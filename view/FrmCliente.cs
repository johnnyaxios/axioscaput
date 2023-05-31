using AxiosCaput.dao;
using AxiosCaput.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AxiosCaput
{
    public partial class FrmCliente : Form
    {
        public FrmCliente()
        {
            InitializeComponent();
        }

        private void BtBuscarCep_Click(object sender, EventArgs e)
        {
            try
            {
                string cep = TxtCep.Text;
                DataSet dados = new DataSet();
                string xml = "http://viacep.com.br/ws/" + cep + "/xml/";

                dados.ReadXml(xml);

                TxtEndereco.Text = dados.Tables[0].Rows[0]["logradouro"].ToString().ToUpper();
                TxtBairro.Text = dados.Tables[0].Rows[0]["bairro"].ToString().ToUpper();
                TxtCidade.Text = dados.Tables[0].Rows[0]["localidade"].ToString().ToUpper();
                CbUf.Text = dados.Tables[0].Rows[0]["uf"].ToString().ToUpper();
            }
            catch (Exception)
            {

                MessageBox.Show("endereço não encontrado, por favor digite novamente um cep valido!");
            }
        }

        private void BtSalvar_Click(object sender, EventArgs e)
        {
            Cliente obj = new Cliente();
            
            obj.nome = TxtNome.Text;
            obj.rg = TxtRg.Text;
            obj.cpf = TxtCpf.Text; ;
            obj.data_nascimento = dtaniversario.Text;
            obj.email = TxtEmail.Text;
            obj.telefone = TxtTelefone.Text;
            obj.celular = TxtCelular.Text;
            obj.cep = TxtCep.Text;
            obj.endereco = TxtEndereco.Text;
            obj.numero = TxtNumero.Text;
            obj.complemento = TxtComplemento.Text;
            obj.bairro = TxtBairro.Text;
            obj.cidade = TxtCidade.Text;
            obj.estado = CbUf.Text;
            
            obj.observacao = TxtObs.Text;
            obj.status = CbStatus.Text;
            ClienteDAO dao = new ClienteDAO();
            dao.cadastrarCliente(obj);
            //
            //novo();
            ClienteDAO CL = new ClienteDAO();
            tabelaCliente.DataSource = CL.listarClientes();
        }

        private void BtNovo_Click(object sender, EventArgs e)
        {
            novo();
        }
        public void novo()
        {
            TxtId.Clear();
            TxtCelular.Clear();
            TxtCep.Clear();
            TxtNome.Clear();
            TxtNumero.Clear();
            TxtRg.Clear();
            TxtCpf.Clear();
            TxtEmail.Clear();
            TxtEndereco.Clear();
            TxtComplemento.Clear();
            TxtBairro.Clear();
            CbUf.Text = "";
            TxtCidade.Clear();
            TxtObs.Clear();
            CbStatus.Text = "";
            TxtPesquisa.Clear();


        }

        private void BtExcluir_Click(object sender, EventArgs e)
        {
            Cliente obj = new Cliente();
            if (TxtId.Text != "")
            {
                obj.Id = int.Parse(TxtId.Text);


            }

            ClienteDAO dao = new ClienteDAO();
            dao.deletar(obj);
            novo();
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            ClienteDAO dao = new ClienteDAO();
            tabelaCliente.DataSource = dao.listarClientes();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtVoltar_Click(object sender, EventArgs e)
        {
            this.Hide(); 
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void BtPesquisar_Click(object sender, EventArgs e)
        {

            ClienteDAO dao = new ClienteDAO();
            string nome = TxtPesquisa.Text;

            tabelaCliente.DataSource =  dao.buscarPorCriterio(nome);
            if (TxtPesquisa.Text == "")
            {
                tabelaCliente.DataSource = dao.listarClientes();
            }

        }

        private void tabelaCliente_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtId.Text = tabelaCliente.CurrentRow.Cells[0].Value.ToString();
            TxtNome.Text = tabelaCliente.CurrentRow.Cells[1].Value.ToString();
            TxtRg.Text = tabelaCliente.CurrentRow.Cells[2].Value.ToString();
            TxtCpf.Text = tabelaCliente.CurrentRow.Cells[3].Value.ToString();
            TxtEmail.Text = tabelaCliente.CurrentRow.Cells[4].Value.ToString();
            TxtTelefone.Text = tabelaCliente.CurrentRow.Cells[5].Value.ToString();
            TxtCelular.Text = tabelaCliente.CurrentRow.Cells[6].Value.ToString();
            TxtCep.Text = tabelaCliente.CurrentRow.Cells[7].Value.ToString();
            TxtEndereco.Text = tabelaCliente.CurrentRow.Cells[8].Value.ToString();
            TxtNumero.Text = tabelaCliente.CurrentRow.Cells[9].Value.ToString();
            TxtComplemento.Text = tabelaCliente.CurrentRow.Cells[10].Value.ToString();
            TxtBairro.Text = tabelaCliente.CurrentRow.Cells[11].Value.ToString();
           CbUf.Text = tabelaCliente.CurrentRow.Cells[12].Value.ToString();
            TxtCidade.Text = tabelaCliente.CurrentRow.Cells[13].Value.ToString();
            dtaniversario.Text = tabelaCliente.CurrentRow.Cells[14].Value.ToString();
            TxtObs.Text = tabelaCliente.CurrentRow.Cells[15].Value.ToString();
            CbStatus.Text = tabelaCliente.CurrentRow.Cells[16].Value.ToString();

            TbCliente.SelectedTab = TbCadCliente;
        }
    }
}
