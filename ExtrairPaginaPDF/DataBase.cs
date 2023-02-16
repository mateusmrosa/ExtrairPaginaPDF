using MySql.Data.MySqlClient;
using System.Data;

namespace ExtrairPaginaPDF
{
    class DataBase
    {
        private string caminho = "server=108.179.192.45;uid=amepp840_usuamep;pwd=YOBhjb*&klf6;database=amepp840_db_ameppre;";
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

        public void gravar(string cpf)
        {
            try
            {
                this.conexao.Open();
                string query = "INSERT INTO tb_cpf_ir_unimed (cpf_ir_cpf) VALUES (" + cpf + ")";

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

        public void gravarUsuario(string nome, string sexo)
        {
            try
            {
                this.conexao.Open();
                string query = "INSERT INTO usuarios (nome, sexo) VALUES ('" + nome + "', '" + sexo + "')";

                MySqlCommand cmd = new MySqlCommand(query, this.conexao);
                //cmd.Parameters.AddWithValue("@nome", nome);
                //cmd.Parameters.AddWithValue("@sexo", sexo);
                cmd.ExecuteNonQuery();

                this.conexao.Close();
                MessageBox.Show("Dados gravados com sucesso...");
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro de gravação: Erro -> " + erro);
            }
        }


        public void updateTable(DataGridView grid, string tabela)
        {

            string query = "SELECT * FROM " + tabela + ";";
            try
            {
                this.conexao.Open();
                DataTable dados = new DataTable();

                MySqlCommand cmd = new MySqlCommand(query, this.conexao);
                dados.Load(cmd.ExecuteReader());

                grid.DataSource = dados.DefaultView;

                this.conexao.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao acessar banco de dados");
            }
        }

        public void deleteRegistro(int codigo)
        {

            string query = "DELETE FROM famosos WHERE codigo =" + codigo;
            try
            {
                this.conexao.Open();

                MySqlCommand cmd = new MySqlCommand(query, this.conexao);
                cmd.ExecuteNonQuery();
                this.conexao.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao deletar registro...");
            }
        }

    }
}
