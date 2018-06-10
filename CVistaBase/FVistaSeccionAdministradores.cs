////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	CVistaBase\FVistaSeccionAdministradores.cs
//
// summary:	Implementa la clase visual FVistaSeccionAdministradores
////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TVO_Utiles;
using TVO_EntidadesDeNegocio;
using System.Collections;

////////////////////////////////////////////////////////////////////////////////////////////////////
// namespace: TVO_VistaWindows
//
// summary:	Espacio de nombres TVO_VistaWindows.
////////////////////////////////////////////////////////////////////////////////////////////////////
namespace TVO_VistaWindows
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Vista seccion administradores. </summary>
    ///
    /// <remarks>   . </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public partial class FVistaSeccionAdministradores : TVO_VistaWindows.FVistaSeccionBase
    {

        /// <summary> Atributo privado estático y de sólo lectura instancia.  </summary>
        /// <value>Representa la instancia de la ventana abierta, que se única por ejecución.</value>
        private static readonly FVistaSeccionAdministradores instancia = new FVistaSeccionAdministradores();

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Busquedas. </summary>
        ///
        /// <remarks>   Vmolero, 13/04/2010. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        delegate void Busqueda(object sender, EventArgs e);
        /// <summary> The metodo busqueda </summary>
        Busqueda MetodoBusqueda;

        private byte[] imagen;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor privado por defecto. Se inicializan los componentes visuales.</summary>
        ///
        /// <remarks>   . </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private FVistaSeccionAdministradores() : base() 
        {
            InitializeComponent();
            this.etSeccion.Text = "Gestión de Administradores";
            this.etAccion.Text = "CONSULTAR";
            pestanyasSeccionBase.GetControl(1).Text = "Insertar";
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Devuelve la instancia de la clase. </summary>
        ///
        /// <value> instancia. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static FVistaSeccionAdministradores Instancia
        {
          get 
          {
              return instancia; 
          }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Método sobreescrito Init. Inicializa el formulario. </summary>
        ///
        /// <remarks>   . </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        override public void Init()
        {
            base.Init();
            MetodoBusqueda = btnBuscar_Click;
            TbSeccionBaseErrorProvider.Dispose();
            gbInfoINS_MOD.Visible = false;
            dgvPersonas.Visible = false;
            ActilizaVistaForm("defecto");
            mtbRegistrosXPagina.Text = PAGINA_registros.ToString();
            ACTUAL_registro = 1;
            TOTAL_registros = dgvPersonas.RowCount;
            MensajePaginacion(etInfoPAG, 1, getNumPaginasTotales());
            btnPaginaAnterior.Visible = false;
            btnPaginaPrimera.Visible = false;
            imagen = null;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Método privado InicializarDataGridView. Inicializa el DataGrid con datos por primera 
        /// vez, además añade la fila de botones. </summary>
        ///
        /// <remarks>   . </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private void InicializarDataGridView()
        {
            DataView dv = new DataView();
           
            DataGridViewButtonColumn colBotonesMod = new DataGridViewButtonColumn();
            colBotonesMod.UseColumnTextForButtonValue = true;
            colBotonesMod.Text = "Mod";
            colBotonesMod.Width = 40;
            colBotonesMod.Name = "btnModificar";
            colBotonesMod.HeaderText = "";

            DataGridViewButtonColumn colBotonesElim = new DataGridViewButtonColumn();
            colBotonesElim.UseColumnTextForButtonValue = true;
            colBotonesElim.Text = "Elim";
            colBotonesElim.Width = 40;
            colBotonesElim.Name = "btnEliminar";
            colBotonesElim.HeaderText = "";

            dgvPersonas.Columns.Insert(0, colBotonesMod);
            dgvPersonas.Columns.Insert(1, colBotonesElim);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Método privado darFormatoDataGrid. Se establecen los anchos de las columnas del 
        /// DataGrid y se actualizan los títulos de las cabeceras. </summary>
        ///
        /// <remarks>   . </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private void darFormatoDataGrid()
        {
            dgvPersonas.RowHeadersVisible = false;
            
            dgvPersonas.Columns["nif"].Width = 65;
            dgvPersonas.Columns["nombre"].Width = 120;
            dgvPersonas.Columns["direccion"].Width = 350;
            dgvPersonas.Columns["email"].Width = 160;
            dgvPersonas.Columns["telefono"].Width = 70;
            dgvPersonas.Columns["perfil"].Width = 50;
            dgvPersonas.Columns["ccc"].Width = 160;
            
            dgvPersonas.Columns["nif"].HeaderText = "NIF";
            dgvPersonas.Columns["nombre"].HeaderText = "Apellidos, Nombre";
            dgvPersonas.Columns["direccion"].HeaderText = "Dirección";
            dgvPersonas.Columns["email"].HeaderText = "E. Mail";
            dgvPersonas.Columns["email"].DefaultCellStyle.ForeColor = Color.Blue;
            dgvPersonas.Columns["telefono"].HeaderText = "Teléfono";
            dgvPersonas.Columns["perfil"].HeaderText = "Perfil";
            dgvPersonas.Columns["ccc"].HeaderText = "Cuenta bancaria";

            dgvPersonas.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
            dgvPersonas.TabStop = false;

        }

       
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Manejador de Evento. Llamado por mtbNIF para el evento LEAVE. </summary>
        ///
        /// <remarks>   . </remarks>
        ///
        /// <param name="sender">   Origen del evento. </param>
        /// <param name="e">        Información del evento. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private void mtbNIF_Leave(object sender, EventArgs e)
        {
            if (!Validacion.NifValido(mtbNIF.Text))
            {
                TbSeccionBaseErrorProvider.SetIconAlignment(mtbNIF, ErrorIconAlignment.MiddleRight);
                TbSeccionBaseErrorProvider.SetIconPadding(mtbNIF, 2);
                TbSeccionBaseErrorProvider.SetError(mtbNIF, "Formato de NIF incorrecto.");
            }
            else
            {
                TbSeccionBaseErrorProvider.SetError(mtbNIF, "");
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by btnFoto for click events. </summary>
        ///
        /// <remarks>   . </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
         private void btnFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFich = new OpenFileDialog();
            OFich.Filter = "jpg (*.jpg)|*.jpg";
            System.IO.Stream stream;
            imgFotoINS_MOD.SizeMode = PictureBoxSizeMode.StretchImage;
            

            if (OFich.ShowDialog() == DialogResult.OK)
            {
                stream = OFich.OpenFile();
                byte[] imageData = new byte[stream.Length];
                //Leer la imagen en un array de bytes
                stream.Read(imageData, 0, (int)stream.Length);
                imgFotoINS_MOD.Image = System.Drawing.Image.FromFile(OFich.FileName);

                this.imagen = imageData;
                
                // al.Ruta = OFich.FileName;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by tbMail for leave events. </summary>
        ///
        /// <remarks>   . </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private void tbMail_Leave(object sender, EventArgs e)
        {
            if (!Validacion.EmailValido(tbMail.Text))
            {
                TbSeccionBaseErrorProvider.SetIconAlignment(tbMail, ErrorIconAlignment.MiddleRight);
                TbSeccionBaseErrorProvider.SetIconPadding(tbMail, 2);
                TbSeccionBaseErrorProvider.SetError(tbMail, "Formato de eMail incorrecto.");
            }
            else
            {
                TbSeccionBaseErrorProvider.SetError(tbMail, "");
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by tbClave for leave events. </summary>
        ///
        /// <remarks>   . </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private void tbClave_Leave(object sender, EventArgs e)
        {
            if (tbClave.Text == "")
            {
                TbSeccionBaseErrorProvider.SetIconAlignment(tbClave, ErrorIconAlignment.MiddleRight);
                TbSeccionBaseErrorProvider.SetIconPadding(tbClave, 2);
                TbSeccionBaseErrorProvider.SetError(tbClave, "Debes proporcionar una clave de acceso.");
            }
            else
            {
                TbSeccionBaseErrorProvider.SetError(tbClave, "");
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Mátodo privado. Validar entrada. Realiza la validación del NIF, correo electrónico
        /// y de la clave de acceso (no vacía).</summary>
        ///
        /// <remarks>   . </remarks>
        ///
        /// <returns>   EL propio objeto ENPersona. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private ENPersona ValidarEntrada()
        {
            bool testNIF = false;
            bool testEMAIL = false;
            bool testClave = false;

            testNIF = Validacion.NifValido(mtbNIF.Text);
            testEMAIL = Validacion.EmailValido(tbMail.Text); 
            testClave = (tbClave.Text != "");

            ENPersona nuevo_admin = new ENPersona();

           
                if (testNIF && testEMAIL && testClave)
                {
                    nuevo_admin.Dni = mtbNIF.Text;
                    nuevo_admin.Clave = tbClave.Text;
                    nuevo_admin.Nombre = tbNombre.Text;
                    nuevo_admin.Apellidos = tbApellidos.Text;
                    nuevo_admin.Direccion = tbDireccion.Text;
                    nuevo_admin.Poblacion = tbPoblacion.Text;
                    nuevo_admin.CP = mtbCP.Text;
                    nuevo_admin.Provincia = cbProvincia.SelectedIndex;
                    nuevo_admin.Email = tbMail.Text;
                    nuevo_admin.Telefono = mtbTelefono.Text;
                    nuevo_admin.CCC = mtbCCC.Text;
                    nuevo_admin.Perfil = (kPerfil)cbAdministrador.SelectedIndex;
                    if (this.imagen != null) nuevo_admin.ImgData = this.imagen;
                }
                else {
                    string mensaje="", mensajeNIF="", mensajeEMAIL="", mensajeClave="";
                    if (!testNIF) mensajeNIF = "\nNIF incorrecto.";
                    if (!testEMAIL) mensajeEMAIL = "\nEMAIL incorrecto.";
                    if (!testClave) mensajeClave = "\nCLAVE vacía. ";
                    
                    mensaje = mensajeNIF + mensajeEMAIL + mensajeClave;
                    Exception ex = new Exception(mensaje);
                    throw ex;
                }
                

            return nuevo_admin;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by btnInsertar for click events. </summary>
        ///
        /// <remarks>   . </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            int estado = -1;
            
            ENPersona nuevo_admin = new ENPersona();

            try
            {
                nuevo_admin = ValidarEntrada();
                if (btnInsertar.Text == "Insertar")
                {
                    estado = nuevo_admin.insertarPersona();
                    
                    if (estado == 1)
                    {
                        MensajeSistema(etInfoINS_MOD, "Registro introducido correctamente.", kMensajeSistema.mCORRECTO);
                        gbInfoINS_MOD.Visible = true;
                    }

                }
                else if (btnInsertar.Text == "Modificar")
                {
                    estado = nuevo_admin.modificarPersona();

                    if (estado == 1)
                    {
                        MensajeSistema(etInfoINS_MOD, "Registro modificado correctamente.", kMensajeSistema.mCORRECTO);
                        gbInfoINS_MOD.Visible = true;
                    }
                }
                gbInfoINS_MOD.Visible = true;
            }
            catch (ENException enex)
            {
                MensajeSistema(etInfoINS_MOD, enex.Message, kMensajeSistema.mERROR);
                gbInfoINS_MOD.Visible = true;
            }
            catch (Exception ex)
            {
                MensajeSistema(etInfoINS_MOD, ex.Message, kMensajeSistema.mADVERTENCIA);
                gbInfoINS_MOD.Visible = true;
            }
            
            
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by btnBuscar for click events. </summary>
        ///
        /// <remarks>   . </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            MetodoBusqueda = btnBuscar_Click;
            DataView dvResultado = new DataView();
            kPerfil p = (kPerfil)cbPerfilBuscar.SelectedIndex-1;

            try
            {
                if (Paginar)
                {
                    // Obtenemos el tamaño de la consulta
                    TOTAL_registros = administrador.obtenerTamanyoConsulta(mtbNIFBuscar.Text, tbNombreBuscar.Text, tbEmailBuscar.Text, p);
                    
                    // Si el total de filas es inferior al número de resgistros por página, se desactiva la paginación
                    if (TOTAL_registros <= MIN_PAGINA_registros)
                    {
                        throw new Exception("Excepción de paginación");
                    }
                    else
                    {
                        // Si el total de filas obtenidas es menos que el registro que estabamos mostrando -> actualizamos el registro actual
                        if (esDesbordamientoPagina(ACTUAL_registro))
                        {
                            ACTUAL_registro = TOTAL_registros - (TOTAL_registros % PAGINA_registros) + 1;
                            
                        }
                        else if (esUltimaPagina(ACTUAL_registro))
                        {
                            btnPaginaSiguiente.Visible = false;
                            btnPaginaUltima.Visible = false;
                        }
                        else
                        {
                            btnPaginaSiguiente.Visible = true;
                            btnPaginaUltima.Visible = true;
                        }
                        MensajePaginacion(etInfoPAG, getNumPaginaActual(ACTUAL_registro), getNumPaginasTotales());
                        dvResultado = administrador.obtenerPersonas(mtbNIFBuscar.Text, tbNombreBuscar.Text, tbEmailBuscar.Text, p, ACTUAL_registro, PAGINA_registros);
                    }
                }
                else
                {
                    dvResultado = administrador.obtenerPersonas(mtbNIFBuscar.Text, tbNombreBuscar.Text, tbEmailBuscar.Text, p);
                    TOTAL_registros = dvResultado.Table.Rows.Count;
                    if (TOTAL_registros <= MIN_PAGINA_registros) chkPaginacion.Enabled = false;
                    else chkPaginacion.Enabled = true;
                }
                dgvPersonas.DataSource = dvResultado;

                if (dvResultado.Count > 0) darFormatoDataGrid();
                gbInfoCON.Visible = true;

                if (dvResultado.Count == 0) dgvPersonas.Visible = false;
                else dgvPersonas.Visible = true;

                if (dvResultado.Count == 1)
                    MensajeSistema(etInfoCON, "Se ha obtenido 1 resultado.", kMensajeSistema.mCORRECTO);
                else MensajeSistema(etInfoCON, "Se han obtenido " + dvResultado.Count + " resultados.", kMensajeSistema.mCORRECTO);
            }
            catch (ENException enex)
            {
                if (enex.Tipo != -1)
                {
                    MensajeSistema(etInfoCON, enex.Message, kMensajeSistema.mADVERTENCIA);
                }
                else MensajeSistema(etInfoCON, enex.Message, kMensajeSistema.mERROR);

                gbInfoCON.Visible = true;
            }
            catch (Exception ex)
            {
                chkPaginacion.Checked = false;
                chkPaginacion_CheckedChanged((CheckBox)chkPaginacion, null);
                MensajeSistema(etInfoCON, "Se ha desactivado la paginación debido a que sólo hay 1 página", kMensajeSistema.mADVERTENCIA);
                chkPaginacion.Enabled = false;
            }
            
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by btnLimpiar for click events. </summary>
        ///
        /// <remarks>   . </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            if (btnInsertar.Text == "Insertar") 
                mtbNIF.Text = "";
            tbClave.Text = "";
            tbNombre.Text = "";
            tbApellidos.Text = "";
            tbDireccion.Text = "";
            tbPoblacion.Text = "";
            mtbCP.Text = "";
            cbProvincia.SelectedIndex = 0;
            tbMail.Text = "";
            mtbTelefono.Text = "";
            mtbCCC.Text = "";
            imagen = null;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Rellenar comboxes. </summary>
        ///
        /// <remarks>   . </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void RellenarComboxes()
        {
            cbPerfilBuscar.Items.Add("Todos los perfiles");
            cbPerfilBuscar.SelectedIndex = 0;
            
            
            ArrayList vPerfiles = new ArrayList();
            DataView dvProvincias = new DataView();
            try
            {
                vPerfiles = administrador.obtenerPerfiles();

                foreach (string perfil in vPerfiles)
                {
                    cbPerfilBuscar.Items.Add(perfil);
                    cbAdministrador.Items.Add(perfil);
                }

                dvProvincias = administrador.obtenerProvincias();
                cbProvincia.DataSource = dvProvincias;
                cbProvincia.DisplayMember = "nombre";
            }
            catch (ENException enex)
            {
                MensajeSistema(etInfoCON, enex.Message, kMensajeSistema.mERROR);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by FVistaSeccionAdministradores for load events. </summary>
        ///
        /// <remarks>   . </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FVistaSeccionAdministradores_Load(object sender, EventArgs e)
        {
            InicializarDataGridView();
            RellenarComboxes();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by dgvPersonas for cell click events. </summary>
        ///
        /// <remarks>   . </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Data grid view cell event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void dgvPersonas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1) throw new Exception();

                if (dgvPersonas.Columns[e.ColumnIndex].Name == "btnModificar")
                {
                    mtbNIF.Text = administrador.obtenerDelDataSet("Personas", e.RowIndex, "nif"); // dgvPersonas.Rows[e.RowIndex].Cells["nif"].Value.ToString();
                    tbClave.Text = administrador.obtenerDelDataSet("Personas", e.RowIndex, "clave");
                    tbNombre.Text = administrador.obtenerDelDataSet("Personas", e.RowIndex, "nombre");
                    tbApellidos.Text = administrador.obtenerDelDataSet("Personas", e.RowIndex, "apellidos");
                    tbDireccion.Text = administrador.obtenerDelDataSet("Personas", e.RowIndex, "direccion");
                    tbPoblacion.Text = administrador.obtenerDelDataSet("Personas", e.RowIndex, "poblacion");
                    mtbCP.Text = administrador.obtenerDelDataSet("Personas", e.RowIndex, "CP");
                    cbProvincia.SelectedIndex = Convert.ToInt32(administrador.obtenerDelDataSet("Personas", e.RowIndex, "IDprovincia"));
                    tbMail.Text = administrador.obtenerDelDataSet("Personas", e.RowIndex, "email");
                    mtbTelefono.Text = administrador.obtenerDelDataSet("Personas", e.RowIndex, "telefono");
                    mtbCCC.Text = administrador.obtenerDelDataSet("Personas", e.RowIndex, "ccc");
                    cbAdministrador.SelectedIndex = int.Parse(administrador.obtenerDelDataSet("Personas", e.RowIndex, "IDperfil"));

                    byte[] img = administrador.obtenerImagenDelDataSet("Personas", e.RowIndex, "foto");
                    if (img != null)
                    {
                        System.IO.Stream ms = new System.IO.MemoryStream(img);
                        System.Drawing.Bitmap miImagen = new Bitmap(ms);
                        imgFotoINS_MOD.Image = (Image)miImagen;
                    }


                    ActilizaVistaForm("modificar");
                    pestanyasSeccionBase.SelectTab(pestanyasSeccionBase.GetControl(1).Name);
                }
                else if (dgvPersonas.Columns[e.ColumnIndex].Name == "btnEliminar")
                {
                    string nif = administrador.obtenerDelDataSet("Personas", e.RowIndex, "nif");

                    if (MessageBox.Show("¿Desea eliminar el registro con NIF " + nif + "?", "TEVEO :: Aplicación de gestión", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        int estado = -1;
                        try
                        {
                            ENPersona admin_seleccionado = new ENPersona();
                            admin_seleccionado.Dni = nif;

                            estado = admin_seleccionado.eliminarPersona();

                            if (estado == 1)
                            {
                                ActilizaVistaForm("defecto");
                                MensajeSistema(etInfoCON, "Registro eliminado correctamente.", kMensajeSistema.mCORRECTO);
                                gbInfoCON.Visible = true;
                            }
                            gbInfoCON.Visible = true;
                        }
                        catch (ENException enex)
                        {
                            MensajeSistema(etInfoCON, enex.Message, kMensajeSistema.mERROR);
                            gbInfoCON.Visible = true;
                        }

                    }

                }
                else if (dgvPersonas.Columns[e.ColumnIndex].Name == "email")
                {
                    WebBrowser web = new WebBrowser();
                    web.Navigate("mailto:" + administrador.obtenerDelDataSet("Personas", e.RowIndex, "email"));
                }
            }
            catch (Exception ex)
            {

            }

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Actiliza vista form. </summary>
        ///
        /// <remarks>   . </remarks>
        ///
        /// <param name="accion">   The accion. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void ActilizaVistaForm(string accion)
        {

            switch (accion)
            {
                case "modificar":
                    pestanyasSeccionBase.GetControl(1).Text = "Modificar";
                    gbInsertarAdministrador.Text = "Modificar datos de administrador";
                    btnInsertar.Text = "Modificar";
                    mtbNIF.Enabled = false;
                    gbInfoINS_MOD.Visible = false;
                    TbSeccionBaseErrorProvider.Dispose();
                    this.etAccion.Text = "MODIFICAR";
                    tbNombre.Focus();
                    break;
                case "insertar":
                    pestanyasSeccionBase.GetControl(1).Text = "Insertar";
                    gbInsertarAdministrador.Text = "Nuevo administrador";
                    btnInsertar.Text = "Insertar";
                    this.etAccion.Text = "INSERTAR";
                    mtbNIF.Enabled = true;
                    gbInfoINS_MOD.Visible = false;
                    btnLimpiar_Click((object)btnLimpiar, null);
                    break;
                default:
                    pestanyasSeccionBase.GetControl(1).Text = "Insertar";
                    gbInsertarAdministrador.Text = "Nuevo administrador";
                    btnInsertar.Text = "Insertar";
                    this.etAccion.Text = "CONSULTAR";
                    // btnBuscar_Click((object)btnBuscar, null);
                    MetodoBusqueda((object)btnBuscar, null);
                    mtbNIFBuscar.Focus();
                    break;
            }
            
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by pestanyasSeccionBase for click events. </summary>
        ///
        /// <remarks>   . </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        override public void pestanyasSeccionBase_Click(object sender, EventArgs e)
        {
            if (pestanyasSeccionBase.SelectedTab.Text == "Consultar")
            {
                ActilizaVistaForm("defecto");
            }
            else if (pestanyasSeccionBase.SelectedTab.Text == "Insertar")
            {
                ActilizaVistaForm("insertar");
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by dgvPersonas for cell mouse move events. </summary>
        ///
        /// <remarks>   . </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Data grid view cell mouse event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void dgvPersonas_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvPersonas.Columns[e.ColumnIndex].Name == "email")
            {
                this.Cursor = Cursors.Hand;
            }
            else this.Cursor = Cursors.Default;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by chkPaginacion for checked changed events. </summary>
        ///
        /// <remarks>   . </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Información del evento. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void chkPaginacion_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPaginacion.Checked)
            {
                gbPaginacion.Visible = true;
                Paginar = true;
                ACTUAL_registro = 1;
                
                btnPaginaUltima.Visible = true;
                btnPaginaSiguiente.Visible = true;
                btnPaginaPrimera.Visible = false;
                btnPaginaAnterior.Visible = false;
                MensajePaginacion(etInfoPAG, 1, getNumPaginasTotales());
                

                // btnBuscar_Click((Button)btnBuscar, null);
                MetodoBusqueda((object)btnBuscar, null);
            }
            else
            {
                gbPaginacion.Visible = false;
                Paginar = false;
                // btnBuscar_Click((Button)btnBuscar, null);
                MetodoBusqueda((object)btnBuscar, null);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by btnPaginaSiguiente for click events. </summary>
        ///
        /// <remarks>   . </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnPaginaSiguiente_Click(object sender, EventArgs e)
        {
            btnPaginaPrimera.Visible = true;
            btnPaginaAnterior.Visible = true;

            ACTUAL_registro += PAGINA_registros;
            if (getNumPaginaActual(ACTUAL_registro) <= getNumPaginasTotales())
            {
                // btnBuscar_Click((Button)btnBuscar, null);
                MetodoBusqueda((object)btnBuscar, null);
                MensajePaginacion(etInfoPAG, getNumPaginaActual(ACTUAL_registro), getNumPaginasTotales());
                if (getNumPaginaActual(ACTUAL_registro) == getNumPaginasTotales())
                {
                    ACTUAL_registro = TOTAL_registros - (TOTAL_registros % PAGINA_registros)+1;
                    btnPaginaSiguiente.Visible = false;
                    btnPaginaUltima.Visible = false;
                }
            }
            else
            {
                ACTUAL_registro = TOTAL_registros - (TOTAL_registros % PAGINA_registros);
                btnPaginaSiguiente.Visible = false;
                btnPaginaUltima.Visible = false;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by btnPaginaAnterior for click events. </summary>
        ///
        /// <remarks>   . </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnPaginaAnterior_Click(object sender, EventArgs e)
        {
            btnPaginaUltima.Visible = true;
            btnPaginaSiguiente.Visible = true;

            ACTUAL_registro -= PAGINA_registros;
            if (getNumPaginaActual(ACTUAL_registro) >= 1)
            {
                // btnBuscar_Click((Button)btnBuscar, null);
                MetodoBusqueda((object)btnBuscar, null);
                MensajePaginacion(etInfoPAG, getNumPaginaActual(ACTUAL_registro), getNumPaginasTotales());
                if (getNumPaginaActual(ACTUAL_registro) == 1)
                {
                    ACTUAL_registro = 1;
                    btnPaginaAnterior.Visible = false;
                    btnPaginaPrimera.Visible = false;
                }

            }
            else
            {
                ACTUAL_registro = 1;
                btnPaginaAnterior.Visible = false;
                btnPaginaPrimera.Visible = false;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by btnPaginaUltima for click events. </summary>
        ///
        /// <remarks>   . </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnPaginaUltima_Click(object sender, EventArgs e)
        {
            btnPaginaUltima.Visible = false;
            btnPaginaSiguiente.Visible = false;
            btnPaginaPrimera.Visible = true;
            btnPaginaAnterior.Visible = true;

            if (PAGINA_registros == 1) ACTUAL_registro = TOTAL_registros - (TOTAL_registros % PAGINA_registros);
            else ACTUAL_registro = TOTAL_registros - (TOTAL_registros % PAGINA_registros)+1;
            // btnBuscar_Click((Button)btnBuscar, null);
            MetodoBusqueda((object)btnBuscar, null);
            MensajePaginacion(etInfoPAG, getNumPaginaActual(ACTUAL_registro), getNumPaginasTotales());
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by btnPaginaPrimera for click events. </summary>
        ///
        /// <remarks>   . </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnPaginaPrimera_Click(object sender, EventArgs e)
        {
            btnPaginaUltima.Visible = true;
            btnPaginaSiguiente.Visible = true;
            btnPaginaPrimera.Visible = false;
            btnPaginaAnterior.Visible = false;

            ACTUAL_registro = 1;
            // btnBuscar_Click((Button)btnBuscar, null);
            MetodoBusqueda((object)btnBuscar, null);
            MensajePaginacion(etInfoPAG, 1, getNumPaginasTotales());
            
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by mtbRegistrosXPagina for leave events. </summary>
        ///
        /// <remarks>   . </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private void mtbRegistrosXPagina_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt32(mtbRegistrosXPagina.Text) < MIN_PAGINA_registros)
            {
                mtbRegistrosXPagina.Text = MIN_PAGINA_registros.ToString();
                PAGINA_registros = MIN_PAGINA_registros;
               // LLamar a activar paginacion
                chkPaginacion_CheckedChanged((CheckBox)chkPaginacion, null);
            }
            else if (Convert.ToInt32(mtbRegistrosXPagina.Text) >= TOTAL_registros)
            {
                mtbRegistrosXPagina.Text = MIN_PAGINA_registros.ToString();
                PAGINA_registros = MIN_PAGINA_registros;
                chkPaginacion.Checked = false;
                chkPaginacion_CheckedChanged((CheckBox)chkPaginacion, null);
                MensajeSistema(etInfoCON, "Se ha desactivado la paginación debido a que sólo hay 1 página", kMensajeSistema.mADVERTENCIA);
                chkPaginacion.Enabled = false;

            }
            else
            {
                PAGINA_registros = Convert.ToInt32(mtbRegistrosXPagina.Text);
                chkPaginacion_CheckedChanged((CheckBox)chkPaginacion, null);
            }
            etPaginacionInfo.Visible = false;
            
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by mtbRegistrosXPagina for key down events. </summary>
        ///
        /// <remarks>   . </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Key event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private void mtbRegistrosXPagina_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                mtbRegistrosXPagina_Leave((MaskedTextBox)mtbRegistrosXPagina, null);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by mtbRegistrosXPagina for enter events. </summary>
        ///
        /// <remarks>   . </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private void mtbRegistrosXPagina_Enter(object sender, EventArgs e)
        {
            etPaginacionInfo.Visible = true;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by mtbNIFBuscar for key down events. </summary>
        ///
        /// <remarks>   . </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Key event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private void mtbNIFBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscar_Click((Button)btnBuscar, null);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by tbNombreBuscar for key down events. </summary>
        ///
        /// <remarks>   . </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Key event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private void tbNombreBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscar_Click((Button)btnBuscar, null);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by tbEmailBuscar for key down events. </summary>
        ///
        /// <remarks>   . </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Key event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private void tbEmailBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscar_Click((Button)btnBuscar, null);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by cbPerfilBuscar for key down events. </summary>
        ///
        /// <remarks>   . </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Key event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private void cbPerfilBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscar_Click((Button)btnBuscar, null);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by imgBusquedaRapida for click events. </summary>
        ///
        /// <remarks>   Vmolero, 13/04/2010. </remarks>
        ///
        /// <exception cref="Exception">    Thrown when exception. </exception>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public override void imgBusquedaRapida_Click(object sender, EventArgs e)
        {
            MetodoBusqueda = imgBusquedaRapida_Click;
            DataView dvResultado = new DataView();
            base.imgBusquedaRapida_Click(sender, e);


            try
            {
                if (Paginar)
                {
                    // Obtenemos el tamaño de la consulta
                    TOTAL_registros = administrador.obtenerTamanyoConsulta(tbBusquedaRapida.Text);

                    // Si el total de filas es inferior al número de resgistros por página, se desactiva la paginación
                    if (TOTAL_registros <= MIN_PAGINA_registros)
                    {
                        throw new Exception("Excepción de paginación");
                    }
                    else
                    {
                        // Si el total de filas obtenidas es menos que el registro que estabamos mostrando -> actualizamos el registro actual
                        if (esDesbordamientoPagina(ACTUAL_registro))
                        {
                            ACTUAL_registro = TOTAL_registros - (TOTAL_registros % PAGINA_registros) + 1;

                        }
                        else if (esUltimaPagina(ACTUAL_registro))
                        {
                            btnPaginaSiguiente.Visible = false;
                            btnPaginaUltima.Visible = false;
                        }
                        else
                        {
                            btnPaginaSiguiente.Visible = true;
                            btnPaginaUltima.Visible = true;
                        }
                        MensajePaginacion(etInfoPAG, getNumPaginaActual(ACTUAL_registro), getNumPaginasTotales());
                        dvResultado = administrador.obtenerBusquedaRapida(tbBusquedaRapida.Text, ACTUAL_registro, PAGINA_registros); // (mtbNIFBuscar.Text, tbNombreBuscar.Text, tbEmailBuscar.Text, p, ACTUAL_registro, PAGINA_registros);
                    }
                }
                else
                {
                    dvResultado = administrador.obtenerBusquedaRapida(tbBusquedaRapida.Text);
                    TOTAL_registros = dvResultado.Table.Rows.Count;
                    if (TOTAL_registros <= MIN_PAGINA_registros) chkPaginacion.Enabled = false;
                    else chkPaginacion.Enabled = true;
                }
                dgvPersonas.DataSource = dvResultado;

                if (dvResultado.Count > 0) darFormatoDataGrid();
                gbInfoCON.Visible = true;

                if (dvResultado.Count == 0) dgvPersonas.Visible = false;
                else dgvPersonas.Visible = true;

                if (dvResultado.Count == 1)
                    MensajeSistema(etInfoCON, "Se ha obtenido 1 resultado.", kMensajeSistema.mCORRECTO);
                else MensajeSistema(etInfoCON, "Se han obtenido " + dvResultado.Count + " resultados.", kMensajeSistema.mCORRECTO);
            }
            catch (ENException enex)
            {
                if (enex.Tipo != -1)
                {
                    MensajeSistema(etInfoCON, enex.Message, kMensajeSistema.mADVERTENCIA);
                }
                else MensajeSistema(etInfoCON, enex.Message, kMensajeSistema.mERROR);

                gbInfoCON.Visible = true;
            }
            catch (Exception ex)
            {
                chkPaginacion.Checked = false;
                chkPaginacion_CheckedChanged((CheckBox)chkPaginacion, null);
                MensajeSistema(etInfoCON, "Se ha desactivado la paginación debido a que sólo hay 1 página", kMensajeSistema.mADVERTENCIA);
                chkPaginacion.Enabled = false;
            }
        }
    }
}
