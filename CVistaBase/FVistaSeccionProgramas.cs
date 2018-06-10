using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using TVO_Utiles;
using System.Windows.Forms;
using TVO_EntidadesDeNegocio;

////////////////////////////////////////////////////////////////////////////////////////////////////
// namespace: TVO_VistaWindows
//
// summary:	Implementa la vista de la sección clase programas.
////////////////////////////////////////////////////////////////////////////////////////////////////

namespace TVO_VistaWindows
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Vista seccion programas. </summary>
    ///
    /// <remarks>   TVO DPAA 2009-2010. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class FVistaSeccionProgramas : TVO_VistaWindows.FVistaSeccionBase
    {
        private static readonly FVistaSeccionProgramas instancia = new FVistaSeccionProgramas();
        //---------------------cambios paginación---------------------
        delegate void Busqueda(object sender, EventArgs e);
        Busqueda MetodoBusqueda;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor por defecto de la vista de Programas. </summary>
        ///
        /// <remarks>   TVO Grupo DPAA2009-2010, 14/04/2010. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private FVistaSeccionProgramas()
            : base()
        {
            InitializeComponent();
            this.etSeccion.Text = "Gestión de Programas";
            this.etAccion.Text = "CONSULTAR";
            vistaTecnico();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets de la instancia. </summary>
        ///
        /// <value> The instancia. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static FVistaSeccionProgramas Instancia
        {
            get
            {
                return instancia;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Inicializador del objeto. </summary>
        ///
        /// <remarks>   TVO Grupo DPAA2009-2010, 14/04/2010. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        override public void Init()
        {
            base.Init();

            TbSeccionBaseErrorProvider.Dispose();

            // btnLimpiar_Click((object)btnLimpiar, null);
            //InicializarDataGridView();
            MetodoBusqueda = buttonBuscar_Click;
            gbMensajes.Visible = false;
            dGVResultBProg.Visible = false;
            // gbInfoCON.Visible = false;

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Llamada al evento asociado al botón Buscar. </summary>
        ///
        /// <remarks>   TVO Grupo DPAA2009-2010, 14/04/2010. </remarks>
        ///
        /// <exception cref="Exception">    Thrown when exception. </exception>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            MetodoBusqueda = buttonBuscar_Click;
            int idCad = 0, idTem = 0, idCal = 0;
            idCad = ObtenerIdCadena(cBBCadena);
            idTem = ObtenerIdTematica(cBBTematica);
            idCal = ObtenerIdCalif(cBBCalificacion);

            ENPrograma prog = new ENPrograma(tBBNombreProg.Text, idTem, idCal, idCad);

            DataView dvResultBusq = new DataView();

            try
            {

                if (Paginar)
                {
                    dGVResultBProg.ClearSelection();
                    // Obtenemos el tamaño de la consulta
                    TOTAL_registros = prog.obtenerTamanyoConsulta();

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
                        dvResultBusq = prog.buscarPrograma(ACTUAL_registro, PAGINA_registros);
                    }
                    gbMensajes.Visible = true;
                }
                else
                {
                    dvResultBusq = prog.buscarPrograma();
                    TOTAL_registros = dvResultBusq.Table.Rows.Count;
                    if (TOTAL_registros <= MIN_PAGINA_registros)
                        chkPaginacion.Enabled = false;
                    else
                        chkPaginacion.Enabled = true;
                }
                //Si obtengo resultados, le asigno la tabla al datagrid
                if (dvResultBusq.Count > 0)
                {
                    dGVResultBProg.DataSource = dvResultBusq;
                    darFormatoDataGrid();
                    dGVResultBProg.Visible = true;
                }
                else
                    dGVResultBProg.Visible = false;

                if (dvResultBusq.Count == 1)
                    MensajeSistema(labelMensSistPB, "Se ha obtenido 1 resultado.", kMensajeSistema.mCORRECTO);
                else
                    MensajeSistema(labelMensSistPB, "Se han obtenido " + dvResultBusq.Count + " resultados.", kMensajeSistema.mCORRECTO);
                gbMensajes.Visible = true;
            }
            catch (ENException enex)
            {
                if (enex.Tipo != -1)
                    MensajeSistema(labelMensSistPB, enex.Message, kMensajeSistema.mADVERTENCIA);

                else
                    MensajeSistema(labelMensSistPB, enex.Message, kMensajeSistema.mERROR);

                gbMensajes.Visible = true;
               // MessageBox.Show(enex.Message);
            }
            catch (Exception ex)
            {
                chkPaginacion.Checked = false;
                chkPaginacion_CheckedChanged((CheckBox)chkPaginacion, null);
                MensajeSistema(labelMensSistPB, "Se ha desactivado la paginación debido a que sólo hay 1 página", kMensajeSistema.mADVERTENCIA);
                chkPaginacion.Enabled = false;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Método utilizado para dar formato al data grid. </summary>
        ///
        /// <remarks>   TVO Grupo DPAA2009-2010, 14/04/2010. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void darFormatoDataGrid()
        {
            dGVResultBProg.RowHeadersVisible = false;

            //Alineación texto 
            dGVResultBProg.Columns["nomProg"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dGVResultBProg.Columns["nomTematica"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dGVResultBProg.Columns["nomCadena"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dGVResultBProg.Columns["nomCalif"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dGVResultBProg.Columns["ActivadoPrograma"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dGVResultBProg.Columns["Novedad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //ancho de columnas
            /*dGVResultBProg.Columns["nomProg"].Width = 120;
            dGVResultBProg.Columns["nomTematica"].Width = 120;
            dGVResultBProg.Columns["nomCadena"].Width = 40;
            dGVResultBProg.Columns["nomCalif"].Width = 60;
            dGVResultBProg.Columns["ActivadoPrograma"].Width = 30;
            dGVResultBProg.Columns["Novedad"].Width = 30;*/

            //nombre de columnas en dgv
            dGVResultBProg.Columns["nomProg"].HeaderText = "Nombre";
            dGVResultBProg.Columns["nomTematica"].HeaderText = "Temática";
            dGVResultBProg.Columns["nomCalif"].HeaderText = "Calificación";
            dGVResultBProg.Columns["nomCadena"].HeaderText = "Cadena";
            dGVResultBProg.Columns["ActivadoPrograma"].HeaderText = "Programa Activo";
            dGVResultBProg.Columns["Novedad"].HeaderText = "Nuevo Programa";
            dGVResultBProg.Columns["descProg"].HeaderText = "Descripción";

            //Columnas "no visibles"
            dGVResultBProg.Columns["idProg"].Visible = false;
            dGVResultBProg.Columns["idCadena"].Visible = false;
            dGVResultBProg.Columns["idTematica"].Visible = false;
            dGVResultBProg.Columns["idCalif"].Visible = false;
            dGVResultBProg.Columns["actProg"].Visible = false;
            dGVResultBProg.Columns["novProg"].Visible = false;

            //dGVResultBProg.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
            //anchos automáticos
            dGVResultBProg.AutoResizeColumnHeadersHeight();
            dGVResultBProg.AutoResizeColumns();
            //orden de las columnas
            dGVResultBProg.Columns["nomProg"].DisplayIndex = 2;
            dGVResultBProg.Columns["nomTematica"].DisplayIndex = 3;
            dGVResultBProg.Columns["nomCadena"].DisplayIndex = 4;
            dGVResultBProg.Columns["nomCalif"].DisplayIndex = 5;
            dGVResultBProg.Columns["ActivadoPrograma"].DisplayIndex = 6;
            dGVResultBProg.Columns["Novedad"].DisplayIndex = 7;

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Inicializar data grid view (añade botones modificar y eliminar al datagrid). </summary>
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
            colBotonesMod.HeaderText = "Modificar";

            DataGridViewButtonColumn colBotonesElim = new DataGridViewButtonColumn();
            colBotonesElim.UseColumnTextForButtonValue = true;
            colBotonesElim.Text = "Elim";
            colBotonesElim.Width = 40;
            colBotonesElim.Name = "btnEliminar";
            colBotonesElim.HeaderText = "Eliminar";

            dGVResultBProg.Columns.Insert(0, colBotonesElim);
            dGVResultBProg.Columns.Insert(1, colBotonesMod);

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Llamada al evento asociado al botón limpiar. </summary>
        ///
        /// <remarks>   TVO Grupo DPAA2009-2010, 14/04/2010. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void buttonLimpiarProg_Click(object sender, EventArgs e)
        {
            tBNombreProg.Text = "";
            cBITematica.SelectedIndex=0;
            cBICalificacion.SelectedIndex = 0;
            tBDescripcion.Text = "";
            cBICadena.SelectedIndex = 0;
            //Init();
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. LLamada al evento asociado al botón Insertar. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        //------------------------------------------------------Insertando
        private void buttonInsertarProg_Click(object sender, EventArgs e)
        {
            int insertadas = 0;
            int idCad = 0, idTem = 0, idCal = 0, idProg = 0;

            idCad = ObtenerIdCadena(cBICadena);
            idTem = ObtenerIdTematica(cBITematica);
            idCal = ObtenerIdCalif(cBICalificacion);
            ENPrograma programa = new ENPrograma(idCad, idTem, idCal, tBNombreProg.Text, tBDescripcion.Text, cBActProg.Checked, cBNovedad.Checked);
            try
            {
                TbSeccionBaseErrorProvider.Dispose();
                if (buttonInsertarProg.Text == "Insertar")
                {
                    if (ValidaFormulario(tBNombreProg.Text, cBITematica.Text, cBICalificacion.Text, cBICadena.Text, tBDescripcion.Text, cBActProg.Checked, cBNovedad.Checked))
                    {
                        DataView dvProgramaExiste = new DataView();
                        ENPrograma programaExiste = new ENPrograma(tBNombreProg.Text);
                        //Se busca un programa con ese nombre y cualquier tipo
                        dvProgramaExiste = programaExiste.buscarPrograma();

                        if (dvProgramaExiste.Count == 0) //No existe el programa que queremos insertar
                        {
                            insertadas = programa.InsertarPrograma();

                            if (insertadas > 0)
                                MensajeSistema(labelMensajeSist, "Inserción correcta", kMensajeSistema.mCORRECTO);
                            else
                                MensajeSistema(labelMensajeSist, "ERROR: La inserción no se pudo realizar.", kMensajeSistema.mERROR);
                        }
                        else
                            MensajeSistema(labelMensajeSist, "ERROR: El programa ya existe.", kMensajeSistema.mERROR);

                        gBMensajesSist.Visible = true;
                    }
                    else
                        gBMensajesSist.Visible = false;
                }
                else
                {
                    if (buttonInsertarProg.Text == "Modificar")
                    {
                        int id = int.Parse(dGVResultBProg.SelectedRows[0].Cells["idProg"].Value.ToString());
                        programa.Id_Programa = id;
                        int modificadas = programa.modificarPrograma();

                        if (modificadas > 0)
                        {
                            MensajeSistema(labelMensajeSist, "Modificación correcta", kMensajeSistema.mCORRECTO);
                            buttonBuscar_Click((object)buttonBuscar, null);
                        }
                        else
                            MensajeSistema(labelMensajeSist, "ERROR: La modificación no se pudo realizar.", kMensajeSistema.mERROR);
                        gBMensajesSist.Visible = true;
                    }
                }
                
            }
            catch (ENException enex)
            {
                MensajeSistema(labelMensajeSist, enex.Message, kMensajeSistema.mERROR);
                gBMensajesSist.Visible = true;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Método auxiliar utilizado para validar el formulario. Comprueba que sean válidos los campos. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="nombrePrograma">   The nombre programa. </param>
        /// <param name="tematica">         The tematica. </param>
        /// <param name="calificacion">     The calificacion. </param>
        /// <param name="cadena">           The cadena. </param>
        /// <param name="descripcion">      The descripcion. </param>
        /// <param name="activado">         true to activado. </param>
        /// <param name="esNovedad">        true to es novedad. </param>
        ///
        /// <returns>   true si son válidos los campos del formulario, false en caso contrario. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private bool ValidaFormulario(string nombrePrograma, string tematica, string calificacion, string cadena, string descripcion, bool activado, bool esNovedad)
        {
            bool nomOk = false, temaOk = false, califOk = false, cadOK = false, formCorrecto = false;

            nomOk = Validacion.CadenaValida(nombrePrograma);
            temaOk = Validacion.ElementoSeleccionado(tematica);
            califOk = Validacion.ElementoSeleccionado(calificacion);
            cadOK = Validacion.ElementoSeleccionado(cadena);

            if (nomOk && temaOk && califOk && cadOK)
                formCorrecto = true;
            else
            {
                if (!nomOk)
                {
                    TbSeccionBaseErrorProvider.SetIconAlignment(tBNombreProg, ErrorIconAlignment.MiddleRight);
                    TbSeccionBaseErrorProvider.SetIconPadding(tBNombreProg, 4);
                    TbSeccionBaseErrorProvider.SetError(tBNombreProg, "ERROR: El formato del nombre no es correcto.");
                }
                if (!temaOk)
                {
                    TbSeccionBaseErrorProvider.SetIconAlignment(cBITematica, ErrorIconAlignment.MiddleRight);
                    TbSeccionBaseErrorProvider.SetIconPadding(cBITematica, 4);
                    TbSeccionBaseErrorProvider.SetError(cBITematica, "ERROR: Debe seleccionar la temática para el programa.");

                }
                if (!califOk)
                {
                    TbSeccionBaseErrorProvider.SetIconAlignment(cBICalificacion, ErrorIconAlignment.MiddleRight);
                    TbSeccionBaseErrorProvider.SetIconPadding(cBICalificacion, 4);
                    TbSeccionBaseErrorProvider.SetError(cBICalificacion, "ERROR: Debe seleccionar la calificación para el programa.");

                }
                if (!cadOK)
                {
                    TbSeccionBaseErrorProvider.SetIconAlignment(cBICadena, ErrorIconAlignment.MiddleRight);
                    TbSeccionBaseErrorProvider.SetIconPadding(cBICadena, 4);
                    TbSeccionBaseErrorProvider.SetError(cBICadena, "ERROR: Debe seleccionar la cadena para el programa.");

                }

            }

            return formCorrecto;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Llamada al evento asociado al hacer click sobre una celda del dataGridV </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="Exception">    Thrown when exception. </exception>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Data grid view cell event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void dGVResultBProg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ENPrograma programa = new ENPrograma();
            int progNovedad = -1, progActivo = -1;
            try
            {
                if (e.RowIndex == -1)
                    throw new Exception();

                    if (dGVResultBProg.Columns[e.ColumnIndex].Name == "btnModificar")
                    {
                        //Relleno
                        cBICadena.Text = dGVResultBProg.Rows[e.RowIndex].Cells["nomCadena"].Value.ToString();
                        cBITematica.Text = dGVResultBProg.Rows[e.RowIndex].Cells["nomTematica"].Value.ToString();
                        cBICalificacion.Text = dGVResultBProg.Rows[e.RowIndex].Cells["nomCalif"].Value.ToString();
                        tBNombreProg.Text = dGVResultBProg.Rows[e.RowIndex].Cells["nomProg"].Value.ToString();
                        tBDescripcion.Text = dGVResultBProg.Rows[e.RowIndex].Cells["descProg"].Value.ToString();
                        progNovedad = (int)dGVResultBProg.Rows[e.RowIndex].Cells["novProg"].Value;
                        progActivo = (int)dGVResultBProg.Rows[e.RowIndex].Cells["actProg"].Value;
                        cBNovedad.Checked = Convert.ToBoolean(progNovedad);
                        cBActProg.Checked = Convert.ToBoolean(progNovedad);

                        dGVResultBProg.Rows[e.RowIndex].Selected = true;
                        CambiarVistaForm("modificar");
                        pestanyasSeccionBase.SelectTab(pestanyasSeccionBase.GetControl(1).Name);
                    }
                    else
                    {
                        if (dGVResultBProg.Columns[e.ColumnIndex].Name == "btnEliminar")
                        {
                            int id = int.Parse(dGVResultBProg.Rows[e.RowIndex].Cells["idProg"].Value.ToString());
                            string nombreProg = dGVResultBProg.Rows[e.RowIndex].Cells["nomProg"].Value.ToString();
                            string nombreCad = dGVResultBProg.Rows[e.RowIndex].Cells["nomCadena"].Value.ToString();
                            if (MessageBox.Show("¿Desea eliminar el registro con Nombre " + nombreProg + " ( " + nombreCad + ")?", "TEVEO :: Aplicación de gestión", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                            {
                                bool eliminado = false;

                                    ENPrograma programaElim = new ENPrograma();
                                    programaElim.Id_Programa = id;
                                    eliminado = programaElim.eliminarPrograma(id);

                                    if (eliminado)
                                    {
                                        CambiarVistaForm("insertar");
                                        MensajeSistema(labelMensSistPB, "Registro eliminado correctamente.", kMensajeSistema.mCORRECTO);
                                        gbMensajes.Visible = true;
                                        buttonBuscar_Click((object)buttonBuscar, null);
                                    }
                            }
                        }
                        else
                        {
                            if (dGVResultBProg.Columns[e.ColumnIndex].Name == "descProg")
                            {
                                programa.Descripcion = dGVResultBProg.Rows[e.RowIndex].Cells["descProg"].Value.ToString();
                                MessageBox.Show(programa.Descripcion, "TEVEO :: Aplicación de gestión", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                            }
                        }
                    }
            }//cierra try
            catch (ENException enex)
            {
                MensajeSistema(labelMensSistPB, enex.Message, kMensajeSistema.mERROR);
                gbMensajes.Visible = true;
            }
            catch (Exception)
            {
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Método utilizado para cambiar la vista del formulario. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="opcion">   The opcion. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void CambiarVistaForm(string opcion)
        {
            if (opcion == "modificar")
            {
                pestanyasSeccionBase.GetControl(1).Text = "Modificar";
                gBInsertModProg.Text = "Modificar datos de una cadena.";
                buttonInsertarProg.Text = "Modificar";
                gBMensajesSist.Visible = false;
                TbSeccionBaseErrorProvider.Dispose();
                this.etAccion.Text = "MODIFICAR";
                tBBNombreProg.Focus();
            }
            if(opcion == "insertar")
            {
                pestanyasSeccionBase.GetControl(1).Text = "Insertar";
                gBInsertModProg.Text = "Insertar una nueva cadena.";
                buttonInsertarProg.Text = "Insertar";
                this.etAccion.Text = "INSERTAR";
                gBMensajesSist.Visible = false;
                buttonLimpiarProg_Click((object)buttonLimpiarProg, null);
                //Init();
                tBBNombreProg.Focus();
            }
            if (opcion == "consultar")
            {
                pestanyasSeccionBase.GetControl(1).Text = "Insertar";
                gBInsertModProg.Text = "Insertar una nueva cadena.";
                buttonInsertarProg.Text = "Insertar";
                this.etAccion.Text = "CONSULTAR";
                gBMensajesSist.Visible = false;
                //Init();
                tBBNombreProg.Focus();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Método utilizado para rellenar los  comboBoxes, cadenas, temáticas y calificaciones. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        //Rellenar Combobox
        public void RellenarComboBox()
        {
            try
            {
                ENCadena cadenas = new ENCadena();
                bool buscar = true, insertar = false;

                //Se rellena el combobox de cadenas
                if (buscar)
                {
                    cBBCadena.DataSource = cadenas.ObtenerListaCadenas(buscar);
                    cBBCadena.DisplayMember = "nombre";

                    cBBTematica.DataSource = cadenas.ObtenerListaTematicas(buscar);
                    cBBTematica.DisplayMember = "nombre";

                    cBBCalificacion.DataSource = cadenas.ObtenerListaCalificacion(buscar);
                    cBBCalificacion.DisplayMember = "nombre";
                }
                if (!insertar)
                {
                    cBICadena.DataSource = cadenas.ObtenerListaCadenas(insertar);
                    cBICadena.DisplayMember = "nombre";

                    cBITematica.DataSource = cadenas.ObtenerListaTematicas(insertar);
                    cBITematica.DisplayMember = "nombre";

                    cBICalificacion.DataSource = cadenas.ObtenerListaCalificacion(insertar);
                    cBICalificacion.DisplayMember = "nombre";

                }
            }
            catch (ENException enex)
            {
                MensajeSistema(labelMensSistPB, enex.Message, kMensajeSistema.mERROR);
                gbMensajes.Visible = true;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Método Load. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FVistaSeccionProgramas_Load(object sender, EventArgs e)
        {
            RellenarComboBox();
            InicializarDataGridView();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Método que obtiene la id del programa del combo (id/nombre) </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="combobox"> The combobox. </param>
        ///
        /// <returns>   int </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private int ObtenerIdCadena(ComboBox combobox)
        {
            int idC = -1;

            if (combobox.SelectedIndex >= 0) //si está seleccionada 1 cadena
            {
                DataRowView filaCadena = (DataRowView)combobox.SelectedItem;

                idC = int.Parse(filaCadena["id"].ToString());
            }

            return idC;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Llamada al evento asociado al hacer click sobre las pestanyasSeccionBase. </summary>
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
                CambiarVistaForm("consultar");
            }
            else if (pestanyasSeccionBase.SelectedTab.Text == "Insertar")
            {
                CambiarVistaForm("insertar");
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Método que obtiene la id del temática del combo (id/nombre) </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="combobox"> The combobox. </param>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private int ObtenerIdTematica(ComboBox combobox)
        {
            int idT = -1;

            if (combobox.SelectedIndex >= 0) //Si el combobox cadenas ya tiene elementos
            {
                DataRowView filaTematica = (DataRowView)combobox.SelectedItem;

                idT = int.Parse(filaTematica["id"].ToString());
            }

            return idT;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Método que obtiene la id del programa del combo (id/nombre) </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="combobox"> The combobox. </param>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private int ObtenerIdCalif(ComboBox combobox)
        {
            int idCalif = -1;

            if (combobox.SelectedIndex >= 0) //Si el combobox cadenas ya tiene elementos
            {
                DataRowView filaCalif = (DataRowView)combobox.SelectedItem;

                idCalif = int.Parse(filaCalif["id"].ToString());
            }

            return idCalif;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Método auxiliar que devuelve true or false dependiendo de valor(0 ó 1) </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="valor">    The valor. </param>
        ///
        /// <returns>   true if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        bool ObtenerBoolDeInt(int valor)
        {
            bool varbool = false;

            if (valor == 1)
                varbool = true;

            return varbool;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Event handler. Llamada al evento asociado a la imagen de búsqueda. </summary>
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
            base.imgBusquedaRapida_Click(sender, e);
            int idCad = 0, idTem = 0, idCal = 0;

            idCad = ObtenerIdCadena(cBBCadena);
            idTem = ObtenerIdTematica(cBBTematica);
            idCal = ObtenerIdCalif(cBBCalificacion);
            string textoBusqRap = tbBusquedaRapida.Text;

            ENPrograma prog = new ENPrograma();

            DataView dvResultBusq = new DataView();

            try
            {
                //Limpio filas seleccionadas antes de seguir...
                dGVResultBProg.ClearSelection();
                if (Paginar)
                {
                    // Obtenemos el tamaño de la consulta

                    TOTAL_registros = prog.obtenerTamanyoConsulta(tbBusquedaRapida.Text);

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
                        dvResultBusq = prog.buscarPrograma(textoBusqRap, ACTUAL_registro, PAGINA_registros);
                    }
                }
                else
                {
                    dvResultBusq = prog.buscarPrograma(textoBusqRap);
                    TOTAL_registros = dvResultBusq.Table.Rows.Count;
                    if (TOTAL_registros <= MIN_PAGINA_registros)
                        chkPaginacion.Enabled = false;
                    else
                        chkPaginacion.Enabled = true;
                }
                //Si obtengo resultados, le asigno la tabla al datagrid
                if (dvResultBusq.Count > 0)
                {
                        dGVResultBProg.DataSource = dvResultBusq;
                        darFormatoDataGrid();
                        dGVResultBProg.Visible = true;
                }
                else// si no obtiene resultados en la búsq oculto dgv
                     dGVResultBProg.Visible = false;

                if (dvResultBusq.Count == 1)
                        MensajeSistema(labelMensSistPB, "Se ha obtenido 1 resultado.", kMensajeSistema.mCORRECTO);
                else
                        MensajeSistema(labelMensSistPB, "Se han obtenido " + dvResultBusq.Count + " resultados.", kMensajeSistema.mCORRECTO);

                gbMensajes.Visible = true;
            }
            catch (ENException enex)
            {
                if (enex.Tipo != -1)
                    MensajeSistema(labelMensSistPB, enex.Message, kMensajeSistema.mADVERTENCIA);

                else
                    MensajeSistema(labelMensSistPB, enex.Message, kMensajeSistema.mERROR);

                gbMensajes.Visible = true;
                MessageBox.Show(enex.Message);
            }
            catch (Exception ex)
            {
                chkPaginacion.Checked = false;
                chkPaginacion_CheckedChanged((CheckBox)chkPaginacion, null);
                MensajeSistema(labelMensSistPB, "Se ha desactivado la paginación debido a que sólo hay 1 página", kMensajeSistema.mADVERTENCIA);
                chkPaginacion.Enabled = false;
            }

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>    Event handler. Llamada al evento asociado al botón de paginación, utilizado para ir a la última página. </summary>
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
            MetodoBusqueda((object)buttonBuscar, null);
            MensajePaginacion(etInfoPAG, getNumPaginaActual(ACTUAL_registro), getNumPaginasTotales());
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>    Event handler. Llamada al evento asociado al botón de paginación, utilizado para ir a la página siguiente. </summary>
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
                MetodoBusqueda((object)buttonBuscar, null);
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
        /// <summary>    Event handler. Llamada al evento asociado al botón de paginación, utilizado para ir a la página anterior. </summary>
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
                MetodoBusqueda((object)buttonBuscar, null);
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
            MetodoBusqueda((object)buttonBuscar, null);
            MensajePaginacion(etInfoPAG, 1, getNumPaginasTotales());
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
                MetodoBusqueda((object)buttonBuscar, null);
            }
            else
            {
                gbPaginacion.Visible = false;
                Paginar = false;
                // btnBuscar_Click((Button)btnBuscar, null);
                MetodoBusqueda((object)buttonBuscar, null);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Llamada al evento asociado al cellMouseMove. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Data grid view cell mouse event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void dGVResultBProg_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex != -1)
            {
                if (dGVResultBProg.Columns[e.ColumnIndex].Name == "descProg")
                {
                    this.Cursor = Cursors.Hand;
                }
                else
                    this.Cursor = Cursors.Default;
            }
        }

    }
}
