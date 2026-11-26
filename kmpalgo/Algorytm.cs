using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;
using System.Text;

namespace kmpalgo
{
    internal class Algorytm
    {
        public int ComparisonCount { get; private set; }

        public int[] BudujTabliceLPS(string wzorzec)
        {
            int m = wzorzec.Length, len = 0, i = 1;
            int[] lps = new int[m];
            lps[0] = 0;

            while ( i < m)
            {
                ComparisonCount++;
                if (wzorzec[i] == wzorzec[len])
                {
                    len++;
                    lps[i] = len;
                    i++;
                }
                else if (len > 0)
                {
                    len = lps[len - 1];
                }
                else
                {
                    lps[i] = 0;
                    i++;
                }
            }
            return lps;
        }

        public List<int> Szukaj(string tekst, string wzorzec)
        {
            ComparisonCount = 0;
            List<int> pozycje = new List<int>();

            int n = tekst.Length;
            int m = wzorzec.Length;

            if (m == 0 || m > n)
                return pozycje;

            int[] lps = BudujTabliceLPS(wzorzec);

            int i = 0, j = 0;

            while (i < n)
            {
                ComparisonCount++;
                if (tekst[i] == wzorzec[j])
                {
                    i++;
                    j++;
                    if (j == m)
                    {
                        pozycje.Add(i - j);
                        j = lps[j - 1];
                    }
                }
                else if (j > 0)
                {
                    j = lps[j - 1];
                }
                else
                {
                    i++;
                }
            }
            return pozycje;
        }
    }
}
