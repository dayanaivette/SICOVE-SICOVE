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
    public partial class frmEmpleado : Form
    {
        public frmEmpleado()
        {
            InitializeComponent();
        }
        tb_Empleados empleados = new tb_Empleados();
        private void FrmEmpleado_Load(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            btnGuardar.Enabled = false;
            btnEliminar.Enabled = false;
            btnEditar.Enabled = false;
            btnNuevoUsuario.Enabled = false;

            limpiartxt();
            cargardatos();
        }
        void cargardatos()
        {
            try
            {
                dgvEmpleados.Rows.Clear();
                using (SICOVE1Entities2 db = new SICOVE1Entities2())
                {
                    var tb_Empleados = db.tb_Empleados;
                    foreach (var iterardatostbUsuario in tb_Empleados)
                    {
                        dgvEmpleados.Rows.Add(
                            iterardatostbUsuario.IdEmpleado,
                            iterardatostbUsuario.Nombre,
                            iterardatostbUsuario.Direccion,
                            iterardatostbUsuario.Celular,
                            iterardatostbUsuario.DUI,
                            iterardatostbUsuario.FechaRegistro
                            );
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
        private void btnCerrar1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }


        private void btnNuevo_Click(object sender, EventArgs e)
        {
                try
                {

                    groupBox1.Enabled = true;
                    btnGuardar.Enabled = true;
                    btnEliminar.Enabled = true;
                    btnEditar.Enabled = true;

                    btnNuevoUsuario.Enabled = true;

                    limpiartxt();
                    cargardatos();
                }
                catch(Exception ex)
                {
                    ex.ToString();
                }
            
        }
        private bool ValidarEmpelado()
        {
            bool ok = false;
            if (txtNombre.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtNombre, "Ingrese un Nombre");
            }
            if (txtDireccion.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtDireccion, "Ingrese una Dirección");
            }
            if (txtCelular.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtCelular, "Ingrese un Celular");
            }
            if (txtDUI.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtDUI, "Ingrese un DUI");
            }
            return ok;
        }
        private void BorrarValidacion()
        {
            errorProvider1.SetError(txtNombre, "");
            errorProvider1.SetError(txtDireccion, "");
            errorProvider1.SetError(txtCelular, "");
            errorProvider1.SetError(txtDUI, "");
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            BorrarValidacion();
            if (ValidarEmpelado())
            {
                try
                {

                    using (SICOVE1Entities2 db = new SICOVE1Entities2())
                    {
                        empleados.Nombre = txtNombre.Text;
                        empleados.Direccion = txtDireccion.Text;
                        empleados.Celular = txtCelular.Text;
                        empleados.DUI = txtDUI.Text;
                        empleados.FechaRegistro = Convert.ToDateTime(dtpFechaReg.Text);

                        db.tb_Empleados.Add(empleados);
                        db.SaveChanges();
                    }
                    MessageBox.Show("El Empleado se ha Registrado con éxito");
                    dgvEmpleados.Rows.Clear();
                    cargardatos();
                    limpiartxt();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Algo salio mal... Intente de nuevo" + ex.ToString());
                }
            }
        }
        private void dgvEmpleados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                String Nombre = dgvEmpleados.CurrentRow.Cells[1].Value.ToString();
                String Direccion = dgvEmpleados.CurrentRow.Cells[2].Value.ToString();
                String Celular = dgvEmpleados.CurrentRow.Cells[3].Value.ToString();
                String DUI = dgvEmpleados.CurrentRow.Cells[4].Value.ToString();
                String Fecha = dgvEmpleados.CurrentRow.Cells[5].Value.ToString();

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
        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            BorrarValidacion();
            if (ValidarEmpelado())
            {
                try
                {

                    using (SICOVE1Entities2 db = new SICOVE1Entities2())
                    {
                        string Id = dgvEmpleados.CurrentRow.Cells[0].Value.ToString();
                        int IdC = int.Parse(Id);
                        empleados = db.tb_Empleados.Where(VerificarId => VerificarId.IdEmpleado == IdC).First();
                        empleados.Nombre = txtNombre.Text;
                        empleados.Direccion = txtDireccion.Text;
                        empleados.Celular = txtCelular.Text;
                        empleados.DUI = txtDUI.Text;
                        empleados.FechaRegistro = Convert.ToDateTime(dtpFechaReg.Text);
                        db.Entry(empleados).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    MessageBox.Show("El Empleado se ha Actualizado con éxito");
                    dgvEmpleados.Rows.Clear();
                    cargardatos();
                    limpiartxt();

                    btnGuardar.Enabled = true;
                    btnNuevo.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Algo salio mal... Intente de nuevo " + ex.ToString());
                }
            }
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
                try
                {

                    using (SICOVE1Entities2 db = new SICOVE1Entities2())
                    {
                        string Id = dgvEmpleados.CurrentRow.Cells[0].Value.ToString();

                        empleados = db.tb_Empleados.Find(int.Parse(Id));
                        db.tb_Empleados.Remove(empleados);
                        db.SaveChanges();
                    }
                    MessageBox.Show("El Empleado se ha Eliminado con éxito");
                    dgvEmpleados.Rows.Clear();
                    cargardatos();
                    limpiartxt();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Algo salio mal... Intente de nuevo " + ex.ToString());
                }
            
        }

        private void btnCerrar_Click_1(object sender, EventArgs e)
        {
            this.Hide();
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

        private void btnNuevoUsuario_Click(object sender, EventArgs e)
        {
            frmUsuarios usuarios = new frmUsuarios();
            usuarios.ShowDialog();
        }

        private void txtCelular_Validating(object sender, CancelEventArgs e)
        {
            int num;
            if (int.TryParse(txtCelular.Text, out num))
            {
                errorProvider1.SetError(txtCelular, "Ingrese el valor en números");
            }
            else
            {
                errorProvider1.SetError(txtCelular, "");
            }
        }
    }
}
