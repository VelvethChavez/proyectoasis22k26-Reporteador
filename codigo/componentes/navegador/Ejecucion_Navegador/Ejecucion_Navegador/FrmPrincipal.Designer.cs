namespace CapaVista_Navegador
{
    partial class FrmPrincipal
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
            this.navegador1 = new CapaVista_Navegador.Navegador();
            this.lblReporte = new System.Windows.Forms.Label();
            this.cmbReporte = new System.Windows.Forms.ComboBox();
            this.btnReportes1 = new CapaVista_BtnReportes.BtnReportes();
            this.SuspendLayout();
            //
            // lblReporte
            //
            this.lblReporte.AutoSize = true;
            this.lblReporte.Location = new System.Drawing.Point(20, 132);
            this.lblReporte.Name = "lblReporte";
            this.lblReporte.Size = new System.Drawing.Size(150, 16);
            this.lblReporte.TabIndex = 1;
            this.lblReporte.Text = "Reporte de Seguridad:";
            //
            // cmbReporte
            //
            this.cmbReporte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReporte.Location = new System.Drawing.Point(176, 129);
            this.cmbReporte.Name = "cmbReporte";
            this.cmbReporte.Size = new System.Drawing.Size(340, 24);
            this.cmbReporte.TabIndex = 2;
            //
            // btnReportes1
            //
            this.btnReportes1.BackColor = System.Drawing.Color.Transparent;
            this.btnReportes1.Location = new System.Drawing.Point(530, 118);
            this.btnReportes1.Name = "btnReportes1";
            this.btnReportes1.Size = new System.Drawing.Size(56, 56);
            this.btnReportes1.TabIndex = 3;
            this.btnReportes1.SolicitarDatos += new System.EventHandler<CapaVista_BtnReportes.ClsEventoSolicitarDatos>(this.btnReportes1_SolicitarDatos);
            //
            // navegador1
            //
            this.navegador1.Location = new System.Drawing.Point(0, 0);
            this.navegador1.Name = "navegador1";
            this.navegador1.Size = new System.Drawing.Size(1438, 111);
            this.navegador1.TabIndex = 0;
            //
            // FrmPrincipal
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(233)))), ((int)(((byte)(217)))));
            this.ClientSize = new System.Drawing.Size(1480, 653);
            this.Controls.Add(this.btnReportes1);
            this.Controls.Add(this.cmbReporte);
            this.Controls.Add(this.lblReporte);
            this.Controls.Add(this.navegador1);
            this.Name = "FrmPrincipal";
            this.Text = "1001 – Crud";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Navegador navegador1;
        private System.Windows.Forms.Label lblReporte;
        private System.Windows.Forms.ComboBox cmbReporte;
        private CapaVista_BtnReportes.BtnReportes btnReportes1;
    }
}
