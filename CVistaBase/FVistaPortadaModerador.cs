////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	CVistaBase\FVistaPortadaModerador.cs
//
// summary:	Implements the vista portada moderador class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TVO_EventosWindows;

////////////////////////////////////////////////////////////////////////////////////////////////////
// namespace: TVO_VistaWindows
//
// summary:	.
////////////////////////////////////////////////////////////////////////////////////////////////////

namespace TVO_VistaWindows
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Vista portada moderador. </summary>
    ///
    /// <remarks>   Vmolero, 13/04/2010. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class FVistaPortadaModerador : TVO_VistaWindows.FVistaPortadaBase
    {
        

        /// <summary> The instancia </summary>
        private static readonly FVistaPortadaModerador instancia = new FVistaPortadaModerador();

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Vmolero, 13/04/2010. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private FVistaPortadaModerador()
            : base() 
        {
            InitializeComponent();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the instancia. </summary>
        ///
        /// <value> The instancia. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static FVistaPortadaModerador Instancia
        {
          get 
          {
              return instancia; 
          }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by btnComentarios for click events. </summary>
        ///
        /// <remarks>   Vmolero, 13/04/2010. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnComentarios_Click(object sender, EventArgs e)
        {
            // EventArgsBase args = new EventArgsBase(fVistas.fSeccionComentariosModerador);
            // PulsadoBotonMenu((FVistaSeccionBase)this, args);
            disparaPulsadoBotonMenu(fVistas.fSeccionComentariosModerador);
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
            
            disparaPulsadoBotonMenu(fVistas.fSeccionCriticasModerador);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by FVistaPortadaModerador for load events. </summary>
        ///
        /// <remarks>   Vmolero, 13/04/2010. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FVistaPortadaModerador_Load(object sender, EventArgs e)
        {
            
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
        
    }

     
}
