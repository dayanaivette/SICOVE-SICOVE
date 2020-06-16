using ProyectoSICOVE.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoSICOVE.Formularios
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }
        private void empleadoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmEmpleado empleado = new frmEmpleado();
            empleado.Show();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClientes cliente = new frmClientes();
            cliente.MdiParent = this;
            cliente.Show();
        }

        private void proveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProveedor proveedor = new frmProveedor();
            proveedor.Show();
        }

        private void formaDePagoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFormaPago pago = new frmFormaPago();
            pago.Show();
        }

        private void cerrasSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void registrarRolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRoles roles = new frmRoles();
            roles.MdiParent = this;
            roles.Show();
        }

        private void registrarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuarios usuarios = new frmUsuarios();
            usuarios.MdiParent = this;
            usuarios.Show();
        }

        private void cambiarDeUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLoguin loguin = new frmLoguin();
            loguin.Show();
            this.Close();
        }

        //clase publica que permite el acceso global de las propiedades de compras
        public static frmCompras compras = new frmCompras();
        private void facturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmCompras compras = new frmCompras();
            compras.MdiParent = this;
            compras.Show();
        }

        private void facturasDeVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVentas ventas = new frmVentas();
            ventas.MdiParent = this;
            ventas.Show();
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategorias categorias = new frmCategorias();
            categorias.Show();
            categorias.MdiParent = this;
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductos productos = new frmProductos();
            productos.MdiParent = this;
            productos.Show();
        }

        private void cdsvdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMuestraExistencias existencias = new frmMuestraExistencias();
            existencias.MdiParent = this;
            existencias.Show();
        }

        private void btnCerrar1_Click(object sender, EventArgs e)
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
