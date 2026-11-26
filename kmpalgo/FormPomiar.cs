using System.Diagnostics;
using System.Text;

namespace kmpalgo
{
    /// <summary>
    /// Okno pomiaru: dla każdego pliku z folderu "Teksty" mierzy czas działania KMP
    /// i liczbę porównań znaków, a wyniki pokazuje na wykresach i w tabeli.
    /// </summary>
    public partial class FormPomiar : Form
    {
        private readonly Algorytm kmp = new Algorytm();

        public FormPomiar()
        {
            InitializeComponent();
        }

        private void buttonMeasure_Click(object? sender, EventArgs e)
        {
            string wzorzec = textBoxPattern.Text;
            if (wzorzec.Length == 0)
            {
                labelInfo.Text = "Wpisz wzorzec.";
                return;
            }

            // Pliki z tekstami leżą w folderze "Teksty" obok programu
            string folder = Path.Combine(AppContext.BaseDirectory, "Teksty");
            if (!Directory.Exists(folder))
            {
                labelInfo.Text = "Nie znaleziono folderu: " + folder;
                return;
            }

            // Nazwy plików tekst_01.txt, tekst_02.txt, ... - sortowanie po nazwie
            // daje kolejność od najkrótszego do najdłuższego tekstu
            string[] pliki = Directory.GetFiles(folder, "*.txt");
            Array.Sort(pliki);
            if (pliki.Length == 0)
            {
                labelInfo.Text = "Folder Teksty jest pusty.";
                return;
            }

            int powtorzenia = (int)numericUpDownRepetitions.Value;

            double[] dlugosci = new double[pliki.Length];
            double[] czasy = new double[pliki.Length];
            double[] porownania = new double[pliki.Length];

            dataGridViewResults.Rows.Clear();
            buttonMeasure.Enabled = false;
            Cursor = Cursors.WaitCursor;
            labelInfo.Text = "Trwa pomiar...";
            labelInfo.Refresh();

            for (int k = 0; k < pliki.Length; k++)
            {
                string tekst = File.ReadAllText(pliki[k], Encoding.UTF8);

                // Pierwsze uruchomienie "na rozgrzewkę" (kompilacja JIT),
                // żeby nie zawyżało czasu pierwszego pliku
                kmp.Szukaj(tekst, wzorzec);

                // Mierzymy kilka powtórzeń i liczymy średnią - pojedynczy pomiar jest zbyt niedokładny
                Stopwatch stoper = Stopwatch.StartNew();
                List<int> pozycje = new List<int>();
                for (int r = 0; r < powtorzenia; r++)
                {
                    pozycje = kmp.Szukaj(tekst, wzorzec);
                }
                stoper.Stop();

                double sredniCzas = stoper.Elapsed.TotalMilliseconds / powtorzenia;

                dlugosci[k] = tekst.Length;
                czasy[k] = sredniCzas;
                porownania[k] = kmp.LiczbaPorownan;

                dataGridViewResults.Rows.Add(
                    Path.GetFileName(pliki[k]),
                    tekst.Length.ToString("N0"),
                    sredniCzas.ToString("0.000"),
                    kmp.LiczbaPorownan.ToString("N0"),
                    ((double)kmp.LiczbaPorownan / tekst.Length).ToString("0.000"),
                    pozycje.Count.ToString("N0"));
            }

            chartTime.UstawDane(dlugosci, czasy);
            chartComparisons.UstawDane(dlugosci, porownania);

            Cursor = Cursors.Default;
            buttonMeasure.Enabled = true;
            labelInfo.Text = "Gotowe. Zmierzono " + pliki.Length + " plików, " + powtorzenia + " powtórzeń każdy.";
        }
    }
}
