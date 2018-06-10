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
    /// <summary>  Implementa el entidad negocio de sección programas. </summary>
    ///
    /// <remarks>   TVO DPAA 2009-2010. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class ENPrograma
    {

        //Variables----------------------------
        private int id_programa;
        private int id_cadena;
        private int id_tematica;
        private int id_calificacion;
        private string nombre;
        private string descripcion;
        private bool activado;
        private bool novedad;
        private DataSet dsProgramas;

        //----------------------------Variables

        //Metodos----------------------------

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor por defecto de Programa. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ENPrograma()
        {
            id_cadena = 0;
            id_tematica = 0;
            id_calificacion = 0;
            nombre = "";
            descripcion = "";
            activado = false;
            novedad = false;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   
        /// Constructor parametrizado de Programa a partir de nombre, temática, calificación y cadena. 
        /// </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="id_cad">       The identifier cad. </param>
        /// <param name="id_tem">       The identifier tem. </param>
        /// <param name="id_calif">     The identifier calif. </param>
        /// <param name="nom">          The nom. </param>
        /// <param name="desc">         The description. </param>
        /// <param name="pactivado">    true to pactivado. </param>
        /// <param name="nuevo">        true to nuevo. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ENPrograma(int id_cad, int id_tem, int id_calif, string nom, string desc, bool pactivado, bool nuevo)
        {
            id_cadena = id_cad;
            id_tematica = id_tem;
            id_calificacion = id_calif;
            nombre = nom;
            descripcion = desc;
            activado = pactivado;
            novedad = nuevo;

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   
        /// Constructor parametrizado de Programa a partir de nombre, temática, calificación y cadena. 
        /// </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="nom">      The nom. </param>
        /// <param name="id_tem">   The identifier tem. </param>
        /// <param name="id_calif"> The identifier calif. </param>
        /// <param name="id_cad">   The identifier cad. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ENPrograma(string nom, int id_tem, int id_calif, int id_cad)
        {
            id_cadena = id_cad;
            id_tematica = id_tem;
            id_calificacion = id_calif;
            nombre = nom;

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor por parametrizado de Programa  a partir de un id de programa. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="id_prog">  The identifier prog. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ENPrograma(int id_prog)
        {
            id_programa = id_prog;

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor por parametrizado de Programa  a partir de un nombre de programa. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="nomProg">  The nom prog. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ENPrograma(string nomProg)
        {
            nombre = nomProg;

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   INSERTAR: Inserta un programa nuevo. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="ENException">  Thrown when en. </exception>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int InsertarPrograma()
        {

            CADPrograma cad = new CADPrograma();
            int insertado = 0, activ = 0, nov = 0;

            ///Devuelve un entero según activado (1-->true 0-->false)
            activ = ObtenerValor(activado);
            nov = ObtenerValor(novedad);

            try
            {
                insertado = cad.BD_insertarPrograma(id_cadena, id_tematica, id_calificacion, nombre, descripcion, activ, nov);
            }
            catch (CADException cadex)
            {
                throw new ENException(cadex.Mensaje);
            }

            return insertado;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Obtiene el valor del . </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="activado"> true to activado. </param>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int ObtenerValor(bool activado)
        {
            int pactv = 0;

            if (activado)
                pactv = 1;

            return pactv;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   
        /// BUSCAR:Busca un programa según los parámetros (nombre, temática,calificacion,cadena) 
        /// </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="ENException">  Thrown when en. </exception>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataView buscarPrograma()
        {
            CADPrograma progBuscar = new CADPrograma();
            DataView dvResultBusq = new DataView();

            try
            {

                dsProgramas = progBuscar.buscarProgramaBD(nombre, id_tematica, id_calificacion, id_cadena);

                if (dsProgramas.Tables.Count > 0)
                    dvResultBusq = VistaProgramas(dsProgramas);
                else
                    throw new ENException("DataSet vacío", 0);
            }
            catch (CADException cadex)
            {
                throw new ENException(cadex.Mensaje);
            }

            return dvResultBusq;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Vista programas. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="dsProgramas">  The ds programas. </param>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private DataView VistaProgramas(DataSet dsProgramas)
        {
            DataTable resultBusc = new DataTable("Programas");
            resultBusc = dsProgramas.Tables["Programas"].Copy();

            //Me copio todo y le añado únicamente la columna q me falta y los datos de esa columna

            resultBusc.Columns.Add("ActivadoPrograma", System.Type.GetType("System.String"));
            resultBusc.Columns.Add("Novedad", System.Type.GetType("System.String"));


            for (int i = 0; i < resultBusc.Rows.Count; i++)
            {
                if ((int)resultBusc.Rows[i]["actProg"] == 0)
                    resultBusc.Rows[i]["ActivadoPrograma"] = "No";
                else
                    resultBusc.Rows[i]["ActivadoPrograma"] = "Sí";

                if ((int)resultBusc.Rows[i]["novProg"] == 0)
                    resultBusc.Rows[i]["Novedad"] = "No";
                else
                    resultBusc.Rows[i]["Novedad"] = "Sí";
            }

            return resultBusc.DefaultView;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   MODIFICAR: Modifica los datos de un programa determinado. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="ENException">  Thrown when en. </exception>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        virtual public int modificarPrograma()
        {
            CADPrograma cad = new CADPrograma();
            int modificado = 0;

            try
            {
                modificado = cad.modificarProgramaBD(id_programa, id_cadena, id_tematica, id_calificacion, nombre, descripcion, Convert.ToInt32(activado), Convert.ToInt32(novedad));

            }
            catch (CADException cadex)
            {
                throw new ENException(cadex.Mensaje);
            }
            return modificado;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   ELIMINAR: Elimina una fila. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="ENException">  Thrown when en. </exception>
        ///
        /// <param name="id">   The identifier. </param>
        ///
        /// <returns>   true if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool eliminarPrograma(int id)
        {
            CADPrograma cad = new CADPrograma();
            int eliminado = 0;
            bool eliminadaFila = false;
            try
            {
                eliminado = cad.eliminarProgramaBD(id);
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
        /// <summary>   Devuelve el id de cadena. </summary>
        ///
        /// <value> The identifier cadena. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        //--------------------------------------Métodos

        //Getters/setters------------------------------

        public int Id_cadena
        {
            get { return id_cadena; }
            set { id_cadena = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>    Devuelve el id de tematica. </summary>
        ///
        /// <value> The identifier tematica. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int Id_tematica
        {
            get { return id_tematica; }
            set { id_tematica = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>    Devuelve el id de calificacion. </summary>
        ///
        /// <value> The identifier calificacion. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int Id_calificacion
        {
            get { return id_calificacion; }
            set { id_calificacion = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>    Devuelve el nombre de un programa . </summary>
        ///
        /// <value> The nombre. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Devuelve la descripción de un programa. </summary>
        ///
        /// <value> The descripcion. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Devuelve el estado de un programa. </summary>
        ///
        /// <value> true if activado, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool Activado
        {
            get { return activado; }
            set { activado = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Devuelve el dataset de un programa. </summary>
        ///
        /// <value> The ds programas. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataSet DsProgramas
        {
            get { return dsProgramas; }
            set { dsProgramas = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether the novedad. </summary>
        ///
        /// <value> true if novedad, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool Novedad
        {
            get { return novedad; }
            set { novedad = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Devuelve el id de un programa </summary>
        ///
        /// <value> The identifier programa. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int Id_Programa
        {
            get { return id_programa; }
            set { id_programa = value; }
        }
        //------------------------------Getters/setters

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Obtiene Id de un programa. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="ENException">  Thrown when en. </exception>
        ///
        /// <param name="indice">           The indice. </param>
        /// <param name="nombrePrograma">   The nombre programa. </param>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int ObtenerIdPrograma(int indice, string nombrePrograma)
        {
            int id = -1;
            CADPrograma programa = new CADPrograma();
            try
            {
                if (indice != -1)
                {
                    id = int.Parse(programa.ObtenerIdPrograma(nombrePrograma));
                }
            }
            catch (CADException cex)
            {
                throw new ENException(cex.Mensaje);
            }
            return id;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Obtiene todos los programas de una cadena. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="ENException">  Thrown when en. </exception>
        ///
        /// <param name="idCadena"> The identifier cadena. </param>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataView ObtenerProgramasDeCadena(string idCadena)
        {
            CADPrograma programa = new CADPrograma();
            DataSet ds = new DataSet();
            DataTable tabla = new DataTable();
            DataRow fila;

            try
            {
                ds = programa.ObtenerProgramasDeCadenaBD(idCadena);

                tabla = ds.Tables["programa"];

                if (tabla.Rows.Count > 0)
                {
                    //Añado una primera fila que pone "Todos"
                    fila = tabla.NewRow();
                    fila["id"] = -1;
                    fila["nombre"] = "Todos";

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
        /// <summary>   
        /// BUSCAR:Busca un programa según los parámetros (nombre, temática,calificacion,cadena) 
        /// </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="ENException">  Thrown when en. </exception>
        ///
        /// <param name="textoBusqRap"> The texto busq rap. </param>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataView buscarPrograma(string textoBusqRap)
        {
            CADPrograma progBuscRap = new CADPrograma();
            DataView dvResultBusq = new DataView();

            try
            {

                dsProgramas = progBuscRap.buscarProgramaBD(textoBusqRap);

                if (dsProgramas.Tables.Count > 0)
                    dvResultBusq = VistaProgramas(dsProgramas);
                else
                    throw new ENException("DataSet vacío", 0);
            }
            catch (CADException cadex)
            {
                throw new ENException(cadex.Mensaje);
            }

            return dvResultBusq;
        }

        public bool existePrograma()
        {
            bool existe = false;

            CADPrograma programa = new CADPrograma();
            try
            {
                int res = programa.BD_existePrograma(this.nombre, this.id_cadena);
                if (res == 1)
                    existe = true;
            }
            catch (CADException cex)
            {
                throw new ENException(cex.Mensaje);
            }
            return existe;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Obtener tamanyo consulta (búsqueda avanzada). </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="ENException">  Thrown when en. </exception>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int obtenerTamanyoConsulta()
        {
            CADPrograma prog = new CADPrograma();
            int tamanyo = 0;

            try
            {
                tamanyo = prog.obtenerTamanyoBD(nombre, id_tematica, id_calificacion, id_cadena);
            }
            catch (CADException cex)
            {
                throw new ENException(cex.Mensaje);
            }

            return tamanyo;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   
        /// BUSCAR:Busca un programa según los parámetros (nombre, temática,calificacion,cadena) 
        /// </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="ENException">  Thrown when en. </exception>
        ///
        /// <param name="actRegistro">  The act registro. </param>
        /// <param name="numPaginas">   Number of paginas. </param>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataView buscarPrograma(int actRegistro, int numPaginas)
        {
            CADPrograma progBuscar = new CADPrograma();
            DataView dvResultBusq = new DataView();

            try
            {

                dsProgramas = progBuscar.buscarProgramaBD(nombre, id_tematica, id_calificacion, id_cadena, actRegistro, numPaginas);

                if (dsProgramas.Tables.Count > 0)
                    dvResultBusq = VistaProgramas(dsProgramas);
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
        /// <param name="busquedaRap">  The busqueda rap. </param>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int obtenerTamanyoConsulta(string busquedaRap)
        {
            CADPrograma prog = new CADPrograma();
            int tamanyo = 0;

            try
            {
                tamanyo = prog.obtenerTamanyoBD(busquedaRap);
            }
            catch (CADException cex)
            {
                throw new ENException(cex.Mensaje);
            }

            return tamanyo;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   
        /// BUSCAR:Busca un programa según los parámetros (nombre, temática,calificacion,cadena) 
        /// </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="ENException">  Thrown when en. </exception>
        ///
        /// <param name="textoBusqRap">     The texto busq rap. </param>
        /// <param name="ACTUAL_registro">  The actual registro. </param>
        /// <param name="PAGINA_registros"> The pagina registros. </param>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataView buscarPrograma(string textoBusqRap, int ACTUAL_registro, int PAGINA_registros)
        {
            CADPrograma progBuscarRap = new CADPrograma();
            DataView dvResultBusq = new DataView();

            try
            {

                dsProgramas = progBuscarRap.buscarProgramaBD(textoBusqRap, ACTUAL_registro, PAGINA_registros);

                if (dsProgramas.Tables.Count > 0)
                    dvResultBusq = VistaProgramas(dsProgramas);
                else
                    throw new ENException("DataSet vacío", -1);
            }
            catch (CADException cadex)
            {
                throw new ENException(cadex.Mensaje);
            }

            return dvResultBusq;
        }
    }
}