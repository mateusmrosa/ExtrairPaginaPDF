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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnProcessar = new System.Windows.Forms.Button();
            this.btnSincronizar = new System.Windows.Forms.Button();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCarregarPDF
            // 
            this.btnCarregarPDF.Location = new System.Drawing.Point(5, 89);
            this.btnCarregarPDF.Name = "btnCarregarPDF";
            this.btnCarregarPDF.Size = new System.Drawing.Size(381, 23);
            this.btnCarregarPDF.TabIndex = 0;
            this.btnCarregarPDF.Text = "CARREGAR PDF";
            this.btnCarregarPDF.UseVisualStyleBackColor = true;
            this.btnCarregarPDF.Click += new System.EventHandler(this.btnCarregarPDF_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(401, 89);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(190, 23);
            this.progressBar1.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(5, 31);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(381, 23);
            this.textBox1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Insira o diretório no campo abaixo:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 15);
            this.label2.TabIndex = 5;
            // 
            // btnProcessar
            // 
            this.btnProcessar.Location = new System.Drawing.Point(401, 31);
            this.btnProcessar.Name = "btnProcessar";
            this.btnProcessar.Size = new System.Drawing.Size(190, 52);
            this.btnProcessar.TabIndex = 6;
            this.btnProcessar.Text = "PROCESSAR EXTRAÇÃO LOCAL";
            this.btnProcessar.UseVisualStyleBackColor = true;
            this.btnProcessar.Click += new System.EventHandler(this.btnProcessar_Click);
            // 
            // btnSincronizar
            // 
            this.btnSincronizar.Location = new System.Drawing.Point(5, 129);
            this.btnSincronizar.Name = "btnSincronizar";
            this.btnSincronizar.Size = new System.Drawing.Size(586, 45);
            this.btnSincronizar.TabIndex = 7;
            this.btnSincronizar.Text = "SINCRONIZAR ARQUIVOS COM SERVIDOR ONLINE";
            this.btnSincronizar.UseVisualStyleBackColor = true;
            this.btnSincronizar.Click += new System.EventHandler(this.btnSincronizar_Click);
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(5, 194);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(586, 15);
            this.progressBar2.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.Green;
            this.label3.Location = new System.Drawing.Point(4, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 15);
            this.label3.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.Green;
            this.label5.Location = new System.Drawing.Point(402, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 15);
            this.label5.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 215);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.btnSincronizar);
            this.Controls.Add(this.btnProcessar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnCarregarPDF);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Extrator de páginas PDF - Ameppre";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnCarregarPDF;
        private ProgressBar progressBar1;
        private TextBox textBox1;
        private Label label1;
        private Label label2;
        private Button btnProcessar;
        private Button btnSincronizar;
        private ProgressBar progressBar2;
        private Label label3;
        private Label label5;
    }
}