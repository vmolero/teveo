using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TVO_ComponentesAccesoDatos;

namespace TVO_EntidadesDeNegocio
{
    public class ENComentario
    {
        int id;
        int programa;
        int canal;
        string subusuario;
        string texto;
        DateTime fecha;
        int validado;
        /// <summary>
        /// DataSet con un listado de los comentarios
        /// </summary>
        DataSet ds;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ENComentario()
        {
            id = -1;
            programa = -1;
            canal = -1;
            subusuario = "";
            texto = "";
            fecha = new DateTime();
            validado = 0;
            ds = null;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ///
        /// <param name="i">    El indice </param>
        /// <param name="p">    El programa. </param>
        /// <param name="c">    El canal. </param>
        /// <param name="s">    El autor(subusuario). </param>
        /// <param name="t">    El texto del comentario. </param>
        /// <param name="f">    La fecha. </param>
        /// <param name="v">    Si está validado (0 no, 1 si). </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ENComentario(int i, int p, int c, string s, string t, DateTime f, int v)
        {
            id = i;
            programa = p;
            canal = c;
            subusuario = s;
            texto = t;
            fecha = f;
            validado = v;
            ds = null;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int Programa
        {
            get { return programa; }
            set { programa = value; }
        }

        public int Canal
        {
            get { return canal; }
            set { canal = value; }
        }

        public string Subusuario
        {
            get { return subusuario; }
            set { subusuario = value; }
        }

        public string Texto
        {
            get { return texto; }
            set { texto = value; }
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public int Validado
        {
            get { return validado; }
            set { validado = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Establecer comentario. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ///
        /// <param name="i">    El indice </param>
        /// <param name="p">    El programa. </param>
        /// <param name="c">    El canal. </param>
        /// <param name="s">    El autor(subusuario). </param>
        /// <param name="t">    El texto del comentario. </param>
        /// <param name="f">    La fecha. </param>
        /// <param name="v">    Si está validado (0 no, 1 si). </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void EstablecerComentario(int i, int p, int c, string s, string t, DateTime f, int v)
        {
            id = i;
            programa = p;
            canal = c;
            subusuario = s;
            texto = t;
            fecha = f;
            validado = v;
        }

        /// <summary>
        /// Inicializa el DataSet y le asigna todos los datos de comentarios 
        /// que hay en la Base de Datos
        /// </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ///
        /// <returns>   Un dataview con todos los datos. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataView InicializarListadoComentarios()
        {
            DataView retorno;
            try
            {
                CADComentario cad = new CADComentario();
                // Inicializamos el DataSet
                ds = new DataSet();
                ds = cad.ObtenerComentarios();
                retorno = new DataView(ds.Tables["comentario"]);
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
        /// <returns>   Un DataView con todos los datos que contiene actualment ds. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataView ObtenerListadoComentarios()
        {
            return (ds.Tables["comentario"].DefaultView);
        }

        /// <summary>
        /// Mete en un DataTable los datos que se mostraran posteriormente,
        /// limitando el número de filas a la cantidad estipulada en numFilas,
        /// tiene en cuenta la pagina de la rejilla en que nos encontramos para devolver los datos.
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


        public DataTable ObtenerTablaComentarios(DataView dv, int primerRegistro, int ultimoRegistro)
        {            
            DataTable dtAux = new DataTable();
            // copiamos en nuestra tabla el formato de la tabla comentario del DG
            dtAux = ds.Tables["comentario"].Clone();
            dtAux.Columns.Add("canalAux", System.Type.GetType("System.String"));
            dtAux.Columns.Add("programaAux", System.Type.GetType("System.String"));
            dtAux.Columns.Add("validadoAux", System.Type.GetType("System.String"));

            for (int i = primerRegistro, j = 0; i < dv.Count && i < ultimoRegistro; i++, j++)
            {
                dtAux.Rows.Add();
                dtAux.Rows[j]["id"] = dv[i].Row["id"];
                dtAux.Rows[j]["subusuario"] = dv[i].Row["subusuario"];
                dtAux.Rows[j]["texto"] = dv[i].Row["texto"];
                dtAux.Rows[j]["fecha"] = dv[i].Row["fecha"];
                dtAux.Rows[j]["validado"] = dv[i].Row["validado"];
                // aunque estos campos no se mostrarán, si los necesitaremos luego, así que los guardamos
                dtAux.Rows[j]["canal"] = dv[i].Row["canal"];
                dtAux.Rows[j]["programa"] = dv[i].Row["programa"];
                // rellenamos los campos de los que tenemos solo su id con su nombre correspondiente
                dtAux.Rows[j]["canalAux"] = ObtenerNombreCanal(dv[i].Row["canal"].ToString());
                dtAux.Rows[j]["programaAux"] = ObtenerNombrePrograma(dv[i].Row["programa"].ToString());
                if (dv[i].Row["validado"].ToString() == "0")
                {
                    dtAux.Rows[j]["validadoAux"] = "no";
                }
                else
                {
                    dtAux.Rows[j]["validadoAux"] = "si";
                }
            }

            return dtAux;
        }
        
        
        /// <summary>
        /// Modifica un comentario en el DataSet, pero no lo guarda todavía en la Base de Datos
        /// </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ///
        /// <returns>   Devuelve la fila que se ha cambiado. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataRow ModificarComentario()
        {
            int i = 0, posicionDs = 0;
            string idAux = id.ToString();
            DataRow retorno = null;

            // Buscamos la posicion del DataSet donde se encuentra la fila cambiada
            foreach (DataRow fila in ds.Tables["comentario"].Rows)
            {
                if (fila["id"].ToString() == idAux)
                {
                    posicionDs = i;
                }
                i++;
            }

            // Asignamos la fila cambiada al DataSet
            ds.Tables["comentario"].Rows[posicionDs]["texto"] = this.texto;
            ds.Tables["comentario"].Rows[posicionDs]["fecha"] = this.fecha;
            ds.Tables["comentario"].Rows[posicionDs]["subusuario"] = this.subusuario;
            ds.Tables["comentario"].Rows[posicionDs]["validado"] = this.validado;

            return ObtenerTablaComentarios(ds.Tables["comentario"].AsDataView(), posicionDs, posicionDs+1).Rows[0];
        }

        /// <summary>
        /// Guarda en la Base de Datos los cambios introducidos en el DataSet desde que fue creado
        /// </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void ConfirmarCambios()
        {
            try
            {
                CADComentario cad = new CADComentario();
                cad.ModificarComentarios(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Devuelve el formato que la tabla comentario tiene en el
        /// DataSet para ser asignado a un DataTable
        /// </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataTable InicializarPendientes()
        {
            DataTable dtAux = ds.Tables["comentario"].Clone();
            dtAux.Columns.Add("canalAux", System.Type.GetType("System.String"));
            dtAux.Columns.Add("programaAux", System.Type.GetType("System.String"));
            dtAux.Columns.Add("validadoAux", System.Type.GetType("System.String"));
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
            return ds.Tables["cadena"].AsDataView();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Devuelve el id que se corresponde con el nombre del canal que le pasamos. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ///
        /// <param name="nombreCanal">  el nombre del canal. </param>
        ///
        /// <returns>   Un entero con el identificador del canal. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int ObtenerIdCanal(string nombreCanal)
        {
            // Recorremos toda la tabla "cadena" del dataSet
            foreach (DataRowView dr in ds.Tables["cadena"].AsDataView())
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

        /// <summary>
        /// Devuelve una cadena de texto con el nombre del canal que se corresponde
        /// con el identificador que le pasamos por parámetro
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
            foreach (DataRowView dr in ds.Tables["cadena"].AsDataView())
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
        /// <summary>   Devuelve la tabla de programa (id y nombre) en un DataView. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ///
        /// <returns>   Un dataView con todos los programas que tenemos en el DataSet. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataView DevolverProgramas()
        {
            return ds.Tables["programa"].AsDataView();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Devuelve el nombre del programa cuya id le pasamos por parámetro. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ///
        /// <param name="id">   El identificador del programa. </param>
        ///
        /// <returns>   Un string con el nombre del programa. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private string ObtenerNombrePrograma(string id)
        {
            // recorremos toda la tabla programa del DataSet
            foreach (DataRowView dr in ds.Tables["programa"].AsDataView())
            {
                if (dr["id"].ToString() == id)
                {
                    return dr["nombre"].ToString();
                }
            }
            return "";
        }

        /// <summary>
        /// Devuelve una lista de identificadores de programas
        /// El hecho de ser una lista y no solo un entero es porque busca 
        /// programas con un nombre similar al que le pasamos
        /// </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ///
        /// <param name="nombrePrograma">   El nombre del programa a buscar. </param>
        ///
        /// <returns>   Una lista con los identificadores cuyo nombre contiene el nombrePrograma. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public List<int> OtenerIdPrograma(string nombrePrograma)
        {
            List<int> listaIds = new List<int>();

            foreach (DataRowView dr in ds.Tables["programa"].AsDataView())
            {
                if (dr["nombre"].ToString().Contains(nombrePrograma))
                {
                    listaIds.Add(int.Parse(dr["id"].ToString()));
                }
            }
            return listaIds;
        }
    }
}
