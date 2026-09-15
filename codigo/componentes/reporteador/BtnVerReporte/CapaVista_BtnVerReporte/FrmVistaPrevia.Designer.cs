namespace CapaVista_BtnVerReporte
{
    partial class FrmVistaPrevia
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.ReporteadorCrvVistaPrevia = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // ReporteadorCrvVistaPrevia
            // 
            this.ReporteadorCrvVistaPrevia.ActiveViewIndex = -1;
            this.ReporteadorCrvVistaPrevia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ReporteadorCrvVistaPrevia.Cursor = System.Windows.Forms.Cursors.Default;
            this.ReporteadorCrvVistaPrevia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReporteadorCrvVistaPrevia.Location = new System.Drawing.Point(0, 0);
            this.ReporteadorCrvVistaPrevia.Name = "ReporteadorCrvVistaPrevia";
            this.ReporteadorCrvVistaPrevia.Size = new System.Drawing.Size(1100, 700);
            this.ReporteadorCrvVistaPrevia.TabIndex = 0;
            this.ReporteadorCrvVistaPrevia.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // FrmVistaPrevia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(230)))), ((int)(((byte)(214)))));
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.Controls.Add(this.ReporteadorCrvVistaPrevia);
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.Name = "FrmVistaPrevia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "3002 – VistaPrevia";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmVistaPrevia_FormClosed);
            this.Load += new System.EventHandler(this.FrmVistaPrevia_Load);
            this.ResumeLayout(false);
        }

        private CrystalDecisions.Windows.Forms.CrystalReportViewer ReporteadorCrvVistaPrevia;
    }
}
