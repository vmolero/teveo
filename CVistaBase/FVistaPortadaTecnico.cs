////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	CVistaBase\FVistaPortadaTecnico.cs
//
// summary:	Implements the vista portada tecnico class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

////////////////////////////////////////////////////////////////////////////////////////////////////
// namespace: TVO_VistaWindows
//
// summary:	.
////////////////////////////////////////////////////////////////////////////////////////////////////

namespace TVO_VistaWindows
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Vista portada tecnico. </summary>
    ///
    /// <remarks>   Vmolero, 13/04/2010. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public sealed partial class FVistaPortadaTecnico : TVO_VistaWindows.FVistaPortadaBase
    {
        /// <summary> The instancia </summary>
        private static readonly FVistaPortadaTecnico instancia = new FVistaPortadaTecnico();

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Vmolero, 13/04/2010. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private FVistaPortadaTecnico()
            : base() 
        {
            InitializeComponent();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the instancia. </summary>
        ///
        /// <value> The instancia. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static FVistaPortadaTecnico Instancia
        {
          get 
          {
              return instancia; 
          }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by FVistaPortadaTecnico for load events. </summary>
        ///
        /// <remarks>   Vmolero, 13/04/2010. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void FVistaPortadaTecnico_Load(object sender, EventArgs e)
        {
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by btnClientes for click events. </summary>
        ///
        /// <remarks>   Vmolero, 13/04/2010. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnClientes_Click(object sender, EventArgs e)
        {
            base.disparaPulsadoBotonMenu(fVistas.fSeccionClientes);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by btnIncidencias for click events. </summary>
        ///
        /// <remarks>   Vmolero, 13/04/2010. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnIncidencias_Click(object sender, EventArgs e)
        {
            base.disparaPulsadoBotonMenu(fVistas.fSeccionIncidencias);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by btnAdmin for click events. </summary>
        ///
        /// <remarks>   Vmolero, 13/04/2010. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            base.disparaPulsadoBotonMenu(fVistas.fSeccionAdministradores);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by btnProgramas for click events. </summary>
        ///
        /// <remarks>   Vmolero, 13/04/2010. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnProgramas_Click(object sender, EventArgs e)
        {
            base.disparaPulsadoBotonMenu(fVistas.fSeccionProgramas);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by btnEmisiones for click events. </summary>
        ///
        /// <remarks>   Vmolero, 13/04/2010. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnEmisiones_Click(object sender, EventArgs e)
        {
            base.disparaPulsadoBotonMenu(fVistas.fSeccionEmisiones);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by btnCadenas for click events. </summary>
        ///
        /// <remarks>   Vmolero, 13/04/2010. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnCadenas_Click(object sender, EventArgs e)
        {
            base.disparaPulsadoBotonMenu(fVistas.fSeccionCanales);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by linkFinSesion for link clicked events. </summary>
        ///
        /// <remarks>   Vmolero, 13/04/2010. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Link label link clicked event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void linkFinSesion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            disparaCerrarSesion();
        }

        private void btnXML_Click(object sender, EventArgs e)
        {
            base.disparaPulsadoBotonMenu(fVistas.fSeccionXML);
        }
    }
       
}
