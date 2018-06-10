using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TVO_ControladorWindows
{
    public class CControladorAcceso : TVO_ControladorWindows.CControladorBase
    {
        public CControladorAcceso()
        {
            
        }
        public int valida (string nif, string clave)
        {
            if (nif == "1")
                return 1;
            else if (nif == "2")
                return 2;
            else return -1;
        }
    }
}
