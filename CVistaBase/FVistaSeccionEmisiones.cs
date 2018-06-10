using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using TVO_EntidadesDeNegocio;

namespace TVO_VistaWindows
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Vista seccion emisiones. </summary>
    ///
    /// <remarks>   TVO DPAA 2009-2010. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class FVistaSeccionEmisiones : TVO_VistaWindows.FVistaSeccionBase
    {
        private static readonly FVistaSeccionEmisiones instancia = new FVistaSeccionEmisiones();

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor por defecto. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private FVistaSeccionEmisiones()
            : base()
        {
            InitializeComponent();
            this.etSeccion.Text = "Gestión de Emisiones";
            this.etAccion.Text = "CONSULTAR";
            pestanyasSeccionBase.GetControl(1).Text = "Insertar";
            FechaHoraEmision.CustomFormat = "dd/MM/yyyy HH:mm:ss tt";
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Devuelve la instancia. </summary>
        ///
        /// <value> The instancia. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static FVistaSeccionEmisiones Instancia
        {
            get
            {
                return instancia;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Inicializa la sección emisiones. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        override public void Init()
        {
            base.Init();
            TbSeccionBaseErrorProvider.Dispose();
            //ActualizaVistaForm("consultar");
            gbInfo.Visible = false;
            gbSistemaInfo.Visible = false;
            labelPrograma.Visible = false;
            labelNomCadena.Visible = false;

            if (cbCadenaINS_MOD.Items.Count > 0)
                cbCadenaINS_MOD.SelectedIndex = 1;
            if (cbProgramaINS_MOD.Items.Count > 0)
                cbProgramaINS_MOD.SelectedIndex = 1;

            nUPMinutos.Value = 0;
            FechaHoraEmision.Value = DateTime.Now;
            RellenarComboBoxCadenas();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Actualiza vista form. </summary>
        ///Cambia la información de la pantalla.
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="tipoVista">    El tipo de vista. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void ActualizaVistaForm(string tipoVista)
        {
            if (tipoVista == "modificar")
            {
                pestanyasSeccionBase.GetControl(1).Text = "Modificar";
                gBInsMod.Text = "Modificar datos de la emisión";
                btInsertar.Text = "Modificar";
                cbCadenaINS_MOD.Enabled = false;
                cbProgramaINS_MOD.Enabled = false;
                gbInfo.Visible = false;
                TbSeccionBaseErrorProvider.Dispose();
                this.etAccion.Text = "MODIFICAR";
                btLimpiar.Visible = false;
            }

            if (tipoVista == "insertar")
            {
                pestanyasSeccionBase.GetControl(1).Text = "Insertar";
                TbSeccionBaseErrorProvider.Dispose();
                gBInsMod.Text = "Nueva emisión";
                btInsertar.Text = "Insertar";
                this.etAccion.Text = "INSERTAR";
                cbCadenaINS_MOD.Enabled = true;
                cbProgramaINS_MOD.Enabled = true;
                gbInfo.Visible = false;
                nUPMinutos.Value = 0;
                FechaHoraEmision.Value = DateTime.Now;
                btLimpiar.Visible = true;
            }

            if (tipoVista == "consultar")
            {
                pestanyasSeccionBase.GetControl(1).Text = "Insertar";
                TbSeccionBaseErrorProvider.Dispose();
                gBInsMod.Text = "Nueva emisión";
                btInsertar.Text = "Insertar";
                this.etAccion.Text = "CONSULTAR";
                cbCadenaINS_MOD.Enabled = true;
                cbProgramaINS_MOD.Enabled = true;
                gbInfo.Visible = false;
                nUPMinutos.Value = 0;
                FechaHoraEmision.Value = DateTime.Now;
                btLimpiar.Visible = true;
            }

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Llamado por pestanyasSeccionBase for click events. </summary>
        ///Llama al método de cambiar la información de la pantalla según la pestaña
        ///en la que hemos hecho click.
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        override public void pestanyasSeccionBase_Click(object sender, EventArgs e)
        {
            if (pestanyasSeccionBase.SelectedTab.Text == "Consultar")
            {
                ActualizaVistaForm("consultar");
            }
            else if (pestanyasSeccionBase.SelectedTab.Text == "Insertar")
            {
                ActualizaVistaForm("insertar");
            }
            Init();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Inicializar data grid view. </summary>
        ///Se crean dos columnas en el datagridview inicial, con las columnas de eliminar y modificar.
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void InicializarDataGridView()
        {
            DataGridViewButtonColumn colBotonesMod = new DataGridViewButtonColumn();
            colBotonesMod.UseColumnTextForButtonValue = true;
            colBotonesMod.Text = "Mod";
            colBotonesMod.Width = 60;
            colBotonesMod.Name = "btnModificar";
            colBotonesMod.HeaderText = "Modificar";

            DataGridViewButtonColumn colBotonesElim = new DataGridViewButtonColumn();
            colBotonesElim.UseColumnTextForButtonValue = true;
            colBotonesElim.Text = "Elim";
            colBotonesElim.Width = 50;
            colBotonesElim.Name = "btnEliminar";
            colBotonesElim.HeaderText = "Eliminar";


            dGWEmisiones.Columns.Insert(0, colBotonesMod);
            dGWEmisiones.Columns.Insert(1, colBotonesElim);

            //anchos automáticos
            dGWEmisiones.AutoResizeColumnHeadersHeight();
            dGWEmisiones.AutoResizeColumns();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Llamada por el botón buscar al evento click. </summary>
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
            ENEmision emisiones = new ENEmision();
            DataView dvResultadoBusqueda = new DataView();
            int compararMinutos = -1; //0 Menor que, 1 Igual, 2 Mayor que

            try
            {
                //limpia las filas seleccionadas anteriormente
                dGWEmisiones.ClearSelection();
                
                //A la nueva emisión se le asigna el id de la cadena
                //La id de la cadena se encuentra internamente en el combobox.
                emisiones.Id_cadena = ObtenerIdCadena(cbCadenaCON);

                //programa
                emisiones.Id_programa = ObtenerIdPrograma(cbProgramaCON);

                //fecha y hora
                int anyo = FechaHoraBusc.Value.Year;
                int mes = FechaHoraBusc.Value.Month;
                int dia = FechaHoraBusc.Value.Day;

                emisiones.FechaHoraInicio = new DateTime(anyo, mes, dia, 0, 0, 0);

                //Duración
                emisiones.Duracion = int.Parse(nUPMinutosBusc.Text);
                if (rBMenos.Checked)
                    compararMinutos = 0;
                if (rBIgual.Checked)
                    compararMinutos = 1;
                if (rBMas.Checked)
                    compararMinutos = 2;

                if (Paginar)
                {
                    // Obtenemos el tamaño de la consulta
                    TOTAL_registros = emisiones.obtenerTamanyoConsulta(compararMinutos);
                    
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
                        //obtenerEmisiones devuelve un dataview con la tabla de emisiones              
                        dvResultadoBusqueda = emisiones.obtenerEmisiones(compararMinutos, ACTUAL_registro, PAGINA_registros);
                    }
                }
                else //no se ha paginado
                {
                    //obtenerEmisiones devuelve un dataview con la tabla de emisiones              
                    dvResultadoBusqueda = emisiones.obtenerEmisiones(compararMinutos);
                    TOTAL_registros = dvResultadoBusqueda.Table.Rows.Count;
                    if (TOTAL_registros <= MIN_PAGINA_registros) //no se permite paginar
                        checkPaginar.Enabled = false;
                    else 
                        checkPaginar.Enabled = true;
                }

                //el datagrid obtiene el resultado del dataview
                dGWEmisiones.DataSource = dvResultadoBusqueda;

                gbSistemaInfo.Visible = true;

                if (dvResultadoBusqueda.Count == 0)
                    dGWEmisiones.Visible = false;
                else
                {
                    darFormatoDataGrid();
                    dGWEmisiones.Visible = true;
                }

                if (dvResultadoBusqueda.Count == 1)
                    MensajeSistema(etSistemaInfo, "Se ha obtenido 1 resultado.", kMensajeSistema.mCORRECTO);
                else
                    MensajeSistema(etSistemaInfo, "Se han obtenido " + dvResultadoBusqueda.Count + " resultados.", kMensajeSistema.mCORRECTO);
            }
            catch (ENException enex)
            {
                if(enex.Tipo!=-1)
                    MensajeSistema(etSistemaInfo, enex.Message, kMensajeSistema.mADVERTENCIA);
                else
                    MensajeSistema(etSistemaInfo, enex.Message, kMensajeSistema.mERROR);
                gbSistemaInfo.Visible = true;
            }
            catch (Exception ex)
            {
                checkPaginar.Checked = false;
                checkPaginar_CheckedChanged((CheckBox)checkPaginar, null);
                MensajeSistema(etSistemaInfo, "Se ha desactivado la paginación debido a que sólo hay 1 página", kMensajeSistema.mADVERTENCIA);
                checkPaginar.Enabled = false;
                gbSistemaInfo.Visible = true;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Obtener identificador programa. </summary>
        /// A partir del combobox con los programas obtiene el id del programa.
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="combobox"> The combobox. </param>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private int ObtenerIdPrograma(ComboBox combobox)
        {
            int idPrograma = -1;

            if (combobox.Items.Count > 0) //Si el combobox programas ya tiene elementos
            {
                DataRowView filaPrograma = (DataRowView)combobox.SelectedItem;

                idPrograma = int.Parse(filaPrograma["id"].ToString());
            }
            return idPrograma;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Obtener identificador cadena. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="combobox"> The combobox. </param>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private int ObtenerIdCadena(ComboBox combobox)
        {
            int idCadena = -1;

            if (combobox.Items.Count > 0) //Si el combobox cadenas ya tiene elementos
            {
                DataRowView filaCadena = (DataRowView)combobox.SelectedItem;

                idCadena = int.Parse(filaCadena["id"].ToString());
            }

            return idCadena;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Dar formato data grid. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void darFormatoDataGrid()
        {
            //vista de las cabeceras
            dGWEmisiones.RowHeadersVisible = false;

            //columnas no visibles
            dGWEmisiones.Columns["Duracion"].Visible = false;
            dGWEmisiones.Columns["FechaHora"].Visible = false;
            dGWEmisiones.Columns["IdEmision"].Visible = false;

            //ancho fijo para la columna de la fecha
            dGWEmisiones.Columns["FechaInicioFin"].Width = 200;

            //alineación del texto centrada
            dGWEmisiones.Columns["Programa"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dGWEmisiones.Columns["Cadena"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dGWEmisiones.Columns["FechaInicioFin"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //texto de las cabeceras
            dGWEmisiones.Columns["Programa"].HeaderText = "Programa";
            dGWEmisiones.Columns["Cadena"].HeaderText = "Cadena";
            dGWEmisiones.Columns["Duracion"].HeaderText = "Duración";
            dGWEmisiones.Columns["FechaInicioFin"].HeaderText = FechaHoraBusc.Value.ToLongDateString();

            //Obliga a que no se puede ordenar la columna de fechas
            dGWEmisiones.Columns["FechaInicioFin"].SortMode = DataGridViewColumnSortMode.NotSortable;

            //orden de las columnas
            dGWEmisiones.Columns["FechaInicioFin"].DisplayIndex = 2;
            dGWEmisiones.Columns["Programa"].DisplayIndex = 3;
            dGWEmisiones.Columns["Cadena"].DisplayIndex = 4;

            //sólo lectura
            dGWEmisiones.AllowUserToAddRows = false;
            dGWEmisiones.ReadOnly = true;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Valida campos busqueda. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <returns>   true if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private bool ValidaCamposBusqueda()
        {
            bool todoOK = true;

            DateTime FechaHoraActual = DateTime.Now;
            if (DateTime.Compare(FechaHoraBusc.Value, FechaHoraActual) < 0)
            {
                TbSeccionBaseErrorProvider.SetError(FechaHoraBusc, "La fecha y hora debe ser superior a la actual.");
                TbSeccionBaseErrorProvider.SetIconAlignment(FechaHoraBusc, ErrorIconAlignment.MiddleRight);
                TbSeccionBaseErrorProvider.SetIconPadding(FechaHoraBusc, 3);
                todoOK = false;
            }

            return todoOK;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. El botón insertar llama al evento clic. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btInsertar_Click(object sender, EventArgs e)
        {
            ENEmision nueva_emision = new ENEmision();
            TbSeccionBaseErrorProvider.Dispose();
            bool insertado = false, modificado = false;

            try
            {
                if (btInsertar.Text == "Insertar")
                {
                    if (ValidaCamposInsertar())
                    {

                        //A la nueva emisión se le asigna el id de la cadena
                        //obteniendola a partir del nombre.
                        nueva_emision.Id_cadena = ObtenerIdCadena(cbCadenaINS_MOD);

                        //programa
                        nueva_emision.Id_programa = ObtenerIdPrograma(cbProgramaINS_MOD);

                        //fecha y hora               
                        nueva_emision.FechaHoraInicio = FechaHoraEmision.Value;

                        //Duración
                        nueva_emision.Duracion = int.Parse(nUPMinutos.Text);

                        //Insertar la nueva emisión en la base de datos.
                        insertado = nueva_emision.insertarEmision();

                        if (insertado)//Se realiza la búsqueda de nuevo si se ha insertado                           
                            btnBuscar_Click((object)(btBuscar), null);

                        if (insertado)
                        {
                            MensajeSistema(etInfo, "Registro introducido correctamente.", kMensajeSistema.mCORRECTO);
                        }
                        else
                        {
                            // etInfo.Text = "NO SE HA REALIZADO LA INSERCIÓN";
                            MensajeSistema(etInfo, "NO SE HA REALIZADO LA INSERCIÓN", kMensajeSistema.mADVERTENCIA);
                        }
                        gbInfo.Visible = true;
                    }
                }
                else
                    if (btInsertar.Text == "Modificar")
                    {
                        //A la nueva emisión se le asigna el id de la cadena
                        //obteniendola a partir del nombre.
                        nueva_emision.Id_cadena = ObtenerIdCadena(cbCadenaINS_MOD);

                        //id_emision, necesaria para identificar la fila a modificar
                        nueva_emision.Id_emision = int.Parse(dGWEmisiones.SelectedCells[0].Value.ToString());

                        //fecha y hora               
                        nueva_emision.FechaHoraInicio = FechaHoraEmision.Value;

                        //Duración
                        nueva_emision.Duracion = int.Parse(nUPMinutos.Text);

                        modificado = nueva_emision.modificarEmision();

                        if (modificado)//Si se realiza la modificación                          
                            btnBuscar_Click((object)(btBuscar), null);

                        if (modificado)
                        {
                            MensajeSistema(etInfo, "Registro modificado correctamente.", kMensajeSistema.mCORRECTO);
                        }
                        else
                        {
                            MensajeSistema(etInfo, "NO SE HA REALIZADO LA MODIFICACIÓN", kMensajeSistema.mADVERTENCIA);
                        }
                        gbInfo.Visible = true;
                    }
            }
            catch (ENException enex)
            {
                MensajeSistema(etInfo, enex.Message, kMensajeSistema.mERROR);
                gbInfo.Visible = true;
            }
            catch (Exception ex)
            {
                MensajeSistema(etInfo, ex.Message, kMensajeSistema.mADVERTENCIA);
                gbInfo.Visible = true;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Valida campos insertar. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <returns>   true if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private bool ValidaCamposInsertar()
        {
            bool todoOK = true;

            if (cbCadenaINS_MOD.SelectedIndex == 0)
            {
                TbSeccionBaseErrorProvider.SetError(cbCadenaINS_MOD, "Se debe elegir una cadena de la lista.");
                TbSeccionBaseErrorProvider.SetIconAlignment(cbCadenaINS_MOD, ErrorIconAlignment.MiddleRight);
                TbSeccionBaseErrorProvider.SetIconPadding(cbCadenaINS_MOD, 3);
                todoOK = false;
            }

            if (cbProgramaINS_MOD.Text == "Sin programas")
            {
                TbSeccionBaseErrorProvider.SetError(cbProgramaINS_MOD, "No existe programas para la cadena elegida.");
                TbSeccionBaseErrorProvider.SetIconAlignment(cbProgramaINS_MOD, ErrorIconAlignment.MiddleRight);
                TbSeccionBaseErrorProvider.SetIconPadding(cbProgramaINS_MOD, 3);
                todoOK = false;
            }

            if (cbProgramaINS_MOD.Text == "Elegir programa")
            {
                TbSeccionBaseErrorProvider.SetError(cbProgramaINS_MOD, "Tiene que elegir un programa.");
                TbSeccionBaseErrorProvider.SetIconAlignment(cbProgramaINS_MOD, ErrorIconAlignment.MiddleRight);
                TbSeccionBaseErrorProvider.SetIconPadding(cbProgramaINS_MOD, 3);
                todoOK = false;
            }

            if (int.Parse(nUPMinutos.Text) == 0)
            {
                TbSeccionBaseErrorProvider.SetError(labelMinutos, "La duración debe ser superior a 0 minutos.");
                TbSeccionBaseErrorProvider.SetIconAlignment(labelMinutos, ErrorIconAlignment.MiddleRight);
                TbSeccionBaseErrorProvider.SetIconPadding(labelMinutos, 3);
                todoOK = false;
            }

            DateTime FechaHoraActual = DateTime.Now;
            if (DateTime.Compare(FechaHoraEmision.Value, FechaHoraActual) < 0)
            {
                TbSeccionBaseErrorProvider.SetError(FechaHoraEmision, "La fecha y hora debe ser superior a la actual.");
                TbSeccionBaseErrorProvider.SetIconAlignment(FechaHoraEmision, ErrorIconAlignment.MiddleRight);
                TbSeccionBaseErrorProvider.SetIconPadding(FechaHoraEmision, 3);
                todoOK = false;
            }

            return todoOK;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Rellenar combobox cadenas. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void RellenarComboBoxCadenas()
        {
            try
            {
                ENEmision cadenasActuales = new ENEmision();
                ENCadena cadenas = new ENCadena();

                //Se rellena el combobox de cadenas de la parte de consultas con las cadenas de emisión actual
                //fecha y hora
                int anyo = FechaHoraBusc.Value.Year;
                int mes = FechaHoraBusc.Value.Month;
                int dia = FechaHoraBusc.Value.Day;

                cadenasActuales.FechaHoraInicio = new DateTime(anyo, mes, dia, 0, 0, 0);
                cbCadenaCON.DataSource = cadenasActuales.ObtenerListaCadenasActuales();
                cbCadenaCON.DisplayMember = "nombre";

                if (cbCadenaCON.Items.Count == 0)
                {
                    cbCadenaCON.Text = "Sin datos de emisión.";
                    cbProgramaCON.Text = "Sin programas en emisión.";
                    cbCadenaCON.Enabled = false;
                    dGWEmisiones.Visible = false;
                }
                else
                    cbCadenaCON.Enabled = true;

                //Se rellena el combobox de cadenas de la parte de insertar/modificar con todas las cadenas
                //-------------------------------------------------------------------------
                DataTable tb = new DataTable();
                DataView dv = new DataView();
                dv = cadenas.ObtenerListaCadenas();
                tb = dv.ToTable();
                tb.Rows[0]["nombre"] = "Elegir cadena";

                cbCadenaINS_MOD.DataSource = tb.DefaultView;
                cbCadenaINS_MOD.DisplayMember = "nombre";
                labelNomCadena.Visible = false;
                labelPrograma.Visible = false;
                //--------------------------------------------------------------------------

                //Hasta que no se elija una cadena no se habilita el combobox
                //de los programas.

                //parte consulta
                cbProgramaCON.Text = "Elegir primero cadena";
                cbProgramaCON.Enabled = false;
                //parte insertar/modificar
                cbProgramaINS_MOD.Text = "Elegir primero cadena";
                cbProgramaINS_MOD.Enabled = false;
            }
            catch (ENException enex)
            {
                MensajeSistema(etSistemaInfo, enex.Message, kMensajeSistema.mERROR);
                gbSistemaInfo.Visible = true;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Rellenar combobox programas con. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="ENException">  Thrown when en. </exception>
        ///
        /// <param name="comboCadenas">     The combo cadenas. </param>
        /// <param name="comboProgramas">   The combo programas. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void RellenarComboboxProgramasCON(ComboBox comboCadenas, ComboBox comboProgramas)
        {
            ENEmision emision = new ENEmision();
            DataView dvprog = new DataView();
            DataRowView filaCadena = (DataRowView)comboCadenas.SelectedItem;

            try
            {
                string idCadena = filaCadena["id"].ToString();
                //fecha y hora
                int anyo = FechaHoraBusc.Value.Year;
                int mes = FechaHoraBusc.Value.Month;
                int dia = FechaHoraBusc.Value.Day;

                emision.FechaHoraInicio = new DateTime(anyo, mes, dia, 0, 0, 0);
                dvprog = emision.ObtenerProgramasDeCadenaActuales(idCadena);
                if (dvprog.Count > 0)//si se han obtenido programas a partir de la cadena
                {
                    comboProgramas.DataSource = dvprog;
                    comboProgramas.DisplayMember = "nombre";
                    comboProgramas.Enabled = true;
                }
                else//Si no se obtienen programas
                {
                    if (comboCadenas.SelectedIndex == 0) //Si en la cadena pone "Selecciona una cadena"
                    {
                        comboProgramas.Text = "Elegir primero cadena";
                        comboProgramas.Enabled = false;
                    }
                    else
                    {
                        comboProgramas.Text = "Sin programas";
                        comboProgramas.Enabled = false;//Deshabilita el combobox
                    }
                }

            }
            catch (ENException enex)
            {
                throw new ENException(enex.Mensaje);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Rellenar combobox programas inssertar/modificar. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="ENException">  Thrown when en. </exception>
        ///
        /// <param name="comboCadenas">     The combo cadenas. </param>
        /// <param name="comboProgramas">   The combo programas. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void RellenarComboboxProgramasINS_MOD(ComboBox comboCadenas, ComboBox comboProgramas)
        {
            ENPrograma programas = new ENPrograma();
            DataView dvprog = new DataView();
            DataRowView filaCadena = (DataRowView)comboCadenas.SelectedItem;
            DataTable tb = new DataTable();

            try
            {
                dvprog = programas.ObtenerProgramasDeCadena(filaCadena["id"].ToString());


                if (dvprog.Count > 0) //si se han obtenido programas a partir de la cadena
                {
                    tb = dvprog.ToTable();
                    tb.Rows[0]["nombre"] = "Elegir programa";
                    dvprog = tb.DefaultView;

                    comboProgramas.DataSource = dvprog;
                    comboProgramas.DisplayMember = "nombre";
                    comboProgramas.Enabled = true;
                }
                else //Si no se obtienen programas
                {
                    if (comboCadenas.SelectedIndex == 0) //Si en la cadena pone "Selecciona una cadena"
                    {
                        comboProgramas.Text = "Elegir primero cadena";
                        comboProgramas.Enabled = false;
                    }
                    else //Si pone una cadena en concreto pero no tiene programas
                    {
                        comboProgramas.Text = "Sin programas";
                        labelPrograma.Visible = false;
                        comboProgramas.Enabled = false;//Deshabilita el combobox
                    }
                }
            }
            catch (ENException enex)
            {
                throw new ENException(enex.Mensaje);
            }
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Evento click del botón limpiar. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btLimpiar_Click(object sender, EventArgs e)
        {
            Init();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Evento cell content click del datagrid. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="Exception">    Thrown when exception. </exception>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Data grid view cell event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void dGWEmisiones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                    throw new Exception();

                if (dGWEmisiones.Columns[e.ColumnIndex].Name == "btnModificar")
                {
                    cbCadenaINS_MOD.Text = dGWEmisiones.Rows[e.RowIndex].Cells["Cadena"].Value.ToString();
                    cbProgramaINS_MOD.Text = dGWEmisiones.Rows[e.RowIndex].Cells["Programa"].Value.ToString();
                    FechaHoraEmision.Value = DateTime.Parse(dGWEmisiones.Rows[e.RowIndex].Cells["fechaHora"].Value.ToString());
                    nUPMinutos.Value = (int)(dGWEmisiones.Rows[e.RowIndex].Cells["duracion"].Value);

                    dGWEmisiones.Rows[e.RowIndex].Cells["IdEmision"].Selected = true;

                    ActualizaVistaForm("modificar");
                    pestanyasSeccionBase.SelectTab(pestanyasSeccionBase.GetControl(1).Name);
                }
                else if (dGWEmisiones.Columns[e.ColumnIndex].Name == "btnEliminar")
                {
                    string programa = dGWEmisiones.Rows[e.RowIndex].Cells["Programa"].Value.ToString() + "\n";
                    string cadena = dGWEmisiones.Rows[e.RowIndex].Cells["Cadena"].Value.ToString() + "\n";
                    string fechaHora = dGWEmisiones.Rows[e.RowIndex].Cells["fechaHora"].Value.ToString();

                    if (MessageBox.Show("¿Desea eliminar la emisión\n:" + programa + cadena + fechaHora + " ?", "TEVEO :: Aplicación de gestión", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        bool eliminado = false;
                        
                            ENEmision emision = new ENEmision();
                            emision.Id_emision = int.Parse(dGWEmisiones.Rows[e.RowIndex].Cells["IdEmision"].Value.ToString());

                            eliminado = emision.eliminarEmision();

                            if (eliminado)
                            {
                                ActualizaVistaForm("insertar");//por defecto la vista de labels y pestañas pone insertar
                                MensajeSistema(etSistemaInfo, "Registro eliminado correctamente.", kMensajeSistema.mCORRECTO);
                                btnBuscar_Click((object)(btBuscar), null);
                            }
                            gbSistemaInfo.Visible = true;                    
                    }
                }
                else if (dGWEmisiones.Columns[e.ColumnIndex].Name == "Critica")
                {
                    string programa = dGWEmisiones.Rows[e.RowIndex].Cells["Programa"].Value.ToString() + "\n";
                    string critica = "Crítica: \n" + dGWEmisiones.Rows[e.RowIndex].Cells["Critica"].Value.ToString();

                    if (critica == "Crítica: \n")
                        critica = "Sin crítica";
                    string mensaje = programa + critica;

                    MessageBox.Show(mensaje, "TEVEO :: Aplicación de gestión", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else if (dGWEmisiones.Columns[e.ColumnIndex].Name == "Programa")
                {
                    string cadena = dGWEmisiones.Rows[e.RowIndex].Cells["Cadena"].Value.ToString() + "\n";
                    string programa = dGWEmisiones.Rows[e.RowIndex].Cells["Programa"].Value.ToString() + "\n";
                    string fecha = dGWEmisiones.Rows[e.RowIndex].Cells["FechaHora"].Value.ToString() + "\n";
                    string intervalo = dGWEmisiones.Rows[e.RowIndex].Cells["FechaInicioFin"].Value.ToString() + "\n";

                    string mensaje = cadena + programa + fecha + intervalo;

                    MessageBox.Show(mensaje, "TEVEO :: Aplicación de gestión", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
            }
            catch (ENException enex)
            {
                MensajeSistema(etSistemaInfo, enex.Message, kMensajeSistema.mERROR);
                gbSistemaInfo.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Evento load de la sección emisiones. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FVistaSeccionEmisiones_Load(object sender, EventArgs e)
        {
            tbBusquedaRapida.Visible = false;
            imgBusquedaRapida.Visible = false;
            nUPMinutos.Maximum = 999;
            nUPMinutos.Minimum = 0;
            InicializarDataGridView();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Llamado por cbCadenaCON para cambio de indices seleccionados. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void cbCadenaCON_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCadenaCON.SelectedIndex == 0)//Se ha elegido
            {
                //Hasta que no se elija una cadena no se habilita el combobox
                //de los programas.

                //parte consulta
                cbProgramaCON.DataSource = (new ArrayList()); //se vacía el combobox
                cbProgramaCON.Text = "Elegir primero cadena";
                cbProgramaCON.Enabled = false;
            }
            else
                RellenarComboboxProgramasCON(cbCadenaCON, cbProgramaCON);
            btnBuscar_Click((object)btBuscar, null); //buscar al elegir una cadena
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Llamado por cbCadenaINS_MOD for selected index changed events. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void cbCadenaINS_MOD_SelectedIndexChanged(object sender, EventArgs e)
        {
            RellenarComboboxProgramasINS_MOD(cbCadenaINS_MOD, cbProgramaINS_MOD);

            labelNomCadena.Text = cbCadenaINS_MOD.Text;
            if (cbCadenaINS_MOD.Text != "Elegir cadena")
            {
                labelNomCadena.Visible = true;
                labelPrograma.Visible = false;
            }
            else
            {
                labelNomCadena.Visible = false;
                labelPrograma.Visible = false;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Llamado por cbPrograma for selected index changed events. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void cbPrograma_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelPrograma.Text = cbProgramaINS_MOD.Text;
            if (cbProgramaINS_MOD.Text != "Elegir primero cadena" && cbProgramaINS_MOD.Text != "Elegir programa")
                labelPrograma.Visible = true;
            else
                labelPrograma.Visible = false;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Llamado por cbProgramaCON for selected index changed events. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void cbProgramaCON_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnBuscar_Click((object)btBuscar, null); //buscar al elegir un programa
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Llamado por FechaHoraBusc for value changed events. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FechaHoraBusc_ValueChanged(object sender, EventArgs e)
        {
            RellenarComboBoxCadenas();
            if (cbCadenaCON.Items.Count == 0)
            {
                cbCadenaCON.Text = "Sin datos de emisión.";
                cbProgramaCON.Text = "Sin programas en emisión.";
                cbCadenaCON.Enabled = false;
            }
            else
                cbCadenaCON.Enabled = true;
            btnBuscar_Click((object)btBuscar, null); //buscar al elegir una fecha
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Llamado por rBMas for checked changed events. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void rBMas_CheckedChanged(object sender, EventArgs e)
        {
            btnBuscar_Click((object)btBuscar, null); //buscar al elegir una comparación
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Llamado por rBIgual for checked changed events. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void rBIgual_CheckedChanged(object sender, EventArgs e)
        {
            btnBuscar_Click((object)btBuscar, null); //buscar al elegir una comparación
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Llamado por rBMenos for checked changed events. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void rBMenos_CheckedChanged(object sender, EventArgs e)
        {
            btnBuscar_Click((object)btBuscar, null); //buscar al elegir una comparación
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Llamado por nUPMinutosBusc for value changed events. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void nUPMinutosBusc_ValueChanged(object sender, EventArgs e)
        {
            btnBuscar_Click((object)btBuscar, null); //buscar al elegir una duración
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Llamado por checkPaginar for checked changed events. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void checkPaginar_CheckedChanged(object sender, EventArgs e)
        {
            if (checkPaginar.Checked)
            {
                Paginar = true;
                gbPaginacion.Visible = true;
                ACTUAL_registro = 1;

                btnPaginaUltima.Visible = true;
                btnPaginaSiguiente.Visible = true;
                btnPaginaPrimera.Visible = false;
                btnPaginaAnterior.Visible = false;
                MensajePaginacion(etInfoPAG, 1, getNumPaginasTotales());
                btnBuscar_Click((object)btBuscar, null);
            }
            else
            {
                Paginar = false;
                gbPaginacion.Visible = false;
                btnBuscar_Click((object)btBuscar, null);

            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Llamado por btnPaginaSiguiente for click events. </summary>
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
                btnBuscar_Click((object)btBuscar, null);
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
        /// <summary>   Event handler. Llamado por btnPaginaAnterior for click events. </summary>
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
                btnBuscar_Click((object)btBuscar, null);
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
        /// <summary>   Event handler. Llamado por btnPaginaUltima for click events. </summary>
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

            if (PAGINA_registros == 1) 
                ACTUAL_registro = TOTAL_registros - (TOTAL_registros % PAGINA_registros);
            else 
                ACTUAL_registro = TOTAL_registros - (TOTAL_registros % PAGINA_registros) + 1;
            btnBuscar_Click((object)btBuscar, null);
            MensajePaginacion(etInfoPAG, getNumPaginaActual(ACTUAL_registro), getNumPaginasTotales());
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Llamado por btnPaginaPrimera for click events. </summary>
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
            btnBuscar_Click((object)btBuscar, null);
            MensajePaginacion(etInfoPAG, 1, getNumPaginasTotales());
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Llamado por mtbRegistrosXPagina for leave events. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
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
                
                checkPaginar_CheckedChanged((CheckBox)checkPaginar, null);
            }
            else if (Convert.ToInt32(mtbRegistrosXPagina.Text) >= TOTAL_registros)
            {
                mtbRegistrosXPagina.Text = MIN_PAGINA_registros.ToString();
                PAGINA_registros = MIN_PAGINA_registros;
                checkPaginar.Checked = false;
                checkPaginar_CheckedChanged((CheckBox)checkPaginar, null);
                MensajeSistema(etSistemaInfo, "Se ha desactivado la paginación debido a que sólo hay 1 página", kMensajeSistema.mADVERTENCIA);
                checkPaginar.Checked = false;

            }
            else
            {
                PAGINA_registros = Convert.ToInt32(mtbRegistrosXPagina.Text);
                checkPaginar_CheckedChanged((CheckBox)checkPaginar, null);
            }
            etPaginacionInfo.Visible = false;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Llamado por mtbRegistrosXPagina for key down events. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
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
        /// <summary>   Event handler. Llamado por mtbRegistrosXPagina for enter events. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void mtbRegistrosXPagina_Enter(object sender, EventArgs e)
        {
            etPaginacionInfo.Visible = true;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Llamado por cbCadenaCON for key down events. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Key event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void cbCadenaCON_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnBuscar_Click((object)btBuscar, null);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Llamado por cbProgramaCON for key down events. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Key event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void cbProgramaCON_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnBuscar_Click((object)btBuscar, null);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Llamado por dGWEmisiones for cell mouse move events. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Data grid view cell mouse event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void dGWEmisiones_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex != -1)
            {
                if (dGWEmisiones.Columns[e.ColumnIndex].Name == "Programa" || dGWEmisiones.Columns[e.ColumnIndex].Name == "Critica")
                {
                    this.Cursor = Cursors.Hand;
                }
                else
                    this.Cursor = Cursors.Default;
            }
        }


    }
}
