using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace TVO_ComponentesAccesoDatos
{
    
    public class CADException : System.Exception
    {
        private string mensaje;
        private int tipo;
        private SqlException sqlex;

        /// <summary>
        /// get y set mensaje
        /// </summary>
        public string Mensaje
        {
            get { return mensaje; }
            set { mensaje = value; }
        }
              
        /// <summary>
        /// get y set tipo
        /// </summary>
        public int Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        /// <summary>
        /// get sqlex
        /// </summary>
        public SqlException SQLex
        {
            get { return sqlex; }
        }
        
        public CADException(string m, int t) : base(m)
        {
            mensaje = m;
            tipo = t;
        }
        public CADException(string m, SqlException se): base(m)
        {
            sqlex = se;
            mensaje = m + "("+se.Number+") " +se.Message;
            tipo = -1;
        }
    }
}
