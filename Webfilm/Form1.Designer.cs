namespace Webfilm
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanelMovies = new System.Windows.Forms.FlowLayoutPanel();
            this.title1Label = new System.Windows.Forms.Label();
            this.title2Label = new System.Windows.Forms.Label();
            this.nextPageButton = new System.Windows.Forms.Button();
            this.previousPageButton = new System.Windows.Forms.Button();
            this.pageNumberLabel = new System.Windows.Forms.Label();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.searchButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // flowLayoutPanelMovies
            // 
            this.flowLayoutPanelMovies.AutoScroll = true;
            this.flowLayoutPanelMovies.Location = new System.Drawing.Point(-5, 84);
            this.flowLayoutPanelMovies.Name = "flowLayoutPanelMovies";
            this.flowLayoutPanelMovies.Size = new System.Drawing.Size(805, 385);
            this.flowLayoutPanelMovies.TabIndex = 0;
            // 
            // title1Label
            // 
            this.title1Label.AutoSize = true;
            this.title1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.title1Label.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.title1Label.Location = new System.Drawing.Point(269, 8);
            this.title1Label.Name = "title1Label";
            this.title1Label.Size = new System.Drawing.Size(65, 29);
            this.title1Label.TabIndex = 0;
            this.title1Label.Text = "Web";
            // 
            // title2Label
            // 
            this.title2Label.AutoSize = true;
            this.title2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.title2Label.ForeColor = System.Drawing.Color.Yellow;
            this.title2Label.Location = new System.Drawing.Point(325, 9);
            this.title2Label.Name = "title2Label";
            this.title2Label.Size = new System.Drawing.Size(62, 29);
            this.title2Label.TabIndex = 1;
            this.title2Label.Text = "Film";
            // 
            // nextPageButton
            // 
            this.nextPageButton.BackColor = System.Drawing.Color.White;
            this.nextPageButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.nextPageButton.Location = new System.Drawing.Point(384, 475);
            this.nextPageButton.Name = "nextPageButton";
            this.nextPageButton.Size = new System.Drawing.Size(48, 23);
            this.nextPageButton.TabIndex = 2;
            this.nextPageButton.Text = ">";
            this.nextPageButton.UseVisualStyleBackColor = false;
            this.nextPageButton.Click += new System.EventHandler(this.nextPageButton_Click);
            // 
            // previousPageButton
            // 
            this.previousPageButton.BackColor = System.Drawing.Color.White;
            this.previousPageButton.Location = new System.Drawing.Point(230, 475);
            this.previousPageButton.Name = "previousPageButton";
            this.previousPageButton.Size = new System.Drawing.Size(48, 23);
            this.previousPageButton.TabIndex = 3;
            this.previousPageButton.Text = "<";
            this.previousPageButton.UseVisualStyleBackColor = false;
            this.previousPageButton.Click += new System.EventHandler(this.previousPageButton_Click);
            // 
            // pageNumberLabel
            // 
            this.pageNumberLabel.AutoSize = true;
            this.pageNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.pageNumberLabel.ForeColor = System.Drawing.Color.White;
            this.pageNumberLabel.Location = new System.Drawing.Point(299, 477);
            this.pageNumberLabel.Name = "pageNumberLabel";
            this.pageNumberLabel.Size = new System.Drawing.Size(66, 17);
            this.pageNumberLabel.TabIndex = 4;
            this.pageNumberLabel.Text = "Strona: 1";
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(274, 58);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(100, 20);
            this.searchTextBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(194, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Wyszukaj Film";
            // 
            // searchButton
            // 
            this.searchButton.BackColor = System.Drawing.Color.White;
            this.searchButton.Location = new System.Drawing.Point(380, 52);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(52, 30);
            this.searchButton.TabIndex = 7;
            this.searchButton.Text = "Szukaj";
            this.searchButton.UseVisualStyleBackColor = false;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 500);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.pageNumberLabel);
            this.Controls.Add(this.previousPageButton);
            this.Controls.Add(this.nextPageButton);
            this.Controls.Add(this.title2Label);
            this.Controls.Add(this.title1Label);
            this.Controls.Add(this.flowLayoutPanelMovies);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMovies;
        private System.Windows.Forms.Label title1Label;
        private System.Windows.Forms.Label title2Label;
        private System.Windows.Forms.Button nextPageButton;
        private System.Windows.Forms.Button previousPageButton;
        private System.Windows.Forms.Label pageNumberLabel;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button searchButton;
    }
}

