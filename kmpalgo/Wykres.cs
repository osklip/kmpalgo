using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace kmpalgo
{
    /// <summary>
    /// Prosty wykres liniowy rysowany ręcznie (GDI+), bez zewnętrznych bibliotek.
    /// Oś X i oś Y zaczynają się od zera, dzięki czemu widać, czy zależność jest liniowa.
    /// </summary>
    public class Wykres : Control
    {
        // Atrybut DesignerSerializationVisibility jest wymagany od .NET 9 (inaczej błąd WFO1000).
        // Visible oznacza, że wartości ustawione w oknie Properties trafiają do pliku Designer.cs.
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string Tytul { get; set; } = "";

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string OpisOsiX { get; set; } = "";

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string OpisOsiY { get; set; } = "";

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color KolorLinii { get; set; } = Color.SteelBlue;

        private double[] wartosciX = new double[0];
        private double[] wartosciY = new double[0];

        // Marginesy obszaru rysowania (miejsce na opisy osi)
        private const int MarginesLewy = 80;
        private const int MarginesPrawy = 45;
        private const int MarginesGorny = 35;
        private const int MarginesDolny = 50;
        private const int LiniiSiatki = 5;

        public Wykres()
        {
            DoubleBuffered = true;  // brak migotania przy odświeżaniu
            ResizeRedraw = true;    // przerysuj po zmianie rozmiaru
            BackColor = Color.White;
        }

        public void UstawDane(double[] x, double[] y)
        {
            wartosciX = x;
            wartosciY = y;
            Invalidate(); // wymusza ponowne narysowanie
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle obszar = new Rectangle(
                MarginesLewy, MarginesGorny,
                Width - MarginesLewy - MarginesPrawy,
                Height - MarginesGorny - MarginesDolny);

            if (obszar.Width < 20 || obszar.Height < 20)
                return;

            using Font czcionka = new Font("Segoe UI", 8.5f);
            using Font czcionkaTytulu = new Font("Segoe UI", 10f, FontStyle.Bold);

            // Tytuł
            g.DrawString(Tytul, czcionkaTytulu, Brushes.Black, MarginesLewy, 8);

            // Zakres osi: od 0 do "ładnej" wartości nie mniejszej niż największa wartość
            double maxX = LadneMaksimum(wartosciX.Length > 0 ? wartosciX.Max() : 1);
            double maxY = LadneMaksimum(wartosciY.Length > 0 ? wartosciY.Max() : 1);

            RysujSiatkeIOpisy(g, obszar, czcionka, maxX, maxY);
            RysujOpisyOsi(g, obszar, czcionka);
            RysujLinie(g, obszar, maxX, maxY);
        }

        private void RysujSiatkeIOpisy(Graphics g, Rectangle obszar, Font czcionka, double maxX, double maxY)
        {
            using Pen piorSiatki = new Pen(Color.Gainsboro);
            using StringFormat doPrawej = new StringFormat { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center };
            using StringFormat doSrodka = new StringFormat { Alignment = StringAlignment.Center };

            for (int k = 0; k <= LiniiSiatki; k++)
            {
                // Linie poziome i opisy osi Y
                float y = obszar.Bottom - k * obszar.Height / (float)LiniiSiatki;
                g.DrawLine(piorSiatki, obszar.Left, y, obszar.Right, y);
                g.DrawString(FormatujLiczbe(maxY * k / LiniiSiatki), czcionka, Brushes.Black, obszar.Left - 6, y, doPrawej);

                // Linie pionowe i opisy osi X
                float x = obszar.Left + k * obszar.Width / (float)LiniiSiatki;
                g.DrawLine(piorSiatki, x, obszar.Top, x, obszar.Bottom);
                g.DrawString(FormatujLiczbe(maxX * k / LiniiSiatki), czcionka, Brushes.Black, x, obszar.Bottom + 5, doSrodka);
            }

            // Osie
            g.DrawLine(Pens.Black, obszar.Left, obszar.Bottom, obszar.Right, obszar.Bottom);
            g.DrawLine(Pens.Black, obszar.Left, obszar.Top, obszar.Left, obszar.Bottom);
        }

        private void RysujOpisyOsi(Graphics g, Rectangle obszar, Font czcionka)
        {
            using StringFormat doSrodka = new StringFormat { Alignment = StringAlignment.Center };

            // Tytuł osi X pod wykresem
            g.DrawString(OpisOsiX, czcionka, Brushes.Black, obszar.Left + obszar.Width / 2f, obszar.Bottom + 25, doSrodka);

            // Tytuł osi Y obrócony o -90 stopni
            g.TranslateTransform(12, obszar.Top + obszar.Height / 2f);
            g.RotateTransform(-90);
            g.DrawString(OpisOsiY, czcionka, Brushes.Black, 0, 0, doSrodka);
            g.ResetTransform();
        }

        private void RysujLinie(Graphics g, Rectangle obszar, double maxX, double maxY)
        {
            if (wartosciX.Length == 0)
                return;

            // Zamiana wartości na współrzędne na ekranie
            PointF[] punkty = new PointF[wartosciX.Length];
            for (int k = 0; k < wartosciX.Length; k++)
            {
                float x = obszar.Left + (float)(wartosciX[k] / maxX * obszar.Width);
                float y = obszar.Bottom - (float)(wartosciY[k] / maxY * obszar.Height);
                punkty[k] = new PointF(x, y);
            }

            using Pen piorLinii = new Pen(KolorLinii, 2);
            using Brush pedzelPunktow = new SolidBrush(KolorLinii);

            if (punkty.Length > 1)
                g.DrawLines(piorLinii, punkty);

            foreach (PointF p in punkty)
                g.FillEllipse(pedzelPunktow, p.X - 4, p.Y - 4, 8, 8);
        }

        /// <summary>
        /// Zaokrągla maksimum osi w górę tak, aby krok siatki był "ładną" liczbą.
        /// Przykłady (5 linii siatki): 11,1 -> 12,5 (krok 2,5); 1 454 921 -> 1 500 000 (krok 300 000).
        /// </summary>
        private static double LadneMaksimum(double max)
        {
            if (max <= 0)
                return 1;

            double krok = max / LiniiSiatki;                                    // krok "surowy"
            double rzadWielkosci = Math.Pow(10, Math.Floor(Math.Log10(krok)));  // rząd wielkości kroku, np. 100 000
            double znormalizowany = krok / rzadWielkosci;                       // liczba z przedziału [1, 10)

            // Wybieramy najmniejszy "ładny" krok, który nie jest mniejszy od kroku surowego
            double[] ladneKroki = { 1, 2, 2.5, 3, 4, 5, 6, 8, 10 };
            double ladnyKrok = 10;
            foreach (double k in ladneKroki)
            {
                if (k >= znormalizowany)
                {
                    ladnyKrok = k;
                    break;
                }
            }

            return ladnyKrok * rzadWielkosci * LiniiSiatki;
        }

        private static string FormatujLiczbe(double wartosc)
        {
            if (wartosc >= 1000)
                return wartosc.ToString("N0");   // np. 1 000 000
            return wartosc.ToString("0.###");     // np. 0,125
        }
    }
}
