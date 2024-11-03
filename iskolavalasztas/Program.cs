using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iskolavalasztas
{
    internal class Program
    {

        static int N, M;
        static int[] Van;
        static int[] Y;
        static int[,] Igeny;
        static int[] Kapacitas;

        static void Iskola()
        {
            int i = 1;

            for (int k = 0; k < Y.Length; k++)
                Y[k] = 0;

            while (i >= 1 && i <= N)
            {
                Jóesetkeresés(i);

                if (Van[i] == 1)
                    i++;
                else
                {
                    Y[i - 1] = 0;
                    i--;
                }
            }
        }

        static void Jóesetkeresés(int i)
        {
            int j = Y[i - 1] + 1;
            Van[i] = 0;

            while (j <= M && Van[i] == 0)
            {
                if (Igeny[i - 1, 1] == 0)
                {
                    Y[i - 1] = Igeny[i - 1, 0];
                    Van[i] = 1;
                }
                else
                {
                    if (!rossz(j, i))
                    {
                        Y[i - 1] = j;
                        Van[i] = 1;
                    }
                }
                j++;
            }
        }

        static bool rossz(int j, int i)
        {
            int db = 0;
            for (int k = 0; k < N; k++)
            {
                if ((Igeny[k, 0] == j || Igeny[k, 1] == j) && Y[k] == j)
                {
                    db++;
                }
            }
            return db >= Kapacitas[j - 1];
        }

        static void Main(string[] args)
        {
            string[] firstLine = Console.ReadLine().Split();
            N = int.Parse(firstLine[0]);
            M = int.Parse(firstLine[1]);

            Van = new int[N + 1];
            Y = new int[N];
            Igeny = new int[N, 2];
            Kapacitas = new int[M];

            for (int i = 0; i < N; i++)
            {
                int[] vallasztottak = Console.ReadLine().Split().Select(int.Parse).ToArray();
                Igeny[i, 0] = vallasztottak[0];
                Igeny[i, 1] = vallasztottak[1];
            }

            for (int i = 0; i < M; i++)
            {
                Kapacitas[i] = int.Parse(Console.ReadLine());
            }

            Iskola();

            Console.WriteLine(string.Join(" ", Y));
        }

    }

}
