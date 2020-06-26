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
using ProyectoSICOVE.Formularios.frmBusquedas;

namespace ProyectoSICOVE.Formularios
{
    public partial class frmCompras : Form
    {
        public frmCompras()
        {
            InitializeComponent();
        }
        tb_Compras compras = new tb_Compras();
        tb_Inventarios inventarios = new tb_Inventarios();
        private void frmCompras_Load(object sender, EventArgs e)
        {
            CargarCombos();
            txtNunFac.Focus();
            retornoId();
        }
        void retornoId()
        {
            using (SICOVE1Entities2 db = new SICOVE1Entities2())
            {

                var tb_compras = db.tb_Compras;
                txtNunFac.Text = "1";
                foreach (var iterardatostbventa in tb_compras)
                {
                    int idCompra = iterardatostbventa.NumFac;
                    int suma = idCompra + 1;
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

                //cargando el combo con proveedores.
                var Proveedores = db.tb_Proveedores.ToList();

                cmbProveedor.DataSource = Proveedores;
                cmbProveedor.DisplayMember = "Nombre";
                cmbProveedor.ValueMember = "IdProveedor";
                if (cmbProveedor.Items.Count > 1)
                    cmbProveedor.SelectedIndex = -1;
                cmbProveedor.Text = "Seleccione";
                cmbProveedor.Refresh();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnRegistrarProveedor_Click(object sender, EventArgs e)
        {
            frmProveedor proveedor = new frmProveedor();
            proveedor.ShowDialog();
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            frmBuscarProducto productos = new frmBuscarProducto();
            productos.ShowDialog();
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
            txtIdCategoria.Clear();
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
                Double iva = 0;
                Double total;

                subTotal = Convert.ToDouble(txtSubTotal.Text);
                iva = Convert.ToDouble(txtIVA.Text);

                total = subTotal + iva;
                txtTotal.Text = total.ToString();
            }
            catch (Exception ex)
            {
                //txtCantidad.Text = "1";
                //txtIVA.Select();
            }
        }

        //agregando el detalle del producto a la tabla, el cual sera el detalle de la compra 
        private void btnAgregarProd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodProducto.Text) || string.IsNullOrEmpty(txtIdCategoria.Text) ||
                 string.IsNullOrEmpty(txtCantidad.Text) || string.IsNullOrEmpty(txtPrecio.Text))
            {
                MessageBox.Show("Debe rellenar los campos", "Completar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
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
                dgvCompras.Rows.Add(txtCodProducto.Text, txtIdCategoria.Text, txtNombreProducto.Text, txtCategoriaProd.Text,
                    txtPrecio.Text, txtCantidad.Text, txtSubTotal.Text, txtIVA.Text, txtTotal.Text);

                //Calcula el valor total de la compra
                calcularTotalFinal();
                Limpiar();
                txtBuscarProducto.Select();
                txtCantidad.Text = "1";
                //srive para refrescar la grid
                dgvCompras.Refresh();
                //selecciona la filla de la grid que se va agregando 
                dgvCompras.ClearSelection();
                //se ubica en la ultima fila insertada en la grid y genera el scroll
                int obtenerUltimaFilas = dgvCompras.Rows.Count - 1;
                dgvCompras.FirstDisplayedScrollingRowIndex = obtenerUltimaFilas;
                dgvCompras.Rows[obtenerUltimaFilas].Selected = true;

                txtBuscarProducto.Focus();
            }
        }


        //calculo del total final de toda la compra
        void calcularTotalFinal()
        {
            Double suma = 0;
            for (int i = 0; i < dgvCompras.RowCount; i++)
            {
                String datosOperar = dgvCompras.Rows[i].Cells[8].Value.ToString();
                Double datosConvertidos = Convert.ToDouble(datosOperar);

                suma += datosConvertidos;
                txtTotalFinal.Text = suma.ToString();

            }
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
        void limpiarVenta()
        {
           // txtNunFac.Clear();
            //dtpFechaReg.InitializeLifetimeService();
            cmbFormaPago.Text = "Seleccione";
            cmbProveedor.Text = "Seleccione";
            txtDetalleCompra.Clear();
            txtBuscarProducto.Clear();
            txtTotalFinal.Clear();

        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            limpiarVenta();
            dgvCompras.Rows.Clear();
        }

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {
            txtCantidad.Select();
        }

        private void dgvCompras_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            calcularTotalFinal();
        }

