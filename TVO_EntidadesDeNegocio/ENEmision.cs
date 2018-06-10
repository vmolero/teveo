using System;
using System.Collections;
using System.Globalization;
using System.Linq;
using System.Text;
using TVO_ComponentesAccesoDatos;
using System.Data;
using System.Collections.Generic;

namespace TVO_EntidadesDeNegocio
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   
    /// Clase encargada de la emision de un programa con la fecha y hora de inicio del programa,
    /// además de su duración. 
    /// </summary>
    ///
    /// <remarks>   TVO DPAA 2009-2010. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class ENEmision
    {
        private int id_emision;
        private int id_cadena;
        private int id_programa;
        private DateTime fechaHoraInicio;
        private int duracion;
        private DataSet dsEmisiones;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   
        /// Constructor por defecto de la clase ENEmision Inicializa los atributos con valores por
        /// defecto. Los id's se ponen a 0. La fecha toma 1/1/0001 12:00:00 AM. La duración toma 00:00:
        /// 00. 
        /// </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ENEmision()
        {
            id_cadena = 0;

            id_programa = 0;

            fechaHoraInicio = new DateTime();

            duracion = 0;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor parametrizado de la clase ENEmision. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <param name="id_cadena">        The identifier cadena. </param>
        /// <param name="id_programa">      The identifier programa. </param>
        /// <param name="fechaHoraInicio">  Date/Time of the fecha hora inicio. </param>
        /// <param name="duracion">         The duracion. </param>
        ///
        /// ### <param name="id_emision">   . </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ENEmision(int id_cadena, int id_programa,  DateTime fechaHoraInicio, int duracion)
        {
            this.id_cadena = id_cadena;
            this.id_programa = id_programa;
            this.fechaHoraInicio = fechaHoraInicio ;
            this.duracion = duracion;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier cadena. </summary>
        ///
        /// <value> The identifier cadena. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int Id_cadena
        {
            get { return id_cadena; }
            set { id_cadena = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier programa. </summary>
        ///
        /// <value> The identifier programa. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int Id_programa
        {
            get { return id_programa; }
            set { id_programa = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the Date/Time of the fecha hora inicio. </summary>
        ///
        /// <value> The fecha hora inicio. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DateTime FechaHoraInicio
        {
            get { return fechaHoraInicio; }
            set { fechaHoraInicio = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the duracion. </summary>
        ///
        /// <value> The duracion. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int Duracion
        {
            get { return duracion; }
            set { duracion = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier emision. </summary>
        ///
        /// <value> The identifier emision. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int Id_emision
        {
            get { return id_emision; }
            set { id_emision = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Insertar emision. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="ENException">  Thrown when en. </exception>
        ///
        /// <returns>   true if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        //CREATE
        virtual public bool insertarEmision()
        {
            bool insertado = false;
            CADEmision cadEmision = new CADEmision();

            try
            {
                if (FranjaHorariaLibre())
                    insertado = cadEmision.insertarEmisionBD(id_cadena, id_programa, fechaHoraInicio, duracion);
                else
                    throw new ENException("Franja horaria ocupada.");
            }
            catch (CADException cex)
            {
                throw new ENException(cex.Mensaje);
            }

            return insertado;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Franja horaria libre. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <returns>   true if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private bool FranjaHorariaLibre()
        {
            bool libre = false;
            CADEmision emision = new CADEmision();

            libre = emision.FranjaHorariaLibreBD(id_cadena,fechaHoraInicio, duracion);

            return libre;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Obtener emisiones. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="ENException">  Thrown when en. </exception>
        ///
        /// <param name="compararMinutos">  The comparar minutos. </param>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        //READ
        virtual public DataView obtenerEmisiones(int compararMinutos)
        {//compararMinutos->0 Menor que, 1 Igual, 2 Mayor que
            CADEmision cadEmision = new CADEmision();
            DataView dvEmisiones = new DataView();

            try
            {
                dsEmisiones = cadEmision.obtenerEmisionesBD(id_cadena, id_programa, fechaHoraInicio, duracion, compararMinutos);

                if (dsEmisiones.Tables.Count > 0)
                {
                    dvEmisiones = CrearVistaEmisiones();
                }
                else
                {
                    throw new ENException("DataSet vacío", 0);
                }
            }
            catch (CADException cex)
            {
                throw new ENException(cex.Mensaje);
            }

            return dvEmisiones;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Obtener emisiones. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="ENException">  Thrown when en. </exception>
        ///
        /// <param name="compararMinutos">  The comparar minutos. </param>
        /// <param name="desde">            The desde. </param>
        /// <param name="cantidad">         The cantidad. </param>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        //READ sobrecarga para paginación
        virtual public DataView obtenerEmisiones(int compararMinutos, int desde, int cantidad)
        {//compararMinutos->0 Menor que, 1 Igual, 2 Mayor que
            CADEmision cadEmision = new CADEmision();
            DataView dvEmisiones = new DataView();

            try
            {
                dsEmisiones = cadEmision.obtenerEmisionesBD(id_cadena, id_programa, fechaHoraInicio, duracion, compararMinutos, desde, cantidad);

                if (dsEmisiones.Tables.Count > 0)
                {
                    dvEmisiones = CrearVistaEmisiones();
                }
                else
                {
                    throw new ENException("DataSet vacío", 0);
                }
            }
            catch (CADException cex)
            {
                throw new ENException(cex.Mensaje);
            }

            return dvEmisiones;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Obtener tamanyo consulta. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="ENException">  Thrown when en. </exception>
        ///
        /// <param name="compararMinutos">  The comparar minutos. </param>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int obtenerTamanyoConsulta(int compararMinutos)
        {
            CADEmision cad = new CADEmision();
            DataSet dsD = new DataSet();
            int tam = 0;

            try
            {
                dsD = cad.BD_obtenerTamanyo(id_cadena, id_programa, fechaHoraInicio, duracion, compararMinutos);
                tam = Convert.ToInt32(dsD.Tables["Total"].Rows[0]["total"]);
            }
            catch (CADException cex)
            {
                throw new ENException(cex.Mensaje);
            }

            return tam;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Crear vista emisiones. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="ENException">  Thrown when en. </exception>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private DataView CrearVistaEmisiones()
        {           
            DateTime fechaFin;

            DataTable copiaTabla = new DataTable("emision");
            copiaTabla = dsEmisiones.Tables["emision"].Copy();

            try
            {
                copiaTabla.Columns.Add("FechaInicioFin", System.Type.GetType("System.String"));

                for (int j = 0; j < copiaTabla.Rows.Count; j++)
                {
                    DateTime fechaIni = DateTime.Parse(copiaTabla.Rows[j]["FechaHora"].ToString());
                    fechaFin = fechaIni.AddMinutes(int.Parse(copiaTabla.Rows[j]["Duracion"].ToString()));

                    copiaTabla.Rows[j]["FechaInicioFin"] = fechaIni.ToLongTimeString() + " - " + fechaFin.ToLongTimeString();
                }
           }
            catch (Exception e)
            {
                throw new ENException(e.Message, -1);
            }

            return copiaTabla.DefaultView;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Modificar emision. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="ENException">  Thrown when en. </exception>
        ///
        /// <returns>   true if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        //UPDATE
        virtual public bool modificarEmision()
        {
            CADEmision cadEmision = new CADEmision();
            bool modificado = false;

            try
            {
                if (FranjaHorariaLibre())
                    modificado = cadEmision.modificarEmisionBD(id_emision,id_cadena, id_programa, fechaHoraInicio, duracion);
                else
                    throw new ENException("Franja horaria ocupada.");
            }
            catch (CADException cex)
            {
                throw new ENException(cex.Mensaje);
            }

            return modificado;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Eliminar emision. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ///
        /// <exception cref="ENException">  Thrown when en. </exception>
        ///
        /// <returns>   true if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        //DELETE
        virtual public bool eliminarEmision()
        {
            CADEmision cadEmision = new CADEmision();
            bool eliminado = false;

            try
            {
                eliminado = cadEmision.eliminarEmisionBD(id_emision);
            }
            catch (CADException cex)
            {
                throw new ENException(cex.Mensaje);
            }
            return eliminado;
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

        public DataView ObtenerListaCadenasActuales()
        {
            CADEmision cadena = new CADEmision();
            DataSet ds = new DataSet();
            DataTable tabla = new DataTable();
            DataView dv = new DataView();
            DataRow fila;

            try
            {
                ds = cadena.ObtenerCadenasActualesBD(fechaHoraInicio);

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

        public DataView ObtenerProgramasDeCadenaActuales(string idCadena)
        {
            CADEmision emision = new CADEmision();
            DataSet ds = new DataSet();
            DataTable tabla = new DataTable();
            DataRow fila;

            try
            {
                ds = emision.ObtenerProgramasDeCadenaActualesBD(idCadena, fechaHoraInicio);

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

    }
}
