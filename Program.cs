using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faculta_7
{
    internal class Program 
    {
        static void Main(string[] args)
        {
           /* Problema6();*/
           /* Problema7();*/
            Dt x=new Dt();
            Console.Write(x.Ret());
        }
        

        static void Problema6()
        {
            int[] a = FileReader();
            int n = a.Length;
            bool ok = true;
            do
            {
                ok = true;
                for (int i = n - 1; i >= 1; i--)
                {
                    if (a[i] == a[i - 1] && a[i] != 0)
                    {
                        a[i - 1] *= 2;
                        for (int j = i; j < n - 1; j++)
                            a[j] = a[j + 1];
                        n--;
                        ok = false;
                    }
                }
            } while (!ok);
            for (int i = 0; i < n; i++)
                Console.Write($"{a[i]} ");
        }

        static void Problema7()
        {
            int s = 0, idx = 1;
            int nr = int.Parse(Console.ReadLine());
            int[] a = new int[10];
            while(nr!=0)
            {
                a[nr % 10]++;
                nr /= 10;
            }

            if (a[0] != 0)
            {
                idx = 1;
                while (a[idx] == 0) idx++;
                s = idx;
                a[idx]--;
            }

            for (int i = 0; i < 10; i++)
                for (int j = 0; j < a[i]; j++)
                    s = s * 10 + i;
            Console.WriteLine(s);
        }

        public class Dt
        {
            int a, z, l, m, h, s;
            public Dt()
            {
                a = 2011;
                l = 4;
                z = 23;
                h = 13;
                m = 23;
                s = 47;
            }
            public ulong Ret()
            {
                ulong zl = (ulong)(a - 1) * 365;
                zl += (ulong)AniBisecti(a - 1);
                zl += (ulong)Zile(l - 1);
                zl += (ulong)z - 1;
                if (AnBisect(a) || l > 2)
                    zl++;
                ulong sec = (ulong)(zl* 24 * 3600);
                sec += (ulong)(h - 1) * 3600;
                sec += (ulong)(m - 1) * 60;
                sec += (ulong)s;
                return sec;

            }
        }
        public static int Zile(int luna)
        {
            switch(luna)
            {
                case 0:
                    return 0;
                case 1:
                    return 31;
                case 2:
                    return 28;
                case 3:
                    return 31;
                case 4:
                    return 30;
                case 5:
                    return 31;
                case 6:
                    return 30;
                case 7:
                    return 31;
                case 8:
                    return 31;
                case 9:
                    return 30;
                case 10:
                    return 31;
                case 11:
                    return 30;
                case 12:
                    return 31;
                default:
                    return -1;
            }
        }
        public static bool AnBisect(int a)
        {
            if (a % 400 == 0 || (a % 4 == 0 && a % 100 != 0))
                return true;
            return false;
        }

        public static int AniBisecti(int a)
        {
            int b = 0;
            for(int i = 0; i<=a;i++)
                if (AnBisect(i))
                    b++;
            return b;
        }

        static int[] FileReader()
        {
            TextReader load = new StreamReader(@"Resources.txt");
            string[] buffer = load.ReadLine().Split(',');
            int[] a = new int[buffer.Length];
            for (int i = 0; i < a.Length; i++)
                a[i] = int.Parse(buffer[i]);
           
            return a;
        }

    }
}
