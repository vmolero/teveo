////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	CVistaBase\FVistaAcceso.cs
//
// summary:	Implements the vista acceso class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TVO_EntidadesDeNegocio;
using TVO_EventosWindows;
using TVO_Utiles;
using System.Collections;

////////////////////////////////////////////////////////////////////////////////////////////////////
// namespace: TVO_VistaWindows
//
// summary:	.
////////////////////////////////////////////////////////////////////////////////////////////////////

namespace TVO_VistaWindows
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Vista acceso. </summary>
    ///
    /// <remarks>   Vmolero, 13/04/2010. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public sealed partial class FVistaAcceso : TVO_VistaWindows.FVistaPortadaBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento acceso handler. </summary>
        ///
        /// <remarks>   Vmolero, 13/04/2010. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="ea">       The ea. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public delegate void EventoAccesoHandler(object sender, EventArgsAcceso ea);
        /// <summary> Event queue for all listeners interested in EventoValidar events. </summary>
        public event EventoAccesoHandler EventoValidar;

        /// <summary> The instancia </summary>
        private static readonly FVistaAcceso instancia = new FVistaAcceso();

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Vmolero, 13/04/2010. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private FVistaAcceso() : base() 
        {
            InitializeComponent();
            
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the instancia. </summary>
        ///
        /// <value> The instancia. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static FVistaAcceso Instancia
        {
          get 
          {
              return instancia; 
          }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initialises this object. </summary>
        ///
        /// <remarks>   Vmolero, 13/04/2010. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        new public void Init()
        {
            eNIF.Clear();
            eClave.Clear();
            eNIF.Focus();
            etMensaje.Text = "";
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by btnValidar for click events. </summary>
        ///
        /// <remarks>   Vmolero, 13/04/2010. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnValidar_Click(object sender, EventArgs e)
        {
            if (TVO_Utiles.Validacion.NifValido(this.eNIF.Text))
            {

                administrador = new ENPersona(this.eNIF.Text, this.eClave.Text);
                EventArgsAcceso args = null;
                try
                {
                    // p = (ENAdministrador) ControladorAcceso.valida(this.eNIF.Text, this.eClave.Text);
                    administrador.obtenerAcceso();

                    //if (administrador.Perfil == kPerfil.pNinguno)
                    //    throw new Exception();

                    Hashtable datos = new Hashtable();
                    datos["nif"] = administrador.Dni;
                    datos["nombre"] = administrador.Nombre;
                    datos["apellidos"] = administrador.Apellidos;
                    datos["perfil"] = (int)administrador.Perfil;
                    if (administrador.ImgData != null) datos["foto"] = (byte[]) administrador.ImgData;
                    args = new EventArgsAcceso(datos);
                    EventoValidar(this, args);
                }
                catch (ENException enex)
                {
                    // MessageBox.Show(enex.Mensaje);
                    etMensaje.Text = "Error de validación: " + enex.Mensaje;
                    eClave.Clear();
                    eClave.Focus();
                }
            }
            else
            {
                etMensaje.Text = "Formato de NIF incorrecto.";
                Init();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by FVistaAcceso for load events. </summary>
        ///
        /// <remarks>   Vmolero, 13/04/2010. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FVistaAcceso_Load(object sender, EventArgs e)
        {
            Init();
            etMensaje.Text = "";
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by FVistaAcceso for shown events. </summary>
        ///
        /// <remarks>   Vmolero, 13/04/2010. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FVistaAcceso_Shown(object sender, EventArgs e)
        {
           // FVistaAcceso_Load(sender, e);
           // MessageBox.Show("Shown");
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by FVistaAcceso for enter events. </summary>
        ///
        /// <remarks>   Vmolero, 13/04/2010. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FVistaAcceso_Enter(object sender, EventArgs e)
        {
           // MessageBox.Show("Enter");
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by eClave for key down events. </summary>
        ///
        /// <remarks>   Vmolero, 13/04/2010. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Key event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void eClave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnValidar_Click((Button)btnValidar, null);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by eNIF for key down events. </summary>
        ///
        /// <remarks>   Vmolero, 13/04/2010. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Key event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void eNIF_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnValidar_Click((Button)btnValidar, null);
            }
        }
        
    }

      
}
