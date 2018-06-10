using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TVO_ComponentesAccesoDatos;


namespace TVO_EntidadesDeNegocio
{
    public class ENIncidencia
    {
        int codigo;
        string descripcion;
        string titular;
        DateTime fecha;
        string tecnico;
        string respuesta;
        /// <summary>
        /// DataSet con un listado de incidencias
        /// </summary>
        DataSet ds;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ENIncidencia()
        {
            codigo = -1;
            descripcion = "";
            titular = "";
            tecnico = "";
            respuesta = "";
            fecha = new DateTime();
            ds = null;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ///
        /// <param name="c">    El codigo. </param>
        /// <param name="d">    La descripción. </param>
        /// <param name="u">    El autor de la incidencia. </param>
        /// <param name="t">    El tecnico. </param>
        /// <param name="r">    La respuesta. </param>
        /// <param name="f">    La fecha. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ENIncidencia(int c, string d, string u, string t, string r, DateTime f)
        {
            codigo = c;
            descripcion = d;
            titular = u;
            tecnico = t;
            respuesta = r;
            fecha = f;
            ds = null;
        }

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public string Titular
        {
            get { return titular; }
            set { titular = value; }
        }

        public string Tecnico
        {
            get { return tecnico; }
            set { tecnico = value; }
        }

        public string Respuesta
        {
            get { return respuesta; }
            set { respuesta = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Establecer incidencia. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ///
        /// <param name="c">    El codigo. </param>
        /// <param name="d">    La descripción. </param>
        /// <param name="u">    El autor de la incidencia. </param>
        /// <param name="t">    El tecnico. </param>
        /// <param name="r">    La respuesta. </param>
        /// <param name="f">    La fecha. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void EstablecerIncidencia(int c, string d, string u, string t, string r, DateTime f)
        {
            codigo = c;
            descripcion = d;
            titular = u;
            tecnico = t;
            respuesta = r;
            fecha = f;
        }

        /// <summary>
        /// Inicializa el DataSet y le asigna todos los datos de incidencia 
        /// que hay en la Base de Datos
        /// </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ///
        /// <returns>   Un dataview con todos los datos. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataView InicializarListadoIncidencias()
        {
            DataView retorno;
            try
            {
                CADIncidencia cad = new CADIncidencia();
                // Inicializamos el DataSet
                ds = new DataSet();
                ds = cad.ObtenerIncidencias();
                retorno = new DataView(ds.Tables["incidencia"]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return (retorno);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Devuelve una vista actual del DataSet. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ///
        /// <returns>   Un DataView con todos los datos que contiene actualment ds. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataView ObtenerListadoIncidencias()
        {
            return (ds.Tables["incidencia"].DefaultView);
        }

        /// <summary>
        /// Mete en un DataTable los datos que se mostraran posteriormente,
        /// limitando el número de filas a la cantidad estipulada en numFilas,
        /// tiene en cuenta la pagina de la rejilla en que nos encontramos para devolver los datos.
        /// </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ///
        /// <param name="dv">       Vista completa de los datos. </param>
        /// <param name="pagAct">   Pagina correspondiente a los datos que se mostrarán. </param>
        /// <param name="numFilas"> Número máximo de filas que se devolverán. </param>
        ///
        /// <returns>   Un DataTable con los datos a mostrar en la página actual. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataTable ActualizarListadoIncidencias(DataView dv, int pagAct, int numFilas)
        {
            DataTable dtAux = new DataTable();
            dtAux = ds.Tables[0].Clone();
            int primerRegistro = (pagAct - 1) * numFilas;
            int ultimoRegistro = (pagAct * numFilas);

            for (int i = primerRegistro; i < dv.Count && i < ultimoRegistro; i++)
            {
                dtAux.ImportRow(dv[i].Row);
            }

            return dtAux;
        }

        /// <summary>
        /// Responde una incidencia en el DataSet, pero no la guarda todavía en la Base de Datos
        /// </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ///
        /// <returns>   Devuelve la fila que se ha cambiado. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataRow ResponderIncidencia()
        {
            int i = 0, posicionDs = 0;
            string codAux = codigo.ToString();
            DataRow retorno = null;

            // Buscamos la posicion del DataSet donde se encuentra la fila cambiada
            foreach (DataRow fila in ds.Tables["incidencia"].Rows)
            {
                if (fila["codigo"].ToString() == codAux)
                {
                    posicionDs = i;
                }
                i++;
            }

            // Asignamos la fila cambiada al DataSet
            ds.Tables["incidencia"].Rows[posicionDs]["tecnico"] = tecnico;
            ds.Tables["incidencia"].Rows[posicionDs]["respuesta"] = respuesta;
            retorno = ds.Tables["incidencia"].Rows[posicionDs];
            return retorno;
        }

        /// <summary>
        /// Guarda en la Base de Datos los cambios introducidos en el DataSet desde que fue creado
        /// </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void ConfirmarCambios()
        {
            try
            {
                CADIncidencia cad = new CADIncidencia();
                cad.ResponderIncidencia(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Devuelve el formato del DataSet para ser asignado a un DataTable. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010 </remarks>
        ///
        /// <returns>   . </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataTable InicializarPendientes()
        {
            return ds.Tables[0].Clone();
        }
    }
}
