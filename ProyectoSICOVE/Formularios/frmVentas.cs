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
using ProyectoSICOVE.Formularios.frmBusquedas;

namespace ProyectoSICOVE.Formularios
{
    public partial class frmVentas : Form
    {
        public frmVentas()
        {
            InitializeComponent();
        }

        tb_Ventas ventas = new tb_Ventas();
        private void frmVentas_Load(object sender, EventArgs e)
        {
            CargarCombos();
            Limpiar();
            retornoId();
        }

        void retornoId()
        {
            using (SICOVE1Entities2 db = new SICOVE1Entities2())
            {

                var tb_venta = db.tb_Ventas;
                txtNunFac.Text = "1";
                foreach (var iterardatostbventa in tb_venta)
                {
                    int idVenta = iterardatostbventa.NumFac;
                    int suma = idVenta + 1;
                    txtNunFac.Text = suma.ToString();
                }
            }
        }
        void CargarCombos()
        {
            using (SICOVE1Entities2 db = new SICOVE1Entities2())
            {
                //cargando el combo de forma de pago.
                var FormaPago = db.tb_FormaPago.ToList();

                cmbFormaPago.DataSource = FormaPago;
                cmbFormaPago.DisplayMember = "Nombre";
                cmbFormaPago.ValueMember = "IdFormaPago";
                if (cmbFormaPago.Items.Count > 1)
                    cmbFormaPago.SelectedIndex = -1;
                cmbFormaPago.Text = "Seleccione";
                cmbFormaPago.Refresh();

                //cargando el combo con cliente.
                var Cliente = db.tb_Clientes.ToList();

                cmbCliente.DataSource = Cliente;
                cmbCliente.DisplayMember = "Nombre";
                cmbCliente.ValueMember = "IdCliente";
                if (cmbCliente.Items.Count > 1)
                    cmbCliente.SelectedIndex = -1;
                cmbCliente.Text = "Seleccione";
                cmbCliente.Refresh();
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
            this.Hide();
        }

        private void btnRegistrarCliente_Click(object sender, EventArgs e)
        {
            frmClientes clientes = new frmClientes();
            clientes.ShowDialog();
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            frmBuscarProductoVentas busquedas = new frmBuscarProductoVentas();
            busquedas.ShowDialog();
        }

        void Limpiar()
        {
            txtCodProducto.Clear();
            txtNombreProducto.Clear();
            txtCategoriaProd.Clear();
            txtPrecio.Clear();
            txtCantidad.Text = "1";
            txtSubTotal.Clear();
            txtIVA.Clear();
            txtTotal.Clear();
            txtIdCategoriaProd.Clear();
        }

        void calculoSubTotal()
        {
            try
            {
                double precioProducto;
                int cantidad;
                double subTotal;

                precioProducto = Convert.ToDouble(txtPrecio.Text);
                cantidad = Convert.ToInt32(txtCantidad.Text);
                //para obtener el sub total se multiplica el precio por la cantidad
                subTotal = precioProducto * cantidad;

                txtSubTotal.Text = subTotal.ToString();

                txtIVA.Select();
            }
            catch (Exception ex)
            {
                txtCantidad.Text = "";
            }
        }
        void calculoTotal()
        {
            try
            {
                Double subTotal;
                Double iva;
                Double total;

                subTotal = Convert.ToDouble(txtSubTotal.Text);
                iva = Convert.ToDouble(txtIVA.Text);

                total = subTotal + iva;
                txtTotal.Text = total.ToString();
            }
            catch (Exception ex)
            {
               // MessageBox.Show("Algo salio mal, comuniquese con soporte tecnico ");
            }
        }

        private void btnAgregarProd_Click(object sender, EventArgs e)
        {
            try
            {

                calculoSubTotal();
                calculoTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo salio mal ... " + ex.ToString());
            }
            dgvVentas.Rows.Add(txtCodProducto.Text, txtIdCategoriaProd.Text, txtNombreProducto.Text, txtCategoriaProd.Text,
                txtPrecio.Text, txtCantidad.Text, txtSubTotal.Text, txtIVA.Text, txtTotal.Text);

            //Calcula el valor total de la compra
            calcularTotalFinal();
            Limpiar();
            txtBuscarProducto.Select();
            txtCantidad.Text = "1";
            //srive para refrescar la grid
            dgvVentas.Refresh();
            //selecciona la filla de la grid que se va agregando 
            dgvVentas.ClearSelection();
            //se ubica en la ultima fila insertada en la grid y genera el scroll
            int obtenerUltimaFilas = dgvVentas.Rows.Count - 1;
            dgvVentas.FirstDisplayedScrollingRowIndex = obtenerUltimaFilas;
            dgvVentas.Rows[obtenerUltimaFilas].Selected = true;

            txtBuscarProducto.Focus();
        }

        //calculo del total final de toda la compra
        void calcularTotalFinal()
        {
            Double suma = 0;
            for (int i = 0; i < dgvVentas.RowCount; i++)
            {
                String datosOperar = dgvVentas.Rows[i].Cells[8].Value.ToString();
                Double datosConvertidos = Convert.ToDouble(datosOperar);

                suma += datosConvertidos;
                txtTotalFinal.Text = suma.ToString();

            }
        }
        void limpiarVenta()
        {
            txtNunFac.Clear();
            //dtpFechaReg.InitializeLifetimeService();
            cmbFormaPago.Text = "Seleccione";
            cmbCliente.Text = "Seleccione";
            txtDetalleVenta.Clear();
            txtBuscarProducto.Clear();
            txtTotalFinal.Clear();

        }

        private void txtIVA_TextChanged(object sender, EventArgs e)
        {
            calculoTotal();
            btnAgregarProd.Select();
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            calculoSubTotal();
        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {
            txtCantidad.Select();
        }

        private void dgvCompras_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            calcularTotalFinal();
        }

        private void txtBuscarProducto_KeyUp(object sender, KeyEventArgs e)
        {
            //cuando entra el numero y se acciona el evento de enter
            if (txtBuscarProducto.Text == "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnBuscarProducto.PerformClick();
                }
            }
            else if (e.KeyCode == Keys.Enter)
            {
                using (SICOVE1Entities2 db = new SICOVE1Entities2())
                {
                    tb_Productos producto = new tb_Productos();
                    tb_Categorias categorias = new tb_Categorias();
                    int buscar = int.Parse(txtBuscarProducto.Text);

                    producto = db.tb_Productos.Where(idBuscar => idBuscar.IdProducto == buscar).First();
                    categorias = db.tb_Categorias.Where(idBuscar => idBuscar.IdCategoria == buscar).First();

                    txtCodProducto.Text = Convert.ToString(producto.IdProducto);
                    txtNombreProducto.Text = Convert.ToString(producto.Nombre);
                    txtIdCategoriaProd.Text = Convert.ToString(categorias.IdCategoria);
                    txtCategoriaProd.Text = Convert.ToString(categorias.Nombre);

                    txtPrecio.Focus();
                    txtBuscarProducto.Text = "";
                    intentos = 2;
                }
            }
        }

