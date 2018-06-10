using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace TVO_ComponentesAccesoDatos
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Cad programa. </summary>
    ///
    /// <remarks>   TVO DPAA 2009-2010. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class CADPrograma
    {
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        SqlConnection conexion;
        SqlDataAdapter da;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor por defecto. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public CADPrograma()
        {
            conexion = new global::System.Data.SqlClient.SqlConnection();
            conexion.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TEVEO"].ConnectionString;

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   INSERTAR: Inserta un programa nuevo. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="CADException"> Thrown when cad. </exception>
        ///
        /// <param name="id_cad">       id de cadena. </param>
        /// <param name="id_tem">       id de temática. </param>
        /// <param name="id_calif">     id de calificación. </param>
        /// <param name="nom">          nombre del programa. </param>
        /// <param name="desc">         descripción. </param>
        /// <param name="activ">        activo. </param>
        /// <param name="Esnovedad">    esnovedad. </param>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int BD_insertarPrograma(int id_cad, int id_tem, int id_calif, string nom, string desc, int activ, int Esnovedad)
        {
            string insertar = "";
            int insertadas = 0;

            try
            {
                conexion.Open();
                insertar = "insert into programa (cadena, nombre, descripcion, tematica, calificacion, novedad, activo) values ('" + id_cad.ToString() + "','" + nom.ToString() + "','" + desc.ToString() + "','" + id_tem.ToString() + "','" + id_calif.ToString() + "','" + Esnovedad.ToString() + "','" + activ.ToString() + "')";
                SqlCommand com = new SqlCommand(insertar, conexion);
                insertadas = com.ExecuteNonQuery();
            }
            catch (SqlException sqlex)
            {
                throw new CADException("Excepción de BD. ", sqlex);
            }
            finally
            {
                conexion.Close();
            }
            return insertadas;         
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   BUSCAR: Busca en los programas todos los que cumplan las condiciones de búsqueda. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="CADException"> Thrown when cad. </exception>
        ///
        /// <param name="nombrePrograma">   The nombre programa. </param>
        /// <param name="id_tem">           The identifier tem. </param>
        /// <param name="id_calif">         The identifier calif. </param>
        /// <param name="id_cad">           The identifier cad. </param>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataSet buscarProgramaBD(string nombrePrograma, int id_tem, int id_calif, int id_cad)
        {
              DataSet dsResultadoBusqueda = new DataSet();
              string buscar="";
              string Sselect = "cadena.id AS idCadena, cadena.nombre AS nomCadena, programa.id AS idProg, programa.nombre AS nomProg, programa.activo AS actProg, programa.novedad AS novProg, programa.descripcion AS descProg,calif_edad.id AS idCalif, calif_edad.nombre AS nomCalif, tematica.id AS idTematica,tematica.nombre AS nomTematica";
              
            buscar+="SELECT " + Sselect + " FROM cadena INNER JOIN programa ON cadena.id = programa.cadena INNER JOIN calif_edad ON programa.calificacion = calif_edad.id INNER JOIN tematica ON programa.tematica = tematica.id";

            if (nombrePrograma != "" || id_tem != -1 || id_calif != -1 || id_cad != -1)
            {
                buscar += " WHERE (1=1)";
                if (nombrePrograma != "")
                    buscar += " and programa.nombre like '%" + nombrePrograma + "%'";
                
                if (id_tem!=-1)
                    buscar += " and tematica='" + id_tem + "'";
                
                if(id_calif!=-1)
                    buscar += " and programa.calificacion='" + id_calif + "'";
                
                if(id_cad!=-1)
                    buscar += " and programa.cadena='" + id_cad + "'";

            }
           try
            {
                SqlDataAdapter sqlAdaptador = new SqlDataAdapter(buscar, conexion);
                sqlAdaptador.Fill(dsResultadoBusqueda, "Programas");
            }
            catch (SqlException sqlex)
            {
                throw new CADException("Excepción de BD. ", sqlex);
            }

            return dsResultadoBusqueda;
        }

        //nombrePrograma

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   MODIFICAR: Modifica los datos de un programa. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="CADException"> Thrown when cad. </exception>
        ///
        /// <param name="idP">      The identifier p. </param>
        /// <param name="id_cad">   The identifier cad. </param>
        /// <param name="id_tem">   The identifier tem. </param>
        /// <param name="id_calif"> The identifier calif. </param>
        /// <param name="nom">      The nom. </param>
        /// <param name="desc">     The description. </param>
        /// <param name="activ">    The activ. </param>
        /// <param name="nuevo">    The nuevo. </param>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int modificarProgramaBD(int idP, int id_cad, int id_tem, int id_calif, string nom, string desc, int activ, int nuevo)
        {
            int modificadas = 0;
            string modificar = "";
            try
            {
                conexion.Open();
                modificar = "UPDATE programa SET cadena='" + id_cad.ToString() + "' ,tematica='" + id_tem.ToString() + "' ,calificacion='" + id_calif.ToString() + "' ,nombre='" + nom + "',descripcion='" + desc + "' ,activo='" + activ.ToString() + "' ,novedad='" + nuevo.ToString() + "' WHERE programa.id = '" + idP.ToString() + "'";

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
        /// <summary>   ELIMINAR: Elimina toda la información sobre un programa de la BD. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="CADException"> Thrown when cad. </exception>
        ///
        /// <param name="id">   The identifier. </param>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int eliminarProgramaBD(int id)
        {
            int eliminadas = 0;
            string eliminar = "delete from programa where programa.id = '" + id.ToString() + "'";

            try
            {
                conexion.Open();
                SqlCommand com = new SqlCommand(eliminar, conexion);
                eliminadas = com.ExecuteNonQuery();

            }
            catch (SqlException sqlex)
            {
                throw new CADException("Excepción de BD. ", sqlex);
            }
            finally
            {
                if (conexion != null)
                    conexion.Close();
            }

            return eliminadas;
        }

        //MÉTODOS AUXILIARES-----------------------------

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Obtiene la id de un programa a partir del nombre. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="CADException"> Thrown when cad. </exception>
        ///
        /// <param name="nom">  The nom. </param>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string ObtenerIdPrograma(string nom)
        {
            string id = "";
            string idPrograma = "";

            try
            {
                //Modo Conectado
                conexion.Open();

                id = "select id from programa where nombre = '" + nom + "'";

                SqlCommand com = new SqlCommand(id, conexion);
                SqlDataReader dr = com.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        idPrograma = Convert.ToString(dr["id"]);
                    }
                }
                dr.Close();
                // idPrograma = (string)com.ExecuteScalar();
            }
            catch (SqlException exsql)
            {

                throw new CADException("Excepción de BD.", exsql);
            }
            finally
            {
                conexion.Close();
            }

            return idPrograma;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Obtiene nombre del programa a partir de la id. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="CADException"> Thrown when cad. </exception>
        ///
        /// <param name="id">   The identifier. </param>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string ObtenerNombrePrograma(string id)
        {
            string nom = "";
            string nomPrograma = "";

            try
            {
                //Modo Conectado
                conexion.Open();

                nom = "select nombre from programa where id_programa = '" + id + "'";

                SqlCommand com = new SqlCommand(id, conexion);

                nomPrograma = (string)com.ExecuteScalar();
            }
            catch (SqlException exsql)
            {

                throw new CADException("Excepción de BD.", exsql);
            }


            return nomPrograma;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Actualizar critica. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="Exception">    Thrown when exception. </exception>
        ///
        /// <param name="ds">   The ds. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        //-----------------------------MÉTODOS AUXILIARES
        public void ActualizarCritica(DataSet ds)
        {
            try
            {

                string sentencia = "SELECT programa.id, cadena, nombre, descripcion, tematica, calificacion, novedad, moderador, critica, fecha_critica";
                sentencia += " FROM programa WHERE activo=1;";
                SqlDataAdapter da = new SqlDataAdapter(sentencia, conexion);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.Update(ds, "programa");
            }
            catch (SqlException ex)
            {
                Exception e = new Exception("Se ha producido un problema con la conexión a la base de datos\n La aplicación no puede continuar.\n");
                throw (e);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Obtener programas activos. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="Exception">    Thrown when exception. </exception>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataSet ObtenerProgramasActivos()
        {
            DataSet ds = new DataSet();
            try
            {

                string sentencia = "SELECT programa.id, cadena, nombre, descripcion, tematica, calificacion, novedad, moderador, critica, fecha_critica";
                sentencia += " FROM programa WHERE activo=1;";

                SqlDataAdapter da = new SqlDataAdapter(sentencia, conexion);

                da.Fill(ds, "programa");

                // añadimos también la tabla cadena (la usaremos para las búsquedas)
                sentencia = "SELECT cadena.id, nombre";
                sentencia += " FROM cadena;";
                da = new SqlDataAdapter(sentencia, conexion);
                da.Fill(ds, "cadena");

                // también la de tematica
                sentencia = "SELECT tematica.id, nombre";
                sentencia += " FROM tematica;";
                da = new SqlDataAdapter(sentencia, conexion);
                da.Fill(ds, "tematica");

                // y la de calificacion edad
                sentencia = "SELECT calif_edad.id, nombre";
                sentencia += " FROM calif_edad;";
                da = new SqlDataAdapter(sentencia, conexion);
                da.Fill(ds, "calificacion");
            }
            catch (SqlException ex)
            {
                Exception e = new Exception("Se ha producido un problema con la conexión a la base de datos\n La aplicación no puede continuar.\n");
                throw (e);
            }
            return ds;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Obtener programas de cadena bd. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="CADException"> Thrown when cad. </exception>
        ///
        /// <param name="idCadena"> The identifier cadena. </param>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataSet ObtenerProgramasDeCadenaBD(string idCadena)
        {
            CADCadena cadena = new CADCadena();
            DataSet ds = new DataSet();
            DataTable tabla = new DataTable();
            string sql = "Select id,nombre from programa where cadena = '" + idCadena + "'";

            try
            {
                SqlDataAdapter adaptador = new SqlDataAdapter(sql, conexion);

                adaptador.Fill(ds, "programa");
            }
            catch (SqlException exsql)
            {

                throw new CADException("Excepción de BD.", exsql);
            }

            return ds;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   BUSCAR: Busca en los programas todos los que cumplan las condiciones de búsqueda. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="CADException"> Thrown when cad. </exception>
        ///
        /// <param name="textoBusqRap"> The texto busq rap. </param>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataSet buscarProgramaBD(string textoBusqRap)
        {
            DataSet dsResultadoBusqueda = new DataSet();
            string buscar = "";
            string Sselect = "cadena.id AS idCadena, cadena.nombre AS nomCadena, programa.id AS idProg, programa.nombre AS nomProg, programa.activo AS actProg, programa.novedad AS novProg, programa.descripcion AS descProg,calif_edad.id AS idCalif, calif_edad.nombre AS nomCalif, tematica.id AS idTematica,tematica.nombre AS nomTematica";

            buscar += "SELECT " + Sselect + " FROM cadena INNER JOIN programa ON cadena.id = programa.cadena INNER JOIN calif_edad ON programa.calificacion = calif_edad.id INNER JOIN tematica ON programa.tematica = tematica.id";
            buscar += " WHERE programa.nombre like '%" + textoBusqRap + "%' or tematica.nombre like '%" + textoBusqRap + "%' or cadena.nombre like '%" + textoBusqRap + "%' or calif_edad.nombre like '%" + textoBusqRap + "%' or programa.descripcion like '%" + textoBusqRap + "%'";

            try
            {
                SqlDataAdapter sqlAdaptador = new SqlDataAdapter(buscar, conexion);
                sqlAdaptador.Fill(dsResultadoBusqueda, "Programas");
            }
            catch (SqlException sqlex)
            {
                throw new CADException("Excepción de BD. ", sqlex);
            }

            return dsResultadoBusqueda;
        }

        public int BD_existePrograma(string prog, int id_cadena)
        {
            string sql = "";
            int cuenta = 0;

            try
            {
                //Modo Conectado
                conexion.Open();

                sql = "select count(id) as n from programa where nombre = '" + prog + "' and cadena = " + id_cadena;

                SqlCommand com = new SqlCommand(sql, conexion);
                SqlDataReader dr = com.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        cuenta = Convert.ToInt32(dr["n"]);
                    }
                }
                dr.Close();

            }
            catch (SqlException exsql)
            {

                throw new CADException("Excepción de BD.", exsql);
            }
            finally
            {
                conexion.Close();
            }

            return cuenta;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Obtener tamaño de la consulta a la bd. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="CADException"> Thrown when cad. </exception>
        ///
        /// <param name="nombre">           The nombre. </param>
        /// <param name="id_tematica">      The identifier tematica. </param>
        /// <param name="id_calificacion">  The identifier calificacion. </param>
        /// <param name="id_cadena">        The identifier cadena. </param>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int obtenerTamanyoBD(string nombre, int id_tematica, int id_calificacion, int id_cadena)
        {
            string buscar = "";
            int totalCadenas = 0;
            //abro conexión
            conexion.Open();
            string Sselect = "cadena.id AS idCadena, cadena.nombre AS nomCadena, programa.id AS idProg, programa.nombre AS nomProg, programa.activo AS actProg, programa.novedad AS novProg, programa.descripcion AS descProg,calif_edad.id AS idCalif, calif_edad.nombre AS nomCalif, tematica.id AS idTematica,tematica.nombre AS nomTematica";
              
            buscar+="SELECT count(programa.id) AS numProgramas FROM cadena INNER JOIN programa ON cadena.id = programa.cadena INNER JOIN calif_edad ON programa.calificacion = calif_edad.id INNER JOIN tematica ON programa.tematica = tematica.id";

            if (nombre != "" || id_tematica != -1 || id_calificacion != -1 || id_cadena != -1)
            {
                buscar += " WHERE (1=1)";
                if (nombre != "")
                    buscar += " and programa.nombre like '%" + nombre + "%'";

                if (id_tematica != -1)
                    buscar += " and tematica='" + id_tematica + "'";

                if (id_calificacion != -1)
                    buscar += " and programa.calificacion='" + id_calificacion + "'";

                if (id_cadena != -1)
                    buscar += " and programa.cadena='" + id_cadena + "'";
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
        /// <summary>   BUSCAR: Busca en los programas todos los que cumplan las condiciones de búsqueda. </summary>
        ///Sobrecargado para paginar.
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="CADException"> Thrown when cad. </exception>
        ///
        /// <param name="nombre">           The nombre. </param>
        /// <param name="id_tematica">      The identifier tematica. </param>
        /// <param name="id_calificacion">  The identifier calificacion. </param>
        /// <param name="id_cadena">        The identifier cadena. </param>
        /// <param name="actRegistro">      The act registro. </param>
        /// <param name="numPaginas">       Number of paginas. </param>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataSet buscarProgramaBD(string nombre, int id_tematica, int id_calificacion, int id_cadena, int actRegistro, int numPaginas)
        {
            DataSet dsResultadoBusqueda = new DataSet();
            string buscar = "";
            string Sselect = "cadena.id AS idCadena, cadena.nombre AS nomCadena, programa.id AS idProg, programa.nombre AS nomProg, programa.activo AS actProg, programa.novedad AS novProg, programa.descripcion AS descProg,calif_edad.id AS idCalif, calif_edad.nombre AS nomCalif, tematica.id AS idTematica,tematica.nombre AS nomTematica";

            buscar += "SELECT " + Sselect + " FROM cadena INNER JOIN programa ON cadena.id = programa.cadena INNER JOIN calif_edad ON programa.calificacion = calif_edad.id INNER JOIN tematica ON programa.tematica = tematica.id";

            if (nombre != "" || id_tematica != -1 || id_calificacion != -1 || id_cadena != -1)
            {
                buscar += " WHERE (1=1)";
                if (nombre != "")
                    buscar += " and programa.nombre like '%" + nombre + "%'";

                if (id_tematica != -1)
                    buscar += " and tematica='" + id_tematica + "'";

                if (id_calificacion != -1)
                    buscar += " and programa.calificacion='" + id_calificacion + "'";

                if (id_cadena != -1)
                    buscar += " and programa.cadena='" + id_cadena + "'";

            }
            try
            {
                SqlDataAdapter sqlAdaptador = new SqlDataAdapter(buscar, conexion);
                sqlAdaptador.Fill(dsResultadoBusqueda,actRegistro - 1, numPaginas, "Programas");
            }
            catch (SqlException sqlex)
            {
                throw new CADException("Excepción de BD. ", sqlex);
            }

            return dsResultadoBusqueda;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Obtener tamaño de la consulta de la bd en la búsqueda rápida. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="CADException"> Thrown when cad. </exception>
        ///
        /// <param name="busquedaRap">  The busqueda rap. </param>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int obtenerTamanyoBD(string busquedaRap)
        {
            string buscar = "";
            int totalProgramas = 0;
            //abro conexión
            conexion.Open();

            buscar += "SELECT count(programa.id) AS numProgramas FROM cadena INNER JOIN programa ON cadena.id = programa.cadena INNER JOIN calif_edad ON programa.calificacion = calif_edad.id INNER JOIN tematica ON programa.tematica = tematica.id";
            buscar += " WHERE programa.nombre like '%" + busquedaRap + "%' or tematica.nombre like '%" + busquedaRap + "%' or cadena.nombre like '%" + busquedaRap + "%' or calif_edad.nombre like '%" + busquedaRap + "%' or programa.descripcion like '%" + busquedaRap + "%'";
            try
            {
                SqlCommand com = new SqlCommand(buscar, conexion);
                totalProgramas = (int)com.ExecuteScalar();
            }
            catch (SqlException sqlex)
            {
                throw new CADException("Excepción de BD. ", sqlex);
            }
            finally
            {
                conexion.Close();
            }

            return totalProgramas;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   BUSCAR: Busca en los programas todos los que cumplan las condiciones de búsqueda. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="CADException"> Thrown when cad. </exception>
        ///
        /// <param name="textoBusqRap"> The texto busq rap. </param>
        /// <param name="actRegistro">  The act registro. </param>
        /// <param name="numPaginas">   Number of paginas. </param>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataSet buscarProgramaBD(string textoBusqRap, int actRegistro, int numPaginas)
        {
            string buscar = "";
            DataSet dsResultadoBusqueda = new DataSet();

            string Sselect = "cadena.id AS idCadena, cadena.nombre AS nomCadena, programa.id AS idProg, programa.nombre AS nomProg, programa.activo AS actProg, programa.novedad AS novProg, programa.descripcion AS descProg,calif_edad.id AS idCalif, calif_edad.nombre AS nomCalif, tematica.id AS idTematica,tematica.nombre AS nomTematica";

            buscar += "SELECT " + Sselect + " FROM cadena INNER JOIN programa ON cadena.id = programa.cadena INNER JOIN calif_edad ON programa.calificacion = calif_edad.id INNER JOIN tematica ON programa.tematica = tematica.id";
            buscar += " WHERE programa.nombre like '%" + textoBusqRap + "%' or tematica.nombre like '%" + textoBusqRap + "%' or cadena.nombre like '%" + textoBusqRap + "%' or calif_edad.nombre like '%" + textoBusqRap + "%' or programa.descripcion like '%" + textoBusqRap + "%'";

            try
            {
                SqlDataAdapter sqlAdaptador = new SqlDataAdapter(buscar, conexion);
                sqlAdaptador.Fill(dsResultadoBusqueda, actRegistro - 1, numPaginas, "Programas");
            }
            catch (SqlException sqlex)
            {
                throw new CADException("Excepción de BD. ", sqlex);
            }

            return dsResultadoBusqueda;
        }
    }
}
