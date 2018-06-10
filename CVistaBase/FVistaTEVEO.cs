////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	CVistaBase\FVistaTEVEO.cs
//
// summary:	Implements the vista teveo class
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
using TVO_VistaWindows;

////////////////////////////////////////////////////////////////////////////////////////////////////
// namespace: TVO_VistaWindows
//
// summary:	.
////////////////////////////////////////////////////////////////////////////////////////////////////

namespace TVO_VistaWindows
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent fVistas. </summary>
    ///
    /// <remarks>   . </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public enum fVistas
    {
        fAcceso,
        fPortada,
        fSeccionCriticasModerador,
        fSeccionComentariosModerador,
        fSeccionClientes,
        fSeccionEmisiones,
        fSeccionIncidencias,
        fSeccionCanales,
        fSeccionProgramas,
        fSeccionAdministradores,
        fSeccionXML
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Vista teveo. </summary>
    ///
    /// <remarks>   . </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public sealed partial class FVistaTEVEO : TVO_VistaWindows.FVistaBase
    {
        /// <summary> .  </summary>
        private FVistaBase TVO_FormActivo;
        public static kPerfil perfil;
        /// <summary> .  </summary>
        private ENPersona administrador;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   . </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public FVistaTEVEO()
        {
            InitializeComponent();
            TVO_FormActivo = null;
            administrador = new ENPersona();   
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by FVistaTEVEO for load events. </summary>
        ///
        /// <remarks>   . </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FVistaTEVEO_Load(object sender, EventArgs e)
        {
            TVO_Mostar_FormAcceso();
            this.Hide();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tvo mostar form acceso. </summary>
        ///
        /// <remarks>   . </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void TVO_Mostar_FormAcceso()
        {
            FVistaAcceso TVO_FormAcceso = FVistaAcceso.Instancia;
            TVO_FormAcceso.Admin = administrador;
            try
            {
                TVO_FormActivo.Hide();

            }
            catch (NullReferenceException nr)
            {
                TVO_FormActivo = TVO_FormAcceso;
            }
            finally
            {
                TVO_FormActivo = TVO_FormAcceso;
                TVO_FormActivo.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CierraAplicacion);
                TVO_FormAcceso.Init();
                TVO_FormAcceso.EventoValidar += new FVistaAcceso.EventoAccesoHandler(RespuestaFormAcceso_Validar);
                TVO_FormActivo.Show();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tvo mostar form portada moderador. </summary>
        ///
        /// <remarks>   . </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void TVO_Mostar_FormPortadaModerador()
        {
            FVistaPortadaModerador TVO_FormPortadaModerador = FVistaPortadaModerador.Instancia;
            TVO_FormPortadaModerador.Admin = administrador;

            try
            {
                TVO_FormActivo.Hide();

            }
            catch (NullReferenceException nr)
            {
                TVO_FormActivo = TVO_FormPortadaModerador;
            }
            finally
            {
                TVO_FormActivo = TVO_FormPortadaModerador;
                TVO_FormActivo.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CierraAplicacion);
                TVO_FormPortadaModerador.PulsadoBotonMenu += new FVistaPortadaBase.EventoMenuHandler(CargaSeccion);
                TVO_FormPortadaModerador.CerrarSesion += new FVistaPortadaBase.EventoCerrarSesionHandler(CierraSesion);
                TVO_FormActivo.Init();
                TVO_FormActivo.Show();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tvo mostar form portada tecnico. </summary>
        ///
        /// <remarks>   . </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void TVO_Mostar_FormPortadaTecnico()
        {
            FVistaPortadaTecnico TVO_FormPortadaTecnico = FVistaPortadaTecnico.Instancia;
            TVO_FormPortadaTecnico.Admin = administrador;

            try
            {
                TVO_FormActivo.Hide();

            }
            catch (NullReferenceException nr)
            {
                TVO_FormActivo = TVO_FormPortadaTecnico;
            }
            finally
            {
                TVO_FormActivo = TVO_FormPortadaTecnico;
                TVO_FormActivo.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CierraAplicacion);
                TVO_FormPortadaTecnico.PulsadoBotonMenu += new FVistaPortadaBase.EventoMenuHandler(CargaSeccion);
                TVO_FormPortadaTecnico.CerrarSesion += new FVistaPortadaBase.EventoCerrarSesionHandler(CierraSesion);
                TVO_FormActivo.Init();
                TVO_FormActivo.Show();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tvo mostar form seccion criticas moderador. </summary>
        ///
        /// <remarks>   . </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void TVO_Mostar_FormSeccionCriticasModerador()
        {
            FVistaSeccionCriticasModerador TVO_FormSeccionCriticasModerador = FVistaSeccionCriticasModerador.Instancia;
            TVO_FormSeccionCriticasModerador.Perfil = kPerfil.pModerador;
            TVO_FormSeccionCriticasModerador.Admin = administrador;

            try
            {
                TVO_FormActivo.Hide();

            }
            catch (NullReferenceException nr)
            {
                TVO_FormActivo = TVO_FormSeccionCriticasModerador;
            }
            finally
            {
                TVO_FormActivo = TVO_FormSeccionCriticasModerador;
                TVO_FormSeccionCriticasModerador.PulsadoMenuPrincipal += new FVistaSeccionBase.EventoMenuPrincipalHandler(CargaSeccion);
                TVO_FormActivo.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CierraAplicacion);
                TVO_FormActivo.Init();
                TVO_FormActivo.Show();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tvo mostar form seccion comentarios moderador. </summary>
        ///
        /// <remarks>   . </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void TVO_Mostar_FormSeccionComentariosModerador()
        {
            FVistaSeccionComentariosModerador TVO_FormSeccionComentariosModerador = FVistaSeccionComentariosModerador.Instancia;
            TVO_FormSeccionComentariosModerador.Perfil = kPerfil.pModerador;
            TVO_FormSeccionComentariosModerador.Admin = administrador;
            try
            {
                TVO_FormActivo.Hide();
            }
            catch (NullReferenceException nr)
            {
                TVO_FormActivo = TVO_FormSeccionComentariosModerador;
            }
            finally
            {
                
                TVO_FormActivo = TVO_FormSeccionComentariosModerador;
                TVO_FormActivo.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CierraAplicacion);
                TVO_FormSeccionComentariosModerador.PulsadoMenuPrincipal += new FVistaSeccionBase.EventoMenuPrincipalHandler(CargaSeccion);
                TVO_FormActivo.Init();
                TVO_FormActivo.Show();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tvo mostar form seccion canales. </summary>
        ///
        /// <remarks>   . </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void TVO_Mostar_FormSeccionCanales()
        {
            FVistaSeccionCadenas TVO_FormSeccionCanales = FVistaSeccionCadenas.Instancia;
            TVO_FormSeccionCanales.Perfil = kPerfil.pTecnico;
            TVO_FormSeccionCanales.Admin = administrador;

            try
            {
                TVO_FormActivo.Hide();
            }
            catch (NullReferenceException nr)
            {
                TVO_FormActivo = TVO_FormSeccionCanales;
            }
            finally
            {
                TVO_FormActivo = TVO_FormSeccionCanales;
                TVO_FormActivo.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CierraAplicacion);
                TVO_FormSeccionCanales.PulsadoMenuPrincipal += new FVistaSeccionBase.EventoMenuPrincipalHandler(CargaSeccion);
                TVO_FormActivo.Init();
                TVO_FormActivo.Show();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tvo mostar form seccion programas. </summary>
        ///
        /// <remarks>   . </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void TVO_Mostar_FormSeccionProgramas()
        {
            FVistaSeccionProgramas TVO_FormSeccionProgramas = FVistaSeccionProgramas.Instancia;
            TVO_FormSeccionProgramas.Perfil = kPerfil.pTecnico;
            TVO_FormSeccionProgramas.Admin = administrador;
            try
            {
                TVO_FormActivo.Hide();
            }
            catch (NullReferenceException nr)
            {
                TVO_FormActivo = TVO_FormSeccionProgramas;
            }
            finally
            {
                TVO_FormActivo = TVO_FormSeccionProgramas;
                TVO_FormActivo.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CierraAplicacion);
                TVO_FormSeccionProgramas.PulsadoMenuPrincipal += new FVistaSeccionBase.EventoMenuPrincipalHandler(CargaSeccion);
                TVO_FormActivo.Init();
                TVO_FormActivo.Show();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tvo mostar form seccion emisiones. </summary>
        ///
        /// <remarks>   . </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void TVO_Mostar_FormSeccionEmisiones()
        {
            FVistaSeccionEmisiones TVO_FormSeccionEmisiones = FVistaSeccionEmisiones.Instancia;
            TVO_FormSeccionEmisiones.Perfil = kPerfil.pTecnico;
            TVO_FormSeccionEmisiones.Admin = administrador;

            try
            {
                TVO_FormActivo.Hide();
            }
            catch (NullReferenceException nr)
            {
                TVO_FormActivo = TVO_FormSeccionEmisiones;
            }
            finally
            {
                TVO_FormActivo = TVO_FormSeccionEmisiones;
                TVO_FormActivo.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CierraAplicacion);
                TVO_FormSeccionEmisiones.PulsadoMenuPrincipal += new FVistaSeccionBase.EventoMenuPrincipalHandler(CargaSeccion);
                TVO_FormActivo.Init();
                TVO_FormActivo.Show();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tvo mostar form seccion incidencias. </summary>
        ///
        /// <remarks>   . </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void TVO_Mostar_FormSeccionIncidencias()
        {
            FVistaSeccionIncidencias TVO_FormSeccionIncidencias = FVistaSeccionIncidencias.Instancia;
            TVO_FormSeccionIncidencias.Perfil = kPerfil.pTecnico;
            TVO_FormSeccionIncidencias.Admin = administrador;
            try
            {
                TVO_FormActivo.Hide();
            }
            catch (NullReferenceException nr)
            {
                TVO_FormActivo = TVO_FormSeccionIncidencias;
            }
            finally
            {
                TVO_FormActivo = TVO_FormSeccionIncidencias;
                TVO_FormActivo.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CierraAplicacion);
                TVO_FormSeccionIncidencias.PulsadoMenuPrincipal += new FVistaSeccionBase.EventoMenuPrincipalHandler(CargaSeccion);
                TVO_FormActivo.Init();
                TVO_FormActivo.Show();
            }
        }

        private void TVO_Mostar_FormSeccionClientes()
        {
            FVistaSeccionClientes TVO_FormSeccionClientes = FVistaSeccionClientes.Instancia;
            TVO_FormSeccionClientes.Perfil = kPerfil.pTecnico;
            TVO_FormSeccionClientes.Admin = administrador;
            try
            {
                TVO_FormActivo.Hide();
            }
            catch (NullReferenceException nr)
            {
                TVO_FormActivo = TVO_FormSeccionClientes;
            }
            finally
            {
                TVO_FormActivo = TVO_FormSeccionClientes;
                TVO_FormActivo.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CierraAplicacion);
                TVO_FormSeccionClientes.PulsadoMenuPrincipal += new FVistaSeccionBase.EventoMenuPrincipalHandler(CargaSeccion);
                TVO_FormActivo.Init();
                TVO_FormActivo.Show();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tvo mostar form seccion administradores. </summary>
        ///
        /// <remarks>   . </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void TVO_Mostar_FormSeccionAdministradores()
        {
            FVistaSeccionAdministradores TVO_FormSeccionAdministradores = FVistaSeccionAdministradores.Instancia;
            TVO_FormSeccionAdministradores.Perfil = kPerfil.pTecnico;
            TVO_FormSeccionAdministradores.Admin = administrador;
            try
            {
                TVO_FormActivo.Hide();
            }
            catch (NullReferenceException nr)
            {
                TVO_FormActivo = TVO_FormSeccionAdministradores;
            }
            finally
            {
                TVO_FormActivo = TVO_FormSeccionAdministradores;
                TVO_FormActivo.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CierraAplicacion);
                TVO_FormSeccionAdministradores.PulsadoMenuPrincipal += new FVistaSeccionBase.EventoMenuPrincipalHandler(CargaSeccion);
                TVO_FormActivo.Init();
                TVO_FormActivo.Show();
            }
        }

        private void TVO_Mostar_FormSeccionXML()
        {
            FVistaSeccionXML TVO_FormSeccionXML = FVistaSeccionXML.Instancia;
            TVO_FormSeccionXML.Perfil = kPerfil.pTecnico;
            TVO_FormSeccionXML.Admin = administrador;
            try
            {
                TVO_FormActivo.Hide();
            }
            catch (NullReferenceException nr)
            {
                TVO_FormActivo = TVO_FormSeccionXML;
            }
            finally
            {
                TVO_FormActivo = TVO_FormSeccionXML;
                TVO_FormActivo.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CierraAplicacion);
                TVO_FormSeccionXML.PulsadoMenuPrincipal += new FVistaSeccionBase.EventoMenuPrincipalHandler(CargaSeccion);
                TVO_FormActivo.Init();
                TVO_FormActivo.Show();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by RespuestaFormAcceso for validar events. </summary>
        ///
        /// <remarks>   . </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        The. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void RespuestaFormAcceso_Validar(object sender, EventArgsAcceso e)
        {
            FVistaPortadaBase Portada = new FVistaPortadaBase();
            
            try
            {
                administrador = new ENPersona();
                administrador.Dni = Convert.ToString(e.persona["nif"]);
                administrador.Nombre = Convert.ToString(e.persona["nombre"]);
                administrador.Apellidos = Convert.ToString(e.persona["apellidos"]);
                administrador.Perfil = (kPerfil)Convert.ToInt32(e.persona["perfil"]);
                if (e.persona["foto"] != null) administrador.ImgData = (byte[]) e.persona["foto"];

                if (administrador.Perfil == kPerfil.pTecnico) TVO_Mostar_FormPortadaTecnico();
                else if (administrador.Perfil == kPerfil.pModerador) TVO_Mostar_FormPortadaModerador();
                else throw new System.Exception("Error de validación");

                ((FVistaAcceso)sender).EventoValidar -= new FVistaAcceso.EventoAccesoHandler(RespuestaFormAcceso_Validar);
            }
            catch (Exception ex)
            {
                
                ((FVistaAcceso)TVO_FormActivo).Init();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Carga seccion. </summary>
        ///
        /// <remarks>   . </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        The. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void CargaSeccion(object sender, EventArgsBase e)
        {
            try
            {
                ((FVistaSeccionBase)sender).PulsadoMenuPrincipal -= CargaSeccion;
            }
            catch (InvalidCastException ice)
            {
                ((FVistaPortadaBase)sender).PulsadoBotonMenu -= CargaSeccion;
                ((FVistaPortadaBase)sender).CerrarSesion -= CierraSesion;
            }
            TVO_FormActivo.FormClosing -= new System.Windows.Forms.FormClosingEventHandler(this.CierraAplicacion);

            switch (e.opcion)
            {
                case (int)fVistas.fAcceso:
                    TVO_Mostar_FormAcceso();
                    break;
                case (int) fVistas.fPortada:
                    if (e.perfil == (int) kPerfil.pTecnico) TVO_Mostar_FormPortadaTecnico();
                    else if (e.perfil == (int) kPerfil.pModerador) TVO_Mostar_FormPortadaModerador();
                    break;
                case (int)fVistas.fSeccionCriticasModerador:
                    TVO_Mostar_FormSeccionCriticasModerador();
                    break;
                case (int)fVistas.fSeccionComentariosModerador:
                    TVO_Mostar_FormSeccionComentariosModerador();
                    break;
                case (int)fVistas.fSeccionClientes:
                    TVO_Mostar_FormSeccionClientes();
                    break;
                case (int)fVistas.fSeccionEmisiones:
                    TVO_Mostar_FormSeccionEmisiones();
                    break;
                case (int)fVistas.fSeccionIncidencias:
                    TVO_Mostar_FormSeccionIncidencias();
                    break;
                case (int)fVistas.fSeccionCanales:
                    TVO_Mostar_FormSeccionCanales();
                    break;
                case (int)fVistas.fSeccionAdministradores:
                    TVO_Mostar_FormSeccionAdministradores();
                    break;
                case (int)fVistas.fSeccionProgramas:
                    TVO_Mostar_FormSeccionProgramas();
                    break;
                case (int)fVistas.fSeccionXML:
                    TVO_Mostar_FormSeccionXML();
                    break;
                default:
                    break;
        
            }
            
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Cierra sesion. </summary>
        ///
        /// <remarks>   . </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        The. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void CierraSesion(object sender, EventArgsPortadaBase e)
        {

            if (MessageBox.Show("¿Desea cerrar la sesión?", "TEVEO :: Aplicación de gestión", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                ((FVistaPortadaBase)sender).CerrarSesion -= CierraSesion;
                //((FVistaPortadaBase)sender).CerrarSesion -= CierraSesion;
                ((FVistaPortadaBase)sender).PulsadoBotonMenu -= CargaSeccion;
                //((FVistaPortadaBase)sender).PulsadoBotonMenu -= CargaSeccion;
                TVO_FormActivo.FormClosing -= new System.Windows.Forms.FormClosingEventHandler(this.CierraAplicacion);
                administrador = null;
                TVO_Mostar_FormAcceso();
            }
            
            
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Cierra aplicacion. </summary>
        ///
        /// <remarks>   . </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Form closing event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void CierraAplicacion(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Desea cerrar la aplicación?", "TEVEO :: Aplicación de gestión", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Application.ExitThread();
            }
            else
            {
                e.Cancel = true;
            }
            
        }
    }
}
