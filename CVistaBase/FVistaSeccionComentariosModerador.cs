////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	CVistaBase\FVistaSeccionComentariosModerador.cs
//
// summary:	Implementa la sección de comentarios del moderador
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using TVO_EventosWindows;
using TVO_EntidadesDeNegocio;
using TVO_Utiles;

namespace TVO_VistaWindows
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Vista seccion comentarios moderador. </summary>
    ///
    /// <remarks>   TVO DPAA 2009-2010 </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class FVistaSeccionComentariosModerador : TVO_VistaWindows.FVistaSeccionBase
    {

        private static readonly FVistaSeccionComentariosModerador instancia = new FVistaSeccionComentariosModerador();
        ENComentario comentario;
        DataView dv;
        DataTable pendientes;
        int numFilas = 16;
        int pagAct, numPaginas, numPendientes;
        bool modificable, botonPuesto, modificarActivo;

        public FVistaSeccionComentariosModerador()
            : base() 
        {
            InitializeComponent();
            this.etSeccion.Text = "Gestión de Comentarios";
            this.etAccion.Text = "CONSULTAR";

            base.vistaModerador();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the instancia. </summary>
        ///
        /// <value> The instancia. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static FVistaSeccionComentariosModerador Instancia
        {
          get 
          {
              return instancia; 
          }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by FVistaSeccionComentariosModerador for load events. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FVistaSeccionComentariosModerador_Load(object sender, EventArgs e)
        {
            comentario = new ENComentario();
            //para controlar que el usuario no acceda a la pestaña modificar
            // si esta no ha cargado nada
            modificarActivo = false;
            PrepararPendientes();
            pagAct = 1;
            numPendientes = 0;
            modificable = false;
            botonPuesto = false;
            etInfoCON.Text = "";
            //cambiamos el titulo de la segunda pestaña
            tpInsertar.Text = "Editar";
            InicializarDatosDG();
            darFormatoDataGrid();
            RellenarCanales();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Inicializa el DataGrid con datos por primera vez, además añade la fila de botones </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void InicializarDatosDG()
        {
            dv = new DataView();
            try
            {
                dv = comentario.InicializarListadoComentarios();
                pendientes = comentario.InicializarPendientes();

                if (botonPuesto == false)
                {
                    //creamos una columna de botones para añadir a las que mostrará el dataSet
                    DataGridViewButtonColumn colBotones = new DataGridViewButtonColumn();
                    colBotones.Name = "VALIDAR";
                    dgComentarios.Columns.Add(colBotones);
                    botonPuesto = true;
                }

                if (dv.Count == 1)
                {
                    MensajeSistema(etInfoCON, "1 registro encontrado.", kMensajeSistema.mCORRECTO);
                }
                else
                {
                    MensajeSistema(etInfoCON, dv.Count.ToString() + " registros encontrados.", kMensajeSistema.mCORRECTO);
                }

                dv.Sort = " fecha DESC";
                InicializarNumPaginas(dv.Count);
                ActualizarDG();
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
            dv = comentario.ObtenerListadoComentarios();
            if (pendientes.Rows.Count == 0)
            {
                pendientes = comentario.InicializarPendientes();
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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Se establecen los anchos de las columnas del DataGrid. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void darFormatoDataGrid()
        {
            dgComentarios.RowHeadersVisible = false;
            // las columnas siguientes no serán mostradas tal cual,
            // sus datos serán formateados en las columnas con su mismo nombre seguido de aux
            // ejemplo canal se verá en canalAux
            dgComentarios.Columns["canal"].Visible = false;
            dgComentarios.Columns["programa"].Visible = false;
            dgComentarios.Columns["validado"].Visible = false;
            dgComentarios.Columns["id"].Visible = false;
            // ajustamos los tamaños de las columnas
            dgComentarios.Columns["subusuario"].Width = 70;
            dgComentarios.Columns["fecha"].Width = 95;
            dgComentarios.Columns["texto"].Width = dgComentarios.Width - 430;
            dgComentarios.Columns["VALIDAR"].Width = 60;
            dgComentarios.Columns["validadoAux"].Width = 53;
            dgComentarios.Columns["programaAux"].Width = 74;
            dgComentarios.Columns["canalAux"].Width = 75;
            // cambiamos las cabeceras de las columnas auxiliares
            dgComentarios.Columns["validadoAux"].HeaderText = "Validado";
            dgComentarios.Columns["canalAux"].HeaderText = "Canal";
            dgComentarios.Columns["programaAux"].HeaderText = "Programa";
            // y del resto
            dgComentarios.Columns["subusuario"].HeaderText = "Autor";
            dgComentarios.Columns["fecha"].HeaderText = "Fecha";
            dgComentarios.Columns["texto"].HeaderText = "Texto";
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Rellena el DataGrid con los datos pertinentes del DataView. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void ActualizarDG()
        {
            // rellenamos el DataGrid
            int primerRegistro = (pagAct - 1) * numFilas;
            int ultimoRegistro = (pagAct * numFilas);
            dgComentarios.DataSource = comentario.ObtenerTablaComentarios(dv, primerRegistro, ultimoRegistro);
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
        /// <summary>   Valida las entradas de texto de las búsquedas. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ///
        /// <returns>   true si todo es correcto, false en caso contrario. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private bool ValidarCamposBusqueda()
        {
            bool retorno = true;
            if (gbFechas.Visible == true)
            {
                if (!Validacion.FechasValidas(DateTime.Parse(eFInicio.Text), DateTime.Parse(eFFin.Text)))
                {
                    TbSeccionBaseErrorProvider.SetError(eFInicio, "La fecha inicial no puede ser más antigua que la final");
                    retorno = false;
                }
            }
            return retorno;
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

        private void dgComentarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int idAux, valAux, idPrograma, idCanal;
            try
            {
                if (dgComentarios.Columns[e.ColumnIndex].Name == "VALIDAR")
                {
                    //se rellenan los campos de la segunda pestaña
                    sPrograma.Text = dgComentarios.Rows[e.RowIndex].Cells["programaAux"].Value.ToString();
                    sCanal.Text = dgComentarios.Rows[e.RowIndex].Cells["canalAux"].Value.ToString();
                    sAutor.Text = dgComentarios.Rows[e.RowIndex].Cells["subusuario"].Value.ToString();
                    sFecha.Text = dgComentarios.Rows[e.RowIndex].Cells["fecha"].Value.ToString();
                    sTexto.Text = dgComentarios.Rows[e.RowIndex].Cells["texto"].Value.ToString();

                    idAux = int.Parse(dgComentarios.Rows[e.RowIndex].Cells["id"].Value.ToString());
                    valAux = int.Parse(dgComentarios.Rows[e.RowIndex].Cells["validado"].Value.ToString());
                    idCanal = int.Parse(dgComentarios.Rows[e.RowIndex].Cells["canal"].Value.ToString());
                    idPrograma = int.Parse(dgComentarios.Rows[e.RowIndex].Cells["programa"].Value.ToString());
                    // se inicializa el objeto ENComentario con los datos del DataGrid
                    comentario.EstablecerComentario(idAux, idPrograma, idCanal, sAutor.Text, sTexto.Text, DateTime.Parse(sFecha.Text), valAux);
                    // si el comentario ya esta validado, no se puede volver a validar
                    if (valAux == 1 && modificable == false)
                    {
                        sTexto.Enabled = false; //se desabilita la caja de texto
                        bValidar.Enabled = false;
                        bValidarTemp.Enabled = false;
                    }
                    else
                    {
                        sTexto.Enabled = true;
                        bValidar.Enabled = true;
                        bValidarTemp.Enabled = true;
                    }
                    // muestra la pestaña con datos
                    modificarActivo = true;
                    pestanyasSeccionBase.SelectedTab = tpInsertar;
                    sTexto.Focus();
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

        private void dgComentarios_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.dgComentarios.Columns[e.ColumnIndex].Name == "VALIDAR" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                DataGridViewButtonCell celBoton = this.dgComentarios.Rows[e.RowIndex].Cells["VALIDAR"] as DataGridViewButtonCell;

                // si ya esta respondida muestra el texto "mostrar", en otro caso "responder"
                if (dgComentarios.Rows[e.RowIndex].Cells["validado"].Value.ToString() == "1")
                {
                    if (modificable) //si es una de las respuestas no confirmadas podemos editarla
                    {
                        e.Graphics.DrawString("Editar", new Font("Segoe UI", 9), new SolidBrush(Color.Black), e.CellBounds.Left + 12, e.CellBounds.Top + 3);
                    }
                    else
                    {
                        e.Graphics.DrawString("Mostrar", new Font("Segoe UI", 9), new SolidBrush(Color.Black), e.CellBounds.Left + 6, e.CellBounds.Top + 3);
                    }
                }
                else
                {
                    e.Graphics.DrawString("Editar", new Font("Segoe UI", 9), new SolidBrush(Color.Black), e.CellBounds.Left + 12, e.CellBounds.Top + 3);
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
            string condiciones = "";
            TbSeccionBaseErrorProvider.Dispose();
            pagAct = 1;
            if (ValidarCamposBusqueda())
            {
                // entre dos fechas
                if (cbFechas.Checked)
                {
                    if (condiciones.Length > 0)
                    {
                        condiciones += " AND ";
                    }
                    condiciones += "fecha >= '" + eFInicio.Value.ToString() + "' AND fecha <= '" + eFFin.Value.ToString() + "'";
                }

                // solo los no validados
                if (rbNoValidados.Checked == true)
                {
                    if (condiciones.Length > 0)
                    {
                        condiciones += " AND ";
                    }
                    condiciones += "validado = 0";
                }

                // por canal
                if (eCadena.Text != "")
                {
                    if (condiciones.Length > 0)
                    {
                        condiciones += " AND ";
                    }
                    // obtenemos el id del canal asociado al nombre seleccionado
                    int idCanal = comentario.ObtenerIdCanal(eCadena.Text);
                    condiciones += "(canal =" + idCanal + ")";
                }

                // por autor
                if (eSubusuario.Text != "")
                {
                    if (condiciones.Length > 0)
                    {
                        condiciones += " AND ";
                    }
                    condiciones += "(subusuario LIKE '%"+eSubusuario.Text+"%')";
                }

                // por programa
                if (ePrograma.Text != "")
                {
                    if (condiciones.Length > 0)
                    {
                        condiciones += " AND ";
                    }
                    // Obtenemos una lista con los id de los programas que contienen en
                    // su nombre el texto introducido por el usuario
                    List<int> idsPrograma = comentario.OtenerIdPrograma(ePrograma.Text);
                    // si no hay ninguna id en la lista, es porque no hay ningún
                    // programa que coincida con esos criterios
                    if (idsPrograma.Count == 0)
                    {
                        condiciones += "(programa = -1)";
                    }
                    else
                    {
                        condiciones += "(";
                        for (int i = 0; i < idsPrograma.Count; i++)
                        {
                            condiciones += "programa = "+idsPrograma[i].ToString();
                            if (i < idsPrograma.Count - 1)
                            {
                                condiciones += " OR ";
                            }
                            
                        }
                        condiciones += ")";
                    }
                }

            }
            else //si hay algún error limpiamos el DataGrid
            {
                condiciones = "id = -1";
                // con esta condición no mostrará nada
            }
            // Mostramos los datos en el DataGrid según los criterios anteriores
            PrepararDatosDG(condiciones);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Guarda los cambios en el DataSet y además los añade a la Base de Datos. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void bValidar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                try
                {
                    TbSeccionBaseErrorProvider.Dispose();
                    comentario.Validado = 1;
                    comentario.Texto = sTexto.Text;
                    comentario.ModificarComentario();
                    comentario.ConfirmarCambios();
                    ActualizarDG();
                    modificarActivo = false;
                    pestanyasSeccionBase.SelectedTab = tpSeccionBaseConsultar;
                    MensajeSistema(etInfoCON, "Comentario validado con éxito.", kMensajeSistema.mCORRECTO);
                }
                catch (Exception ex)
                {
                    MensajeSistema(etInfoCON, ex.ToString(), kMensajeSistema.mERROR);
                }
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

        /// <summary>
        /// Pasa a la página anterior del DataGrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bAnterior_Click(object sender, EventArgs e)
        {
            pagAct--;
            ActualizarDG();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   
        /// Valida un comentario pero todavía no lo actualiza en la Base de Datos, aunque sí actualiza el
        /// DataSet. 
        /// </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void bValidarTemp_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                TbSeccionBaseErrorProvider.Dispose();
                comentario.Validado = 1;
                comentario.Texto = sTexto.Text;
                comentario.ModificarComentario();
                // Guardamos la fila modificada por si hay que mostrarla
                pendientes.ImportRow(comentario.ModificarComentario());
                ActualizarDG();
                // Tenemos otra respuesta pendiente de confirmación en la BD
                numPendientes++;
                gbPendientes.Visible = true;
                bGuardarPendientes.Enabled = true;
                bCancelarPendientes.Enabled = true;
                sPendientes.Text = "Tiene " + numPendientes + " comentarios validados pendientes de ser confirmados";
                MensajeSistema(etInfoCON, "Comentario a la espera de ser confirmado.", kMensajeSistema.mCORRECTO);
                modificarActivo = false;
                pestanyasSeccionBase.SelectedTab = tpSeccionBaseConsultar;
                bGuardarPendientes.Focus();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Guarda en la BD todas los comentarios validados pendientes de confirmación. </summary>
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
                comentario.ConfirmarCambios();
                gbPendientes.Visible = false;
                bGuardarPendientes.Enabled = false;
                bCancelarPendientes.Enabled = false;
                pendientes.Clear();
                numPendientes = 0;
                MensajeSistema(etInfoCON, "Comentarios almacenados con éxito.", kMensajeSistema.mCORRECTO);
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

        private void bCancelarPendientes_Click(object sender, EventArgs e)
        {
            gbPendientes.Visible = false;
            bGuardarPendientes.Enabled = false;
            bCancelarPendientes.Enabled = false;
            pendientes.Clear();
            MensajeSistema(etInfoCON, "Comentarios pendientes eliminados con éxito.", kMensajeSistema.mCORRECTO);
            InicializarDatosDG();
            numPendientes = 0;
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

            if (sTexto.Text == "")
            {
                TbSeccionBaseErrorProvider.SetError(sTexto, "El comentario debe contener algún texto");
                sTexto.Focus();
                retorno = false;
            }
            return retorno;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Rellena el campo de canales con todos los nombres de canales que tenemos en la BD. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void RellenarCanales()
        {
            DataView listaCanales = comentario.DevolverCanales();
            eCadena.Items.Add("");
            foreach(DataRowView dr in listaCanales)
            {
                eCadena.Items.Add(dr["nombre"].ToString());
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Limpia los campos de búsqueda. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            eSubusuario.Clear();
            ePrograma.Clear();
            cbFechas.Checked = false;
            gbFechas.Visible = false;
            TbSeccionBaseErrorProvider.Dispose();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Prepara el DataTable pendientes por si debe ser mostrado. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void PrepararPendientes()
        {
            pendientes = new DataTable();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   
        /// Rellena el DataGrid con los comentarios modificados pero pendientes de ser almacenados en la
        /// BD. 
        /// </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void bMostrarPendientes_Click(object sender, EventArgs e)
        {
            // rellenamos el DataGrid
            dgComentarios.DataSource = pendientes;
            modificable = true;
            pagAct = numPaginas = 1;
            etInfoPAG.Text = "Pagina " + pagAct + " de " + numPaginas;
            ActualizarBotonesPaginacion();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by imgBusquedaRapida for click events. </summary>
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
                // AUTOR
                condiciones += "(subusuario LIKE '%" + tbBusquedaRapida.Text + "%')";
                // CANAL
                // obtenemos el id del canal asociado al nombre seleccionado
                int idCanal = comentario.ObtenerIdCanal(tbBusquedaRapida.Text);
                if (idCanal > -1)
                {
                    condiciones += "(canal =" + idCanal + ")";
                }

                // PROGRAMA
                // Obtenemos una lista con los id de los programas que contienen en
                // su nombre el texto introducido por el usuario
                List<int> idsPrograma = comentario.OtenerIdPrograma(ePrograma.Text);
                // si no hay ninguna id en la lista, es porque no hay ningún
                // programa que coincida con esos criterios
                if (idsPrograma.Count > 0)
                {
                    condiciones += " OR (";
                    for (int i = 0; i < idsPrograma.Count; i++)
                    {
                        condiciones += "programa = " + idsPrograma[i].ToString();
                        if (i < idsPrograma.Count - 1)
                        {
                            condiciones += " OR ";
                        }
                    }
                    condiciones += ")";
                }
                // TEXTO
                condiciones += " OR (texto LIKE '%" + tbBusquedaRapida.Text + "%')";
            }

            // Mostramos los datos en el DataGrid según los criterios anteriores
            PrepararDatosDG(condiciones);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by btnPaginaUltima for click events. </summary>
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
        /// <summary>   Event handler. Called by btnPaginaPrimera for click events. </summary>
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
        /// <summary>   Para controlar la entrada de datos de la paginación </summary>
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
        /// <summary>   Event handler. Called by mtbRegistrosXPagina for text changed events. </summary>
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
