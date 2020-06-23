namespace ProyectoSICOVE.ConsultarRPT
{
    partial class frmrptClientes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.crClientes = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.crClientes);
            this.panel1.Location = new System.Drawing.Point(4, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(872, 482);
            this.panel1.TabIndex = 0;
            // 
            // crClientes
            // 
            this.crClientes.ActiveViewIndex = -1;
            this.crClientes.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.crClientes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crClientes.Cursor = System.Windows.Forms.Cursors.Default;
            this.crClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crClientes.Location = new System.Drawing.Point(0, 0);
            this.crClientes.Name = "crClientes";
            this.crClientes.Size = new System.Drawing.Size(872, 482);
            this.crClientes.TabIndex = 0;
            // 
            // frmrptClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 514);
            this.Controls.Add(this.panel1);
            this.Name = "frmrptClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmrptClientes";
            this.Load += new System.EventHandler(this.frmrptClientes_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crClientes;
    }
}