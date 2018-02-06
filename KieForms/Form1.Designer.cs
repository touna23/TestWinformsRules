namespace KieForms
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboRep = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelQuestions = new System.Windows.Forms.Label();
            this.labelQuestion = new System.Windows.Forms.Label();
            this.Valider = new System.Windows.Forms.Button();
            this.labelReponse = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboRep
            // 
            this.comboRep.FormattingEnabled = true;
            this.comboRep.Items.AddRange(new object[] {
            "Tête",
            "Jambe"});
            this.comboRep.Location = new System.Drawing.Point(128, 64);
            this.comboRep.Name = "comboRep";
            this.comboRep.Size = new System.Drawing.Size(121, 21);
            this.comboRep.TabIndex = 0;
            this.comboRep.Text = " ";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.labelQuestions);
            this.groupBox1.Controls.Add(this.labelQuestion);
            this.groupBox1.Controls.Add(this.Valider);
            this.groupBox1.Controls.Add(this.comboRep);
            this.groupBox1.Controls.Add(this.labelReponse);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(392, 192);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " ";
            // 
            // labelQuestions
            // 
            this.labelQuestions.AutoSize = true;
            this.labelQuestions.Location = new System.Drawing.Point(126, 28);
            this.labelQuestions.Name = "labelQuestions";
            this.labelQuestions.Size = new System.Drawing.Size(142, 13);
            this.labelQuestions.TabIndex = 9;
            this.labelQuestions.Text = "A quel organe souffez vous?";
            // 
            // labelQuestion
            // 
            this.labelQuestion.AutoSize = true;
            this.labelQuestion.Location = new System.Drawing.Point(15, 28);
            this.labelQuestion.Name = "labelQuestion";
            this.labelQuestion.Size = new System.Drawing.Size(55, 13);
            this.labelQuestion.TabIndex = 8;
            this.labelQuestion.Text = "Question :";
            // 
            // Valider
            // 
            this.Valider.Location = new System.Drawing.Point(183, 122);
            this.Valider.Name = "Valider";
            this.Valider.Size = new System.Drawing.Size(75, 23);
            this.Valider.TabIndex = 7;
            this.Valider.Text = "Valider";
            this.Valider.UseVisualStyleBackColor = true;
            this.Valider.Click += new System.EventHandler(this.Valider_Click);
            // 
            // labelReponse
            // 
            this.labelReponse.AutoSize = true;
            this.labelReponse.Location = new System.Drawing.Point(15, 66);
            this.labelReponse.Name = "labelReponse";
            this.labelReponse.Size = new System.Drawing.Size(56, 13);
            this.labelReponse.TabIndex = 0;
            this.labelReponse.Text = "Réponse :";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 216);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboRep;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelQuestions;
        private System.Windows.Forms.Label labelQuestion;
        private System.Windows.Forms.Button Valider;
        private System.Windows.Forms.Label labelReponse;
    }
}

