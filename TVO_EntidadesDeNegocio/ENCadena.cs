////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	TVO_EntidadesDeNegocio\ENCadena.cs
//
// summary:	Implements el entidad negocio de la clase cadena.
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using TVO_ComponentesAccesoDatos;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace TVO_EntidadesDeNegocio
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Enumerado utilizado para representar los diferentes tipos de cadena, kTipo. </summary>
    ///
    /// <remarks>   TVO DPAA 2009-2010. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public enum kTipo
    {
        Todos = 0,
        Generalista,
        Deportes,
        Notícias,
        Cocina,
        Musical,
        Cine,
        Documentales,
        Ocio
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Clase entidad negocio de cadena. </summary>
    ///
    /// <remarks>   TVO DPAA 2009-2010. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class ENCadena
    {
       /// <summary>
  ///-------- Variables Cadena
       /// </summary>
        private int id_cadena;
        private string nombre;
        private string tipo;
        private bool activo;
        private ArrayList misprogramas;
        private DataSet dsCadenas;
  ///Variables Cadena--------

 ///-------- MÉTODOS

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor por defecto Cadena. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ENCadena()
        {
            nombre="";
            tipo="";
            activo=false;
            dsCadenas=new DataSet();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   //Constructor parametrizado(id de cadena, nombre, tipo). </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="nombre">   The nombre. </param>
        /// <param name="tipo">     The tipo. </param>
        /// <param name="activo">   true to activo. </param>
        ///
        /// ### <param name="id_Cadena">    . </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ENCadena(string nombre, string tipo, bool activo)
        {
            this.nombre = nombre;
            this.tipo = tipo;
            this.activo = activo;
            dsCadenas = new DataSet();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   //Constructor parametrizado (id de cadena, nombre, tipo ,estado). </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="idC">      The identifier c. </param>
        /// <param name="nombre">   The nombre. </param>
        /// <param name="tipo">     The tipo. </param>
        /// <param name="activo">   true to activo. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ENCadena(int idC,string nombre, string tipo, bool activo)
        {
            id_cadena=idC;
            this.nombre = nombre;
            this.tipo = tipo;
            this.activo = activo;
            dsCadenas = new DataSet();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   //Constructor parametrizado a partir de un nombre y un tipo de cadena. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="nombre">   The nombre. </param>
        /// <param name="tipo">     The tipo. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ENCadena(string nombre, string tipo)
        {
            this.nombre = nombre;
            this.tipo = tipo;
            dsCadenas = new DataSet();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor por defecto Cadena a partir de un nombre. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="nombre">   The nombre. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ENCadena(string nombre)
        {
            this.nombre = nombre;
            dsCadenas = new DataSet();
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Obtiene los  tipos cadenas en un arraylist. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ArrayList ObtenerTiposCadenas()
        {
            ArrayList listaTipos = new ArrayList();

                foreach (string tipo in Enum.GetNames(typeof(kTipo)))
                {
                    listaTipos.Add(tipo);
                }
            return listaTipos;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Devuelve el nombre de una cadena. </summary>
        ///
        /// <value> The nombre. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        //getters y setters
        public int Id
        {
            get { return id_cadena; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Devuelve el tipo de una cadena. </summary>
        ///
        /// <value> The tipo. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Devuelve el valor de activo (true si la cadena está activada, false en caso contrario). </summary>
        ///
        /// <value> true if activo, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool Activo
        {
            get { return activo; }
            set { activo = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Devuelve un array list con los programas que pertenecen a la cadena. </summary>
        ///
        /// <value> The mis programas. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ArrayList MisProgramas
        {
            get { return misprogramas; }
            set { misprogramas = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Obtiene los diferentes tipos de cadena existentes. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="ENException">  Thrown when en. </exception>
        ///
        /// <param name="nombreCadena"> The nombre cadena. </param>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ArrayList ObtenerTipos(string nombreCadena)
        {
            DataSet dsTipos = new DataSet();
            DataTable dtTipos = new DataTable();
            CADCadena cad = new CADCadena();
            ArrayList alistTipos= new ArrayList();

            try
            {
                dsTipos = cad.ObtenerTiposBD(nombreCadena);
                dtTipos = dsTipos.Tables["tipo"];

                foreach (DataRow fila in dtTipos.Rows)
                {
                    alistTipos.Add(fila["tipo"].ToString());
                }
            }
            catch (CADException cadex)
            {
                throw new ENException(cadex.Mensaje);
            }
            catch (NullReferenceException nullExcep)
             {
                throw new ENException(nullExcep.Message);
             }

            return alistTipos;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   INSERTAR: Inserta una cadena en la base de datos. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="ENException">  Thrown when en. </exception>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        virtual public int insertarCadena()
        {
            CADCadena cad = new CADCadena();
            int insertado = 0;

            try
            {
                insertado = cad.BD_insertarCadena(nombre, tipo, activo);
            }
            catch (CADException cadex)
            {
                throw new ENException(cadex.Mensaje);
            }

            return insertado;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   BUSCAR: busca una cadena en la BD. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="ENException">  Thrown when en. </exception>
        ///
        /// <param name="nombreCadena"> The nombre cadena. </param>
        /// <param name="tipoCadena">   The tipo cadena. </param>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataView buscarCadena(string nombreCadena, string tipoCadena)
        {
            CADCadena cadenaBuscar = new CADCadena();
            DataView dvResultBusq = new DataView();

            try
            {

                dsCadenas = cadenaBuscar.buscarCadenaBD(nombreCadena,tipoCadena);

                if (dsCadenas.Tables.Count > 0)
                    dvResultBusq = VistaCadenas(dsCadenas);
                else
                    throw new ENException("DataSet vacío",-1);
            }
            catch(CADException cadex)
            {
                throw new ENException(cadex.Mensaje);
            }

            return dvResultBusq;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   BUSCAR: busca una cadena en la BD. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="ENException">  Thrown when en. </exception>
        ///
        /// <param name="buscRapida">   The busc rapida. </param>
        ///
        /// <returns>   . </returns>
        ///
        /// ### <param name="nombreCadena"> . </param>
        /// ### <param name="tipoCadena">   . </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataView buscarCadena(string buscRapida)
        {
            CADCadena cadenaBuscarRap = new CADCadena();
            DataView dvResultBusq = new DataView();

            try
            {

                dsCadenas = cadenaBuscarRap.buscarCadenaBD(buscRapida);

                if (dsCadenas.Tables.Count > 0)
                    dvResultBusq = VistaCadenas(dsCadenas);
                else
                    throw new ENException("DataSet vacío", -1);
            }
            catch (CADException cadex)
            {
                throw new ENException(cadex.Mensaje);
            }

            return dvResultBusq;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Vista cadenas. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="ENException">  Thrown when en. </exception>
        ///
        /// <param name="dsC">  The ds c. </param>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private DataView VistaCadenas(DataSet dsC)
        {
            DataTable resultBusc = new DataTable("Cadenas");
            try
            {
                resultBusc = dsC.Tables["Cadenas"].Copy();

                //Me copio todo y le añado únicamente la columna q me falta y los datos de esa columna

                resultBusc.Columns.Add("ActivadaCadena", System.Type.GetType("System.String"));

                for (int i = 0; i < resultBusc.Rows.Count; i++)
                {
                    if ((int)resultBusc.Rows[i]["activo"] == 0)
                        resultBusc.Rows[i]["ActivadaCadena"] = "No";
                    else
                        resultBusc.Rows[i]["ActivadaCadena"] = "Sí";
                }
            }
            catch (NullReferenceException nre)
            {
                throw new ENException("DataSet vacío", 0);
            }
            catch (CADException cadex)
            {
                throw new ENException(cadex.Mensaje);
            }

            return resultBusc.DefaultView;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   MODIFICAR: Modifica una cadena. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="ENException">  Thrown when en. </exception>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        virtual public int modificarCadena()
        {
            CADCadena cad = new CADCadena();
            int modificado = 0;

            try
            {
                modificado = cad.modificarCadenaBD(id_cadena, nombre, tipo, activo);

            }
            catch (CADException cadex)
            {
                throw new ENException(cadex.Mensaje);
            }
            return modificado;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   ELIMINAR: elimina una cadena de la BD. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="ENException">  Thrown when en. </exception>
        ///
        /// <param name="idCad">    The identifier cad. </param>
        ///
        /// <returns>   true if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool eliminarCadena(int idCad)
        {
            CADCadena cad = new CADCadena(); 
            int eliminado = 0;
            bool eliminadaFila = false;
                try
                {
                    eliminado = cad.eliminarCadenaBD(idCad);
                }
                catch (CADException cex)
                {
                    throw new ENException(cex.Mensaje);
                }
                if (eliminado > 0)
                    eliminadaFila = true;

            return eliminadaFila;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Obtiene la lista de cadenas. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="ENException">  Thrown when en. </exception>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataView ObtenerListaCadenas()
        {
            CADCadena cadena = new CADCadena();
            DataSet ds = new DataSet();
            DataTable tabla = new DataTable();
            DataView dv = new DataView();
            DataRow fila;

            try
            {
                ds = cadena.ObtenerCadenasBD();

                tabla = ds.Tables["TCadenas"];

                if (tabla.Rows.Count > 0)
                {
                    //Añado una primera fila que pone "Todas"
                    fila = tabla.NewRow();
                    fila["id"] = -1;
                    fila["nombre"] = "Todas";

                    tabla.Rows.InsertAt(fila, 0);
                }

            }
            catch (CADException cadex)
            {
                throw new ENException(cadex.Mensaje);
            }
            catch (NullReferenceException ex)
            {
                throw new ENException(ex.Message);
            }

            return tabla.DefaultView;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Obtener del data set. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="ENException">  Thrown when en. </exception>
        ///
        /// <param name="tabla">    The tabla. </param>
        /// <param name="fila">     The fila. </param>
        /// <param name="columna">  The columna. </param>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string obtenerDelDataSet(string tabla, int fila, string columna)
        {
            string elemento = "";

            try
            {
                elemento = dsCadenas.Tables[tabla].Rows[fila][columna].ToString();
            }
            catch (NullReferenceException nre)
            {
                throw new ENException("DataSet vacío", -1);
            }
            return elemento;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Obtener id cadena. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="ENException">  Thrown when en. </exception>
        ///
        /// <param name="indice">       The indice. </param>
        /// <param name="nombreCadena"> The nombre cadena. </param>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int ObtenerIdCadena(int indice, string nombreCadena)
        {
            int id = -1;
            CADCadena cadena = new CADCadena();
            try
            {
                if (indice != -1)
                {
                    id = int.Parse(cadena.ObtenerIdCadena(nombreCadena));
                }
            }
            catch (CADException cex)
            {
                throw new ENException(cex.Mensaje);
            }
            return id;
        }

        ///Método auxiliar para rellenar los comboboxes

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Obtiene la lista de cadenas. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="ENException">  Thrown when en. </exception>
        ///
        /// <param name="ftodas">   true to ftodas. </param>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        virtual public DataView ObtenerListaCadenas( bool ftodas)
        {
            CADCadena cadena = new CADCadena();
            DataSet ds = new DataSet();
            DataTable tabla = new DataTable();
            DataView dv = new DataView();
            DataRow fila;

            try
            {
                ds = cadena.ObtenerCadenasBD();

                tabla = ds.Tables["TCadenas"];

                if (tabla.Rows.Count > 0 && ftodas)
                {
                    //Añado una primera fila que pone "Todas"
                    fila = tabla.NewRow();
                    fila["id"] = -1;
                    fila["nombre"] = "Todas";

                    tabla.Rows.InsertAt(fila, 0);
                }

            }
            catch (CADException cadex)
            {
                throw new ENException(cadex.Mensaje);
            }
            catch (NullReferenceException ex)
            {
                throw new ENException(ex.Message);
            }

            return tabla.DefaultView;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Obtener lista tematicas. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="ENException">  Thrown when en. </exception>
        ///
        /// <param name="ftodas">   true to ftodas. </param>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public object ObtenerListaTematicas(bool ftodas)
        {
            CADCadena cadena = new CADCadena();
            DataSet ds = new DataSet();
            DataTable tabla = new DataTable();
            DataView dv = new DataView();
            DataRow fila;

            try
            {
                ds = cadena.ObtenerTematicasBD();

                tabla = ds.Tables["TTematicas"];

                if (tabla.Rows.Count > 0 && ftodas)
                {
                    //Añado una primera fila que pone "Ninguna"
                    fila = tabla.NewRow();
                    fila["id"] = -1;
                    fila["nombre"] = "Todas";

                    tabla.Rows.InsertAt(fila, 0);

                }

            }
            catch (CADException cadex)
            {
                throw new ENException(cadex.Mensaje);
            }
            catch (NullReferenceException ex)
            {
                throw new ENException(ex.Message);
            }

            return tabla.DefaultView;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Obtener lista calificaciones. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="ENException">  Thrown when en. </exception>
        ///
        /// <param name="ftodas">   true to ftodas. </param>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public object ObtenerListaCalificacion(bool ftodas)
        {
            CADCadena cadena = new CADCadena();
            DataSet ds = new DataSet();
            DataTable tabla = new DataTable();
            DataView dv = new DataView();
            DataRow fila;

            try
            {
                ds = cadena.ObtenerCalificacionesBD();

                tabla = ds.Tables["TCalificaciones"];

                if (tabla.Rows.Count > 0 && ftodas)
                {
                    fila = tabla.NewRow();
                    fila["id"] = -1;
                    fila["nombre"] = "Todas";

                    tabla.Rows.InsertAt(fila, 0);

                }
            }
            catch (CADException cadex)
            {
                throw new ENException(cadex.Mensaje);
            }
            catch (NullReferenceException ex)
            {
                throw new ENException(ex.Message);
            }

            return tabla.DefaultView;
        }

        public int existeNombreCadena()
        {
            CADCadena c = new CADCadena();

            int id_cadena = c.BD_existeNombreCadena(this.Nombre);
            return id_cadena;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   BUSCAR: busca una cadena en la BD. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="ENException">  Thrown when en. </exception>
        ///
        /// <param name="nombreCadena"> The nombre cadena. </param>
        /// <param name="tipoCadena">   The tipo cadena. </param>
        /// <param name="actRegistro">  The act registro. </param>
        /// <param name="numPaginas">   Number of paginas. </param>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataView buscarCadena(string nombreCadena, string tipoCadena, int actRegistro, int numPaginas)
        {

            CADCadena cadenaBuscar = new CADCadena();
            DataView dvResultBusq = new DataView();

            try
            {

                dsCadenas = cadenaBuscar.buscarCadenaBD(nombreCadena, tipoCadena, actRegistro, numPaginas);

                if (dsCadenas.Tables.Count > 0)
                    dvResultBusq = VistaCadenas(dsCadenas);
                else
                    throw new ENException("DataSet vacío", -1);
            }
            catch (CADException cadex)
            {
                throw new ENException(cadex.Mensaje);
            }

            return dvResultBusq;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Obtener tamanyo consulta. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="ENException">  Thrown when en. </exception>
        ///
        /// <param name="nombreCadena"> The nombre cadena. </param>
        /// <param name="TipoCadena">   The tipo cadena. </param>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int obtenerTamanyoConsulta(string nombreCadena, string TipoCadena)
        {
            CADCadena cad = new CADCadena();
            int tamanyo = 0;

            try
            {
                tamanyo = cad.obtenerTamanyoBD(nombreCadena,TipoCadena);
            }
            catch (CADException cex)
            {
                throw new ENException(cex.Mensaje);
            }

            return tamanyo;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Obtener tamanyo consulta. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="ENException">  Thrown when en. </exception>
        ///
        /// <param name="busquedaRap">  The busqueda rap. </param>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int obtenerTamanyoConsulta(string busquedaRap)
        {
            CADCadena cad = new CADCadena();
            int tamanyo = 0;

            try
            {
                tamanyo = cad.obtenerTamanyoBD(busquedaRap);
            }
            catch (CADException cex)
            {
                throw new ENException(cex.Mensaje);
            }

            return tamanyo;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   BUSCAR: busca una cadena en la BD. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="ENException">  Thrown when en. </exception>
        ///
        /// <param name="cadenaBusqueda">   The cadena busqueda. </param>
        /// <param name="ACTUAL_registro">  The actual registro. </param>
        /// <param name="PAGINA_registros"> The pagina registros. </param>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataView buscarCadena(string cadenaBusqueda, int ACTUAL_registro, int PAGINA_registros)
        {
            CADCadena cadenaBuscarRap = new CADCadena();
            DataView dvResultBusq = new DataView();

            try
            {

                dsCadenas = cadenaBuscarRap.buscarCadenaBD(cadenaBusqueda, ACTUAL_registro, PAGINA_registros);

                if (dsCadenas.Tables.Count > 0)
                    dvResultBusq = VistaCadenas(dsCadenas);
                else
                    throw new ENException("DataSet vacío", -1);
            }
            catch (CADException cadex)
            {
                throw new ENException(cadex.Mensaje);
            }

            return dvResultBusq;
        }
    }//ENCadena FIN

}//FIN:TVO EN
