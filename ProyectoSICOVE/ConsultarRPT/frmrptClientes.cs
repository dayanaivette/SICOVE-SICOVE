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
    public partial class frmrptClientes : Form
    {
        public frmrptClientes()
        {
            InitializeComponent();
        }

        private void frmrptClientes_Load(object sender, EventArgs e)
        {
            using (SICOVE1Entities2 db = new SICOVE1Entities2())
            {
                rptClientes rptClientes = new rptClientes();
                rptClientes.SetDataSource(db.tb_Clientes.ToList());
                crClientes.ReportSource = rptClientes;
            }
        }
    }
}
