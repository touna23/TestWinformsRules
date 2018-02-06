namespace KieForms
{
    partial class ExptableLayout
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
            this.tableLayoutResponse = new System.Windows.Forms.TableLayoutPanel();
            this.btn_answer1 = new System.Windows.Forms.Button();
            this.btn_answer2 = new System.Windows.Forms.Button();
            this.labelQuestions = new System.Windows.Forms.Label();
            this.tableLayoutQuestion = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutResponse.SuspendLayout();
            this.tableLayoutQuestion.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutResponse
            // 
            this.tableLayoutResponse.AutoScroll = true;
            this.tableLayoutResponse.ColumnCount = 2;
            this.tableLayoutResponse.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutResponse.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutResponse.Controls.Add(this.btn_answer1, 0, 0);
            this.tableLayoutResponse.Controls.Add(this.btn_answer2, 1, 0);
            this.tableLayoutResponse.Location = new System.Drawing.Point(12, 37);
            this.tableLayoutResponse.Name = "tableLayoutResponse";
            this.tableLayoutResponse.RowCount = 1;
            this.tableLayoutResponse.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutResponse.Size = new System.Drawing.Size(502, 81);
            this.tableLayoutResponse.TabIndex = 0;
            // 
            // btn_answer1
            // 
            this.btn_answer1.AutoSize = true;
            this.btn_answer1.Location = new System.Drawing.Point(3, 3);
            this.btn_answer1.Name = "btn_answer1";
            this.btn_answer1.Size = new System.Drawing.Size(70, 23);
            this.btn_answer1.TabIndex = 11;
            this.btn_answer1.Tag = "answer";
            this.btn_answer1.Text = "Tête";
            this.btn_answer1.UseVisualStyleBackColor = true;
            this.btn_answer1.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_answer2
            // 
            this.btn_answer2.AutoSize = true;
            this.btn_answer2.Location = new System.Drawing.Point(79, 3);
            this.btn_answer2.Name = "btn_answer2";
            this.btn_answer2.Size = new System.Drawing.Size(74, 23);
            this.btn_answer2.TabIndex = 12;
            this.btn_answer2.Tag = "answer";
            this.btn_answer2.Text = "Jambe";
            this.btn_answer2.UseVisualStyleBackColor = true;
            this.btn_answer2.Click += new System.EventHandler(this.button2_Click);
            // 
            // labelQuestions
            // 
            this.labelQuestions.AutoSize = true;
            this.labelQuestions.Location = new System.Drawing.Point(3, 0);
            this.labelQuestions.Name = "labelQuestions";
            this.labelQuestions.Size = new System.Drawing.Size(142, 13);
            this.labelQuestions.TabIndex = 10;
            this.labelQuestions.Text = "A quel organe souffez vous?";
            // 
            // tableLayoutQuestion
            // 
            this.tableLayoutQuestion.ColumnCount = 1;
            this.tableLayoutQuestion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutQuestion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutQuestion.Controls.Add(this.labelQuestions, 0, 0);
            this.tableLayoutQuestion.Location = new System.Drawing.Point(12, 6);
            this.tableLayoutQuestion.Name = "tableLayoutQuestion";
            this.tableLayoutQuestion.RowCount = 1;
            this.tableLayoutQuestion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutQuestion.Size = new System.Drawing.Size(502, 25);
            this.tableLayoutQuestion.TabIndex = 1;
            // 
            // ExptableLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 256);
            this.Controls.Add(this.tableLayoutQuestion);
            this.Controls.Add(this.tableLayoutResponse);
            this.Name = "ExptableLayout";
            this.Text = "ExptableLayout";
            this.tableLayoutResponse.ResumeLayout(false);
            this.tableLayoutResponse.PerformLayout();
            this.tableLayoutQuestion.ResumeLayout(false);
            this.tableLayoutQuestion.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutResponse;
        private System.Windows.Forms.Label labelQuestions;
        private System.Windows.Forms.Button btn_answer1;
        private System.Windows.Forms.Button btn_answer2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutQuestion;
    }
}