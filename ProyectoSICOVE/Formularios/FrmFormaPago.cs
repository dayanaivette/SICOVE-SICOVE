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
    public partial class frmFormaPago : Form
    {
        public frmFormaPago()
        {
            InitializeComponent();
        }
        tb_FormaPago formaPago = new tb_FormaPago();
        private void frmFormaPago_Load(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            btnGuardar.Enabled = false;
            btnEminiar.Enabled = false;
            btnEditar.Enabled = false;
            cargardatos();
            txtFPago.Focus();
        }
        void cargardatos()
        {
            try
            {

                using (SICOVE1Entities2 db = new SICOVE1Entities2())
                {
                    var tb_FormaPago = db.tb_FormaPago;
                    foreach (var iterardatostbUsuario in tb_FormaPago)
                    {
                        dgvFPagos.Rows.Add(
                            iterardatostbUsuario.IdFormaPago,
                            iterardatostbUsuario.Nombre);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(" Algo salio mal...  ¡Intente de nuevo! ");
            }
        }

        private bool validarFPagos()
        {
            bool ok = true;
            if (txtFPago.Text == "")
            {
                ok = false;
                errorProvider1.SetError(txtFPago, "Ingrese una Forma de pago");
            }
            return ok;
        }

        private void borrarValidacion()
        {
            errorProvider1.SetError(txtFPago, "");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            borrarValidacion();
            if (validarFPagos())
            {
                try
                {
                    using (SICOVE1Entities2 db = new SICOVE1Entities2())
                    {
                        if (txtFPago.Text == "")
                        {
                            MessageBox.Show("Debe dijitar una forma de pago");
                        }
                        else
                        {
                            formaPago.Nombre = txtFPago.Text;

                            db.tb_FormaPago.Add(formaPago);
                            db.SaveChanges();
                        }
                    }
                    MessageBox.Show("La Forma de Pago se ha registrado con éxito");
                    dgvFPagos.Rows.Clear();
                    cargardatos();
                    txtFPago.Clear();
                    txtFPago.Focus();
                }
                catch (Exception ex)
                {
                    //System.Windows.Forms.MessageBox.Show("Error: " + ex.Message, "FormaPago");
                    MessageBox.Show(" Algo salio mal...  ¡Intente de nuevo! ");
                }
            }
           
        }

        private void dgvFPagos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String fPagos = dgvFPagos.CurrentRow.Cells[1].Value.ToString();
            txtFPago.Text = fPagos;

            btnGuardar.Enabled = false;
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            borrarValidacion();
            if (validarFPagos())
            {
                try
                {
                    using (SICOVE1Entities2 db = new SICOVE1Entities2())
                    {
                        string Id = dgvFPagos.CurrentRow.Cells[0].Value.ToString();
                        int IdC = int.Parse(Id);
                        formaPago = db.tb_FormaPago.Where(VerificarId => VerificarId.IdFormaPago == IdC).First();
                        formaPago.Nombre = txtFPago.Text;
                        db.Entry(formaPago).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    MessageBox.Show("La Forma de Pago se ha Actualizado con éxito");
                    dgvFPagos.Rows.Clear();
                    cargardatos();
                    txtFPago.Clear();
                    txtFPago.Focus();

                    btnGuardar.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(" Algo salio mal...  ¡Intente de nuevo! ");
                }
            }
            
        }

        private void btnEminiar_Click(object sender, EventArgs e)
        {
            borrarValidacion();
            if (validarFPagos())
            {
                try
                {
                    using (SICOVE1Entities2 db = new SICOVE1Entities2())
                    {
                        string Id = dgvFPagos.CurrentRow.Cells[0].Value.ToString();

                        formaPago = db.tb_FormaPago.Find(int.Parse(Id));
                        db.tb_FormaPago.Remove(formaPago);
                        db.SaveChanges();
                    }
                    MessageBox.Show("La Forma de Pago se ha Eliminado con éxito");
                    dgvFPagos.Rows.Clear();
                    cargardatos();
                    txtFPago.Clear();
                    txtFPago.Focus();

                    btnGuardar.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(" Algo salio mal...  ¡Intente de nuevo! ");
                }
            }
            
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            borrarValidacion();
            if (validarFPagos())
            {
                try
                {

                    groupBox1.Enabled = true;
                    btnGuardar.Enabled = true;
                    btnEminiar.Enabled = true;
                    btnEditar.Enabled = true;
                    dgvFPagos.Rows.Clear();
                    cargardatos();
                    txtFPago.Clear();

                    btnNuevo.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Algo salio mal... " + ex.ToString());
                }
            }
        }

        private void btnCerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMini_Click(object sender, EventArgs e)
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
