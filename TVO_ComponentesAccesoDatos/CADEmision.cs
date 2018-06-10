using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace TVO_ComponentesAccesoDatos
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Cad emision. </summary>
    ///
    /// <remarks>   TVO DPAA 2009-2010. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class CADEmision
    {
        SqlConnection conexionBD;
        DataSet dsEmisiones;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor por defecto que crea la conexión con la base de datos. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public CADEmision()
        {
            conexionBD = new global::System.Data.SqlClient.SqlConnection();

            conexionBD.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TEVEO"].ConnectionString;

            dsEmisiones = new DataSet();
        }

        //CREATE

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Inserta en la bd una nueva emisión. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="CADException"> Thrown when cad. </exception>
        ///
        /// <param name="id_cadena">    The identifier cadena. </param>
        /// <param name="id_programa">  The identifier programa. </param>
        /// <param name="fechaHora">    Date/Time of the fecha hora. </param>
        /// <param name="duracion">     The duracion. </param>
        ///
        /// <returns>   true if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool insertarEmisionBD(int id_cadena, int id_programa, DateTime fechaHora, int duracion)
        {
            int filas = 0;
            bool insertado = false;
            string sql_insertar = "";

            try
            {
                conexionBD.Open();
                sql_insertar = "insert into emision (cadena,programa,fechaHora,duracion) values ('" + id_cadena + "','" + id_programa + "','" + fechaHora + "','" + duracion + "')";
                SqlCommand com = new SqlCommand(sql_insertar, conexionBD);
                filas = com.ExecuteNonQuery();
                if (filas == 1)
                    insertado = true;

            }
            catch (SqlException sqlex)
            {
                throw new CADException("Excepción de BD. ", sqlex);
            }
            finally
            {
                if (conexionBD != null)
                    conexionBD.Close();
            }

            return insertado;
        }

        //READ

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Método para recuperar emisiones según el filtrado. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="CADException"> Thrown when cad. </exception>
        ///
        /// <param name="id_cadena">        The identifier cadena. </param>
        /// <param name="id_programa">      The identifier programa. </param>
        /// <param name="fechaHoraInicio">  Date/Time of the fecha hora inicio. </param>
        /// <param name="duracion">         The duracion. </param>
        /// <param name="compararMinutos">  The comparar minutos. </param>
        ///
        /// <returns>   . </returns>
        ///
        /// ### <param name="cadena">   . </param>
        /// ### <param name="programa"> . </param>
        /// ### <param name="detalle">  . </param>
        /// ### <param name="fecha">    . </param>
        /// ### <param name="hora">     . </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataSet obtenerEmisionesBD(int id_cadena, int id_programa, DateTime fechaHoraInicio, int duracion, int compararMinutos)
        {
                //Comando sql para ejecutar sobre la base de datos
                string comandoSQL = "SELECT emision.id_emision AS IdEmision, emision.duracion AS Duracion, emision.fechaHora AS FechaHora, cadena.nombre AS Cadena, programa.nombre AS Programa, programa.critica AS Critica FROM emision INNER JOIN programa ON emision.programa = programa.id AND emision.cadena= programa.cadena INNER JOIN cadena ON programa.cadena = cadena.id where 1=1";

                //comprobar que condiciones se le añaden al select
                if (id_cadena != -1) //Se quiere buscar una cadena
                {
                    comandoSQL += " and emision.cadena = " + "'" + id_cadena + "'";
                }

                if (id_programa != -1) //Se quiere buscar un programa
                {
                    comandoSQL += " and emision.programa = " + "'" + id_programa + "'";
                }

                DateTime fechaSiguiente = fechaHoraInicio.AddDays(1);
                comandoSQL += " and fechaHora >= '" + fechaHoraInicio.ToString() + "' and fechaHora < '" + fechaSiguiente.ToString() + "'";

                //compararMinutos->0 Menor que, 1 Igual, 2 Mayor que
                if (compararMinutos == 0)
                    comandoSQL += " and duracion < " + "'" + duracion.ToString() + "'";
                if (compararMinutos == 1)
                    comandoSQL += " and duracion = " + "'" + duracion.ToString() + "'";
                if (compararMinutos == 2)
                    comandoSQL += " and duracion > " + "'" + duracion.ToString() + "'";

                comandoSQL += " ORDER BY emision.fechaHora";
                try
                {
                    SqlDataAdapter sqlAdaptador = new SqlDataAdapter(comandoSQL, conexionBD);

                    sqlAdaptador.Fill(dsEmisiones, "emision");

                }
                catch (SqlException sqlex)
                {
                    throw new CADException("Excepción de BD. ", sqlex);
                }
                finally
                {
                    if (conexionBD != null)
                        conexionBD.Close(); // Se asegura de cerrar la conexión. 
                }

            return dsEmisiones;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Método para recuperar emisiones según el filtrado. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="CADException"> Thrown when cad. </exception>
        ///
        /// <param name="id_cadena">        The identifier cadena. </param>
        /// <param name="id_programa">      The identifier programa. </param>
        /// <param name="fechaHoraInicio">  Date/Time of the fecha hora inicio. </param>
        /// <param name="duracion">         The duracion. </param>
        /// <param name="compararMinutos">  The comparar minutos. </param>
        /// <param name="desde">            The desde. </param>
        /// <param name="cantidad">         The cantidad. </param>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataSet obtenerEmisionesBD(int id_cadena, int id_programa, DateTime fechaHoraInicio, int duracion, int compararMinutos, int desde, int cantidad)
        {
            //Comando sql para ejecutar sobre la base de datos
            string comandoSQL = "SELECT emision.id_emision AS IdEmision, emision.duracion AS Duracion, emision.fechaHora AS FechaHora, cadena.nombre AS Cadena, programa.nombre AS Programa, programa.critica AS Critica FROM emision INNER JOIN programa ON emision.programa = programa.id AND emision.cadena= programa.cadena INNER JOIN cadena ON programa.cadena = cadena.id where 1=1";

            //comprobar que condiciones se le añaden al select
            if (id_cadena != -1) //Se quiere buscar una cadena
            {
                comandoSQL += " and emision.cadena = " + "'" + id_cadena + "'";
            }

            if (id_programa != -1) //Se quiere buscar un programa
            {
                comandoSQL += " and emision.programa = " + "'" + id_programa + "'";
            }

            DateTime fechaSiguiente = fechaHoraInicio.AddDays(1);
            comandoSQL += " and fechaHora >= '" + fechaHoraInicio.ToString() + "' and fechaHora < '" + fechaSiguiente.ToString() + "'";

            //compararMinutos->0 Menor que, 1 Igual, 2 Mayor que
            if (compararMinutos == 0)
                comandoSQL += " and duracion < " + "'" + duracion.ToString() + "'";
            if (compararMinutos == 1)
                comandoSQL += " and duracion = " + "'" + duracion.ToString() + "'";
            if (compararMinutos == 2)
                comandoSQL += " and duracion > " + "'" + duracion.ToString() + "'";

            comandoSQL += " ORDER BY emision.fechaHora";
            try
            {
                SqlDataAdapter sqlAdaptador = new SqlDataAdapter(comandoSQL, conexionBD);

                sqlAdaptador.Fill(dsEmisiones,desde - 1, cantidad, "emision");

            }
            catch (SqlException sqlex)
            {
                throw new CADException("Excepción de BD. ", sqlex);
            }
            finally
            {
                if (conexionBD != null)
                    conexionBD.Close(); // Se asegura de cerrar la conexión. 
            }

            return dsEmisiones;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Bd obtener tamanyo. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="CADException"> Thrown when cad. </exception>
        ///
        /// <param name="id_cadena">        The identifier cadena. </param>
        /// <param name="id_programa">      The identifier programa. </param>
        /// <param name="fechaHoraInicio">  Date/Time of the fecha hora inicio. </param>
        /// <param name="duracion">         The duracion. </param>
        /// <param name="compararMinutos">  The comparar minutos. </param>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataSet BD_obtenerTamanyo(int id_cadena, int id_programa, DateTime fechaHoraInicio, int duracion, int compararMinutos)
        {
            //Comando sql para ejecutar sobre la base de datos
            string comandoSQL = "select count(id_emision) AS total FROM emision INNER JOIN programa ON emision.programa = programa.id AND emision.cadena= programa.cadena INNER JOIN cadena ON programa.cadena = cadena.id where 1=1";

            //comprobar que condiciones se le añaden al select
            if (id_cadena != -1) //Se quiere buscar una cadena
            {
                comandoSQL += " and emision.cadena = " + "'" + id_cadena + "'";
            }

            if (id_programa != -1) //Se quiere buscar un programa
            {
                comandoSQL += " and emision.programa = " + "'" + id_programa + "'";
            }

            DateTime fechaSiguiente = fechaHoraInicio.AddDays(1);
            comandoSQL += " and fechaHora >= '" + fechaHoraInicio.ToString() + "' and fechaHora < '" + fechaSiguiente.ToString() + "'";

            //compararMinutos->0 Menor que, 1 Igual, 2 Mayor que
            if (compararMinutos == 0)
                comandoSQL += " and duracion < " + "'" + duracion.ToString() + "'";
            if (compararMinutos == 1)
                comandoSQL += " and duracion = " + "'" + duracion.ToString() + "'";
            if (compararMinutos == 2)
                comandoSQL += " and duracion > " + "'" + duracion.ToString() + "'";

            try
            {
                SqlDataAdapter sqlAdaptador = new SqlDataAdapter(comandoSQL, conexionBD);

                sqlAdaptador.Fill(dsEmisiones, "Total");

            }
            catch (SqlException sqlex)
            {
                throw new CADException("Excepción de BD. ", sqlex);
            }
            finally
            {
                if (conexionBD != null)
                    conexionBD.Close(); // Se asegura de cerrar la conexión. 
            }

            return dsEmisiones;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Modificar emision bd. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="CADException"> Thrown when cad. </exception>
        ///
        /// <param name="id_emision">       The identifier emision. </param>
        /// <param name="id_cadena">        The identifier cadena. </param>
        /// <param name="id_programa">      The identifier programa. </param>
        /// <param name="fechaHoraInicio">  Date/Time of the fecha hora inicio. </param>
        /// <param name="minutos">          The minutos. </param>
        ///
        /// <returns>   true if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        //UPDATE
        public bool modificarEmisionBD(int id_emision,int id_cadena, int id_programa, DateTime fechaHoraInicio, int minutos)
        {
            bool modificado = false;
            int filasActualizadas = -1;
            string sqlMod = "";
            try
            {
                conexionBD.Open();
                sqlMod = "UPDATE emision SET fechaHora='" + fechaHoraInicio.ToString() + "'" + 
                        ",duracion='" + minutos + "'" +" WHERE id_emision = '" + id_emision + "'";

                SqlCommand com = new SqlCommand(sqlMod, conexionBD);
                filasActualizadas = com.ExecuteNonQuery();

            }
            catch (SqlException sqlex)
            {
                throw new CADException("Excepción de BD. ", sqlex);
            }
            finally
            {
                conexionBD.Close();
            }

            if (filasActualizadas == 1)
                modificado = true;

            return modificado;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Eliminar emision bd. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="CADException"> Thrown when cad. </exception>
        ///
        /// <param name="id_emision">   The identifier emision. </param>
        ///
        /// <returns>   true if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        //DELETE
        public bool eliminarEmisionBD(int id_emision)
        {
            bool eliminado = false;
            string sqlEliminar = "";
            int eliminados = -1;

            try
            {
                conexionBD.Open();
                sqlEliminar = "DELETE FROM emision WHERE id_emision = '" + id_emision.ToString() + "'";

                SqlCommand com = new SqlCommand(sqlEliminar, conexionBD);
                eliminados = com.ExecuteNonQuery();

                if (eliminados == 1)
                    eliminado = true;
            }
            catch (SqlException sqlex)
            {
                throw new CADException("Excepción de BD. ", sqlex);
            }
            finally
            {
                conexionBD.Close();
            }

            return eliminado;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Franja horaria libre bd. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="CADException"> Thrown when cad. </exception>
        ///
        /// <param name="id_cadena">        The identifier cadena. </param>
        /// <param name="fechaHoraInicio">  Date/Time of the fecha hora inicio. </param>
        /// <param name="duracion">         The duracion. </param>
        ///
        /// <returns>   true if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool FranjaHorariaLibreBD(int id_cadena,DateTime fechaHoraInicio, int duracion)
        {
            bool libre = true;
            DateTime fAnt = new DateTime();
            DateTime fTope = new DateTime();
            int durac = 0;
            try
            {
                fTope = fechaHoraInicio.AddMinutes(duracion);

                conexionBD.Open();

                SqlCommand com = new SqlCommand("select fechaHora, duracion from emision where cadena = " + id_cadena.ToString() + " and fechaHora < '" + fTope.ToString() + "'", conexionBD);
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read() && libre)
                {
                    fAnt = (DateTime)dr["fechaHora"];
                    durac = (int)dr["duracion"];

                    fAnt = fAnt.AddMinutes(durac);

                    if (fAnt >= fechaHoraInicio)
                        libre = false;
                }
                dr.Close();
            }
            catch (SqlException sqex) 
            {
                throw new CADException("Error en BD.",sqex); 
            }
            finally
            {
                if(conexionBD!=null)
                    conexionBD.Close();
            }
            return libre;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Obtiene una lista de cadenas. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="CADException"> Thrown when cad. </exception>
        ///
        /// <param name="fechaElegida"> Date/Time of the fecha elegida. </param>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataSet ObtenerCadenasActualesBD(DateTime fechaElegida)
        {
            DataSet dsCadenas = new DataSet();

            try
            {
                DateTime fechaSiguiente = fechaElegida.AddDays(1);

                string comandoSQL = "SELECT DISTINCT emision.cadena AS id, cadena.nombre FROM emision INNER JOIN cadena ON emision.cadena = cadena.id";
                comandoSQL += " where emision.fechaHora >= '" + fechaElegida.ToString() + "' and emision.fechaHora < '" + fechaSiguiente.ToString() + "'"; comandoSQL += " ORDER BY cadena.nombre";
                SqlDataAdapter adaptador = new SqlDataAdapter(comandoSQL, conexionBD);

                adaptador.Fill(dsCadenas, "TCadenas");
            }
            catch (SqlException exsql)
            {
                throw new CADException("Excepción de BD.", exsql);
            }

            return dsCadenas;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Obtener programas de cadena actuales bd. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="CADException"> Thrown when cad. </exception>
        ///
        /// <param name="idCadena">     The identifier cadena. </param>
        /// <param name="fechaElegida"> Date/Time of the fecha elegida. </param>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataSet ObtenerProgramasDeCadenaActualesBD(string idCadena, DateTime fechaElegida)
        {
            CADCadena cadena = new CADCadena();
            DataSet ds = new DataSet();
            DataTable tabla = new DataTable();

            DateTime fechaSiguiente = fechaElegida.AddDays(1);
            string sql = "SELECT emision.programa AS id, programa.nombre, emision.fechaHora FROM emision INNER JOIN programa ON emision.programa = programa.id AND emision.cadena = programa.cadena WHERE (emision.fechaHora >= '" + fechaElegida.ToString() + "') AND (emision.fechaHora < '" + fechaSiguiente.ToString() + "') AND emision.cadena = " + idCadena + " ORDER BY programa.nombre";

            try
            {
                SqlDataAdapter adaptador = new SqlDataAdapter(sql, conexionBD);

                adaptador.Fill(ds, "programa");
            }
            catch (SqlException exsql)
            {

                throw new CADException("Excepción de BD.", exsql);
            }

            return ds;
        }
    }
}

