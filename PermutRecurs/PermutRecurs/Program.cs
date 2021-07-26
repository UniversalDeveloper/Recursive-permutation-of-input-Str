using System;
using System.Linq;

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
            if (str.Length<lenRes) throw new Exception("");
            string[] r;
            int count = 0;
            string[] a;
            if (lenRes == 1)
            {
                r = new string[str.Length];           
                var v = outOneEl(str);
                r = concArr(ref r, v, ref count);
                return r;
            }
           
            r = new string[factorial(str.Length)];
            for (int i = 0; i < str.Length; i++)
            {
                var s = remEl(str, i);
                a = get_n_n(s, lenRes - 1);
                var v = concatStr(str[i], a);
                r = concArr(ref r, v, ref count);
            }
            return r;
        }

        public static string[] permutStr(string str)
        {
            int c = 0;
            if (str == null) throw new Exception("Enter the string");
            var count = 0;
            var l = factorial(str.Length);
            var r = new string[l * str.Length];
            for (int i = str.Length; i > 0; i--)
            {
                var v = get_n_n(str, i);
                 c = v.Length;
                r = concArr(ref r, v, ref count);
            }
           int o= c;
          // var a = r.Distinct().ToArray();
            return r;
        }
       public static int countLen(string str)
        {
            int c = 0;
            for (int i = str.Length; i > 0; i--)
            {
                var v = get_n_n(str, i);
                c += v.Length;
               
            }
          return c;

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
          //  var r = permutStr("1234");
            var l = countLen("1234");
            var p = 10;
            //  string[] d = { "1", "2", "3","1" };
            //  var o = delDublic(d);
        }
    }
}
