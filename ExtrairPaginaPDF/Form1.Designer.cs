namespace ExtrairPaginaPDF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnCarregarPDF = new System.Windows.Forms.Button();
            this.labelNomeArquivo = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // btnCarregarPDF
            // 
            this.btnCarregarPDF.Location = new System.Drawing.Point(169, 12);
            this.btnCarregarPDF.Name = "btnCarregarPDF";
            this.btnCarregarPDF.Size = new System.Drawing.Size(94, 36);
            this.btnCarregarPDF.TabIndex = 0;
            this.btnCarregarPDF.Text = "Carregar PDF";
            this.btnCarregarPDF.UseVisualStyleBackColor = true;
            this.btnCarregarPDF.Click += new System.EventHandler(this.btnCarregarPDF_Click);
            // 
            // labelNomeArquivo
            // 
            this.labelNomeArquivo.AutoSize = true;
            this.labelNomeArquivo.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelNomeArquivo.Location = new System.Drawing.Point(224, 204);
            this.labelNomeArquivo.Name = "labelNomeArquivo";
            this.labelNomeArquivo.Size = new System.Drawing.Size(0, 15);
            this.labelNomeArquivo.TabIndex = 1;
            this.labelNomeArquivo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 67);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(408, 23);
            this.progressBar1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 103);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.labelNomeArquivo);
            this.Controls.Add(this.btnCarregarPDF);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Extrator de páginas PDF - Ameppre";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnCarregarPDF;
        private Label labelNomeArquivo;
        private ProgressBar progressBar1;
    }
}