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
    public partial class frmClientes : Form
    {
        public frmClientes()
        {
            InitializeComponent();
        }
        tb_Clientes clientes = new tb_Clientes();

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            btnGuardar.Enabled = false;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            cargardatos();
            limpiartxt();

        }
        void cargardatos()
        {
            try
            {

                using (SICOVE1Entities2 db = new SICOVE1Entities2())
                {
                    var tb_Clientes = db.tb_Clientes;
                    foreach (var iterardatostbUsuario in tb_Clientes)
                    {
                        dgvClientes.Rows.Add(
                            iterardatostbUsuario.IdCliente,
                            iterardatostbUsuario.Nombre,
                            iterardatostbUsuario.Direccion,
                            iterardatostbUsuario.Celular,
                            iterardatostbUsuario.DUI,
                            iterardatostbUsuario.FechaRegistro);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo salio mal... Intente de nuevo " + ex.ToString());
            }
        }

        void limpiartxt()
        {
            txtNombre.Clear();
            txtDireccion.Clear();
            txtCelular.Clear();
            txtDUI.Clear();

            txtNombre.Focus();
        }
        
        private void btnGuardar_Click(object sender, EventArgs e)
        {
                try
                {

                    using (SICOVE1Entities2 db = new SICOVE1Entities2())
                    {
                        clientes.Nombre = txtNombre.Text;
                        clientes.Direccion = txtDireccion.Text;
                        clientes.Celular = txtCelular.Text;
                        clientes.DUI = txtDUI.Text;
                        clientes.FechaRegistro = Convert.ToDateTime(dtpFechaReg.Text);

                        db.tb_Clientes.Add(clientes);
                        db.SaveChanges();
                    }
                    MessageBox.Show("El Cliente se ha Registrado con éxito");
                    dgvClientes.Rows.Clear();
                    cargardatos();
                    limpiartxt();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Algo salio mal... Intente de nuevo " + ex.ToString());
                }

        }

        private void dgvClientes_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
                try
                {

                    String Nombre = dgvClientes.CurrentRow.Cells[1].Value.ToString();
                    String Direccion = dgvClientes.CurrentRow.Cells[2].Value.ToString();
                    String Celular = dgvClientes.CurrentRow.Cells[3].Value.ToString();
                    String DUI = dgvClientes.CurrentRow.Cells[4].Value.ToString();
                    String Fecha = dgvClientes.CurrentRow.Cells[5].Value.ToString();
                    txtNombre.Text = Nombre;
                    txtDireccion.Text = Direccion;
                    txtCelular.Text = Celular;
                    txtDUI.Text = DUI;
                    dtpFechaReg.Text = Fecha;

                    btnGuardar.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Algo salio mal... Intente de nuevo " + ex.ToString());
                }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
                try
                {

                    using (SICOVE1Entities2 db = new SICOVE1Entities2())
                    {
                        string Id = dgvClientes.CurrentRow.Cells[0].Value.ToString();
                        int IdC = int.Parse(Id);
                        clientes = db.tb_Clientes.Where(VerificarId => VerificarId.IdCliente == IdC).First();
                        clientes.Nombre = txtNombre.Text;
                        clientes.Direccion = txtDireccion.Text;
                        clientes.Celular = txtCelular.Text;
                        clientes.DUI = txtDUI.Text;
                        clientes.FechaRegistro = Convert.ToDateTime(dtpFechaReg.Text);

                        db.Entry(clientes).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    MessageBox.Show("El Cliente se ha Actualizado con éxito");
                    dgvClientes.Rows.Clear();
                    cargardatos();
                    limpiartxt();

                    btnGuardar.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Algo salio mal... Intente de nuevo " + MessageBoxIcon.Exclamation + ex.ToString());
                }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
                try
                {

                    using (SICOVE1Entities2 db = new SICOVE1Entities2())
                    {
                        string Id = dgvClientes.CurrentRow.Cells[0].Value.ToString();

                        clientes = db.tb_Clientes.Find(int.Parse(Id));
                        db.tb_Clientes.Remove(clientes);
                        db.SaveChanges();
                    }
                    MessageBox.Show("El Cliente se ha Eliminado con éxito");
                    dgvClientes.Rows.Clear();
                    cargardatos();
                    limpiartxt();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Algo salio mal... Intente de nuevo " + ex.ToString());
                }
            
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
                groupBox1.Enabled = true;
                btnGuardar.Enabled = true;
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
                dgvClientes.Rows.Clear();
                cargardatos();
                limpiartxt();
            

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

        private void txtCelular_Validating(object sender, CancelEventArgs e)
        {
        }

        /// ///////////7777 va lidacion de campos
        /// </summary>
        Validaciones v = new Validaciones();
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.soloLetras(e);
        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.Descripciones(e);
        }

        private void txtCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.soloNumeros(e);
        }

        private void txtDUI_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.soloNumeros(e);
        }
    }
}
