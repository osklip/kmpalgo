namespace kmpalgo
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelPattern = new Label();
            textBoxPattern = new TextBox();
            checkBoxIgnoreCase = new CheckBox();
            this.buttonLoadFile = new Button();
            this.buttonNext = new Button();
            this.buttonSearch = new Button();
            buttonChart = new Button();
            buttonOwnText = new Button();
            richTextBoxText = new RichTextBox();
            labelResult = new Label();
            SuspendLayout();
            // 
            // labelPattern
            // 
            labelPattern.AutoSize = true;
            labelPattern.Location = new Point(14, 23);
            labelPattern.Name = "labelPattern";
            labelPattern.Size = new Size(54, 15);
            labelPattern.TabIndex = 0;
            labelPattern.Text = "Wzorzec:";
            // 
            // textBoxPattern
            // 
            textBoxPattern.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxPattern.Location = new Point(90, 20);
            textBoxPattern.Name = "textBoxPattern";
            textBoxPattern.Size = new Size(312, 23);
            textBoxPattern.TabIndex = 1;
            // 
            // checkBoxIgnoreCase
            // 
            checkBoxIgnoreCase.AutoSize = true;
            checkBoxIgnoreCase.Location = new Point(440, 22);
            checkBoxIgnoreCase.Name = "checkBoxIgnoreCase";
            checkBoxIgnoreCase.Size = new Size(135, 19);
            checkBoxIgnoreCase.TabIndex = 2;
            checkBoxIgnoreCase.Text = "Ignoruj wielkość liter";
            checkBoxIgnoreCase.UseVisualStyleBackColor = true;
            // 
            // buttonLoadFile
            // 
            this.buttonLoadFile.Location = new Point(636, 12);
            this.buttonLoadFile.Name = "buttonLoadFile";
            this.buttonLoadFile.Size = new Size(136, 38);
            this.buttonLoadFile.TabIndex = 3;
            this.buttonLoadFile.Text = "Wczytaj plik .txt";
            this.buttonLoadFile.UseVisualStyleBackColor = true;
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new Point(90, 72);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new Size(140, 38);
            this.buttonNext.TabIndex = 4;
            this.buttonNext.Text = "Następne";
            this.buttonNext.UseVisualStyleBackColor = true;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new Point(262, 72);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new Size(140, 38);
            this.buttonSearch.TabIndex = 5;
            this.buttonSearch.Text = "Szukaj";
            this.buttonSearch.UseVisualStyleBackColor = true;
            // 
            // buttonChart
            // 
            buttonChart.Location = new Point(440, 72);
            buttonChart.Name = "buttonChart";
            buttonChart.Size = new Size(136, 38);
            buttonChart.TabIndex = 6;
            buttonChart.Text = "Wykres czasu";
            buttonChart.UseVisualStyleBackColor = true;
            // 
            // buttonOwnText
            // 
            buttonOwnText.Location = new Point(636, 72);
            buttonOwnText.Name = "buttonOwnText";
            buttonOwnText.Size = new Size(136, 38);
            buttonOwnText.TabIndex = 7;
            buttonOwnText.Text = "Wpisz własny tekst";
            buttonOwnText.UseVisualStyleBackColor = true;
            // 
            // richTextBoxText
            // 
            richTextBoxText.BackColor = Color.White;
            richTextBoxText.DetectUrls = false;
            richTextBoxText.HideSelection = false;
            richTextBoxText.Location = new Point(6, 120);
            richTextBoxText.Name = "richTextBoxText";
            richTextBoxText.Size = new Size(772, 290);
            richTextBoxText.TabIndex = 8;
            richTextBoxText.Text = "";
            // 
            // labelResult
            // 
            labelResult.AutoSize = true;
            labelResult.Location = new Point(8, 418);
            labelResult.Name = "labelResult";
            labelResult.Size = new Size(43, 15);
            labelResult.TabIndex = 9;
            labelResult.Text = "Wynik:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 446);
            Controls.Add(labelResult);
            Controls.Add(richTextBoxText);
            Controls.Add(buttonOwnText);
            Controls.Add(buttonChart);
            Controls.Add(this.buttonSearch);
            Controls.Add(this.buttonNext);
            Controls.Add(this.buttonLoadFile);
            Controls.Add(checkBoxIgnoreCase);
            Controls.Add(textBoxPattern);
            Controls.Add(labelPattern);
            MinimumSize = new Size(800, 400);
            Name = "Form1";
            Text = "Knuth-Morris-Pratt";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelPattern;
        private TextBox textBoxPattern;
        private CheckBox checkBoxIgnoreCase;
        private Button buttonLoadFile;
        private Button buttonNext;
        private Button buttonSearch;
        private Button buttonChart;
        private Button buttonOwnText;
        private RichTextBox richTextBoxText;
        private Label labelResult;
    }
}
