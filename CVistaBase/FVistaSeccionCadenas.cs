////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	CVistaBase\FVistaSeccionCadenas.cs
//
// summary:	Implementa la vista de la sección clase cadenas.
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
    public partial class FVistaSeccionCadenas : TVO_VistaWindows.FVistaSeccionBase
    {
        private static readonly FVistaSeccionCadenas instancia = new FVistaSeccionCadenas();
        //---------------------cambios paginación---------------------
        delegate void Busqueda(object sender, EventArgs e);
        Busqueda MetodoBusqueda;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor por defecto de FVistaSeccionCadenas. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private FVistaSeccionCadenas()
            : base()
        {
            InitializeComponent();
            this.etSeccion.Text = "Gestión de Cadenas de TV";
            this.etAccion.Text = "CONSULTAR";

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets de instancia. </summary>
        ///
        /// <value> La instancia. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static FVistaSeccionCadenas Instancia
        {
            get
            {
                return instancia;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Inicializador del objeto. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        override public void Init()
        {
            base.Init();
            ENCadena cad = new ENCadena();

            TbSeccionBaseErrorProvider.Dispose();
            cBTipo.DataSource = cad.ObtenerTiposCadenas();
            cBTipoBusq.DataSource = cad.ObtenerTiposCadenas();
            //SCambiarVistaForm("defecto");
            // btnLimpiar_Click((object)btnLimpiar, null);
            //---------------------cambios paginación--------------------- p2
            MetodoBusqueda = btnBuscar_Click;
            gbMensajesSist.Visible = false;
            // gbInfoCON.Visible = false;
            gbMensajes.Visible = false;
            dGRbuscCanales.Visible = false;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Limpia los campos no vacíos. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void buttonLimpiarC_Click(object sender, EventArgs e)
        {
            tBNombre.Text = "";
            cBActivar.Checked = false;
            cBTipo.Text = "";
            //Init();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Comprueba que el formulario es correcto (nombre de cadena, tipo de cadena) </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="nombre">    nombre. </param>
        /// <param name="tipo">      tipo. </param>
        ///
        /// <returns>   true si los datos del formulario son correctos, falso en caso contrario. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private bool ValidaFormulario(string nombre, int tipo)
        {
            bool nomOk = false, tipoOk = false, formCorrecto = false;

            nomOk = Validacion.CadenaValida(nombre);
            tipoOk = Validacion.ElementoSeleccionado(tipo);

            if (nomOk && tipoOk)
                formCorrecto = true;
            else
            {
                if (!nomOk)
                {
                    TbSeccionBaseErrorProvider.SetIconAlignment(tBNombre, ErrorIconAlignment.MiddleRight);
                    TbSeccionBaseErrorProvider.SetIconPadding(tBNombre, 4);
                    TbSeccionBaseErrorProvider.SetError(tBNombre, "ERROR: El formato del nombre no es correcto.");
                }
                if (!tipoOk)
                {
                    TbSeccionBaseErrorProvider.SetIconAlignment(cBTipo, ErrorIconAlignment.MiddleRight);
                    TbSeccionBaseErrorProvider.SetIconPadding(cBTipo, 4);
                    TbSeccionBaseErrorProvider.SetError(cBTipo, "ERROR: Debe seleccionar un tipo de cadena.");

                }
            }

            return formCorrecto;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Llamada a  pestanyasSeccionBase para el evento click. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        override public void pestanyasSeccionBase_Click(object sender, EventArgs e)
        {
            if (pestanyasSeccionBase.SelectedTab.Text == "Consultar")
            {
                CambiarVistaForm("defecto");
            }
            else if (pestanyasSeccionBase.SelectedTab.Text == "Insertar")
            {
                CambiarVistaForm("insertar");
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Llamada al evento asociado al botón Insertar. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void buttonInsertarC_Click(object sender, EventArgs e)
        {
            int insertadas = 0;
            int modificado = 0;

            try
            {
                TbSeccionBaseErrorProvider.Dispose();
                if (ValidaFormulario(tBNombre.Text, cBTipo.SelectedIndex) && buttonInsertarC.Text == "Insertar" && cBTipo.Text != "Todos")
                {
                    ENCadena nuevaCadena = new ENCadena(tBNombre.Text, cBTipo.Text, cBActivar.Checked);
                    DataView dvCadenaExiste = new DataView();

                    //Se busca una cadena con ese nombre y cualquier tipo
                    dvCadenaExiste = nuevaCadena.buscarCadena(tBNombre.Text, "Todos");

                    if (dvCadenaExiste.Count == 0) //No existe la cadena que queremos insertar
                        insertadas = nuevaCadena.insertarCadena();
                    else
                        MensajeSistema(labelMensajes, "ERROR: La cadena ya existe.", kMensajeSistema.mERROR);

                    if (insertadas > 0)
                    {
                        MensajeSistema(labelMensajes, "Inserción correcta", kMensajeSistema.mCORRECTO);
                        btnBuscar_Click((object)btnBuscar, null);
                    }
                    else
                        MensajeSistema(labelMensajes, "ERROR: La inserción no se pudo realizar.", kMensajeSistema.mERROR);
                    gbMensajes.Visible = true;
                }
                else
                {
                    if (buttonInsertarC.Text == "Modificar")
                    {
                        int idCadena = int.Parse(dGRbuscCanales.SelectedRows[0].Cells["id"].Value.ToString());
                        ENCadena modCadena = new ENCadena(idCadena, tBNombre.Text, cBTipo.Text, cBActivar.Checked);
                        modificado = modCadena.modificarCadena();


                        if (modificado > 0)
                        {
                            MensajeSistema(labelMensajes, "Modificación correcta", kMensajeSistema.mCORRECTO);
                            btnBuscar_Click((object)btnBuscar, null);
                        }
                        else
                            MensajeSistema(labelMensajes, "ERROR: La modificación no se pudo realizar.", kMensajeSistema.mERROR);

                        gbMensajes.Visible = true;
                    }
                    else
                    {
                        if (buttonInsertarC.Text == "Insertar" && cBTipo.Text == "Todos")
                        {
                            TbSeccionBaseErrorProvider.SetIconAlignment(cBTipo, ErrorIconAlignment.MiddleRight);
                            TbSeccionBaseErrorProvider.SetIconPadding(cBTipo, 4);
                            TbSeccionBaseErrorProvider.SetError(cBTipo, "ERROR: No es posible insertar una cadena cuyo tipo sea Todos.");
                        }
                    }
                }
            }
            catch (ENException enex)
            {
                if (enex.Tipo != -1)
                {
                    MensajeSistema(labelMensajes, enex.Message, kMensajeSistema.mADVERTENCIA);
                }
                else MensajeSistema(labelMensajes, enex.Message, kMensajeSistema.mERROR);

                gbMensajes.Visible = true;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Llamada al evento asociado al botón buscar. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="Exception">    Thrown when exception. </exception>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            MetodoBusqueda = btnBuscar_Click;
            //No compruebo validación campos porq lo hago en el método del evento leave
            ENCadena cadenaBuscar = new ENCadena();
            DataView dvResultBusq = new DataView();
            try
            {

                if (Paginar)
                {
                    // Obtenemos el tamaño de la consulta
                    TOTAL_registros = cadenaBuscar.obtenerTamanyoConsulta(tBNombreBusq.Text, cBTipoBusq.Text);

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
                        dvResultBusq = cadenaBuscar.buscarCadena(tBNombreBusq.Text, cBTipoBusq.Text, ACTUAL_registro, PAGINA_registros);
                    }

                }
                else
                {
                    dvResultBusq = cadenaBuscar.buscarCadena(tBNombreBusq.Text, cBTipoBusq.Text);
                    TOTAL_registros = dvResultBusq.Table.Rows.Count;
                    if (TOTAL_registros <= MIN_PAGINA_registros)
                        chkPaginacion.Enabled = false;
                    else
                        chkPaginacion.Enabled = true;
                }
                //Si obtengo resultados, le asigno la tabla al datagrid
                if (dvResultBusq.Count > 0)
                {
                    dGRbuscCanales.DataSource = dvResultBusq;
                    darFormatoDataGrid();
                    dGRbuscCanales.Visible = true;
                }
                else
                    dGRbuscCanales.Visible = false;
                gbMensajesSist.Visible = true;

                if (dvResultBusq.Count == 1)
                    MensajeSistema(labelMensajesSist, "Se ha obtenido 1 resultado.", kMensajeSistema.mCORRECTO);
                else
                    MensajeSistema(labelMensajesSist, "Se han obtenido " + dvResultBusq.Count + " resultados.", kMensajeSistema.mCORRECTO);

                /* //si se obtienen resultados se muestra el datagrid sino no
                    if (dvResultBusq.Count > 0)
                            dGRbuscCanales.Visible = true;
                    else
                        if (dvResultBusq.Count == 0)
                              dGRbuscCanales.Visible = false;
                }*/
            }
            catch (ENException enex)
            {
                if (enex.Tipo != -1)
                {
                    MensajeSistema(labelMensajesSist, enex.Message, kMensajeSistema.mADVERTENCIA);
                }
                else MensajeSistema(labelMensajesSist, enex.Message, kMensajeSistema.mERROR);

                gbMensajesSist.Visible = true;
            }
            catch (Exception ex)
            {
                chkPaginacion.Checked = false;
                chkPaginacion_CheckedChanged((CheckBox)chkPaginacion, null);
                MensajeSistema(labelMensajesSist, "Se ha desactivado la paginación debido a que sólo hay 1 página", kMensajeSistema.mADVERTENCIA);
                chkPaginacion.Enabled = false;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Método utilizado para dar formato al datagridview resultado de la búsqueda. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void darFormatoDataGrid()
        {
            dGRbuscCanales.RowHeadersVisible = false;

            dGRbuscCanales.Columns["nombre"].Width = 65;
            dGRbuscCanales.Columns["tipo"].Width = 120;
            dGRbuscCanales.Columns["ActivadaCadena"].Width = 30;
            dGRbuscCanales.Columns["nombre"].HeaderText = "Nombre";
            dGRbuscCanales.Columns["tipo"].HeaderText = "Tipo";
            dGRbuscCanales.Columns["ActivadaCadena"].HeaderText = "Cadena Activada";
            dGRbuscCanales.Columns["id"].Visible = false;
            dGRbuscCanales.Columns["activo"].Visible = false;

            dGRbuscCanales.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Valida el formulario búsqueda. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="nombreCadena"> El nombre cadena. </param>
        ///
        /// <returns>   true si el formulario de búsqueda es correcto, false en caso contrario. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private bool ValidaFormularioBusq(string nombreCadena)
        {
            bool nombreOK = false;
            if (Validacion.CadenaValida(nombreCadena))
                nombreOK = true;

            return nombreOK;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Llamada al evento asociado al datagridview (dGRbuscCanales para las celdas del dgv). </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="Exception">    Thrown when exception. </exception>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Data grid view cell event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void dGRbuscCanales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ENCadena cadena = new ENCadena();
            string cadenaActivada = "";
            DataView dvResultBusq = new DataView();//Para actualizar dgv

            //llamar buscar
            dvResultBusq = cadena.buscarCadena(tBNombreBusq.Text, cBTipoBusq.Text);
            dGRbuscCanales.DataSource = dvResultBusq;
            darFormatoDataGrid();
            try
            {
                if (e.RowIndex == -1)
                    throw new Exception();

                    if (dGRbuscCanales.Columns[e.ColumnIndex].Name == "btnModificar")
                    {
                        // MessageBox.Show(dGRbuscCanales.Rows[e.RowIndex].Cells["nombre"].ToString());
                        tBNombre.Text = dGRbuscCanales.Rows[e.RowIndex].Cells["nombre"].Value.ToString();
                        cBTipo.Text = dGRbuscCanales.Rows[e.RowIndex].Cells["tipo"].Value.ToString();
                        cadenaActivada = dGRbuscCanales.Rows[e.RowIndex].Cells["activo"].Value.ToString();
                        //Llama a una función auxiliar que me devuelve un bool (true= cBActivado || false= CBNoActivado)
                        cBActivar.Checked = ActivarCheckBox(cadenaActivada);

                        //Selecciono la fila en la que voy a querer realizar la modificación.
                        dGRbuscCanales.Rows[e.RowIndex].Selected = true;
                        CambiarVistaForm("modificar");
                        pestanyasSeccionBase.SelectTab(pestanyasSeccionBase.GetControl(1).Name);
                    }
                    else
                    {
                        if (dGRbuscCanales.Columns[e.ColumnIndex].Name == "btnEliminar")
                        {
                            //selecciono fila eliminar
                            dGRbuscCanales.Rows[e.RowIndex].Selected = true;
                            int idC = int.Parse(dGRbuscCanales.SelectedRows[0].Cells["id"].Value.ToString());
                            string nombre = dGRbuscCanales.Rows[e.RowIndex].Cells["nombre"].Value.ToString();

                            if (MessageBox.Show("¿Desea eliminar el registro con Nombre: " + nombre + "?", "TEVEO :: Aplicación de gestión", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                            {
                                bool eliminado = false;

                                    eliminado = cadena.eliminarCadena(idC);

                                    if (eliminado)
                                    {
                                        CambiarVistaForm("defecto");
                                        MensajeSistema(labelMensajesSist, "Registro eliminado correctamente.", kMensajeSistema.mCORRECTO);
                                        gbMensajesSist.Visible = true;
                                        btnBuscar_Click((object)btnBuscar, null);
                                    }
                            }
                        }
                    }
                }
            catch (ENException enex)
            {
                MensajeSistema(labelMensajesSist, enex.Message, kMensajeSistema.mERROR);
                gbMensajesSist.Visible = true;
            }
            catch (Exception ex)
            {}
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Llamada al evento asociado al LOAD de la pantalla. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FVistaSeccionCadenas_Load(object sender, EventArgs e)
        {
            InicializarDataGridView();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Añade los botones Eliminar y Modificar al DataView resultado de la búsqueda. </summary>
        ///
        /// <remarks>   TVO Grupo DPAA2009-2010, 14/04/2010. </remarks>
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

            dGRbuscCanales.Columns.Insert(0, colBotonesMod);
            dGRbuscCanales.Columns.Insert(1, colBotonesElim);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Cambiar la vista del formulario. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="opcion">   The opcion. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void CambiarVistaForm(string opcion)
        {
            if (opcion == "modificar")
            {
                pestanyasSeccionBase.GetControl(1).Text = "Modificar";
                gbInsertarModCanal.Text = "Modificar datos de una cadena.";
                buttonInsertarC.Text = "Modificar";
                gbMensajes.Visible = false;
                TbSeccionBaseErrorProvider.Dispose();
                this.etAccion.Text = "MODIFICAR";
                tBNombre.Focus();
            }
            else
            {
                if (opcion == "insertar")
                {
                    pestanyasSeccionBase.GetControl(1).Text = "Insertar";
                    gbInsertarModCanal.Text = "Insertar una nueva cadena.";
                    buttonInsertarC.Text = "Insertar";
                    this.etAccion.Text = "INSERTAR";
                    gbMensajes.Visible = false;
                    buttonLimpiarC_Click((object)buttonLimpiarC, null);
                    //Init();
                    //dGRbuscCanales.ClearSelection();
                    tBNombre.Focus();
                }
                else
                {
                    pestanyasSeccionBase.GetControl(1).Text = "Insertar";
                    gbInsertarModCanal.Text = "Insertar una nueva cadena.";
                    buttonInsertarC.Text = "Insertar";
                    this.etAccion.Text = "CONSULTAR";
                    gbMensajes.Visible = false;
                    //Init();
                    //dGRbuscCanales.ClearSelection();
                    tBNombre.Focus();
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Método auxiliar utilizado para activar el checkbox (activada cadena). </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="opcion">   The opcion. </param>
        ///
        /// <returns>   true if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        bool ActivarCheckBox(string opcion)
        {
            bool activ = false;
            if (opcion == "1")
                activ = true;
            return activ;

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Llamada al evento asociado a la imagen de búsqueda. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="Exception">    Thrown when exception. </exception>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        override public void imgBusquedaRapida_Click(object sender, EventArgs e)
        {
            MetodoBusqueda = imgBusquedaRapida_Click;
            //No compruebo validación campos porq lo hago en el método del evento leave
            ENCadena cadenaBuscaRap = new ENCadena();
            DataView dvResultBusq = new DataView();
            base.imgBusquedaRapida_Click(sender, e);

            try
            {
                gbMensajesSist.Visible = true;
                if (Paginar)
                {
                    // Obtenemos el tamaño de la consulta

                    TOTAL_registros = cadenaBuscaRap.obtenerTamanyoConsulta(tbBusquedaRapida.Text);

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
                        dvResultBusq = cadenaBuscaRap.buscarCadena(tbBusquedaRapida.Text, ACTUAL_registro, PAGINA_registros); 
                    }
                }
                else
                {
                    dvResultBusq = cadenaBuscaRap.buscarCadena(tbBusquedaRapida.Text);
                    TOTAL_registros = dvResultBusq.Table.Rows.Count;
                    if (TOTAL_registros <= MIN_PAGINA_registros)
                        chkPaginacion.Enabled = false;
                    else
                        chkPaginacion.Enabled = true;
                }
                if (dvResultBusq.Count > 0)
                 {
                        dGRbuscCanales.DataSource = dvResultBusq;
                        darFormatoDataGrid();
                        dGRbuscCanales.Visible = true;
                 }
                 else
                        dGRbuscCanales.Visible = false;
                 if (dvResultBusq.Count == 1)
                        MensajeSistema(labelMensajesSist, "Se ha obtenido 1 resultado.", kMensajeSistema.mCORRECTO);
                    else
                        MensajeSistema(labelMensajesSist, "Se han obtenido " + dvResultBusq.Count + " resultados.", kMensajeSistema.mCORRECTO);
            }
            catch (ENException enex)
            {
                if (enex.Tipo != -1)
                {
                    MensajeSistema(labelMensajesSist, enex.Message, kMensajeSistema.mADVERTENCIA);
                }
                else MensajeSistema(labelMensajesSist, enex.Message, kMensajeSistema.mERROR);

                gbMensajesSist.Visible = true;
            }
            catch (Exception ex)
            {
                chkPaginacion.Checked = false;
                chkPaginacion_CheckedChanged((CheckBox)chkPaginacion, null);
                MensajeSistema(labelMensajesSist, "Se ha desactivado la paginación debido a que sólo hay 1 página", kMensajeSistema.mADVERTENCIA);
                chkPaginacion.Enabled = false;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. LLamada al evento asociado al checkBox utilizado para activar/desactivar la paginación. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
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
        /// <summary>   Event handler. Llamada al evento asociado al botón de paginación, utilizado para ir a la última página. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
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
            else ACTUAL_registro = TOTAL_registros - (TOTAL_registros % PAGINA_registros) + 1;
            // btnBuscar_Click((Button)btnBuscar, null);
            MetodoBusqueda((object)btnBuscar, null);
            MensajePaginacion(etInfoPAG, getNumPaginaActual(ACTUAL_registro), getNumPaginasTotales());
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Llamada al evento asociado al botón de paginación, utilizado para ir a la primera página. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
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
        /// <summary>   Event handler. Llamada al evento asociado al botón de paginación, utilizado para volver a la página anterior. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
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

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Llamada al evento asociado al botón de paginación, utilizado para volver a la página anterior. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
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
                    ACTUAL_registro = TOTAL_registros - (TOTAL_registros % PAGINA_registros) + 1;
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
        /// <summary>   Event handler. Llamada al evento asociado al comboBox Tipo, utilizado para activar la opción enter. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Key event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void cBTipoBusq_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnBuscar_Click((object)btnBuscar, null);
        }

    }
}
