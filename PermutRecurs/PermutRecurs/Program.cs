using System;
using System.Diagnostics;
using System.Linq;

namespace PermutForStr
{
    class Program
    {
        public static int calcElArr(int l, int lenRes)
        {
            return lenRes == 1 
                ? l 
                : l * calcElArr(l-1,lenRes - 1);
        }

        public static int countLenAr(int l)
        {
            int c;
            int u = 0;
            for (int i = l; i > 0; i--)
            {
                c = calcElArr(l, i);
                u += c;
            }
            int p = u;
            return p;
        }

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
           // if (str.Length < lenRes) throw new Exception("");
            string[] r;
            int count = 0;
            
            if (lenRes == 1)
            {
                 r = new string[str.Length];
                 var v = outOneEl(str);
                r = concArr(ref r, v, ref count);                
                return r;
            }
            string[] a;
            r = new string[calcElArr(str.Length,lenRes)];
            for (int i = 0; i < str.Length; i++)
            {
                var s = remEl(str, i);
                a = get_n_n(s, lenRes - 1);

                var v = concatStr(str[i], a);
                r = concArr(ref r, v, ref count);            

            }
           
            return r;
        }
        public static void logArr(string caption, string[] r)
        {
            //Console.WriteLine(caption);
            //foreach (var item in r)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine("---");
            Console.WriteLine();
            Debug.WriteLine(caption);
            foreach (var item in r)
            {
                Debug.WriteLine(item);
            }
            Debug.WriteLine("---");
        }

        public static string[] permutStr(string str)
        {
            if (str == null) throw new Exception("Enter the string");
            var count = 0;
            var l = countLenAr(str.Length);
            string[] r = new string[l];

            for (int i = str.Length; i > 0; i--)
            {
                var v = get_n_n(str, i);
                logArr(string.Format("n-n {0}, {1}", str.Length, i), v);
                r = concArr(ref r, v, ref count);                
            }            
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
            var r = permutStr("12345658");
            // var r = calcLenArrorTow("1234");
         //   var r = countLenAr("1234");
         //   var l = countLen("12345");
          //  var p = 10;
            //  string[] d = { "1", "2", "3","1" };
            //  var o = delDublic(d);
        }
    }
}
