////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	TVO_ComponentesAccesoDatos\CADPersona.cs
//
// summary:	Implementa el Componente de Acceso a Datos (CAD) CADPersona
////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections;
using System.Data;

////////////////////////////////////////////////////////////////////////////////////////////////////
// namespace: TVO_ComponentesAccesoDatos
//
// summary:	Espacio de nombres que encapsula los Componentes de Acceso a Datos de Persona.
////////////////////////////////////////////////////////////////////////////////////////////////////
namespace TVO_ComponentesAccesoDatos
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Clase pública CADPersona. Gestiona la conexión a la Base de Datos y proporciona los métodos
    /// para Insertar, Modificar y Consultar los datos de una Persona.</summary>
    ///
    /// <remarks>   . </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class CADPersona
    {
        /// <summary> Atributo privado de tipo SqlConnection. Objeto encargado de realizar la conexión. </summary>
        /// <value>El objeto C representa la conexión a la BD.</value>
        private SqlConnection C;
        
        /// <summary> Atributo privado de tipo DataSet. Almacena la estructura y los datos de las Tablas
        /// necesarias para la obtención de información.</summary>
        /// <value>El DataSet dsCADPersona mantiene la estructura y los datos de las Tablas Persona, Perfil y Provincias.</value>
        private DataSet dsCADPersona;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor por defecto. Inicializa la conexión y obtiene la cadena de conexion
        /// desde el fichero <code>app.settings</code></summary>
        ///
        /// <remarks>   . </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public CADPersona()
        {
            C = new global::System.Data.SqlClient.SqlConnection();
            C.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TEVEO"].ConnectionString;
            dsCADPersona = new DataSet();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Método para obtener persona. Se usa en el proceso de validación. Comprueba la existencia
        ///  del NIF en la base de datos y, si existe, compara la Clave obtenida de la BD con la proporcionada por
        ///  el método. </summary>
        ///
        /// <remarks>   . </remarks>
        /// 
        /// <exception cref="System.SqlException">Se recoge cuando existe algún problema de conexión a la Base de Datos</exception>
        /// <exception cref="CADException">Se lanza en dos casos: 1) Si la contraseña es incorrecta, 2) Si no existe el NIF o 3) Si se ha recogido una SqlException.</exception>
        /// 
        /// <param name="dni">      NIF del administrador. </param>
        /// <param name="clave">    Clave de acceso. </param>
        ///
        /// <returns>   Hastable con la información del administrador. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public Hashtable BD_obtenerPersona(string dni, string clave)
        {
            Hashtable persona = new Hashtable();
            persona.Add("perfil", -1);
            SqlDataReader dr=null;
            try
            {
                C.Open();
                SqlCommand com = new SqlCommand("Select clave, nombre, apellidos, perfil, foto from administrador where nif='" + dni + "'", C); // and clave='" + clave + "'", C);
                dr = com.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    if (clave != Convert.ToString(dr["clave"]))
                        throw new CADException("Contraseña incorrecta", 1);
                    persona.Add("nombre", Convert.ToString(dr["nombre"]));
                    persona.Add("apellidos", Convert.ToString(dr["apellidos"]));
                    // if (dr["foto"] != Convert.IsDBNull) 
                    persona.Add("foto", dr["foto"]);
                   // else persona.Add("foto", null);
                    int tipo = Convert.ToInt32(dr["perfil"]);
                    persona["perfil"] = tipo;
                }
                else
                {
                    throw new CADException(dni + " no existe.", 0);
                }
                dr.Close();
            }
            catch (SqlException sqlex)
            {
                throw new CADException("Excepción de BD.", sqlex);
            }
            finally
            {
                if (C != null) C.Close();
                if (dr != null) dr.Close();
            }
            return persona;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sobrecargado (1). Método para obtener un conjunto de personas. Obtiene los registros de la Base de Datos
        /// que responden a los criterios pasados como parámetros al método.</summary>
        ///
        /// <remarks>   Los parámetros que sean cadena de longitud 0 no se tendrán en cuenta en los parámetros de búsqueda
        /// . </remarks>
        ///
        /// <example>Ejemplo de uso del método:
        /// <code>
        ///     BD_obtenerPersonas("48","","",-1);
        /// </code>
        /// Buscará y devolverá todos los registro cuyo NIF contenga la cadena "48".
        /// <code>
        ///     BD_obtenerPersonas("","Luis","",0);
        /// </code>
        /// Buscará y devolverá todos los registro cuyo Nombre y/o Apellido contenga la 
        /// palabra "Luis" y además tenga asociado el perfil 0 (Moderador)
        /// </example>
        /// 
        /// <exception cref="System.SqlException">Se lanza cuando existe algún problema de conexión a la Base de Datos</exception>
        /// <exception cref="CADException">Se lanza si se ha recogido una SqlException.</exception>
        /// 
        /// <param name="dni">      NIF completo o parte que se usará en la búsqueda. </param>
        /// <param name="nombre">   Nombre o Apellido (completo o parte) que se usará en la búsqueda. </param>
        /// <param name="email">    Correo electrónio (completo o parte) que se usará en la búsqueda. </param>
        /// <param name="perfil">   Perfil que se usará en la búsqueda. (Si su valor es -1 no se tiene en cuenta)</param>
        ///
        /// <returns>   Devuelve el DataSet con la información resultado de la consulta. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public DataSet BD_obtenerPersonas(string dni, string nombre, string email, int perfil)
        {
            string selector = "administrador.nif, administrador.clave, administrador.nombre, administrador.apellidos, administrador.direccion, administrador.poblacion, administrador.cp, administrador.email, administrador.telefono, administrador.ccc, administrador.perfil AS IDperfil, perfil.nombre AS kperfil, administrador.provincia AS IDprovincia, provincia.nombre AS kprovincia, administrador.foto"; 
            string sqlBase = "SELECT " + selector + " FROM administrador INNER JOIN perfil ON administrador.perfil = perfil.id_perfil "+
                                                                        "INNER JOIN provincia ON administrador.provincia = provincia.id "+
                                                                        "WHERE 1=1";
            
            if (dni.Length > 0) {
                sqlBase += " and nif like '%" + dni + "%'";
            }
            if (nombre.Length > 0) {
                sqlBase += " and administrador.nombre like '%" + nombre + "%' or administrador.apellidos like '%" + nombre + "%'";
            }
            if (email.Length > 0)
            {
                sqlBase += " and email like '%" + email + "%'";
            }
            if (perfil > -1)
            {
                sqlBase += " and perfil = " + perfil;
            }

            try
            {
                SqlDataAdapter sqlAdaptador = new SqlDataAdapter(sqlBase, C);
                sqlAdaptador.Fill(dsCADPersona,"Personas");
            }
            catch (SqlException sqlex)
            {
                throw new CADException("Excepción de BD. ", sqlex);
            }
            finally
            {
                if (C != null) C.Close();
            }
            return dsCADPersona;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sobrecargado (2). Método para obtener un conjunto de personas. Obtiene una cantidad
        /// de registros especificados apartir de un determinado registro de la Base de Datos
        /// que responden a los criterios pasados como parámetros al método.</summary>
        ///
        /// <remarks>   Los parámetros que sean cadena de longitud 0 no se tendrán en cuenta en los parámetros de búsqueda
        /// El parámetro desde comienza en el 1. . </remarks>
        ///
        /// <example>Ejemplo de uso del método:
        /// <code>
        ///     BD_obtenerPersonas("","","",-1,15,10);
        /// </code>
        /// Buscará y devolverá todos los registro desde el registro 15 hasta el 25.
        /// <code>
        ///     BD_obtenerPersonas("","Luis","",-1,1,100);
        /// </code>
        /// Buscará y devolverá todos los registro cuyo Nombre y/o Apellido contenga la 
        /// palabra "Luis" desde el principio hasta el registro 100.
        /// </example>
        /// 
        /// <exception cref="System.SqlException">Se lanza cuando existe algún problema de conexión a la Base de Datos</exception>
        /// <exception cref="CADException">Se lanza si se ha recogido una SqlException.</exception>
        /// 
        /// <param name="dni">      NIF completo o parte que se usará en la búsqueda. </param>
        /// <param name="nombre">   Nombre o Apellido completo o parte que se usará en la búsqueda. </param>
        /// <param name="email">    Correo electrónio (completo o parte) que se usará en la búsqueda. </param>
        /// <param name="perfil">   Perfil que se usará en la búsqueda. (Si su valor es -1 no se tiene en cuenta)</param>
        /// <param name="desde">    Valor entero que representa el registro desde el cual se obtendrán los datos. </param>
        /// <param name="cantidad"> Valor entero que representa cuantos registros como máximo debemos obtener apartir de 'desde'. </param>
        ///
        /// <returns>   Devuelve el DataSet con la información resultado de la consulta. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public DataSet BD_obtenerPersonas(string dni, string nombre, string email, int perfil, int desde, int cantidad)
        {
            string selector = "administrador.nif, administrador.clave, administrador.nombre, administrador.apellidos, administrador.direccion, administrador.poblacion, administrador.cp, administrador.email, administrador.telefono, administrador.ccc, administrador.perfil AS IDperfil, perfil.nombre AS kperfil, administrador.provincia AS IDprovincia, provincia.nombre AS kprovincia, administrador.foto";
            string sqlBase = "SELECT " + selector + " FROM administrador INNER JOIN perfil ON administrador.perfil = perfil.id_perfil " +
                                                                        "INNER JOIN provincia ON administrador.provincia = provincia.id " +
                                                                        "WHERE 1=1";

           
            if (dni.Length > 0)
            {
                sqlBase += " and nif like '%" + dni + "%'";
            }
            if (nombre.Length > 0)
            {
                sqlBase += " and administrador.nombre like '%" + nombre + "%' or administrador.apellidos like '%" + nombre + "%'";
            }
            if (email.Length > 0)
            {
                sqlBase += " and email like '%" + email + "%'";
            }
            if (perfil > -1)
            {
                sqlBase += " and perfil = " + perfil;
            }

            try
            {
                SqlDataAdapter sqlAdaptadorBase = new SqlDataAdapter(sqlBase, C);
                sqlAdaptadorBase.Fill(dsCADPersona, desde - 1, cantidad, "Personas");
            }
            catch (SqlException sqlex)
            {
                throw new CADException("Excepción de BD. ", sqlex);
            }
            finally
            {
                if (C != null) C.Close();
            }
            return dsCADPersona;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Método que permite obtener el tamaño de una consta encapsulado en un DataSet. </summary>
        ///
        /// <remarks>   . </remarks>
        ///
        /// <param name="dni">      NIF completo o parte que se usará en la búsqueda. </param>
        /// <param name="nombre">   Nombre o Apellido completo o parte que se usará en la búsqueda. </param>
        /// <param name="email">    Correo electrónio (completo o parte) que se usará en la búsqueda. </param>
        /// <param name="perfil">   Perfil que se usará en la búsqueda. (Si su valor es -1 no se tiene en cuenta)</param>
        ///
        /// <exception cref="System.SqlException">Se lanza cuando existe algún problema de conexión a la Base de Datos</exception> 
        /// <exception cref="CADException">Se lanza si se ha recogido una SqlException.</exception>
        /// 
        /// <returns>   DataSet con una tabla con una fila y una columna que contiene el tamaño. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public DataSet BD_obtenerTamanyo(string dni, string nombre, string email, int perfil)
        {
            string sqlExtra = "select count(nif) AS total from administrador where 1=1";

            if (dni.Length > 0)
            {
               sqlExtra += " and nif like '%" + dni + "%'";
            }
            if (nombre.Length > 0)
            {
               sqlExtra += " and administrador.nombre like '%" + nombre + "%' or administrador.apellidos like '%" + nombre + "%'";
            }
            if (email.Length > 0)
            {
               sqlExtra += " and email like '%" + email + "%'";
            }
            if (perfil > -1)
            {
               sqlExtra += " and perfil = " + perfil;
            }
            
            try
            {
                SqlDataAdapter sqlAdaptador = new SqlDataAdapter(sqlExtra, C);
                sqlAdaptador.Fill(dsCADPersona, "Total");
            }
            catch (SqlException sqlex)
            {
                throw new CADException("Excepción de BD. ", sqlex);
            }
            finally
            {
                if (C != null) C.Close();
            }
            return dsCADPersona;
        }

        public DataSet BD_obtenerTamanyo(string criterio)
        {
            string sqlExtra = "select count(nif) AS total from administrador INNER JOIN perfil ON administrador.perfil = perfil.id_perfil " +
                                                                        "INNER JOIN provincia ON administrador.provincia = provincia.id " +
                                                                        "WHERE 1=1";

            if (criterio.Length > 0)
            {
                sqlExtra += " and nif like '%" + criterio + "%'";
                sqlExtra += " or administrador.nombre like '%" + criterio + "%' or administrador.apellidos like '%" + criterio + "%'";
                sqlExtra += " or email like '%" + criterio + "%'";
                sqlExtra += " or direccion like '%" + criterio + "%'";
                sqlExtra += " or poblacion like '%" + criterio + "%'";
                sqlExtra += " or cp like '%" + criterio + "%'";
                sqlExtra += " or ccc like '%" + criterio + "%'";
                sqlExtra += " or provincia.nombre like '%" + criterio + "%'";
                sqlExtra += " or perfil.nombre like '%" + criterio + "%'";
            }

            try
            {
                SqlDataAdapter sqlAdaptador = new SqlDataAdapter(sqlExtra, C);
                sqlAdaptador.Fill(dsCADPersona, "Total");
            }
            catch (SqlException sqlex)
            {
                throw new CADException("Excepción de BD. ", sqlex);
            }
            finally
            {
                if (C != null) C.Close();
            }
            return dsCADPersona;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Método para insertar una persona en BD. </summary>
        ///
        /// <remarks>   . </remarks>
        ///
        /// 
        /// <exception cref="System.SqlException">Se lanza cuando existe algún problema de conexión a la Base de Datos</exception> 
        /// <exception cref="CADException">Se lanza si se ha recogido una SqlException.</exception>
        /// 
        /// <param name="nif">          NIF a insertar. </param>
        /// <param name="clave">        Clave a insertar. </param>
        /// <param name="nombre">       Nombre de la persona. </param>
        /// <param name="apellidos">    Apellidos de la persona. </param>
        /// <param name="direccion">    Dorección postal. </param>
        /// <param name="poblacion">    Población. </param>
        /// <param name="cp">           Código postal. </param>
        /// <param name="provincia">    Provincia (entero que representa la provincia). </param>
        /// <param name="email">        Correo electrónico. </param>
        /// <param name="telefono">     Teléfono. </param>
        /// <param name="ccc">          Cuenta bancaria. </param>
        /// <param name="perfil">       Perfil (entero: 0 MOderador, 1 Técnico). </param>
        ///
        /// <returns>   Devuelve un entero que representa el número de filas afectadas por la inserción. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public int BD_insertarPersona(string nif, string clave, string nombre, string apellidos, string direccion, string poblacion, string cp, int provincia, string email, string telefono, string ccc, int perfil)
        {
            int filas_afectadas = -1;
            string sql_insert = "";
            try
            {
                C.Open();
                sql_insert = "insert into administrador (nif,clave,nombre,apellidos,direccion,poblacion,cp,provincia,email,telefono,ccc,perfil) values ('" + nif + "','" + clave + "','" + nombre + "','" + apellidos + "','" + direccion + "','" + poblacion + "','" + cp + "','" + provincia + "','" + email + "','" + telefono + "','" + ccc + "','" + perfil + "')";
                SqlCommand com = new SqlCommand(sql_insert, C);
                filas_afectadas = com.ExecuteNonQuery();
            }
            catch (SqlException sqlex)
            {
                throw new CADException("Excepción de BD. ", sqlex);
            }
            finally
            {
                C.Close();
            }

            return filas_afectadas;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sobrecargado (2) Método para insertar una persona en BD. </summary>
        ///
        /// <remarks>   . </remarks>
        ///
        /// 
        /// <exception cref="System.SqlException">Se lanza cuando existe algún problema de conexión a la Base de Datos</exception> 
        /// <exception cref="CADException">Se lanza si se ha recogido una SqlException.</exception>
        /// 
        /// <param name="nif">          NIF a insertar. </param>
        /// <param name="clave">        Clave a insertar. </param>
        /// <param name="nombre">       Nombre de la persona. </param>
        /// <param name="apellidos">    Apellidos de la persona. </param>
        /// <param name="direccion">    Dorección postal. </param>
        /// <param name="poblacion">    Población. </param>
        /// <param name="cp">           Código postal. </param>
        /// <param name="provincia">    Provincia (entero que representa la provincia). </param>
        /// <param name="email">        Correo electrónico. </param>
        /// <param name="telefono">     Teléfono. </param>
        /// <param name="ccc">          Cuenta bancaria. </param>
        /// <param name="perfil">       Perfil (entero: 0 MOderador, 1 Técnico). </param>
        ///
        /// <returns>   Devuelve un entero que representa el número de filas afectadas por la inserción. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public int BD_insertarPersona(string nif, string clave, string nombre, string apellidos, string direccion, string poblacion, string cp, int provincia, string email, string telefono, string ccc, int perfil, byte[] img)
        {
            int filas_afectadas = -1;
            string sql_insert = "";
            try
            {
                C.Open();

                sql_insert = "insert into administrador (nif,clave,nombre,apellidos,direccion,poblacion,cp,provincia,email,telefono,ccc,perfil,foto) values ('" + nif + "','" + clave + "','" + nombre + "','" + apellidos + "','" + direccion + "','" + poblacion + "','" + cp + "','" + provincia + "','" + email + "','" + telefono + "','" + ccc + "','" + perfil + "',@image)";
                // inicializar el SqlCommand para insertar los objetos por parametros
                SqlCommand SqlCom = new SqlCommand(sql_insert, C);
                SqlCom.Parameters.Add(new SqlParameter("@image", img));

                // SqlCommand com = new SqlCommand(sql_insert, C);
                filas_afectadas = SqlCom.ExecuteNonQuery();
            }
            catch (SqlException sqlex)
            {
                throw new CADException("Excepción de BD. ", sqlex);
            }
            finally
            {
                C.Close();
            }

            return filas_afectadas;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sobrecargado (1) Método para modificar una persona en la BD. </summary>
        ///
        /// <remarks>   . </remarks>
        ///
        /// <param name="nif">          NIF de la persona a la cual modificar sus datos. </param>
        /// <param name="clave">        Nueva clave. </param>
        /// <param name="nombre">       Nuevo nombre. </param>
        /// <param name="apellidos">    Nuevo apellidos. </param>
        /// <param name="direccion">    Nueva direción. </param>
        /// <param name="poblacion">    Nueva población. </param>
        /// <param name="cp">           Nuevo código postal. </param>
        /// <param name="provincia">    Nueva provincia. </param>
        /// <param name="email">        Nuevo correo electrónico. </param>
        /// <param name="telefono">     Nuevo teléfono. </param>
        /// <param name="ccc">          Nueva cuenta bancaria. </param>
        /// <param name="perfil">       Nuevo perfil. </param>
        /// <param name="foto">         Nueva foto. </param>
        ///
        /// <returns>   Entero que representa las filas que se han modificado. </returns>
        ///
        /// <exception cref="System.SqlException">  Se lanza cuando existe algún problema de conexión
        ///                                             a la Base de Datos. </exception>
        /// <exception cref="CADException">         Se lanza si se ha recogido una SqlException. </exception>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public int BD_modificarPersona(string nif, string clave, string nombre, string apellidos, string direccion, string poblacion, string cp, int provincia, string email, string telefono, string ccc, int perfil, byte[] img)
        {
            int filas_afectadas = -1;
            string sql_mod = "";
            try
            {
                C.Open();
                sql_mod = "UPDATE administrador SET clave='" + clave + "'" +
                                                  ",nombre='" + nombre + "'" +
                                                  ",apellidos='" + apellidos + "'" +
                                                  ",direccion='" + direccion + "'" +
                                                  ",poblacion='" + poblacion + "'" +
                                                  ",cp='" + cp + "'" +
                                                  ",provincia=" + provincia +
                                                  ",email='" + email + "'" +
                                                  ",telefono='" + telefono + "'" +
                                                  ",ccc='" + ccc + "'" +
                                                  ",perfil=" + perfil +
                                                  ",foto=@image" +
                          " WHERE nif = '" + nif + "'";

                SqlCommand com = new SqlCommand(sql_mod, C);
                com.Parameters.Add(new SqlParameter("@image", img));
                filas_afectadas = com.ExecuteNonQuery();

            }
            catch (SqlException sqlex)
            {
                throw new CADException("Excepción de BD. ", sqlex);
            }
            finally
            {
                C.Close();
            }

            return filas_afectadas;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sobrecargado (2) Método para modificar una persona en la BD. </summary>
        ///
        /// <remarks>   . </remarks>
        ///
        /// <exception cref="System.SqlException">Se lanza cuando existe algún problema de conexión a la Base de Datos</exception> 
        /// <exception cref="CADException">Se lanza si se ha recogido una SqlException.</exception>
        /// 
        /// <param name="nif">          NIF de la persona a la cual modificar sus datos. </param>
        /// <param name="clave">        Nueva clave. </param>
        /// <param name="nombre">       Nuevo nombre. </param>
        /// <param name="apellidos">    Nuevo apellidos. </param>
        /// <param name="direccion">    Nueva direción. </param>
        /// <param name="poblacion">    Nueva población. </param>
        /// <param name="cp">           Nuevo código postal. </param>
        /// <param name="provincia">    Nueva provincia. </param>
        /// <param name="email">        Nuevo correo electrónico. </param>
        /// <param name="telefono">     Nuevo teléfono. </param>
        /// <param name="ccc">          Nueva cuenta bancaria. </param>
        /// <param name="perfil">       Nuevo perfil. </param>
        ///
        /// <returns>   Entero que representa las filas que se han modificado. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        
        public int BD_modificarPersona(string nif, string clave, string nombre, string apellidos, string direccion, string poblacion, string cp, int provincia, string email, string telefono, string ccc, int perfil)
        {
            int filas_afectadas = -1;
            string sql_mod = "";
            try
            {
                C.Open();
                sql_mod = "UPDATE administrador SET clave='" + clave + "'" +
                                                  ",nombre='" + nombre + "'" +
                                                  ",apellidos='" + apellidos + "'" +
                                                  ",direccion='" + direccion + "'" +
                                                  ",poblacion='" + poblacion + "'" +
                                                  ",cp='" + cp + "'" +
                                                  ",provincia=" + provincia +
                                                  ",email='" + email + "'" +
                                                  ",telefono='" + telefono + "'" +
                                                  ",ccc='" + ccc + "'" +
                                                  ",perfil=" + perfil +
                          " WHERE nif = '" + nif + "'";

                SqlCommand com = new SqlCommand(sql_mod, C);
                filas_afectadas = com.ExecuteNonQuery();

            }
            catch (SqlException sqlex)
            {
                throw new CADException("Excepción de BD. ", sqlex);
            }
            finally
            {
                C.Close();
            }

            return filas_afectadas;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Método para eliminar una persona de la BD. </summary>
        ///
        /// <remarks>   . </remarks>
        ///
        /// <exception cref="System.SqlException">Se lanza cuando existe algún problema de conexión a la Base de Datos</exception> 
        /// <exception cref="CADException">Se lanza si se ha recogido una SqlException.</exception>
        /// 
        /// <param name="nif">  NIF del usuario que se desea eliminar. </param>
        ///
        /// <returns>   Entero con el número de filas afectadas por el borrado. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public int BD_eliminarPersona(string nif)
        {
            int filas_afectadas = -1;
            string sql_eli = "";
            try
            {
                C.Open();
                sql_eli = "DELETE FROM administrador" + 
                          " WHERE nif = '" + nif + "'";

                SqlCommand com = new SqlCommand(sql_eli, C);
                filas_afectadas = com.ExecuteNonQuery();

            }
            catch (SqlException sqlex)
            {
                throw new CADException("Excepción de BD. ", sqlex);
            }
            finally
            {
                C.Close();
            }

            return filas_afectadas;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Método para obtener los perfiles existentes. </summary>
        ///
        /// <remarks>   Este método se usa para rellenar los componentes de tipo ComboBox de la parte visual
        /// . </remarks>
        ///
        /// <exception cref="System.SqlException">Se lanza cuando existe algún problema de conexión a la Base de Datos</exception> 
        /// <exception cref="CADException">Se lanza si se ha recogido una SqlException.</exception>
        /// 
        /// <returns>   ArrayList con el nombre de los perfiles. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public ArrayList BD_obtenerPerfiles()
        {
            ArrayList perfiles = new ArrayList();
            
            try
            {
                C.Open();
                SqlCommand com = new SqlCommand("Select nombre from perfil where id_perfil != -1 order by id_perfil", C);
                SqlDataReader dr = com.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        perfiles.Add(Convert.ToString(dr["nombre"]));
                    }
                }
                dr.Close();
            }
            catch (SqlException sqlex)
            {
                throw new CADException("Error de lectura de BD. ", sqlex);
            }
            finally
            {
                C.Close();
            }
            return perfiles;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Método para obtener las provincias españolas de la BD. </summary>
        ///
        /// <remarks>   . </remarks>
        ///
        /// <exception cref="System.SqlException">Se lanza cuando existe algún problema de conexión a la Base de Datos</exception> 
        /// <exception cref="CADException">Se lanza si se ha recogido una SqlException.</exception>
        /// 
        /// <returns>   DataSet con el identificador y el nombre de las provincias. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public DataSet BD_obtenerProvincias()
        {
            DataSet dsProvincias = new DataSet();
            
            try
            {
                string selector = "id, nombre";
                string sqlBase = "SELECT " + selector + " FROM provincia";

                SqlDataAdapter da = new SqlDataAdapter(sqlBase, C);
                da.Fill(dsProvincias, "Provincia");
            }
            catch (SqlException sqlex)
            {
                throw new CADException("Error de lectura de BD. ", sqlex);
            }
            finally
            {
                C.Close();
            }
            return dsProvincias;
        }

        public DataSet BD_obtenerBusquedaRapida(string criterio)
        {
            string selector = "administrador.nif, administrador.clave, administrador.nombre, administrador.apellidos, administrador.direccion, administrador.poblacion, administrador.cp, administrador.email, administrador.telefono, administrador.ccc, administrador.perfil AS IDperfil, perfil.nombre AS kperfil, administrador.provincia AS IDprovincia, provincia.nombre AS kprovincia, administrador.foto";
            string sqlBase = "SELECT " + selector + " FROM administrador INNER JOIN perfil ON administrador.perfil = perfil.id_perfil " +
                                                                        "INNER JOIN provincia ON administrador.provincia = provincia.id " +
                                                                        "WHERE 1=1";

            if (criterio.Length > 0)
            {
                sqlBase += " and nif like '%" + criterio + "%'";
                sqlBase += " or administrador.nombre like '%" + criterio + "%' or administrador.apellidos like '%" + criterio + "%'";
                sqlBase += " or email like '%" + criterio + "%'";
                sqlBase += " or direccion like '%" + criterio + "%'";
                sqlBase += " or poblacion like '%" + criterio + "%'";
                sqlBase += " or cp like '%" + criterio + "%'";
                sqlBase += " or ccc like '%" + criterio + "%'";
                sqlBase += " or provincia.nombre like '%" + criterio + "%'";
                sqlBase += " or perfil.nombre like '%" + criterio + "%'";
            }

            try
            {
                SqlDataAdapter sqlAdaptador = new SqlDataAdapter(sqlBase, C);
                sqlAdaptador.Fill(dsCADPersona, "Personas");
            }
            catch (SqlException sqlex)
            {
                throw new CADException("Excepción de BD. ", sqlex);
            }
            finally
            {
                if (C != null) C.Close();
            }
            return dsCADPersona;
        }


        public DataSet BD_obtenerBusquedaRapida(string criterio, int desde, int cantidad)
        {
            string selector = "administrador.nif, administrador.clave, administrador.nombre, administrador.apellidos, administrador.direccion, administrador.poblacion, administrador.cp, administrador.email, administrador.telefono, administrador.ccc, administrador.perfil AS IDperfil, perfil.nombre AS kperfil, administrador.provincia AS IDprovincia, provincia.nombre AS kprovincia, administrador.foto";
            string sqlBase = "SELECT " + selector + " FROM administrador INNER JOIN perfil ON administrador.perfil = perfil.id_perfil " +
                                                                        "INNER JOIN provincia ON administrador.provincia = provincia.id " +
                                                                        "WHERE 1=1";

            if (criterio.Length > 0)
            {
                sqlBase += " and nif like '%" + criterio + "%'";
                sqlBase += " or administrador.nombre like '%" + criterio + "%' or administrador.apellidos like '%" + criterio + "%'";
                sqlBase += " or email like '%" + criterio + "%'";
                sqlBase += " or direccion like '%" + criterio + "%'";
                sqlBase += " or poblacion like '%" + criterio + "%'";
                sqlBase += " or cp like '%" + criterio + "%'";
                sqlBase += " or ccc like '%" + criterio + "%'";
                sqlBase += " or provincia.nombre like '%" + criterio + "%'";
                sqlBase += " or perfil.nombre like '%" + criterio + "%'";
            }

            try
            {
                SqlDataAdapter sqlAdaptador = new SqlDataAdapter(sqlBase, C);
                sqlAdaptador.Fill(dsCADPersona, desde - 1, cantidad, "Personas");
            }
            catch (SqlException sqlex)
            {
                throw new CADException("Excepción de BD. ", sqlex);
            }
            finally
            {
                if (C != null) C.Close();
            }
            return dsCADPersona;
        }
    
    }

    
}
