////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	CVistaBase\FVistaPortadaBase.cs
//
// summary:	Implements the vista portada base class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using TVO_EventosWindows;
using TVO_EntidadesDeNegocio;

////////////////////////////////////////////////////////////////////////////////////////////////////
// namespace: TVO_VistaWindows
//
// summary:	.
////////////////////////////////////////////////////////////////////////////////////////////////////

namespace TVO_VistaWindows
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Vista portada base. </summary>
    ///
    /// <remarks>   Vmolero, 13/04/2010. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class FVistaPortadaBase : TVO_VistaWindows.FVistaBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento menu handler. </summary>
        ///
        /// <remarks>   Vmolero, 13/04/2010. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        The. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public delegate void EventoMenuHandler(object sender, EventArgsBase e);
        /// <summary> Event queue for all listeners interested in PulsadoBotonMenu events. </summary>
        public event EventoMenuHandler PulsadoBotonMenu;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento cerrar sesion handler. </summary>
        ///
        /// <remarks>   Vmolero, 13/04/2010. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        The. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public delegate void EventoCerrarSesionHandler(object sender, EventArgsPortadaBase e);
        /// <summary> Event queue for all listeners interested in CerrarSesion events. </summary>
        public event EventoCerrarSesionHandler CerrarSesion;

        /// <summary> The nif </summary>
        protected string nif;
        /// <summary> The administrador </summary>
        protected ENPersona administrador;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   get y set Admin. </summary>
        ///
        /// <value> The admin. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ENPersona Admin
        {
            get { return administrador; }
            set { administrador = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Vmolero, 13/04/2010. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public FVistaPortadaBase() : base()
        {
            InitializeComponent();
            this.nif = "";
            administrador = new ENPersona();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Vmolero, 13/04/2010. </remarks>
        ///
        /// <param name="nif">  The nif. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public FVistaPortadaBase(string nif)
        {
            InitializeComponent();
            this.nif = nif;
            administrador = new ENPersona(nif);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initialises this object. </summary>
        ///
        /// <remarks>   Vmolero, 13/04/2010. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        override public void Init()
        {
            etNombre.Text = administrador.Nombre + " " + administrador.Apellidos;
            
            if (administrador.ImgData != null) {
               System.IO.Stream ms = new System.IO.MemoryStream(administrador.ImgData);
               System.Drawing.Bitmap miImagen = new Bitmap(ms);
               imgPortadaBaseFoto.Image = (Image)miImagen;
            }
            
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Dispara pulsado boton menu. </summary>
        ///
        /// <remarks>   Vmolero, 13/04/2010. </remarks>
        ///
        /// <param name="v">    The v. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void disparaPulsadoBotonMenu(fVistas v)
        {
            EventArgsBase args = new EventArgsBase((int) v);
            PulsadoBotonMenu(this, args);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Dispara cerrar sesion. </summary>
        ///
        /// <remarks>   Vmolero, 13/04/2010. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void disparaCerrarSesion()
        {
            EventArgsPortadaBase args = new EventArgsPortadaBase(false);
            CerrarSesion(this, args);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by linkCerrarApp for link clicked events. </summary>
        ///
        /// <remarks>   Vmolero, 13/04/2010. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Link label link clicked event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void linkCerrarApp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by FVistaPortadaBase for load events. </summary>
        ///
        /// <remarks>   Vmolero, 13/04/2010. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Link label link clicked event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FVistaPortadaBase_Load(object sender, EventArgs e)
        {

        }
    }
    
   
}
