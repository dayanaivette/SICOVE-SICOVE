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

namespace ProyectoSICOVE.Formularios
{
    public partial class frmMuestraExistencias : Form
    {
        public frmMuestraExistencias()
        {
            InitializeComponent();
        }

        private void Existencias_Load(object sender, EventArgs e)
        {
            filtro();
           // dgvExistencias.Rows.Clear();
        }

        private void btnCerrar1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void filtro()
        {
            using (SICOVE1Entities2 db = new SICOVE1Entities2())
            {
                string nombre = txtBuscarProducto.Text;

                var buscarprod = from tb_Inventarios in db.tb_Inventarios
                                 from tb_Productos in db.tb_Productos
                                 from tb_Categorias in db.tb_Categorias
                                 where tb_Inventarios.IdProducto == tb_Productos.IdProducto
                                 where tb_Productos.IdCategoria == tb_Categorias.IdCategoria
                                //se filtra la busqueda por el nombre de producto
                                 where tb_Productos.Nombre.Contains(nombre)

                                 select new
                                 {
                                     Codigo = tb_Inventarios.IdInventario,
                                     //idProducto = tb_Inventarios.IdProducto,
                                     //idCategoria = tb_Inventarios.IdCategoria,
                                     NombreProducto = tb_Productos.Nombre,
                                     Categorias = tb_Categorias.Nombre,
                                     Existencias = tb_Inventarios.Existencia
                                 };

                dgvExistencias.DataSource = buscarprod.ToList();
            }
        }

        private void txtBuscarProducto_TextChanged(object sender, EventArgs e)
        {
            filtro();
        }

        private void dgvExistencias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

