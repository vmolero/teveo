////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	TVO_EntidadesDeNegocio\ENCritica.cs
//
// summary:	Implementa la Entidad de Negocio de Crítica
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TVO_ComponentesAccesoDatos;

namespace TVO_EntidadesDeNegocio
{
    public class ENCritica
    {
        int idPrograma;
        int cadena;
        string programa;
        string descripcionPrograma;
        int tematica;
        int calificacion;
        int novedad;
        string moderador;
        string critica;
        DateTime fechaCritica;
        /// <summary>
        /// DataSet con un listado de programas
        /// </summary>
        DataSet listaProgramas;


        public int IdPrograma
        {
            get { return idPrograma; }
            set { idPrograma = value; }
        }
        

        public int Cadena
        {
            get { return cadena; }
            set { cadena = value; }
        }
        

        public string Programa
        {
            get { return programa; }
            set { programa = value; }
        }
        

        public string DescripcionPrograma
        {
            get { return descripcionPrograma; }
            set { descripcionPrograma = value; }
        }
        

        public int Tematica
        {
            get { return tematica; }
            set { tematica = value; }
        }
        

        public int Calificacion
        {
            get { return calificacion; }
            set { calificacion = value; }
        }
        

        public int Novedad
        {
            get { return novedad; }
            set { novedad = value; }
        }
        

        public string Moderador
        {
            get { return moderador; }
            set { moderador = value; }
        }
        

        public string Critica
        {
            get { return critica; }
            set { critica = value; }
        }
        

