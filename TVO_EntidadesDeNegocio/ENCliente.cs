////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	TVO_EntidadesDeNegocio\ENCliente.cs
//
// summary:	Implementa la Entidad de Negocio (EN) ENCliente
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TVO_ComponentesAccesoDatos;
using System.Collections;
using System.Data;

////////////////////////////////////////////////////////////////////////////////////////////////////
// namespace: TVO_EntidadesDeNegocio
//
// summary:	Espacio de nombre de las Entidades de Negocio.
////////////////////////////////////////////////////////////////////////////////////////////////////

namespace TVO_EntidadesDeNegocio
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Clase publica cliente. Hereda de ENPersona </summary>
    ///
    /// <remarks>   TVO DPAA 2009-2010. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class ENCliente : ENPersona
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor por defecto. Llama al constructor por defecto de ENPersona </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        
        public ENCliente() : base() {
            
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor Cliente Parametrizado. Llama al constructor de ENPersona y inicializa los atributos de cliente </summary>///
        ///                                                                                                                                  ///   
        /// <remarks>   TVO DPAA 2009-2010. </remarks>                                                                                       ///   
        ///                                                                                                                                  ///   
        /// <param name="dni">          The dni. </param>                                                                                    ///   
        /// <param name="clave">        The clave. </param>                                                                                  ///   
        /// <param name="nombre">       The nombre. </param>                                                                                 ///   
        /// <param name="apellidos">    The apellidos. </param>                                                                              ///       
        /// <param name="sexo">         The sexo. </param>                                                                                   ///   
        /// <param name="fecha">        The fecha. </param>                                                                                  ///   
        /// <param name="email">        The email. </param>                                                                                  ///    
        /// <param name="telefono">     The telefono. </param>                                                                               ///
        /// <param name="direccion">    The direccion. </param>                                                                              ///   
        /// <param name="poblacion">    The poblacion. </param>                                                                              ///       
        /// <param name="ccc">          The ccc. </param>                                                                                    ///   
        /// <param name="provincia">    The provincia. </param>                                                                              ///           
        /// <param name="perfil">       The perfil. </param>                                                                                 ///           
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////      

        public ENCliente(string dni, string clave, string nombre, string apellidos, string sexo, DateTime fecha, string email, string telefono, string direccion, string poblacion, string ccc, int provincia,string cp)
            : base(dni, clave, nombre, apellidos, sexo, fecha, email, telefono, direccion, poblacion, ccc, provincia,cp)
        {
           
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Insertar cliente en la Base de Datos. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <returns>   Devuelve el numero de Clientes insertados en la base de datos. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int InsertarClienteBD()
        {
            CADCliente BD = new CADCliente();
            int insertar = 0;
            try
            {
                insertar = BD.InsertarCliente(Dni, Clave, Nombre, Apellidos, Sexo, Fecha, Telefono, Email, Provincia, Poblacion, Direccion, CCC, CP);
            }
            catch (CADException cex)
            {
                throw new ENException("Violación de la clave primaria. Dni ya insertado.");
            }
            return insertar;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Borrar cliente de la Base de datos. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <returns>   Devuelve el numero de Clientes borrados en la base de datos. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int BorrarClienteBD()
        {
            CADCliente BD = new CADCliente();
            int borrados = 0;
            try
            {
                borrados = BD.BorrarCliente(Dni);
            } 
            catch(CADException cex)
            {
                throw new ENException(cex.Mensaje);
            }
            return borrados;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Modificar cliente en la Base de Datos. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <returns>   Devuelve el numero de Clientes modificados. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int ModificarClienteBD()
        {
            CADCliente BD = new CADCliente();
            int modificados = 0;
            try
            {
                modificados = BD.ModificarCliente(Dni, Clave, Nombre, Apellidos, Sexo, Fecha, Telefono, Email, Provincia, Poblacion, Direccion, CCC, CP);
            } 
            catch(CADException cex)
            {
                throw new ENException(cex.Mensaje);
            }
            return modificados;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Obtener vista dgv cliente. Unifica el campo de direccion (direccion,cp,poblacion,provincia) y de nombre (Apellidos y nombre) de la tabla. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="dsCliente">    DataSet Cliente. </param>
        ///
        /// <returns>   Devuelve la nueva vista del datagridview de clientes. </returns>
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataTable obtenerVistaDGVCliente(DataSet dsCliente) 
        {
            DataTable dtAuxiliar = new DataTable("Clientes");
            DataTable dv = new DataTable();
            try
            {
                dv = dsCliente.Tables["Clientes"];
                dtAuxiliar.Columns.Add("nif", System.Type.GetType("System.String"));
                dtAuxiliar.Columns.Add("nombre", System.Type.GetType("System.String"));
                dtAuxiliar.Columns.Add("direccion", System.Type.GetType("System.String"));
                dtAuxiliar.Columns.Add("telefono", System.Type.GetType("System.String"));
                dtAuxiliar.Columns.Add("email", System.Type.GetType("System.String"));
                
                dtAuxiliar.Columns.Add("ccc", System.Type.GetType("System.String"));
                dtAuxiliar.Columns.Add("fecha", System.Type.GetType("System.String"));
                dtAuxiliar.Columns.Add("sexo", System.Type.GetType("System.String"));
                

                for (int i = 0; i < dv.Rows.Count; i++)
                {
                    dtAuxiliar.Rows.Add();
                    dtAuxiliar.Rows[i]["nif"] = dv.Rows[i]["nif"];
                    dtAuxiliar.Rows[i]["nombre"] = dv.Rows[i]["apellidos"] + ", " + dv.Rows[i]["nombre"];
                    dtAuxiliar.Rows[i]["direccion"] = dv.Rows[i]["direccion"] + "- " + dv.Rows[i]["cp"] + " " + dv.Rows[i]["poblacion"] + " (" + dv.Rows[i]["provi"] + ")";
                    dtAuxiliar.Rows[i]["fecha"] = dv.Rows[i]["fecha"];
                    dtAuxiliar.Rows[i]["telefono"] = dv.Rows[i]["telefono"];
                    dtAuxiliar.Rows[i]["email"] = dv.Rows[i]["email"];
                    dtAuxiliar.Rows[i]["sexo"] = dv.Rows[i]["sexo"];
                    dtAuxiliar.Rows[i]["ccc"] = dv.Rows[i]["ccc"];
                    
                }
            }
            catch (Exception e)
            {
                throw new ENException(e.Message, -1);
            }
            return dtAuxiliar;
        
        } 
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Buscar clientes en la Base de datos. Con parametros Basicos y las opciones Avanzadas </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="dni">          El dni del Cliente. </param>
        /// <param name="nombre">       El nombre del Cliente. </param>
        /// <param name="apellidos">    Los apellidos del Cliente. </param>
        /// <param name="activado">     true si activado la Parte de Opciones Avanzadas. </param>
        /// <param name="sexo">         El sexo del Cliente. </param>
        /// <param name="telefono">     El telefono del Cliente. </param>
        /// <param name="email">        El email del Cliente. </param>
        /// <param name="provincia">    La provincia del Cliente. </param>
        ///
        /// <returns>   Devuelve el DataView de la busqueda realizada en tabla clientes. </returns>
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataView BuscarClientesBD(string dni, string nombre, string apellidos, string sexo, string telefono, string email, int provincia)
        {
            CADCliente BD = new CADCliente();
            DataSet DSCliente = new DataSet();
            DataView VistaCliente = new DataView();
            try
            {
                DSCliente = BD.BuscarClientes(dni, nombre, apellidos, sexo, telefono, email, provincia);
                if (DSCliente.Tables.Count > 0)
                {
                    //Realizamos el cambio de formato del DataSet Recibido de la busqueda
                    VistaCliente = (obtenerVistaDGVCliente(DSCliente)).DefaultView;
                    DsPersonas = DSCliente.Copy();

                }
                else
                    throw new ENException("DataSet vacío", 0);
            }
            catch (CADException cex)
            {
                throw new ENException(cex.Mensaje);
            }
            return VistaCliente;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Buscar clientes en la Base de datos. Con lo parametros Basicos </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="dni">          El dni del Cliente. </param>
        /// <param name="nombre">       El nombre del Cliente. </param>
        /// <param name="apellidos">    Los apellidos del Cliente. </param>
        ///
        /// <returns>   Devuelve el DataView de la busqueda realizada en tabla clientes. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataView BuscarClientesBD(string dni, string nombre, string apellidos)
        {
            CADCliente BD = new CADCliente();
            DataSet DSCliente = new DataSet();
            DataView VistaCliente = new DataView();
            try
            {
                //Realizamos el cambio de formato del DataSet Recibido de la busqueda
                DSCliente = BD.BuscarClientes(dni, nombre, apellidos);
                if (DSCliente.Tables.Count > 0)
                {
                    VistaCliente = (obtenerVistaDGVCliente(DSCliente)).DefaultView;
                    DsPersonas = DSCliente.Copy();
                }
                else throw new ENException("DataSet vacío", 0);
            }
            catch (CADException cex)
            {
                throw new ENException(cex.Mensaje);
            }
                return VistaCliente;
            
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>  Buscar clientes en la Base de datos. Con parametros Basicos. Con Paginacion </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="dni">          El dni del Cliente. </param>
        /// <param name="nombre">       El nombre del Cliente. </param>
        /// <param name="apellidos">    Los apellidos del Cliente. </param>
        /// <param name="desde">        Valor de inicio en la Paginación. </param>
        /// <param name="cantidad">     Valor de fin en la Paginación. </param>
        ///
        /// <returns>   Devuelve el DataView de la busqueda realizada en tabla clientes. </returns>
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataView BuscarClientesBD(string dni, string nombre, string apellidos,int desde,int cantidad)
        {
            CADCliente BD = new CADCliente();
            DataSet DSCliente = new DataSet();
            DataView VistaCliente = new DataView();
            try
            {
                DSCliente = BD.BuscarClientes(dni, nombre, apellidos,desde,cantidad);
                if (DSCliente.Tables.Count > 0)
                {
                    VistaCliente = (obtenerVistaDGVCliente(DSCliente)).DefaultView;
                    DsPersonas = DSCliente.Copy();
                }
                else throw new ENException("DataSet vacío", 0);
            }
            catch (CADException cex)
            {
                throw new ENException(cex.Mensaje);
            }
            return VistaCliente;

        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Buscar clientes en la Base de datos. Con parametros Basicos y las opciones Avanzadas. Con Paginacion </summary>
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
        /// <param name="desde">        Valor de inicio en la Paginación. </param>
        /// <param name="cantidad">     Valor de fin en la Paginación. </param>
        ///
        /// <returns>   Devuelve el DataView de la busqueda realizada en tabla clientes. </returns>
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataView BuscarClientesBD(string dni, string nombre, string apellidos, string sexo, string telefono, string email, int provincia, int desde, int tamaño)
        {
            CADCliente BD = new CADCliente();
            DataSet DSCliente = new DataSet();
            DataView VistaCliente = new DataView();
            try
            {
                DSCliente = BD.BuscarClientes(dni, nombre, apellidos, sexo, telefono, email, provincia,desde,tamaño);
                if (DSCliente.Tables.Count > 0)
                {
                    VistaCliente = (obtenerVistaDGVCliente(DSCliente)).DefaultView;
                    DsPersonas = DSCliente.Copy();

                }
                else
                    throw new ENException("DataSet vacío", 0);
            }
            catch (CADException cex)
            {
                throw new ENException(cex.Mensaje);
            }
            return VistaCliente;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Obtener tamañoo consulta. </summary>
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
        /// <returns>   Obtiene el Tamaño de la consulta a realizar. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        virtual public int obtenerTamanyoConsulta(string nif,string nombre, string apellidos,string sexo, string telefono,string email,int provincia)
        {
            CADCliente cad = new CADCliente();
            DataSet dsD = new DataSet();
            int tam = 0;

            try
            {
                dsD = cad.BD_obtenerTamanyo(nif, nombre, apellidos, sexo, telefono,email, provincia);
                tam = Convert.ToInt32(dsD.Tables["Total"].Rows[0]["total"]);
            }
            catch (CADException cex)
            {
                throw new ENException(cex.Mensaje);
            }

            return tam;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Obtener tamanyo consulta. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="dni">          El dni del Cliente. </param>
        /// <param name="nombre">       El nombre del Cliente. </param>
        /// <param name="apellidos">    Los apellidos del Cliente. </param>
        ///
        /// <returns>   Obtiene el Tamaño de la consulta a realizar. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        virtual public int obtenerTamanyoConsulta(string nif, string nombre, string apellidos)
        {
            CADCliente cad = new CADCliente();
            DataSet dsD = new DataSet();
            int tam = 0;

            try
            {
                dsD = cad.BD_obtenerTamanyo(nif, nombre, apellidos);
                tam = Convert.ToInt32(dsD.Tables["Total"].Rows[0]["total"]);
            }
            catch (CADException cex)
            {
                throw new ENException(cex.Mensaje);
            }

            return tam;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Busqueda generica Con Paginacion. Busqueda en todos los campos del cliente</summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="cadena">       La cadena. </param>
        /// <param name="desde">        Valor de inicio en la Paginación. </param>
        /// <param name="cantidad">     Valor de fin en la Paginación. </param>
        ///
        /// <returns>   Devuelve el DataView de la busqueda realizada en tabla clientes. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataView BusquedaGenerica(string cadena, int desde , int tamaño)
        {
            CADCliente BD = new CADCliente();
            DataSet DSCliente = new DataSet();
            DataView VistaCliente = new DataView();
            try
            {
                DSCliente = BD.BusquedaGenericaCliente(cadena, desde, tamaño);
                if (DSCliente.Tables.Count > 0)
                {
                    VistaCliente = (obtenerVistaDGVCliente(DSCliente)).DefaultView;
                    DsPersonas = DSCliente.Copy();

                }
                else throw new ENException("DataSet vacío", 0);
            }
            catch (CADException cex)
            {
                throw new ENException(cex.Mensaje);
            }
            return VistaCliente;

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Obtener tamanyo consulta con Busqueda Generica. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="criterio"> El criterio a buscar. </param>
        ///
        /// <returns>   Obtiene el Tamaño de la consulta a realizar. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        override public int obtenerTamanyoConsulta(string criterio)
        {
            CADCliente cad = new CADCliente();
            DataSet dsD = new DataSet();
            int tam = 0;

            try
            {
                dsD = cad.BD_obtenerTamanyo(criterio);
                tam = Convert.ToInt32(dsD.Tables["Total"].Rows[0]["total"]);
            }
            catch (CADException cex)
            {
                throw new ENException(cex.Mensaje);
            }

            return tam;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Busqueda generica. Busca en todos los campos del cliente </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="cadena">   La cadena a buscar. </param>
        ///
        /// <returns>   Devuelve el DataView de la busqueda realizada en la Tabla clientes. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataView BusquedaGenerica(string cadena)
                {
            CADCliente BD = new CADCliente();
            DataSet DSCliente = new DataSet();
            DataView VistaCliente = new DataView();
            try
            {
                DSCliente = BD.BusquedaGenericaCliente(cadena);
                if (DSCliente.Tables.Count > 0)
                {
                    VistaCliente = (obtenerVistaDGVCliente(DSCliente)).DefaultView;
                    DsPersonas = DSCliente.Copy();
                    
                }
                else throw new ENException("DataSet vacío", 0);
            }
            catch (CADException cex)
            {
                throw new ENException(cex.Mensaje);
            }
                return VistaCliente;
            
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Datobtener provincias. Obtine las provincias que hay en la base de datos </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <returns>   Devuelve el DataView con las Provincias de la Base de Datos. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataView datobtenerProvinciasBD()
        {
            DataView dsprovincias = new DataView();
            CADCliente cad = new CADCliente();
            try
            {
                dsprovincias = (cad.BD_obtenerProvincias()).Tables["Provincias"].DefaultView;
            }
            catch (CADException cex)
            {
                throw new ENException(cex.Mensaje);
            }
            return dsprovincias;


            

        }



    }
}
