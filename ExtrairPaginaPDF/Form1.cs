using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using iText.Kernel.Pdf.Canvas.Parser;

namespace ExtrairPaginaPDF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void btnCarregarPDF_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Carregar PDF | *.pdf";

            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog.FileName;

                string[] pathSplit = path.Split("-");

                labelNomeArquivo.Text = "Nome do arquivo PDF: " + pathSplit[2];
            }
            else return;

            string dirPdf = @"C:\Users\Mateus-dev\source\repos\ExtrairPaginaPDF\ExtrairPaginaPDF\dir_PDF";

            ExtrairPaginaPDF(openFileDialog.FileName, dirPdf);
        }


        private void ExtrairPaginaPDF(string path, string dirPDF)
        {

            var pagina = 0;
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
                            for (pagina = 1; pagina <= doc.GetNumberOfPages(); pagina++)
                            {
                                var max = pagina;

                                progressBar1.Maximum = max;

                                progressBar1.Value = pagina;

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

                                char[] arrChar = posicao.ToCharArray();

                                Array.Reverse(arrChar);

                                string stringInvertida = new String(arrChar);

                                if (pagina == 315)
                                    break;

                                string stringInvertidaRemove = stringInvertida.Remove(0, 17);

                                string stringInvertidaRemove2 = stringInvertidaRemove.Remove(12);

                                char[] arrChar2 = stringInvertidaRemove2.ToCharArray();

                                Array.Reverse(arrChar2);

                                string stringOriginal = new String(arrChar2);

                                cpf = stringOriginal;

                                using (var pdfNovo = new PdfWriter(dirPDF + "\\pag-" + pagina + "-" + cpf + ".pdf"))
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
    }
}