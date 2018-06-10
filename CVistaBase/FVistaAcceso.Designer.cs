namespace TVO_VistaWindows
{
    partial class FVistaAcceso
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
            this.btnValidar = new System.Windows.Forms.Button();
            this.etAcceso = new System.Windows.Forms.Label();
            this.eClave = new System.Windows.Forms.TextBox();
            this.eNIF = new System.Windows.Forms.TextBox();
            this.tClave = new System.Windows.Forms.Label();
            this.tNIF = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.etMensaje = new System.Windows.Forms.Label();
            this.pnlBotonesPortadaBase.SuspendLayout();
            this.pnlInfoPortadaBase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgPortadaBaseFoto)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBotonesPortadaBase
            // 
            this.pnlBotonesPortadaBase.Controls.Add(this.etMensaje);
            this.pnlBotonesPortadaBase.Controls.Add(this.label1);
            this.pnlBotonesPortadaBase.Controls.Add(this.btnValidar);
            this.pnlBotonesPortadaBase.Controls.Add(this.etAcceso);
            this.pnlBotonesPortadaBase.Controls.Add(this.eClave);
            this.pnlBotonesPortadaBase.Controls.Add(this.eNIF);
            this.pnlBotonesPortadaBase.Controls.Add(this.tClave);
            this.pnlBotonesPortadaBase.Controls.Add(this.tNIF);
            this.pnlBotonesPortadaBase.Controls.SetChildIndex(this.pnlInfoPortadaBase, 0);
            this.pnlBotonesPortadaBase.Controls.SetChildIndex(this.tNIF, 0);
            this.pnlBotonesPortadaBase.Controls.SetChildIndex(this.tClave, 0);
            this.pnlBotonesPortadaBase.Controls.SetChildIndex(this.eNIF, 0);
            this.pnlBotonesPortadaBase.Controls.SetChildIndex(this.eClave, 0);
            this.pnlBotonesPortadaBase.Controls.SetChildIndex(this.etAcceso, 0);
            this.pnlBotonesPortadaBase.Controls.SetChildIndex(this.btnValidar, 0);
            this.pnlBotonesPortadaBase.Controls.SetChildIndex(this.label1, 0);
            this.pnlBotonesPortadaBase.Controls.SetChildIndex(this.etMensaje, 0);
            // 
            // pnlInfoPortadaBase
            // 
            this.pnlInfoPortadaBase.Controls.Add(this.label2);
            this.pnlInfoPortadaBase.Controls.SetChildIndex(this.etBienvenido, 0);
            this.pnlInfoPortadaBase.Controls.SetChildIndex(this.linkCerrarApp, 0);
            this.pnlInfoPortadaBase.Controls.SetChildIndex(this.dateTimePicker1, 0);
            this.pnlInfoPortadaBase.Controls.SetChildIndex(this.linkFinSesion, 0);
            this.pnlInfoPortadaBase.Controls.SetChildIndex(this.etNombre, 0);
            this.pnlInfoPortadaBase.Controls.SetChildIndex(this.label2, 0);
            this.pnlInfoPortadaBase.Controls.SetChildIndex(this.imgPortadaBaseFoto, 0);
            // 
            // etNombre
            // 
            this.etNombre.Size = new System.Drawing.Size(0, 47);
            this.etNombre.Text = "";
            this.etNombre.Visible = false;
            // 
            // linkCerrarApp
            // 
            this.linkCerrarApp.Location = new System.Drawing.Point(255, 219);
            // 
            // linkFinSesion
            // 
            this.linkFinSesion.Size = new System.Drawing.Size(0, 13);
            this.linkFinSesion.TabStop = false;
            this.linkFinSesion.Text = "";
            this.linkFinSesion.Visible = false;
            // 
            // imgPortadaBaseFoto
            // 
            this.imgPortadaBaseFoto.Image = global::TVO_VistaWindows.Properties.Resources.Key;
            this.imgPortadaBaseFoto.Location = new System.Drawing.Point(347, 61);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(21, 212);
            this.dateTimePicker1.Visible = false;
            // 
            // etBienvenido
            // 
            this.etBienvenido.Size = new System.Drawing.Size(0, 30);
            this.etBienvenido.Text = "";
            this.etBienvenido.Visible = false;
            // 
            // btnValidar
            // 
            this.btnValidar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnValidar.ForeColor = System.Drawing.Color.FloralWhite;
            this.btnValidar.Location = new System.Drawing.Point(812, 173);
            this.btnValidar.Name = "btnValidar";
            this.btnValidar.Size = new System.Drawing.Size(82, 26);
            this.btnValidar.TabIndex = 3;
            this.btnValidar.Text = "Validar";
            this.btnValidar.UseVisualStyleBackColor = true;
            this.btnValidar.Click += new System.EventHandler(this.btnValidar_Click);
            // 
            // etAcceso
            // 
            this.etAcceso.AutoSize = true;
            this.etAcceso.Font = new System.Drawing.Font("Segoe UI Light", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.etAcceso.ForeColor = System.Drawing.Color.FloralWhite;
            this.etAcceso.Location = new System.Drawing.Point(571, 26);
            this.etAcceso.Name = "etAcceso";
            this.etAcceso.Size = new System.Drawing.Size(329, 54);
            this.etAcceso.TabIndex = 31;
            this.etAcceso.Text = "Control de Acceso";
            // 
            // eClave
            // 
            this.eClave.Location = new System.Drawing.Point(744, 128);
            this.eClave.Name = "eClave";
            this.eClave.Size = new System.Drawing.Size(150, 20);
            this.eClave.TabIndex = 2;
            this.eClave.UseSystemPasswordChar = true;
            this.eClave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.eClave_KeyDown);
            // 
            // eNIF
            // 
            this.eNIF.Location = new System.Drawing.Point(744, 102);
            this.eNIF.Name = "eNIF";
            this.eNIF.Size = new System.Drawing.Size(150, 20);
            this.eNIF.TabIndex = 1;
            this.eNIF.KeyDown += new System.Windows.Forms.KeyEventHandler(this.eNIF_KeyDown);
            // 
            // tClave
            // 
            this.tClave.AutoSize = true;
            this.tClave.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.tClave.Location = new System.Drawing.Point(704, 132);
            this.tClave.Name = "tClave";
            this.tClave.Size = new System.Drawing.Size(34, 13);
            this.tClave.TabIndex = 32;
            this.tClave.Text = "Clave";
            // 
            // tNIF
            // 
            this.tNIF.AutoSize = true;
            this.tNIF.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.tNIF.Location = new System.Drawing.Point(713, 106);
            this.tNIF.Name = "tNIF";
            this.tNIF.Size = new System.Drawing.Size(24, 13);
            this.tNIF.TabIndex = 33;
            this.tNIF.Text = "NIF";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Info;
            this.label1.Location = new System.Drawing.Point(739, 276);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Introduzca NIF y clave de acceso";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Light", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(131, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(363, 37);
            this.label2.TabIndex = 22;
            this.label2.Text = "TEVEO :: Aplicación de gestión";
            // 
            // etMensaje
            // 
            this.etMensaje.AutoSize = true;
            this.etMensaje.ForeColor = System.Drawing.Color.DarkRed;
            this.etMensaje.Location = new System.Drawing.Point(739, 258);
            this.etMensaje.Name = "etMensaje";
            this.etMensaje.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.etMensaje.Size = new System.Drawing.Size(95, 13);
            this.etMensaje.TabIndex = 37;
            this.etMensaje.Text = "Error de validación";
            this.etMensaje.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // FVistaAcceso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1061, 444);
            this.Name = "FVistaAcceso";
            this.Load += new System.EventHandler(this.FVistaAcceso_Load);
            this.Shown += new System.EventHandler(this.FVistaAcceso_Shown);
            this.Enter += new System.EventHandler(this.FVistaAcceso_Enter);
            this.pnlBotonesPortadaBase.ResumeLayout(false);
            this.pnlBotonesPortadaBase.PerformLayout();
            this.pnlInfoPortadaBase.ResumeLayout(false);
            this.pnlInfoPortadaBase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgPortadaBaseFoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnValidar;
        private System.Windows.Forms.Label etAcceso;
        private System.Windows.Forms.TextBox eClave;
        private System.Windows.Forms.TextBox eNIF;
        private System.Windows.Forms.Label tClave;
        private System.Windows.Forms.Label tNIF;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label etMensaje;

    }
}
