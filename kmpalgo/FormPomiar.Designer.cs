namespace kmpalgo
{
    partial class FormPomiar
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panelTop = new Panel();
            labelPattern = new Label();
            textBoxPattern = new TextBox();
            labelRepetitions = new Label();
            numericUpDownRepetitions = new NumericUpDown();
            buttonMeasure = new Button();
            labelInfo = new Label();
            tableLayoutPanelMain = new TableLayoutPanel();
            chartTime = new Wykres();
            chartComparisons = new Wykres();
            dataGridViewResults = new DataGridView();
            columnFile = new DataGridViewTextBoxColumn();
            columnLength = new DataGridViewTextBoxColumn();
            columnTime = new DataGridViewTextBoxColumn();
            columnComparisons = new DataGridViewTextBoxColumn();
            columnRatio = new DataGridViewTextBoxColumn();
            columnOccurrences = new DataGridViewTextBoxColumn();
            panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownRepetitions).BeginInit();
            tableLayoutPanelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewResults).BeginInit();
            SuspendLayout();
            //
            // panelTop
            //
            panelTop.Controls.Add(labelPattern);
            panelTop.Controls.Add(textBoxPattern);
            panelTop.Controls.Add(labelRepetitions);
            panelTop.Controls.Add(numericUpDownRepetitions);
            panelTop.Controls.Add(buttonMeasure);
            panelTop.Controls.Add(labelInfo);
            panelTop.Dock = DockStyle.Top;
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1000, 56);
            //
            // labelPattern
            //
            labelPattern.AutoSize = true;
            labelPattern.Location = new Point(12, 20);
            labelPattern.Name = "labelPattern";
            labelPattern.Text = "Wzorzec:";
            //
            // textBoxPattern
            //
            textBoxPattern.Location = new Point(75, 17);
            textBoxPattern.Name = "textBoxPattern";
            textBoxPattern.Size = new Size(160, 23);
            textBoxPattern.TabIndex = 0;
            textBoxPattern.Text = "ABABCAB";
            //
            // labelRepetitions
            //
            labelRepetitions.AutoSize = true;
            labelRepetitions.Location = new Point(255, 20);
            labelRepetitions.Name = "labelRepetitions";
            labelRepetitions.Text = "Powtórzeń:";
            //
            // numericUpDownRepetitions
            //
            numericUpDownRepetitions.Location = new Point(330, 17);
            numericUpDownRepetitions.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDownRepetitions.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownRepetitions.Name = "numericUpDownRepetitions";
            numericUpDownRepetitions.Size = new Size(70, 23);
            numericUpDownRepetitions.TabIndex = 1;
            numericUpDownRepetitions.Value = new decimal(new int[] { 50, 0, 0, 0 });
            //
            // buttonMeasure
            //
            buttonMeasure.Location = new Point(420, 9);
            buttonMeasure.Name = "buttonMeasure";
            buttonMeasure.Size = new Size(140, 38);
            buttonMeasure.TabIndex = 2;
            buttonMeasure.Text = "Wykonaj pomiar";
            buttonMeasure.UseVisualStyleBackColor = true;
            buttonMeasure.Click += buttonMeasure_Click;
            //
            // labelInfo
            //
            labelInfo.AutoSize = true;
            labelInfo.Location = new Point(580, 20);
            labelInfo.Name = "labelInfo";
            labelInfo.Text = "Kliknij \"Wykonaj pomiar\".";
            //
            // tableLayoutPanelMain
            //
            tableLayoutPanelMain.ColumnCount = 2;
            tableLayoutPanelMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelMain.Controls.Add(chartTime, 0, 0);
            tableLayoutPanelMain.Controls.Add(chartComparisons, 1, 0);
            tableLayoutPanelMain.Controls.Add(dataGridViewResults, 0, 1);
            tableLayoutPanelMain.SetColumnSpan(dataGridViewResults, 2);
            tableLayoutPanelMain.Dock = DockStyle.Fill;
            tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            tableLayoutPanelMain.RowCount = 2;
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 62F));
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 38F));
            //
            // chartTime
            //
            chartTime.Dock = DockStyle.Fill;
            chartTime.Name = "chartTime";
            chartTime.Tytul = "Czas wykonania KMP";
            chartTime.OpisOsiX = "Długość tekstu n [znaki]";
            chartTime.OpisOsiY = "Czas [ms]";
            chartTime.KolorLinii = Color.SteelBlue;
            //
            // chartComparisons
            //
            chartComparisons.Dock = DockStyle.Fill;
            chartComparisons.Name = "chartComparisons";
            chartComparisons.Tytul = "Liczba porównań znaków";
            chartComparisons.OpisOsiX = "Długość tekstu n [znaki]";
            chartComparisons.OpisOsiY = "Liczba porównań";
            chartComparisons.KolorLinii = Color.DarkOrange;
            //
            // dataGridViewResults
            //
            dataGridViewResults.AllowUserToAddRows = false;
            dataGridViewResults.AllowUserToDeleteRows = false;
            dataGridViewResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewResults.BackgroundColor = Color.White;
            dataGridViewResults.Columns.AddRange(new DataGridViewColumn[] { columnFile, columnLength, columnTime, columnComparisons, columnRatio, columnOccurrences });
            dataGridViewResults.Dock = DockStyle.Fill;
            dataGridViewResults.Name = "dataGridViewResults";
            dataGridViewResults.ReadOnly = true;
            dataGridViewResults.RowHeadersVisible = false;
            //
            // kolumny tabeli
            //
            columnFile.HeaderText = "Plik";
            columnFile.Name = "columnFile";
            columnLength.HeaderText = "Długość tekstu n";
            columnLength.Name = "columnLength";
            columnTime.HeaderText = "Średni czas [ms]";
            columnTime.Name = "columnTime";
            columnComparisons.HeaderText = "Liczba porównań";
            columnComparisons.Name = "columnComparisons";
            columnRatio.HeaderText = "Porównania / n";
            columnRatio.Name = "columnRatio";
            columnOccurrences.HeaderText = "Liczba wystąpień";
            columnOccurrences.Name = "columnOccurrences";
            //
            // FormPomiar
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 680);
            Controls.Add(tableLayoutPanelMain);
            Controls.Add(panelTop);
            MinimumSize = new Size(800, 550);
            Name = "FormPomiar";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "KMP - czas wykonania w zależności od długości tekstu";
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownRepetitions).EndInit();
            tableLayoutPanelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewResults).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Label labelPattern;
        private TextBox textBoxPattern;
        private Label labelRepetitions;
        private NumericUpDown numericUpDownRepetitions;
        private Button buttonMeasure;
        private Label labelInfo;
        private TableLayoutPanel tableLayoutPanelMain;
        private Wykres chartTime;
        private Wykres chartComparisons;
        private DataGridView dataGridViewResults;
        private DataGridViewTextBoxColumn columnFile;
        private DataGridViewTextBoxColumn columnLength;
        private DataGridViewTextBoxColumn columnTime;
        private DataGridViewTextBoxColumn columnComparisons;
        private DataGridViewTextBoxColumn columnRatio;
        private DataGridViewTextBoxColumn columnOccurrences;
    }
}
