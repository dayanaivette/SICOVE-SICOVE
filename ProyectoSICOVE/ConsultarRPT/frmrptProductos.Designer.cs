namespace ProyectoSICOVE.ConsultarRPT
{
    partial class frmrptProductos
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
            this.crProductos = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.CrystalReport11 = new ProyectoSICOVE.CrystalReport1();
            this.SuspendLayout();
            // 
            // crProductos
            // 
            this.crProductos.ActiveViewIndex = -1;
            this.crProductos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crProductos.Cursor = System.Windows.Forms.Cursors.Default;
            this.crProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crProductos.Location = new System.Drawing.Point(0, 0);
            this.crProductos.Name = "crProductos";
            this.crProductos.ReportSource = this.CrystalReport11;
            this.crProductos.Size = new System.Drawing.Size(913, 489);
            this.crProductos.TabIndex = 0;
            // 
            // frmrptProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 489);
            this.Controls.Add(this.crProductos);
            this.Name = "frmrptProductos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmrptProductos";
            this.Load += new System.EventHandler(this.frmrptProductos_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crProductos;
        private CrystalReport1 CrystalReport11;
    }
}