using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

////////////////////////////////////////////////////////////////////////////////////////////////////
// namespace: TVO_ComponentesAccesoDatos
//
// summary:	Espacion de nombre TVO_ComponentesAccesoDatos.
////////////////////////////////////////////////////////////////////////////////////////////////////

namespace TVO_ComponentesAccesoDatos
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Clase Cad cadena. </summary>
    ///
    /// <remarks>   TVO DPAA 2009-2010. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class CADCadena
    {
        /// <summary> Conexion del CadCadena a la base de datos.  </summary>
        SqlConnection conexion;
        
        /// <summary> SqlDataAdapter del CadCadena.  </summary>
        SqlDataAdapter da;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor por Defecto. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public CADCadena()
        {
            conexion = new global::System.Data.SqlClient.SqlConnection();
            conexion.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TEVEO"].ConnectionString;

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Metodo Bd insertar cadena. Para insertar la Cadena en la base de datos </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="CADException"> Thrown when cad. </exception>
        ///
        /// <param name="nombre">   El nombre de la Cadena. </param>
        /// <param name="tipo">     El tipo de Cadena. </param>
        /// <param name="activo">   true to activo. Indica si esta activa la cadena</param>
        ///
        /// <returns>   Devuelve el numero de inserciones en la BD. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int BD_insertarCadena(string nombre, string tipo, bool activo)
        {
            string insertar = "";
            int insertadas = 0;
            int activaCadena = 0;

            if (activo)
                activaCadena = 1;
            else
                activaCadena = 0;

            try
            {
                conexion.Open();
                insertar = "insert into cadena (nombre,tipo,activo) values ('" + nombre + "','" + tipo + "','" + activaCadena.ToString() + "')";

                SqlCommand com = new SqlCommand(insertar, conexion);
                insertadas = com.ExecuteNonQuery();
            }
            catch (SqlException exsql)
            {
                throw new CADException(exsql.Message, -1);
            }
            finally
            {
                conexion.Close();
            }
            return insertadas;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Método para modificar la BD. Modifica los datos de la Cadena </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="CADException"> Excepción Thrown del cad. </exception>
        ///
        /// <param name="idC">  El identificador de cadena. </param>
        /// <param name="nom">  El nombre de la cadena. </param>
        /// <param name="t">    El tipo de cadena. </param>
        /// <param name="act">  true to act. Indica si esta activa la cadena</param>
        ///
        /// <returns>  Devuelve el numero de cadenas afectadas en la modificacion en la BD. </returns>
        ///
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int modificarCadenaBD(int idC, string nom, string t, bool act)
        {

            int modificadas = 0;
            //string idCadena = ObtenerIdCadena(nom);
            string modificar = "";
            int activaCadena = 0;

            if (act)
                activaCadena = 1;
            else
                activaCadena = 0;

            try
            {
                conexion.Open();
                modificar = "UPDATE cadena SET nombre='" + nom + "'" + ",tipo='" + t + "',activo='" + activaCadena.ToString() + "' WHERE id='" + idC.ToString() + "'";

                SqlCommand com = new SqlCommand(modificar, conexion);
                modificadas = com.ExecuteNonQuery();

            }
            catch (SqlException exsql)
            {
                throw new CADException(exsql.Message, -1);
            }
            finally
            {
                conexion.Close();
            }

            return modificadas;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Método auxiliar utilizado para rellenar el combobox de tipos a partir de 1 cadena. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="CADException"> Excepcion Thrown del cad. </exception>
        ///
        /// <param name="nombreCadena"> El nombre cadena. </param>
        ///
        /// <returns>   Devuelve un dataSet con los tipos de cadenas en la BD. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataSet ObtenerTiposBD(string nombreCadena)
        {
            DataSet dsTipos = new DataSet();
            string obtener = "Select distinct tipo from cadena";

            if (nombreCadena != "")
                obtener += " where nombre like '%" + nombreCadena + "%'";
            try
            {
                SqlDataAdapter sqlAdaptador = new SqlDataAdapter(obtener, conexion);
                sqlAdaptador.Fill(dsTipos);
            }
            catch (SqlException exsql)
            {
                throw new CADException("Excepción de BD.", exsql);
            }


            return dsTipos;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Metodo ObtenerColumnaID. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="CADException"> Excepcion Thrown del cad. </exception>
        ///
        /// <returns>   Devuelve un dataSet con las id's de las cadenas. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataSet ObtenerColumnaID()
        {
            CADCadena cadena = new CADCadena();
            DataSet ds = new DataSet();
            DataTable tabla = new DataTable();

            try
            {
                SqlDataAdapter adaptador = new SqlDataAdapter("Select id from cadena", conexion);

                adaptador.Fill(ds);
            }
            catch (SqlException exsql)
            {

                throw new CADException("Excepción de BD.", exsql);
            }

            return ds;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>  Metodo ObtenerIdCadena
        /// Obtiene el id de una cadena a partir de su nombre, en modo conectado realiza la consulta y
        /// obtendrá una fila y una columna, ExecuteScalar devuelve el elemento de esa posición. 
        /// </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="CADException"> Excepción Thrown when cad. </exception>
        ///
        /// <param name="nombreCadena"> Nombre de la cadena. </param>
        ///
        /// <returns>   Devuelve el id de la cadena en la BD. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string ObtenerIdCadena(string nombreCadena)
        {
            string id = "";
            string idCadena = "";

            try
            {
                //Modo Conectado
                conexion.Open();

                id = "select id from cadena where nombre = " + nombreCadena;

                SqlCommand com = new SqlCommand(id, conexion);

                idCadena = (string)com.ExecuteScalar();
            }
            catch (SqlException exsql)
            {

                throw new CADException("Excepción de BD.", exsql);
            }


            return idCadena;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Metodo ObtenerNombreCadena. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="CADException"> Exceptión Thrown del cad. </exception>
        ///
        /// <param name="id_cad">   The identifier cad. </param>
        ///
        /// <returns>   Devuelve el nombre de la cadena con el id de la BD. </returns>
        ///
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string ObtenerNombreCadena(string id_cad)
        {
            string nombre = "";
            string nomCadena = "";

            try
            {
                //Modo Conectado
                conexion.Open();

                nombre = "select nombre from cadena where id = " + id_cad;

                SqlCommand com = new SqlCommand(nombre, conexion);

                nomCadena = (string)com.ExecuteScalar();
            }
            catch (SqlException sqlex)
            {

                throw new CADException("Excepción de BD.", sqlex);
            }


            return id_cad;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Método para la búsqueda rápida. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="CADException"> Excepción Thrown del cad. </exception>
        ///
        /// <param name="nombreCadena"> El nombre de la cadena. </param>
        /// <param name="tipoCadena">   El tipo de cadena. </param>
        ///
        /// <returns>   Devuelve un DataSet con las cadenas con nombre y tipo requeridos. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataSet buscarCadenaBD(string nombreCadena, string tipoCadena)
        {
            string buscar = "";
            DataSet dsResultadoBusqueda = new DataSet();

            buscar = "select * from cadena";

            if (nombreCadena != "" || (tipoCadena != "" && tipoCadena != "Todos"))
            {
                buscar += " where (1=1)";

                if (nombreCadena != "")
                    buscar += " and nombre like '%" + nombreCadena + "%'";

                if (tipoCadena != "Todos" && tipoCadena != "")
                    buscar += " and tipo='" + tipoCadena + "'";
            }

            try
            {
                SqlDataAdapter sqlAdaptador = new SqlDataAdapter(buscar, conexion);
                sqlAdaptador.Fill(dsResultadoBusqueda, "Cadenas");
            }
            catch (SqlException sqlex)
            {
                throw new CADException("Excepción de BD. ", sqlex);
            }

            return dsResultadoBusqueda;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Metodo Eliminar cadena bd. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="CADException"> Excepcion Thrown when cad. </exception>
        ///
        /// <param name="idC">  El identificador de cadena. </param>
        ///
        /// <returns>   Devuelve el número de cadenas eliminadas en la BD. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int eliminarCadenaBD(int idC)
        {
            int eliminadas = 0;
            //string idCadena = ObtenerIdCadena(nombre);
            string eliminar = "delete from cadena where id='" + idC.ToString() + "'";

            try
            {
                conexion.Open();
                SqlCommand com = new SqlCommand(eliminar, conexion);
                eliminadas = com.ExecuteNonQuery();

            }
            catch (SqlException exsql)
            {
                throw new CADException(exsql.Message, -1);
            }
            finally
            {
                conexion.Close();
            }

            return eliminadas;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Método Obtiene una lista de cadenas. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="CADException"> Excepción Thrown del cad. </exception>
        ///
        /// <returns>   Obtiene un DataSet con las cadenas de la BD. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataSet ObtenerCadenasBD()
        {
            DataSet dsCadenas = new DataSet();

            try
            {
                SqlDataAdapter adaptador = new SqlDataAdapter("Select nombre,id from cadena", conexion);

                adaptador.Fill(dsCadenas, "TCadenas");
            }
            catch (SqlException exsql)
            {
                throw new CADException("Excepción de BD.", exsql);
            }

            return dsCadenas;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Método Obtener tematicas bd. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="CADException"> Excepción Thrown del cad. </exception>
        ///
        /// <returns>   Devuelve un DataSet con las Tematicas que hay en la BD. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataSet ObtenerTematicasBD()
        {
            DataSet dsTematicas = new DataSet();

            try
            {
                SqlDataAdapter adaptador = new SqlDataAdapter("Select nombre,id from tematica", conexion);

                adaptador.Fill(dsTematicas, "TTematicas");
            }
            catch (SqlException exsql)
            {
                throw new CADException("Excepción de BD.", exsql);
            }

            return dsTematicas;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>  Método Obtener calificaciones bd. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="CADException"> Excepcion Thrown del cad. </exception>
        ///
        /// <returns>   Devuelve un DataSet con las Calificaciones que hay en la Base de Datos. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataSet ObtenerCalificacionesBD()
        {
            DataSet dsCalificacion = new DataSet();

            try
            {
                SqlDataAdapter adaptador = new SqlDataAdapter("Select nombre,id from calif_edad", conexion);

                adaptador.Fill(dsCalificacion, "TCalificaciones");
            }
            catch (SqlException exsql)
            {
                throw new CADException("Excepción de BD.", exsql);
            }

            return dsCalificacion;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Método para la búsqueda rápida. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="CADException"> Thrown when cad. </exception>
        ///
        /// <param name="buscRapida">   Parametro de búsqueda Rápida. </param>
        ///
        /// <returns>   Devuelve un DataSet con los resultado de la búsqueda en la BD. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataSet buscarCadenaBD(string buscRapida)
        {
            string buscar = "";
            DataSet dsResultadoBusqueda = new DataSet();

            buscar = "select * from cadena where nombre like '%" + buscRapida + "%' or tipo like '%" + buscRapida + "%'";

            try
            {
                SqlDataAdapter sqlAdaptador = new SqlDataAdapter(buscar, conexion);
                sqlAdaptador.Fill(dsResultadoBusqueda, "Cadenas");
            }
            catch (SqlException sqlex)
            {
                throw new CADException("Excepción de BD. ", sqlex);
            }

            return dsResultadoBusqueda;
        }

        public int BD_existeNombreCadena(string nombre)
        {
            int id = -1;
            string sql = "";

            try
            {
                //Modo Conectado
                conexion.Open();

                sql = "select id from cadena where nombre = '" + nombre + "'";

                SqlCommand com = new SqlCommand(sql, conexion);
                SqlDataReader dr = com.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        id = Convert.ToInt32(dr["id"]);
                    }
                }
                dr.Close();

            }
            catch (SqlException exsql)
            {

                throw new CADException("Excepción de BD. " + exsql.Message, -1);
            }
            finally
            {
                conexion.Close();
            }

            return id;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Método para la búsqueda rápida. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="CADException"> Thrown when cad. </exception>
        ///
        /// <param name="nombreCadena"> El nombre de cadena. </param>
        /// <param name="tipoCadena">   el tipo de cadena. </param>
        /// <param name="actRegistro">  El act registro. </param>
        /// <param name="numPaginas">   Numero de páginas a mostrar. </param>
        ///
        /// <returns>   Devuelve un DataSet con los resultados de la búsqueda Paginados. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataSet buscarCadenaBD(string nombreCadena, string tipoCadena, int actRegistro, int numPaginas)
        {
            string buscar = "";
            DataSet dsResultadoBusqueda = new DataSet();

            buscar = "select * from cadena";

            if (nombreCadena != "" || (tipoCadena != "" && tipoCadena != "Todos"))
            {
                buscar += " where (1=1)";

                if (nombreCadena != "")
                    buscar += " and nombre like '%" + nombreCadena + "%'";

                if (tipoCadena != "Todos" && tipoCadena != "")
                    buscar += " and tipo='" + tipoCadena + "'";
            }

            try
            {
                SqlDataAdapter sqlAdaptador = new SqlDataAdapter(buscar, conexion);
                sqlAdaptador.Fill(dsResultadoBusqueda, actRegistro - 1, numPaginas, "Cadenas");
            }
            catch (SqlException sqlex)
            {
                throw new CADException("Excepción de BD. ", sqlex);
            }

            return dsResultadoBusqueda;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Metodo Obtener tamanyo bd. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="CADException"> Excepcion Thrown when cad. </exception>
        ///
        /// <param name="nombreCadena"> El nombre de la cadena. </param>
        /// <param name="TipoCadena">   El tipo de cadena. </param>
        ///
        /// <returns>  Obtiene el numero de resultados de la búsqueda realizada en la BD. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int obtenerTamanyoBD(string nombreCadena, string TipoCadena)
        {
            string buscar = "";
            int totalCadenas = 0;
            //abro conexión
            conexion.Open();
            buscar = "select count(id) AS numCadenas from cadena";

            if (nombreCadena != "" || (TipoCadena != "" && TipoCadena != "Todos"))
            {
                buscar += " where (1=1)";

                if (nombreCadena != "")
                    buscar += " and nombre like '%" + nombreCadena + "%'";

                if (TipoCadena != "Todos" && TipoCadena != "")
                    buscar += " and tipo='" + TipoCadena + "'";
            }
            try
            {
                SqlCommand com = new SqlCommand(buscar, conexion);
                totalCadenas = (int)com.ExecuteScalar();
            }
            catch (SqlException sqlex)
            {
                throw new CADException("Excepción de BD. ", sqlex);
            }
            finally
            {
                conexion.Close();
            }

            return totalCadenas;

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Método Obtener tamanyo bd. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="CADException"> Excepcion Thrown con cad. </exception>
        ///
        /// <param name="buscRapida">    Parametro de búsqueda. </param>
        ///
        /// <returns>   Devuelve el número de registro de la búsqueda rápida. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int obtenerTamanyoBD(string buscRapida)
        {
            string buscar = "";
            int totalCadenas = 0;
            //abro conexión
            conexion.Open();
            buscar = "select count(cadena.id) AS numCadenas from cadena where nombre like '%" + buscRapida + "%' or tipo like '%" + buscRapida + "%'";
            try
            {
                SqlCommand com = new SqlCommand(buscar, conexion);
                totalCadenas = (int)com.ExecuteScalar();
            }
            catch (SqlException sqlex)
            {
                throw new CADException("Excepción de BD. ", sqlex);
            }
            finally
            {
                conexion.Close();
            }

            return totalCadenas;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Método para la búsqueda rápida. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="CADException"> Thrown when cad. </exception>
        ///
        /// <param name="buscRapida">   The busc rapida. </param>
        /// <param name="actRegistro">  The act registro. </param>
        /// <param name="numPaginas">   Number of paginas. </param>
        ///
        /// <returns>   Devuelve un DataSet con los resultados de la búsqueda rápida con Paginación. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataSet buscarCadenaBD(string buscRapida, int actRegistro, int numPaginas)
        {
            string buscar = "";
            DataSet dsResultadoBusqueda = new DataSet();

            buscar = "select * from cadena where nombre like '%" + buscRapida + "%' or tipo like '%" + buscRapida + "%'";

            try
            {
                SqlDataAdapter sqlAdaptador = new SqlDataAdapter(buscar, conexion);
                sqlAdaptador.Fill(dsResultadoBusqueda, actRegistro - 1, numPaginas, "Cadenas");
            }
            catch (SqlException sqlex)
            {
                throw new CADException("Excepción de BD. ", sqlex);
            }

            return dsResultadoBusqueda;

        }

    }
}

//-------------------------------
