
namespace CalculatorAppForm3
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
            this.txtResult = new System.Windows.Forms.TextBox();
            this.calculationShow = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(13, 38);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(331, 20);
            this.txtResult.TabIndex = 19;
            // 
            // calculationShow
            // 
            this.calculationShow.AutoSize = true;
            this.calculationShow.ForeColor = System.Drawing.Color.Coral;
            this.calculationShow.Location = new System.Drawing.Point(12, 22);
            this.calculationShow.Name = "calculationShow";
            this.calculationShow.Size = new System.Drawing.Size(35, 13);
            this.calculationShow.TabIndex = 22;
            this.calculationShow.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Cyan;
            this.label2.Location = new System.Drawing.Point(108, 314);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Kenan EGE - Calculator App";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(356, 336);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.calculationShow);
            this.Controls.Add(this.txtResult);
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Click += new System.EventHandler(this.numsClicked);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Label calculationShow;
        private System.Windows.Forms.Label label2;
    }
}