        int intentos = 1;
        private void txtCantidad_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (intentos == 2)
                {
                    btnAgregarProd.PerformClick();

                    Limpiar();
                    intentos = 0;
                    txtBuscarProducto.Focus();
                }
                intentos += 1;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                using (SICOVE1Entities2 db = new SICOVE1Entities2())
                {
                    // se hacer el insert de la compra en la tabla de compras 
                    String comboProveedor = cmbCliente.SelectedValue.ToString();
                    ventas.IdCliente = Convert.ToInt32(comboProveedor);

                    String comboFPago = cmbFormaPago.SelectedValue.ToString();
                    ventas.IdFormaPago = Convert.ToInt32(comboFPago);

                    ventas.IdEmpleado = 1;
                    ventas.NumFac = Convert.ToInt32(txtNunFac.Text);
                    ventas.Detalle = txtDetalleVenta.Text;
                    ventas.TotalVenta = Convert.ToDecimal(txtTotalFinal.Text);
                    ventas.FechaRegistro = Convert.ToDateTime(dtpFechaReg.Text);


                    db.tb_Ventas.Add(ventas);
                    db.SaveChanges();


                    ///////////////////////////////////////////////////////////////////// Lilian Bonilla.
                    //se hace el insert para la tabla detalle de la compra 

                    tb_DetalleVentas detalleVenta = new tb_DetalleVentas();
                    for (int i = 0; i < dgvVentas.RowCount; i++)
                    {
                        String idProducto = dgvVentas.Rows[i].Cells[0].Value.ToString();
                        int IdProductoConvertidos = Convert.ToInt32(idProducto);

                        String idCategoria = dgvVentas.Rows[i].Cells[1].Value.ToString();
                        int IdCategoriaConvertida = Convert.ToInt32(idCategoria);

                        String precio = dgvVentas.Rows[i].Cells[4].Value.ToString();
                        decimal precioConvertidos = Convert.ToDecimal(precio);

                        String cantidad = dgvVentas.Rows[i].Cells[5].Value.ToString();
                        int cantidadConvertidos = Convert.ToInt32(cantidad);

                        String SubTotal = dgvVentas.Rows[i].Cells[6].Value.ToString();
                        decimal SubTotalConvertidos = Convert.ToDecimal(SubTotal);

                        String IVA = dgvVentas.Rows[i].Cells[7].Value.ToString();
                        decimal IVAConvertidos = Convert.ToDecimal(IVA);

                        String total = dgvVentas.Rows[i].Cells[7].Value.ToString();
                        decimal totalConvertidos = Convert.ToDecimal(total);


                        detalleVenta.IdVenta = Convert.ToInt32(txtNunFac.Text);

                        detalleVenta.IdProducto = IdProductoConvertidos;
                        detalleVenta.IdCategoria = IdCategoriaConvertida;
                        detalleVenta.PrecioVenta = precioConvertidos;
                        detalleVenta.Cantidad = cantidadConvertidos;
                        detalleVenta.SubTotal = SubTotalConvertidos;
                        detalleVenta.IVA = IVAConvertidos;
                        detalleVenta.Total = totalConvertidos;

                        db.tb_DetalleVentas.Add(detalleVenta);
                        db.SaveChanges();
                    }
                    MessageBox.Show("La venta se registro con exito ");
                    dgvVentas.Rows.Clear();
                    limpiarVenta();
                    Limpiar();
                    CargarCombos();
                    retornoId();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo salio mal... " + ex.ToString());
            }

        }
    }
}