        public DateTime FechaCritica
        {
            get { return fechaCritica; }
            set { fechaCritica = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ENCritica()
        {
            this.idPrograma = -1;
            this.cadena = -1;
            this.programa = "";
            this.descripcionPrograma = "";
            this.tematica = -1;
            this.calificacion = -1;
            this.novedad = 0;
            this.moderador = "";
            this.critica = "";
            this.fechaCritica = new DateTime();
            this.listaProgramas = null;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ///
        /// <param name="id">   Identificador de programa. </param>
        /// <param name="c">    Id de cadena. </param>
        /// <param name="p">    Nombre del programa. </param>
        /// <param name="dp">   Descripción del programa. </param>
        /// <param name="t">    Temática. </param>
        /// <param name="cal">  Calificación por Edades. </param>
        /// <param name="nov">  Novedad o no (0 no, 1 sí). </param>
        /// <param name="mod">  Moderador. </param>
        /// <param name="cri">  Crítica. </param>
        /// <param name="f">    Fecha de la crítica. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ENCritica(int id, int c, string p, string dp, int t, int cal, int nov, string mod, string cri, DateTime f)
        {
            this.idPrograma = id;
            this.cadena = c;
            this.programa = p;
            this.descripcionPrograma = dp;
            this.tematica = t;
            this.calificacion = cal;
            this.novedad = nov;
            this.moderador = mod;
            this.critica = cri;
            this.fechaCritica = f;
            this.listaProgramas = null;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Establecer programa. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ///
        /// <param name="id">   Identificador de programa. </param>
        /// <param name="c">    Id de cadena. </param>
        /// <param name="p">    Nombre del programa. </param>
        /// <param name="dp">   Descripción del programa. </param>
        /// <param name="t">    Temática. </param>
        /// <param name="cal">  Calificación por Edades. </param>
        /// <param name="nov">  Novedad o no (0 no, 1 sí). </param>
        /// <param name="mod">  Moderador. </param>
        /// <param name="cri">  Crítica. </param>
        /// <param name="f">    Fecha de la crítica. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void EstablecerPrograma(int id, int c, string p, string dp, int t, int cal, int nov, string mod, string cri, DateTime f)
        {
            this.idPrograma = id;
            this.cadena = c;
            this.programa = p;
            this.descripcionPrograma = dp;
            this.tematica = t;
            this.calificacion = cal;
            this.novedad = nov;
            this.moderador = mod;
            this.critica = cri;
            this.fechaCritica = f;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   
        /// Inicializa el DataSet y le asigna todos los datos de comentarios que hay en la Base de Datos. 
        /// </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ///
        /// <returns>   Un dataview con todos los datos. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataView InicializarListadoProgramas()
        {
            DataView retorno;
            try
            {
                CADPrograma cad = new CADPrograma();
                // Inicializamos el DataSet
                listaProgramas = new DataSet();
                listaProgramas = cad.ObtenerProgramasActivos();
                retorno = new DataView(listaProgramas.Tables["programa"]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return (retorno);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Devuelve una vista actual del DataSet. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ///
        /// <returns>   Un DataView con todos los datos que contiene actualmente ds. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataView ObtenerListadoProgramas()
        {
            return (listaProgramas.Tables["programa"].DefaultView);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   
        /// Mete en un DataTable los datos que se mostraran posteriormente, limitando el número de filas
        /// a la cantidad estipulada en numFilas, tiene en cuenta la pagina de la rejilla en que nos
        /// encontramos para devolver los datos. 
        /// </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ///
        /// <param name="dv">               Vista completa de los datos. </param>
        /// <param name="primerRegistro">   The primer registro. </param>
        /// <param name="ultimoRegistro">   The ultimo registro. </param>
        ///
        /// <returns>   Un DataTable con los datos a mostrar en la página actual. </returns>
        ///
        /// ### <param name="pagAct">   Pagina correspondiente a los datos que se mostrarán. </param>
        /// ### <param name="numFilas"> Número máximo de filas que se devolverán. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataTable ObtenerTablaProgramas(DataView dv, int primerRegistro, int ultimoRegistro)
        {
            DataTable dtAux = new DataTable();
            // copiamos en nuestra tabla el formato de la tabla comentario del DG
            dtAux = listaProgramas.Tables["programa"].Clone();
            dtAux.Columns.Add("canalAux", System.Type.GetType("System.String"));
            dtAux.Columns.Add("novedadAux", System.Type.GetType("System.String"));
            dtAux.Columns.Add("tematicaAux", System.Type.GetType("System.String"));
            dtAux.Columns.Add("calificacionAux", System.Type.GetType("System.String"));

            for (int i = primerRegistro, j = 0; i < dv.Count && i < ultimoRegistro; i++, j++)
            {
                dtAux.Rows.Add();
                dtAux.Rows[j]["id"] = dv[i].Row["id"];
                dtAux.Rows[j]["nombre"] = dv[i].Row["nombre"];
                dtAux.Rows[j]["descripcion"] = dv[i].Row["descripcion"];
                dtAux.Rows[j]["moderador"] = dv[i].Row["moderador"];
                dtAux.Rows[j]["critica"] = dv[i].Row["critica"];
                dtAux.Rows[j]["fecha_critica"] = dv[i].Row["fecha_critica"];
                // aunque estos campos no se mostrarán, si los necesitaremos luego, así que los guardamos
                dtAux.Rows[j]["cadena"] = dv[i].Row["cadena"];
                dtAux.Rows[j]["tematica"] = dv[i].Row["tematica"];
                dtAux.Rows[j]["calificacion"] = dv[i].Row["calificacion"];
                dtAux.Rows[j]["novedad"] = dv[i].Row["novedad"];
                // rellenamos los campos de los que tenemos solo su id con su nombre correspondiente
                dtAux.Rows[j]["canalAux"] = ObtenerNombreCanal(dv[i].Row["cadena"].ToString());
                dtAux.Rows[j]["tematicaAux"] = ObtenerNombreTematica(dv[i].Row["tematica"].ToString());
                dtAux.Rows[j]["calificacionAux"] = ObtenerNombreCalificacion(dv[i].Row["calificacion"].ToString());
                if (dv[i].Row["novedad"].ToString() == "0")
                {
                    dtAux.Rows[j]["novedadAux"] = "no";
                }
                else
                {
                    dtAux.Rows[j]["novedadAux"] = "si";
                }
            }

            return dtAux;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Devuelve la tabla de cadena (id y nombre) en un DataView. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ///
        /// <returns>   Un dataView con los datos. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataView DevolverCanales()
        {
            return listaProgramas.Tables["cadena"].AsDataView();
        }

        /// <summary>
        /// Devuelve el id que se corresponde con el nombre del canal que le pasamos
        /// </summary>
        /// <param name="nombreCanal">el nombre del canal</param>
        /// <returns>Un entero con el identificador del canal</returns>
        public int ObtenerIdCanal(string nombreCanal)
        {
            // Recorremos toda la tabla "cadena" del dataSet
            foreach (DataRowView dr in listaProgramas.Tables["cadena"].AsDataView())
            {
                if (dr["nombre"].ToString() == nombreCanal)
                {
                    // cuando lo encontramos lo devolvemos
                    return int.Parse(dr["id"].ToString());
                }
            }
            // si no existe se devuelve -1
            // (no habrá ningún resultado coincidente en la búsqueda)
            return -1;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   
        /// Devuelve una cadena de texto con el nombre del canal que se corresponde con el identificador
        /// que le pasamos por parámetro. 
        /// </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ///
        /// <param name="id">   Identificador del canal. </param>
        ///
        /// <returns>   Un string con el nombre del canal. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private string ObtenerNombreCanal(string id)
        {
            // Recorremos toda la tabla "cadena" del dataSet
            foreach (DataRowView dr in listaProgramas.Tables["cadena"].AsDataView())
            {
                if (dr["id"].ToString() == id)
                {
                    // cuando lo encontramos lo devolvemos
                    return dr["nombre"].ToString();
                }
            }
            return "";
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   
        /// Devuelve una cadena de texto con el nombre de la tematica que se corresponde con el
        /// identificador que le pasamos por parámetro. 
        /// </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ///
        /// <param name="id">   Identificador de la tematica. </param>
        ///
        /// <returns>   Un string con el nombre de la tematica. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private string ObtenerNombreTematica(string id)
        {
            // Recorremos toda la tabla "tematica" del dataSet
            foreach (DataRowView dr in listaProgramas.Tables["tematica"].AsDataView())
            {
                if (dr["id"].ToString() == id)
                {
                    // cuando lo encontramos lo devolvemos
                    return dr["nombre"].ToString();
                }
            }
            return "";
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   
        /// Devuelve una cadena de texto con el nombre de la calificación que se corresponde con el
        /// identificador que le pasamos por parámetro. 
        /// </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ///
        /// <param name="id">   Identificador de la calificacion. </param>
        ///
        /// <returns>   Un string con el nombre de la calificacion por edades. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private string ObtenerNombreCalificacion(string id)
        {
            // Recorremos toda la tabla "calificacion" del dataSet
            foreach (DataRowView dr in listaProgramas.Tables["calificacion"].AsDataView())
            {
                if (dr["id"].ToString() == id)
                {
                    // cuando lo encontramos lo devolvemos
                    return dr["nombre"].ToString();
                }
            }
            return "";
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   
        /// Modifica un comentario en el DataSet, pero no lo guarda todavía en la Base de Datos. 
        /// </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ///
        /// <returns>   Devuelve la fila que se ha cambiado. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataRow AnadirCritica()
        {
            int i = 0, posicionDs = 0;
            string idAux = idPrograma.ToString();
            DataRow retorno = null;

            // Buscamos la posicion del DataSet donde se encuentra la fila cambiada
            foreach (DataRow fila in listaProgramas.Tables["programa"].Rows)
            {
                if (fila["id"].ToString() == idAux)
                {
                    posicionDs = i;
                }
                i++;
            }

            // Asignamos la fila cambiada al DataSet
            listaProgramas.Tables["programa"].Rows[posicionDs]["moderador"] = this.moderador;
            listaProgramas.Tables["programa"].Rows[posicionDs]["fecha_critica"] = this.fechaCritica;
            listaProgramas.Tables["programa"].Rows[posicionDs]["critica"] = this.critica;
            
            return ObtenerTablaProgramas(listaProgramas.Tables["programa"].AsDataView(), posicionDs, posicionDs + 1).Rows[0];
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   
        /// Guarda en la Base de Datos los cambios introducidos en el DataSet desde que fue creado. 
        /// </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void ConfirmarCambios()
        {
            try
            {
                CADPrograma cad = new CADPrograma();
                cad.ActualizarCritica(listaProgramas);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   
        /// Devuelve el formato que la tabla programa tiene en el DataSet para ser asignado a un
        /// DataTable. 
        /// </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataTable InicializarPendientes()
        {
            DataTable dtAux = listaProgramas.Tables["programa"].Clone();
            dtAux.Columns.Add("canalAux", System.Type.GetType("System.String"));
            dtAux.Columns.Add("novedadAux", System.Type.GetType("System.String"));
            dtAux.Columns.Add("tematicaAux", System.Type.GetType("System.String"));
            dtAux.Columns.Add("calificacionAux", System.Type.GetType("System.String"));
            return dtAux;
        }

    }
}
