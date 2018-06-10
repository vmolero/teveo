namespace TVO_VistaWindows
{
    partial class FVistaPortadaModerador
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnComentarios = new System.Windows.Forms.Button();
            this.btnProgramas = new System.Windows.Forms.Button();
            this.etInfo = new System.Windows.Forms.Label();
            this.pnlBotonesPortadaBase.SuspendLayout();
            this.pnlInfoPortadaBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgPortadaBaseFoto)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBotonesPortadaBase
            // 
            this.pnlBotonesPortadaBase.BackColor = System.Drawing.Color.IndianRed;
            this.pnlBotonesPortadaBase.Controls.Add(this.etInfo);
            this.pnlBotonesPortadaBase.Controls.Add(this.btnProgramas);
            this.pnlBotonesPortadaBase.Controls.Add(this.btnComentarios);
            this.pnlBotonesPortadaBase.Controls.SetChildIndex(this.pnlInfoPortadaBase, 0);
            this.pnlBotonesPortadaBase.Controls.SetChildIndex(this.btnComentarios, 0);
            this.pnlBotonesPortadaBase.Controls.SetChildIndex(this.btnProgramas, 0);
            this.pnlBotonesPortadaBase.Controls.SetChildIndex(this.etInfo, 0);
            // 
            // linkFinSesion
            // 
            this.linkFinSesion.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkFinSesion_LinkClicked);
            // 
            // btnComentarios
            // 
            this.btnComentarios.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnComentarios.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComentarios.Location = new System.Drawing.Point(712, 161);
            this.btnComentarios.Name = "btnComentarios";
            this.btnComentarios.Size = new System.Drawing.Size(95, 95);
            this.btnComentarios.TabIndex = 33;
            this.btnComentarios.Text = "Gestión de Comentarios";
            this.btnComentarios.UseVisualStyleBackColor = true;
            this.btnComentarios.Click += new System.EventHandler(this.btnComentarios_Click);
            // 
            // btnProgramas
            // 
            this.btnProgramas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProgramas.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProgramas.Location = new System.Drawing.Point(592, 161);
            this.btnProgramas.Name = "btnProgramas";
            this.btnProgramas.Size = new System.Drawing.Size(95, 95);
            this.btnProgramas.TabIndex = 32;
            this.btnProgramas.Text = "Gestión de Críticas";
            this.btnProgramas.UseVisualStyleBackColor = true;
            this.btnProgramas.Click += new System.EventHandler(this.btnProgramas_Click);
            // 
            // etInfo
            // 
            this.etInfo.AutoSize = true;
            this.etInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.etInfo.ForeColor = System.Drawing.SystemColors.Info;
            this.etInfo.Location = new System.Drawing.Point(810, 276);
            this.etInfo.Name = "etInfo";
            this.etInfo.Size = new System.Drawing.Size(116, 13);
            this.etInfo.TabIndex = 34;
            this.etInfo.Text = "Seleccione una opción";
            // 
            // FVistaPortadaModerador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1064, 778);
            this.Name = "FVistaPortadaModerador";
            this.Load += new System.EventHandler(this.FVistaPortadaModerador_Load);
            this.pnlBotonesPortadaBase.ResumeLayout(false);
            this.pnlBotonesPortadaBase.PerformLayout();
            this.pnlInfoPortadaBase.ResumeLayout(false);
            this.pnlInfoPortadaBase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgPortadaBaseFoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label etInfo;
        private System.Windows.Forms.Button btnComentarios;
        private System.Windows.Forms.Button btnProgramas;




    }
}
