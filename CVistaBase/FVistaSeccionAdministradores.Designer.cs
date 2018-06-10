namespace TVO_VistaWindows
{
    partial class FVistaSeccionAdministradores
    {
        /// <summary>
        /// Variable del diseñador requerida...
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
            this.gbResultados = new System.Windows.Forms.GroupBox();
            this.dgvPersonas = new System.Windows.Forms.DataGridView();
            this.gbConsultas = new System.Windows.Forms.GroupBox();
            this.chkPaginacion = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tbEmailBuscar = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cbPerfilBuscar = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.mtbNIFBuscar = new System.Windows.Forms.MaskedTextBox();
            this.tbNombreBuscar = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbInsertarAdministrador = new System.Windows.Forms.GroupBox();
            this.cbProvincia = new System.Windows.Forms.ComboBox();
            this.mtbCCC = new System.Windows.Forms.MaskedTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.mtbCP = new System.Windows.Forms.MaskedTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbPoblacion = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbApellidos = new System.Windows.Forms.TextBox();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.mtbTelefono = new System.Windows.Forms.MaskedTextBox();
            this.btnFoto = new System.Windows.Forms.Button();
            this.imgFotoINS_MOD = new System.Windows.Forms.PictureBox();
            this.btnInsertar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.tbMail = new System.Windows.Forms.TextBox();
            this.cbAdministrador = new System.Windows.Forms.ComboBox();
            this.tbDireccion = new System.Windows.Forms.TextBox();
            this.tbClave = new System.Windows.Forms.TextBox();
            this.mtbNIF = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gbInfoINS_MOD = new System.Windows.Forms.GroupBox();
            this.llDetalle = new System.Windows.Forms.LinkLabel();
            this.etInfoINS_MOD = new System.Windows.Forms.Label();
            this.gbInfoCON = new System.Windows.Forms.GroupBox();
            this.etInfoCON = new System.Windows.Forms.Label();
            this.gbDetalle = new System.Windows.Forms.GroupBox();
            this.etDetalle = new System.Windows.Forms.Label();
            this.gbPaginacion = new System.Windows.Forms.GroupBox();
            this.etPaginacionInfo = new System.Windows.Forms.Label();
            this.btnPaginaPrimera = new System.Windows.Forms.Button();
            this.btnPaginaAnterior = new System.Windows.Forms.Button();
            this.btnPaginaUltima = new System.Windows.Forms.Button();
            this.btnPaginaSiguiente = new System.Windows.Forms.Button();
            this.etInfoPAG = new System.Windows.Forms.Label();
            this.mtbRegistrosXPagina = new System.Windows.Forms.MaskedTextBox();
            this.label15 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgBusquedaRapida)).BeginInit();
            this.pnlSecBase.SuspendLayout();
            this.pestanyasSeccionBase.SuspendLayout();
            this.tpSeccionBaseConsultar.SuspendLayout();
            this.tpInsertar.SuspendLayout();
            this.splitContainerSeccionBase.Panel1.SuspendLayout();
            this.splitContainerSeccionBase.Panel2.SuspendLayout();
            this.splitContainerSeccionBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TbSeccionBaseErrorProvider)).BeginInit();
            this.gbResultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonas)).BeginInit();
            this.gbConsultas.SuspendLayout();
            this.gbInsertarAdministrador.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgFotoINS_MOD)).BeginInit();
            this.gbInfoINS_MOD.SuspendLayout();
            this.gbInfoCON.SuspendLayout();
            this.gbDetalle.SuspendLayout();
            this.gbPaginacion.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbBusquedaRapida
            // 
            this.tbBusquedaRapida.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            //this.tbBusquedaRapida.Location = new System.Drawing.Point(726, 106);
            this.tbBusquedaRapida.Text = "";
            // 
            // imgBusquedaRapida
            // 
            //this.imgBusquedaRapida.Location = new System.Drawing.Point(897, 106);
            // 
            // tpInsertar
            // 
            this.tpInsertar.Controls.Add(this.gbDetalle);
            this.tpInsertar.Controls.Add(this.gbInfoINS_MOD);
            this.tpInsertar.Controls.Add(this.gbInsertarAdministrador);
            // 
            // splitContainerSeccionBase
            // 
            this.splitContainerSeccionBase.IsSplitterFixed = true;
            // 
            // splitContainerSeccionBase.Panel1
            // 
            this.splitContainerSeccionBase.Panel1.Controls.Add(this.gbInfoCON);
            this.splitContainerSeccionBase.Panel1.Controls.Add(this.gbPaginacion);
            this.splitContainerSeccionBase.Panel1.Controls.Add(this.gbConsultas);
            // 
            // splitContainerSeccionBase.Panel2
            // 
            this.splitContainerSeccionBase.Panel2.Controls.Add(this.gbResultados);
            this.splitContainerSeccionBase.SplitterDistance = 340;
            // 
            // gbResultados
            // 
            this.gbResultados.Controls.Add(this.dgvPersonas);
            this.gbResultados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbResultados.Location = new System.Drawing.Point(10, 10);
            this.gbResultados.Name = "gbResultados";
            this.gbResultados.Padding = new System.Windows.Forms.Padding(10);
            this.gbResultados.Size = new System.Drawing.Size(671, 514);
            this.gbResultados.TabIndex = 20;
            this.gbResultados.TabStop = false;
            this.gbResultados.Text = "Resultados de la búsqueda";
            // 
            // dgvPersonas
            // 
            this.dgvPersonas.AllowUserToAddRows = false;
            this.dgvPersonas.AllowUserToDeleteRows = false;
            this.dgvPersonas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPersonas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPersonas.Location = new System.Drawing.Point(10, 25);
            this.dgvPersonas.Name = "dgvPersonas";
            this.dgvPersonas.ReadOnly = true;
            this.dgvPersonas.Size = new System.Drawing.Size(651, 479);
            this.dgvPersonas.TabIndex = 16;
            this.dgvPersonas.TabStop = false;
            this.dgvPersonas.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvPersonas_CellMouseMove);
            this.dgvPersonas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPersonas_CellClick);
            // 
            // gbConsultas
            // 
            this.gbConsultas.Controls.Add(this.chkPaginacion);
            this.gbConsultas.Controls.Add(this.label14);
            this.gbConsultas.Controls.Add(this.tbEmailBuscar);
            this.gbConsultas.Controls.Add(this.label13);
            this.gbConsultas.Controls.Add(this.cbPerfilBuscar);
            this.gbConsultas.Controls.Add(this.btnBuscar);
            this.gbConsultas.Controls.Add(this.mtbNIFBuscar);
            this.gbConsultas.Controls.Add(this.tbNombreBuscar);
            this.gbConsultas.Controls.Add(this.label2);
            this.gbConsultas.Controls.Add(this.label1);
            this.gbConsultas.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbConsultas.Location = new System.Drawing.Point(10, 10);
            this.gbConsultas.MaximumSize = new System.Drawing.Size(328, 250);
            this.gbConsultas.MinimumSize = new System.Drawing.Size(328, 250);
            this.gbConsultas.Name = "gbConsultas";
            this.gbConsultas.Size = new System.Drawing.Size(328, 250);
            this.gbConsultas.TabIndex = 20;
            this.gbConsultas.TabStop = false;
            this.gbConsultas.Text = "Búsqueda Avanzada";
            // 
            // chkPaginacion
            // 
            this.chkPaginacion.AutoSize = true;
            this.chkPaginacion.Location = new System.Drawing.Point(10, 222);
            this.chkPaginacion.Name = "chkPaginacion";
            this.chkPaginacion.Size = new System.Drawing.Size(122, 17);
            this.chkPaginacion.TabIndex = 9;
            this.chkPaginacion.Text = "Paginar resultados";
            this.chkPaginacion.UseVisualStyleBackColor = true;
            this.chkPaginacion.CheckedChanged += new System.EventHandler(this.chkPaginacion_CheckedChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(17, 85);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 13);
            this.label14.TabIndex = 8;
            this.label14.Text = "eMail";
            // 
            // tbEmailBuscar
            // 
            this.tbEmailBuscar.Location = new System.Drawing.Point(19, 101);
            this.tbEmailBuscar.Name = "tbEmailBuscar";
            this.tbEmailBuscar.Size = new System.Drawing.Size(190, 22);
            this.tbEmailBuscar.TabIndex = 2;
            this.tbEmailBuscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbEmailBuscar_KeyDown);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(16, 141);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(83, 13);
            this.label13.TabIndex = 6;
            this.label13.Text = "Indica el perfil:";
            // 
            // cbPerfilBuscar
            // 
            this.cbPerfilBuscar.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbPerfilBuscar.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbPerfilBuscar.FormattingEnabled = true;
            this.cbPerfilBuscar.Location = new System.Drawing.Point(19, 157);
            this.cbPerfilBuscar.Name = "cbPerfilBuscar";
            this.cbPerfilBuscar.Size = new System.Drawing.Size(121, 21);
            this.cbPerfilBuscar.TabIndex = 3;
            this.cbPerfilBuscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbPerfilBuscar_KeyDown);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(245, 216);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // mtbNIFBuscar
            // 
            this.mtbNIFBuscar.Location = new System.Drawing.Point(20, 48);
            this.mtbNIFBuscar.Name = "mtbNIFBuscar";
            this.mtbNIFBuscar.Size = new System.Drawing.Size(100, 22);
            this.mtbNIFBuscar.TabIndex = 0;
            this.mtbNIFBuscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mtbNIFBuscar_KeyDown);
            // 
            // tbNombreBuscar
            // 
            this.tbNombreBuscar.Location = new System.Drawing.Point(126, 48);
            this.tbNombreBuscar.Name = "tbNombreBuscar";
            this.tbNombreBuscar.Size = new System.Drawing.Size(190, 22);
            this.tbNombreBuscar.TabIndex = 1;
            this.tbNombreBuscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbNombreBuscar_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(124, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre y/o apellidos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "NIF";
            // 
            // gbInsertarAdministrador
            // 
            this.gbInsertarAdministrador.Controls.Add(this.cbProvincia);
            this.gbInsertarAdministrador.Controls.Add(this.mtbCCC);
            this.gbInsertarAdministrador.Controls.Add(this.label12);
            this.gbInsertarAdministrador.Controls.Add(this.label11);
            this.gbInsertarAdministrador.Controls.Add(this.mtbCP);
            this.gbInsertarAdministrador.Controls.Add(this.label10);
            this.gbInsertarAdministrador.Controls.Add(this.tbPoblacion);
            this.gbInsertarAdministrador.Controls.Add(this.label9);
            this.gbInsertarAdministrador.Controls.Add(this.tbApellidos);
            this.gbInsertarAdministrador.Controls.Add(this.tbNombre);
            this.gbInsertarAdministrador.Controls.Add(this.label27);
            this.gbInsertarAdministrador.Controls.Add(this.label28);
            this.gbInsertarAdministrador.Controls.Add(this.mtbTelefono);
            this.gbInsertarAdministrador.Controls.Add(this.btnFoto);
            this.gbInsertarAdministrador.Controls.Add(this.imgFotoINS_MOD);
            this.gbInsertarAdministrador.Controls.Add(this.btnInsertar);
            this.gbInsertarAdministrador.Controls.Add(this.btnLimpiar);
            this.gbInsertarAdministrador.Controls.Add(this.tbMail);
            this.gbInsertarAdministrador.Controls.Add(this.cbAdministrador);
            this.gbInsertarAdministrador.Controls.Add(this.tbDireccion);
            this.gbInsertarAdministrador.Controls.Add(this.tbClave);
            this.gbInsertarAdministrador.Controls.Add(this.mtbNIF);
            this.gbInsertarAdministrador.Controls.Add(this.label8);
            this.gbInsertarAdministrador.Controls.Add(this.label7);
            this.gbInsertarAdministrador.Controls.Add(this.label6);
            this.gbInsertarAdministrador.Controls.Add(this.label5);
            this.gbInsertarAdministrador.Controls.Add(this.label4);
            this.gbInsertarAdministrador.Controls.Add(this.label3);
            this.gbInsertarAdministrador.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbInsertarAdministrador.Location = new System.Drawing.Point(3, 3);
            this.gbInsertarAdministrador.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.gbInsertarAdministrador.Name = "gbInsertarAdministrador";
            this.gbInsertarAdministrador.Size = new System.Drawing.Size(550, 544);
            this.gbInsertarAdministrador.TabIndex = 0;
            this.gbInsertarAdministrador.TabStop = false;
            this.gbInsertarAdministrador.Text = "Nuevo administrador";
            // 
            // cbProvincia
            // 
            this.cbProvincia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbProvincia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbProvincia.FormattingEnabled = true;
            this.cbProvincia.Location = new System.Drawing.Point(163, 225);
            this.cbProvincia.Name = "cbProvincia";
            this.cbProvincia.Size = new System.Drawing.Size(200, 21);
            this.cbProvincia.TabIndex = 63;
            // 
            // mtbCCC
            // 
            this.mtbCCC.Location = new System.Drawing.Point(163, 309);
            this.mtbCCC.Mask = "00000000000000000000";
            this.mtbCCC.Name = "mtbCCC";
            this.mtbCCC.Size = new System.Drawing.Size(300, 22);
            this.mtbCCC.TabIndex = 10;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(119, 313);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(28, 13);
            this.label12.TabIndex = 62;
            this.label12.Text = "CCC";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(97, 229);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 13);
            this.label11.TabIndex = 61;
            this.label11.Text = "Provincia";
            // 
            // mtbCP
            // 
            this.mtbCP.Location = new System.Drawing.Point(163, 197);
            this.mtbCP.Mask = "00000";
            this.mtbCP.Name = "mtbCP";
            this.mtbCP.Size = new System.Drawing.Size(40, 22);
            this.mtbCP.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(79, 201);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 13);
            this.label10.TabIndex = 58;
            this.label10.Text = "Código Postal";
            // 
            // tbPoblacion
            // 
            this.tbPoblacion.Location = new System.Drawing.Point(163, 169);
            this.tbPoblacion.MaxLength = 50;
            this.tbPoblacion.Name = "tbPoblacion";
            this.tbPoblacion.Size = new System.Drawing.Size(197, 22);
            this.tbPoblacion.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(97, 173);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 57;
            this.label9.Text = "Población";
            // 
            // tbApellidos
            // 
            this.tbApellidos.Location = new System.Drawing.Point(163, 111);
            this.tbApellidos.MaxLength = 50;
            this.tbApellidos.Name = "tbApellidos";
            this.tbApellidos.Size = new System.Drawing.Size(197, 22);
            this.tbApellidos.TabIndex = 3;
            // 
            // tbNombre
            // 
            this.tbNombre.Location = new System.Drawing.Point(163, 83);
            this.tbNombre.MaxLength = 32;
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.Size = new System.Drawing.Size(100, 22);
            this.tbNombre.TabIndex = 2;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(97, 115);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(55, 13);
            this.label27.TabIndex = 55;
            this.label27.Text = "Apellidos";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(103, 88);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(48, 13);
            this.label28.TabIndex = 54;
            this.label28.Text = "Nombre";
            // 
            // mtbTelefono
            // 
            this.mtbTelefono.Location = new System.Drawing.Point(163, 281);
            this.mtbTelefono.Mask = "99000000000";
            this.mtbTelefono.Name = "mtbTelefono";
            this.mtbTelefono.Size = new System.Drawing.Size(100, 22);
            this.mtbTelefono.TabIndex = 9;
            // 
            // btnFoto
            // 
            this.btnFoto.Location = new System.Drawing.Point(394, 107);
            this.btnFoto.Name = "btnFoto";
            this.btnFoto.Size = new System.Drawing.Size(70, 23);
            this.btnFoto.TabIndex = 12;
            this.btnFoto.Text = "Subir foto";
            this.btnFoto.UseVisualStyleBackColor = true;
            this.btnFoto.Click += new System.EventHandler(this.btnFoto_Click);
            // 
            // imgFotoINS_MOD
            // 
            this.imgFotoINS_MOD.Image = global::TVO_VistaWindows.Properties.Resources.user_256;
            this.imgFotoINS_MOD.Location = new System.Drawing.Point(394, 20);
            this.imgFotoINS_MOD.Name = "imgFotoINS_MOD";
            this.imgFotoINS_MOD.Size = new System.Drawing.Size(70, 81);
            this.imgFotoINS_MOD.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgFotoINS_MOD.TabIndex = 14;
            this.imgFotoINS_MOD.TabStop = false;
            // 
            // btnInsertar
            // 
            this.btnInsertar.Location = new System.Drawing.Point(451, 357);
            this.btnInsertar.Name = "btnInsertar";
            this.btnInsertar.Size = new System.Drawing.Size(75, 23);
            this.btnInsertar.TabIndex = 13;
            this.btnInsertar.Text = "Insertar";
            this.btnInsertar.UseVisualStyleBackColor = true;
            this.btnInsertar.Click += new System.EventHandler(this.btnInsertar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(370, 357);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 14;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // tbMail
            // 
            this.tbMail.Location = new System.Drawing.Point(163, 253);
            this.tbMail.Name = "tbMail";
            this.tbMail.Size = new System.Drawing.Size(250, 22);
            this.tbMail.TabIndex = 8;
            this.tbMail.Leave += new System.EventHandler(this.tbMail_Leave);
            // 
            // cbAdministrador
            // 
            this.cbAdministrador.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbAdministrador.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbAdministrador.FormattingEnabled = true;
            this.cbAdministrador.Location = new System.Drawing.Point(163, 347);
            this.cbAdministrador.Name = "cbAdministrador";
            this.cbAdministrador.Size = new System.Drawing.Size(121, 21);
            this.cbAdministrador.TabIndex = 11;
            this.cbAdministrador.Text = "Seleccione tipo...";
            // 
            // tbDireccion
            // 
            this.tbDireccion.Location = new System.Drawing.Point(163, 139);
            this.tbDireccion.Name = "tbDireccion";
            this.tbDireccion.Size = new System.Drawing.Size(305, 22);
            this.tbDireccion.TabIndex = 4;
            // 
            // tbClave
            // 
            this.tbClave.Location = new System.Drawing.Point(163, 57);
            this.tbClave.Name = "tbClave";
            this.tbClave.Size = new System.Drawing.Size(100, 22);
            this.tbClave.TabIndex = 1;
            this.tbClave.Leave += new System.EventHandler(this.tbClave_Leave);
            // 
            // mtbNIF
            // 
            this.mtbNIF.Location = new System.Drawing.Point(163, 29);
            this.mtbNIF.Mask = "00000000a";
            this.mtbNIF.Name = "mtbNIF";
            this.mtbNIF.Size = new System.Drawing.Size(100, 22);
            this.mtbNIF.TabIndex = 0;
            this.mtbNIF.Leave += new System.EventHandler(this.mtbNIF_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(129, 350);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Tipo";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(103, 142);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Dirección";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(120, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Clave";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(101, 285);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Telefono";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(118, 258);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "eMail";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(126, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "NIF";
            // 
            // gbInfoINS_MOD
            // 
            this.gbInfoINS_MOD.Controls.Add(this.llDetalle);
            this.gbInfoINS_MOD.Controls.Add(this.etInfoINS_MOD);
            this.gbInfoINS_MOD.Location = new System.Drawing.Point(561, 4);
            this.gbInfoINS_MOD.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.gbInfoINS_MOD.Name = "gbInfoINS_MOD";
            this.gbInfoINS_MOD.Size = new System.Drawing.Size(450, 150);
            this.gbInfoINS_MOD.TabIndex = 1;
            this.gbInfoINS_MOD.TabStop = false;
            this.gbInfoINS_MOD.Text = "Mensajes del sistema";
            // 
            // llDetalle
            // 
            this.llDetalle.AutoSize = true;
            this.llDetalle.Location = new System.Drawing.Point(15, 126);
            this.llDetalle.Name = "llDetalle";
            this.llDetalle.Size = new System.Drawing.Size(63, 13);
            this.llDetalle.TabIndex = 1;
            this.llDetalle.TabStop = true;
            this.llDetalle.Text = "Ver Detalle";
            this.llDetalle.Visible = false;
            // 
            // etInfoINS_MOD
            // 
            this.etInfoINS_MOD.AutoSize = true;
            this.etInfoINS_MOD.Location = new System.Drawing.Point(15, 26);
            this.etInfoINS_MOD.MaximumSize = new System.Drawing.Size(400, 100);
            this.etInfoINS_MOD.MinimumSize = new System.Drawing.Size(400, 60);
            this.etInfoINS_MOD.Name = "etInfoINS_MOD";
            this.etInfoINS_MOD.Size = new System.Drawing.Size(400, 60);
            this.etInfoINS_MOD.TabIndex = 0;
            this.etInfoINS_MOD.Text = "Sistema";
            // 
            // gbInfoCON
            // 
            this.gbInfoCON.Controls.Add(this.etInfoCON);
            this.gbInfoCON.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbInfoCON.Location = new System.Drawing.Point(10, 360);
            this.gbInfoCON.MaximumSize = new System.Drawing.Size(328, 50);
            this.gbInfoCON.MinimumSize = new System.Drawing.Size(328, 100);
            this.gbInfoCON.Name = "gbInfoCON";
            this.gbInfoCON.Size = new System.Drawing.Size(328, 100);
            this.gbInfoCON.TabIndex = 21;
            this.gbInfoCON.TabStop = false;
            this.gbInfoCON.Text = "Mensaje del sistema";
            // 
            // etInfoCON
            // 
            this.etInfoCON.AutoSize = true;
            this.etInfoCON.Location = new System.Drawing.Point(15, 26);
            this.etInfoCON.MaximumSize = new System.Drawing.Size(300, 60);
            this.etInfoCON.MinimumSize = new System.Drawing.Size(300, 60);
            this.etInfoCON.Name = "etInfoCON";
            this.etInfoCON.Size = new System.Drawing.Size(300, 60);
            this.etInfoCON.TabIndex = 0;
            this.etInfoCON.Text = "label13";
            // 
            // gbDetalle
            // 
            this.gbDetalle.Controls.Add(this.etDetalle);
            this.gbDetalle.Location = new System.Drawing.Point(565, 167);
            this.gbDetalle.Name = "gbDetalle";
            this.gbDetalle.Size = new System.Drawing.Size(445, 149);
            this.gbDetalle.TabIndex = 2;
            this.gbDetalle.TabStop = false;
            this.gbDetalle.Text = "Detalle";
            this.gbDetalle.Visible = false;
            // 
            // etDetalle
            // 
            this.etDetalle.AutoSize = true;
            this.etDetalle.Location = new System.Drawing.Point(11, 23);
            this.etDetalle.MaximumSize = new System.Drawing.Size(400, 100);
            this.etDetalle.MinimumSize = new System.Drawing.Size(400, 60);
            this.etDetalle.Name = "etDetalle";
            this.etDetalle.Size = new System.Drawing.Size(400, 60);
            this.etDetalle.TabIndex = 1;
            this.etDetalle.Text = "Sistema";
            // 
            // gbPaginacion
            // 
            this.gbPaginacion.Controls.Add(this.etPaginacionInfo);
            this.gbPaginacion.Controls.Add(this.btnPaginaPrimera);
            this.gbPaginacion.Controls.Add(this.btnPaginaAnterior);
            this.gbPaginacion.Controls.Add(this.btnPaginaUltima);
            this.gbPaginacion.Controls.Add(this.btnPaginaSiguiente);
            this.gbPaginacion.Controls.Add(this.etInfoPAG);
            this.gbPaginacion.Controls.Add(this.mtbRegistrosXPagina);
            this.gbPaginacion.Controls.Add(this.label15);
            this.gbPaginacion.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbPaginacion.Location = new System.Drawing.Point(10, 260);
            this.gbPaginacion.MaximumSize = new System.Drawing.Size(328, 50);
            this.gbPaginacion.MinimumSize = new System.Drawing.Size(328, 100);
            this.gbPaginacion.Name = "gbPaginacion";
            this.gbPaginacion.Size = new System.Drawing.Size(328, 100);
            this.gbPaginacion.TabIndex = 22;
            this.gbPaginacion.TabStop = false;
            this.gbPaginacion.Text = "Paginación";
            this.gbPaginacion.Visible = false;
            // 
            // etPaginacionInfo
            // 
            this.etPaginacionInfo.AutoSize = true;
            this.etPaginacionInfo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.etPaginacionInfo.Location = new System.Drawing.Point(10, 47);
            this.etPaginacionInfo.MaximumSize = new System.Drawing.Size(150, 30);
            this.etPaginacionInfo.MinimumSize = new System.Drawing.Size(30, 30);
            this.etPaginacionInfo.Name = "etPaginacionInfo";
            this.etPaginacionInfo.Size = new System.Drawing.Size(136, 30);
            this.etPaginacionInfo.TabIndex = 7;
            this.etPaginacionInfo.Text = "Pulse \'Enter\' para aplicar cambios";
            this.etPaginacionInfo.Visible = false;
            // 
            // btnPaginaPrimera
            // 
            this.btnPaginaPrimera.BackColor = System.Drawing.Color.LightGray;
            this.btnPaginaPrimera.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPaginaPrimera.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPaginaPrimera.Location = new System.Drawing.Point(175, 67);
            this.btnPaginaPrimera.Name = "btnPaginaPrimera";
            this.btnPaginaPrimera.Size = new System.Drawing.Size(30, 25);
            this.btnPaginaPrimera.TabIndex = 6;
            this.btnPaginaPrimera.Text = "|<";
            this.btnPaginaPrimera.UseVisualStyleBackColor = false;
            this.btnPaginaPrimera.Click += new System.EventHandler(this.btnPaginaPrimera_Click);
            // 
            // btnPaginaAnterior
            // 
            this.btnPaginaAnterior.BackColor = System.Drawing.Color.LightGray;
            this.btnPaginaAnterior.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPaginaAnterior.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPaginaAnterior.Location = new System.Drawing.Point(211, 67);
            this.btnPaginaAnterior.Name = "btnPaginaAnterior";
            this.btnPaginaAnterior.Size = new System.Drawing.Size(30, 25);
            this.btnPaginaAnterior.TabIndex = 5;
            this.btnPaginaAnterior.Text = "<";
            this.btnPaginaAnterior.UseVisualStyleBackColor = false;
            this.btnPaginaAnterior.Click += new System.EventHandler(this.btnPaginaAnterior_Click);
            // 
            // btnPaginaUltima
            // 
            this.btnPaginaUltima.BackColor = System.Drawing.Color.LightGray;
            this.btnPaginaUltima.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPaginaUltima.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPaginaUltima.Location = new System.Drawing.Point(292, 67);
            this.btnPaginaUltima.Name = "btnPaginaUltima";
            this.btnPaginaUltima.Size = new System.Drawing.Size(30, 25);
            this.btnPaginaUltima.TabIndex = 4;
            this.btnPaginaUltima.Text = ">|";
            this.btnPaginaUltima.UseVisualStyleBackColor = false;
            this.btnPaginaUltima.Click += new System.EventHandler(this.btnPaginaUltima_Click);
            // 
            // btnPaginaSiguiente
            // 
            this.btnPaginaSiguiente.BackColor = System.Drawing.Color.LightGray;
            this.btnPaginaSiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPaginaSiguiente.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPaginaSiguiente.Location = new System.Drawing.Point(256, 67);
            this.btnPaginaSiguiente.Name = "btnPaginaSiguiente";
            this.btnPaginaSiguiente.Size = new System.Drawing.Size(30, 25);
            this.btnPaginaSiguiente.TabIndex = 3;
            this.btnPaginaSiguiente.Text = ">";
            this.btnPaginaSiguiente.UseVisualStyleBackColor = false;
            this.btnPaginaSiguiente.Click += new System.EventHandler(this.btnPaginaSiguiente_Click);
            // 
            // etInfoPAG
            // 
            this.etInfoPAG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.etInfoPAG.AutoSize = true;
            this.etInfoPAG.Location = new System.Drawing.Point(158, 48);
            this.etInfoPAG.MinimumSize = new System.Drawing.Size(165, 0);
            this.etInfoPAG.Name = "etInfoPAG";
            this.etInfoPAG.Size = new System.Drawing.Size(165, 13);
            this.etInfoPAG.TabIndex = 2;
            this.etInfoPAG.Text = "Página 1000 de 7555";
            this.etInfoPAG.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // mtbRegistrosXPagina
            // 
            this.mtbRegistrosXPagina.Location = new System.Drawing.Point(10, 21);
            this.mtbRegistrosXPagina.Mask = "09";
            this.mtbRegistrosXPagina.Name = "mtbRegistrosXPagina";
            this.mtbRegistrosXPagina.Size = new System.Drawing.Size(25, 22);
            this.mtbRegistrosXPagina.TabIndex = 1;
            this.mtbRegistrosXPagina.Text = "10";
            this.mtbRegistrosXPagina.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtbRegistrosXPagina.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mtbRegistrosXPagina_KeyDown);
            this.mtbRegistrosXPagina.Leave += new System.EventHandler(this.mtbRegistrosXPagina_Leave);
            this.mtbRegistrosXPagina.Enter += new System.EventHandler(this.mtbRegistrosXPagina_Enter);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(40, 25);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(136, 13);
            this.label15.TabIndex = 0;
            this.label15.Text = "Filas por página (mín. 10)";
            // 
            // FVistaSeccionAdministradores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1061, 750);
            this.Name = "FVistaSeccionAdministradores";
            this.Load += new System.EventHandler(this.FVistaSeccionAdministradores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgBusquedaRapida)).EndInit();
            this.pnlSecBase.ResumeLayout(false);
            this.pestanyasSeccionBase.ResumeLayout(false);
            this.tpSeccionBaseConsultar.ResumeLayout(false);
            this.tpInsertar.ResumeLayout(false);
            this.splitContainerSeccionBase.Panel1.ResumeLayout(false);
            this.splitContainerSeccionBase.Panel2.ResumeLayout(false);
            this.splitContainerSeccionBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TbSeccionBaseErrorProvider)).EndInit();
            this.gbResultados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonas)).EndInit();
            this.gbConsultas.ResumeLayout(false);
            this.gbConsultas.PerformLayout();
            this.gbInsertarAdministrador.ResumeLayout(false);
            this.gbInsertarAdministrador.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgFotoINS_MOD)).EndInit();
            this.gbInfoINS_MOD.ResumeLayout(false);
            this.gbInfoINS_MOD.PerformLayout();
            this.gbInfoCON.ResumeLayout(false);
            this.gbInfoCON.PerformLayout();
            this.gbDetalle.ResumeLayout(false);
            this.gbDetalle.PerformLayout();
            this.gbPaginacion.ResumeLayout(false);
            this.gbPaginacion.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbConsultas;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.MaskedTextBox mtbNIFBuscar;
        private System.Windows.Forms.TextBox tbNombreBuscar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.GroupBox gbResultados;
        private System.Windows.Forms.DataGridView dgvPersonas;
        private System.Windows.Forms.GroupBox gbInsertarAdministrador;
        private System.Windows.Forms.ComboBox cbAdministrador;
        private System.Windows.Forms.TextBox tbDireccion;
        private System.Windows.Forms.TextBox tbClave;
        private System.Windows.Forms.MaskedTextBox mtbNIF;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnInsertar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.TextBox tbMail;
        private System.Windows.Forms.Button btnFoto;
        private System.Windows.Forms.PictureBox imgFotoINS_MOD;
        private System.Windows.Forms.MaskedTextBox mtbTelefono;
        private System.Windows.Forms.TextBox tbApellidos;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox tbPoblacion;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.MaskedTextBox mtbCP;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.MaskedTextBox mtbCCC;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox gbInfoINS_MOD;
        private System.Windows.Forms.Label etInfoINS_MOD;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cbPerfilBuscar;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tbEmailBuscar;
        private System.Windows.Forms.GroupBox gbInfoCON;
        private System.Windows.Forms.Label etInfoCON;
        private System.Windows.Forms.GroupBox gbDetalle;
        private System.Windows.Forms.Label etDetalle;
        private System.Windows.Forms.LinkLabel llDetalle;
        private System.Windows.Forms.ComboBox cbProvincia;
        private System.Windows.Forms.GroupBox gbPaginacion;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.MaskedTextBox mtbRegistrosXPagina;
        private System.Windows.Forms.CheckBox chkPaginacion;
        private System.Windows.Forms.Label etInfoPAG;
        private System.Windows.Forms.Button btnPaginaPrimera;
        private System.Windows.Forms.Button btnPaginaAnterior;
        private System.Windows.Forms.Button btnPaginaUltima;
        private System.Windows.Forms.Button btnPaginaSiguiente;
        private System.Windows.Forms.Label etPaginacionInfo;



    }
}
