namespace Synthesis
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    internal sealed class Rewriter : CSharpSyntaxRewriter
    {
        List<String> list = new List<String>();
        List<int> listAccess = new List<int>();
        List<int> listAtributes = new List<int>();
        public List<MethodDeclarationSyntax> nodeList = new List<MethodDeclarationSyntax>();
        
        public void SortMethods()
        {
            int n = list.Count;
            do
            {
                for (int i = 0; i < n - 1; i++)
                {
                    if (listAccess.ElementAt(i) > listAccess.ElementAt(i + 1))
                    {
                        var tmp = listAccess[i];
                        listAccess[i] = listAccess[i + 1];
                        listAccess[i + 1] = tmp;

                        var tmp2 = list[i];
                        list[i] = list[i + 1];
                        list[i + 1] = tmp2;

                        var tmp3 = nodeList[i];
                        nodeList[i] = nodeList[i + 1];
                        nodeList[i + 1] = tmp3;

                        var tmp4 = listAtributes[i];
                        listAtributes[i] = listAtributes[i + 1];
                        listAtributes[i + 1] = tmp4;
                    }
                }
                n--;
            } while (n > 1);
            n = list.Count;
            do
            {
                for (int i = 0; i < n - 1; i++)
                {
                    if (listAccess.ElementAt(i) == listAccess.ElementAt(i + 1))
                    {
                        if (listAtributes.ElementAt(i) > listAtributes.ElementAt(i + 1))
                        {
                            var tmp = listAccess[i];
                            listAccess[i] = listAccess[i + 1];
                            listAccess[i + 1] = tmp;

                            var tmp2 = list[i];
                            list[i] = list[i + 1];
                            list[i + 1] = tmp2;

                            var tmp3 = nodeList[i];
                            nodeList[i] = nodeList[i + 1];
                            nodeList[i + 1] = tmp3;

                            var tmp4 = listAtributes[i];
                            listAtributes[i] = listAtributes[i + 1];
                            listAtributes[i + 1] = tmp4;
                        }
                    }
                }
                n--;
            } while (n > 1);
            
        }
        
        public override SyntaxNode VisitMethodDeclaration(MethodDeclarationSyntax node)
        {
            var tokenTmp = node.GetFirstToken().ToString();
            
            list.Add(tokenTmp);
            nodeList.Add(node);
            switch (tokenTmp)
            {
                case "private":
                    listAccess.Add(1);
                    break;
                case "protected":
                    listAccess.Add(2);
                    break;
                case "internal":
                    listAccess.Add(3);
                    break;
                case "public":
                    listAccess.Add(4);
                    break;
            }

            //Zbędne komentarze służyły do testowania, pozdrawiam ;)

            /*Console.WriteLine("Posortowane? :O ");
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(listAccess.ElementAt(i));
            }
            Console.WriteLine("............");*/

            return base.VisitMethodDeclaration(node);

        }
        public override SyntaxNode VisitParameterList(ParameterListSyntax node)
        {
            var Attributes = node.Parameters;
            listAtributes.Add(Attributes.Count);
           

            SortMethods();
            //Console.WriteLine("----------------");
            /*for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine("Acces: "+listAccess.ElementAt(i)+" Attrybutyyyy: " + listAtributes.ElementAt(i));
            }
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(nodeList.ElementAt(i));
            }
            */
                return base.VisitParameterList(node);
        }
    }
}
