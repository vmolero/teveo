////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	CVistaBase\FVistaSeccionIncidencias.cs
//
// summary:	Implements the vista seccion incidencias class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TVO_EntidadesDeNegocio;
using TVO_Utiles;

namespace TVO_VistaWindows
{
    
    public partial class FVistaSeccionIncidencias : TVO_VistaWindows.FVistaSeccionBase
    {
        private static readonly FVistaSeccionIncidencias instancia = new FVistaSeccionIncidencias();
        ENIncidencia incidencias;
        DataView dv;
        DataTable pendientes;
        int numFilas = 16;
        int pagAct, numPaginas, numPendientes;
        bool modificable, botonPuesto, modificarActivo;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public FVistaSeccionIncidencias()
        {
            InitializeComponent();
            this.etSeccion.Text = "Gestión de Incidencias";
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   
        /// Al cargar el formulario se inicializan las variables y se prepara el DataGrid con todos los
        /// datos de la BD. 
        /// </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FVistaSeccionIncidencias_Load(object sender, EventArgs e)
        {
            incidencias = new ENIncidencia();
            pendientes = new DataTable();
            pagAct = 1;
            botonPuesto = false;
            etInfoCON.Text = "";
            numPendientes = 0;
            modificable = false;
            // para controlar que el usuario no acceda a la pestaña modificar
            // si esta no ha cargado nada
            modificarActivo = false;
            //cambiamos el titulo de la segunda pestaña
            tpInsertar.Text = "Editar";
            InicializarDatosDG();
            darFormatoDataGrid();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the instancia. </summary>
        ///
        /// <value> The instancia. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static FVistaSeccionIncidencias Instancia
        {
            get
            {
                return instancia;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   
        /// Al pulsar en una celda abrimos la segunda pestaña con sus datos (solo tiene en cuenta cuando
        /// se pulsa el botón) 
        /// </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Data grid view cell event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void dgIncidencias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int codAux;
            try
            {
                if (dgIncidencias.Columns[e.ColumnIndex].Name == "RESPONDER")
                {
                    //se rellenan los campos de la segunda pestaña
                    sCliente.Text = dgIncidencias.Rows[e.RowIndex].Cells["titular"].Value.ToString();
                    sFecha.Text = dgIncidencias.Rows[e.RowIndex].Cells["fecha"].Value.ToString();
                    sTexto.Text = dgIncidencias.Rows[e.RowIndex].Cells["descripcion"].Value.ToString();
                    sTecnico.Text = dgIncidencias.Rows[e.RowIndex].Cells["tecnico"].Value.ToString();
                    eRespuesta.Text = dgIncidencias.Rows[e.RowIndex].Cells["respuesta"].Value.ToString();
                    codAux = int.Parse(dgIncidencias.Rows[e.RowIndex].Cells["codigo"].Value.ToString());
                    if (sTecnico.Text == "")
                    {
                        sTecnico.Text = administrador.Dni;
                    }

                    // se inicializa el objeto ENIncidencia con los datos del DataGrid
                    incidencias.EstablecerIncidencia(codAux, sFecha.Text, sCliente.Text, sTecnico.Text, eRespuesta.Text, DateTime.Parse(sFecha.Text));

                    // si la incidencia ya esta respondida, no se puede volver a responder
                    if ((dgIncidencias.Rows[e.RowIndex].Cells["tecnico"].Value.ToString() != "") && modificable == false)
                    {
                        eRespuesta.Enabled = false; //se desabilita la caja de texto
                        btIncidencia.Enabled = false;
                        bRespTemp.Enabled = false;
                    }
                    else
                    {
                        eRespuesta.Enabled = true;
                        btIncidencia.Enabled = true;
                        bRespTemp.Enabled = true;
                    }
                    // muestra la pestaña con datos
                    modificarActivo = true;
                    pestanyasSeccionBase.SelectedTab = tpInsertar;
                    eRespuesta.Focus();
                }
            }
            catch { }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Escribe el texto en los botones del DataGrid. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Data grid view cell painting event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void dgIncidencias_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.dgIncidencias.Columns[e.ColumnIndex].Name == "RESPONDER" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                DataGridViewButtonCell celBoton = this.dgIncidencias.Rows[e.RowIndex].Cells["RESPONDER"] as DataGridViewButtonCell;

                // si ya esta respondida muestra el texto "mostrar", en otro caso "responder"
                if (dgIncidencias.Rows[e.RowIndex].Cells["tecnico"].Value.ToString() != "")
                {
                    if (modificable) //si es una de las respuestas no confirmadas podemos editarla
                    {
                        e.Graphics.DrawString("Editar", new Font("Segoe UI", 9), new SolidBrush(Color.Black), e.CellBounds.Left + 18, e.CellBounds.Top + 3);
                    }
                    else
                    {
                        e.Graphics.DrawString("Mostrar", new Font("Segoe UI", 9), new SolidBrush(Color.Black), e.CellBounds.Left + 14, e.CellBounds.Top + 3);
                    }
                }
                else
                {
                    e.Graphics.DrawString("Responder", new Font("Segoe UI", 9), new SolidBrush(Color.Black), e.CellBounds.Left + 6, e.CellBounds.Top + 3);
                }
                e.Handled = true;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Muestra o no las fechas en función de si está o no activo su checkBox. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void cbFechas_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFechas.Checked)
            {
                gbFechas.Visible = true;
            }
            else
            {
                gbFechas.Visible = false;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   
        /// Al pulsar en este botón establecemos los criterios de las filas a mostrar en el DataGrid
        /// según los campos seleccionados por el usuario. 
        /// </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            TbSeccionBaseErrorProvider.Dispose();
            pagAct = 1;
            string condiciones = "";

            if (ValidarCamposBusqueda())
            {

                // Generamos las condiciones de los valores a mostrar en el dataGrid
                // todas o solo las no respondidads
                if (rbTodas.Checked == false)
                {
                    condiciones = "tecnico is null";
                }
                // por cliente
                if (eCliente.Text.ToString() != "")
                {
                    if (condiciones.Length > 0)
                    {
                        condiciones += " AND ";
                    }
                    string[] datosC;
                    datosC = eCliente.Text.Split(' ');

                    for (int i = 0; i < datosC.Length; i++)
                    {
                        condiciones += "(titular like '" + datosC[i] + "')";
                        if (i < datosC.Length - 1)
                        {
                            condiciones += " AND ";
                        }
                    }
                }
                // entre dos fechas
                if (cbFechas.Checked)
                {
                    if (condiciones.Length > 0)
                    {
                        condiciones += " AND ";
                    }
                    condiciones += "fecha >= '" + eFInicio.Value.ToString() + "' AND fecha <= '" + eFFin.Value.ToString() + "'";
                }
                
            }
            else //si hay algún error limpiamos el DataGrid
            {
                condiciones = "codigo = -1";
                // con esta condición no mostrará nada
            }

            // Mostramos los datos en el DataGrid según los criterios anteriores
            PrepararDatosDG(condiciones);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Inicializa el DataGrid con datos por primera vez, además añade la fila de botones. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void InicializarDatosDG()
        {
            dv = new DataView();
            try
            {
                dv = incidencias.InicializarListadoIncidencias();
                pendientes = incidencias.InicializarPendientes();
                if (botonPuesto == false)
                {
                    //creamos una columna de botones para añadir a las que mostrará el dataSet
                    DataGridViewButtonColumn colBotones = new DataGridViewButtonColumn();
                    colBotones.Name = "RESPONDER";
                    dgIncidencias.Columns.Add(colBotones);
                    botonPuesto = true;
                }
                dv.Sort = " fecha DESC";
                InicializarNumPaginas(dv.Count);
                ActualizarDG();
                if (dv.Count == 1)
                {
                    MensajeSistema(etInfoCON, "1 registro encontrado.", kMensajeSistema.mCORRECTO);
                }
                else
                {
                    MensajeSistema(etInfoCON, dv.Count.ToString() + " registros encontrados.", kMensajeSistema.mCORRECTO);
                }
                
            }
            catch (Exception ex)
            {
                MensajeSistema(etInfoCON, ex.ToString(), kMensajeSistema.mERROR);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   
        /// Actualiza los datos del DataGrid según los criterios que le pasamos en condiciones. 
        /// </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ///
        /// <param name="condiciones">  Cadena de texto con las condiciones a mostrar. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void PrepararDatosDG(string condiciones)
        {
            dv = new DataView();
            dv = incidencias.ObtenerListadoIncidencias();
            if (pendientes.Rows.Count==0)
            {
                pendientes = incidencias.InicializarPendientes();
            }
            dv.RowFilter = condiciones;
            dv.Sort = " fecha DESC";
            if (dv.Count == 1)
            {
                MensajeSistema(etInfoCON, "1 registro encontrado.", kMensajeSistema.mCORRECTO);
            }
            else
            {
                MensajeSistema(etInfoCON, dv.Count.ToString() + " registros encontrados.", kMensajeSistema.mCORRECTO);
            }
            InicializarNumPaginas(dv.Count);
            ActualizarDG();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   
        /// Inicializa las variables de numero de paginas según la cantidad de datos del DataGrid. 
        /// </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ///
        /// <param name="cantidadReg">  Cantidad total de datos a mostrar en el DataGrid. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void InicializarNumPaginas(int cantidadReg)
        {
            numPaginas = cantidadReg / numFilas;

            if (numPaginas > 0)
            {
                if (cantidadReg % numFilas > 0)
                    numPaginas++;
            }
        }

        /// <summary>
        /// Se establecen los anchos de las columnas del DataGrid
        /// </summary>
        private void darFormatoDataGrid()
        {
            dgIncidencias.RowHeadersVisible = false;

            dgIncidencias.Columns["codigo"].Visible = false;
            dgIncidencias.Columns["titular"].Width = 64;
            dgIncidencias.Columns["tecnico"].Width = 66;
            dgIncidencias.Columns["fecha"].Width = 95;
            dgIncidencias.Columns["RESPONDER"].Width = 75;
            int anchoRestantes = (dgIncidencias.Width - 303) / 2;
            dgIncidencias.Columns["descripcion"].Width = anchoRestantes;
            dgIncidencias.Columns["respuesta"].Width = anchoRestantes;
            // cambiamos los nombres de las cabeceras
            dgIncidencias.Columns["titular"].HeaderText = "Titular";
            dgIncidencias.Columns["tecnico"].HeaderText = "Técnico";
            dgIncidencias.Columns["fecha"].HeaderText = "Fecha";
            dgIncidencias.Columns["descripcion"].HeaderText = "Descripción";
            dgIncidencias.Columns["respuesta"].HeaderText = "Respuesta";
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Guarda la Respuesta en el DataSet y además la añade a la Base de Datos. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btIncidencia_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarDatos())
                {
                    TbSeccionBaseErrorProvider.Dispose();
                    incidencias.Tecnico = sTecnico.Text.ToString();
                    incidencias.Respuesta = eRespuesta.Text.ToString();
                    incidencias.ResponderIncidencia();
                    incidencias.ConfirmarCambios();
                    ActualizarDG();
                    MensajeSistema(etInfoCON, "Incidencia almacenada con éxito", kMensajeSistema.mCORRECTO);
                    modificarActivo = false;
                    pestanyasSeccionBase.SelectedTab = tpSeccionBaseConsultar;
                }
            }
            catch (Exception ex)
            {
                MensajeSistema(etInfoCON, ex.ToString(), kMensajeSistema.mERROR);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Pasa a la página siguiente del DataGrid. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void bSiguiente_Click(object sender, EventArgs e)
        {
            pagAct++;
            ActualizarDG();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Pasa a la página anterior del DataGrid. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void bAnterior_Click(object sender, EventArgs e)
        {
            pagAct--;
            ActualizarDG();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Rellena el DataGrid con los datos pertinentes del DataView. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void ActualizarDG()
        {
            // rellenamos el DataGrid
            dgIncidencias.DataSource = incidencias.ActualizarListadoIncidencias(dv, pagAct, numFilas);
            modificable = false;
            if (numPaginas > 0)
            {
                etInfoPAG.Text = "Pagina " + pagAct + " de " + numPaginas;
            }
            else
            {
                etInfoPAG.Text = "Pagina " + pagAct + " de 1";
            }
            ActualizarBotonesPaginacion();
            modificable = false;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Activa o no los botones de anterior y siguiente según tengan o no operatividad. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void ActualizarBotonesPaginacion()
        {
            if (numPaginas > 1)
            {
                gbPaginacion.Visible = true;
            }
            else
            {
                gbPaginacion.Visible = false;
            }
            if (pagAct < numPaginas)
            {
                btnPaginaSiguiente.Enabled = true;
                btnPaginaSiguiente.Focus();
                btnPaginaUltima.Enabled = true;
            }
            else
            {
                btnPaginaSiguiente.Enabled = false;
                btnPaginaUltima.Enabled = false;
            }

            if (pagAct > 1)
            {
                btnPaginaAnterior.Enabled = true;
                btnPaginaPrimera.Enabled = true;
            }
            else
            {
                btnPaginaAnterior.Enabled = false;
                btnPaginaPrimera.Enabled = false;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   
        /// Responde una incidencia pero todavía no la actualiza en la Base de Datos, aunque sí actualiza
        /// el DataSet. 
        /// </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void bRespTemp_Click_1(object sender, EventArgs e)
        {
            if(ValidarDatos())
            {
                TbSeccionBaseErrorProvider.Dispose();
                incidencias.Tecnico = sTecnico.Text.ToString();
                incidencias.Respuesta = eRespuesta.Text.ToString();
                // Guardamos la fila modificada por si hay que mostrarla
                pendientes.ImportRow(incidencias.ResponderIncidencia());
                ActualizarDG();
                // Tenemos otra respuesta pendiente de confirmación en la BD
                numPendientes++;
                gbPendientes.Visible = true;
                bGuardarPendientes.Enabled = true;
                bCancelar.Enabled = true;
                sPendientes.Text = "Tiene " + numPendientes + " incidencias respondidas pendientes de ser confirmadas";
                MensajeSistema(etInfoCON, "Incidencia a la espera de ser confirmada.", kMensajeSistema.mCORRECTO);
                modificarActivo = false;
                pestanyasSeccionBase.SelectedTab = tpSeccionBaseConsultar;
                bGuardarPendientes.Focus();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Guarda en la BD todas las respuestas pendientes de confirmación. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void bGuardarPendientes_Click(object sender, EventArgs e)
        {
            try
            {
                incidencias.ConfirmarCambios();
                gbPendientes.Visible = false;
                bGuardarPendientes.Enabled = false;
                bCancelar.Enabled = false;
                PrepararDatosDG("");
                pendientes.Clear();
                MensajeSistema(etInfoCON, "Incidencias almacenadas con éxito.", kMensajeSistema.mCORRECTO);
                numPendientes = 0;
            }
            catch (Exception ex)
            {
                MensajeSistema(etInfoCON, ex.ToString(), kMensajeSistema.mERROR);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   
        /// Cancela todos los cambios pendientes y vuelve a obtener en el DataView los datos que contiene
        /// la BD. 
        /// </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void bCancelar_Click(object sender, EventArgs e)
        {
            gbPendientes.Visible = false;
            bGuardarPendientes.Enabled = false;
            bCancelar.Enabled = false;
            pendientes.Clear();
            MensajeSistema(etInfoCON, "Incidencias pendientes eliminadas con éxito.", kMensajeSistema.mCORRECTO);
            InicializarDatosDG();
            numPendientes = 0;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Muestra solo las incidencias respondidas pendientes de confirmación. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void bMostrarPendientes_Click(object sender, EventArgs e)
        {
            // rellenamos el DataGrid
            dgIncidencias.DataSource = pendientes;
            modificable = true;
            pagAct = numPaginas = 1;
            etInfoPAG.Text = "Pagina " + pagAct + " de " + numPaginas;
            ActualizarBotonesPaginacion();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by btnLimpiar for click events. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            eCliente.Clear();
            rbTodas.Checked = true;
            rbNoLeidas.Checked = false;
            cbFechas.Checked = false;
            gbFechas.Visible = false;
            TbSeccionBaseErrorProvider.Dispose();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Valida las entradas de texto de las búsquedas. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ///
        /// <returns>   true si todo es correcto, false en caso contrario. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private bool ValidarCamposBusqueda()
        {
            bool retorno = true;
            if (eCliente.Text.Length > 0)
            {
                if (!Validacion.NifValido(eCliente.Text))
                {
                    TbSeccionBaseErrorProvider.SetError(eCliente, "Debe introducir un NIF");
                    retorno = false;
                    eCliente.Focus();
                }
            }
            if (gbFechas.Visible == true)
            {
                if(!Validacion.FechasValidas(DateTime.Parse(eFInicio.Text), DateTime.Parse(eFFin.Text)))
                {
                    TbSeccionBaseErrorProvider.SetError(eFInicio, "La fecha inicial no puede ser más antigua que la final");
                    retorno = false;
                }
            }
            return retorno;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Valida la entrada de datos. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ///
        /// <returns>   true si todo es correcto, false en caso contrario. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool ValidarDatos()
        {
            bool retorno = true;

            if (eRespuesta.Text == "")
            {
                TbSeccionBaseErrorProvider.SetError(eRespuesta, "Debe introducir alguna respuesta");
                eRespuesta.Focus();
                retorno = false;
            }
            return retorno;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Busqueda simple, busca en todos los campos de la tabla comentario. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        override public void imgBusquedaRapida_Click(object sender, EventArgs e)
        {
            TbSeccionBaseErrorProvider.Dispose();
            string condiciones = "";
            
            if (tbBusquedaRapida.Text != "")
            {
                condiciones += "(titular like '%" + tbBusquedaRapida.Text + "%')";
                condiciones += " OR (tecnico like '%" + tbBusquedaRapida.Text + "%')";
                condiciones += " OR (descripcion like '%" + tbBusquedaRapida.Text + "%')";
                condiciones += " OR (respuesta like '%" + tbBusquedaRapida.Text + "%')";
            }
            // Mostramos los datos en el DataGrid según los criterios anteriores
            PrepararDatosDG(condiciones);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Al pulsar la ultima pagina de paginación </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnPaginaUltima_Click(object sender, EventArgs e)
        {
            pagAct = numPaginas;
            ActualizarDG();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Al pulsar la primera página de paginación. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnPaginaPrimera_Click(object sender, EventArgs e)
        {
            pagAct = 1;
            ActualizarDG();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by mtbRegistrosXPagina for key down events. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
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
        /// <summary>   Gestiona la cantidad a registros a mostrar en la paginación. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void mtbRegistrosXPagina_Leave(object sender, EventArgs e)
        {
            int regXPagina;
            etPaginacionInfo.Visible = false;
            TbSeccionBaseErrorProvider.Dispose();
            try
            {
                regXPagina = int.Parse(mtbRegistrosXPagina.Text);
                if (regXPagina < 10)
                {
                    TbSeccionBaseErrorProvider.SetError(mtbRegistrosXPagina, "Debe introducir un número mayor que 10");
                }
                else
                {
                    numFilas = regXPagina;
                    ActualizarDG();
                }
            }
            catch
            {
                TbSeccionBaseErrorProvider.SetError(mtbRegistrosXPagina, "Debe introducir un número mayor que 10");
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Al escribir algo mostramos el texto de ayuda. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void mtbRegistrosXPagina_TextChanged(object sender, EventArgs e)
        {
            etPaginacionInfo.Visible = true;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Comprueba si el usuario puede ver la segunda pestaña o no. </summary>
        ///
        /// <remarks>   JM, 08/04/2010. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void PermitirModificar()
        {
            // si no se ha cargado nada en la pestaña de modificación
            // no dejamos que el usuario entre
            if (modificarActivo == false)
            {
                pestanyasSeccionBase.SelectedTab = tpSeccionBaseConsultar;
            }
            else
            {
                pestanyasSeccionBase.SelectedTab = tpInsertar;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Se lanza cuando el usuario intenta cambiar de pestaña. </summary>
        ///
        /// <remarks>   JM, 08/04/2010. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Layout event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void pestanyasSeccionBase_Layout(object sender, LayoutEventArgs e)
        {
            // solo comprobamos si quiere ir a la pestaña de edición
            // en otro caso puede ir sin problemas
            if (pestanyasSeccionBase.SelectedTab == tpInsertar)
            {
                PermitirModificar();
            }
        }
    }
}
