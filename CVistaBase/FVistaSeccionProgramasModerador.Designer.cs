namespace TVO_VistaWindows
{
    partial class FVistaSeccionProgramasModerador
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
            this.cbCalificacion = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.eNombre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.etCadena = new System.Windows.Forms.Label();
            this.etNombrePrograma = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCadena = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescripcion = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colTematica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCalificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCritica = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colNovedad = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pestanyasSeccionBase.SuspendLayout();
            this.tpInsertar.SuspendLayout();
            this.pnlSeccionBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.pnlSecBase.SuspendLayout();
            this.tpSeccionBaseConsultar.SuspendLayout();
            this.splitContainerSeccionBase.Panel1.SuspendLayout();
            this.splitContainerSeccionBase.Panel2.SuspendLayout();
            this.splitContainerSeccionBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tpInsertar
            // 
            this.tpInsertar.Controls.Add(this.groupBox3);
            // 
            // etAccion
            // 
            this.etAccion.Size = new System.Drawing.Size(147, 21);
            this.etAccion.Text = "Catálogo programas";
            // 
            // splitContainerSeccionBase
            // 
            // 
            // splitContainerSeccionBase.Panel1
            // 
            this.splitContainerSeccionBase.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainerSeccionBase.Panel2
            // 
            this.splitContainerSeccionBase.Panel2.Controls.Add(this.groupBox2);
            // 
            // cbCalificacion
            // 
            this.cbCalificacion.FormattingEnabled = true;
            this.cbCalificacion.Items.AddRange(new object[] {
            "Para todos los publicos",
            "Mayores de 7 años",
            "Mayores de 13 años",
            "Mayores de 18 años"});
            this.cbCalificacion.Location = new System.Drawing.Point(23, 159);
            this.cbCalificacion.Name = "cbCalificacion";
            this.cbCalificacion.Size = new System.Drawing.Size(121, 21);
            this.cbCalificacion.TabIndex = 9;
            this.cbCalificacion.Text = "Selecciona criterio...";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Infantil",
            "Deportes",
            "Aventuras",
            "Corazón",
            "Documentales"});
            this.comboBox1.Location = new System.Drawing.Point(23, 103);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 8;
            this.comboBox1.Text = "Selecciona temática";
            // 
            // eNombre
            // 
            this.eNombre.Location = new System.Drawing.Point(67, 29);
            this.eNombre.Name = "eNombre";
            this.eNombre.Size = new System.Drawing.Size(100, 22);
            this.eNombre.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Calificación de edad";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(238, 212);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Buscar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Temática";
            // 
            // etCadena
            // 
            this.etCadena.AutoSize = true;
            this.etCadena.Location = new System.Drawing.Point(19, 58);
            this.etCadena.Name = "etCadena";
            this.etCadena.Size = new System.Drawing.Size(46, 13);
            this.etCadena.TabIndex = 2;
            this.etCadena.Text = "Cadena";
            // 
            // etNombrePrograma
            // 
            this.etNombrePrograma.AutoSize = true;
            this.etNombrePrograma.Location = new System.Drawing.Point(17, 33);
            this.etNombrePrograma.Name = "etNombrePrograma";
            this.etNombrePrograma.Size = new System.Drawing.Size(48, 13);
            this.etNombrePrograma.TabIndex = 1;
            this.etNombrePrograma.Text = "Nombre";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNombre,
            this.colCadena,
            this.colDescripcion,
            this.colTematica,
            this.colCalificacion,
            this.colCritica,
            this.colNovedad});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(10, 25);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(643, 479);
            this.dataGridView1.TabIndex = 0;
            // 
            // colNombre
            // 
            this.colNombre.HeaderText = "Nombre";
            this.colNombre.Name = "colNombre";
            // 
            // colCadena
            // 
            this.colCadena.HeaderText = "Cadena";
            this.colCadena.Name = "colCadena";
            // 
            // colDescripcion
            // 
            this.colDescripcion.HeaderText = "Ver descripción";
            this.colDescripcion.Name = "colDescripcion";
            // 
            // colTematica
            // 
            this.colTematica.HeaderText = "Temática";
            this.colTematica.Name = "colTematica";
            // 
            // colCalificacion
            // 
            this.colCalificacion.HeaderText = "Calificación de edad";
            this.colCalificacion.Name = "colCalificacion";
            // 
            // colCritica
            // 
            this.colCritica.HeaderText = "Ver/Realizar Crítica";
            this.colCritica.Name = "colCritica";
            // 
            // colNovedad
            // 
            this.colNovedad.HeaderText = "Novedad";
            this.colNovedad.Name = "colNovedad";
            this.colNovedad.ReadOnly = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(582, 236);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "Limpiar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(582, 265);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 75);
            this.button3.TabIndex = 12;
            this.button3.Text = "Hacer crítica";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(61, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Crítica";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(128, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(139, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Descripción del programa";
            // 
            // richTextBox2
            // 
            this.richTextBox2.BackColor = System.Drawing.Color.Gainsboro;
            this.richTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox2.Location = new System.Drawing.Point(64, 140);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(500, 200);
            this.richTextBox2.TabIndex = 9;
            this.richTextBox2.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(54, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Cadena";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(44, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Programa";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.eNombre);
            this.groupBox1.Controls.Add(this.cbCalificacion);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.etCadena);
            this.groupBox1.Controls.Add(this.etNombrePrograma);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(328, 250);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Búsqueda Avanzada";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(67, 55);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 10;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(10, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox2.Size = new System.Drawing.Size(663, 514);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Resultados de la búsqueda";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.richTextBox2);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1045, 544);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Nueva crítica";
            // 
            // FVistaSeccionProgramasModerador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1061, 750);
            this.Name = "FVistaSeccionProgramasModerador";
            this.pestanyasSeccionBase.ResumeLayout(false);
            this.tpInsertar.ResumeLayout(false);
            this.pnlSeccionBase.ResumeLayout(false);
            this.pnlSeccionBase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.pnlSecBase.ResumeLayout(false);
            this.tpSeccionBaseConsultar.ResumeLayout(false);
            this.splitContainerSeccionBase.Panel1.ResumeLayout(false);
            this.splitContainerSeccionBase.Panel2.ResumeLayout(false);
            this.splitContainerSeccionBase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cbCalificacion;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox eNombre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label etCadena;
        private System.Windows.Forms.Label etNombrePrograma;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCadena;
        private System.Windows.Forms.DataGridViewButtonColumn colDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTematica;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCalificacion;
        private System.Windows.Forms.DataGridViewButtonColumn colCritica;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colNovedad;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox comboBox2;
    }
}
