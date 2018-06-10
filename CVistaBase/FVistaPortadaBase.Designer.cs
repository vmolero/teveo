namespace TVO_VistaWindows
{
    partial class FVistaPortadaBase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FVistaPortadaBase));
            this.pnlBotonesPortadaBase = new System.Windows.Forms.Panel();
            this.pnlInfoPortadaBase = new System.Windows.Forms.Panel();
            this.etBienvenido = new System.Windows.Forms.Label();
            this.etNombre = new System.Windows.Forms.Label();
            this.linkCerrarApp = new System.Windows.Forms.LinkLabel();
            this.linkFinSesion = new System.Windows.Forms.LinkLabel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.imgPortadaBaseFoto = new System.Windows.Forms.PictureBox();
            this.pnlBotonesPortadaBase.SuspendLayout();
            this.pnlInfoPortadaBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgPortadaBaseFoto)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBotonesPortadaBase
            // 
            this.pnlBotonesPortadaBase.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pnlBotonesPortadaBase.Controls.Add(this.pnlInfoPortadaBase);
            this.pnlBotonesPortadaBase.Location = new System.Drawing.Point(0, 70);
            this.pnlBotonesPortadaBase.Name = "pnlBotonesPortadaBase";
            this.pnlBotonesPortadaBase.Size = new System.Drawing.Size(958, 311);
            this.pnlBotonesPortadaBase.TabIndex = 32;
            // 
            // pnlInfoPortadaBase
            // 
            this.pnlInfoPortadaBase.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnlInfoPortadaBase.Controls.Add(this.etBienvenido);
            this.pnlInfoPortadaBase.Controls.Add(this.etNombre);
            this.pnlInfoPortadaBase.Controls.Add(this.linkCerrarApp);
            this.pnlInfoPortadaBase.Controls.Add(this.linkFinSesion);
            this.pnlInfoPortadaBase.Controls.Add(this.dateTimePicker1);
            this.pnlInfoPortadaBase.Controls.Add(this.imgPortadaBaseFoto);
            this.pnlInfoPortadaBase.Location = new System.Drawing.Point(20, 26);
            this.pnlInfoPortadaBase.Margin = new System.Windows.Forms.Padding(100, 3, 3, 3);
            this.pnlInfoPortadaBase.Name = "pnlInfoPortadaBase";
            this.pnlInfoPortadaBase.Size = new System.Drawing.Size(513, 263);
            this.pnlInfoPortadaBase.TabIndex = 30;
            // 
            // etBienvenido
            // 
            this.etBienvenido.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.etBienvenido.AutoSize = true;
            this.etBienvenido.Font = new System.Drawing.Font("Segoe UI Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.etBienvenido.Location = new System.Drawing.Point(170, 55);
            this.etBienvenido.Name = "etBienvenido";
            this.etBienvenido.Size = new System.Drawing.Size(110, 30);
            this.etBienvenido.TabIndex = 37;
            this.etBienvenido.Text = "Bienvenido";
            // 
            // etNombre
            // 
            this.etNombre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.etNombre.AutoSize = true;
            this.etNombre.Font = new System.Drawing.Font("Segoe UI Semibold", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.etNombre.Location = new System.Drawing.Point(167, 85);
            this.etNombre.MaximumSize = new System.Drawing.Size(330, 160);
            this.etNombre.MinimumSize = new System.Drawing.Size(330, 160);
            this.etNombre.Name = "etNombre";
            this.etNombre.Size = new System.Drawing.Size(330, 160);
            this.etNombre.TabIndex = 36;
            this.etNombre.Text = "Fulanito Pérez";
            // 
            // linkCerrarApp
            // 
            this.linkCerrarApp.AutoSize = true;
            this.linkCerrarApp.Location = new System.Drawing.Point(75, 218);
            this.linkCerrarApp.Name = "linkCerrarApp";
            this.linkCerrarApp.Size = new System.Drawing.Size(86, 13);
            this.linkCerrarApp.TabIndex = 35;
            this.linkCerrarApp.TabStop = true;
            this.linkCerrarApp.Text = "Cerrar aplicación";
            this.linkCerrarApp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkCerrarApp_LinkClicked);
            // 
            // linkFinSesion
            // 
            this.linkFinSesion.AutoSize = true;
            this.linkFinSesion.Location = new System.Drawing.Point(83, 196);
            this.linkFinSesion.Name = "linkFinSesion";
            this.linkFinSesion.Size = new System.Drawing.Size(78, 13);
            this.linkFinSesion.TabIndex = 34;
            this.linkFinSesion.TabStop = true;
            this.linkFinSesion.Text = "Finalizar sesión";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker1.CalendarMonthBackground = System.Drawing.SystemColors.ActiveCaption;
            this.dateTimePicker1.CalendarTrailingForeColor = System.Drawing.SystemColors.Desktop;
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Location = new System.Drawing.Point(167, 15);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 20;
            // 
            // imgPortadaBaseFoto
            // 
            this.imgPortadaBaseFoto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imgPortadaBaseFoto.ErrorImage = ((System.Drawing.Image)(resources.GetObject("imgPortadaBaseFoto.ErrorImage")));
            this.imgPortadaBaseFoto.Image = global::TVO_VistaWindows.Properties.Resources.user_256;
            this.imgPortadaBaseFoto.InitialImage = global::TVO_VistaWindows.Properties.Resources.sinfoto;
            this.imgPortadaBaseFoto.Location = new System.Drawing.Point(14, 15);
            this.imgPortadaBaseFoto.Name = "imgPortadaBaseFoto";
            this.imgPortadaBaseFoto.Size = new System.Drawing.Size(147, 171);
            this.imgPortadaBaseFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgPortadaBaseFoto.TabIndex = 19;
            this.imgPortadaBaseFoto.TabStop = false;
            // 
            // FVistaPortadaBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.pnlBotonesPortadaBase);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FVistaPortadaBase";
            this.Load += new System.EventHandler(this.FVistaPortadaBase_Load);
            this.Controls.SetChildIndex(this.pnlBotonesPortadaBase, 0);
            this.pnlBotonesPortadaBase.ResumeLayout(false);
            this.pnlInfoPortadaBase.ResumeLayout(false);
            this.pnlInfoPortadaBase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgPortadaBaseFoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Panel pnlBotonesPortadaBase;
        public System.Windows.Forms.Panel pnlInfoPortadaBase;
        public System.Windows.Forms.Label etNombre;
        public System.Windows.Forms.LinkLabel linkCerrarApp;
        public System.Windows.Forms.LinkLabel linkFinSesion;
        public System.Windows.Forms.PictureBox imgPortadaBaseFoto;
        public System.Windows.Forms.DateTimePicker dateTimePicker1;
        public System.Windows.Forms.Label etBienvenido;

    }
}
