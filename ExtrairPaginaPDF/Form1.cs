using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using iText.Kernel.Pdf.Canvas.Parser;

namespace ExtrairPaginaPDF
{
    public partial class Form1 : Form
    {
        public OpenFileDialog openFileDialog = new OpenFileDialog();

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
                MessageBox.Show("Erro: informe o diretório para salvar os PDF`s");
            else
            {
                if (openFileDialog.FileName.Trim() == "")
                    MessageBox.Show("Erro: carregue um PDF!");
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

        private void ExtrairPaginaPDF(string path, string dirPDF)
        {
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

                                if (pagina == 315)
                                    break;

                                string novoConteudo = conteudo.Remove(0, 528);

                                string novoConteudoRemovido = novoConteudo.Replace("\nNumero Cartão Nome C.P.F.\nGrau de\nParentesco\nNascimento Valor\n", "");

                                string[] novoConteudoRemovidoSplit = novoConteudoRemovido.Split("\n");

                                string posicao = novoConteudoRemovidoSplit[0]
                                    .Replace("Titular", "")
                                    .Replace("/", "")
                                    .Replace("-", "")
                                    .Replace("R$", "")
                                    .Replace(",", "")
                                    .Replace(".", "");

                                string stringInvertida = util.InverterString(posicao);

                                if (pagina == 315)
                                    break;

                                string stringInvertidaRemove = stringInvertida.Remove(0, 17);

                                string stringInvertidaRemove2 = stringInvertidaRemove.Remove(12);

                                string stringOriginal = util.DesinverterString(stringInvertidaRemove2);

                                cpf = stringOriginal;

                                string ano = util.RetornaAnoAtual();

                                using (var pdfNovo = new PdfWriter(dirPDF + "\\pag-" + pagina + "-" + ano + "-" + cpf + ".pdf"))
                                {
                                    using (var docNovo = new PdfDocument(pdfNovo))
                                    {
                                        doc.CopyPagesTo(pagina, pagina, docNovo);
                                    }
                                }
                            }
                        }
                        pagina -= 1;
                        MessageBox.Show(pagina + " páginas extraídas com sucesso!");
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


    }
}