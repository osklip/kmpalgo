namespace kmpalgo
{
    public partial class Form1 : Form
    {
        private readonly Algorytm kmp = new Algorytm();
        private List<int> pozycje = new List<int>();
        private int aktualnyIndeks = -1;
        private string? ostatniTekst;
        private string? ostatniWzorzec;
        private bool ignorujWielkoscLiter;

        public Form1()
        {
            InitializeComponent();
        }



    }
}
