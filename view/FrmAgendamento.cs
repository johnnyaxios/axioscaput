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

namespace AxiosCaput.view
{
    public partial class FrmAgendamento : Form
    {
        public FrmAgendamento()
        {
            InitializeComponent();
        }

        private void BtSalvar_Click(object sender, EventArgs e)
        {
            if (TxtCodigo.Text == "")
            {

                Agendamento obj = new Agendamento();
                obj.id_cliente = int.Parse(cbCliente.SelectedValue.ToString());
                obj.data_agendamento = dtData.Value.ToString("dd/MM/yyyy");
                obj.hora_agendamento = cbHora.Text;
                obj.status = cbStatus.Text; ;
                obj.observacao = TxtObs.Text;
                obj.data_cad = DateTime.Now.ToString("dd/MM/yyyy hh:mm");
                AgendamentoDAO dao = new AgendamentoDAO();

                dao.CadastarAgendamento(obj);
            }
            else
            {
                Agendamento obj = new Agendamento();
                obj.status = cbStatus.Text;
                obj.id = int.Parse(TxtCodigo.Text);

                AgendamentoDAO dao = new AgendamentoDAO();
                dao.alterarAgendamento(obj);

            }
            //
            novo();
            AgendamentoDAO adao = new AgendamentoDAO();
            tabelaAgendamento.DataSource = adao.buscarAgendamentoData(dtData.Value.ToString("dd/MM/yyyy"));

        }

        private void FrmAgendamento_Load(object sender, EventArgs e)
        {
            ClienteDAO c_dao = new ClienteDAO();
            cbCliente.DataSource = c_dao.listarClientes();
            cbCliente.DisplayMember = "nome";
            cbCliente.ValueMember = "id";
            AgendamentoDAO adao = new AgendamentoDAO();
            tabelaAgendamento.DataSource = adao.buscarAgendamentoData(dtData.Value.ToString("dd/MM/yyyy"));
        }

        private void dtData_ValueChanged(object sender, EventArgs e)
        {
            novo();
            AgendamentoDAO adao = new AgendamentoDAO();
            tabelaAgendamento.DataSource = adao.buscarAgendamentoData(dtData.Value.ToString("dd/MM/yyyy"));
        }
        public void novo()
        {
            TxtCodigo.Clear();
            cbCliente.Text = "";
            cbHora.Text = "";
            cbStatus.Text = "";
            TxtObs.Clear();
        }

        private void tabelaAgendamento_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtCodigo.Text = tabelaAgendamento.CurrentRow.Cells[0].Value.ToString();
            cbCliente.Text = tabelaAgendamento.CurrentRow.Cells[2].Value.ToString();
            cbHora.Text = tabelaAgendamento.CurrentRow.Cells[3].Value.ToString();
            cbStatus.Text = tabelaAgendamento.CurrentRow.Cells[5].Value.ToString();
            TxtObs.Text = tabelaAgendamento.CurrentRow.Cells[4].Value.ToString();
        }

    }
}

