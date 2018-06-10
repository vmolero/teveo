////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	CVistaBase\FVistaSeccionXML.cs
//
// summary:	Implementa la clase FVistaSeccionXML
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using TVO_EntidadesDeNegocio;
using System.Collections;
using TVO_Utiles;
using System.Security;
using System.Diagnostics;
using System.IO;

////////////////////////////////////////////////////////////////////////////////////////////////////
// namespace: TVO_VistaWindows
//
// summary:	Espacio de nombres.
////////////////////////////////////////////////////////////////////////////////////////////////////

namespace TVO_VistaWindows
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Vista seccion xml. </summary>
    ///
    /// <remarks>   Victor, 14/04/2010. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class FVistaSeccionXML : TVO_VistaWindows.FVistaSeccionBase
    {
        /// <summary> Atributo privado estático y de sólo lectura instancia.  </summary>
        /// <value>Representa la instancia de la ventana abierta, que se única por ejecución.</value>
        private static readonly FVistaSeccionXML instancia = new FVistaSeccionXML();

        
        /// <summary> Id cadena.  </summary>
        int ID_cadena;

        /// <summary> XElement Raiz. Raiz del documento XML a leer. </summary>
        private XElement xRaiz;
        
        /// <summary> Descriptor de entrada.  </summary>
        StreamWriter inputWriter;
        /// <summary> Descriptor de salida.  </summary>
        StreamReader outputReader;
        /// <summary> Desciptor de salida de error.  </summary>
        StreamReader errorReader;
        
        /// <summary> Lista de emisiones.  </summary>
        List<ENEmision> listaEmisionCompleta;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor por defecto</summary>
        ///
        /// <remarks>   Ajusta los componentes visuales. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private FVistaSeccionXML()
        {
            InitializeComponent();
            this.etSeccion.Text = "Gestión de XMLTV";
            this.etAccion.Text = "Añadir programación";
            listaEmisionCompleta = new List<ENEmision>();
            pestanyasSeccionBase.GetControl(0).Text = "XMLTV";
            pestanyasSeccionBase.GetControl(1).Text = "Deshabilitado";
            // pestanyasSeccionBase.TabPages.RemoveByKey("Deshabilitado");
            pestanyasSeccionBase.TabPages.RemoveAt(1);
            // (TabPage)pestanyasSeccionBase.GetControl(1)
            gbInfoXML.Visible = false;
        }

        void p_Exited(object sender, EventArgs e)
        {
            if (inputWriter != null) inputWriter.Close();
            if (outputReader != null) outputReader.Close();
            if (errorReader != null) errorReader.Close();
           //  p.Close();
            // MessageBox.Show("Proceso exited");
        }

        
        void p_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            // MessageBox.Show(e.Data.ToString());
        }

        void p_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!String.IsNullOrEmpty(e.Data))
            {
                // rtbOutput.AppendText(e.Data.ToString());
                // MessageBox.Show(e.Data.ToString());
                MensajeSistema(etRespuesta, e.Data, kMensajeSistema.mCORRECTO);

            }
            else
            {
                MensajeSistema(etInfoXML, e.Data, kMensajeSistema.mERROR);
                gbInfoXML.Visible = true;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Mensaje sistema adaptada a un RichTextBox. </summary>
        ///
        /// <remarks>   Victor, 14/04/2010. </remarks>
        ///
        /// <param name="l">    RichTextBox destino. </param>
        /// <param name="m">    Mensaje que se desea mostrar. </param>
        /// <param name="tipo"> Tipo de mensaje. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void MensajeSistema(RichTextBox l, string m, kMensajeSistema tipo)
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
                    l.ForeColor = Color.Black;
                    break;
            }
            l.Text = m;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Devuelve la instancia de la clase. </summary>
        ///
        /// <value> instancia. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static FVistaSeccionXML Instancia
        {
            get
            {
                return instancia;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Leer xmltv. </summary>
        ///
        /// <remarks>   Procesa el documento XML rellenando la lista List que almacena las emisiones.
        /// 
        /// Las etiquetas channel, contienen información de las cadenas, mientras que la etiqueta programme sobre 
        /// los programas.
        /// Una vez leído el XML, se ordena la lista usando como criterio la fecha de emisión, y, posteriormente
        /// se recorre para realizar las inserciones en la BD de forma correcta. Cada emisión debe calcular su duración con relación
        /// a la siguiente emsión dentro de la cadena.
        /// </remarks>
        ///
        /// <param name="xElem">    The x coordinate element. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void leerXMLtv(XElement xElem)
        {

            string infoLectura = "";

            
            infoLectura = etRespuesta.Text + "\nLeyendo XML...";
            MensajeSistema(etRespuesta, infoLectura, kMensajeSistema.mCORRECTO);
            MensajeSistema(etInfoXML, "Procesando XML...", kMensajeSistema.mCORRECTO);
            gbInfoXML.Visible = true;
            try
            {
                //La ruta del documento XML permite rutas relativas
                //respecto del ejecutable!
                int numcad = 0;
                int numprog = 0;
                Hashtable miguiaTV = new Hashtable();
                List<ENEmision> listaEmision = new List<ENEmision>();

                IEnumerable<XElement> ListaHijos = from el in xElem.Elements() select el;
                foreach (XElement e in ListaHijos)
                {
                    if (e.Name.LocalName == "channel")
                    {
                        IEnumerable<XElement> HijosDeChannel = from hijo in e.Elements() select hijo;
                        foreach (XElement h in HijosDeChannel)
                        {
                            if (h.Name.LocalName == "display-name")
                            {
                                ENCadena nuevo = new ENCadena(h.Value);
                                nuevo.Activo = true;
                                nuevo.Tipo = Enum.GetName(typeof(kTipo), kTipo.Generalista);
                                // e.Attribute
                                int id = nuevo.existeNombreCadena();

                                if (id == -1) // No existe el nombre en la BD
                                {
                                    nuevo.insertarCadena();
                                    miguiaTV[e.FirstAttribute.Value] = nuevo.Id;
                                    infoLectura = etRespuesta.Text + "\nAñadido nuevo Canal: " + nuevo.Nombre;
                                    MensajeSistema(etRespuesta, infoLectura, kMensajeSistema.mCORRECTO);
                                }
                                else
                                {
                                    miguiaTV[e.FirstAttribute.Value] = id;
                                    numcad++;
                                }
                            }
                        }
                    }

                    if (e.Name.LocalName == "programme")
                    {
                        // Start
                        string start = SecurityElement.Escape(e.Attribute("start").Value);
                        // Channel
                        string channel = e.Attribute("channel").Value;

                        int cadena = (int)miguiaTV[channel];
                        string nombre = SecurityElement.Escape(Validacion.SustituyeCaracteresRaros(e.Element("title").Value));

                        // string descripcion = xmlStringHelpers.ConvierteA_UTF8(e.Element("desc").Value);
                        string descripcion = SecurityElement.Escape(Validacion.SustituyeCaracteresRaros(e.Element("desc").Value));
                        int tematica = 1;
                        int calificacion = 1;
                        bool novedad = true;
                        bool activo = true;
                        int id_programa = -1;

                        ENPrograma p = new ENPrograma(cadena, tematica, calificacion, nombre, descripcion, activo, novedad);

                        if (!p.existePrograma())
                        {
                            p.InsertarPrograma();
                            id_programa = p.Id_Programa;
                            infoLectura = etRespuesta.Text + "\nAñadido nuevo Programa: " + p.Nombre;
                            MensajeSistema(etRespuesta, infoLectura, kMensajeSistema.mCORRECTO);
                            numprog++;
                        }
                        else
                        {
                            id_programa = p.ObtenerIdPrograma(0, nombre);
                        }

                        DateTimeConverter con = new DateTimeConverter();

                        string anyo = start.Substring(0, 4);
                        string mes = start.Substring(4, 2);
                        string dia = start.Substring(6, 2);
                        string hora = start.Substring(8, 2);
                        string minuto = start.Substring(10, 2);
                        string segundo = start.Substring(12, 2);

                        DateTime fechaHoraEmision = new DateTime(Convert.ToInt32(anyo), Convert.ToInt32(mes), Convert.ToInt32(dia), Convert.ToInt32(hora), Convert.ToInt32(minuto), Convert.ToInt32(segundo));
                        ENEmision emision = new ENEmision(cadena, id_programa, fechaHoraEmision, 0);

                        listaEmision.Add(emision);
                    }

                }
                listaEmision.Sort(ComparaENEmisionPorFechaInicio);


                MensajeSistema(etInfoXML, "Creando estructura de datos interna...", kMensajeSistema.mADVERTENCIA);
                gbInfoXML.Visible = true;
                foreach (int id_cadena in miguiaTV.Values)
                {
                    List<ENEmision> emisionPorCadena = new List<ENEmision>();

                    ID_cadena = id_cadena;

                    emisionPorCadena = listaEmision.FindAll(ComparaENEmisionPorCadena);  //(totaller.AddBookToTotal)ComparaENEmisionPorCadena);
                    // Bucle que asigna las duraciones
                    for (int j = 0; j < emisionPorCadena.Count; j++)
                    {
                        if (j == (emisionPorCadena.Count) - 1)
                        {
                            // Ultima emision
                            emisionPorCadena[emisionPorCadena.Count - 1].Duracion = 30;
                            listaEmisionCompleta.Add(emisionPorCadena[emisionPorCadena.Count - 1]);
                        }
                        else
                        {
                            // Todas excepto la última
                            ENEmision completa = emisionPorCadena[j];

                            DateTime actual = emisionPorCadena[j].FechaHoraInicio;
                            DateTime siguiente = emisionPorCadena[j + 1].FechaHoraInicio;

                            TimeSpan duracion = siguiente.Subtract(actual);

                            completa.Duracion = (int)Math.Ceiling(duracion.TotalMinutes);

                            listaEmisionCompleta.Add(completa);
                        }
                    }

                }

                infoLectura = etRespuesta.Text + "\nEstructura de datos interna cargada con la programación.";
                MensajeSistema(etRespuesta, infoLectura, kMensajeSistema.mCORRECTO);
                MensajeSistema(etInfoXML, "Proceso finalizado", kMensajeSistema.mCORRECTO);
                gbInfoXML.Visible = true;
            }
            catch (Exception ex)
            {
                if (MessageBox.Show("El fichero xml no está bien formado, hay que volver a generarlo. ¿Desea generar de nuevo el xml?", "TEVEO :: Aplicación de gestión", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    btnGenerarXML_Click((Button)btnCarga, null);
                }
            }

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Insertar emisiones. </summary>
        ///
        /// <remarks>   Una vez se tiene la lista de emisiones ordenada y con la duración asignada, se procede a
        /// insertar en la BD, la información leída.</remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void insertarEmisiones()
        {
            etRespuesta.Clear();
            string infoLectura = "Leyendo lista de Emisiones...";
            MensajeSistema(etRespuesta, infoLectura, kMensajeSistema.mCORRECTO);
            
            if (listaEmisionCompleta.Count > 0)
            {
                
                MensajeSistema(etInfoXML, "Actualizando la Base de Datos, no interrumpa este proceso...", kMensajeSistema.mADVERTENCIA);
                gbInfoXML.Visible = true;

                foreach (ENEmision emision in listaEmisionCompleta)
                {
                    try
                    {
                        emision.insertarEmision();

                        DataView dv = new DataView();
                        ENPrograma p = new ENPrograma();
                        ENCadena c = new ENCadena();

                        // p.Id_Programa = emision.Id_programa;

                        // dv = p.buscarPrograma(

                        //c.Id = emision.Id_cadena;


                        infoLectura = etRespuesta.Text + "\nInsertada emisión: " + emision.Id_programa + "(" + emision.Id_cadena + "): [" + emision.FechaHoraInicio.ToShortDateString() + "]";
                        MensajeSistema(etRespuesta, infoLectura, kMensajeSistema.mCORRECTO);
                        
                    }
                    catch (ENException enex)
                    {
                        infoLectura = etRespuesta.Text + "\nFranja ocupada: " + emision.Id_programa + "(" + emision.Id_cadena + "): [" + emision.FechaHoraInicio.ToShortDateString() + "]";
                        MensajeSistema(etRespuesta, infoLectura, kMensajeSistema.mCORRECTO);
                    }
                }
            }
            else
            {
                if (MessageBox.Show("Debe generar un fichero xml. ¿Desea hacerlo?", "TEVEO :: Aplicación de gestión", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    btnGenerarXML_Click((Button)btnCarga, null);
                }
                else
                {
                    MensajeSistema(etInfoXML, "Debe generar un documento XML", kMensajeSistema.mERROR);
                    gbInfoXML.Visible = true;
                }
            }
            MensajeSistema(etInfoXML, "Proceso finalizado", kMensajeSistema.mCORRECTO);
            gbInfoXML.Visible = true;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Compara en emision por cadena. </summary>
        ///
        /// <remarks>   Método predicado usado por el método FindAll para obtener todas las emisiones que pertenecen a una 
        /// única cadena. Se apoya en el atributo de clase ID_cadena.</remarks>
        ///
        /// <param name="x">    Emisión actual </param>
        ///
        /// <returns>   true if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private bool ComparaENEmisionPorCadena(ENEmision x)
        {
            return x.Id_cadena == ID_cadena;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Compara en emision por fecha inicio. </summary>
        ///
        /// <remarks>   Método delegado usado para la ordenación, método Sort, del objeto Collection.List </remarks>
        ///
        /// <param name="x">    Emision actual </param>
        /// <param name="y">    Siguiente emisión </param>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private int ComparaENEmisionPorFechaInicio(ENEmision x, ENEmision y)
        {
            return x.FechaHoraInicio.CompareTo(y.FechaHoraInicio);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by btnConfigurar for click events. </summary>
        ///
        /// <remarks>   Evento que lanza el proceso de configuración de XMLTV. Se lanza el proceso
        /// que escribe en la entrada estándar las respuestas necesarias para ejecutar el proceso.</remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnConfigurar_Click(object sender, EventArgs e)
        {
            btnConfigurar.Enabled = false;
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            try
            {
                
                
                MensajeSistema(etInfoXML, "Iniciando proceso de configuración...", kMensajeSistema.mADVERTENCIA);
                gbInfoXML.Visible = true;
                // System.Diagnostics.Process.Start("xmltv\\xmltv.exe", "tv_grab_es_miguiatv --configure");

                //System.Diagnostics.Process.Start("xmltv\\xmltv.exe", "tv_grab_es_miguiatv --output hoy.xml --days 1");
                // tv_grab_es_miguiatv [--config-file xmltv\\.xmltv\\tv_grab_es_miguiatv.conf] [--output FILE] [--days N]

                p.StartInfo.FileName = "xmltv\\xmltv.exe";
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.Arguments = " tv_grab_es_miguiatv --configure";
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.ErrorDialog = false;

                MensajeSistema(etRespuesta, "Comando: $ xmltv  tv_grab_es_miguiatv --configure", kMensajeSistema.mCORRECTO);

                bool processStarted = p.Start();
                if (processStarted)
                {
                    inputWriter = p.StandardInput;
                    outputReader = p.StandardOutput;
                    errorReader = p.StandardError;

                    inputWriter.WriteLine("yes");
                    inputWriter.WriteLine("yes");
                    inputWriter.WriteLine("all");
                    
                    p.WaitForExit();

                    //Display the result
                    string displayText = "Salida" + Environment.NewLine + "==============" + Environment.NewLine;
                    displayText += outputReader.ReadToEnd();
                    displayText += errorReader.ReadToEnd();
                    MensajeSistema(etRespuesta, displayText, kMensajeSistema.mCORRECTO);
                    MensajeSistema(etInfoXML, "Proceso finalizado", kMensajeSistema.mCORRECTO);
                    gbInfoXML.Visible = true;
                }

                p.Close();

            }
            catch (Exception ex)
            {
                MensajeSistema(etInfoXML, "Error al crear el proceso", kMensajeSistema.mERROR);
                gbInfoXML.Visible = true;
            }
            finally
            {
                if (inputWriter != null)
                {
                    inputWriter.Close();
                }
                if (outputReader != null)
                {
                    outputReader.Close();
                }
                if (errorReader != null)
                {
                    errorReader.Close();
                }
                if (p != null) p.Close();
                btnConfigurar.Enabled = true;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by btnGenerarXML for click events. </summary>
        ///
        /// <remarks>   Evento que genera el fichero xml haciendo una llamada a XMLTV. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnGenerarXML_Click(object sender, EventArgs e)
        {
            
            
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            btnGenrarXML.Enabled = false;
            try
            {

                if (System.IO.File.Exists(".xmltv\\tv_grab_es_miguiatv.conf"))
                {

                    MensajeSistema(etInfoXML, "Generando XML...", kMensajeSistema.mADVERTENCIA);
                    gbInfoXML.Visible = true;

                    // tv_grab_es_miguiatv [--config-file FILE] [--output FILE] [--days N]
                    // ./.xmltv/tv_grab_es_miguiatv.conf
                    p.StartInfo.FileName = "xmltv\\xmltv.exe";
                    p.StartInfo.UseShellExecute = true;
                    p.StartInfo.Arguments = " tv_grab_es_miguiatv --output xmltv\\hoy.xml --days 1";
                    p.StartInfo.RedirectStandardInput = false;
                    p.StartInfo.RedirectStandardOutput = false;
                    p.StartInfo.RedirectStandardError = false;
                    p.StartInfo.CreateNoWindow = false;
                    p.StartInfo.ErrorDialog = false;

                    // p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

                    MensajeSistema(etRespuesta, "Comando: $ xmltv tv_grab_es_miguiatv --output xmltv\\hoy.xml --days 1.  \nEste proceso puede tardar varios minutos, por favor espere...", kMensajeSistema.mCORRECTO);

                    bool processStarted = p.Start();
                    if (processStarted)
                    {
                        //Get the output stream
                        //outputReader = p.StandardOutput;
                        //errorReader = p.StandardError;

                        p.Exited += new EventHandler(p_Exited);
                        // Set 'EnableRaisingEvents' to true, to raise 'Exited' event when process is terminated.
                        p.EnableRaisingEvents = true;

                        p.WaitForExit();

                        //Display the result
                        // string displayText = "Salida" + Environment.NewLine + "==============" + Environment.NewLine;
                        // displayText += outputReader.ReadToEnd();
                        // displayText += Environment.NewLine + "Error" + Environment.NewLine + "==============" +
                        //                Environment.NewLine;
                        // displayText += errorReader.ReadToEnd();
                        MensajeSistema(etRespuesta, "Fichero hoy.xml generado correctamente.", kMensajeSistema.mCORRECTO);
                        MensajeSistema(etInfoXML, "Proceso finalizado", kMensajeSistema.mCORRECTO);
                        gbInfoXML.Visible = true;
                    }
                    p.Close();
                }
                else
                {
                    if (MessageBox.Show("El fichero de configuración no existe. ¿Desea crearlo?", "TEVEO :: Aplicación de gestión", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        btnConfigurar_Click((Button)btnConfigurar, null);
                        btnGenerarXML_Click((Button)btnGenrarXML, null);
                    }
                }
                

          }
          catch (Exception ex)
          {
              MessageBox.Show(ex.Message);
          }
          finally
          {
              if (inputWriter != null)
              {
                  inputWriter.Close();
              }
              if (outputReader != null)
              {
                  outputReader.Close();
              }
              if (errorReader != null)
              {
                  errorReader.Close();
              }
              if (p != null) p.Close();
              btnGenrarXML.Enabled = true;
          }

           
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by btnCarga for click events. </summary>
        ///
        /// <remarks>   Método que lee el XML generado e inserta los registros en la Base de Datos. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnCarga_Click(object sender, EventArgs e)
        {
            btnCarga.Enabled = false;
            try
            {
                if (System.IO.File.Exists(".xmltv\\tv_grab_es_miguiatv.conf"))
                {


                    if (!System.IO.File.Exists("xmltv\\hoy.xml"))
                    {

                        if (MessageBox.Show("El fichero xml con la programación no existe. ¿Desea generarlo?", "TEVEO :: Aplicación de gestión", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            btnGenerarXML_Click((Button)btnCarga, null);
                        }
                        else
                        {
                            throw new Exception("No se ha realizado ninguna acción.");
                        }
                    }
                    else
                    {
                        xRaiz = XElement.Load("xmltv\\hoy.xml");




                        if (MessageBox.Show("Esta operación modificará su Base de Datos, ¿Continuamos?", "TEVEO :: Aplicación de gestión", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            leerXMLtv(xRaiz);
                            insertarEmisiones();
                        }
                        else
                        {
                            throw new Exception("No se ha realizado ninguna acción.");
                        }
                    }
                }
                else
                {
                    if (MessageBox.Show("El fichero de configuración no existe. ¿Desea crearlo?", "TEVEO :: Aplicación de gestión", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        btnConfigurar_Click((Button)btnConfigurar, null);
                        btnCarga_Click((Button)btnCarga, null);
                    }
                    else
                    {
                        throw new Exception("No se ha realizado ninguna acción.");

                    }
                }
                
            }
            catch (XmlException xmlex)
            {
                if (MessageBox.Show("El fichero xml no está bien formado, hay que volver a generarlo. ¿Desea generar de nuevo el xml?", "TEVEO :: Aplicación de gestión", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    btnGenerarXML_Click((Button)btnCarga, null);
                }
                else
                {
                    gbInfoXML.Visible = true;

                    etRespuesta.Clear();
                    MensajeSistema(etInfoXML, xmlex.Message, kMensajeSistema.mADVERTENCIA);
                }
            }
            catch (Exception ex)
            {
                gbInfoXML.Visible = true;

                etRespuesta.Clear();
                MensajeSistema(etInfoXML, ex.Message, kMensajeSistema.mADVERTENCIA);
            }
            finally
            {
                btnCarga.Enabled = true;
            }
                
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by btnLimpiar for click events. </summary>
        ///
        /// <remarks>   Limpia el RichTextBox de resultados </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            etRespuesta.Clear();
        }
       
    
    }

    
}
