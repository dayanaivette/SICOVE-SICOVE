using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoSICOVE.Model;

namespace ProyectoSICOVE.Formularios
{
    public partial class frmUsuarios : Form
    {
        public frmUsuarios()
        {
            InitializeComponent();
        }
        tb_Usuarios user = new tb_Usuarios();
        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            btnGuardar.Enabled = false;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;

            cargarGridview();
            limpiardatos();
            CargarCombo();
        }
        void cargarGridview()
        {
            using (SICOVE1Entities2 db = new SICOVE1Entities2())
            {
                var innerJoin =from tb_Roles in db.tb_Roles
                               from tb_Usuarios in db.tb_Usuarios
                               from tb_Empleados in db.tb_Empleados
                                where  tb_Roles.IdRol == tb_Usuarios.IdRol
                                && tb_Empleados.IdEmpleado == tb_Usuarios.IdEmpleado


                               select new
                                {
                                    IdUsuario = tb_Usuarios.IdUsuario,
                                    Usuario = tb_Usuarios.Usuario,
                                    Clave = tb_Usuarios.Clave,
                                    Fecha = tb_Usuarios.FechaRegistro,
                                    Rol = tb_Roles.Nombre,
                                    Empleado = tb_Empleados.Nombre,
                                   IdRol = tb_Roles.IdRol,
                                   IdEmpleado = tb_Empleados.IdEmpleado

                                };

                foreach (var iterardatostbUsuario in innerJoin)
                {
                    dgvUsuarios.Rows.Add(
                        iterardatostbUsuario.IdUsuario,
                        iterardatostbUsuario.Usuario,
                        iterardatostbUsuario.Clave,
                        iterardatostbUsuario.Fecha,
                        iterardatostbUsuario.Rol,
                        iterardatostbUsuario.Empleado,
                        iterardatostbUsuario.IdRol,
                        iterardatostbUsuario.IdEmpleado
                        );
                }
            }
        }
        void limpiardatos()
        {
            txtUsuario.Clear();
            txtClave.Text = "";
            cmbRol.Text = "";

           // txtUsuario.Focus();
        }
        void CargarCombo()
        {
            using (SICOVE1Entities2 db = new SICOVE1Entities2())
            {
                //cargando el combo de Rol, con los roles disponibles
                var Rol = db.tb_Roles.ToList();

                cmbRol.DataSource = Rol;
                cmbRol.DisplayMember = "Nombre";
                cmbRol.ValueMember = "IdRol";
                if (cmbRol.Items.Count > 1)
                    cmbRol.SelectedIndex = -1;
                cmbRol.Text = "Seleccione";

                //cargando el combo de empleado con los empleados 
                var Empleado = db.tb_Empleados.ToList();

                cmbEmpleado.DataSource = Empleado;
                cmbEmpleado.DisplayMember = "Nombre";
                cmbEmpleado.ValueMember = "IdEmpleado";
                if (cmbEmpleado.Items.Count > 1)
                    cmbEmpleado.SelectedIndex = -1;
                cmbEmpleado.Text = "Seleccione";
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                using (SICOVE1Entities2 db = new SICOVE1Entities2())
                {
                    user.Usuario = txtUsuario.Text;
                    user.Clave = txtClave.Text;

                    user.FechaRegistro = Convert.ToDateTime(dtpFechaReg.Text);

                    String comboRol = cmbRol.SelectedValue.ToString();
                    user.IdRol = Convert.ToInt32(comboRol);

                    String comboEmpleado = cmbEmpleado.SelectedValue.ToString();
                    user.IdEmpleado = Convert.ToInt32(comboEmpleado);


                    db.tb_Usuarios.Add(user);
                    db.SaveChanges();
                }
                MessageBox.Show("Usuario registrado con éxito");
                dgvUsuarios.Rows.Clear();
                cargarGridview();
                limpiardatos();
                CargarCombo();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Algo salio mal " + ex.ToString());
            }
            
        }

        private void dgvUsuarios_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            String usuario = dgvUsuarios.CurrentRow.Cells[1].Value.ToString();
            String clave = dgvUsuarios.CurrentRow.Cells[2].Value.ToString();
            String fecha = dgvUsuarios.CurrentRow.Cells[3].Value.ToString();
            String rol = dgvUsuarios.CurrentRow.Cells[4].Value.ToString();
            String empleado = dgvUsuarios.CurrentRow.Cells[5].Value.ToString();
            txtUsuario.Text = usuario;
            txtClave.Text = clave;
            dtpFechaReg.Text = fecha;
            cmbRol.Text = rol;
            cmbEmpleado.Text = empleado;

            btnGuardar.Enabled = false;
            btnNuevo.Enabled = true;
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            
            try
            {
                using (SICOVE1Entities2 db = new SICOVE1Entities2())
                {
                    string Id = dgvUsuarios.CurrentRow.Cells[0].Value.ToString();
                    int IdC = int.Parse(Id);
                    user = db.tb_Usuarios.Where(VerificarId => VerificarId.IdUsuario == IdC).First();
                    user.Usuario = txtUsuario.Text;
                    user.Clave = txtClave.Text;

                    String comboRol = cmbRol.SelectedValue.ToString();
                    user.IdRol = Convert.ToInt32(comboRol);

                    String comboEmpleado = cmbEmpleado.SelectedValue.ToString();
                    user.IdEmpleado = Convert.ToInt32(comboEmpleado);

                    user.FechaRegistro = Convert.ToDateTime(dtpFechaReg.Text);

                    db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                MessageBox.Show("Se Actualizo con éxito");
                dgvUsuarios.Rows.Clear();
                cargarGridview();
                limpiardatos();
                CargarCombo();

                btnGuardar.Enabled = true;
                btnNuevo.Enabled = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Algo Salio Mal... " + ex.ToString());
            }
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                using (SICOVE1Entities2 db = new SICOVE1Entities2())
                {
                    string Id = dgvUsuarios.CurrentRow.Cells[0].Value.ToString();

                    user = db.tb_Usuarios.Find(int.Parse(Id));
                    db.tb_Usuarios.Remove(user);
                    db.SaveChanges();
                }
                MessageBox.Show("El registro se eliminó con éxito");
                dgvUsuarios.Rows.Clear();
                cargarGridview();
                limpiardatos();
                CargarCombo();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Algo salio mal, intente de nuevo");
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {

                groupBox1.Enabled = true;
                btnGuardar.Enabled = true;
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;

                btnNuevo.Enabled = false;

                dgvUsuarios.Rows.Clear();
                cargarGridview();
                limpiardatos();
                CargarCombo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo salio mal... " + ex.ToString());
            }
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
