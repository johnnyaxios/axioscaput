using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AxiosCaput.model;
using AxiosCaput.conexao;

namespace AxiosCaput.dao
{
    public class AgendamentoDAO
    {
            private MySqlConnection conexao;
            public AgendamentoDAO()
            {
                this.conexao = new ConnectionFactory().getconnection();
            }

            //metodo cadastrarcliente
            #region CadastarAgendamento
            public void CadastarAgendamento(Agendamento obj)
            {
                try
                {
                    string sql = @"insert into tb_agendamento(id_cliente, data_agendamento, hora_agendamento
                                               , observacao, status, id_funcionario, data_cad) " +
                                   "values(@id_cliente,@data_agendamento,@hora_agendamento," +
                                   "@observacao,@status,@id_funcionario,@data_cad)";
                    MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                    executacmd.Parameters.AddWithValue("@id_cliente", obj.id_cliente);
                    executacmd.Parameters.AddWithValue("@data_agendamento", obj.data_agendamento);
                    executacmd.Parameters.AddWithValue("@hora_agendamento", obj.hora_agendamento);
                    executacmd.Parameters.AddWithValue("@observacao", obj.observacao);
                    executacmd.Parameters.AddWithValue("@status", obj.status);
                    executacmd.Parameters.AddWithValue("@data_cad", obj.data_cad);
                    conexao.Open();
                    executacmd.ExecuteNonQuery();

                    MessageBox.Show("Agendamento Cadastrado com sucesso!");
                    conexao.Close();

                }
                catch (Exception erro)
                {

                    MessageBox.Show("Aconteceu o erro: " + erro);
                    conexao.Close();
                }
            }
            #endregion
            #region buscarclientepornome
            public DataTable buscarAgendamentoData(string dataAgendamento)
            {
                try
                {
                    DataTable tabelaAgendamento = new DataTable();
                    string sql = "SELECT ta.id, ta.id_cliente, tc.nome, ta.hora_agendamento, ta.observacao, ta.status  \r\nFROM tb_agendamento ta \r\njoin tb_cliente tc on tc.id = ta.id_cliente\r\nwhere ta.data_agendamento =@dataAgendamento\r\n and ta.status not in ('Cancelado')order by 4";

                    MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                    executacmd.Parameters.AddWithValue("@dataAgendamento", dataAgendamento);
                    conexao.Open();
                    executacmd.ExecuteNonQuery();

                    MySqlDataAdapter da = new MySqlDataAdapter(executacmd);
                    da.Fill(tabelaAgendamento);
                    conexao.Close();
                    return tabelaAgendamento;
                }
                catch (Exception erro)
                {

                    MessageBox.Show("Aconteceu o erro: " + erro);
                    return null;
                }
            }
            #endregion
            #region AlterarAgendamento
            public void alterarAgendamento(Agendamento obj)
            {
                try
                {
                    string sql = @"update tb_agendamento set status=@status
                                    where id=@id";
                    MySqlCommand executacmd = new MySqlCommand(sql, conexao);
                    executacmd.Parameters.AddWithValue("@status", obj.status);
                    executacmd.Parameters.AddWithValue("@id", obj.id);

                    conexao.Open();
                    executacmd.ExecuteNonQuery();

                    MessageBox.Show("Serviço Cadastrado com sucesso!");
                    conexao.Close();

                }
                catch (Exception erro)
                {

                    MessageBox.Show("Aconteceu o erro: " + erro);
                    conexao.Close();
                }
            }
            #endregion

        }
    }

