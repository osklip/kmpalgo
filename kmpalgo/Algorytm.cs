using System;
using System.Collections.Generic;
using System.Text;

namespace kmpalgo
{
    /// <summary>
    /// Algorytm Knutha-Morrisa-Pratta.
    /// Oznaczenia jak w notatkach: tekst (n - długość, i - wskaźnik),
    /// wzorzec (m - długość, j - wskaźnik), lps - tablica prefikso-sufiksowa.
    /// </summary>
    internal class Algorytm
    {
        // Liczba porównań znaków w ostatnim wywołaniu Szukaj (budowa LPS + wyszukiwanie)
        public long LiczbaPorownan { get; private set; }

        public int[] BudujTabliceLPS(string wzorzec)
        {
            int m = wzorzec.Length, len = 0, i = 1;
            int[] lps = new int[m];
            lps[0] = 0;

            while ( i < m)
            {
                LiczbaPorownan++;
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
            LiczbaPorownan = 0;
            List<int> pozycje = new List<int>();

            int n = tekst.Length;
            int m = wzorzec.Length;

            if (m == 0 || m > n)
                return pozycje;

            int[] lps = BudujTabliceLPS(wzorzec);

            int i = 0, j = 0;

            while (i < n)
            {
                LiczbaPorownan++;
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
