using MySql.Data.MySqlClient;
using System.Data;

namespace ExtrairPaginaPDF
{
    class DataBase
    {
        private string caminho = "server=108.179.192.45;user=amepp840_usuamep;password=YOBhjb*&klf6;database=amepp840_db_ameppre;";
        private MySqlConnection conexao;

        public MySqlConnection Conexao()
        {
            return this.conexao;
        }

        public DataBase()
        {

            try
            {
                conexao = new MySqlConnection(caminho);
                conexao.Open();
                //MessageBox.Show("Conectado com sucesso...");
            }
            catch (Exception)
            {
                MessageBox.Show("Erro de conexão");
            }
            finally
            {
                conexao.Close();
            }
        }

        public void GravarCpf(string cpf)
        {
            try
            {
                this.conexao.Open();
                string query = "INSERT INTO tb_cpf_ir_unimed (cpf_ir_cpf) VALUES ('" + cpf + "')";

                MySqlCommand cmd = new MySqlCommand(query, this.conexao);
                cmd.Parameters.AddWithValue("@cpf_ir_cpf", cpf);
                cmd.ExecuteNonQuery();

                this.conexao.Close();
                //MessageBox.Show("Dados gravados com sucesso...");
            }
            catch (Exception)
            {
                MessageBox.Show("Erro de gravação");
            }
        }

        public string ObterCpf(int id)
        {
            string resultCpf = "";
            try
            {
                this.conexao.Open();
                string query = "SELECT cpf_ir_cpf FROM tb_cpf_ir_unimed WHERE cpf_ir_id = " + id;

                MySqlCommand cmd = new MySqlCommand(query, this.conexao);
                cmd.Parameters.AddWithValue("@cpf_ir_id", id);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    resultCpf = reader.GetString(0);
                }

                reader.Close();
                this.conexao.Close();

                //MessageBox.Show("Dados gravados com sucesso...");
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro de gravação: Erro -> " + erro);
            }

            return resultCpf;
        }






    }
}
