
        private static void Test()
        {


        }

        private static void Log(string str)
        {
            ConsoleColor aux = ForegroundColor;
            ForegroundColor = ConsoleColor.DarkGreen;
            WriteLine(str);
            ForegroundColor = aux;
        }

        protected void Protect(string x, bool y)
        {

        }
        protected void Protectd(string x, bool y, int z)
        {

        }
        internal int Metod()
        {
            return 4;
        }

        public static void Main()
        {
            string upper = Upper(@"Mierzejewski, Krzysztof");
            Write($"{upper} = {Count(upper)}");
        }
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

        public static int Count(string s, bool z, float t)
        {
            int length = s.Length;
            return length;
        }
