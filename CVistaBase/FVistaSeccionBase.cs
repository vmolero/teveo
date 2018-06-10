////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	CVistaBase\FVistaSeccionBase.cs
//
// summary:	Implementa la clase FVistaSeccionBase
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

////////////////////////////////////////////////////////////////////////////////////////////////////
// namespace: TVO_VistaWindows
//
// summary:	.
////////////////////////////////////////////////////////////////////////////////////////////////////
namespace TVO_VistaWindows
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Enumerado que representa los mensajes del sistema. </summary>
    /// <list type="bullet">
    ///     <listheader>
    ///         <term>kMensaje</term>
    ///         <description>Enum de mensajes</description>
    ///     </listheader>
    ///     <item>
    ///         <term>mERROR</term>
    ///         <description>Valor 0. El texto se mostrará en rojo.</description>
    ///         <term>mADVERTENCIA</term>
    ///         <description>Valor 1. El texto se mostrará en naranja.</description>
    ///         <term>mCORRECTO</term>
    ///         <description>Valor 2. El texto se mostrará en verde.</description>
    ///     </item>
    ///</list>
    /// <remarks>   . </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public enum kMensajeSistema
    {
        mERROR,
        mADVERTENCIA,
        mCORRECTO
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Vista seccion base. </summary>
    ///
    /// <remarks>   . </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class FVistaSeccionBase : TVO_VistaWindows.FVistaBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Evento menu principal handler. </summary>
        ///
        /// <remarks>   . </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        The. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public delegate void EventoMenuPrincipalHandler(object sender, EventArgsBase e);
        /// <summary> .  </summary>
        public event EventoMenuPrincipalHandler PulsadoMenuPrincipal;

        /// <summary> .  </summary>
        public ErrorProvider TbSeccionBaseErrorProvider;

        /// <summary> .  </summary>
        protected ENPersona administrador;
        /// <summary>
        /// get y set Admin
        /// </summary>
        public ENPersona Admin
        {
            get { return administrador; }
            set { administrador = value; }
        }

        /// <summary> .  </summary>
        protected bool __PAGINAR;
        /// <summary>
        /// get y set __PAGINAR
        /// </summary>
        public bool Paginar
        {
            get { return __PAGINAR; }
            set { __PAGINAR = value; }
        }
        
        /// <summary> .  </summary>
        protected int __TOTAL_registros;
        /// <summary>
        /// get y set __TOTAL_registros
        /// </summary>
        public int TOTAL_registros
        {
            get { return __TOTAL_registros; }
            set { __TOTAL_registros = value; }
        }

        /// <summary> .  </summary>
        protected int __PAGINA_registros;
        /// <summary>
        /// get y set __PAGINA_registros
        /// </summary>
        public int PAGINA_registros
        {
            get { return __PAGINA_registros; }
            set { __PAGINA_registros = value; }
        }

        /// <summary> .  </summary>
        protected const int __MIN_PAGINA_registros = 10;
        /// <summary>
        /// get __MIN_PAGINA_registros
        /// </summary>
        public int MIN_PAGINA_registros
        {
            get { return __MIN_PAGINA_registros; }
        }

        /// <summary> .  </summary>
        protected int __ACTUAL_registro;
        /// <summary>
        /// get y set __ACTUAL_registro
        /// </summary>
        public int ACTUAL_registro
        {
            get { return __ACTUAL_registro; }
            set { __ACTUAL_registro = value; }
        }
        
        protected kPerfil perfil;
        
        /// <summary>
        /// get y set dni
        /// </summary>
        public kPerfil Perfil
        {
            get { return perfil; }
            set { perfil = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   . </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public FVistaSeccionBase()
        {
            InitializeComponent();
            administrador = new ENPersona();
            TbSeccionBaseErrorProvider = new System.Windows.Forms.ErrorProvider();
            TbSeccionBaseErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.BlinkIfDifferentError;
            Paginar = false;
            ACTUAL_registro = 1;
            PAGINA_registros = MIN_PAGINA_registros;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initialises this object. </summary>
        ///
        /// <remarks>   . </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        override public void Init()
        {
            etNombre.Text = administrador.Nombre + " " + administrador.Apellidos;
            if (administrador.Perfil == kPerfil.pModerador) vistaModerador();
            else if (administrador.Perfil == kPerfil.pTecnico) vistaTecnico();
            if (administrador.ImgData != null)
            {
                System.IO.Stream ms = new System.IO.MemoryStream(administrador.ImgData);
                System.Drawing.Bitmap miImagen = new Bitmap(ms);
                pbFoto.Image = (Image)miImagen;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Vista moderador. </summary>
        ///
        /// <remarks>   . </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void vistaModerador()
        {
            itemClientes.Visible = false;
            itemCanales.Visible = false;
            itemEmisiones.Visible = false;
            itemIncidencias.Visible = false;
            itemAdministradores.Visible = false;
            itemProgramas.Visible = false;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Vista tecnico. </summary>
        ///
        /// <remarks>   . </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void vistaTecnico()
        {
            itemCriticasModerador.Visible = false;
            itemComentariosModerador.Visible = false;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Dispara pulsado menu principal. </summary>
        ///
        /// <remarks>   . </remarks>
        ///
        /// <param name="e">    The. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void disparaPulsadoMenuPrincipal(fVistas e)
        {
            EventArgsBase eB = new EventArgsBase((int)e, (int) Perfil);
            PulsadoMenuPrincipal(this, eB);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by itemCliente for click events. </summary>
        ///
        /// <remarks>   . </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void itemCliente_Click(object sender, EventArgs e)
        {
            disparaPulsadoMenuPrincipal(fVistas.fSeccionClientes);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by itemCanales for click events. </summary>
        ///
        /// <remarks>   . </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void itemCanales_Click(object sender, EventArgs e)
        {
            disparaPulsadoMenuPrincipal(fVistas.fSeccionCanales);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by itemIncidencias for click events. </summary>
        ///
        /// <remarks>   . </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void itemIncidencias_Click(object sender, EventArgs e)
        {
            disparaPulsadoMenuPrincipal(fVistas.fSeccionIncidencias);
        }

        private void FVistaSeccionBase_Load(object sender, EventArgs e)
        {
           
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by itemProgramasModerador for click events. </summary>
        ///
        /// <remarks>   . </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void itemProgramasModerador_Click(object sender, EventArgs e)
        {
            disparaPulsadoMenuPrincipal(fVistas.fSeccionCriticasModerador);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by itemComentariosModerador for click events. </summary>
        ///
        /// <remarks>   . </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void itemComentariosModerador_Click(object sender, EventArgs e)
        {
            disparaPulsadoMenuPrincipal(fVistas.fSeccionComentariosModerador);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by itemPortada for click events. </summary>
        ///
        /// <remarks>   . </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void itemPortada_Click(object sender, EventArgs e)
        {
            disparaPulsadoMenuPrincipal(fVistas.fPortada);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by itemAdministradores for click events. </summary>
        ///
        /// <remarks>   . </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void itemAdministradores_Click(object sender, EventArgs e)
        {
            disparaPulsadoMenuPrincipal(fVistas.fSeccionAdministradores);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by itemEmisiones for click events. </summary>
        ///
        /// <remarks>   . </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void itemEmisiones_Click(object sender, EventArgs e)
        {
            disparaPulsadoMenuPrincipal(fVistas.fSeccionEmisiones);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Virtual Event handler. Called by pestanyasSeccionBase for click events. </summary>
        ///
        /// <remarks>   . </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        virtual public void pestanyasSeccionBase_Click(object sender, EventArgs e)
        {
            
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Mensaje sistema. </summary>
        ///
        /// <remarks>   . </remarks>
        ///
        /// <param name="l">    The  control. </param>
        /// <param name="m">    The message text. </param>
        /// <param name="tipo"> The tipo. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        virtual public void MensajeSistema(Label l, string m, kMensajeSistema tipo)
        {
            switch (tipo)
            {
                case kMensajeSistema.mERROR:
                    l.ForeColor = Color.Red;
                    m = "ERROR: " + m;
                    break;
                case kMensajeSistema.mADVERTENCIA:
                    l.ForeColor = Color.Orange;
                    m = "Atención: " + m;
                    break;
                case kMensajeSistema.mCORRECTO:
                    l.ForeColor = Color.Green;
                    break;
            }
            l.Text = m;
        }

       ////////////////////////////////////////////////////////////////////////////////////////////////////
       /// <summary>    Mensaje paginacion. </summary>
       ///
       /// <remarks>    . </remarks>
       ///
       /// <param name="l">             The  control. </param>
       /// <param name="pagActual">     The pag actual. </param>
       /// <param name="pagTotales">    The pag totales. </param>
       ////////////////////////////////////////////////////////////////////////////////////////////////////

       virtual public void MensajePaginacion(Label l, int pagActual, int pagTotales)
        {
            l.Text = "(" + ACTUAL_registro.ToString() + "-" + Math.Min(ACTUAL_registro+PAGINA_registros-1,TOTAL_registros).ToString() + "/" + TOTAL_registros.ToString() + ") Página " + pagActual.ToString() + " de " + pagTotales.ToString();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the number paginas totales. </summary>
        ///
        /// <remarks>   . </remarks>
        ///
        /// <returns>   The number paginas totales. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected int getNumPaginasTotales()
        {
            int paginas_totales = 1;

            try
            {
                paginas_totales = (int) Math.Ceiling((double) TOTAL_registros / (double) PAGINA_registros);
            }
            catch (DivideByZeroException dbze)
            {
                paginas_totales = 1;
            }

            return paginas_totales;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets a number pagina actual. </summary>
        ///
        /// <remarks>   . </remarks>
        ///
        /// <param name="numero_registro">  The numero registro. </param>
        ///
        /// <returns>   The number pagina actual. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected int getNumPaginaActual(int numero_registro)
        {
            int paginas_actual = 1;

            try
            {
                paginas_actual = (int) Math.Ceiling((double)numero_registro / (double)PAGINA_registros);
            }
            catch (DivideByZeroException dbze)
            {
                paginas_actual = 1;
            }

            return paginas_actual;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Es ultima pagina. </summary>
        ///
        /// <remarks>   . </remarks>
        ///
        /// <param name="numregistro">  The numregistro. </param>
        ///
        /// <returns>   true if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected bool esUltimaPagina(int numregistro)
        {
            if (numregistro < TOTAL_registros && (numregistro + PAGINA_registros) > TOTAL_registros)
                return true;
            else return false;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Es desbordamiento pagina. </summary>
        ///
        /// <remarks>   . </remarks>
        ///
        /// <param name="numregistro">  The numregistro. </param>
        ///
        /// <returns>   true if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected bool esDesbordamientoPagina(int numregistro)
        {
            if (numregistro > TOTAL_registros)
                return true;
            else return false;
        }

        virtual public void imgBusquedaRapida_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Busqueda Rápida");
            pestanyasSeccionBase.SelectTab(pestanyasSeccionBase.GetControl(0).Name);
        }

        private void tbBusquedaRapida_Enter(object sender, EventArgs e)
        {
            tbBusquedaRapida.Text = "";
            tbBusquedaRapida.Font = new Font(this.Font, FontStyle.Regular);
            imgBusquedaRapida.Enabled = true;
        }

        private void tbBusquedaRapida_Leave(object sender, EventArgs e)
        {
            if (tbBusquedaRapida.Text == "") 
            {
                tbBusquedaRapida.Text = "Búsqueda rápida";
                tbBusquedaRapida.Font = new Font(this.Font, FontStyle.Italic);
                imgBusquedaRapida.Enabled = false;
            }
            
        }

        private void imgBusquedaRapida_MouseHover(object sender, EventArgs e)
        {
            // tbBusquedaRapida.Focus();
        }

        private void imgBusquedaRapida_MouseEnter(object sender, EventArgs e)
        {
            if (imgBusquedaRapida.Enabled == true)
            {
                this.Cursor = Cursors.Hand;
            }
            else this.Cursor = Cursors.Default;
        }

        private void imgBusquedaRapida_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void tbBusquedaRapida_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                imgBusquedaRapida_Click((object)sender, null);
            }
        }

        private void itemProgramas_Click(object sender, EventArgs e)
        {
            disparaPulsadoMenuPrincipal(fVistas.fSeccionProgramas);
        }

        private void itemAcercaDe_Click(object sender, EventArgs e)
        {
            FVistaAcercaDe ad = new FVistaAcercaDe();
            ad.ShowDialog();
        }
    }
}
