using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoSICOVE.Model;
using ProyectoSICOVE.Reportes;

namespace ProyectoSICOVE.ConsultarRPT
{
    public partial class frmrptEmpleados : Form
    {
        public frmrptEmpleados()
        {
            InitializeComponent();
        }

        private void frmrptEmpleados_Load(object sender, EventArgs e)
        {

            using (SICOVE1Entities2 db = new SICOVE1Entities2())
            {
                rptEmpleados rptEmpleado = new rptEmpleados();
                rptEmpleado.SetDataSource(db.tb_Clientes.ToList());
                crEmpleados.ReportSource = rptEmpleado;
            }
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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
