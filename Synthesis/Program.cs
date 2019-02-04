namespace Synthesis
{
    using System;
    using System.IO;
    using System.Linq;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    //Program na bazie projektu Pana mgr Mierzejewskiego

    //Program przerobił szer. pchor. Damian TOMASIK
    //Grupa I6B1S1

         //Temat :
         /* 
        7.Sortowanie metod w klasie
    Wszystkie metody znajdujące się w klasie mają zostać poprzestawiane w taki sposób,
    żeby występowały zgodnie z porządkiem leksykograficznym następujących reguł:
    1.	dostępność private, protected, internal, public
    2.	kolejność zgodnie z liczbą argumentów metody, od najmniejszej liczby argumentów.
        */

    public static class Program
    {
        private static readonly string AssemblyPath = Path.GetDirectoryName(typeof(object).Assembly.Location);

        public static void Main()
        {
            SyntaxTree tree = CSharpSyntaxTree.ParseText(File.ReadAllText("Class.cs"));
            var newRoot = new Rewriter();
            var x = newRoot.Visit(tree.GetRoot());
            String newCode = null;
            
            Console.WriteLine("Program Wykonał szer. pchor. Damian TOMASIK");
            
            foreach(MethodDeclarationSyntax md in newRoot.nodeList )
            {
                newCode += md.GetText().ToString();
            }

            File.WriteAllText(@"..\..\Class.altered.cs", newCode);

            var mscorlib = MetadataReference.CreateFromFile(Path.Combine(AssemblyPath, "mscorlib.dll"));
            var system = MetadataReference.CreateFromFile(Path.Combine(AssemblyPath, "System.dll"));
            var systemCore = MetadataReference.CreateFromFile(Path.Combine(AssemblyPath, "System.Core.dll"));

            var compilation = CSharpCompilation.Create(
                "Altered",
                syntaxTrees: new[] { x.SyntaxTree },
                references: new[] { mscorlib, system, systemCore },
                options: new CSharpCompilationOptions(OutputKind.ConsoleApplication));

            foreach (var item in compilation.GetDiagnostics())
                Console.WriteLine($"Diagnostics: {item}");

            var emitResult = compilation.Emit("Altered.exe", "Altered.pdb");

            if (!emitResult.Success)
                foreach (var error in emitResult.Diagnostics)
                    Console.WriteLine(error);
            

            Console.ReadKey();
        }
    }
}
