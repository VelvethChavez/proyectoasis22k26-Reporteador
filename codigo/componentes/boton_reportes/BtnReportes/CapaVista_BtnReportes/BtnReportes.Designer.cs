namespace CapaVista_BtnReportes
{
    partial class BtnReportes
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
            this.BtnAccionReportes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // BtnAccionReportes
            //
            this.BtnAccionReportes.BackColor = System.Drawing.Color.Transparent;
            this.BtnAccionReportes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnAccionReportes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAccionReportes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnAccionReportes.FlatAppearance.BorderSize = 0;
            this.BtnAccionReportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAccionReportes.Image = global::CapaVista_BtnReportes.Properties.Resources.btn_reportes;
            this.BtnAccionReportes.Location = new System.Drawing.Point(0, 0);
            this.BtnAccionReportes.Name = "BtnAccionReportes";
            this.BtnAccionReportes.Size = new System.Drawing.Size(56, 56);
            this.BtnAccionReportes.TabIndex = 0;
            this.BtnAccionReportes.UseVisualStyleBackColor = false;
            //
            // BtnReportes
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.BtnAccionReportes);
            this.Name = "BtnReportes";
            this.Size = new System.Drawing.Size(56, 56);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Button BtnAccionReportes;
    }
}
