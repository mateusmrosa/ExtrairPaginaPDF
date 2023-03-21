﻿using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using iText.Kernel.Pdf.Canvas.Parser;
using System.Net;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace ExtrairPaginaPDF
{
    public partial class Form1 : Form
    {
        private const string Uri = "https://api.ameppre.com.br/insertInformativoUnimed";
        private const string TokenBody = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c";
        private OpenFileDialog openFileDialog = new OpenFileDialog();
        private Util util = new();
        private DataBase dataBase = new();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCarregarPDF_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Carregar PDF | *.pdf";

            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog.FileName;

                string[] pathSplit = path.Split("-");

                label2.Text = "Nome do arquivo PDF: " + pathSplit[2];
            }
            else return;
        }

        private void btnProcessar_Click(object sender, EventArgs e)
        {
            string dirPdf = textBox1.Text;
            if (dirPdf.Trim() == "")
                MessageBox.Show("Erro: informe o diret�rio para salvar os PDF`s");
            else
            {
                if (openFileDialog.FileName.Trim() == "")
                    MessageBox.Show("Erro: Carregue um PDF!");
                else
                    ExtrairPaginaPDF(openFileDialog.FileName, dirPdf);
            }
        }

        private void ProgressBar(int pagina)
        {
            var max = pagina;
            progressBar1.Maximum = max;
            progressBar1.Value = pagina;
        }

        private void ProgressBar2(int i)
        {
            var max = i;
            progressBar2.Maximum = max;
            progressBar2.Value = i;
        }

        private void ExtrairPaginaPDF(string path, string dirPDF)
        {
            btnProcessar.Enabled = false;

            var arquivos = util.GetArquivoPdfRecursive(dirPDF);

            if (arquivos.Length > 0)
            {
                MessageBox.Show("O PDF já foi extraído, agora você pode sincronizar com o servidor!");
                btnProcessar.Enabled = true;
                return;
            }

            int pagina = 0;
            string cpf;

            try
            {
                using (var pdf = new PdfReader(path))
                {
                    using (var doc = new PdfDocument(pdf))
                    {
                        if (doc.GetNumberOfPages() == 0)
                            MessageBox.Show("O arquivo " + path + " não tem nenhuma página!");
                        else
                        {
                            Util util = new();

                            for (pagina = 1; pagina <= doc.GetNumberOfPages(); pagina++)
                            {
                                ProgressBar(pagina);

                                ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();

                                string conteudo = PdfTextExtractor.GetTextFromPage(doc.GetPage(pagina), strategy);

                                cpf = util.ProcuraCpf(conteudo);

                                string ano = util.RetornaAnoAtual();

                                using (var pdfNovo = new PdfWriter(dirPDF + "\\IR-" + pagina.ToString("000") + "-" + ano + "-" + cpf + ".pdf"))
                                {
                                    //  dataBase.GravarCpf(cpf);

                                    using (var docNovo = new PdfDocument(pdfNovo))
                                    {
                                        doc.CopyPagesTo(pagina, pagina, docNovo);
                                    }
                                }

                            }
                        }
                        pagina -= 1;
                        MessageBox.Show("Sucesso: " + pagina + " p�ginas extra�das com sucesso!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void btnSincronizar_Click(object sender, EventArgs e)
        {
            btnSincronizar.Enabled = false;

            string dirPdf = textBox1.Text;

            progressBar1.Value = 0;

            if (dirPdf == "")
            {
                MessageBox.Show("Erro: informe o caminho do diretorio!");
                return;
            }

            var arquivos = util.GetArquivoPdfRecursive(dirPdf);

            if (arquivos.Length == 0)
            {
                MessageBox.Show("Error: primeiro voc� precisa extrair o PDF");
                return;
            }

            int i = 1;

            foreach (var item in arquivos)
            {
                ProgressBar2(i);

                string base64irUnimed = util.ConverterPdfParaBase64(item);

                string cpf = dataBase.ObterCpf(i);

                var response = await PostApi(base64irUnimed, i, cpf); //enviar por parametro o cpf nesse chamda da api

                i++;

                if (i > 314)
                    i--;

                label3.Text = "Aguarde, sincronizando arquivos: " + i.ToString() + "/" + arquivos.Length;
            }

            MessageBox.Show("Sucesso: Os IR`s dos associados foram sincronizados com o servidor!");

        }

        public async Task<string> PostApi(string base64IrUnimed, int id, string cpf)
        {
            using var client = new HttpClient();

            var data = new Dictionary<string, string>
            {
                { "tokenBody"      , TokenBody            },
                { "id"             , Convert.ToString(id) },
                { "cpf"            , cpf                  },
                { "base64IrUnimed" , base64IrUnimed       }
            };

            var res = await client.PostAsync(Uri, new FormUrlEncodedContent(data));

            var content = await res.Content.ReadAsStringAsync();

            return content;
        }
    }
}