using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoSICOVE.Formularios;
using ProyectoSICOVE.Model;

namespace ProyectoSICOVE
{
    public partial class frmLoguin : Form
    {
        public frmLoguin()
        {
            InitializeComponent();
        }

        private void frmLogueo_Load(object sender, EventArgs e)
        {

        }
        public static frmLoguin loguin = new frmLoguin();
        private void txtClave_TextChanged(object sender, EventArgs e)
        {
            txtClave.PasswordChar = '*';
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            using (SICOVE1Entities2 db = new SICOVE1Entities2())
            {
                var lista = from usuario in db.tb_Usuarios
                            where usuario.Usuario == txtUsuario.Text
                            && usuario.Clave == txtClave.Text
                            select usuario;

                if (lista.Count() > 0)
                {
                    frmMenu menu = new frmMenu();
                    menu.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show(" ¡El Usuario y/o clave no son corecctos! " + "  ¡Intente de nuevo! ");
                    txtUsuario.Clear();
                    txtClave.Clear();
                    txtUsuario.Focus();
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal) 
            {
                WindowState = FormWindowState.Minimized;
            }
            else if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
            }

        }
    }
}
