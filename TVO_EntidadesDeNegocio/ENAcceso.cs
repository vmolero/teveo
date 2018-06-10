using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace TVO_EntidadesDeNegocio
{
    public class ENAcceso
    {
        public ENAcceso()
        {
        }
        
        public ENPersona valida(string nif, string clave)
        {
            ENAdministrador p = new ENAdministrador(nif, clave);
            
            try
            {
                p.obtenerAcceso();
            }
            catch (NullReferenceException nre)
            {
                p = null;
            }
            finally
            {
            }

            return p;
        }
    }
    
}
