////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	CVistaBase\FVistaSeccionClientes.cs
//
// summary:	Implementa la clase publica Vista Seccion Clientes
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TVO_EntidadesDeNegocio;
using System.Text.RegularExpressions;
using TVO_Utiles;

////////////////////////////////////////////////////////////////////////////////////////////////////
// namespace: TVO_VistaWindows
//
// summary:	Espacio de nombres TVO_VistaWindows.
////////////////////////////////////////////////////////////////////////////////////////////////////

namespace TVO_VistaWindows
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Vista seccion clientes. </summary>
    ///
    /// <remarks>   TVO DPAA 2009-2010. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class FVistaSeccionClientes : TVO_VistaWindows.FVistaSeccionBase
    {
        /// <summary> Atributo privado estático y de sólo lectura instancia.  </summary>
        /// <value>Representa la instancia de la ventana abierta, que se única por ejecución.</value>
        private static readonly FVistaSeccionClientes instancia = new FVistaSeccionClientes();
        
        delegate void Busqueda(object sender, EventArgs e);
        Busqueda MetodoBusqueda;

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor por Defecto. Llama a Vista Seccion Base. Se inicializan los componetes visuales</summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
 
        private FVistaSeccionClientes()
            : base()
        {
            InitializeComponent();
            this.etSeccion.Text = "Gestión de Clientes";
            this.etAccion.Text = "CONSULTAR";
            pestanyasSeccionBase.GetControl(1).Text = "Insertar";
            sNif.Focus(); lbNif.Focus();
            vistaTecnico();

        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Devuelve la instancia de la clase. </summary>
        ///
        /// <value> instancia. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static FVistaSeccionClientes Instancia
        {
            get
            {
                return instancia;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initialises this object. </summary>
        ///
        /// <remarks>  TVO DPAA 2009-2010. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public override void Init()
        {
            base.Init();
            bBuscar_Click((object)bBuscar, null);
            MetodoBusqueda = bBuscar_Click;
            TbSeccionBaseErrorProvider.Dispose();
            gbMensajeDelSistema.Visible = false;
            gbMensajeSistema.Visible = false;
            mtbRegistrosXPagina.Text = PAGINA_registros.ToString();
            ACTUAL_registro = 1;
            TOTAL_registros = DGVClientes.RowCount;
            MensajePaginacion(etInfoPAG, 1, getNumPaginasTotales());
            btnPaginaAnterior.Visible = false;
            btnPaginaPrimera.Visible = false;
            bBuscar_Click((object)bBuscar, null);
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary> Activa la visibilidad de las Opciones Avanzadads en la Busqueda Clientes.  </summary>
        ///
        /// <remarks>  TVO DPAA 2009-2010 . </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void cbOpcionesAvanzadas_CheckedChanged(object sender, EventArgs e)
        {
            if (cbOpcionesAvanzadas.Checked == true)
            {
                gbOpcionesAvanzadas.Visible = true;
            }
            else
            {
                gbOpcionesAvanzadas.Visible = false;
            }

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Limpia los Campos en la Pestaña Insertar y Modificar. </summary>
        ///
        /// <remarks>   . </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void bLimpiar_Click(object sender, EventArgs e)
        {
            sNif.Focus();
            if (sNif.ReadOnly == false)
            {
                sNif.Text = "";
                sClave.Text = "";
            }
            else
                sNombre.Focus();
            sNombre.Text = "";
            sApellidos.Text = "";
            sEmail.Text = "";
            sFecha.Value = System.DateTime.Today;
            sTelefono.Text = "";
            sDireccion.Text = "";
            sProvincia.Text = "";
            sCCC.Text = "";
            sCp.Text = "";
            sPoblacion.Text="";
            
            
            TbSeccionBaseErrorProvider.Dispose();
            gbMensajeDelSistema.Visible = false;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Limpia Cuando la insercion Clientes a sido Correcta. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void limpiar()
        {
            
            if (sNif.ReadOnly == true)
            {
                sNif.ReadOnly = false;
                sClave.ReadOnly = false; 
            }
            sNif.Text = "";
            sClave.Text = "";
     
            sNombre.Text = "";
            sApellidos.Text = "";
            sEmail.Text = "";
            sFecha.Value = System.DateTime.Today;
            sTelefono.Text = "";
            sDireccion.Text = "";
            sProvincia.Text = "";
            sCCC.Text = "";
            sPoblacion.Text = "";
            sCp.Text = "";
            
            pestanyasSeccionBase.GetControl(1).Text = "Insertar";
            TbSeccionBaseErrorProvider.Dispose();
            bInsertar.Text = "Insertar";
            gbInsertarCliente.Text = "Nuevo cliente";
            this.etAccion.Text = "INSERTAR";
            //QUITAMOS EL MENSAJE DE ERROR SI LO HUBIESE
            gbMensajeDelSistema.Visible = true;
            //QUITAR EL ERRORPROVIDER
            TbSeccionBaseErrorProvider.Dispose();
            //POSICIONAMOS EL FOCO
          
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Crea Nuevo Cliente. Analiza los Datos de Cliente si son correctos, crea y añade al cliente en la Base Datos sino da un aviso de Error. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void bInsertar_Click(object sender, EventArgs e)
        {
            ///Validacion de los Atributos de Cliente
            bool correcto = true;
            lMensajeError.Text = "";
            //Quitamos el parpadeo.
            //TbSeccionBaseErrorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            //string ER = @"^((67\d{2})(4\d{3})(5[1-5]\d{2})(6011))(-?\s?\d{4}){3}(3[4,7])\ d{2}-?\s?\d{6}-?\s?\d{5}$";
            string ER = @"^\d{20}$";
            //CCC
            try
            {

            if (!(Regex.Match(sCCC.Text, ER).Success))
            {
                sCCC.Focus();
                TbSeccionBaseErrorProvider.SetError(sCCC, "Inserta tu CCC");
                correcto = false;
                lMensajeError.Text += "   CCC:  Insertar un codigo cuenta cliente correcto (20 dígitos mín)"; 

            }
            else
            {
                TbSeccionBaseErrorProvider.SetError(sCCC, "");
            }

            //Cp
            ER = @"^([1-9]{2}|[0-9][1-9]|[1-9][0-9])[0-9]{3}$";

            if (!Regex.Match(sCp.Text, ER).Success)
            {
                sCp.Focus();
                TbSeccionBaseErrorProvider.SetError(sCp, "Código Postal incorrecto o vacio");
                correcto = false;
                lMensajeError.Text = "   Código Postal:  Incorrecto o vacio (5 dígitos mín)\n" + lMensajeError.Text;
            }
            else
            {
                TbSeccionBaseErrorProvider.SetError(sCp, "");
            }
            //Provincia
            if (sProvincia.SelectedIndex <= 0 || sProvincia.SelectedIndex > 52)
            {
                sProvincia.Focus();
                TbSeccionBaseErrorProvider.SetError(sProvincia, "Introduce una provincia");
                correcto = false;
                lMensajeError.Text = "   Provincia:  Sin asignar la provincia\n" + lMensajeError.Text;
            }
            else
            {
                TbSeccionBaseErrorProvider.SetError(sProvincia, "");
            }
            //Poblacion
            if (sPoblacion.Text == "")
            {
                sPoblacion.Focus();
                TbSeccionBaseErrorProvider.SetError(sPoblacion, "Introduce una problacion");
                correcto = false;
                lMensajeError.Text = "   Población:  No insertada o vacia\n" + lMensajeError.Text;
            }
            else
            {
                TbSeccionBaseErrorProvider.SetError(sPoblacion, "");
            }

            //Direccion
            if (sDireccion.Text == "")
            {
                sDireccion.Focus();
                TbSeccionBaseErrorProvider.SetError(sDireccion, "Inserta una dirección");
                correcto = false;
                lMensajeError.Text = "   Dirección:  No insertada o vacio\n" + lMensajeError.Text;
            }
            else
            {
                TbSeccionBaseErrorProvider.SetError(sDireccion, "");
            }

            //Fecha Nacimiento

            if ((System.DateTime.Today.Year - sFecha.Value.Year) < 18)
            {
                TbSeccionBaseErrorProvider.SetError(sFecha, "Fecha Incorrecta o no permitida");
                sFecha.Focus();
                correcto = false;
                lMensajeError.Text = "   Fecha de nacimiento:  Eres menor de edad  (incorrecta)\n" + lMensajeError.Text;
            }
            else
            { //MAYOR O IGUAL A 18
                if ((System.DateTime.Today.Year - sFecha.Value.Year) == 18)
                {
                    if (System.DateTime.Today.Month == sFecha.Value.Month)
                    {
                        if (System.DateTime.Today.Day >= sFecha.Value.Day)
                        {
                            TbSeccionBaseErrorProvider.SetError(sFecha, "");
                        }
                        else
                        {
                            TbSeccionBaseErrorProvider.SetError(sFecha, "Fecha Incorrecta o no permitida");
                            sFecha.Focus();
                            correcto = false;
                            lMensajeError.Text = "   Fecha de nacimiento:  Eres menor de edad  (incorrecta)\n" + lMensajeError.Text;
                        }

                    }
                    else
                    {
                        if (System.DateTime.Today.Month < sFecha.Value.Month)
                        {
                            TbSeccionBaseErrorProvider.SetError(sFecha, "Fecha Incorrecta o no permitida");
                            sFecha.Focus();
                            correcto = false;
                            lMensajeError.Text = "   Fecha de nacimiento:  Eres menor de edad  (incorrecta)\n" + lMensajeError.Text;
                        }
                        else
                            TbSeccionBaseErrorProvider.SetError(sFecha, "");
                    }
                }
                else
                {
                    TbSeccionBaseErrorProvider.SetError(sFecha, "");
                }
            }

            //Telefono
            ER = @"^[0-9]{2,3}-? ?[0-9]{6,7}$";
            if (!Regex.Match(sTelefono.Text, ER).Success)
            {
                sTelefono.Focus();
                TbSeccionBaseErrorProvider.SetError(sTelefono, "Introduce un Telefono");
                correcto = false;
                lMensajeError.Text = "   Telefono:  Incorrecto (9 digitos mín)\n" + lMensajeError.Text;
            }
            else
            {
                TbSeccionBaseErrorProvider.SetError(sTelefono, "");
            }
            //Email
            ER = @"(^[0-9a-zA-Z]+(?:[._][0-9a-zA-Z]+)*)@([0-9a-zA-Z]+(?:[._-][0-9a-zA-Z]+)*\.[0-9a-zA-Z]{2,3})$";
            if (!Regex.Match(sEmail.Text, ER).Success)
            {
                sEmail.Focus();
                TbSeccionBaseErrorProvider.SetError(sEmail, "Inserta tu Correo Electrónico");
                correcto = false;
                lMensajeError.Text = "   Email:  Incorrecto por ej: dpaa@teveo.com \n" + lMensajeError.Text;
            }
            else
                TbSeccionBaseErrorProvider.SetError(sEmail, "");
            //Clave
            ER = @"(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{8,10})$";
            if (!Regex.Match(sClave.Text, ER).Success)
            {
                sClave.Focus();
                TbSeccionBaseErrorProvider.SetError(sClave, "Inserta una clave Correcta (numero + letras + numero)");
                correcto = false;
                lMensajeError.Text = "   Clave:  Tiene que ser letras y números (8 carateres mín)\n" + lMensajeError.Text;
            }
            else
                TbSeccionBaseErrorProvider.SetError(sClave, "");

            //Sexo  -- Se Selecciona uno por defecto.Por eso siempre esta activo uno.
            string varsexo="";
            if (sSexoH.Checked )
                varsexo = "Hombre";
            else
                varsexo = "Mujer";
           
            //Apellidos
            if (sApellidos.Text == "")
            {
                sApellidos.Focus();
                TbSeccionBaseErrorProvider.SetError(sApellidos, "Apellido vacio");
                correcto = false;
                lMensajeError.Text = "   Apellidos:  No insertados o vacio\n" + lMensajeError.Text;
            }
            else
            {
                TbSeccionBaseErrorProvider.SetError(sApellidos, "");
            }
            //Nombre
            if (sNombre.Text == "")
            {
                sNombre.Focus();
                TbSeccionBaseErrorProvider.SetError(sNombre, "Nombre vacio");
                correcto = false;
                lMensajeError.Text = "   Nombre:  No insertado o vacio\n" + lMensajeError.Text;
            }
            else
            {
                TbSeccionBaseErrorProvider.SetError(sNombre, "");
            }
            //Dni
            ER = @"^\d{1,8}[A-Za-z]$";
            if (!Validacion.NifValido(sNif.Text))
            {
                sNif.Focus();
                TbSeccionBaseErrorProvider.SetError(sNif, "Dni incorrecto o vacio");
                correcto = false;
                lMensajeError.Text = "   Dni:  Incorrecto o vacio.   Por ej: 48560292R \n" + lMensajeError.Text;
            }
            else
            {
                TbSeccionBaseErrorProvider.SetError(sNif, "");
            }

            //Campos correctos
            lMensajeError.Visible = true;
            if (correcto == true)
            {
                //Insertar Clientestring dni, string clave, string nombre, string apellidos, string sexo,DateTime fecha, string telefono, string email , int provincia,string poblacion, string direccion , string ccc, string cp)
                ENCliente cliente = new ENCliente(sNif.Text, sClave.Text, sNombre.Text, sApellidos.Text, varsexo, sFecha.Value, sEmail.Text, sTelefono.Text, sDireccion.Text, sPoblacion.Text, sCCC.Text, sProvincia.SelectedIndex, sCp.Text);
                int inser_mod;
                if (sNif.ReadOnly == false)
                    inser_mod = cliente.InsertarClienteBD();
                else
                    inser_mod = cliente.ModificarClienteBD();
                
                if (inser_mod == 1)
                {
                    //Mensaje de Aviso
                    if (sNif.ReadOnly == false) //Mirar si estoy modificando
                        MensajeSistema(lMensajeError, "Cliente insertado", kMensajeSistema.mCORRECTO);
                    else
                        MensajeSistema(lMensajeError, "Cliente Modifado", kMensajeSistema.mCORRECTO);
                    //Limpiar la pantalla

                    this.limpiar();
                    gbMensajeDelSistema.Visible = true;
                }
                else
                {
                    //Mensaje de Aviso
                    if (sNif.ReadOnly == false)
                        MensajeSistema(lMensajeError, "Cliente no insertado", kMensajeSistema.mERROR);
                    else
                        MensajeSistema(lMensajeError, "Cliente no modificado", kMensajeSistema.mERROR);
                }
            }
            else
            {
                //Mensaje de Aviso "Campos incorrectos"
                gbMensajeDelSistema.Visible = true;
                lMensajeError.Text = "Campos incorrectos: \n\n" + lMensajeError.Text;
                MensajeSistema(lMensajeError, lMensajeError.Text, kMensajeSistema.mADVERTENCIA);
            }
        }
            catch (ENException enex)
            {
                MensajeSistema(lMensajeError, enex.Mensaje, kMensajeSistema.mERROR);
                gbMensajeDelSistema.Visible = true;
            }
            catch (Exception ex)
            {
                MensajeSistema(lMensajeError, ex.Message, kMensajeSistema.mADVERTENCIA);
                gbMensajeDelSistema.Visible = true;
            }

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Limpia los campos en la Busqueda Cliente. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void bLimpiarBusqueda_Click(object sender, EventArgs e)
        {
            eNif.Text = "";
            eNombre.Text = "";
            eApellidos.Text = "";
            eEmail1.Text = "";
            //eFecha = System.DateTime.Today;
            eTelefono.Text = "";
            eEmail1.Text = "";
            eProvincia.Text = "";
            etodos.Checked = true;
            //QUITAMOS EL MENSAJE DE ERROR SI LO HUBIESE
            gbMensajeSistema.Visible = false;
            //QUITAMOS LOS ERRORPROVIDER
            TbSeccionBaseErrorProvider.Dispose();
            cbOpcionesAvanzadas.Checked = false;
            chbPaginacion.Checked = false;
            chbPaginacion.Enabled = true;
            //POSICIONAMOS EL FOCO
            lbNif.Focus();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Inicilizar dgv cliente. Insertamos las columnas con los botones eliminar y modificar </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void inicilizarDGVCliente()
        {
            DataGridViewButtonColumn BotonModificarDGVCliente = new DataGridViewButtonColumn();
            BotonModificarDGVCliente.Text = "Mod";
            BotonModificarDGVCliente.Width = 60;
            BotonModificarDGVCliente.Name = "btModificar";
            BotonModificarDGVCliente.HeaderText = "Modificar";
            BotonModificarDGVCliente.UseColumnTextForButtonValue = true;

            DataGridViewButtonColumn BotonEliminarDGVCliente = new DataGridViewButtonColumn();
            BotonEliminarDGVCliente.Text = "Eli";
            BotonEliminarDGVCliente.Width = 60;
            BotonEliminarDGVCliente.Name = "btEliminar";
            BotonEliminarDGVCliente.HeaderText = "Eliminar";
            BotonEliminarDGVCliente.UseColumnTextForButtonValue = true;

            DGVClientes.Columns.Insert(0, BotonModificarDGVCliente);
            DGVClientes.Columns.Insert(1, BotonEliminarDGVCliente);
           
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by mtbRegistrosXPagina for leave events. </summary>
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
                // LLamar a activar paginacion
                chbPaginacion_CheckedChanged((CheckBox)chbPaginacion, null);
            }
            else if (Convert.ToInt32(mtbRegistrosXPagina.Text) >= TOTAL_registros)
            {
                mtbRegistrosXPagina.Text = MIN_PAGINA_registros.ToString();
                PAGINA_registros = MIN_PAGINA_registros;
                chbPaginacion.Checked = false;
                chbPaginacion_CheckedChanged((CheckBox)chbPaginacion, null);
                MensajeSistema(lErrorBusqueda, "Se ha desactivado la paginación debido a que sólo hay 1 página", kMensajeSistema.mADVERTENCIA);
                chbPaginacion.Enabled = false;

            }
            else
            {
                PAGINA_registros = Convert.ToInt32(mtbRegistrosXPagina.Text);
                chbPaginacion_CheckedChanged((CheckBox)chbPaginacion, null);
            }
            etPaginacionInfo.Visible = false;

        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by mtbNIFBuscar for key down events. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Key event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private void mtbNIFBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bBuscar_Click((Button)bBuscar, null);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by tbNombreBuscar for key down events. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Key event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private void tbNombreBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bBuscar_Click((Button)bBuscar, null);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by tbEmailBuscar for key down events. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Key event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        private void tbEmailBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bBuscar_Click((Button)bBuscar, null);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by mtbRegistrosXPagina for enter events. </summary>
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
        /// <summary>   Event handler. Called by mtbRegistrosXPagina for key down events. </summary>
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
        /// <summary>   Formato dgv cliente. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void FormatoDGVCliente()
        {
            DGVClientes.RowHeadersVisible = false;

            DGVClientes.Columns["nif"].Width = 65;
            DGVClientes.Columns["nombre"].Width = 200;
            DGVClientes.Columns["direccion"].Width = 350;
            DGVClientes.Columns["email"].Width = 160;
            DGVClientes.Columns["telefono"].Width = 70;
            DGVClientes.Columns["ccc"].Width = 160;
            DGVClientes.Columns["sexo"].Width = 50;
            DGVClientes.Columns["fecha"].Width = 160;
            //DGVClientes.Columns["provincia"].Width = 50;

            DGVClientes.Columns["nif"].HeaderText = "NIF";
            DGVClientes.Columns["nombre"].HeaderText = "Apellidos, Nombre";
            DGVClientes.Columns["direccion"].HeaderText = "Dirección";
            DGVClientes.Columns["email"].HeaderText = "E. Mail";
            DGVClientes.Columns["email"].DefaultCellStyle.ForeColor = Color.Blue;
            DGVClientes.Columns["telefono"].HeaderText = "Teléfono";
            DGVClientes.Columns["sexo"].HeaderText = "Sexo";
            DGVClientes.Columns["fecha"].HeaderText = "Fecha Nacimiento";
            //DGVClientes.Columns["provincia"].HeaderText = "Provincia";
            DGVClientes.Columns["ccc"].HeaderText = "Cuenta bancaria";

            DGVClientes.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
            DGVClientes.TabStop = false;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by btnPaginaSiguiente for click events. </summary>
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
                MetodoBusqueda((object)bBuscar, null);
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
        /// <summary>   Event handler. Called by btnPaginaAnterior for click events. </summary>
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
                MetodoBusqueda((object)bBuscar, null);
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
            MetodoBusqueda((object)bBuscar, null);
            MensajePaginacion(etInfoPAG, getNumPaginaActual(ACTUAL_registro), getNumPaginasTotales());
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by btnPaginaPrimera for click events. </summary>
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
            MetodoBusqueda((object)bBuscar, null);
            MensajePaginacion(etInfoPAG, 1, getNumPaginasTotales());

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Realiza la Busqueda Cliente. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void bBuscar_Click(object sender, EventArgs e)
        {
            MetodoBusqueda = bBuscar_Click;
            ENCliente clienteBusqueda = new ENCliente();
            DataView BDResultado = new DataView();
            string sexo = "";
            try
            {
                if (Paginar) {
                    // Obtenemos el tamaño de la consulta
                   
                    if (cbOpcionesAvanzadas.Checked)
                    {
                        
                        if (eSexoH.Checked)
                            sexo = "Hombre";
                        if(eSexoM.Checked)
                            sexo = "Mujer";
                        if (etodos.Checked)
                            sexo = "Todos";
                        TOTAL_registros = clienteBusqueda.obtenerTamanyoConsulta(eNif.Text, eNombre.Text, eApellidos.Text, sexo, eTelefono.Text, eEmail1.Text, eProvincia.SelectedIndex);

                    }
                    else
                    {
                        TOTAL_registros = clienteBusqueda.obtenerTamanyoConsulta(eNif.Text, eNombre.Text, eApellidos.Text);
                    }
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
                        if (cbOpcionesAvanzadas.Checked)
                        {
                            BDResultado = clienteBusqueda.BuscarClientesBD(eNif.Text, eNombre.Text, eApellidos.Text, sexo, eTelefono.Text, eEmail1.Text, eProvincia.SelectedIndex, ACTUAL_registro, PAGINA_registros);
                            
                        }
                        else 
                        {
                            BDResultado = clienteBusqueda.BuscarClientesBD(eNif.Text, eNombre.Text, eApellidos.Text,ACTUAL_registro, PAGINA_registros);
                        }

                    }
                }
                else
                {
                    if (cbOpcionesAvanzadas.Checked)
                    {

                        if (eSexoH.Checked)
                            sexo = "Hombre";
                        if (eSexoM.Checked)
                            sexo = "Mujer";
                        if (etodos.Checked)
                            sexo = "Todos";
                        BDResultado = clienteBusqueda.BuscarClientesBD(eNif.Text, eNombre.Text, eApellidos.Text, sexo, eTelefono.Text, eEmail1.Text, eProvincia.SelectedIndex);

                    }
                    else
                    {
                        BDResultado = clienteBusqueda.BuscarClientesBD(eNif.Text, eNombre.Text, eApellidos.Text);
                    }
                    TOTAL_registros = BDResultado.Table.Rows.Count;
                    if (TOTAL_registros <= MIN_PAGINA_registros) chbPaginacion.Enabled = false;
                    else chbPaginacion.Enabled = true;
                }
                DGVClientes.DataSource = BDResultado;
                if (BDResultado.Count > 0)
                {
                    //Adaptamos el datagridview
                    
                    MensajeSistema(lErrorBusqueda, "Se han obtenido " + BDResultado.Count + " resultado", kMensajeSistema.mCORRECTO);
                    gbMensajeSistema.Visible = true;
                    FormatoDGVCliente();
                    DGVClientes.Visible = true;

                }

                else 
                {
                    MensajeSistema(lErrorBusqueda, "No se ha obtenido ningun resultado", kMensajeSistema.mADVERTENCIA);
                    DGVClientes.Visible = false;
                    gbMensajeSistema.Visible = true;
                }


                administrador = clienteBusqueda;
            }
            catch (ENException enex)
            {
                if (enex.Tipo != -1)
                {
                    MensajeSistema(lErrorBusqueda, enex.Message, kMensajeSistema.mADVERTENCIA);
                }
                else MensajeSistema(lErrorBusqueda, enex.Message, kMensajeSistema.mERROR);

                gbMensajeSistema.Visible = true;
            }
            catch (Exception ex)
            {
                chbPaginacion.Checked = false;
                chbPaginacion_CheckedChanged((CheckBox)chbPaginacion, null);
                MensajeSistema(lErrorBusqueda, "Se ha desactivado la paginación debido a que sólo hay 1 página", kMensajeSistema.mADVERTENCIA);
                //chbPaginacion.Enabled = false;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by DGVClientes for cell content click events. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Data grid view cell event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void DGVClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Boton Elimininar del DGVClientes
            try
            {
                if (e.RowIndex == -1) throw new Exception();
                
                    if (DGVClientes.Columns[e.ColumnIndex].Name == "btEliminar")
                    {
                        string nifEliminar = DGVClientes.Rows[e.RowIndex].Cells["nif"].Value.ToString();
                        if (MessageBox.Show("¿Desea eliminar el registro con NIF " + nifEliminar + "?", "TEVEO :: Aplicación de gestión", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            ENCliente clienteEliminado = new ENCliente();
                            try
                            {
                                clienteEliminado.Dni = nifEliminar;
                                int borrados = clienteEliminado.BorrarClienteBD();

                                if (borrados == 1)
                                {
                                    //ACTUALIZA EL DATAGRIDVIEW
                                    bBuscar_Click((Button)bBuscar, null);
                                    MensajeSistema(lErrorBusqueda, "Registro eliminado correctamente", kMensajeSistema.mCORRECTO);
                                    lErrorBusqueda.Visible = true;
                                }
                            }
                            catch (ENException enex)
                            {
                                MensajeSistema(lErrorBusqueda, enex.Mensaje, kMensajeSistema.mERROR);
                                lErrorBusqueda.Visible = true;
                            }



                        }
                    }

                    //Boton Modificar del DGVClientes
                    if (DGVClientes.Columns[e.ColumnIndex].Name == "btModificar")
                    {
                        //No Necesito la vista de la Tabla Titular por Defecto
                        //Obtenemos los datos Directamente del Datagridview DGVCliente
                        //Sexo
                        if (DGVClientes.Rows[e.RowIndex].Cells["sexo"].Value.ToString() == "Mujer")
                        {
                            sSexoM.Checked = true;
                            sSexoH.Checked = false;
                        }
                        else
                        {
                            sSexoH.Checked = true;
                            sSexoM.Checked = false;
                        }
                        //ccc
                        sCCC.Text = DGVClientes.Rows[e.RowIndex].Cells["ccc"].Value.ToString();
                        //email
                        sEmail.Text = DGVClientes.Rows[e.RowIndex].Cells["email"].Value.ToString();
                        //telefono
                        sTelefono.Text = DGVClientes.Rows[e.RowIndex].Cells["telefono"].Value.ToString();
                        sFecha.Text = DGVClientes.Rows[e.RowIndex].Cells["fecha"].Value.ToString();

                        sNif.Text = administrador.obtenerDelDataSet("Clientes", e.RowIndex, "nif");
                        sNif.ReadOnly = true;
                        sClave.Text = administrador.obtenerDelDataSet("Clientes", e.RowIndex, "clave");
                        sClave.ReadOnly = true;
                        sNombre.Text = administrador.obtenerDelDataSet("Clientes", e.RowIndex, "nombre");
                        sNombre.Focus();
                        sApellidos.Text = administrador.obtenerDelDataSet("Clientes", e.RowIndex, "apellidos");

                        //Direccion

                        sCp.Text = administrador.obtenerDelDataSet("Clientes", e.RowIndex, "cp");
                        sPoblacion.Text = administrador.obtenerDelDataSet("Clientes", e.RowIndex, "poblacion");
                        sProvincia.SelectedIndex = Convert.ToInt32(administrador.obtenerDelDataSet("Clientes", e.RowIndex, "provincia"));
                        sDireccion.Text = administrador.obtenerDelDataSet("Clientes", e.RowIndex, "direccion");

                        pestanyasSeccionBase.SelectTab(pestanyasSeccionBase.GetControl(1).Name);
                        pestanyasSeccionBase.GetControl(1).Text = "Modificar";
                        TbSeccionBaseErrorProvider.Dispose();
                        bInsertar.Text = "Modificar";
                        gbInsertarCliente.Text = "Modificar Cliente";
                        this.etAccion.Text = "MODIFICAR";


                    }
                    //Celda email
                    if (DGVClientes.Columns[e.ColumnIndex].Name == "email")
                    {
                        WebBrowser web = new WebBrowser();
                        web.Navigate("mailto:" + DGVClientes.Rows[e.RowIndex].Cells["email"].Value.ToString());

                    }
                
            }
            catch(Exception ex) 
            { }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by FVistaSeccionClientes for load events. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FVistaSeccionClientes_Load(object sender, EventArgs e)
        {
            inicilizarDGVCliente();
            RellenarComboProvincias();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by imgBusquedaRapida for click events. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public override void imgBusquedaRapida_Click(object sender, EventArgs e) 
        {
            ENCliente clienteBusqueda = new ENCliente();
            DataView BDResultado = new DataView();
            MetodoBusqueda = imgBusquedaRapida_Click;
            try
            {

                if (Paginar)
                {
                    TOTAL_registros = clienteBusqueda.obtenerTamanyoConsulta(tbBusquedaRapida.Text);
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

                       BDResultado = clienteBusqueda.BusquedaGenerica(tbBusquedaRapida.Text, ACTUAL_registro, PAGINA_registros);

                    }
                }
                else
                {

                    BDResultado = clienteBusqueda.BusquedaGenerica(tbBusquedaRapida.Text);

                    TOTAL_registros = BDResultado.Table.Rows.Count;
                    if (TOTAL_registros <= MIN_PAGINA_registros) chbPaginacion.Enabled = false;
                    else chbPaginacion.Enabled = true;
                }
                DGVClientes.DataSource = BDResultado;
                if (BDResultado.Count > 0)
                {
                    //Adaptamos el datagridview

                    MensajeSistema(lErrorBusqueda, "Se han obtenido " + BDResultado.Count + " resultado", kMensajeSistema.mCORRECTO);
                    gbMensajeSistema.Visible = true;
                    FormatoDGVCliente();
                    DGVClientes.Visible = true;

                }

                else
                {
                    MensajeSistema(lErrorBusqueda, "No se ha obtenido ningun resultado", kMensajeSistema.mADVERTENCIA);
                    DGVClientes.Visible = false;
                    gbMensajeSistema.Visible = true;
                }


                administrador = clienteBusqueda;
                pestanyasSeccionBase.SelectedIndex = 0;
            }
            catch (ENException enex)
            {
                if (enex.Tipo != -1)
                {
                    MensajeSistema(lErrorBusqueda, enex.Message, kMensajeSistema.mADVERTENCIA);
                }
                else MensajeSistema(lErrorBusqueda, enex.Message, kMensajeSistema.mERROR);

                gbMensajeSistema.Visible = true;
            }
            catch (Exception ex)
            {
                chbPaginacion.Checked = false;
                chbPaginacion_CheckedChanged((CheckBox)chbPaginacion, null);
                MensajeSistema(lErrorBusqueda, "Se ha desactivado la paginación debido a que sólo hay 1 página", kMensajeSistema.mADVERTENCIA);
                //chbPaginacion.Enabled = false;
            }

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by pestanyasSeccionBase_Click for 1 events. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void pestanyasSeccionBase_Click_1(object sender, EventArgs e)
        {
            if (pestanyasSeccionBase.SelectedTab.Text == "Consultar")
            {
                pestanyasSeccionBase.GetControl(1).Text = "Insertar";
                limpiar();
                this.etAccion.Text = "CONSULTAR";
                lMensajeError.Visible = false;
                gbMensajeDelSistema.Visible = false;
                //pestanyasSeccionBase.TabIndex = 1;

            }
            if(pestanyasSeccionBase.SelectedTab.Text == "Insertar")
            {
                pestanyasSeccionBase.GetControl(1).Text = "Insertar";
                this.etAccion.Text = "INSERTAR";
                //pestanyasSeccionBase.TabIndex = 0;
            }

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by chbPaginacion for checked changed events. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void chbPaginacion_CheckedChanged(object sender, EventArgs e)
        {
            if (chbPaginacion.Checked)
            {
                gbPaginacion.Visible = true;
                Paginar = true;
                ACTUAL_registro = 1;

                btnPaginaUltima.Visible = true;
                btnPaginaSiguiente.Visible = true;
                btnPaginaPrimera.Visible = false;
                btnPaginaAnterior.Visible = false;

                MensajePaginacion(etInfoPAG, 1, getNumPaginasTotales());
                MetodoBusqueda((object)bBuscar, null);
            }
            else
            {
                gbPaginacion.Visible = false;
                Paginar = false;
                MetodoBusqueda((object)bBuscar, null);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Rellenar combo provincias. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void RellenarComboProvincias()
        {
            DataView dvProvincias = new DataView();
            ENCliente vistaCliente = new ENCliente();
            try
            {
                sProvincia.DataSource = vistaCliente.obtenerProvincias();
                eProvincia.DataSource = vistaCliente.obtenerProvincias();
                sProvincia.DisplayMember = "nombre";
                eProvincia.DisplayMember = "nombre";
            }
            catch (ENException enex)
            {
                MensajeSistema(lErrorBusqueda, enex.Message, kMensajeSistema.mERROR);
                MensajeSistema(lMensajeError, enex.Mensaje, kMensajeSistema.mERROR);
            }

        }

        private void tbBusquedaRapida_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

    



