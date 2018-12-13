namespace Playground
{
    using System;
    using static System.Console;

    public static class Class
    {
        public static bool Test2(bool tist)
        {
            return tist;
        }
        public static string Upper(string s, int x)
        {
            string aux = s.ToUpper();
            int y = x;
            return aux;
        }

        protected void Protect(string x, bool y)
        {

        }
        protected void Protectd(string x, bool y, int z)
        {

        }

        private static void Test()
        {


        }

        public static int Count(string s, bool z, float t)
        {
            int length = s.Length;
            return length;
        }

        public static void Main()
        {
            string upper = Upper(@"Mierzejewski, Krzysztof");
            Write($"{upper} = {Count(upper)}");
        }

        private static void Log(string str)
        {
            ConsoleColor aux = ForegroundColor;
            ForegroundColor = ConsoleColor.DarkGreen;
            WriteLine(str);
            ForegroundColor = aux;
        }
        internal int Metod()
        {
            return 4;
        }

    }
}

