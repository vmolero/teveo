using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.Configuration;

namespace TVO_ComponentesAccesoDatos
{
    public class CADComentario
    {
        private SqlConnection con;

        public CADComentario()
        {
            con = new global::System.Data.SqlClient.SqlConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TEVEO"].ConnectionString;
        }

        /// <summary>
        /// Obtiene todos los comentarios que tenemos en la Base de Datos,
        /// se trabajará con ellos en modo no conectado
        /// </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ///
        /// <returns>   Un DataSet con los comentarios. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataSet ObtenerComentarios()
        {
            DataSet ds = new DataSet();
            try
            {
                if (con == null)
                {
                    con = new global::System.Data.SqlClient.SqlConnection();
                    con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TEVEO"].ConnectionString;
                }
                
                string sentencia = "SELECT id, programa, canal, subusuario, texto, fecha, validado";
                sentencia += " FROM comentario;";
                SqlDataAdapter da = new SqlDataAdapter(sentencia, con);
                da.Fill(ds, "comentario");

                // añadimos también la tabla cadena (la usaremos para las búsquedas)
                sentencia = "SELECT id, nombre";
                sentencia += " FROM cadena;";
                da = new SqlDataAdapter(sentencia, con);
                da.Fill(ds, "cadena");

                // y la tabla programa (la usaremos para las búsquedas)
                sentencia = "SELECT id, nombre";
                sentencia += " FROM programa;";
                da = new SqlDataAdapter(sentencia, con);
                da.Fill(ds, "programa");
                
                // devolvemos el DataSet con las tablas comentario, cadena y programa
                
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

        public void ModificarComentarios(DataSet ds)
        {
            try
            {
                if (con == null)
                {
                    con = new global::System.Data.SqlClient.SqlConnection();
                    con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TEVEO"].ConnectionString;
                }
                string sentencia = "SELECT id, programa, canal, subusuario, texto, fecha, validado";
                sentencia += " FROM comentario;";
                SqlDataAdapter da = new SqlDataAdapter(sentencia, con);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.Update(ds, "comentario");
            }
            catch (SqlException ex)
            {
                Exception e = new Exception("Se ha producido un problema con la conexión a la base de datos\n La aplicación no puede continuar.\n");
                throw (e);
            }
        }
    }
}
