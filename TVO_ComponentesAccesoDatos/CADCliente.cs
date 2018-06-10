////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	TVO_ComponentesAccesoDatos\CADCliente.cs
//
// summary:	Implementa el Componente de Asceso de Datos (CAD) CADCliente
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;

////////////////////////////////////////////////////////////////////////////////////////////////////
// namespace: TVO_ComponentesAccesoDatos
//
// summary:	Espacio de nombres que encapsula los Componentes de Acceso de Datos de Cliente.
////////////////////////////////////////////////////////////////////////////////////////////////////

namespace TVO_ComponentesAccesoDatos
{   
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>    Clase pública CADCliente. Gestiona la conexión a la Base de Datos y proporciona los métodos
    /// para Insertar, Modificar y Consultar los datos de un Cliente. </summary>
    ///
    /// <remarks>  TVO DPAA 2009-2010 . </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class CADCliente
    {   
        /// <summary> Atributo privado que conecta a la Base de Datos .  </summary>

        private SqlConnection Conexion;
        /// <summary> Atributo para Guardarnos el DataSet obtenido en las Busquedas y poder paginar.  </summary>

        private DataSet dsCADCliente;
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor por Defecto. Estable la conexion a la Base de Datos </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public CADCliente() 
        {
            Conexion = new global::System.Data.SqlClient.SqlConnection();

            Conexion.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TEVEO"].ConnectionString;
            dsCADCliente = new DataSet();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Bd obtener tamanyo. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="dni">          El dni del Cliente. </param>
        /// <param name="nombre">       El nombre del Cliente. </param>
        /// <param name="apellidos">    Los apellidos del Cliente. </param>
        ///
        /// <returns>   Obtiene un dataset con el numero de registro que cumplen la select. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataSet BD_obtenerTamanyo(string dni, string nombre,string apellidos)
        {
            string sqlExtra = "select count(nif) AS total from titular where 1=1";

            if (dni.Length > 0)
            {
                sqlExtra += " and titular.nif like '%" + dni + "%'";
            }
            if (nombre.Length > 0)
            {
                sqlExtra += " and titular.nombre like '%" + nombre + "%' ";
            }
            if (apellidos.Length > 0 )
                sqlExtra += "and titular.apellidos like '%" + apellidos + "%'";

            try
            {
                SqlDataAdapter sqlAdaptador = new SqlDataAdapter(sqlExtra, Conexion);
                sqlAdaptador.Fill(dsCADCliente, "Total");
            }
            catch (SqlException sqlex)
            {
                throw new CADException("Excepción de BD. ", sqlex);
            }
            finally
            {
                if (Conexion != null) Conexion.Close();
            }
            return dsCADCliente;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Bd obtener tamanyo de la consulta. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="dni">          El dni del Cliente. </param>
        /// <param name="nombre">       El nombre del Cliente. </param>
        /// <param name="apellidos">    Los apellidos del Cliente. </param>
        /// <param name="sexo">         El sexo del Cliente. </param>
        /// <param name="telefono">     El telefono del Cliente. </param>
        /// <param name="email">        El email del Cliente. </param>
        /// <param name="provincia">    La provincia del Cliente. </param>
        ///
        /// <returns>   Obtiene un dataset con el numero de registro que cumplen la select. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataSet BD_obtenerTamanyo( string dni,string nombre, string apellidos,string sexo,string telefono,string email,int provincia)
        {
            string sqlExtra = "select count(nif) AS total from titular where 1=1";

            if (dni.Length > 0)
               sqlExtra += " and titular.nif like '%" + dni + "%'";
            if (provincia > 0 && provincia <= 52)
                sqlExtra += "and titular.provincia="+ provincia;
            if (sexo.Length > 0 && sexo != "Todos")
                sqlExtra += " and titular.sexo like '%" + sexo + "%'";
            
            if (nombre.Length > 0)
               sqlExtra += " and titular.nombre like '%" + nombre + "%'";
            if(apellidos.Length > 0)
               sqlExtra += " and titular.apellidos like '%" + apellidos + "%'";
            if(telefono.Length > 0)
                sqlExtra += " and titular.telefono like '%" + telefono + "%'";
            if(email.Length > 0)
                sqlExtra += " and titular.email like '%" + email + "%'";

            try
            {
                SqlDataAdapter sqlAdaptador = new SqlDataAdapter(sqlExtra, Conexion);
                sqlAdaptador.Fill(dsCADCliente, "Total");
            }
            catch (SqlException sqlex)
            {
                throw new CADException("Excepción de BD. ", sqlex);
            }
            finally
            {
                if (Conexion != null) Conexion.Close();
            }
            return dsCADCliente;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Bd obtener tamanyo. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="cadena">   La cadena. </param>
        ///
        /// <returns>   Obtiene un dataset con el numero de registro que cumplen la select. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataSet BD_obtenerTamanyo(string cadena)
        {


            string sqlInstruccion = "select count(nif) AS total from titular INNER JOIN provincia ON titular.provincia = provincia.id WHERE 1=1 ";
            if (cadena.Length > 0)
            {
                sqlInstruccion += " and titular.nif like '%" + cadena + "%'";
                sqlInstruccion += " or titular.sexo like '%" + cadena + "%'";
                sqlInstruccion += " or provincia.nombre like '%" + cadena + "%'";
                
                sqlInstruccion += " or titular.direccion like '%" + cadena + "%'";
                sqlInstruccion += " or titular.nombre like '%" + cadena + "%'";
                sqlInstruccion += " or titular.apellidos like '%" + cadena + "%'";
                sqlInstruccion += " or titular.poblacion like '%" + cadena + "%'";
                sqlInstruccion += " or titular.cp like '%" + cadena + "%'";
                sqlInstruccion += " or titular.email like '%" + cadena + "%'";
                sqlInstruccion += " or titular.telefono like '%" + cadena + "%'";
                sqlInstruccion += " or titular.ccc like '%" + cadena + "%'";
                sqlInstruccion += " or titular.fecha like '%" + cadena + "%'";

                
            }

            try
            {
                SqlDataAdapter sqlAdaptador = new SqlDataAdapter(sqlInstruccion, Conexion);
                sqlAdaptador.Fill(dsCADCliente, "Total");
            }
            catch (SqlException sqlex)
            {
                throw new CADException("Excepción de BD. ", sqlex);
            }
            finally
            {
                if (Conexion != null) Conexion.Close();
            }
            return dsCADCliente;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Busqueda generica cliente. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="cadena">       La cadena. </param>
        /// <param name="desde">        Valor de inicio en la Paginación. </param>
        /// <param name="cantidad">     Valor de fin en la Paginación. </param>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataSet BusquedaGenericaCliente(string cadena, int desde, int cantidad)
        {
            DataSet dsCliente = new DataSet();
            string sqlInstruccion = "SELECT  provincia.nombre as provi ,titular.nif, titular.clave, titular.nombre, titular.apellidos, titular.sexo, titular.fecha, titular.ccc, titular.telefono, titular.email, titular.direccion, titular.poblacion, titular.cp, titular.provincia FROM titular INNER JOIN provincia ON titular.provincia = provincia.id WHERE 1=1 ";
            if (cadena.Length > 0)
            {
                sqlInstruccion += " and titular.nif like '%" + cadena + "%'";
                sqlInstruccion += " or provincia.nombre like '%" + cadena + "%'";
                sqlInstruccion += " or titular.sexo like '%" + cadena + "%'";

                sqlInstruccion += " or titular.direccion like '%" + cadena + "%'";
                sqlInstruccion += " or titular.nombre like '%" + cadena + "%'";
                sqlInstruccion += " or titular.apellidos like '%" + cadena + "%'";
                sqlInstruccion += " or titular.poblacion like '%" + cadena + "%'";
                sqlInstruccion += " or titular.cp like '%" + cadena + "%'";
                sqlInstruccion += " or titular.email like '%" + cadena + "%'";
                sqlInstruccion += " or titular.telefono like '%" + cadena + "%'";
                sqlInstruccion += " or titular.ccc like '%" + cadena + "%'";
                sqlInstruccion += " or titular.fecha like '%" + cadena + "%'";
            }
            try
            {
                SqlDataAdapter sqlAdaptador = new SqlDataAdapter(sqlInstruccion, Conexion);
                sqlAdaptador.Fill(dsCADCliente, desde - 1, cantidad, "Clientes");
            }
            catch (SqlException sqlex)
            {
                throw new CADException("Excepción de BD. ", sqlex);
            }
            finally
            {
                if (Conexion != null) Conexion.Close();
            }
            return dsCADCliente;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Buscar clientes. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="dni">          El dni del Cliente. </param>
        /// <param name="nombre">       El nombre del Cliente. </param>
        /// <param name="apellidos">    Los apellidos del Cliente. </param>
        /// <param name="sexo">         El sexo del Cliente. </param>
        /// <param name="telefono">     El telefono del Cliente. </param>
        /// <param name="email">        El email del Cliente. </param>
        /// <param name="provincia">    La provincia del Cliente. </param>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataSet BuscarClientes (string dni,string nombre, string apellidos,string sexo,string telefono, string email ,int provincia )
        {
            DataSet dsCliente = new DataSet();
            //Generamos el Comando select
            string sqlInstruccion = "SELECT titular.nif, titular.clave, titular.nombre, titular.apellidos, titular.direccion, titular.poblacion, titular.cp, titular.provincia, provincia.nombre AS provi, titular.email, titular.telefono, titular.ccc, titular.fecha, titular.sexo FROM titular INNER JOIN  provincia ON titular.provincia = provincia.id WHERE 1=1 ";
            
            if ( dni.Length > 0 )
                sqlInstruccion += " and titular.nif like '%" + dni + "%'";
            if (provincia > 0 && provincia <= 52)
                sqlInstruccion += " and titular.provincia = '" + provincia + "'";
            if (sexo.Length > 0 && sexo != "Todos")
                sqlInstruccion += " and titular.sexo like '%" + sexo + "%'";

            if (nombre.Length > 0)
                sqlInstruccion += " and titular.nombre like '%" + nombre + "%'";
            if (apellidos.Length > 0)
                sqlInstruccion += " and titular.apellidos like '%" + apellidos + "%'";
            if (email.Length > 0)
                sqlInstruccion += " and titular.email like '%" + email + "%'";
            if (telefono.Length > 0)
                sqlInstruccion += " and titular.telefono like '%" + telefono + "%'";
            
            try 
            {
                SqlDataAdapter daCliente = new SqlDataAdapter(sqlInstruccion,Conexion);
                daCliente.Fill(dsCliente, "Clientes");
            }
            catch (Exception ex) 
            {
                //throw new CADException("Error en la Busqueda Clientes");
                throw ex;
            }
            finally
            {
                if (Conexion != null)
                    Conexion.Close();
            }
            return dsCliente;
           

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Buscar clientes. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="dni">          El dni del Cliente. </param>
        /// <param name="nombre">       El nombre del Cliente. </param>
        /// <param name="apellidos">    Los apellidos del Cliente. </param>
        /// <param name="sexo">         El sexo del Cliente. </param>
        /// <param name="telefono">     El telefono del Cliente. </param>
        /// <param name="email">        El email del Cliente. </param>
        /// <param name="provincia">    La provincia del Cliente. </param>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataSet BuscarClientes(string dni, string nombre, string apellidos, string sexo, string telefono, string email, int provincia, int desde, int tamaño)
        {
            DataSet dsCliente = new DataSet();
            //Generamos el Comando select
            string sqlInstruccion = "SELECT titular.nif, titular.clave, titular.nombre, titular.apellidos, titular.direccion, titular.poblacion, titular.cp, titular.provincia,  titular.email, titular.telefono, titular.ccc, titular.fecha, titular.sexo ,provincia.nombre AS provi FROM titular INNER JOIN  provincia ON titular.provincia = provincia.id WHERE 1=1 ";
            if (dni.Length > 0)
                sqlInstruccion += " and titular.nif like '%" + dni + "%'";
            if (provincia > 0 && provincia <= 52)
                sqlInstruccion += " and titular.provincia = " + provincia;
            if (sexo.Length > 0 && sexo != "Todos")
                sqlInstruccion += " and titular.sexo like '%" + sexo + "%'";

            if (nombre.Length > 0)
                sqlInstruccion += " and titular.nombre like '%" + nombre + "%'";
            if (apellidos.Length > 0)
                sqlInstruccion += " and titular.apellidos like '%" + apellidos + "%'";
            if (email.Length > 0)
                sqlInstruccion += " and titular.email like '%" + email + "%'";
            if (telefono.Length > 0)
                sqlInstruccion += " and titular.telefono like '%" + telefono + "%'";
           


            try
            {
                SqlDataAdapter daCliente = new SqlDataAdapter(sqlInstruccion, Conexion);
                daCliente.Fill(dsCliente,desde -1, tamaño, "Clientes");
            }
            catch (Exception ex)
            {
                //throw new CADException("Error en la Busqueda Clientes");
                throw ex;
            }
            finally
            {
                if (Conexion != null)
                    Conexion.Close();
            }
            return dsCliente;


        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Buscar clientes. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="dni">          El dni del Cliente. </param>
        /// <param name="nombre">       El nombre del Cliente. </param>
        /// <param name="apellidos">    Los apellidos del Cliente. </param>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataSet BuscarClientes(string dni, string nombre, string apellidos)
        {
            DataSet dsCliente = new DataSet();
            //Generamos el Comando select

            string sqlInstruccion = "SELECT titular.nif, titular.clave, titular.nombre, titular.apellidos, titular.direccion, titular.poblacion, titular.cp, titular.provincia, provincia.nombre AS provi, titular.email, titular.telefono, titular.ccc, titular.fecha, titular.sexo FROM titular INNER JOIN  provincia ON titular.provincia = provincia.id WHERE 1=1 ";
            if (dni.Length > 0)
                sqlInstruccion += " and titular.nif like '%" + dni + "%'";
            if (nombre.Length > 0)
                sqlInstruccion += " and titular.nombre like '%" + nombre + "%'";
            if (apellidos.Length > 0)
                sqlInstruccion += " and titular.apellidos like '%" + apellidos + "%'";

            try
            {
                SqlDataAdapter daCliente = new SqlDataAdapter(sqlInstruccion, Conexion);
                daCliente.Fill(dsCliente, "Clientes");
            }
            catch (Exception ex)
            {
                //throw new CADException("Error en la Busqueda Clientes");
                throw ex;
            }
            finally
            {
                if (Conexion != null)
                    Conexion.Close();
            }
            return dsCliente;


        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Buscar clientes. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="dni">          The dni. </param>
        /// <param name="nombre">       The nombre. </param>
        /// <param name="apellidos">    The apellidos. </param>
        /// <param name="desde">        The desde. </param>
        /// <param name="tamaño">       The tama o. </param>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataSet BuscarClientes(string dni, string nombre, string apellidos, int desde, int tamaño)
        {
            DataSet dsCliente = new DataSet();
            //Generamos el Comando select

            string sqlInstruccion = "SELECT titular.nif, titular.clave, titular.nombre, titular.apellidos, titular.direccion, titular.poblacion, titular.cp, titular.provincia, provincia.nombre AS provi, titular.email, titular.telefono, titular.ccc, titular.fecha, titular.sexo FROM titular INNER JOIN  provincia ON titular.provincia = provincia.id WHERE 1=1 ";
            if (dni.Length > 0)
                sqlInstruccion += " and titular.nif like '%" + dni + "%'";
            if (nombre.Length > 0)
                sqlInstruccion += " and titular.nombre like '%" + nombre + "%'";
            if (apellidos.Length > 0)
                sqlInstruccion += " and titular.apellidos like '%" + apellidos + "%'";

            try
            {
                SqlDataAdapter daCliente = new SqlDataAdapter(sqlInstruccion, Conexion);
                daCliente.Fill(dsCliente,desde -1, tamaño, "Clientes");
            }
            catch (Exception ex)
            {
                //throw new CADException("Error en la Busqueda Clientes");
                throw ex;
            }
            finally
            {
                if (Conexion != null)
                    Conexion.Close();
            }
            return dsCliente;


        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Busqueda generica cliente. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="cadena">   La cadena. </param>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataSet BusquedaGenericaCliente(string cadena) 
        {
            DataSet dsCliente = new DataSet();
            string sqlInstruccion = "SELECT  provincia.nombre as provi ,titular.nif, titular.clave, titular.nombre, titular.apellidos, titular.sexo, titular.fecha, titular.ccc, titular.telefono, titular.email, titular.direccion, titular.poblacion, titular.cp, titular.provincia FROM titular INNER JOIN provincia ON titular.provincia = provincia.id WHERE 1=1 ";
            if (cadena.Length > 0)
            {
                sqlInstruccion += " and titular.nif like '%" + cadena + "%'";
                sqlInstruccion += " or titular.direccion like '%" + cadena + "%'";
                sqlInstruccion += " or titular.nombre like '%" + cadena + "%'";
                sqlInstruccion += " or titular.apellidos like '%" + cadena + "%'";
                sqlInstruccion += " or titular.poblacion like '%" + cadena + "%'";
                sqlInstruccion += " or titular.cp like '%" + cadena + "%'";
                sqlInstruccion += " or provincia.nombre like '%" + cadena + "%'";
                sqlInstruccion += " or titular.sexo like '%" + cadena + "%'";
                sqlInstruccion += " or titular.email like '%" + cadena + "%'";
                sqlInstruccion += " or titular.telefono like '%" + cadena + "%'";
                sqlInstruccion += " or titular.ccc like '%" + cadena + "%'";
                sqlInstruccion += " or titular.fecha like '%" + cadena + "%'";
            }
            try
            {
                SqlDataAdapter daCliente = new SqlDataAdapter(sqlInstruccion, Conexion);
                daCliente.Fill(dsCliente, "Clientes");
                
            }
            catch (Exception sqlex)
            {
                throw new CADException("Excepción de BD. "+sqlex.Message,-1);
            }
            finally
            {
                if (Conexion != null)
                    Conexion.Close();
            }
            return dsCliente;

        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Insertar cliente. Generamos el comando Insert into para insertar el cliente en la Base de Datos </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="dni">          El dni del cliente. </param>
        /// <param name="clave">        La clave del cliente. </param>
        /// <param name="nombre">       El nombre del cliente. </param>
        /// <param name="apellidos">    Los apellidos del cliente. </param>
        /// <param name="sexo">         El sexo del cliente. </param>
        /// <param name="fecha">        La fecha de naciemiento del cliente. </param>
        /// <param name="telefono">     El Telefono del cliente. </param>
        /// <param name="email">        El email del cliente. </param>
        /// <param name="provincia">    La Provincia del cliente. </param>
        /// <param name="poblacion">    La Poblacion del cliente. </param>
        /// <param name="direccion">    La Direccion del cliente. </param>
        /// <param name="ccc">          El Código Cuenta Cliente. </param>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int InsertarCliente(string dni, string clave, string nombre, string apellidos, string sexo,DateTime fecha, string telefono, string email , int provincia,string poblacion, string direccion , string ccc, string cp) 
        {
            int insertados = -1;
            string sqlInstruccion = "insert into titular (nif,clave,nombre,apellidos,direccion,poblacion,cp,provincia,email,telefono,ccc,fecha,sexo) values ('" + dni + "','" + clave + "','" + nombre + "','" + apellidos + "','" + direccion + "','" + poblacion + "','" + cp + "','" + provincia + "','" + email + "','" + telefono + "','" + ccc + "','" + fecha + "','" + sexo + "')" ;
            try
            {
                Conexion.Open();
                SqlCommand comando = new SqlCommand(sqlInstruccion, Conexion);
                insertados = comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new CADException("Excepción de BD. "+ ex.Message,-1);
               
            }
            finally
            {
                if(Conexion != null)
                    Conexion.Close();
            }
            return insertados;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Borrar Cliente en la Base de Datos. Generamos el comando delete para borrar el cliente de la Base de Datos </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="dni">  El dni del Cliente. </param>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int BorrarCliente(string dni)
        {
            int borrados = -1;
            //Creamos la sentencia delete
            string sqlInstruccion = "delete from titular where nif= '" + dni + "'";
            try
            {
                Conexion.Open();
                SqlCommand comando = new SqlCommand(sqlInstruccion, Conexion);
                borrados = comando.ExecuteNonQuery();
            }
            catch (SqlException sqlex)
            {
                throw new CADException("Excepción de BD. ", sqlex);
            }
            finally {
                if (Conexion != null)
                    Conexion.Close();
            }
            return borrados;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Modificar Cliente en la Base de Datos. Generamos el comando Update para modificar los valores del Cliente </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="dni">          El dni del cliente. </param>
        /// <param name="clave">        La clave del cliente. </param>
        /// <param name="nombre">       El nombre del cliente. </param>
        /// <param name="apellidos">    Los apellidos del cliente. </param>
        /// <param name="sexo">         El sexo del cliente. </param>
        /// <param name="fecha">        La fecha de naciemiento del cliente. </param>
        /// <param name="telefono">     El Telefono del cliente. </param>
        /// <param name="email">        El email del cliente. </param>
        /// <param name="provincia">    La Provincia del cliente. </param>
        /// <param name="poblacion">    La Poblacion del cliente. </param>
        /// <param name="direccion">    La Direccion del cliente. </param>
        /// <param name="ccc">          El Código Cuenta Cliente. </param>
        /// <param name="cp">           El Código Postal . </param>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int ModificarCliente(string dni, string clave, string nombre, string apellidos, string sexo, DateTime fecha, string telefono, string email, int provincia, string poblacion, string direccion, string ccc, string cp) 
        {
            int modificados = -1;
            //Creamos la sentencia update
            string sqlInstruccion = "update titular set " + 
                                                  
                                                  "clave='" + clave + "'" +
                                                  ",nombre='" + nombre + "'" +
                                                  ",apellidos='" + apellidos + "'" +
                                                  ",direccion='" + direccion + "'" +
                                                  ",poblacion='" + poblacion + "'" +
                                                  ",cp='" + cp + "'" +
                                                  ",provincia=" + provincia +
                                                  ",email='" + email + "'" +
                                                  ",telefono='" + telefono + "'" +
                                                  ",ccc='" + ccc + "'" +
                                                  ",sexo='" + sexo + "'" +
                                                  ",fecha='" + fecha.ToString() + "'" +
                                                 

                                                  " where nif = '" + dni + "'";
            try {
                Conexion.Open();
                SqlCommand comando = new SqlCommand(sqlInstruccion, Conexion);
                modificados = comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally 
            {
                if (Conexion != null)
                    Conexion.Close();
            }
            return modificados;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Bd obtener provincias. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataSet BD_obtenerProvincias()
        {
            DataSet dsProvincias = new DataSet();

            try
            {
               
                string sqlInstruccion = "SELECT id, nombre FROM provincia";

                SqlDataAdapter da = new SqlDataAdapter(sqlInstruccion, Conexion);
                da.Fill(dsProvincias, "Provincia");
            }
            catch (SqlException sqlex)
            {
                throw new CADException("Error de lectura de BD. ", sqlex);
            }
            finally
            {
                Conexion.Close();
            }
            return dsProvincias;
        }
    }
}
