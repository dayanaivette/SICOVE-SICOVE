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
    public partial class frmrptProductos : Form
    {
        public frmrptProductos()
        {
            InitializeComponent();
        }

        private void frmrptProductos_Load(object sender, EventArgs e)
        {

            using (SICOVE1Entities2 db = new SICOVE1Entities2())
            {
            //    rptProductos rptProductos = new rptProductos();
            //    rptProductos.SetDataSource(db.tb_Productos.ToList());
            //    crProductos.ReportSource = rptProductos;
            }
        }
    }
}
