namespace TVO_VistaWindows
{
    partial class FVistaSeccionXML
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
            this.btnConfigurar = new System.Windows.Forms.Button();
            this.btnGenrarXML = new System.Windows.Forms.Button();
            this.btnCarga = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.gbXMLTV = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gbInfoXML = new System.Windows.Forms.GroupBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.etInfoXML = new System.Windows.Forms.Label();
            this.gbResultados = new System.Windows.Forms.GroupBox();
            this.etRespuesta = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.TbSeccionBaseErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBusquedaRapida)).BeginInit();
            this.pnlSecBase.SuspendLayout();
            this.pestanyasSeccionBase.SuspendLayout();
            this.tpSeccionBaseConsultar.SuspendLayout();
            this.splitContainerSeccionBase.Panel1.SuspendLayout();
            this.splitContainerSeccionBase.Panel2.SuspendLayout();
            this.splitContainerSeccionBase.SuspendLayout();
            this.gbXMLTV.SuspendLayout();
            this.gbInfoXML.SuspendLayout();
            this.gbResultados.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbBusquedaRapida
            // 
            this.tbBusquedaRapida.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic);
            this.tbBusquedaRapida.Text = "";
            this.tbBusquedaRapida.Visible = false;
            // 
            // imgBusquedaRapida
            // 
            this.imgBusquedaRapida.Visible = false;
            // 
            // splitContainerSeccionBase
            // 
            // 
            // splitContainerSeccionBase.Panel1
            // 
            this.splitContainerSeccionBase.Panel1.Controls.Add(this.gbInfoXML);
            this.splitContainerSeccionBase.Panel1.Controls.Add(this.gbXMLTV);
            // 
            // splitContainerSeccionBase.Panel2
            // 
            this.splitContainerSeccionBase.Panel2.Controls.Add(this.gbResultados);
            // 
            // btnConfigurar
            // 
            this.btnConfigurar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfigurar.Location = new System.Drawing.Point(23, 70);
            this.btnConfigurar.Name = "btnConfigurar";
            this.btnConfigurar.Size = new System.Drawing.Size(150, 23);
            this.btnConfigurar.TabIndex = 0;
            this.btnConfigurar.Text = "Crear configuración";
            this.btnConfigurar.UseVisualStyleBackColor = true;
            this.btnConfigurar.Click += new System.EventHandler(this.btnConfigurar_Click);
            // 
            // btnGenrarXML
            // 
            this.btnGenrarXML.Location = new System.Drawing.Point(23, 159);
            this.btnGenrarXML.Name = "btnGenrarXML";
            this.btnGenrarXML.Size = new System.Drawing.Size(150, 23);
            this.btnGenrarXML.TabIndex = 1;
            this.btnGenrarXML.Text = "Obtener  XML";
            this.btnGenrarXML.UseVisualStyleBackColor = true;
            this.btnGenrarXML.Click += new System.EventHandler(this.btnGenerarXML_Click);
            // 
            // btnCarga
            // 
            this.btnCarga.Location = new System.Drawing.Point(144, 262);
            this.btnCarga.Name = "btnCarga";
            this.btnCarga.Size = new System.Drawing.Size(170, 23);
            this.btnCarga.TabIndex = 2;
            this.btnCarga.Text = "Almacenar programación";
            this.btnCarga.UseVisualStyleBackColor = true;
            this.btnCarga.Click += new System.EventHandler(this.btnCarga_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label1.Location = new System.Drawing.Point(20, 22);
            this.label1.MaximumSize = new System.Drawing.Size(200, 45);
            this.label1.MinimumSize = new System.Drawing.Size(200, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 45);
            this.label1.TabIndex = 3;
            this.label1.Text = "1. Ejecute Crear Configuración si es la primera vez que usa XMLTV en esta máquina" +
                "";
            // 
            // gbXMLTV
            // 
            this.gbXMLTV.Controls.Add(this.label3);
            this.gbXMLTV.Controls.Add(this.btnCarga);
            this.gbXMLTV.Controls.Add(this.btnConfigurar);
            this.gbXMLTV.Controls.Add(this.btnGenrarXML);
            this.gbXMLTV.Controls.Add(this.label1);
            this.gbXMLTV.Controls.Add(this.label2);
            this.gbXMLTV.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbXMLTV.Location = new System.Drawing.Point(10, 10);
            this.gbXMLTV.Name = "gbXMLTV";
            this.gbXMLTV.Size = new System.Drawing.Size(328, 300);
            this.gbXMLTV.TabIndex = 4;
            this.gbXMLTV.TabStop = false;
            this.gbXMLTV.Text = "XMLTV";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 201);
            this.label3.MaximumSize = new System.Drawing.Size(275, 45);
            this.label3.MinimumSize = new System.Drawing.Size(275, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(275, 45);
            this.label3.TabIndex = 5;
            this.label3.Text = "3. Actualización de la Base de Datos. Se vuelca el contenido de los datos interno" +
                "s a la BD.\r\n";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 112);
            this.label2.MaximumSize = new System.Drawing.Size(225, 40);
            this.label2.MinimumSize = new System.Drawing.Size(225, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(225, 40);
            this.label2.TabIndex = 4;
            this.label2.Text = "2. Genere el fichero hoy.xml con la programación de hoy. Lectura del XML y creaci" +
                "ón de estructuras de datos internas.\r\n";
            // 
            // gbInfoXML
            // 
            this.gbInfoXML.Controls.Add(this.btnLimpiar);
            this.gbInfoXML.Controls.Add(this.etInfoXML);
            this.gbInfoXML.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbInfoXML.Location = new System.Drawing.Point(10, 310);
            this.gbInfoXML.MaximumSize = new System.Drawing.Size(328, 50);
            this.gbInfoXML.MinimumSize = new System.Drawing.Size(328, 100);
            this.gbInfoXML.Name = "gbInfoXML";
            this.gbInfoXML.Size = new System.Drawing.Size(328, 100);
            this.gbInfoXML.TabIndex = 22;
            this.gbInfoXML.TabStop = false;
            this.gbInfoXML.Text = "Mensaje del sistema";
            this.gbInfoXML.Visible = false;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(240, 63);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 1;
            this.btnLimpiar.Text = "Limpiar >>";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // etInfoXML
            // 
            this.etInfoXML.AutoSize = true;
            this.etInfoXML.Location = new System.Drawing.Point(15, 26);
            this.etInfoXML.MaximumSize = new System.Drawing.Size(300, 60);
            this.etInfoXML.MinimumSize = new System.Drawing.Size(300, 60);
            this.etInfoXML.Name = "etInfoXML";
            this.etInfoXML.Size = new System.Drawing.Size(300, 60);
            this.etInfoXML.TabIndex = 0;
            this.etInfoXML.Text = "label13";
            // 
            // gbResultados
            // 
            this.gbResultados.Controls.Add(this.etRespuesta);
            this.gbResultados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbResultados.Location = new System.Drawing.Point(10, 10);
            this.gbResultados.Name = "gbResultados";
            this.gbResultados.Padding = new System.Windows.Forms.Padding(10);
            this.gbResultados.Size = new System.Drawing.Size(663, 514);
            this.gbResultados.TabIndex = 21;
            this.gbResultados.TabStop = false;
            this.gbResultados.Text = "Resultados";
            // 
            // etRespuesta
            // 
            this.etRespuesta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.etRespuesta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.etRespuesta.Location = new System.Drawing.Point(10, 25);
            this.etRespuesta.Name = "etRespuesta";
            this.etRespuesta.ReadOnly = true;
            this.etRespuesta.Size = new System.Drawing.Size(643, 479);
            this.etRespuesta.TabIndex = 0;
            this.etRespuesta.Text = "";
            // 
            // FVistaSeccionXML
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1061, 750);
            this.Name = "FVistaSeccionXML";
            ((System.ComponentModel.ISupportInitialize)(this.TbSeccionBaseErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBusquedaRapida)).EndInit();
            this.pnlSecBase.ResumeLayout(false);
            this.pestanyasSeccionBase.ResumeLayout(false);
            this.tpSeccionBaseConsultar.ResumeLayout(false);
            this.splitContainerSeccionBase.Panel1.ResumeLayout(false);
            this.splitContainerSeccionBase.Panel2.ResumeLayout(false);
            this.splitContainerSeccionBase.ResumeLayout(false);
            this.gbXMLTV.ResumeLayout(false);
            this.gbXMLTV.PerformLayout();
            this.gbInfoXML.ResumeLayout(false);
            this.gbInfoXML.PerformLayout();
            this.gbResultados.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConfigurar;
        private System.Windows.Forms.Button btnGenrarXML;
        private System.Windows.Forms.Button btnCarga;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbXMLTV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gbInfoXML;
        private System.Windows.Forms.Label etInfoXML;
        public System.Windows.Forms.GroupBox gbResultados;
        private System.Windows.Forms.RichTextBox etRespuesta;
        private System.Windows.Forms.Button btnLimpiar;
    }
}