        //llamdo por medio de codigo de barras el producto
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
                    txtIdCategoria.Text = Convert.ToString(categorias.IdCategoria);
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
            if (string.IsNullOrEmpty(cmbProveedor.Text) || string.IsNullOrEmpty(cmbFormaPago.Text) || string.IsNullOrEmpty(txtTotalFinal.Text))
            {
                MessageBox.Show("Debe de llenar los campos de la compra", "Completar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {

                try
                {
                    using (SICOVE1Entities2 db = new SICOVE1Entities2())
                    {

                        // se hacer el insert de la compra en la tabla de compras 
                        String comboProveedor = cmbProveedor.SelectedValue.ToString();
                        compras.IdProveedor = Convert.ToInt32(comboProveedor);

                        String comboFPago = cmbFormaPago.SelectedValue.ToString();
                        compras.IdFormaPago = Convert.ToInt32(comboFPago);

                        compras.IdEmpleado = 1;
                        compras.NumFac = Convert.ToInt32(txtNunFac.Text);
                        compras.DetalleCompra = txtDetalleCompra.Text;
                        compras.TotalCompra = Convert.ToDecimal(txtTotalFinal.Text);
                        compras.FechaRegistro = Convert.ToDateTime(dtpFechaReg.Text);


                        db.tb_Compras.Add(compras);
                        db.SaveChanges();


                        ///////////////////////////////////////////////////////////////////// Lilian Bonilla.
                        //se hace el insert para la tabla detalle de la compra 

                        tb_DetalleCompras detalleCompra = new tb_DetalleCompras();
                        for (int i = 0; i < dgvCompras.RowCount; i++)
                        {
                            String idProducto = dgvCompras.Rows[i].Cells[0].Value.ToString();
                            int IdProductoConvertidos = Convert.ToInt32(idProducto);

                            String idCategoria = dgvCompras.Rows[i].Cells[1].Value.ToString();
                            int IdCategoriaConvertida = Convert.ToInt32(idCategoria);

                            String precio = dgvCompras.Rows[i].Cells[4].Value.ToString();
                            decimal precioConvertidos = Convert.ToDecimal(precio);

                            String cantidad = dgvCompras.Rows[i].Cells[5].Value.ToString();
                            int cantidadConvertidos = Convert.ToInt32(cantidad);

                            String SubTotal = dgvCompras.Rows[i].Cells[6].Value.ToString();
                            decimal SubTotalConvertidos = Convert.ToDecimal(SubTotal);

                            String IVA = dgvCompras.Rows[i].Cells[7].Value.ToString();
                            decimal IVAConvertidos = Convert.ToDecimal(IVA);

                            String total = dgvCompras.Rows[i].Cells[8].Value.ToString();
                            decimal totalConvertidos = Convert.ToDecimal(total);


                            detalleCompra.IdCompra = Convert.ToInt32(txtNunFac.Text);

                            detalleCompra.IdProducto = IdProductoConvertidos;
                            detalleCompra.IdCategoria = IdCategoriaConvertida;
                            detalleCompra.PrecioCompra = precioConvertidos;
                            detalleCompra.Cantidad = cantidadConvertidos;
                            detalleCompra.SubTotal = SubTotalConvertidos;
                            detalleCompra.IVA = IVAConvertidos;
                            detalleCompra.Total = totalConvertidos;


                            var listaInventario = db.tb_Inventarios;
                            try
                            {
                                inventarios = db.tb_Inventarios.Where(VerificarId => VerificarId.IdProducto == IdProductoConvertidos).First();
                                foreach (var iterardatostbventa in listaInventario)
                                {
                                    int idCompra = inventarios.Existencia;

                                    inventarios.Existencia = inventarios.Existencia + cantidadConvertidos;
                                    db.Entry(inventarios).State = System.Data.Entity.EntityState.Modified;
                                }
                            }
                            catch (Exception ex)
                            {
                                inventarios.Existencia = inventarios.Existencia + cantidadConvertidos;
                                inventarios.IdProducto = IdProductoConvertidos;
                                db.tb_Inventarios.Add(inventarios);
                            }


                            db.tb_DetalleCompras.Add(detalleCompra);
                            db.SaveChanges();



                         

                        }
                        MessageBox.Show("La Compra se registro con exito ");
                        dgvCompras.Rows.Clear();
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
        /// ///////////validacion de parametro 
        Validaciones v = new Validaciones();
        private void txtDetalleCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.Descripciones(e);
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.soloNumeros(e);
        }
    }
}
