using System;

namespace PermutForStr
{
    class Program
    {
        public static string[] concatStr(char fixEl, string[] strPerm)
        {
            var r = new string[strPerm.Length];
            for (int i = 0; i < strPerm.Length; i++)
            {
                r[i] = fixEl + strPerm[i];
            }
            return r;
        }
        public static string remEl(string str, int indDel)
        {
            var s = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (i == indDel) continue;
                s += str[i];
            }
            return s;
        }
        public static string[] outOneEl(string str)
        {
            var r = new string[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                r[i] += str[i];
            }
            return r;
        }

        public static string[] get_n_n(string str, int lenRes)
        {
            string[] r = new string[factorial(str.Length)];
            int count = 0;
            string[] a;
            if (lenRes == 1)
            {
                var v = outOneEl(str);
                r = concArr(ref r, v, ref count);
                /* for (int i = 0; i < str.Length; i++)
                 {
                     r[count++] = outOneEl(str)[i];
                 }*/
                return r;
            }

            for (int i = 0; i < str.Length; i++)
            {
                var s = remEl(str, i);
                a = get_n_n(s, lenRes - 1);
                var v = concatStr(str[i], a);
                r = concArr(ref r, v, ref count);
                /* for (int j = 0; j < a.Length; j++)
                 {
                     r[count++] = v[j];
                 }*/
            }
            return r;
        }

        public static string[] permutStr(string str)
        {
            var count = 0;
            var r = new string[factorial(str.Length) * str.Length];
            for (int i = str.Length; i > 0; i--)
            {
                var v = get_n_n(str, i);
                r = concArr(ref r, v, ref count);
                //  r = concArr(r, v);
                /*  for (int j = 0; j < v.Length; j++)
                  {
                      r[count++] = v[j];
                  }*/
            }
            return r;
        }

        public static string[] concArr(ref string[] a, string[] b, ref int count)
        {
            for (int j = 0; j < b.Length; j++)
            {
                a[count++] = b[j];
            }
            return a;
        }

        public static int factorial(int num)
        {
            int a = 1;
            for (int i = 1; i <= num; i++)
            {
                a *= i;
            }
            return a;
        }
        static void Main(string[] args)
        {
            var r = permutStr("123");
            // int i=  factorial(0);
        }
    }
}
