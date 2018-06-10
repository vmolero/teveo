////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	CVistaBase\FVistaSeccionCriticasModerador.cs
//
// summary:	Implementa el formulario de Críticas a programas
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TVO_EventosWindows;
using TVO_EntidadesDeNegocio;
using TVO_Utiles;

namespace TVO_VistaWindows
{
    public partial class FVistaSeccionCriticasModerador : TVO_VistaWindows.FVistaSeccionBase
    {
        private static readonly FVistaSeccionCriticasModerador instancia = new FVistaSeccionCriticasModerador();
        ENCritica critica;
        DataView dv;
        DataTable pendientes;
        int numFilas = 16;
        int pagAct, numPaginas, numPendientes;
        bool modificable, modificarActivo, botonPuesto;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private FVistaSeccionCriticasModerador()
            : base() 
        {
            InitializeComponent();
            this.etSeccion.Text = "Críticas de Programas";
            
        }

        public static FVistaSeccionCriticasModerador Instancia
        {
          get 
          {
              return instancia; 
          }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by FVistaSeccionCriticasModerador for load events. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FVistaSeccionCriticasModerador_Load(object sender, EventArgs e)
        {
            critica = new ENCritica();
            botonPuesto = false;
            //para controlar que el usuario no acceda a la pestaña modificar
            // si esta no ha cargado nada
            modificarActivo = false;
            PrepararPendientes();
            pagAct = 1;
            numPendientes = 0;
            modificable = false;
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
                dv = critica.InicializarListadoProgramas();
                pendientes = critica.InicializarPendientes();

                if (botonPuesto == false)
                {
                    //creamos una columna de botones para añadir a las que mostrará el dataSet
                    DataGridViewButtonColumn colBotones = new DataGridViewButtonColumn();
                    colBotones.Name = "MOSTRAR";
                    dgvCriticas.Columns.Add(colBotones);
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
                
                // añadimos los valores al DG
                dv.Sort = " fecha_critica DESC";
                InicializarNumPaginas(dv.Count);
                ActualizarDG();
            }
            catch (Exception ex)
            {
                MensajeSistema(etInfoCON, ex.ToString(), kMensajeSistema.mERROR);
                MensajeSistema(etInfoINS_MOD, ex.ToString(), kMensajeSistema.mERROR);
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
            dv = critica.ObtenerListadoProgramas();
            if (pendientes.Rows.Count == 0)
            {
                pendientes = critica.InicializarPendientes();
            }
            dv.RowFilter = condiciones;
            dv.Sort = " fecha_critica DESC";
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
            dgvCriticas.RowHeadersVisible = false;
            // las columnas siguientes no serán mostradas tal cual,
            // sus datos serán formateados en las columnas con su mismo nombre seguido de aux
            // ejemplo canal se verá en canalAux
            dgvCriticas.Columns["cadena"].Visible = false;
            dgvCriticas.Columns["tematica"].Visible = false;
            dgvCriticas.Columns["calificacion"].Visible = false;
            dgvCriticas.Columns["novedad"].Visible = false;
            dgvCriticas.Columns["id"].Visible = false;
            // ajustamos los tamaños de las columnas
            dgvCriticas.Columns["moderador"].Width = 70;
            dgvCriticas.Columns["fecha_critica"].Width = 95;
            dgvCriticas.Columns["descripcion"].Width = 100;
            dgvCriticas.Columns["nombre"].Width = 150;
            dgvCriticas.Columns["critica"].Width = 120;
            dgvCriticas.Columns["canalAux"].Width = 80;
            dgvCriticas.Columns["tematicaAux"].Width = 60;
            dgvCriticas.Columns["calificacionAux"].Width = 67;
            dgvCriticas.Columns["novedadAux"].Width = 55;
            dgvCriticas.Columns["MOSTRAR"].Width = 61;
            // cambiamos las cabeceras de las columnas auxiliares
            dgvCriticas.Columns["canalAux"].HeaderText = "Canal";
            dgvCriticas.Columns["tematicaAux"].HeaderText = "Tematica";
            dgvCriticas.Columns["calificacionAux"].HeaderText = "Calificación";
            dgvCriticas.Columns["novedadAux"].HeaderText = "Novedad";
            // y del resto
            dgvCriticas.Columns["moderador"].HeaderText = "Moderador";
            dgvCriticas.Columns["fecha_critica"].HeaderText = "Fecha";
            dgvCriticas.Columns["descripcion"].HeaderText = "Descripción";
            dgvCriticas.Columns["nombre"].HeaderText = "Programa";
            dgvCriticas.Columns["critica"].HeaderText = "Crítica";
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
            dgvCriticas.DataSource = critica.ObtenerTablaProgramas(dv, primerRegistro, ultimoRegistro);
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

        private void dgvCriticas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // si se ha pulsado el botón
                if (dgvCriticas.Columns[e.ColumnIndex].Name == "MOSTRAR")
                {
                    int idAux, idCanal, idTematica, idCalificacion, novedadAux;
                    DateTime fechaAux;
                    //se rellenan los campos de la segunda pestaña
                    sPrograma.Text = dgvCriticas.Rows[e.RowIndex].Cells["nombre"].Value.ToString();
                    sCanal.Text = dgvCriticas.Rows[e.RowIndex].Cells["canalAux"].Value.ToString();
                    if (dgvCriticas.Rows[e.RowIndex].Cells["fecha_critica"].Value.ToString() == "")
                    {
                        sFecha.Text = "";
                        fechaAux = DateTime.Now;
                    }
                    else
                    {
                        sFecha.Text = dgvCriticas.Rows[e.RowIndex].Cells["fecha_critica"].Value.ToString();
                        fechaAux = DateTime.Parse(sFecha.Text);
                    }
                    sDescripcion.Text = dgvCriticas.Rows[e.RowIndex].Cells["descripcion"].Value.ToString();
                    sAutor.Text = dgvCriticas.Rows[e.RowIndex].Cells["moderador"].Value.ToString();
                    eCritica.Text = dgvCriticas.Rows[e.RowIndex].Cells["critica"].Value.ToString();

                    idAux = int.Parse(dgvCriticas.Rows[e.RowIndex].Cells["id"].Value.ToString());
                    idCanal = int.Parse(dgvCriticas.Rows[e.RowIndex].Cells["cadena"].Value.ToString());
                    idTematica = int.Parse(dgvCriticas.Rows[e.RowIndex].Cells["tematica"].Value.ToString());
                    idCalificacion = int.Parse(dgvCriticas.Rows[e.RowIndex].Cells["calificacion"].Value.ToString());
                    if (dgvCriticas.Rows[e.RowIndex].Cells["novedad"].Value.ToString() == "no")
                    {
                        novedadAux = 0;
                    }
                    else
                    {
                        novedadAux = 1;
                    }
                    // se inicializa el objeto ENCritica con los datos del DataGrid
                    critica.EstablecerPrograma(idAux, idCanal, sPrograma.Text, sDescripcion.Text, idTematica, idCalificacion, novedadAux, sAutor.Text, eCritica.Text, fechaAux);
                    // si ya tiene critica no se puede añadir otra
                    if (sAutor.Text != "" && modificable == false)
                    {
                        eCritica.Enabled = false; //se desabilita la caja de texto
                        bValidar.Enabled = false;
                        bValidarTemp.Enabled = false;
                        btnLimpiar.Enabled = false;
                    }
                    else
                    {
                        eCritica.Enabled = true;
                        bValidar.Enabled = true;
                        bValidarTemp.Enabled = true;
                        btnLimpiar.Enabled = true;
                    }
                    // muestra la pestaña con datos
                    modificarActivo = true;
                    pestanyasSeccionBase.SelectedTab = tpInsertar;
                    eCritica.Focus();
                }
                else if (dgvCriticas.Columns[e.ColumnIndex].Name == "descripcion")
                {
                    MessageBox.Show(dgvCriticas.Rows[e.RowIndex].Cells["descripcion"].Value.ToString(), "Descripción", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch { }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by dgvCriticas for cell painting events. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Data grid view cell painting event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void dgvCriticas_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && this.dgvCriticas.Columns[e.ColumnIndex].Name == "MOSTRAR" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                DataGridViewButtonCell celBoton = this.dgvCriticas.Rows[e.RowIndex].Cells["MOSTRAR"] as DataGridViewButtonCell;

                // si ya esta respondida muestra el texto "mostrar", en otro caso "responder"
                // si no es NULL
                if (dgvCriticas.Rows[e.RowIndex].Cells["moderador"].Value != null)
                {
                    if (dgvCriticas.Rows[e.RowIndex].Cells["moderador"].Value.ToString() != "")
                    {
                        if (modificable) //si es una de las respuestas no confirmadas podemos editarla
                        {
                            e.Graphics.DrawString("Añadir", new Font("Segoe UI", 9), new SolidBrush(Color.Black), e.CellBounds.Left + 12, e.CellBounds.Top + 3);
                        }
                        else
                        {
                            e.Graphics.DrawString("Mostrar", new Font("Segoe UI", 9), new SolidBrush(Color.Black), e.CellBounds.Left + 8, e.CellBounds.Top + 3);
                        }
                    }
                    else
                    {
                        e.Graphics.DrawString("Añadir", new Font("Segoe UI", 9), new SolidBrush(Color.Black), e.CellBounds.Left + 12, e.CellBounds.Top + 3);
                    }
                }
                else
                {
                    e.Graphics.DrawString("Añadir", new Font("Segoe UI", 9), new SolidBrush(Color.Black), e.CellBounds.Left + 12, e.CellBounds.Top + 3);
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
                    }//añadido _critica en ambas condiciones
                    condiciones += "fecha_critica >= '" + eFInicio.Value.ToString() + "' AND fecha_critica <= '" + eFFin.Value.ToString() + "'";
                }

                // solo los no validados
                if (rbSinCritica.Checked == true)
                {
                    if (condiciones.Length > 0)
                    {
                        condiciones += " AND ";
                    }
                    condiciones += "moderador LIKE ''";
                }
                else if (rbConCritica.Checked == true)
                {
                    if (condiciones.Length > 0)
                    {
                        condiciones += " AND ";
                    }
                    condiciones += "moderador NOT LIKE ''";
                }

                // por canal
                if (cbCadena.Text != "")
                {
                    if (condiciones.Length > 0)
                    {
                        condiciones += " AND ";
                    }
                    // obtenemos el id del canal asociado al nombre seleccionado
                    int idCanal = critica.ObtenerIdCanal(cbCadena.Text);
                    condiciones += "(cadena =" + idCanal + ")";
                }

                // por nombre
                if (tbPrograma.Text != "")
                {
                    if (condiciones.Length > 0)
                    {
                        condiciones += " AND ";
                    }
                    condiciones += "(nombre LIKE '%" + tbPrograma.Text + "%')";
                }
            }
            else
            {
                condiciones = "id = -1";
                // con esta condición no mostrará nada
            }
            // Mostramos los datos en el DataGrid según los criterios anteriores
            PrepararDatosDG(condiciones);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   
        /// Añade una crítica pero todavía no la actualiza en la Base de Datos, aunque sí actualiza el
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
                critica.Critica = eCritica.Text;
                critica.Moderador = administrador.Dni;
                critica.FechaCritica = DateTime.Now;
                // Guardamos la fila modificada por si hay que mostrarla
                pendientes.ImportRow(critica.AnadirCritica());
                ActualizarDG();
                // Tenemos otra respuesta pendiente de confirmación en la BD
                numPendientes++;
                gbPendientes.Visible = true;
                bGuardarPendientes.Enabled = true;
                bCancelarPendientes.Enabled = true;
                sPendientes.Text = "Tiene " + numPendientes + " críticas pendientes de ser confirmados";
                MensajeSistema(etInfoCON, "Crítica a la espera de ser confirmada.", kMensajeSistema.mCORRECTO);
                MensajeSistema(etInfoINS_MOD, "Crítica a la espera de ser confirmada.", kMensajeSistema.mCORRECTO);
                modificarActivo = false;
                pestanyasSeccionBase.SelectedTab = tpSeccionBaseConsultar;
                bGuardarPendientes.Focus();
            }
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
                    critica.Critica = eCritica.Text;
                    critica.FechaCritica = DateTime.Now;
                    critica.Moderador = administrador.Dni;
                    critica.AnadirCritica();
                    critica.ConfirmarCambios();
                    ActualizarDG();
                    modificarActivo = false;
                    pestanyasSeccionBase.SelectedTab = tpSeccionBaseConsultar;
                    MensajeSistema(etInfoCON, "Crítica almacenada con éxito.", kMensajeSistema.mCORRECTO);
                    MensajeSistema(etInfoINS_MOD, "Crítica almacenada con éxito.", kMensajeSistema.mCORRECTO);
                }
                catch (Exception ex)
                {
                    MensajeSistema(etInfoCON, ex.ToString(), kMensajeSistema.mERROR);
                    MensajeSistema(etInfoINS_MOD, ex.ToString(), kMensajeSistema.mERROR);
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

        private void btnPaginaSiguiente_Click(object sender, EventArgs e)
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

        private void btnPaginaAnterior_Click(object sender, EventArgs e)
        {
            pagAct--;
            ActualizarDG();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Guarda en la BD todas las críticas pendientes de confirmación. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void bGuardarPendientes2_Click(object sender, EventArgs e)
        {
            try
            {
                critica.ConfirmarCambios();
                gbPendientes.Visible = false;
                bGuardarPendientes.Enabled = false;
                bCancelarPendientes.Enabled = false;
                pendientes.Clear();
                numPendientes = 0;
                MensajeSistema(etInfoCON, "Críticas almacenadas con éxito.", kMensajeSistema.mCORRECTO);
                MensajeSistema(etInfoINS_MOD, "Críticas almacenadas con éxito.", kMensajeSistema.mCORRECTO);
            }
            catch (Exception ex)
            {
                MensajeSistema(etInfoCON, ex.ToString(), kMensajeSistema.mERROR);
                MensajeSistema(etInfoINS_MOD, ex.ToString(), kMensajeSistema.mERROR);
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

        private void bCancelarPendientes2_Click(object sender, EventArgs e)
        {
            gbPendientes.Visible = false;
            bGuardarPendientes.Enabled = false;
            bCancelarPendientes.Enabled = false;
            pendientes.Clear();
            MensajeSistema(etInfoCON, "Críticas pendientes eliminadas con éxito.", kMensajeSistema.mCORRECTO);
            MensajeSistema(etInfoINS_MOD, "Críticas pendientes eliminadas con éxito.", kMensajeSistema.mCORRECTO);
            //PrepararDatosDG("");
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

            if (eCritica.Text == "")
            {
                TbSeccionBaseErrorProvider.SetError(eCritica, "La crítica debe contener algún texto");
                eCritica.Focus();
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
            DataView listaCanales = critica.DevolverCanales();
            cbCadena.Items.Add("");
            foreach (DataRowView dr in listaCanales)
            {
                cbCadena.Items.Add(dr["nombre"].ToString());
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Limpia el contenido de critica. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            eCritica.Clear();
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
        /// Rellena el DataGrid con las criticaspendientes de ser almacenadas en la
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
            dgvCriticas.DataSource = pendientes;
            modificable = true;
            pagAct = numPaginas = 1;
            etInfoPAG.Text = "Pagina " + pagAct + " de " + numPaginas;
            ActualizarBotonesPaginacion();
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
        /// <summary>   Al pulsarlo muestra resultados de la búsqueda rápida. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void imgBusquedaRapida_Click_1(object sender, EventArgs e)
        {
            TbSeccionBaseErrorProvider.Dispose();
            string condiciones = "";
            if (tbBusquedaRapida.Text != "")
            {
                // AUTOR
                condiciones += "(moderador LIKE '%" + tbBusquedaRapida.Text + "%')";
                // CANAL
                // obtenemos el id del canal asociado al nombre seleccionado
                int idCanal = critica.ObtenerIdCanal(tbBusquedaRapida.Text);
                if (idCanal > -1)
                {
                    condiciones += " OR (cadena =" + idCanal + ")";
                }

                // PROGRAMA
                condiciones += "OR (nombre LIKE '%" + tbBusquedaRapida.Text + "%')";
                // DESCRIPCION
                condiciones += " OR (descripcion LIKE '%" + tbBusquedaRapida.Text + "%')";
            }

            // Mostramos los datos en el DataGrid según los criterios anteriores
            PrepararDatosDG(condiciones);
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
