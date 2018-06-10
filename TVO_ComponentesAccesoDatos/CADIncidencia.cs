using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;

namespace TVO_ComponentesAccesoDatos
{
    public class CADIncidencia
    {
        private SqlConnection con;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public CADIncidencia()
        {
            con = new global::System.Data.SqlClient.SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TEVEO"].ConnectionString;
        }

        /// <summary>
        /// Obtiene todas las incidencias que tenemos en la Base de Datos,
        /// se trabajará con ellas en modo no conectado
        /// </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ///
        /// <returns>   Un DataSet con las incidencias. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataSet ObtenerIncidencias()
        {
            DataSet ds = new DataSet();
            try
            {
                if (con == null)
                {
                    con = new global::System.Data.SqlClient.SqlConnection();
                    con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TEVEO"].ConnectionString;
                }
                string sentencia = "SELECT codigo, titular, descripcion, fecha, tecnico, respuesta";
                sentencia += " FROM incidencia;";
                /*string sentencia = "SELECT incidencia.codigo, incidencia.titular, titular.nombre, titular.apellidos, incidencia.descripcion,";
                sentencia += " incidencia.fecha, incidencia.tecnico, incidencia.respuesta";
                sentencia += " FROM incidencia, titular WHERE nif=titular";*/

                SqlDataAdapter da = new SqlDataAdapter(sentencia, con);

                da.Fill(ds, "incidencia");
            }
            catch (SqlException ex)
            {
                Exception e = new Exception("Se ha producido un problema con la conexión a la base de datos\n La aplicación no puede continuar.\n");
                throw (e);
            }
            return ds;
        }

        /// <summary>
        /// Modifica la BD con las filas modificadas en el DS con respecto al método donde este se obtenía
        /// </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ///
        /// <param name="ds">   DataSet con los nuevos datos. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void ResponderIncidencia(DataSet ds)
        {
            try
            {
                if (con == null)
                {
                    con = new global::System.Data.SqlClient.SqlConnection();
                    con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TEVEO"].ConnectionString;
                }
                string sentencia = "SELECT codigo, titular, descripcion, fecha, tecnico, respuesta";
                sentencia += " FROM incidencia;";
                SqlDataAdapter da = new SqlDataAdapter(sentencia, con);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.Update(ds, "incidencia");
            }
            catch (SqlException ex)
            {
                Exception e = new Exception("Se ha producido un problema con la conexión a la base de datos\n La aplicación no puede continuar.\n");
                throw (e);
            }
        }
    }
}
