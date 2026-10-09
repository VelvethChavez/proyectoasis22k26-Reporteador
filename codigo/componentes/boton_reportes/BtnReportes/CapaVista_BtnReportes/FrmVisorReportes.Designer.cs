namespace CapaVista_BtnReportes
{
    partial class FrmVisorReportes
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
            this.ReportViewerBtn = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            //
            // ReportViewerBtn
            //
            this.ReportViewerBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReportViewerBtn.Location = new System.Drawing.Point(0, 0);
            this.ReportViewerBtn.Name = "ReportViewerBtn";
            this.ReportViewerBtn.ServerReport.BearerToken = null;
            this.ReportViewerBtn.Size = new System.Drawing.Size(984, 661);
            this.ReportViewerBtn.TabIndex = 0;
            //
            // FrmVisorReportes
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.ReportViewerBtn);
            this.Name = "FrmVisorReportes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte";
            this.Load += new System.EventHandler(this.FrmVisorReportes_Load);
            this.ResumeLayout(false);

        }

        private Microsoft.Reporting.WinForms.ReportViewer ReportViewerBtn;
    }
}
