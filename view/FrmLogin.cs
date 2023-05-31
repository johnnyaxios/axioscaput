using AxiosCaput.dao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace AxiosCaput.view
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtNovo_Click(object sender, EventArgs e)
        {
            string login = TxtLogin.Text;
            string senha = TxtSenha.Text;

            UsuarioDAO dao = new UsuarioDAO();
            if (dao.efetuarLogin(login, senha))
            {
                this.Hide();
            }
        }
    }
}
