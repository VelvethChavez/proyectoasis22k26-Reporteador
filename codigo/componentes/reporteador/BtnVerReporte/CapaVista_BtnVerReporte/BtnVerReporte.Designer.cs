namespace CapaVista_BtnVerReporte
{
    partial class BtnVerReporte
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
            this.ReporteadorBtnVerReporte = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ReporteadorBtnVerReporte
            // 
            this.ReporteadorBtnVerReporte.BackColor = System.Drawing.Color.Transparent;
            this.ReporteadorBtnVerReporte.BackgroundImage = global::CapaVista_BtnVerReporte.Properties.Resources.btn_verReporte;
            this.ReporteadorBtnVerReporte.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ReporteadorBtnVerReporte.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ReporteadorBtnVerReporte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReporteadorBtnVerReporte.FlatAppearance.BorderSize = 0;
            this.ReporteadorBtnVerReporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReporteadorBtnVerReporte.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(230)))), ((int)(((byte)(214)))));
            this.ReporteadorBtnVerReporte.Location = new System.Drawing.Point(0, 0);
            this.ReporteadorBtnVerReporte.Margin = new System.Windows.Forms.Padding(4);
            this.ReporteadorBtnVerReporte.Name = "ReporteadorBtnVerReporte";
            this.ReporteadorBtnVerReporte.Size = new System.Drawing.Size(197, 195);
            this.ReporteadorBtnVerReporte.TabIndex = 0;
            this.ReporteadorBtnVerReporte.UseVisualStyleBackColor = false;
            this.ReporteadorBtnVerReporte.Click += new System.EventHandler(this.ReporteadorBtnVerReporte_Click);
            // 
            // BtnVerReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(230)))), ((int)(((byte)(214)))));
            this.Controls.Add(this.ReporteadorBtnVerReporte);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "BtnVerReporte";
            this.Size = new System.Drawing.Size(197, 195);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button ReporteadorBtnVerReporte;
    }
}
