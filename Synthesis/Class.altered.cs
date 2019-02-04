
        void DeafultAccesIsPrivate()
        {

        }

        private static void Test()
        {


        }

        static void WithoutAccesibility(int wow)
        {

        }

        private static void Log(string str)
        {
            ConsoleColor aux = ForegroundColor;
            ForegroundColor = ConsoleColor.DarkGreen;
            WriteLine(str);
            ForegroundColor = aux;
        }
        void AccesPrivate(int a, int b, int c)
        {

        }
        protected  void testttt(int x, int z)
        {

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
        public async static bool Test2(bool tist)
        {
            return tist;
        }
        public static string[] Upper(string s, int x)
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
        async static public void LotOfArguments(string x, int a, bool z, byte ix, char del)
        {

        }
