namespace TVO_VistaWindows
{
    partial class FVistaPortadaTecnico
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
            this.etInfo = new System.Windows.Forms.Label();
            this.btnCadenas = new System.Windows.Forms.Button();
            this.btnAdmin = new System.Windows.Forms.Button();
            this.btnEmisiones = new System.Windows.Forms.Button();
            this.btnClientes = new System.Windows.Forms.Button();
            this.btnProgramas = new System.Windows.Forms.Button();
            this.btnIncidencias = new System.Windows.Forms.Button();
            this.btnXML = new System.Windows.Forms.Button();
            this.pnlBotonesPortadaBase.SuspendLayout();
            this.pnlInfoPortadaBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgPortadaBaseFoto)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBotonesPortadaBase
            // 
            this.pnlBotonesPortadaBase.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlBotonesPortadaBase.Controls.Add(this.etInfo);
            this.pnlBotonesPortadaBase.Controls.Add(this.btnEmisiones);
            this.pnlBotonesPortadaBase.Controls.Add(this.btnIncidencias);
            this.pnlBotonesPortadaBase.Controls.Add(this.btnProgramas);
            this.pnlBotonesPortadaBase.Controls.Add(this.btnClientes);
            this.pnlBotonesPortadaBase.Controls.Add(this.btnAdmin);
            this.pnlBotonesPortadaBase.Controls.Add(this.btnCadenas);
            this.pnlBotonesPortadaBase.Controls.SetChildIndex(this.btnCadenas, 0);
            this.pnlBotonesPortadaBase.Controls.SetChildIndex(this.btnAdmin, 0);
            this.pnlBotonesPortadaBase.Controls.SetChildIndex(this.btnClientes, 0);
            this.pnlBotonesPortadaBase.Controls.SetChildIndex(this.btnProgramas, 0);
            this.pnlBotonesPortadaBase.Controls.SetChildIndex(this.btnIncidencias, 0);
            this.pnlBotonesPortadaBase.Controls.SetChildIndex(this.btnEmisiones, 0);
            this.pnlBotonesPortadaBase.Controls.SetChildIndex(this.etInfo, 0);
            this.pnlBotonesPortadaBase.Controls.SetChildIndex(this.pnlInfoPortadaBase, 0);
            // 
            // pnlInfoPortadaBase
            // 
            this.pnlInfoPortadaBase.Controls.Add(this.btnXML);
            this.pnlInfoPortadaBase.Controls.SetChildIndex(this.etNombre, 0);
            this.pnlInfoPortadaBase.Controls.SetChildIndex(this.btnXML, 0);
            this.pnlInfoPortadaBase.Controls.SetChildIndex(this.imgPortadaBaseFoto, 0);
            this.pnlInfoPortadaBase.Controls.SetChildIndex(this.dateTimePicker1, 0);
            this.pnlInfoPortadaBase.Controls.SetChildIndex(this.linkFinSesion, 0);
            this.pnlInfoPortadaBase.Controls.SetChildIndex(this.linkCerrarApp, 0);
            this.pnlInfoPortadaBase.Controls.SetChildIndex(this.etBienvenido, 0);
            // 
            // linkFinSesion
            // 
            this.linkFinSesion.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkFinSesion_LinkClicked);
            // 
            // etInfo
            // 
            this.etInfo.AutoSize = true;
            this.etInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.etInfo.ForeColor = System.Drawing.SystemColors.Info;
            this.etInfo.Location = new System.Drawing.Point(802, 281);
            this.etInfo.Name = "etInfo";
            this.etInfo.Size = new System.Drawing.Size(116, 13);
            this.etInfo.TabIndex = 49;
            this.etInfo.Text = "Seleccione una opción";
            // 
            // btnCadenas
            // 
            this.btnCadenas.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadenas.Location = new System.Drawing.Point(815, 154);
            this.btnCadenas.Name = "btnCadenas";
            this.btnCadenas.Size = new System.Drawing.Size(103, 103);
            this.btnCadenas.TabIndex = 46;
            this.btnCadenas.Text = "Gestión de CADENAS de TV";
            this.btnCadenas.UseVisualStyleBackColor = true;
            this.btnCadenas.Click += new System.EventHandler(this.btnCadenas_Click);
            // 
            // btnAdmin
            // 
            this.btnAdmin.BackColor = System.Drawing.Color.Gray;
            this.btnAdmin.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdmin.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAdmin.Location = new System.Drawing.Point(815, 31);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(103, 103);
            this.btnAdmin.TabIndex = 48;
            this.btnAdmin.Text = "Gestión ADMIN";
            this.btnAdmin.UseVisualStyleBackColor = false;
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            // 
            // btnEmisiones
            // 
            this.btnEmisiones.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmisiones.Location = new System.Drawing.Point(694, 154);
            this.btnEmisiones.Name = "btnEmisiones";
            this.btnEmisiones.Size = new System.Drawing.Size(103, 103);
            this.btnEmisiones.TabIndex = 47;
            this.btnEmisiones.Text = "Gestión de EMISIONES";
            this.btnEmisiones.UseVisualStyleBackColor = true;
            this.btnEmisiones.Click += new System.EventHandler(this.btnEmisiones_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClientes.Location = new System.Drawing.Point(572, 31);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(103, 103);
            this.btnClientes.TabIndex = 43;
            this.btnClientes.Text = "Gestión de CLIENTES";
            this.btnClientes.UseVisualStyleBackColor = true;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // btnProgramas
            // 
            this.btnProgramas.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnProgramas.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProgramas.Location = new System.Drawing.Point(572, 154);
            this.btnProgramas.Name = "btnProgramas";
            this.btnProgramas.Size = new System.Drawing.Size(103, 103);
            this.btnProgramas.TabIndex = 44;
            this.btnProgramas.Text = "Gestión de PROGRAMAS";
            this.btnProgramas.UseVisualStyleBackColor = true;
            this.btnProgramas.Click += new System.EventHandler(this.btnProgramas_Click);
            // 
            // btnIncidencias
            // 
            this.btnIncidencias.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIncidencias.Location = new System.Drawing.Point(694, 31);
            this.btnIncidencias.Name = "btnIncidencias";
            this.btnIncidencias.Size = new System.Drawing.Size(103, 103);
            this.btnIncidencias.TabIndex = 45;
            this.btnIncidencias.Text = "Gestión de INCIDENCIAS";
            this.btnIncidencias.UseVisualStyleBackColor = true;
            this.btnIncidencias.Click += new System.EventHandler(this.btnIncidencias_Click);
            // 
            // btnXML
            // 
            this.btnXML.Location = new System.Drawing.Point(424, 227);
            this.btnXML.Name = "btnXML";
            this.btnXML.Size = new System.Drawing.Size(75, 23);
            this.btnXML.TabIndex = 38;
            this.btnXML.Text = "XMLTV";
            this.btnXML.UseVisualStyleBackColor = true;
            this.btnXML.Click += new System.EventHandler(this.btnXML_Click);
            // 
            // FVistaPortadaTecnico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1061, 750);
            this.Name = "FVistaPortadaTecnico";
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
        private System.Windows.Forms.Button btnCadenas;
        private System.Windows.Forms.Button btnAdmin;
        private System.Windows.Forms.Button btnEmisiones;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Button btnProgramas;
        private System.Windows.Forms.Button btnIncidencias;
        private System.Windows.Forms.Button btnXML;
    }
}
