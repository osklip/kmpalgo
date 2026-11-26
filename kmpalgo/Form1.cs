using System.Diagnostics;
using System.Text;

namespace kmpalgo
{
    public partial class Form1 : Form
    {
        // Ile wystąpień najwyżej podświetlać (podświetlanie w RichTextBox jest wolne)
        private const int MaksPodswietlen = 1000;
        // Ile pozycji najwyżej wypisywać w polu "Wynik"
        private const int MaksWypisanychPozycji = 10;

        private readonly Algorytm kmp = new Algorytm();

        // Wyniki ostatniego wyszukiwania
        private List<int> pozycje = new List<int>();
        private int aktualnyIndeks = -1;       // które wystąpienie zaznaczył przycisk "Następne"
        private string? ostatniTekst;          // w jakim tekście szukaliśmy
        private string? ostatniWzorzec;        // jakiego wzorca szukaliśmy
        private bool ignorujWielkoscLiter;     // czy przy ostatnim szukaniu ignorowano wielkość liter

        public Form1()
        {
            InitializeComponent();
        }

        // ---------------- Przyciski ----------------

        private void buttonSearch_Click(object? sender, EventArgs e)
        {
            UruchomWyszukiwanie();
        }

        private void buttonNext_Click(object? sender, EventArgs e)
        {
            // Jeśli tekst, wzorzec lub opcja się zmieniły, najpierw szukamy od nowa
            if (WynikNieaktualny())
            {
                UruchomWyszukiwanie();
            }

            if (pozycje.Count == 0 || ostatniWzorzec == null)
                return;

            // Kolejne wystąpienie; po ostatnim wracamy do pierwszego
            aktualnyIndeks = (aktualnyIndeks + 1) % pozycje.Count;
            int pozycja = pozycje[aktualnyIndeks];

            richTextBoxText.Focus();
            richTextBoxText.Select(pozycja, ostatniWzorzec.Length);
            richTextBoxText.ScrollToCaret();

            labelResult.Text = "Wynik: wystąpienie " + (aktualnyIndeks + 1) + " z " + pozycje.Count
                             + ", pozycja " + pozycja + ".";
        }

        private void buttonLoadFile_Click(object? sender, EventArgs e)
        {
            using OpenFileDialog okno = new OpenFileDialog();
            okno.Filter = "Pliki tekstowe (*.txt)|*.txt";
            okno.Title = "Wybierz plik z tekstem";

            // Okno wyboru pliku otwiera się w folderze z przykładowymi tekstami
            string folderPrzykladow = Path.Combine(AppContext.BaseDirectory, "Przyklady");
            if (Directory.Exists(folderPrzykladow))
                okno.InitialDirectory = folderPrzykladow;

            if (okno.ShowDialog() != DialogResult.OK)
                return;

            richTextBoxText.Text = File.ReadAllText(okno.FileName, Encoding.UTF8);
            richTextBoxText.ReadOnly = true; // tekst z pliku tylko do odczytu
            WyczyscWyniki();
            labelResult.Text = "Wynik: wczytano plik " + Path.GetFileName(okno.FileName)
                             + " (" + richTextBoxText.TextLength + " znaków).";
        }

        private void buttonOwnText_Click(object? sender, EventArgs e)
        {
            richTextBoxText.ReadOnly = false;
            richTextBoxText.Clear();
            WyczyscWyniki();
            labelResult.Text = "Wynik: wpisz tekst w polu poniżej.";
            richTextBoxText.Focus();
        }

        private void buttonChart_Click(object? sender, EventArgs e)
        {
            FormPomiar oknoPomiaru = new FormPomiar();
            oknoPomiaru.Show();
        }

        // ---------------- Wyszukiwanie ----------------

        private void UruchomWyszukiwanie()
        {
            string tekst = richTextBoxText.Text;
            string wzorzec = textBoxPattern.Text;
            bool ignoruj = checkBoxIgnoreCase.Checked;

            WyczyscWyniki();

            if (wzorzec.Length == 0)
            {
                labelResult.Text = "Wynik: wpisz wzorzec.";
                return;
            }
            if (tekst.Length == 0)
            {
                labelResult.Text = "Wynik: brak tekstu do przeszukania.";
                return;
            }

            // Ignorowanie wielkości liter: porównujemy wersje zapisane małymi literami.
            // Długość tekstu się nie zmienia, więc pozycje pozostają poprawne.
            string tekstDoSzukania = ignoruj ? tekst.ToLowerInvariant() : tekst;
            string wzorzecDoSzukania = ignoruj ? wzorzec.ToLowerInvariant() : wzorzec;

            Stopwatch stoper = Stopwatch.StartNew();
            pozycje = kmp.Szukaj(tekstDoSzukania, wzorzecDoSzukania);
            stoper.Stop();

            ostatniTekst = tekst;
            ostatniWzorzec = wzorzec;
            ignorujWielkoscLiter = ignoruj;

            PodswietlWystapienia(wzorzec.Length);
            PokazWynik(stoper.Elapsed.TotalMilliseconds);
        }

        private bool WynikNieaktualny()
        {
            return ostatniTekst != richTextBoxText.Text
                || ostatniWzorzec != textBoxPattern.Text
                || ignorujWielkoscLiter != checkBoxIgnoreCase.Checked;
        }

        private void WyczyscWyniki()
        {
            pozycje = new List<int>();
            aktualnyIndeks = -1;
            ostatniTekst = null;
            ostatniWzorzec = null;
            UsunPodswietlenie();
        }

        // ---------------- Podświetlanie ----------------

        private void PodswietlWystapienia(int dlugoscWzorca)
        {
            int ile = Math.Min(pozycje.Count, MaksPodswietlen);
            for (int k = 0; k < ile; k++)
            {
                richTextBoxText.Select(pozycje[k], dlugoscWzorca);
                richTextBoxText.SelectionBackColor = Color.Yellow;
            }
            richTextBoxText.Select(0, 0);
        }

        private void UsunPodswietlenie()
        {
            richTextBoxText.SelectAll();
            richTextBoxText.SelectionBackColor = richTextBoxText.BackColor;
            richTextBoxText.Select(0, 0);
        }

        // ---------------- Wynik ----------------

        private void PokazWynik(double milisekundy)
        {
            string wynik = "Wynik: liczba wystąpień: " + pozycje.Count;

            if (pozycje.Count > 0)
            {
                int ile = Math.Min(pozycje.Count, MaksWypisanychPozycji);
                wynik += " (pozycje: " + string.Join(", ", pozycje.Take(ile));
                if (pozycje.Count > ile)
                    wynik += ", ...";
                wynik += ")";
            }

            wynik += "   |   porównań: " + kmp.LiczbaPorownan
                   + "   |   czas: " + milisekundy.ToString("0.000") + " ms";

            if (pozycje.Count > MaksPodswietlen)
                wynik += "   |   podświetlono pierwsze " + MaksPodswietlen;

            labelResult.Text = wynik;
        }
    }
}
