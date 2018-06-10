namespace TVO_VistaWindows
{
    partial class FVistaSeccionEmisiones
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gBbuscarEmision = new System.Windows.Forms.GroupBox();
            this.checkPaginar = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbProgramaCON = new System.Windows.Forms.ComboBox();
            this.cbCadenaCON = new System.Windows.Forms.ComboBox();
            this.rBMas = new System.Windows.Forms.RadioButton();
            this.rBIgual = new System.Windows.Forms.RadioButton();
            this.rBMenos = new System.Windows.Forms.RadioButton();
            this.nUPMinutosBusc = new System.Windows.Forms.NumericUpDown();
            this.labelDuracion = new System.Windows.Forms.Label();
            this.FechaHoraBusc = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btBuscar = new System.Windows.Forms.Button();
            this.dGWEmisiones = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbInfo = new System.Windows.Forms.GroupBox();
            this.etInfo = new System.Windows.Forms.Label();
            this.gbSistemaInfo = new System.Windows.Forms.GroupBox();
            this.etSistemaInfo = new System.Windows.Forms.Label();
            this.gbPaginacion = new System.Windows.Forms.GroupBox();
            this.etPaginacionInfo = new System.Windows.Forms.Label();
            this.btnPaginaPrimera = new System.Windows.Forms.Button();
            this.btnPaginaAnterior = new System.Windows.Forms.Button();
            this.btnPaginaUltima = new System.Windows.Forms.Button();
            this.btnPaginaSiguiente = new System.Windows.Forms.Button();
            this.etInfoPAG = new System.Windows.Forms.Label();
            this.mtbRegistrosXPagina = new System.Windows.Forms.MaskedTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.gBInsMod = new System.Windows.Forms.GroupBox();
            this.cbProgramaINS_MOD = new System.Windows.Forms.ComboBox();
            this.cbCadenaINS_MOD = new System.Windows.Forms.ComboBox();
            this.labelMinutos = new System.Windows.Forms.Label();
            this.nUPMinutos = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.FechaHoraEmision = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.btInsertar = new System.Windows.Forms.Button();
            this.btLimpiar = new System.Windows.Forms.Button();
            this.labelNomCadena = new System.Windows.Forms.Label();
            this.labelPrograma = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgBusquedaRapida)).BeginInit();
            this.pnlSecBase.SuspendLayout();
            this.pestanyasSeccionBase.SuspendLayout();
            this.tpSeccionBaseConsultar.SuspendLayout();
            this.tpInsertar.SuspendLayout();
            this.splitContainerSeccionBase.Panel1.SuspendLayout();
            this.splitContainerSeccionBase.Panel2.SuspendLayout();
            this.splitContainerSeccionBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TbSeccionBaseErrorProvider)).BeginInit();
            this.gBbuscarEmision.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUPMinutosBusc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGWEmisiones)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gbInfo.SuspendLayout();
            this.gbSistemaInfo.SuspendLayout();
            this.gbPaginacion.SuspendLayout();
            this.gBInsMod.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUPMinutos)).BeginInit();
            this.SuspendLayout();
            // 
            // tbBusquedaRapida
            // 
            this.tbBusquedaRapida.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic);
            this.tbBusquedaRapida.Location = new System.Drawing.Point(714, 114);
            this.tbBusquedaRapida.Text = "";
            // 
            // imgBusquedaRapida
            // 
            this.imgBusquedaRapida.Location = new System.Drawing.Point(885, 110);
            // 
            // pnlSecBase
            // 
            this.pnlSecBase.Size = new System.Drawing.Size(1055, 570);
            // 
            // pestanyasSeccionBase
            // 
            this.pestanyasSeccionBase.Size = new System.Drawing.Size(1053, 568);
            this.pestanyasSeccionBase.Click += new System.EventHandler(this.pestanyasSeccionBase_Click);
            // 
            // tpSeccionBaseConsultar
            // 
            this.tpSeccionBaseConsultar.Size = new System.Drawing.Size(1045, 542);
            // 
            // tpInsertar
            // 
            this.tpInsertar.Controls.Add(this.gBInsMod);
            this.tpInsertar.Controls.Add(this.gbInfo);
            this.tpInsertar.Size = new System.Drawing.Size(1045, 542);
            // 
            // splitContainerSeccionBase
            // 
            // 
            // splitContainerSeccionBase.Panel1
            // 
            this.splitContainerSeccionBase.Panel1.Controls.Add(this.gbSistemaInfo);
            this.splitContainerSeccionBase.Panel1.Controls.Add(this.gbPaginacion);
            this.splitContainerSeccionBase.Panel1.Controls.Add(this.gBbuscarEmision);
            // 
            // splitContainerSeccionBase.Panel2
            // 
            this.splitContainerSeccionBase.Panel2.Controls.Add(this.groupBox1);
            this.splitContainerSeccionBase.Size = new System.Drawing.Size(1039, 536);
            this.splitContainerSeccionBase.SplitterDistance = 346;
            // 
            // gBbuscarEmision
            // 
            this.gBbuscarEmision.Controls.Add(this.checkPaginar);
            this.gBbuscarEmision.Controls.Add(this.label1);
            this.gBbuscarEmision.Controls.Add(this.cbProgramaCON);
            this.gBbuscarEmision.Controls.Add(this.cbCadenaCON);
            this.gBbuscarEmision.Controls.Add(this.rBMas);
            this.gBbuscarEmision.Controls.Add(this.rBIgual);
            this.gBbuscarEmision.Controls.Add(this.rBMenos);
            this.gBbuscarEmision.Controls.Add(this.nUPMinutosBusc);
            this.gBbuscarEmision.Controls.Add(this.labelDuracion);
            this.gBbuscarEmision.Controls.Add(this.FechaHoraBusc);
            this.gBbuscarEmision.Controls.Add(this.label6);
            this.gBbuscarEmision.Controls.Add(this.label4);
            this.gBbuscarEmision.Controls.Add(this.label3);
            this.gBbuscarEmision.Controls.Add(this.btBuscar);
            this.gBbuscarEmision.Dock = System.Windows.Forms.DockStyle.Top;
            this.gBbuscarEmision.Location = new System.Drawing.Point(10, 10);
            this.gBbuscarEmision.MaximumSize = new System.Drawing.Size(326, 328);
            this.gBbuscarEmision.MinimumSize = new System.Drawing.Size(326, 328);
            this.gBbuscarEmision.Name = "gBbuscarEmision";
            this.gBbuscarEmision.Size = new System.Drawing.Size(326, 328);
            this.gBbuscarEmision.TabIndex = 0;
            this.gBbuscarEmision.TabStop = false;
            this.gBbuscarEmision.Text = "Búsqueda Avanzada";
            // 
            // checkPaginar
            // 
            this.checkPaginar.AutoSize = true;
            this.checkPaginar.Location = new System.Drawing.Point(6, 296);
            this.checkPaginar.Name = "checkPaginar";
            this.checkPaginar.Size = new System.Drawing.Size(65, 17);
            this.checkPaginar.TabIndex = 39;
            this.checkPaginar.Text = "Paginar";
            this.checkPaginar.UseVisualStyleBackColor = true;
            this.checkPaginar.CheckedChanged += new System.EventHandler(this.checkPaginar_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(7, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(288, 13);
            this.label1.TabIndex = 38;
            this.label1.Text = "Si lo desea puede escribir el nombre de la cadena/programa";
            // 
            // cbProgramaCON
            // 
            this.cbProgramaCON.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbProgramaCON.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbProgramaCON.FormattingEnabled = true;
            this.cbProgramaCON.Location = new System.Drawing.Point(77, 97);
            this.cbProgramaCON.Name = "cbProgramaCON";
            this.cbProgramaCON.Size = new System.Drawing.Size(230, 21);
            this.cbProgramaCON.TabIndex = 1;
            this.cbProgramaCON.SelectedIndexChanged += new System.EventHandler(this.cbProgramaCON_SelectedIndexChanged);
            this.cbProgramaCON.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbProgramaCON_KeyDown);
            // 
            // cbCadenaCON
            // 
            this.cbCadenaCON.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbCadenaCON.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbCadenaCON.FormattingEnabled = true;
            this.cbCadenaCON.Location = new System.Drawing.Point(77, 35);
            this.cbCadenaCON.Name = "cbCadenaCON";
            this.cbCadenaCON.Size = new System.Drawing.Size(180, 21);
            this.cbCadenaCON.TabIndex = 0;
            this.cbCadenaCON.SelectedIndexChanged += new System.EventHandler(this.cbCadenaCON_SelectedIndexChanged);
            this.cbCadenaCON.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbCadenaCON_KeyDown);
            // 
            // rBMas
            // 
            this.rBMas.AutoSize = true;
            this.rBMas.Checked = true;
            this.rBMas.Location = new System.Drawing.Point(211, 221);
            this.rBMas.Name = "rBMas";
            this.rBMas.Size = new System.Drawing.Size(71, 17);
            this.rBMas.TabIndex = 5;
            this.rBMas.TabStop = true;
            this.rBMas.Text = "Más de...";
            this.rBMas.UseVisualStyleBackColor = true;
            this.rBMas.CheckedChanged += new System.EventHandler(this.rBMas_CheckedChanged);
            // 
            // rBIgual
            // 
            this.rBIgual.AutoSize = true;
            this.rBIgual.Location = new System.Drawing.Point(116, 221);
            this.rBIgual.Name = "rBIgual";
            this.rBIgual.Size = new System.Drawing.Size(69, 17);
            this.rBIgual.TabIndex = 4;
            this.rBIgual.Text = "Igual a...";
            this.rBIgual.UseVisualStyleBackColor = true;
            this.rBIgual.CheckedChanged += new System.EventHandler(this.rBIgual_CheckedChanged);
            // 
            // rBMenos
            // 
            this.rBMenos.AutoSize = true;
            this.rBMenos.Location = new System.Drawing.Point(15, 221);
            this.rBMenos.Name = "rBMenos";
            this.rBMenos.Size = new System.Drawing.Size(85, 17);
            this.rBMenos.TabIndex = 3;
            this.rBMenos.Text = "Menos de...";
            this.rBMenos.UseVisualStyleBackColor = true;
            this.rBMenos.CheckedChanged += new System.EventHandler(this.rBMenos_CheckedChanged);
            // 
            // nUPMinutosBusc
            // 
            this.nUPMinutosBusc.Location = new System.Drawing.Point(116, 259);
            this.nUPMinutosBusc.Name = "nUPMinutosBusc";
            this.nUPMinutosBusc.Size = new System.Drawing.Size(60, 22);
            this.nUPMinutosBusc.TabIndex = 6;
            this.nUPMinutosBusc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nUPMinutosBusc.ValueChanged += new System.EventHandler(this.nUPMinutosBusc_ValueChanged);
            // 
            // labelDuracion
            // 
            this.labelDuracion.AutoSize = true;
            this.labelDuracion.Location = new System.Drawing.Point(7, 192);
            this.labelDuracion.Name = "labelDuracion";
            this.labelDuracion.Size = new System.Drawing.Size(115, 13);
            this.labelDuracion.TabIndex = 28;
            this.labelDuracion.Text = "Duración en minutos";
            // 
            // FechaHoraBusc
            // 
            this.FechaHoraBusc.Location = new System.Drawing.Point(77, 148);
            this.FechaHoraBusc.Name = "FechaHoraBusc";
            this.FechaHoraBusc.Size = new System.Drawing.Size(220, 22);
            this.FechaHoraBusc.TabIndex = 2;
            this.FechaHoraBusc.ValueChanged += new System.EventHandler(this.FechaHoraBusc_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Fecha";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Cadena";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Programa";
            // 
            // btBuscar
            // 
            this.btBuscar.Location = new System.Drawing.Point(211, 290);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(75, 23);
            this.btBuscar.TabIndex = 7;
            this.btBuscar.Text = "Buscar";
            this.btBuscar.UseVisualStyleBackColor = true;
            this.btBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dGWEmisiones
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dGWEmisiones.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dGWEmisiones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dGWEmisiones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dGWEmisiones.DefaultCellStyle = dataGridViewCellStyle2;
            this.dGWEmisiones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGWEmisiones.Location = new System.Drawing.Point(10, 25);
            this.dGWEmisiones.Name = "dGWEmisiones";
            this.dGWEmisiones.ReadOnly = true;
            this.dGWEmisiones.Size = new System.Drawing.Size(639, 471);
            this.dGWEmisiones.TabIndex = 0;
            this.dGWEmisiones.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dGWEmisiones_CellMouseMove);
            this.dGWEmisiones.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGWEmisiones_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dGWEmisiones);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox1.Size = new System.Drawing.Size(659, 506);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Resultados de la búsqueda";
            // 
            // gbInfo
            // 
            this.gbInfo.Controls.Add(this.etInfo);
            this.gbInfo.Location = new System.Drawing.Point(557, 25);
            this.gbInfo.Name = "gbInfo";
            this.gbInfo.Size = new System.Drawing.Size(450, 50);
            this.gbInfo.TabIndex = 2;
            this.gbInfo.TabStop = false;
            this.gbInfo.Text = "Mensajes del sistema";
            this.gbInfo.Visible = false;
            // 
            // etInfo
            // 
            this.etInfo.AutoSize = true;
            this.etInfo.Location = new System.Drawing.Point(15, 26);
            this.etInfo.Name = "etInfo";
            this.etInfo.Size = new System.Drawing.Size(88, 13);
            this.etInfo.TabIndex = 0;
            this.etInfo.Text = "mensajeSistema";
            // 
            // gbSistemaInfo
            // 
            this.gbSistemaInfo.Controls.Add(this.etSistemaInfo);
            this.gbSistemaInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbSistemaInfo.Location = new System.Drawing.Point(10, 438);
            this.gbSistemaInfo.MaximumSize = new System.Drawing.Size(326, 70);
            this.gbSistemaInfo.MinimumSize = new System.Drawing.Size(326, 70);
            this.gbSistemaInfo.Name = "gbSistemaInfo";
            this.gbSistemaInfo.Size = new System.Drawing.Size(326, 70);
            this.gbSistemaInfo.TabIndex = 22;
            this.gbSistemaInfo.TabStop = false;
            this.gbSistemaInfo.Text = "Mensaje del sistema";
            // 
            // etSistemaInfo
            // 
            this.etSistemaInfo.AutoSize = true;
            this.etSistemaInfo.Location = new System.Drawing.Point(7, 18);
            this.etSistemaInfo.MaximumSize = new System.Drawing.Size(315, 50);
            this.etSistemaInfo.MinimumSize = new System.Drawing.Size(315, 50);
            this.etSistemaInfo.Name = "etSistemaInfo";
            this.etSistemaInfo.Size = new System.Drawing.Size(315, 50);
            this.etSistemaInfo.TabIndex = 0;
            this.etSistemaInfo.Text = "label13";
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
            this.gbPaginacion.Location = new System.Drawing.Point(10, 338);
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
            this.mtbRegistrosXPagina.TabIndex = 0;
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
            // gBInsMod
            // 
            this.gBInsMod.Controls.Add(this.cbProgramaINS_MOD);
            this.gBInsMod.Controls.Add(this.cbCadenaINS_MOD);
            this.gBInsMod.Controls.Add(this.labelMinutos);
            this.gBInsMod.Controls.Add(this.nUPMinutos);
            this.gBInsMod.Controls.Add(this.label10);
            this.gBInsMod.Controls.Add(this.label9);
            this.gBInsMod.Controls.Add(this.label8);
            this.gBInsMod.Controls.Add(this.FechaHoraEmision);
            this.gBInsMod.Controls.Add(this.label5);
            this.gBInsMod.Controls.Add(this.btInsertar);
            this.gBInsMod.Controls.Add(this.btLimpiar);
            this.gBInsMod.Controls.Add(this.labelNomCadena);
            this.gBInsMod.Controls.Add(this.labelPrograma);
            this.gBInsMod.Location = new System.Drawing.Point(19, 25);
            this.gBInsMod.Name = "gBInsMod";
            this.gBInsMod.Size = new System.Drawing.Size(491, 330);
            this.gBInsMod.TabIndex = 3;
            this.gBInsMod.TabStop = false;
            this.gBInsMod.Text = "Insertar/Modificar";
            // 
            // cbProgramaINS_MOD
            // 
            this.cbProgramaINS_MOD.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbProgramaINS_MOD.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbProgramaINS_MOD.FormattingEnabled = true;
            this.cbProgramaINS_MOD.Location = new System.Drawing.Point(102, 125);
            this.cbProgramaINS_MOD.Name = "cbProgramaINS_MOD";
            this.cbProgramaINS_MOD.Size = new System.Drawing.Size(180, 21);
            this.cbProgramaINS_MOD.TabIndex = 1;
            this.cbProgramaINS_MOD.SelectedIndexChanged += new System.EventHandler(this.cbPrograma_SelectedIndexChanged);
            // 
            // cbCadenaINS_MOD
            // 
            this.cbCadenaINS_MOD.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbCadenaINS_MOD.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbCadenaINS_MOD.FormattingEnabled = true;
            this.cbCadenaINS_MOD.Location = new System.Drawing.Point(102, 75);
            this.cbCadenaINS_MOD.Name = "cbCadenaINS_MOD";
            this.cbCadenaINS_MOD.Size = new System.Drawing.Size(180, 21);
            this.cbCadenaINS_MOD.TabIndex = 0;
            this.cbCadenaINS_MOD.SelectedIndexChanged += new System.EventHandler(this.cbCadenaINS_MOD_SelectedIndexChanged);
            // 
            // labelMinutos
            // 
            this.labelMinutos.AutoSize = true;
            this.labelMinutos.Location = new System.Drawing.Point(168, 232);
            this.labelMinutos.Name = "labelMinutos";
            this.labelMinutos.Size = new System.Drawing.Size(49, 13);
            this.labelMinutos.TabIndex = 40;
            this.labelMinutos.Text = "minutos";
            // 
            // nUPMinutos
            // 
            this.nUPMinutos.Location = new System.Drawing.Point(102, 223);
            this.nUPMinutos.Name = "nUPMinutos";
            this.nUPMinutos.Size = new System.Drawing.Size(60, 22);
            this.nUPMinutos.TabIndex = 3;
            this.nUPMinutos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(31, 225);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 13);
            this.label10.TabIndex = 38;
            this.label10.Text = "Duración";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(31, 78);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 13);
            this.label9.TabIndex = 35;
            this.label9.Text = "Cadena";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(31, 128);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 34;
            this.label8.Text = "Programa";
            // 
            // FechaHoraEmision
            // 
            this.FechaHoraEmision.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.FechaHoraEmision.Location = new System.Drawing.Point(102, 173);
            this.FechaHoraEmision.Name = "FechaHoraEmision";
            this.FechaHoraEmision.Size = new System.Drawing.Size(220, 22);
            this.FechaHoraEmision.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "Fecha/Hora";
            // 
            // btInsertar
            // 
            this.btInsertar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btInsertar.Location = new System.Drawing.Point(247, 280);
            this.btInsertar.Name = "btInsertar";
            this.btInsertar.Size = new System.Drawing.Size(75, 23);
            this.btInsertar.TabIndex = 4;
            this.btInsertar.Text = "Insertar";
            this.btInsertar.UseVisualStyleBackColor = true;
            this.btInsertar.Click += new System.EventHandler(this.btInsertar_Click);
            // 
            // btLimpiar
            // 
            this.btLimpiar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btLimpiar.Location = new System.Drawing.Point(157, 280);
            this.btLimpiar.Name = "btLimpiar";
            this.btLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btLimpiar.TabIndex = 5;
            this.btLimpiar.Text = "Limpiar";
            this.btLimpiar.UseVisualStyleBackColor = true;
            this.btLimpiar.Click += new System.EventHandler(this.btLimpiar_Click);
            // 
            // labelNomCadena
            // 
            this.labelNomCadena.AutoSize = true;
            this.labelNomCadena.Location = new System.Drawing.Point(85, 43);
            this.labelNomCadena.MaximumSize = new System.Drawing.Size(400, 13);
            this.labelNomCadena.MinimumSize = new System.Drawing.Size(400, 13);
            this.labelNomCadena.Name = "labelNomCadena";
            this.labelNomCadena.Size = new System.Drawing.Size(400, 13);
            this.labelNomCadena.TabIndex = 29;
            this.labelNomCadena.Text = "labelCadena";
            this.labelNomCadena.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelNomCadena.Visible = false;
            // 
            // labelPrograma
            // 
            this.labelPrograma.AutoSize = true;
            this.labelPrograma.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrograma.Location = new System.Drawing.Point(5, 15);
            this.labelPrograma.MaximumSize = new System.Drawing.Size(480, 28);
            this.labelPrograma.MinimumSize = new System.Drawing.Size(480, 28);
            this.labelPrograma.Name = "labelPrograma";
            this.labelPrograma.Size = new System.Drawing.Size(480, 28);
            this.labelPrograma.TabIndex = 28;
            this.labelPrograma.Text = "labelPrograma";
            this.labelPrograma.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelPrograma.Visible = false;
            // 
            // FVistaSeccionEmisiones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1055, 742);
            this.Name = "FVistaSeccionEmisiones";
            this.Load += new System.EventHandler(this.FVistaSeccionEmisiones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgBusquedaRapida)).EndInit();
            this.pnlSecBase.ResumeLayout(false);
            this.pestanyasSeccionBase.ResumeLayout(false);
            this.tpSeccionBaseConsultar.ResumeLayout(false);
            this.tpInsertar.ResumeLayout(false);
            this.splitContainerSeccionBase.Panel1.ResumeLayout(false);
            this.splitContainerSeccionBase.Panel2.ResumeLayout(false);
            this.splitContainerSeccionBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TbSeccionBaseErrorProvider)).EndInit();
            this.gBbuscarEmision.ResumeLayout(false);
            this.gBbuscarEmision.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUPMinutosBusc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGWEmisiones)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.gbInfo.ResumeLayout(false);
            this.gbInfo.PerformLayout();
            this.gbSistemaInfo.ResumeLayout(false);
            this.gbSistemaInfo.PerformLayout();
            this.gbPaginacion.ResumeLayout(false);
            this.gbPaginacion.PerformLayout();
            this.gBInsMod.ResumeLayout(false);
            this.gBInsMod.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUPMinutos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gBbuscarEmision;
        private System.Windows.Forms.Button btBuscar;
        private System.Windows.Forms.DataGridView dGWEmisiones;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gbInfo;
        private System.Windows.Forms.Label etInfo;
        private System.Windows.Forms.GroupBox gbSistemaInfo;
        private System.Windows.Forms.Label etSistemaInfo;
        private System.Windows.Forms.NumericUpDown nUPMinutosBusc;
        private System.Windows.Forms.Label labelDuracion;
        private System.Windows.Forms.DateTimePicker FechaHoraBusc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox gbPaginacion;
        private System.Windows.Forms.Label etPaginacionInfo;
        private System.Windows.Forms.Button btnPaginaPrimera;
        private System.Windows.Forms.Button btnPaginaAnterior;
        private System.Windows.Forms.Button btnPaginaUltima;
        private System.Windows.Forms.Button btnPaginaSiguiente;
        private System.Windows.Forms.Label etInfoPAG;
        private System.Windows.Forms.MaskedTextBox mtbRegistrosXPagina;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.RadioButton rBMenos;
        private System.Windows.Forms.RadioButton rBIgual;
        private System.Windows.Forms.RadioButton rBMas;
        private System.Windows.Forms.GroupBox gBInsMod;
        private System.Windows.Forms.Label labelMinutos;
        private System.Windows.Forms.NumericUpDown nUPMinutos;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker FechaHoraEmision;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btInsertar;
        private System.Windows.Forms.Button btLimpiar;
        private System.Windows.Forms.Label labelNomCadena;
        private System.Windows.Forms.Label labelPrograma;
        private System.Windows.Forms.ComboBox cbProgramaCON;
        private System.Windows.Forms.ComboBox cbCadenaCON;
        private System.Windows.Forms.ComboBox cbProgramaINS_MOD;
        private System.Windows.Forms.ComboBox cbCadenaINS_MOD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkPaginar;

    }
}
