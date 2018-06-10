namespace TVO_VistaWindows
{
    partial class FVistaSeccionBase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FVistaSeccionBase));
            this.pnlSeccionBase = new System.Windows.Forms.Panel();
            this.tbBusquedaRapida = new System.Windows.Forms.TextBox();
            this.etAccion = new System.Windows.Forms.Label();
            this.mnBase = new System.Windows.Forms.MenuStrip();
            this.itemPortada = new System.Windows.Forms.ToolStripMenuItem();
            this.itemClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.itemCanales = new System.Windows.Forms.ToolStripMenuItem();
            this.itemProgramas = new System.Windows.Forms.ToolStripMenuItem();
            this.itemEmisiones = new System.Windows.Forms.ToolStripMenuItem();
            this.itemIncidencias = new System.Windows.Forms.ToolStripMenuItem();
            this.itemAdministradores = new System.Windows.Forms.ToolStripMenuItem();
            this.itemCriticasModerador = new System.Windows.Forms.ToolStripMenuItem();
            this.itemComentariosModerador = new System.Windows.Forms.ToolStripMenuItem();
            this.itemAyuda = new System.Windows.Forms.ToolStripMenuItem();
            this.itemAcercaDe = new System.Windows.Forms.ToolStripMenuItem();
            this.etSeccion = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.pbFoto = new System.Windows.Forms.PictureBox();
            this.etNombre = new System.Windows.Forms.Label();
            this.imgBusquedaRapida = new System.Windows.Forms.PictureBox();
            this.pnlSecBase = new System.Windows.Forms.Panel();
            this.pestanyasSeccionBase = new System.Windows.Forms.TabControl();
            this.tpSeccionBaseConsultar = new System.Windows.Forms.TabPage();
            this.splitContainerSeccionBase = new System.Windows.Forms.SplitContainer();
            this.tpInsertar = new System.Windows.Forms.TabPage();
            this.pnlSeccionBase.SuspendLayout();
            this.mnBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBusquedaRapida)).BeginInit();
            this.pnlSecBase.SuspendLayout();
            this.pestanyasSeccionBase.SuspendLayout();
            this.tpSeccionBaseConsultar.SuspendLayout();
            this.splitContainerSeccionBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSeccionBase
            // 
            this.pnlSeccionBase.Controls.Add(this.tbBusquedaRapida);
            this.pnlSeccionBase.Controls.Add(this.etAccion);
            this.pnlSeccionBase.Controls.Add(this.mnBase);
            this.pnlSeccionBase.Controls.Add(this.etSeccion);
            this.pnlSeccionBase.Controls.Add(this.dateTimePicker1);
            this.pnlSeccionBase.Controls.Add(this.pbFoto);
            this.pnlSeccionBase.Controls.Add(this.etNombre);
            this.pnlSeccionBase.Controls.Add(this.imgBusquedaRapida);
            this.pnlSeccionBase.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSeccionBase.Location = new System.Drawing.Point(0, 0);
            this.pnlSeccionBase.Name = "pnlSeccionBase";
            this.pnlSeccionBase.Size = new System.Drawing.Size(1061, 150);
            this.pnlSeccionBase.TabIndex = 1;
            // 
            // tbBusquedaRapida
            // 
            this.tbBusquedaRapida.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbBusquedaRapida.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbBusquedaRapida.Location = new System.Drawing.Point(726, 114);
            this.tbBusquedaRapida.Name = "tbBusquedaRapida";
            this.tbBusquedaRapida.Size = new System.Drawing.Size(165, 20);
            this.tbBusquedaRapida.TabIndex = 1;
            this.tbBusquedaRapida.Text = "Búsqueda rápida";
            this.tbBusquedaRapida.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbBusquedaRapida_KeyDown);
            this.tbBusquedaRapida.Leave += new System.EventHandler(this.tbBusquedaRapida_Leave);
            this.tbBusquedaRapida.Enter += new System.EventHandler(this.tbBusquedaRapida_Enter);
            // 
            // etAccion
            // 
            this.etAccion.AutoSize = true;
            this.etAccion.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.etAccion.Location = new System.Drawing.Point(20, 71);
            this.etAccion.Name = "etAccion";
            this.etAccion.Size = new System.Drawing.Size(67, 21);
            this.etAccion.TabIndex = 12;
            this.etAccion.Text = "ACCIÓN";
            // 
            // mnBase
            // 
            this.mnBase.BackColor = System.Drawing.SystemColors.GrayText;
            this.mnBase.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.mnBase.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemPortada,
            this.itemClientes,
            this.itemCanales,
            this.itemProgramas,
            this.itemEmisiones,
            this.itemIncidencias,
            this.itemAdministradores,
            this.itemCriticasModerador,
            this.itemComentariosModerador,
            this.itemAyuda});
            this.mnBase.Location = new System.Drawing.Point(0, 0);
            this.mnBase.Name = "mnBase";
            this.mnBase.Size = new System.Drawing.Size(1061, 24);
            this.mnBase.TabIndex = 8;
            this.mnBase.Text = "Menú Principal";
            // 
            // itemPortada
            // 
            this.itemPortada.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.itemPortada.ForeColor = System.Drawing.SystemColors.Info;
            this.itemPortada.Name = "itemPortada";
            this.itemPortada.Size = new System.Drawing.Size(62, 20);
            this.itemPortada.Text = "Portada";
            this.itemPortada.Click += new System.EventHandler(this.itemPortada_Click);
            // 
            // itemClientes
            // 
            this.itemClientes.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.itemClientes.Name = "itemClientes";
            this.itemClientes.Size = new System.Drawing.Size(61, 20);
            this.itemClientes.Text = "Clientes";
            this.itemClientes.Click += new System.EventHandler(this.itemCliente_Click);
            // 
            // itemCanales
            // 
            this.itemCanales.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.itemCanales.Name = "itemCanales";
            this.itemCanales.Size = new System.Drawing.Size(64, 20);
            this.itemCanales.Text = "Cadenas";
            this.itemCanales.Click += new System.EventHandler(this.itemCanales_Click);
            // 
            // itemProgramas
            // 
            this.itemProgramas.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.itemProgramas.Name = "itemProgramas";
            this.itemProgramas.Size = new System.Drawing.Size(76, 20);
            this.itemProgramas.Text = "Programas";
            this.itemProgramas.Click += new System.EventHandler(this.itemProgramas_Click);
            // 
            // itemEmisiones
            // 
            this.itemEmisiones.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.itemEmisiones.Name = "itemEmisiones";
            this.itemEmisiones.Size = new System.Drawing.Size(72, 20);
            this.itemEmisiones.Text = "Emisiones";
            this.itemEmisiones.Click += new System.EventHandler(this.itemEmisiones_Click);
            // 
            // itemIncidencias
            // 
            this.itemIncidencias.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.itemIncidencias.Name = "itemIncidencias";
            this.itemIncidencias.Size = new System.Drawing.Size(78, 20);
            this.itemIncidencias.Text = "Incidencias";
            this.itemIncidencias.Click += new System.EventHandler(this.itemIncidencias_Click);
            // 
            // itemAdministradores
            // 
            this.itemAdministradores.ForeColor = System.Drawing.Color.IndianRed;
            this.itemAdministradores.Name = "itemAdministradores";
            this.itemAdministradores.Size = new System.Drawing.Size(106, 20);
            this.itemAdministradores.Text = "Administradores";
            this.itemAdministradores.Click += new System.EventHandler(this.itemAdministradores_Click);
            // 
            // itemCriticasModerador
            // 
            this.itemCriticasModerador.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.itemCriticasModerador.Name = "itemCriticasModerador";
            this.itemCriticasModerador.Size = new System.Drawing.Size(58, 20);
            this.itemCriticasModerador.Text = "Críticas";
            this.itemCriticasModerador.Click += new System.EventHandler(this.itemProgramasModerador_Click);
            // 
            // itemComentariosModerador
            // 
            this.itemComentariosModerador.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.itemComentariosModerador.Name = "itemComentariosModerador";
            this.itemComentariosModerador.Size = new System.Drawing.Size(87, 20);
            this.itemComentariosModerador.Text = "Comentarios";
            this.itemComentariosModerador.Click += new System.EventHandler(this.itemComentariosModerador_Click);
            // 
            // itemAyuda
            // 
            this.itemAyuda.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemAcercaDe});
            this.itemAyuda.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.itemAyuda.Name = "itemAyuda";
            this.itemAyuda.Size = new System.Drawing.Size(81, 20);
            this.itemAyuda.Text = "Acerca De...";
            // 
            // itemAcercaDe
            // 
            this.itemAcercaDe.Name = "itemAcercaDe";
            this.itemAcercaDe.Size = new System.Drawing.Size(152, 22);
            this.itemAcercaDe.Text = "TeVeo v1.0";
            this.itemAcercaDe.Click += new System.EventHandler(this.itemAcercaDe_Click);
            // 
            // etSeccion
            // 
            this.etSeccion.AutoSize = true;
            this.etSeccion.Font = new System.Drawing.Font("Segoe UI Light", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.etSeccion.Location = new System.Drawing.Point(12, 85);
            this.etSeccion.Name = "etSeccion";
            this.etSeccion.Size = new System.Drawing.Size(150, 54);
            this.etSeccion.TabIndex = 11;
            this.etSeccion.Text = "Sección";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker1.CalendarMonthBackground = System.Drawing.SystemColors.ActiveCaption;
            this.dateTimePicker1.CalendarTrailingForeColor = System.Drawing.SystemColors.Desktop;
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Location = new System.Drawing.Point(726, 57);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 10;
            // 
            // pbFoto
            // 
            this.pbFoto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbFoto.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pbFoto.ErrorImage")));
            this.pbFoto.Image = global::TVO_VistaWindows.Properties.Resources.user_256;
            this.pbFoto.InitialImage = global::TVO_VistaWindows.Properties.Resources.sinfoto;
            this.pbFoto.Location = new System.Drawing.Point(932, 41);
            this.pbFoto.Name = "pbFoto";
            this.pbFoto.Size = new System.Drawing.Size(85, 93);
            this.pbFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFoto.TabIndex = 9;
            this.pbFoto.TabStop = false;
            // 
            // etNombre
            // 
            this.etNombre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.etNombre.AutoSize = true;
            this.etNombre.Location = new System.Drawing.Point(726, 41);
            this.etNombre.MaximumSize = new System.Drawing.Size(200, 13);
            this.etNombre.MinimumSize = new System.Drawing.Size(200, 13);
            this.etNombre.Name = "etNombre";
            this.etNombre.Size = new System.Drawing.Size(200, 13);
            this.etNombre.TabIndex = 7;
            this.etNombre.Text = "Fulanito Pérez";
            this.etNombre.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // imgBusquedaRapida
            // 
            this.imgBusquedaRapida.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imgBusquedaRapida.Image = ((System.Drawing.Image)(resources.GetObject("imgBusquedaRapida.Image")));
            this.imgBusquedaRapida.InitialImage = ((System.Drawing.Image)(resources.GetObject("imgBusquedaRapida.InitialImage")));
            this.imgBusquedaRapida.Location = new System.Drawing.Point(897, 110);
            this.imgBusquedaRapida.Name = "imgBusquedaRapida";
            this.imgBusquedaRapida.Size = new System.Drawing.Size(29, 24);
            this.imgBusquedaRapida.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgBusquedaRapida.TabIndex = 14;
            this.imgBusquedaRapida.TabStop = false;
            this.imgBusquedaRapida.MouseLeave += new System.EventHandler(this.imgBusquedaRapida_MouseLeave);
            this.imgBusquedaRapida.Click += new System.EventHandler(this.imgBusquedaRapida_Click);
            this.imgBusquedaRapida.MouseHover += new System.EventHandler(this.imgBusquedaRapida_MouseHover);
            this.imgBusquedaRapida.MouseEnter += new System.EventHandler(this.imgBusquedaRapida_MouseEnter);
            // 
            // pnlSecBase
            // 
            this.pnlSecBase.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.pnlSecBase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSecBase.Controls.Add(this.pestanyasSeccionBase);
            this.pnlSecBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSecBase.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlSecBase.Location = new System.Drawing.Point(0, 150);
            this.pnlSecBase.Name = "pnlSecBase";
            this.pnlSecBase.Size = new System.Drawing.Size(1061, 578);
            this.pnlSecBase.TabIndex = 2;
            // 
            // pestanyasSeccionBase
            // 
            this.pestanyasSeccionBase.Controls.Add(this.tpSeccionBaseConsultar);
            this.pestanyasSeccionBase.Controls.Add(this.tpInsertar);
            this.pestanyasSeccionBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pestanyasSeccionBase.Location = new System.Drawing.Point(0, 0);
            this.pestanyasSeccionBase.Name = "pestanyasSeccionBase";
            this.pestanyasSeccionBase.SelectedIndex = 0;
            this.pestanyasSeccionBase.Size = new System.Drawing.Size(1059, 576);
            this.pestanyasSeccionBase.TabIndex = 0;
            this.pestanyasSeccionBase.Click += new System.EventHandler(this.pestanyasSeccionBase_Click);
            // 
            // tpSeccionBaseConsultar
            // 
            this.tpSeccionBaseConsultar.Controls.Add(this.splitContainerSeccionBase);
            this.tpSeccionBaseConsultar.Location = new System.Drawing.Point(4, 22);
            this.tpSeccionBaseConsultar.Name = "tpSeccionBaseConsultar";
            this.tpSeccionBaseConsultar.Padding = new System.Windows.Forms.Padding(3);
            this.tpSeccionBaseConsultar.Size = new System.Drawing.Size(1051, 550);
            this.tpSeccionBaseConsultar.TabIndex = 0;
            this.tpSeccionBaseConsultar.Text = "Consultar";
            this.tpSeccionBaseConsultar.UseVisualStyleBackColor = true;
            // 
            // splitContainerSeccionBase
            // 
            this.splitContainerSeccionBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerSeccionBase.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerSeccionBase.Location = new System.Drawing.Point(3, 3);
            this.splitContainerSeccionBase.Name = "splitContainerSeccionBase";
            // 
            // splitContainerSeccionBase.Panel1
            // 
            this.splitContainerSeccionBase.Panel1.Padding = new System.Windows.Forms.Padding(10);
            // 
            // splitContainerSeccionBase.Panel2
            // 
            this.splitContainerSeccionBase.Panel2.Padding = new System.Windows.Forms.Padding(10, 10, 20, 20);
            this.splitContainerSeccionBase.Size = new System.Drawing.Size(1045, 544);
            this.splitContainerSeccionBase.SplitterDistance = 348;
            this.splitContainerSeccionBase.TabIndex = 0;
            // 
            // tpInsertar
            // 
            this.tpInsertar.Location = new System.Drawing.Point(4, 22);
            this.tpInsertar.Name = "tpInsertar";
            this.tpInsertar.Padding = new System.Windows.Forms.Padding(3);
            this.tpInsertar.Size = new System.Drawing.Size(1051, 550);
            this.tpInsertar.TabIndex = 1;
            this.tpInsertar.Text = "Insertar/Modificar";
            this.tpInsertar.UseVisualStyleBackColor = true;
            // 
            // FVistaSeccionBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1061, 750);
            this.Controls.Add(this.pnlSecBase);
            this.Controls.Add(this.pnlSeccionBase);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "FVistaSeccionBase";
            this.Load += new System.EventHandler(this.FVistaSeccionBase_Load);
            this.Controls.SetChildIndex(this.pnlSeccionBase, 0);
            this.Controls.SetChildIndex(this.pnlSecBase, 0);
            this.pnlSeccionBase.ResumeLayout(false);
            this.pnlSeccionBase.PerformLayout();
            this.mnBase.ResumeLayout(false);
            this.mnBase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBusquedaRapida)).EndInit();
            this.pnlSecBase.ResumeLayout(false);
            this.pestanyasSeccionBase.ResumeLayout(false);
            this.tpSeccionBaseConsultar.ResumeLayout(false);
            this.splitContainerSeccionBase.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox tbBusquedaRapida;
        public System.Windows.Forms.PictureBox imgBusquedaRapida;
        public System.Windows.Forms.ToolStripMenuItem Clientes;
        public System.Windows.Forms.ToolStripMenuItem itemAcercaDe;
        public System.Windows.Forms.MenuStrip mnBase;
        public System.Windows.Forms.Panel pnlSecBase;
        public System.Windows.Forms.TabControl pestanyasSeccionBase;
        public System.Windows.Forms.TabPage tpSeccionBaseConsultar;
        public System.Windows.Forms.TabPage tpInsertar;
        public System.Windows.Forms.ToolStripMenuItem itemClientes;
        public System.Windows.Forms.ToolStripMenuItem itemCanales;
        public System.Windows.Forms.ToolStripMenuItem itemIncidencias;
        public System.Windows.Forms.ToolStripMenuItem itemAdministradores;
        public System.Windows.Forms.ToolStripMenuItem itemEmisiones;
        public System.Windows.Forms.ToolStripMenuItem itemPortada;
        private System.Windows.Forms.ToolStripMenuItem itemCriticasModerador;
        private System.Windows.Forms.ToolStripMenuItem itemComentariosModerador;
        private System.Windows.Forms.ToolStripMenuItem itemProgramas;
        internal System.Windows.Forms.Label etAccion;
        internal System.Windows.Forms.Panel pnlSeccionBase;
        internal System.Windows.Forms.Label etSeccion;
        internal System.Windows.Forms.DateTimePicker dateTimePicker1;
        internal System.Windows.Forms.Label etNombre;
        public System.Windows.Forms.SplitContainer splitContainerSeccionBase;
        internal System.Windows.Forms.PictureBox pbFoto;
        private System.Windows.Forms.ToolStripMenuItem itemAyuda;


    }
}
