namespace TVO_VistaWindows
{
    partial class FVistaSeccionProgramas
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
            this.label5 = new System.Windows.Forms.Label();
            this.cBBCadena = new System.Windows.Forms.ComboBox();
            this.cBBCalificacion = new System.Windows.Forms.ComboBox();
            this.cBBTematica = new System.Windows.Forms.ComboBox();
            this.tBBNombreProg = new System.Windows.Forms.TextBox();
            this.buttonBuscar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dGVResultBProg = new System.Windows.Forms.DataGridView();
            this.cBActProg = new System.Windows.Forms.CheckBox();
            this.cBICadena = new System.Windows.Forms.ComboBox();
            this.cBICalificacion = new System.Windows.Forms.ComboBox();
            this.cBITematica = new System.Windows.Forms.ComboBox();
            this.tBNombreProg = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkPaginacion = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gBInsertModProg = new System.Windows.Forms.GroupBox();
            this.labelDescripcion = new System.Windows.Forms.Label();
            this.tBDescripcion = new System.Windows.Forms.TextBox();
            this.cBNovedad = new System.Windows.Forms.CheckBox();
            this.buttonInsertarProg = new System.Windows.Forms.Button();
            this.buttonLimpiarProg = new System.Windows.Forms.Button();
            this.gbMensajes = new System.Windows.Forms.GroupBox();
            this.labelMensSistPB = new System.Windows.Forms.Label();
            this.gBMensajesSist = new System.Windows.Forms.GroupBox();
            this.labelMensajeSist = new System.Windows.Forms.Label();
            this.gbPaginacion = new System.Windows.Forms.GroupBox();
            this.etPaginacionInfo = new System.Windows.Forms.Label();
            this.btnPaginaPrimera = new System.Windows.Forms.Button();
            this.btnPaginaAnterior = new System.Windows.Forms.Button();
            this.btnPaginaUltima = new System.Windows.Forms.Button();
            this.btnPaginaSiguiente = new System.Windows.Forms.Button();
            this.etInfoPAG = new System.Windows.Forms.Label();
            this.mtbRegistrosXPagina = new System.Windows.Forms.MaskedTextBox();
            this.label15 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TbSeccionBaseErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBusquedaRapida)).BeginInit();
            this.pnlSecBase.SuspendLayout();
            this.pestanyasSeccionBase.SuspendLayout();
            this.tpSeccionBaseConsultar.SuspendLayout();
            this.tpInsertar.SuspendLayout();
            this.splitContainerSeccionBase.Panel1.SuspendLayout();
            this.splitContainerSeccionBase.Panel2.SuspendLayout();
            this.splitContainerSeccionBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TbSeccionBaseErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGVResultBProg)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gBInsertModProg.SuspendLayout();
            this.gbMensajes.SuspendLayout();
            this.gBMensajesSist.SuspendLayout();
            this.gbPaginacion.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbBusquedaRapida
            // 
            this.tbBusquedaRapida.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic);
            // 
            // imgBusquedaRapida
            // 
            this.imgBusquedaRapida.Click += new System.EventHandler(this.imgBusquedaRapida_Click);
            // 
            // tpSeccionBaseConsultar
            // 
            this.tpSeccionBaseConsultar.Size = new System.Drawing.Size(1051, 556);
            // 
            // tpInsertar
            // 
            this.tpInsertar.Controls.Add(this.gBMensajesSist);
            this.tpInsertar.Controls.Add(this.gBInsertModProg);
            this.tpInsertar.Text = "Insertar";
            // 
            // splitContainerSeccionBase
            // 
            // 
            // splitContainerSeccionBase.Panel1
            // 
            this.splitContainerSeccionBase.Panel1.Controls.Add(this.gbMensajes);
            this.splitContainerSeccionBase.Panel1.Controls.Add(this.gbPaginacion);
            this.splitContainerSeccionBase.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainerSeccionBase.Panel2
            // 
            this.splitContainerSeccionBase.Panel2.Controls.Add(this.groupBox2);
            this.splitContainerSeccionBase.Size = new System.Drawing.Size(1045, 550);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Cadena";
            // 
            // cBBCadena
            // 
            this.cBBCadena.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cBBCadena.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cBBCadena.FormattingEnabled = true;
            this.cBBCadena.Location = new System.Drawing.Point(75, 171);
            this.cBBCadena.Name = "cBBCadena";
            this.cBBCadena.Size = new System.Drawing.Size(187, 21);
            this.cBBCadena.TabIndex = 13;
            // 
            // cBBCalificacion
            // 
            this.cBBCalificacion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cBBCalificacion.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cBBCalificacion.FormattingEnabled = true;
            this.cBBCalificacion.Location = new System.Drawing.Point(74, 126);
            this.cBBCalificacion.Name = "cBBCalificacion";
            this.cBBCalificacion.Size = new System.Drawing.Size(187, 21);
            this.cBBCalificacion.TabIndex = 10;
            // 
            // cBBTematica
            // 
            this.cBBTematica.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cBBTematica.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cBBTematica.FormattingEnabled = true;
            this.cBBTematica.Location = new System.Drawing.Point(67, 85);
            this.cBBTematica.Name = "cBBTematica";
            this.cBBTematica.Size = new System.Drawing.Size(195, 21);
            this.cBBTematica.TabIndex = 9;
            // 
            // tBBNombreProg
            // 
            this.tBBNombreProg.Location = new System.Drawing.Point(66, 39);
            this.tBBNombreProg.Name = "tBBNombreProg";
            this.tBBNombreProg.Size = new System.Drawing.Size(196, 22);
            this.tBBNombreProg.TabIndex = 8;
            this.tBBNombreProg.TextChanged += new System.EventHandler(this.buttonBuscar_Click);
            // 
            // buttonBuscar
            // 
            this.buttonBuscar.Location = new System.Drawing.Point(227, 255);
            this.buttonBuscar.Name = "buttonBuscar";
            this.buttonBuscar.Size = new System.Drawing.Size(80, 25);
            this.buttonBuscar.TabIndex = 7;
            this.buttonBuscar.Text = "Buscar";
            this.buttonBuscar.UseVisualStyleBackColor = true;
            this.buttonBuscar.Click += new System.EventHandler(this.buttonBuscar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Temática";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Calificación";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nombre";
            // 
            // dGVResultBProg
            // 
            this.dGVResultBProg.AllowUserToAddRows = false;
            this.dGVResultBProg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVResultBProg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGVResultBProg.Location = new System.Drawing.Point(10, 25);
            this.dGVResultBProg.Name = "dGVResultBProg";
            this.dGVResultBProg.ReadOnly = true;
            this.dGVResultBProg.Size = new System.Drawing.Size(643, 485);
            this.dGVResultBProg.TabIndex = 0;
            this.dGVResultBProg.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dGVResultBProg_CellMouseMove);
            this.dGVResultBProg.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGVResultBProg_CellClick);
            // 
            // cBActProg
            // 
            this.cBActProg.AutoSize = true;
            this.cBActProg.Checked = true;
            this.cBActProg.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBActProg.Location = new System.Drawing.Point(491, 57);
            this.cBActProg.Name = "cBActProg";
            this.cBActProg.Size = new System.Drawing.Size(113, 17);
            this.cBActProg.TabIndex = 24;
            this.cBActProg.Text = "Activar programa";
            this.cBActProg.UseVisualStyleBackColor = true;
            // 
            // cBICadena
            // 
            this.cBICadena.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cBICadena.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cBICadena.Location = new System.Drawing.Point(110, 177);
            this.cBICadena.Name = "cBICadena";
            this.cBICadena.Size = new System.Drawing.Size(250, 21);
            this.cBICadena.TabIndex = 21;
            // 
            // cBICalificacion
            // 
            this.cBICalificacion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cBICalificacion.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cBICalificacion.Location = new System.Drawing.Point(110, 136);
            this.cBICalificacion.Name = "cBICalificacion";
            this.cBICalificacion.Size = new System.Drawing.Size(250, 21);
            this.cBICalificacion.TabIndex = 20;
            // 
            // cBITematica
            // 
            this.cBITematica.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cBITematica.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cBITematica.Location = new System.Drawing.Point(110, 92);
            this.cBITematica.Name = "cBITematica";
            this.cBITematica.Size = new System.Drawing.Size(247, 21);
            this.cBITematica.TabIndex = 19;
            this.cBITematica.Text = " ";
            // 
            // tBNombreProg
            // 
            this.tBNombreProg.Location = new System.Drawing.Point(110, 55);
            this.tBNombreProg.Name = "tBNombreProg";
            this.tBNombreProg.Size = new System.Drawing.Size(250, 22);
            this.tBNombreProg.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 185);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Cadena";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 136);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Calificación";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 92);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Temática";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 55);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Nombre";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkPaginacion);
            this.groupBox1.Controls.Add(this.tBBNombreProg);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.buttonBuscar);
            this.groupBox1.Controls.Add(this.cBBCadena);
            this.groupBox1.Controls.Add(this.cBBTematica);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cBBCalificacion);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(328, 300);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Búsqueda Avanzada";
            // 
            // chkPaginacion
            // 
            this.chkPaginacion.AutoSize = true;
            this.chkPaginacion.Location = new System.Drawing.Point(11, 263);
            this.chkPaginacion.Name = "chkPaginacion";
            this.chkPaginacion.Size = new System.Drawing.Size(122, 17);
            this.chkPaginacion.TabIndex = 20;
            this.chkPaginacion.Text = "Paginar resultados";
            this.chkPaginacion.UseVisualStyleBackColor = true;
            this.chkPaginacion.CheckedChanged += new System.EventHandler(this.chkPaginacion_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dGVResultBProg);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(10, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox2.Size = new System.Drawing.Size(663, 520);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Resultados de la búsqueda";
            // 
            // gBInsertModProg
            // 
            this.gBInsertModProg.Controls.Add(this.labelDescripcion);
            this.gBInsertModProg.Controls.Add(this.tBDescripcion);
            this.gBInsertModProg.Controls.Add(this.cBNovedad);
            this.gBInsertModProg.Controls.Add(this.buttonInsertarProg);
            this.gBInsertModProg.Controls.Add(this.buttonLimpiarProg);
            this.gBInsertModProg.Controls.Add(this.cBActProg);
            this.gBInsertModProg.Controls.Add(this.label9);
            this.gBInsertModProg.Controls.Add(this.label8);
            this.gBInsertModProg.Controls.Add(this.label7);
            this.gBInsertModProg.Controls.Add(this.cBICadena);
            this.gBInsertModProg.Controls.Add(this.label6);
            this.gBInsertModProg.Controls.Add(this.cBICalificacion);
            this.gBInsertModProg.Controls.Add(this.tBNombreProg);
            this.gBInsertModProg.Controls.Add(this.cBITematica);
            this.gBInsertModProg.Location = new System.Drawing.Point(7, 36);
            this.gBInsertModProg.Name = "gBInsertModProg";
            this.gBInsertModProg.Size = new System.Drawing.Size(600, 500);
            this.gBInsertModProg.TabIndex = 25;
            this.gBInsertModProg.TabStop = false;
            this.gBInsertModProg.Text = "Nuevo Programa";
            // 
            // labelDescripcion
            // 
            this.labelDescripcion.AutoSize = true;
            this.labelDescripcion.Location = new System.Drawing.Point(21, 251);
            this.labelDescripcion.Name = "labelDescripcion";
            this.labelDescripcion.Size = new System.Drawing.Size(142, 13);
            this.labelDescripcion.TabIndex = 29;
            this.labelDescripcion.Text = "Descripción del programa:";
            // 
            // tBDescripcion
            // 
            this.tBDescripcion.Location = new System.Drawing.Point(34, 293);
            this.tBDescripcion.Multiline = true;
            this.tBDescripcion.Name = "tBDescripcion";
            this.tBDescripcion.Size = new System.Drawing.Size(550, 100);
            this.tBDescripcion.TabIndex = 28;
            // 
            // cBNovedad
            // 
            this.cBNovedad.AutoSize = true;
            this.cBNovedad.Checked = true;
            this.cBNovedad.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBNovedad.Location = new System.Drawing.Point(491, 105);
            this.cBNovedad.Name = "cBNovedad";
            this.cBNovedad.Size = new System.Drawing.Size(72, 17);
            this.cBNovedad.TabIndex = 27;
            this.cBNovedad.Text = "Novedad";
            this.cBNovedad.UseVisualStyleBackColor = true;
            // 
            // buttonInsertarProg
            // 
            this.buttonInsertarProg.Location = new System.Drawing.Point(509, 423);
            this.buttonInsertarProg.Name = "buttonInsertarProg";
            this.buttonInsertarProg.Size = new System.Drawing.Size(75, 23);
            this.buttonInsertarProg.TabIndex = 26;
            this.buttonInsertarProg.Text = "Insertar";
            this.buttonInsertarProg.UseVisualStyleBackColor = true;
            this.buttonInsertarProg.Click += new System.EventHandler(this.buttonInsertarProg_Click);
            // 
            // buttonLimpiarProg
            // 
            this.buttonLimpiarProg.Location = new System.Drawing.Point(402, 423);
            this.buttonLimpiarProg.Name = "buttonLimpiarProg";
            this.buttonLimpiarProg.Size = new System.Drawing.Size(75, 23);
            this.buttonLimpiarProg.TabIndex = 25;
            this.buttonLimpiarProg.Text = "Limpiar";
            this.buttonLimpiarProg.UseVisualStyleBackColor = true;
            this.buttonLimpiarProg.Click += new System.EventHandler(this.buttonLimpiarProg_Click);
            // 
            // gbMensajes
            // 
            this.gbMensajes.Controls.Add(this.labelMensSistPB);
            this.gbMensajes.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbMensajes.Location = new System.Drawing.Point(10, 410);
            this.gbMensajes.MaximumSize = new System.Drawing.Size(329, 100);
            this.gbMensajes.MinimumSize = new System.Drawing.Size(329, 100);
            this.gbMensajes.Name = "gbMensajes";
            this.gbMensajes.Size = new System.Drawing.Size(329, 100);
            this.gbMensajes.TabIndex = 16;
            this.gbMensajes.TabStop = false;
            this.gbMensajes.Text = "Mensajes del sistema";
            // 
            // labelMensSistPB
            // 
            this.labelMensSistPB.AutoSize = true;
            this.labelMensSistPB.Location = new System.Drawing.Point(15, 26);
            this.labelMensSistPB.Name = "labelMensSistPB";
            this.labelMensSistPB.Size = new System.Drawing.Size(98, 13);
            this.labelMensSistPB.TabIndex = 0;
            this.labelMensSistPB.Text = "labelMensajesSist";
            // 
            // gBMensajesSist
            // 
            this.gBMensajesSist.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gBMensajesSist.Controls.Add(this.labelMensajeSist);
            this.gBMensajesSist.Location = new System.Drawing.Point(617, 36);
            this.gBMensajesSist.Name = "gBMensajesSist";
            this.gBMensajesSist.Size = new System.Drawing.Size(420, 50);
            this.gBMensajesSist.TabIndex = 26;
            this.gBMensajesSist.TabStop = false;
            this.gBMensajesSist.Text = "Mensajes del sistema";
            // 
            // labelMensajeSist
            // 
            this.labelMensajeSist.AutoSize = true;
            this.labelMensajeSist.Location = new System.Drawing.Point(15, 26);
            this.labelMensajeSist.Name = "labelMensajeSist";
            this.labelMensajeSist.Size = new System.Drawing.Size(98, 13);
            this.labelMensajeSist.TabIndex = 0;
            this.labelMensajeSist.Text = "labelMensajesSist";
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
            this.gbPaginacion.Name = "gbPaginacion";
            this.gbPaginacion.Size = new System.Drawing.Size(328, 100);
            this.gbPaginacion.TabIndex = 18;
            this.gbPaginacion.TabStop = false;
            this.gbPaginacion.Text = "Paginación";
            this.gbPaginacion.Visible = false;
            // 
            // etPaginacionInfo
            // 
            this.etPaginacionInfo.AutoSize = true;
            this.etPaginacionInfo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.etPaginacionInfo.Location = new System.Drawing.Point(8, 46);
            this.etPaginacionInfo.MaximumSize = new System.Drawing.Size(150, 30);
            this.etPaginacionInfo.MinimumSize = new System.Drawing.Size(30, 30);
            this.etPaginacionInfo.Name = "etPaginacionInfo";
            this.etPaginacionInfo.Size = new System.Drawing.Size(136, 30);
            this.etPaginacionInfo.TabIndex = 15;
            this.etPaginacionInfo.Text = "Pulse \'Enter\' para aplicar cambios";
            this.etPaginacionInfo.Visible = false;
            // 
            // btnPaginaPrimera
            // 
            this.btnPaginaPrimera.BackColor = System.Drawing.Color.LightGray;
            this.btnPaginaPrimera.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPaginaPrimera.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPaginaPrimera.Location = new System.Drawing.Point(169, 69);
            this.btnPaginaPrimera.Name = "btnPaginaPrimera";
            this.btnPaginaPrimera.Size = new System.Drawing.Size(30, 25);
            this.btnPaginaPrimera.TabIndex = 14;
            this.btnPaginaPrimera.Text = "|<";
            this.btnPaginaPrimera.UseVisualStyleBackColor = false;
            this.btnPaginaPrimera.Click += new System.EventHandler(this.btnPaginaPrimera_Click);
            // 
            // btnPaginaAnterior
            // 
            this.btnPaginaAnterior.BackColor = System.Drawing.Color.LightGray;
            this.btnPaginaAnterior.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPaginaAnterior.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPaginaAnterior.Location = new System.Drawing.Point(205, 69);
            this.btnPaginaAnterior.Name = "btnPaginaAnterior";
            this.btnPaginaAnterior.Size = new System.Drawing.Size(30, 25);
            this.btnPaginaAnterior.TabIndex = 13;
            this.btnPaginaAnterior.Text = "<";
            this.btnPaginaAnterior.UseVisualStyleBackColor = false;
            this.btnPaginaAnterior.Click += new System.EventHandler(this.btnPaginaAnterior_Click);
            // 
            // btnPaginaUltima
            // 
            this.btnPaginaUltima.BackColor = System.Drawing.Color.LightGray;
            this.btnPaginaUltima.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPaginaUltima.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPaginaUltima.Location = new System.Drawing.Point(277, 69);
            this.btnPaginaUltima.Name = "btnPaginaUltima";
            this.btnPaginaUltima.Size = new System.Drawing.Size(30, 25);
            this.btnPaginaUltima.TabIndex = 12;
            this.btnPaginaUltima.Text = ">|";
            this.btnPaginaUltima.UseVisualStyleBackColor = false;
            this.btnPaginaUltima.Click += new System.EventHandler(this.btnPaginaUltima_Click);
            // 
            // btnPaginaSiguiente
            // 
            this.btnPaginaSiguiente.BackColor = System.Drawing.Color.LightGray;
            this.btnPaginaSiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPaginaSiguiente.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPaginaSiguiente.Location = new System.Drawing.Point(241, 69);
            this.btnPaginaSiguiente.Name = "btnPaginaSiguiente";
            this.btnPaginaSiguiente.Size = new System.Drawing.Size(30, 25);
            this.btnPaginaSiguiente.TabIndex = 11;
            this.btnPaginaSiguiente.Text = ">";
            this.btnPaginaSiguiente.UseVisualStyleBackColor = false;
            this.btnPaginaSiguiente.Click += new System.EventHandler(this.btnPaginaSiguiente_Click);
            // 
            // etInfoPAG
            // 
            this.etInfoPAG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.etInfoPAG.AutoSize = true;
            this.etInfoPAG.Location = new System.Drawing.Point(157, 46);
            this.etInfoPAG.MinimumSize = new System.Drawing.Size(165, 0);
            this.etInfoPAG.Name = "etInfoPAG";
            this.etInfoPAG.Size = new System.Drawing.Size(165, 13);
            this.etInfoPAG.TabIndex = 10;
            this.etInfoPAG.Text = "Página 1000 de 7555";
            this.etInfoPAG.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // mtbRegistrosXPagina
            // 
            this.mtbRegistrosXPagina.Location = new System.Drawing.Point(6, 21);
            this.mtbRegistrosXPagina.Mask = "09";
            this.mtbRegistrosXPagina.Name = "mtbRegistrosXPagina";
            this.mtbRegistrosXPagina.Size = new System.Drawing.Size(25, 22);
            this.mtbRegistrosXPagina.TabIndex = 9;
            this.mtbRegistrosXPagina.Text = "10";
            this.mtbRegistrosXPagina.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(37, 24);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(136, 13);
            this.label15.TabIndex = 8;
            this.label15.Text = "Filas por página (mín. 10)";
            // 
            // FVistaSeccionProgramas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1061, 750);
            this.Name = "FVistaSeccionProgramas";
            this.Load += new System.EventHandler(this.FVistaSeccionProgramas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgBusquedaRapida)).EndInit();
            this.pnlSecBase.ResumeLayout(false);
            this.pestanyasSeccionBase.ResumeLayout(false);
            this.tpSeccionBaseConsultar.ResumeLayout(false);
            this.tpInsertar.ResumeLayout(false);
            this.splitContainerSeccionBase.Panel1.ResumeLayout(false);
            this.splitContainerSeccionBase.Panel2.ResumeLayout(false);
            this.splitContainerSeccionBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TbSeccionBaseErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGVResultBProg)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.gBInsertModProg.ResumeLayout(false);
            this.gBInsertModProg.PerformLayout();
            this.gbMensajes.ResumeLayout(false);
            this.gbMensajes.PerformLayout();
            this.gBMensajesSist.ResumeLayout(false);
            this.gBMensajesSist.PerformLayout();
            this.gbPaginacion.ResumeLayout(false);
            this.gbPaginacion.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cBBCalificacion;
        private System.Windows.Forms.ComboBox cBBTematica;
        private System.Windows.Forms.TextBox tBBNombreProg;
        private System.Windows.Forms.Button buttonBuscar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dGVResultBProg;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cBBCadena;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox gBInsertModProg;
        private System.Windows.Forms.CheckBox cBActProg;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cBICadena;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cBICalificacion;
        private System.Windows.Forms.TextBox tBNombreProg;
        private System.Windows.Forms.ComboBox cBITematica;
        private System.Windows.Forms.Button buttonInsertarProg;
        private System.Windows.Forms.Button buttonLimpiarProg;
        private System.Windows.Forms.GroupBox gbMensajes;
        private System.Windows.Forms.Label labelMensSistPB;
        private System.Windows.Forms.GroupBox gBMensajesSist;
        private System.Windows.Forms.Label labelMensajeSist;
        private System.Windows.Forms.TextBox tBDescripcion;
        private System.Windows.Forms.CheckBox cBNovedad;
        private System.Windows.Forms.Label labelDescripcion;
        private System.Windows.Forms.GroupBox gbPaginacion;
        private System.Windows.Forms.Label etPaginacionInfo;
        private System.Windows.Forms.Button btnPaginaPrimera;
        private System.Windows.Forms.Button btnPaginaAnterior;
        private System.Windows.Forms.Button btnPaginaUltima;
        private System.Windows.Forms.Button btnPaginaSiguiente;
        private System.Windows.Forms.Label etInfoPAG;
        private System.Windows.Forms.MaskedTextBox mtbRegistrosXPagina;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox chkPaginacion;
    }
}
