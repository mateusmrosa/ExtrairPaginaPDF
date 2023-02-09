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
            this.btnCarregarPDF = new System.Windows.Forms.Button();
            this.labelNomeArquivo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCarregarPDF
            // 
            this.btnCarregarPDF.Location = new System.Drawing.Point(273, 140);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 312);
            this.Controls.Add(this.labelNomeArquivo);
            this.Controls.Add(this.btnCarregarPDF);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnCarregarPDF;
        private Label labelNomeArquivo;
    }
}