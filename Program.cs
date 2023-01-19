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
            Problema7();
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
