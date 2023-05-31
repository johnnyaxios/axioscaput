using AxiosCaput.conexao;
using AxiosCaput.Resources;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AxiosCaput.dao
{
    public class UsuarioDAO
    {
        private MySqlConnection conexao;
        public UsuarioDAO()
        {
            this.conexao = new ConnectionFactory().getconnection();
        }

        public bool efetuarLogin(string login, string senha)
        {
            try
            {
                string sql = @"select * from tb_usuario t where t.login = @login and t.senha = @senha";

                MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                executacmd.Parameters.AddWithValue("@login", login);
                executacmd.Parameters.AddWithValue("@senha", senha);

                conexao.Open();
                MySqlDataReader reader = executacmd.ExecuteReader();
                if (reader.Read())
                {

                   
                    MessageBox.Show("Login realizaedo com sucesso!");
                   FrmMenu menu = new FrmMenu();
                    menu.Show();

                    return true;
                }
                else
                {
                    MessageBox.Show("Login ou senha invalida!");
                    return false;
                }




            }
            catch (Exception erro)
            {

                MessageBox.Show("Aconteceu o erro: " + erro);
                return false;
            }
        }
    }
}
