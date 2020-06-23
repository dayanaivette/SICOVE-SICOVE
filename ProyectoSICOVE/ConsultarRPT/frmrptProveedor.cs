using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoSICOVE.Reportes;
using ProyectoSICOVE.Model;

namespace ProyectoSICOVE.ConsultarRPT
{
    public partial class frmrptProveedor : Form
    {
        public frmrptProveedor()
        {
            InitializeComponent();
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

        private void frmrptProveedor_Load(object sender, EventArgs e)
        {
            using (SICOVE1Entities2 db = new SICOVE1Entities2())
            {
                rptProveedor rptProveedor = new rptProveedor();
                rptProveedor.SetDataSource(db.tb_Clientes.ToList());
                crProveedor.ReportSource = rptProveedor;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
