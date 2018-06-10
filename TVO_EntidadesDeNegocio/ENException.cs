using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TVO_EntidadesDeNegocio
{
    public class ENException: System.Exception
    {
        private string mensaje;
        /// <summary>
        /// get y set mensaje
        /// </summary>
        public string Mensaje
        {
            get { return mensaje; }
            set { mensaje = value; }
        }
        
        private int tipo;
        /// <summary>
        /// get y set tipo
        /// </summary>
        public int Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
        
        public ENException(string mensaje, int tipo) : base(mensaje)
        {
            this.mensaje = mensaje;
            this.tipo = tipo;
        }
        public ENException(string mensaje)
            : base(mensaje)
        {
            this.mensaje = mensaje;
            tipo = -1;
        }
        public ENException(string mensaje, Exception e)
            : base(mensaje)
        {
            this.mensaje = mensaje + ": " + e.Message;
            tipo = -1;
        }
    }
}
