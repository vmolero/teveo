namespace TVO_VistaWindows
{
    partial class FVistaSeccionCriticasModerador
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
            this.btnBuscar = new System.Windows.Forms.Button();
            this.etCadena = new System.Windows.Forms.Label();
            this.dgvCriticas = new System.Windows.Forms.DataGridView();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.bValidarTemp = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.eCritica = new System.Windows.Forms.RichTextBox();
            this.sCanal = new System.Windows.Forms.Label();
            this.sPrograma = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbFechas = new System.Windows.Forms.GroupBox();
            this.eFFin = new System.Windows.Forms.DateTimePicker();
            this.labelFecha = new System.Windows.Forms.Label();
            this.eFInicio = new System.Windows.Forms.DateTimePicker();
            this.label24 = new System.Windows.Forms.Label();
            this.cbFechas = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rbTodos = new System.Windows.Forms.RadioButton();
            this.rbConCritica = new System.Windows.Forms.RadioButton();
            this.rbSinCritica = new System.Windows.Forms.RadioButton();
            this.tbPrograma = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbCadena = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gbPendientes = new System.Windows.Forms.GroupBox();
            this.bMostrarPendientes = new System.Windows.Forms.Button();
            this.bCancelarPendientes2 = new System.Windows.Forms.Button();
            this.bGuardarPendientes2 = new System.Windows.Forms.Button();
            this.sPendientes = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.bCancelarPendientes = new System.Windows.Forms.Button();
            this.bGuardarPendientes = new System.Windows.Forms.Button();
            this.bValidar = new System.Windows.Forms.Button();
            this.sAutor = new System.Windows.Forms.Label();
            this.sFecha = new System.Windows.Forms.Label();
            this.gbPaginacion = new System.Windows.Forms.GroupBox();
            this.etPaginacionInfo = new System.Windows.Forms.Label();
            this.btnPaginaPrimera = new System.Windows.Forms.Button();
            this.btnPaginaAnterior = new System.Windows.Forms.Button();
            this.btnPaginaUltima = new System.Windows.Forms.Button();
            this.btnPaginaSiguiente = new System.Windows.Forms.Button();
            this.etInfoPAG = new System.Windows.Forms.Label();
            this.mtbRegistrosXPagina = new System.Windows.Forms.MaskedTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.gbInfoCON = new System.Windows.Forms.GroupBox();
            this.etInfoCON = new System.Windows.Forms.Label();
            this.gbInfoINS_MOD = new System.Windows.Forms.GroupBox();
            this.etInfoINS_MOD = new System.Windows.Forms.Label();
            this.sDescripcion = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgBusquedaRapida)).BeginInit();
            this.pnlSecBase.SuspendLayout();
            this.pestanyasSeccionBase.SuspendLayout();
            this.tpSeccionBaseConsultar.SuspendLayout();
            this.tpInsertar.SuspendLayout();
            this.splitContainerSeccionBase.Panel1.SuspendLayout();
            this.splitContainerSeccionBase.Panel2.SuspendLayout();
            this.splitContainerSeccionBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TbSeccionBaseErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCriticas)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gbFechas.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbPendientes.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gbPaginacion.SuspendLayout();
            this.gbInfoCON.SuspendLayout();
            this.gbInfoINS_MOD.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbBusquedaRapida
            // 
            this.tbBusquedaRapida.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic);
            this.tbBusquedaRapida.Text = "";
            // 
            // imgBusquedaRapida
            // 
            this.imgBusquedaRapida.Click += new System.EventHandler(this.imgBusquedaRapida_Click_1);
            // 
            // pestanyasSeccionBase
            // 
            this.pestanyasSeccionBase.Layout += new System.Windows.Forms.LayoutEventHandler(this.pestanyasSeccionBase_Layout);
            // 
            // tpInsertar
            // 
            this.tpInsertar.Controls.Add(this.gbInfoINS_MOD);
            this.tpInsertar.Controls.Add(this.groupBox3);
            // 
            // splitContainerSeccionBase
            // 
            // 
            // splitContainerSeccionBase.Panel1
            // 
            this.splitContainerSeccionBase.Panel1.Controls.Add(this.gbInfoCON);
            this.splitContainerSeccionBase.Panel1.Controls.Add(this.gbPaginacion);
            this.splitContainerSeccionBase.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainerSeccionBase.Panel2
            // 
            this.splitContainerSeccionBase.Panel2.Controls.Add(this.groupBox2);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(256, 271);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(65, 23);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // etCadena
            // 
            this.etCadena.AutoSize = true;
            this.etCadena.Location = new System.Drawing.Point(18, 53);
            this.etCadena.Name = "etCadena";
            this.etCadena.Size = new System.Drawing.Size(46, 13);
            this.etCadena.TabIndex = 2;
            this.etCadena.Text = "Cadena";
            // 
            // dgvCriticas
            // 
            this.dgvCriticas.AllowUserToAddRows = false;
            this.dgvCriticas.AllowUserToDeleteRows = false;
            this.dgvCriticas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCriticas.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvCriticas.Location = new System.Drawing.Point(10, 25);
            this.dgvCriticas.Name = "dgvCriticas";
            this.dgvCriticas.ReadOnly = true;
            this.dgvCriticas.RowTemplate.Height = 25;
            this.dgvCriticas.Size = new System.Drawing.Size(643, 424);
            this.dgvCriticas.TabIndex = 0;
            this.dgvCriticas.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvCriticas_CellPainting);
            this.dgvCriticas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCriticas_CellClick);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(523, 324);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 2;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // bValidarTemp
            // 
            this.bValidarTemp.Enabled = false;
            this.bValidarTemp.Location = new System.Drawing.Point(523, 140);
            this.bValidarTemp.Name = "bValidarTemp";
            this.bValidarTemp.Size = new System.Drawing.Size(75, 40);
            this.bValidarTemp.TabIndex = 0;
            this.bValidarTemp.Text = "Añadir";
            this.bValidarTemp.UseVisualStyleBackColor = true;
            this.bValidarTemp.Click += new System.EventHandler(this.bValidarTemp_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Crítica";
            // 
            // eCritica
            // 
            this.eCritica.BackColor = System.Drawing.Color.Gainsboro;
            this.eCritica.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.eCritica.Location = new System.Drawing.Point(17, 140);
            this.eCritica.Name = "eCritica";
            this.eCritica.Size = new System.Drawing.Size(500, 200);
            this.eCritica.TabIndex = 9;
            this.eCritica.Text = "";
            // 
            // sCanal
            // 
            this.sCanal.AutoSize = true;
            this.sCanal.Location = new System.Drawing.Point(13, 59);
            this.sCanal.MinimumSize = new System.Drawing.Size(140, 13);
            this.sCanal.Name = "sCanal";
            this.sCanal.Size = new System.Drawing.Size(140, 13);
            this.sCanal.TabIndex = 8;
            this.sCanal.Text = "Cadena";
            this.sCanal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sPrograma
            // 
            this.sPrograma.AutoSize = true;
            this.sPrograma.Location = new System.Drawing.Point(14, 34);
            this.sPrograma.MinimumSize = new System.Drawing.Size(140, 13);
            this.sPrograma.Name = "sPrograma";
            this.sPrograma.Size = new System.Drawing.Size(140, 13);
            this.sPrograma.TabIndex = 7;
            this.sPrograma.Text = "Programa";
            this.sPrograma.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gbFechas);
            this.groupBox1.Controls.Add(this.cbFechas);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.rbTodos);
            this.groupBox1.Controls.Add(this.rbConCritica);
            this.groupBox1.Controls.Add(this.rbSinCritica);
            this.groupBox1.Controls.Add(this.tbPrograma);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbCadena);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.etCadena);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.MaximumSize = new System.Drawing.Size(328, 300);
            this.groupBox1.MinimumSize = new System.Drawing.Size(328, 300);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(328, 300);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Búsqueda Avanzada";
            // 
            // gbFechas
            // 
            this.gbFechas.Controls.Add(this.eFFin);
            this.gbFechas.Controls.Add(this.labelFecha);
            this.gbFechas.Controls.Add(this.eFInicio);
            this.gbFechas.Controls.Add(this.label24);
            this.gbFechas.Location = new System.Drawing.Point(6, 160);
            this.gbFechas.Name = "gbFechas";
            this.gbFechas.Size = new System.Drawing.Size(250, 110);
            this.gbFechas.TabIndex = 81;
            this.gbFechas.TabStop = false;
            this.gbFechas.Text = "Fechas";
            this.gbFechas.Visible = false;
            // 
            // eFFin
            // 
            this.eFFin.Location = new System.Drawing.Point(16, 76);
            this.eFFin.Name = "eFFin";
            this.eFFin.Size = new System.Drawing.Size(210, 22);
            this.eFFin.TabIndex = 1;
            // 
            // labelFecha
            // 
            this.labelFecha.AutoSize = true;
            this.labelFecha.Location = new System.Drawing.Point(22, 60);
            this.labelFecha.Name = "labelFecha";
            this.labelFecha.Size = new System.Drawing.Size(66, 13);
            this.labelFecha.TabIndex = 77;
            this.labelFecha.Text = "Fecha final:";
            // 
            // eFInicio
            // 
            this.eFInicio.Location = new System.Drawing.Point(16, 35);
            this.eFInicio.Name = "eFInicio";
            this.eFInicio.Size = new System.Drawing.Size(210, 22);
            this.eFInicio.TabIndex = 0;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(22, 18);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(73, 13);
            this.label24.TabIndex = 75;
            this.label24.Text = "Fecha inicial:";
            // 
            // cbFechas
            // 
            this.cbFechas.AutoSize = true;
            this.cbFechas.Location = new System.Drawing.Point(10, 137);
            this.cbFechas.Name = "cbFechas";
            this.cbFechas.Size = new System.Drawing.Size(144, 17);
            this.cbFechas.TabIndex = 80;
            this.cbFechas.Text = "Busqueda entre fechas";
            this.cbFechas.UseVisualStyleBackColor = true;
            this.cbFechas.CheckedChanged += new System.EventHandler(this.cbFechas_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Elija Cadena y/o Programa";
            // 
            // rbTodos
            // 
            this.rbTodos.AutoSize = true;
            this.rbTodos.Checked = true;
            this.rbTodos.Location = new System.Drawing.Point(182, 143);
            this.rbTodos.Name = "rbTodos";
            this.rbTodos.Size = new System.Drawing.Size(56, 17);
            this.rbTodos.TabIndex = 16;
            this.rbTodos.TabStop = true;
            this.rbTodos.Text = "Todos";
            this.rbTodos.UseVisualStyleBackColor = true;
            // 
            // rbConCritica
            // 
            this.rbConCritica.AutoSize = true;
            this.rbConCritica.Location = new System.Drawing.Point(182, 125);
            this.rbConCritica.Name = "rbConCritica";
            this.rbConCritica.Size = new System.Drawing.Size(79, 17);
            this.rbConCritica.TabIndex = 15;
            this.rbConCritica.Text = "Con crítica";
            this.rbConCritica.UseVisualStyleBackColor = true;
            // 
            // rbSinCritica
            // 
            this.rbSinCritica.AutoSize = true;
            this.rbSinCritica.Location = new System.Drawing.Point(182, 107);
            this.rbSinCritica.Name = "rbSinCritica";
            this.rbSinCritica.Size = new System.Drawing.Size(74, 17);
            this.rbSinCritica.TabIndex = 14;
            this.rbSinCritica.Text = "Sin crítica";
            this.rbSinCritica.UseVisualStyleBackColor = true;
            // 
            // tbPrograma
            // 
            this.tbPrograma.Location = new System.Drawing.Point(70, 78);
            this.tbPrograma.Name = "tbPrograma";
            this.tbPrograma.Size = new System.Drawing.Size(170, 22);
            this.tbPrograma.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Programa";
            // 
            // cbCadena
            // 
            this.cbCadena.FormattingEnabled = true;
            this.cbCadena.Location = new System.Drawing.Point(70, 50);
            this.cbCadena.Name = "cbCadena";
            this.cbCadena.Size = new System.Drawing.Size(170, 21);
            this.cbCadena.TabIndex = 10;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gbPendientes);
            this.groupBox2.Controls.Add(this.dgvCriticas);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(10, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox2.Size = new System.Drawing.Size(663, 514);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Resultados de la búsqueda";
            // 
            // gbPendientes
            // 
            this.gbPendientes.Controls.Add(this.bMostrarPendientes);
            this.gbPendientes.Controls.Add(this.bCancelarPendientes2);
            this.gbPendientes.Controls.Add(this.bGuardarPendientes2);
            this.gbPendientes.Controls.Add(this.sPendientes);
            this.gbPendientes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbPendientes.Location = new System.Drawing.Point(10, 442);
            this.gbPendientes.Name = "gbPendientes";
            this.gbPendientes.Size = new System.Drawing.Size(643, 62);
            this.gbPendientes.TabIndex = 20;
            this.gbPendientes.TabStop = false;
            this.gbPendientes.Text = "Respuestas pendientes";
            this.gbPendientes.Visible = false;
            // 
            // bMostrarPendientes
            // 
            this.bMostrarPendientes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bMostrarPendientes.Location = new System.Drawing.Point(132, 36);
            this.bMostrarPendientes.Name = "bMostrarPendientes";
            this.bMostrarPendientes.Size = new System.Drawing.Size(120, 23);
            this.bMostrarPendientes.TabIndex = 3;
            this.bMostrarPendientes.Text = "Mostrar Pendientes";
            this.bMostrarPendientes.UseVisualStyleBackColor = true;
            this.bMostrarPendientes.Click += new System.EventHandler(this.bMostrarPendientes_Click);
            // 
            // bCancelarPendientes2
            // 
            this.bCancelarPendientes2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bCancelarPendientes2.Location = new System.Drawing.Point(258, 36);
            this.bCancelarPendientes2.Name = "bCancelarPendientes2";
            this.bCancelarPendientes2.Size = new System.Drawing.Size(120, 23);
            this.bCancelarPendientes2.TabIndex = 2;
            this.bCancelarPendientes2.Text = "Cancelar Pendientes";
            this.bCancelarPendientes2.UseVisualStyleBackColor = true;
            this.bCancelarPendientes2.Click += new System.EventHandler(this.bCancelarPendientes2_Click);
            // 
            // bGuardarPendientes2
            // 
            this.bGuardarPendientes2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bGuardarPendientes2.Location = new System.Drawing.Point(6, 36);
            this.bGuardarPendientes2.Name = "bGuardarPendientes2";
            this.bGuardarPendientes2.Size = new System.Drawing.Size(120, 23);
            this.bGuardarPendientes2.TabIndex = 1;
            this.bGuardarPendientes2.Text = "Guardar Pendientes";
            this.bGuardarPendientes2.UseVisualStyleBackColor = true;
            this.bGuardarPendientes2.Click += new System.EventHandler(this.bGuardarPendientes2_Click);
            // 
            // sPendientes
            // 
            this.sPendientes.AutoSize = true;
            this.sPendientes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sPendientes.Location = new System.Drawing.Point(6, 15);
            this.sPendientes.Name = "sPendientes";
            this.sPendientes.Size = new System.Drawing.Size(13, 15);
            this.sPendientes.TabIndex = 0;
            this.sPendientes.Text = "a";
            this.sPendientes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.sDescripcion);
            this.groupBox3.Controls.Add(this.bCancelarPendientes);
            this.groupBox3.Controls.Add(this.bGuardarPendientes);
            this.groupBox3.Controls.Add(this.bValidar);
            this.groupBox3.Controls.Add(this.sAutor);
            this.groupBox3.Controls.Add(this.sFecha);
            this.groupBox3.Controls.Add(this.sPrograma);
            this.groupBox3.Controls.Add(this.btnLimpiar);
            this.groupBox3.Controls.Add(this.sCanal);
            this.groupBox3.Controls.Add(this.bValidarTemp);
            this.groupBox3.Controls.Add(this.eCritica);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(620, 544);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Nueva crítica";
            // 
            // bCancelarPendientes
            // 
            this.bCancelarPendientes.Enabled = false;
            this.bCancelarPendientes.Location = new System.Drawing.Point(523, 278);
            this.bCancelarPendientes.Name = "bCancelarPendientes";
            this.bCancelarPendientes.Size = new System.Drawing.Size(75, 40);
            this.bCancelarPendientes.TabIndex = 18;
            this.bCancelarPendientes.Text = "Cancelar Pendientes";
            this.bCancelarPendientes.UseVisualStyleBackColor = true;
            this.bCancelarPendientes.Click += new System.EventHandler(this.bCancelarPendientes2_Click);
            // 
            // bGuardarPendientes
            // 
            this.bGuardarPendientes.Enabled = false;
            this.bGuardarPendientes.Location = new System.Drawing.Point(523, 232);
            this.bGuardarPendientes.Name = "bGuardarPendientes";
            this.bGuardarPendientes.Size = new System.Drawing.Size(75, 40);
            this.bGuardarPendientes.TabIndex = 17;
            this.bGuardarPendientes.Text = "Guardar Pendientes";
            this.bGuardarPendientes.UseVisualStyleBackColor = true;
            this.bGuardarPendientes.Click += new System.EventHandler(this.bGuardarPendientes2_Click);
            // 
            // bValidar
            // 
            this.bValidar.Enabled = false;
            this.bValidar.Location = new System.Drawing.Point(523, 186);
            this.bValidar.Name = "bValidar";
            this.bValidar.Size = new System.Drawing.Size(75, 40);
            this.bValidar.TabIndex = 1;
            this.bValidar.Text = "Añadir y Guardar";
            this.bValidar.UseVisualStyleBackColor = true;
            this.bValidar.Click += new System.EventHandler(this.bValidar_Click);
            // 
            // sAutor
            // 
            this.sAutor.AutoSize = true;
            this.sAutor.Location = new System.Drawing.Point(74, 121);
            this.sAutor.Name = "sAutor";
            this.sAutor.Size = new System.Drawing.Size(37, 13);
            this.sAutor.TabIndex = 15;
            this.sAutor.Text = "Fecha";
            // 
            // sFecha
            // 
            this.sFecha.AutoSize = true;
            this.sFecha.Location = new System.Drawing.Point(15, 100);
            this.sFecha.Name = "sFecha";
            this.sFecha.Size = new System.Drawing.Size(37, 13);
            this.sFecha.TabIndex = 14;
            this.sFecha.Text = "Fecha";
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
            this.gbPaginacion.Location = new System.Drawing.Point(10, 310);
            this.gbPaginacion.MaximumSize = new System.Drawing.Size(328, 50);
            this.gbPaginacion.MinimumSize = new System.Drawing.Size(328, 100);
            this.gbPaginacion.Name = "gbPaginacion";
            this.gbPaginacion.Size = new System.Drawing.Size(328, 100);
            this.gbPaginacion.TabIndex = 23;
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
            this.mtbRegistrosXPagina.Text = "16";
            this.mtbRegistrosXPagina.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mtbRegistrosXPagina.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mtbRegistrosXPagina_KeyDown);
            this.mtbRegistrosXPagina.Leave += new System.EventHandler(this.mtbRegistrosXPagina_Leave);
            this.mtbRegistrosXPagina.TextChanged += new System.EventHandler(this.mtbRegistrosXPagina_TextChanged);
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
            // gbInfoCON
            // 
            this.gbInfoCON.Controls.Add(this.etInfoCON);
            this.gbInfoCON.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbInfoCON.Location = new System.Drawing.Point(10, 410);
            this.gbInfoCON.MaximumSize = new System.Drawing.Size(328, 50);
            this.gbInfoCON.MinimumSize = new System.Drawing.Size(328, 100);
            this.gbInfoCON.Name = "gbInfoCON";
            this.gbInfoCON.Size = new System.Drawing.Size(328, 100);
            this.gbInfoCON.TabIndex = 24;
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
            // gbInfoINS_MOD
            // 
            this.gbInfoINS_MOD.Controls.Add(this.etInfoINS_MOD);
            this.gbInfoINS_MOD.Location = new System.Drawing.Point(630, 3);
            this.gbInfoINS_MOD.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.gbInfoINS_MOD.Name = "gbInfoINS_MOD";
            this.gbInfoINS_MOD.Size = new System.Drawing.Size(300, 200);
            this.gbInfoINS_MOD.TabIndex = 15;
            this.gbInfoINS_MOD.TabStop = false;
            this.gbInfoINS_MOD.Text = "Mensajes del sistema";
            // 
            // etInfoINS_MOD
            // 
            this.etInfoINS_MOD.AutoSize = true;
            this.etInfoINS_MOD.Location = new System.Drawing.Point(15, 26);
            this.etInfoINS_MOD.MaximumSize = new System.Drawing.Size(400, 120);
            this.etInfoINS_MOD.MinimumSize = new System.Drawing.Size(275, 120);
            this.etInfoINS_MOD.Name = "etInfoINS_MOD";
            this.etInfoINS_MOD.Size = new System.Drawing.Size(275, 120);
            this.etInfoINS_MOD.TabIndex = 0;
            this.etInfoINS_MOD.Text = "Sistema";
            // 
            // sDescripcion
            // 
            this.sDescripcion.BackColor = System.Drawing.Color.Gainsboro;
            this.sDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.sDescripcion.Location = new System.Drawing.Point(167, 34);
            this.sDescripcion.Name = "sDescripcion";
            this.sDescripcion.Size = new System.Drawing.Size(350, 100);
            this.sDescripcion.TabIndex = 19;
            this.sDescripcion.Text = "Descripción del Programa";
            // 
            // FVistaSeccionCriticasModerador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1061, 750);
            this.Name = "FVistaSeccionCriticasModerador";
            this.Load += new System.EventHandler(this.FVistaSeccionCriticasModerador_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgBusquedaRapida)).EndInit();
            this.pnlSecBase.ResumeLayout(false);
            this.pestanyasSeccionBase.ResumeLayout(false);
            this.tpSeccionBaseConsultar.ResumeLayout(false);
            this.tpInsertar.ResumeLayout(false);
            this.splitContainerSeccionBase.Panel1.ResumeLayout(false);
            this.splitContainerSeccionBase.Panel2.ResumeLayout(false);
            this.splitContainerSeccionBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TbSeccionBaseErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCriticas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbFechas.ResumeLayout(false);
            this.gbFechas.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.gbPendientes.ResumeLayout(false);
            this.gbPendientes.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gbPaginacion.ResumeLayout(false);
            this.gbPaginacion.PerformLayout();
            this.gbInfoCON.ResumeLayout(false);
            this.gbInfoCON.PerformLayout();
            this.gbInfoINS_MOD.ResumeLayout(false);
            this.gbInfoINS_MOD.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCriticas;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label etCadena;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button bValidarTemp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox eCritica;
        private System.Windows.Forms.Label sCanal;
        private System.Windows.Forms.Label sPrograma;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cbCadena;
        private System.Windows.Forms.GroupBox gbPaginacion;
        private System.Windows.Forms.Label etPaginacionInfo;
        private System.Windows.Forms.Button btnPaginaPrimera;
        private System.Windows.Forms.Button btnPaginaAnterior;
        private System.Windows.Forms.Button btnPaginaUltima;
        private System.Windows.Forms.Button btnPaginaSiguiente;
        private System.Windows.Forms.Label etInfoPAG;
        private System.Windows.Forms.MaskedTextBox mtbRegistrosXPagina;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox gbInfoCON;
        private System.Windows.Forms.Label etInfoCON;
        private System.Windows.Forms.RadioButton rbTodos;
        private System.Windows.Forms.RadioButton rbConCritica;
        private System.Windows.Forms.RadioButton rbSinCritica;
        private System.Windows.Forms.TextBox tbPrograma;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbInfoINS_MOD;
        private System.Windows.Forms.Label etInfoINS_MOD;
        private System.Windows.Forms.Label sFecha;
        private System.Windows.Forms.GroupBox gbFechas;
        private System.Windows.Forms.DateTimePicker eFFin;
        private System.Windows.Forms.Label labelFecha;
        private System.Windows.Forms.DateTimePicker eFInicio;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.CheckBox cbFechas;
        private System.Windows.Forms.GroupBox gbPendientes;
        private System.Windows.Forms.Button bMostrarPendientes;
        private System.Windows.Forms.Button bCancelarPendientes2;
        private System.Windows.Forms.Button bGuardarPendientes2;
        private System.Windows.Forms.Label sPendientes;
        private System.Windows.Forms.Label sAutor;
        private System.Windows.Forms.Button bCancelarPendientes;
        private System.Windows.Forms.Button bGuardarPendientes;
        private System.Windows.Forms.Button bValidar;
        private System.Windows.Forms.RichTextBox sDescripcion;
    }
}
