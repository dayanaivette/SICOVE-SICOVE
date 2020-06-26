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
    public partial class frmCategorias : Form
    {
        public frmCategorias()
        {
            InitializeComponent();
        }
        tb_Categorias categorias = new tb_Categorias();
        private void frmCategorias_Load(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            btnGuardar.Enabled = false;
            btnEditar.Enabled = false;
            btnEminiar.Enabled = false;
            cargardatos();

        }

        void cargardatos()
        {
            try
            {
                using (SICOVE1Entities2 db = new SICOVE1Entities2())
                {
                    var tb_Categorias = db.tb_Categorias;
                    foreach (var iterardatostbUsuario in tb_Categorias)
                    {
                        dgvCategoria.Rows.Add(
                            iterardatostbUsuario.IdCategoria,
                            iterardatostbUsuario.Nombre,
                            iterardatostbUsuario.FechaRegistro);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo salio mal " + ex.ToString());
            }

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
                try
                {
                    groupBox1.Enabled = true;
                    btnGuardar.Enabled = true;
                    btnEditar.Enabled = true;
                    btnEminiar.Enabled = true;
                    btnNuevo.Enabled = false;

                    dgvCategoria.Rows.Clear();
                    cargardatos();
                    txtCategoria.Clear();
                    txtCategoria.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Algo salio mal " + ex.ToString());
                }
            
        }
        private bool validarCategoria()
        {
            bool ok = true;
            if (txtCategoria.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtCategoria, "Ingrese una Categoria");
            }
            return ok;
        }

        private void borrarValidacion()
        {
            errorProvider1.SetError(txtCategoria, "");
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            borrarValidacion();
            if (validarCategoria())
            {
                try
                {
                    using (SICOVE1Entities2 db = new SICOVE1Entities2())
                    {
                        categorias.Nombre = txtCategoria.Text;
                        categorias.FechaRegistro = Convert.ToDateTime(dtpFechaReg.Text);

                        db.tb_Categorias.Add(categorias);
                        db.SaveChanges();
                    }
                    MessageBox.Show("La categoría se ha Registrado con éxito");
                    dgvCategoria.Rows.Clear();
                    cargardatos();
                    txtCategoria.Clear();
                    txtCategoria.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Algo salio mal " + ex.ToString());
                }
            }

        }
        //llevar los datos de la gris al los txt
        private void dgvCategoria_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String Categoria = dgvCategoria.CurrentRow.Cells[1].Value.ToString();
            String Fecha = dgvCategoria.CurrentRow.Cells[2].Value.ToString();
            txtCategoria.Text = Categoria;
            dtpFechaReg.Text = Fecha;

            btnGuardar.Enabled = false;
            btnNuevo.Enabled = true;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            borrarValidacion();
            if (validarCategoria())
            {
                try
                {
                    using (SICOVE1Entities2 db = new SICOVE1Entities2())
                    {
                        string Id = dgvCategoria.CurrentRow.Cells[0].Value.ToString();
                        int IdC = int.Parse(Id);
                        categorias = db.tb_Categorias.Where(VerificarId => VerificarId.IdCategoria == IdC).First();
                        categorias.Nombre = txtCategoria.Text;
                        categorias.FechaRegistro = Convert.ToDateTime(dtpFechaReg.Text);
                        db.Entry(categorias).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    MessageBox.Show("La categoría se ha Actualizo con éxito");
                    dgvCategoria.Rows.Clear();
                    cargardatos();
                    txtCategoria.Clear();
                    txtCategoria.Focus();

                    btnGuardar.Enabled = true;
                    btnNuevo.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Algo salio mal " + ex.ToString());
                }
            }
        }

        private void btnEminiar_Click(object sender, EventArgs e)
        {
                try
                {
                    using (SICOVE1Entities2 db = new SICOVE1Entities2())
                    {
                        string Id = dgvCategoria.CurrentRow.Cells[0].Value.ToString();

                        categorias = db.tb_Categorias.Find(int.Parse(Id));
                        db.tb_Categorias.Remove(categorias);
                        db.SaveChanges();
                    }
                    MessageBox.Show("La categoría se ha Eliminado con éxito");
                    dgvCategoria.Rows.Clear();
                    cargardatos();
                    txtCategoria.Clear();
                    txtCategoria.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Algo salio mal " + ex.ToString());
                }
            

        }

        private void btnCerrar1_Click(object sender, EventArgs e)
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
        Validaciones v = new Validaciones();
        private void txtCategoria_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.soloLetras(e);
        }
    }
}
