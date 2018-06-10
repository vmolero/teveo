////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	TVO_EntidadesDeNegocio\ENPersona.cs
//
// summary:	Implementa la Entidad de Negocio (EN) ENPersona
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
    /// <summary>   Enumerado que representa los valores de kPerfil. </summary>
    /// <list type="bullet">
    ///     <listheader>
    ///         <term>kPerfil</term>
    ///         <description>Enum de perfil</description>
    ///     </listheader>
    ///     <item>
    ///         <term>pNinguno</term>
    ///         <description>Valor -1. Representa a ninguno o a todos, en función del caso</description>
    ///         <term>pModerador</term>
    ///         <description>Valor 0</description>
    ///         <term>pTecnico</term>
    ///         <description>Valor 1</description>
    ///     </item>
    ///</list>
    /// <remarks>   . </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public enum kPerfil
    {
        pNinguno=-1,
        pModerador,
        pTecnico,
        
    }
    
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Clase pública ENPersona. Se encarga de la lógica de negocio de la aplicación, haciendo 
    /// de puente entre la capa de presentación y el Acceso a Datos.</summary>
    ///
    /// <remarks>   . </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public class ENPersona
    {
        /// <summary> Atributo de tipo string que representa el NIF.  </summary>
        private string dni;
        /// <summary> Atributo de tipo string que representa el Nombre.  </summary>
        private string nombre;
        /// <summary> Atributo de tipo string que representa la clave de acceso.  </summary>
        private string clave;
        /// <summary> Atributo de tipo string que representa los Apellidos.  </summary>
        private string apellidos;
        /// <summary> Atributo de tipo string que representa el Correo electrónico.  </summary>
        private string email;
        /// <summary> Atributo de tipo string que representa el Teléfono.  </summary>
        private string telefono;
        /// <summary> Atributo de tipo string que representa la Dirección.  </summary>
        private string direccion;
        /// <summary> Atributo de tipo string que representa la Población.  </summary>
        private string poblacion;
        /// <summary> Atributo de tipo string que representa el Código Postal.  </summary>
        private string cp;
        /// <summary> Atributo de tipo string que representa la cuenta bancaria.  </summary>
        private string ccc;
        /// <summary> Atributo de tipo int que representa la Provincia.  </summary>
        private int provincia;
        /// <summary> Atributo de tipo kPerfil que representa el Perfil.  </summary>
        private kPerfil perfil;
        /// <summary> Atributo de tipo byte[] que representa la imagen.  </summary>
        private byte[] imgData;
        /// <summary> Atributo de tipo string que representa la fecha </summary>
        private DateTime fecha;
        /// <summary> Atributo de tipo string que representa el sexo </summary>
        private string sexo;
        /// <summary> Atributo de tipo DataSet que contiene la información de Personas.  </summary>
        private DataSet dsPersonas;


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor por Defecto. </summary>
        ///
        /// <remarks>   . </remarks>
        ///
        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        public ENPersona() 
        {
            this.dni = "";
            this.clave = "";
            this.nombre = "";
            this.apellidos = "";
            this.email = "";
            this.telefono = "" ;
            this.direccion = "";
            this.ccc = "";
            this.provincia = -1;
            this.poblacion = "";
            this.perfil = kPerfil.pNinguno;
            this.imgData = null;
            dsPersonas = new DataSet();
            this.fecha = System.DateTime.Today;
            this.sexo = "";
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Contructor Persona Parametrizado 1. </summary>
        ///
        /// <remarks>   . </remarks>
        ///
        /// <param name="nif">  The nif. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public ENPersona(string nif)
        {
            this.dni = nif;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Contructor Persona Parametrizado 2. </summary>
        ///
        /// <remarks>   . </remarks>
        ///
        /// <param name="nif">      NIF. </param>
        /// <param name="clave">    Clave de acceso. </param>
        ///
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public ENPersona(string nif, string clave)
        {
            this.dni = nif;
            this.clave = clave;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Contructor Persona Parametrizado 2. </summary>
        ///
        /// <remarks>   . </remarks>
        ///
        /// <param name="dni">          NIF. </param>
        /// <param name="clave">        Clave de acceso. </param>
        /// <param name="nombre">       Nombre. </param>
        /// <param name="apellidos">    Apellidos. </param>
        /// <param name="email">        Correo electrónico. </param>
        /// <param name="telefono">     Teléfono. </param>
        /// <param name="direccion">    Dirección. </param>
        /// <param name="poblacion">    Población. </param>
        /// <param name="ccc">          Cuenta bancaria. </param>
        /// <param name="provincia">    Provincia. </param>
        /// <param name="ciudad">       Población. </param>
        /// <param name="perfil">       Perfil. </param>
        /// <param name="fecha">        Fecha. </paramn>
        /// <param name="sexo">         Sexo. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public ENPersona(string dni, string clave, string nombre, string apellidos,string sexo,DateTime fecha, string email, string telefono, string direccion, string poblacion, string ccc, int provincia, string cp) 
        {
            this.dni=dni;
            this.clave = clave;
            this.nombre= nombre;
            this.apellidos=apellidos;
            this.email=email;
            this.telefono=telefono;
            this.direccion=direccion;
            this.ccc=ccc;
            this.provincia=provincia;
            this.poblacion=poblacion;
            this.cp = cp;
            
            this.fecha = fecha;
            this.sexo = sexo;
        }
        /// <summary>
        /// get y set dni
        /// </summary>
        public string Dni
        {
            get { return dni; }
            set { dni = value; }
        }
        /// <summary>
        /// get y set clave
        /// </summary>
        public string Clave
        {
            get { return clave; }
            set { clave = value; }
        }
        /// <summary>
        /// get y set nombre
        /// </summary>
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        /// <summary>
        /// get y set apellidos
        /// </summary>
        public string Apellidos
        {
            get { return apellidos; }
            set { apellidos = value; }
        }
        
        /// <summary>
        /// get y set email
        /// </summary>
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        /// <summary>
        /// get y set telefono
        /// </summary>
        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
        /// <summary>
        /// get y set direccion
        /// </summary>
        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }
        /// <summary>
        /// get y set ccc
        /// </summary>
        public string CCC
        {
            get { return ccc; }
            set { ccc = value; }
        }
        /// <summary>
        /// get y set provincia
        /// </summary>
        public int Provincia
        {
            get { return provincia; }
            set { provincia = value; }
        }
        /// <summary>
        /// get y set cp
        /// </summary>
        public string CP
        {
            get { return cp; }
            set { cp = value; }
        }
        
        /// <summary>
        /// get y set ciudad
        /// </summary>
        public string Poblacion
        {
            get { return poblacion; }
            set { poblacion = value; }
        }
        /// <summary>
        /// get y set perfil
        /// </summary>
        public kPerfil Perfil
        {
            get { return perfil; }
            set { perfil = value; }
        }

        /// <summary>
        /// get y set imgData
        /// </summary>
        public byte[] ImgData
        {
            get { return imgData; }
            set { imgData = value; }
        }
        /// <summary>
        /// get y set fecha
        /// </summary>

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        /// <summary>
        /// get y set sexo
        /// </summary>
        public string Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }
        /// <summary>
        /// get y set DsPersonas
        /// </summary>
        protected DataSet DsPersonas
        {
            get { return dsPersonas; }
            set { dsPersonas = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Método virtual obtenerAcceso. Permite validad al objeto como usuario
        /// de la aplicación.</summary>
        /// <remarks>   . </remarks>
        ///
        /// <exception cref="CADException">Se recoge cuando existe algún problema en el CADPersona</exception>
        /// <exception cref="ENException">Se lanza si se ha recogido una CADException.</exception>
        /// 
        /// <returns>   Devuelve el propio objeto. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        virtual public ENPersona obtenerAcceso()
        {
            CADPersona cad = new CADPersona();
            Hashtable persona = new Hashtable();
            try
            {

                persona = cad.BD_obtenerPersona(this.Dni, this.Clave);

                Perfil = (kPerfil)Convert.ToInt32(persona["perfil"]);

                if (Perfil != kPerfil.pNinguno)
                {
                    Nombre = Convert.ToString(persona["nombre"]);
                    Apellidos = Convert.ToString(persona["apellidos"]);
                    ImgData = (byte[]) persona["foto"];
                }
            }
            catch (InvalidCastException ice)
            {
                persona["foto"] = null;
            }
            catch (CADException ex)
            {
                if (ex.Tipo != -1) throw new ENException(ex.Mensaje, ex.Tipo);
                else throw new ENException(ex.Mensaje, ex.SQLex);
            }
            return this;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Método virtual Insertar persona. </summary>
        ///
        /// <remarks>   . </remarks>
        ///
        /// <exception cref="CADException">Se recoge cuando existe algún problema en el CADPersona</exception>
        /// <exception cref="ENException">Se lanza si se ha recogido una CADException.</exception>
        /// 
        /// <returns>   Entero que representa el estado de haber realizado la inserción. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        virtual public int insertarPersona()
        {
            CADPersona cad = new CADPersona(); // string poblacion, string cp, string provincia, string pais, string email, string telefono, string ccc, int perfil
            int estado = -1;
            try
            {
                // if si hay foto: nuevo metodo sobrecargado
                // si no llamar al actual
                if (ImgData != null) estado = cad.BD_insertarPersona(Dni, Clave, Nombre, Apellidos, Direccion, Poblacion, CP, Provincia, Email, Telefono, CCC, (int)Perfil, ImgData);
                else estado = cad.BD_insertarPersona(Dni, Clave, Nombre, Apellidos, Direccion, Poblacion, CP, Provincia, Email, Telefono, CCC, (int)Perfil);
            }
            catch (CADException cex)
            {
                throw new ENException(cex.Mensaje);
            }
            return estado;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Método virtual Modificar persona. </summary>
        ///
        /// <remarks>   . </remarks>
        /// 
        /// <exception cref="CADException">Se recoge cuando existe algún problema en el CADPersona</exception>
        /// <exception cref="ENException">Se lanza si se ha recogido una CADException.</exception>
        ///
        /// <returns>   Entero que representa el estado de haber realizado la modificación.  </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        virtual public int modificarPersona()
        {
            CADPersona cad = new CADPersona(); 
            int estado = -1;
            try
            {
                if (ImgData != null) estado = cad.BD_modificarPersona(Dni, Clave, Nombre, Apellidos, Direccion, Poblacion, CP, Provincia, Email, Telefono, CCC, (int)Perfil, ImgData);
                else estado = cad.BD_modificarPersona(Dni, Clave, Nombre, Apellidos, Direccion, Poblacion, CP, Provincia, Email, Telefono, CCC, (int)Perfil);   
            }
            catch (CADException cex)
            {
                throw new ENException(cex.Mensaje);
            }
            return estado;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Método virtual Eliminar persona. </summary>
        ///
        /// <remarks>   . </remarks>
        /// 
        /// <exception cref="CADException">Se recoge cuando existe algún problema en el CADPersona</exception>
        /// <exception cref="ENException">Se lanza si se ha recogido una CADException.</exception>
        ///
        /// <returns>   Entero que representa el estado de haber realizado el borrado.  </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        virtual public int eliminarPersona()
        {
            CADPersona cad = new CADPersona(); // string poblacion, string cp, string provincia, string pais, string email, string telefono, string ccc, int perfil
            int estado = -1;
            try
            {
                estado = cad.BD_eliminarPersona(Dni);
                // estado = cad.BD_modificarPersona(dsPersonas);
            }
            catch (CADException cex)
            {
                throw new ENException(cex.Mensaje);
            }
            return estado;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary> Método virtual. Obtiene el número de filas como resultado de una consulta. Realiza una consulta a la Base de Datos con los
        /// criterios de búsqueda seleccionados y obtiene la cantidad de filas afectadas. Este método
        /// se usa como preparación para la fucnionalidad de paginación, permitiendo ajustar los componentes
        /// visuales.</summary>
        ///
        /// <remarks>   . </remarks>
        ///
        /// <exception cref="CADException">Se recoge cuando existe algún problema en el CADPersona</exception>
        /// <exception cref="ENException">Se lanza si se ha recogido una CADException.</exception>
        /// 
        /// <param name="nif">      NIF que identifica a a la persona. </param>
        /// <param name="nombre">   Nombre o Apellido. Si se usa "" no se tendrá en cuenta en la búsqueda</param>
        /// <param name="email">    Correo electrónico. Si se usa "" no se tendrá en cuenta en la búsqueda</param>
        /// <param name="perfil">   Perfil. Entero que representa el perfil. Si su valor es -1, no se tiene en cuenta en la búsqueda. </param>
        ///
        /// <returns>Entero que representa el número de filas de la consulta. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        virtual public int obtenerTamanyoConsulta(string nif, string nombre, string email, kPerfil perfil)
        {
            CADPersona cad = new CADPersona();
            DataSet dsD = new DataSet();
            int tam = 0;

            try
            {
                dsD = cad.BD_obtenerTamanyo(nif, nombre, email, (int) perfil);
                tam = Convert.ToInt32(dsD.Tables["Total"].Rows[0]["total"]);
            }
            catch (CADException cex)
            {
                throw new ENException(cex.Mensaje);
            }

            return tam;
        }

        virtual public int obtenerTamanyoConsulta(string criterio)
        {
            CADPersona cad = new CADPersona();
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
        /// <summary>  Sobrecargado (1). Método virtual Obtener personas. Obtiene un DataView generado desde una DataSet con el
        /// resultado de la consulta y que queda preparado para ser mostrado en la parte visual.</summary>
        ///
        /// <remarks>   . </remarks>
        ///
        /// <exception cref="CADException">Se recoge cuando existe algún problema en el CADPersona</exception>
        /// <exception cref="ENException">Se lanza si se ha recogido una CADException o si el Datase está vacío.</exception>
        /// 
        /// <param name="nif">      NIF que identifica a a la persona. </param>
        /// <param name="nombre">   Nombre o Apellido. Si se usa "" no se tendrá en cuenta en la búsqueda</param>
        /// <param name="email">    Correo electrónico. Si se usa "" no se tendrá en cuenta en la búsqueda</param>
        /// <param name="perfil">   Perfil. Entero que representa el perfil. Si su valor es -1, no se tiene en cuenta en la búsqueda. </param>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        virtual public DataView obtenerPersonas(string nif, string nombre, string email, kPerfil perfil)
        {
            CADPersona cad = new CADPersona();
            DataView dvPersonas = new DataView();
            ArrayList contenedor = new ArrayList();

            DataSet dsRes = new DataSet();
            try
            {

                dsRes = cad.BD_obtenerPersonas(nif, nombre, email, (int)perfil);
                
                if (dsRes.Tables.Count > 0)
                {
                    dvPersonas = (ObtenerVistaPersonas(dsRes)).DefaultView;
                    dsPersonas = dsRes.Copy();
                }
                else throw new ENException("DataSet vacío", 0);
            }
            catch (CADException cex)
            {
                throw new ENException(cex.Mensaje);
            }
            return dvPersonas;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   
        /// Sobrecargado (1). Método virtual Obtener personas. Obtiene un DataView generado desde una
        /// DataSet con el resultado de la consulta y que queda preparado para ser mostrado en la parte
        /// visual. 
        /// </summary>
        ///
        /// 
        /// <remarks>   EL DataTable obtenido por el método <see cref="ObtenerVistaPersona">ObtenerVistaPersona</see>, se trasforma a DataView
        /// y se devuelve a la vista. . </remarks>
        ///
        /// <exception cref="CADException"> Se recoge cuando existe algún problema en el CADPersona. </exception>
        /// <exception cref="ENException">  Se lanza si se ha recogido una CADException o si el
        /// 
        /// <param name="nif">      NIF que identifica a a la persona. </param>
        /// <param name="nombre">   Nombre o Apellido. Si se usa "" no se tendrá en cuenta en la
        ///                         búsqueda. </param>
        /// <param name="email">    Correo electrónico. Si se usa "" no se tendrá en cuenta en la
        ///                         búsqueda. </param>
        /// <param name="perfil">   Perfil. Entero que representa el perfil. Si su valor es -1, no se
        ///                         tiene en cuenta en la búsqueda. </param>
        /// <param name="desde">    Valor entero que representa el registro desde el cual se obtendrán los datos. </param>
        /// <param name="cantidad"> Valor entero que representa cuantos registros como máximo debemos obtener apartir de 'desde'. </param>
        ///
        /// <returns>   . </returns>
        ///
        ///                                     Datase está vacío. </exception>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        virtual public DataView obtenerPersonas(string nif, string nombre, string email, kPerfil perfil, int desde, int cantidad)
        {
            CADPersona cad = new CADPersona();
            DataView dvPersonas = new DataView();
            ArrayList contenedor = new ArrayList();

            DataSet dsRes = new DataSet();
            try
            {

                dsRes = cad.BD_obtenerPersonas(nif, nombre, email, (int)perfil, desde, cantidad);

                if (dsRes.Tables.Count > 0)
                {
                    dvPersonas = (ObtenerVistaPersonas(dsRes)).DefaultView;
                    dsPersonas = dsRes.Copy();
                }
                else throw new ENException("DataSet vacío", 0);
            }
            catch (CADException cex)
            {
                throw new ENException(cex.Mensaje);
            }
            return dvPersonas;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Método Obtener vista personas. Prepara el DataSet pasado por parámatro y lo convierte
        /// en un DataTable.</summary>
        ///
        /// <remarks>   Se recorre el DataSet (que debe de contener una tabla "Personas") y fila a fila se construye 
        /// el DataTable. . </remarks>
        ///
        /// <exception cref="Exception">  Se lanza si se el DataSet no contiene la tabla "Personas" o no existen las columnas especificadas</exception>
        /// <param name="ds">   DataSet de Personas. </param>
        ///
        /// <returns>   DataTable preparado para ser devuelto a la vista. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public DataTable ObtenerVistaPersonas(DataSet ds)
        {
            DataTable dtAux = new DataTable("Personas");
            DataTable dv = new DataTable();

            try
            {
                dv = ds.Tables["Personas"];

                //byte[] vBytes = new byte();

                
                dtAux.Columns.Add("nif", System.Type.GetType("System.String"));
                dtAux.Columns.Add("nombre", System.Type.GetType("System.String"));
                dtAux.Columns.Add("direccion", System.Type.GetType("System.String"));
                dtAux.Columns.Add("email", System.Type.GetType("System.String"));
                dtAux.Columns.Add("telefono", System.Type.GetType("System.String"));
                dtAux.Columns.Add("perfil", System.Type.GetType("System.String"));
                dtAux.Columns.Add("ccc", System.Type.GetType("System.String"));
                // dtAux.Columns.Add("foto", System.Type.GetTypeArray(vBytes));


                for (int j = 0; j < dv.Rows.Count; j++)
                {
                    dtAux.Rows.Add();
                    dtAux.Rows[j]["nif"] = dv.Rows[j]["nif"];
                    dtAux.Rows[j]["nombre"] = dv.Rows[j]["apellidos"].ToString() + ", " + dv.Rows[j]["nombre"].ToString();
                    dtAux.Rows[j]["direccion"] = dv.Rows[j]["direccion"].ToString() + "- " + dv.Rows[j]["cp"].ToString() + " " + dv.Rows[j]["poblacion"].ToString() + " (" + dv.Rows[j]["kprovincia"].ToString() + ")";
                    dtAux.Rows[j]["email"] = dv.Rows[j]["email"];
                    dtAux.Rows[j]["telefono"] = dv.Rows[j]["telefono"];
                    dtAux.Rows[j]["perfil"] = dv.Rows[j]["kperfil"];
                    dtAux.Rows[j]["ccc"] = dv.Rows[j]["ccc"];
                    // dtAux.Rows[j]["foto"] = dv.Rows[j]["foto"];
                }
            }
            catch (Exception e)
            {
                throw new ENException(e.Message, -1);
            }

            return dtAux;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Método Obtener perfiles. </summary>
        ///
        /// <remarks>   . </remarks>
        ///
        /// <exception cref="CADException">Se recoge cuando existe algún problema en el CADPersona</exception>
        /// <exception cref="ENException">Se lanza si se ha recogido una CADException.</exception>
        ///
        /// <returns>   ArrayList con los perfiles devueltos por el CADPersona. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        virtual public ArrayList obtenerPerfiles()
        {
            CADPersona cad = new CADPersona();
            ArrayList alPerfiles = new ArrayList();

            try
            {
                alPerfiles = cad.BD_obtenerPerfiles();
            }
            catch (CADException cex)
            {
                throw new ENException(cex.Mensaje);
            }

            return alPerfiles;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Método Obtener provincias. </summary>
        ///
        /// <remarks>   El DataView que se construye está pensado para ser usado en un componente visual de tipo
        /// ComboBox. . </remarks>
        ///
        /// <returns>   Devuelve el DataView con las provincias. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public DataView obtenerProvincias()
        {
            CADPersona cad = new CADPersona();
            DataView dvProvincias = new DataView();
            DataSet ds = new DataSet();
            try
            {
                ds = cad.BD_obtenerProvincias();
                dvProvincias = ds.Tables["Provincia"].DefaultView;
            }
            catch (CADException cex)
            {
                throw new ENException(cex.Mensaje);
            }

            return dvProvincias;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sobrecargado (1) Método ObtenerDelDataSet. Permite obtener un dato de un DataSet.</summary>
        ///
        /// <remarks>   Para obtener el dato se acceso a la tabla, la fila y la columna. 
        /// . </remarks>
        ///
        /// <exception cref="NullReferenceException">Si el DataSet está vacío o no existe la Tabla o la fila o la columna.</exception>
        /// <exception cref="ENException">Se lanza si se ha recogido una NullReferenceException.</exception>
        /// 
        /// <param name="tabla">    Tabla del DataSet. </param>
        /// <param name="fila">     Fila de la Tabla del DataSet. </param>
        /// <param name="columna">  Columna de la fila de la tabla del DataSet. </param>
        ///
        /// <returns>   Cadena con el dato. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public string obtenerDelDataSet(string tabla, int fila, string columna)
        {
            string dato="";
            
            try 
            {
                dato = dsPersonas.Tables[tabla].Rows[fila][columna].ToString();
            }
            catch (NullReferenceException nre)
            {
                throw new ENException("DataSet vacío: " + nre.Message, 0);
            }
            return dato;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sobrecargado (2) Método ObtenerDelDataSet. Permite obtener un dato de un DataSet.</summary>
        ///
        /// <remarks>   Para obtener el dato se acceso a la tabla, la fila y la columna. 
        /// . </remarks>
        ///
        /// <exception cref="NullReferenceException">Si el DataSet está vacío o no existe la Tabla o la fila o la columna.</exception>
        /// <exception cref="ENException">Se lanza si se ha recogido una NullReferenceException.</exception>
        /// 
        /// <param name="tabla">    Tabla del DataSet. </param>
        /// <param name="fila">     Fila de la Tabla del DataSet. </param>
        /// <param name="columna">  Columna de la fila de la tabla del DataSet. </param>
        ///
        /// <returns>   Cadena con el dato. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public string obtenerDelDataSet(int tabla, int fila, int columna)
        {
            string dato = "";

            try
            {
                dato = dsPersonas.Tables[tabla].Rows[fila][columna].ToString();
            }
            catch (NullReferenceException nre)
            {
                throw new ENException("DataSet vacío: " + nre.Message, 0);
            }
            return dato;
        }

        public byte[] obtenerImagenDelDataSet(string tabla, int fila, string columna)
        {
            byte[] dato = null;

            try
            {
                dato = (byte[])dsPersonas.Tables[tabla].Rows[fila][columna];
            }
            catch (InvalidCastException ice)
            {
                dato = null;
            }
            catch (NullReferenceException nre)
            {
                throw new ENException("DataSet vacío: " + nre.Message, 0);
            }
            return dato;
        }

        virtual public DataView obtenerBusquedaRapida(string criterio)
        {
            CADPersona cad = new CADPersona();
            DataView dvPersonas = new DataView();
            
            DataSet dsRes = new DataSet();
            try
            {

                dsRes = cad.BD_obtenerBusquedaRapida(criterio);

                if (dsRes.Tables.Count > 0)
                {
                    dvPersonas = (ObtenerVistaPersonas(dsRes)).DefaultView;
                    dsPersonas = dsRes.Copy();
                }
                else throw new ENException("DataSet vacío", 0);
            }
            catch (CADException cex)
            {
                throw new ENException(cex.Mensaje);
            }
            return dvPersonas;
        }

        virtual public DataView obtenerBusquedaRapida(string criterio, int desde, int cantidad)
        {
            CADPersona cad = new CADPersona();
            DataView dvPersonas = new DataView();

            DataSet dsRes = new DataSet();
            try
            {

                dsRes = cad.BD_obtenerBusquedaRapida(criterio, desde, cantidad);

                if (dsRes.Tables.Count > 0)
                {
                    dvPersonas = (ObtenerVistaPersonas(dsRes)).DefaultView;
                    dsPersonas = dsRes.Copy();
                }
                else throw new ENException("DataSet vacío", 0);
            }
            catch (CADException cex)
            {
                throw new ENException(cex.Mensaje);
            }
            return dvPersonas;
        }
        
    }
}