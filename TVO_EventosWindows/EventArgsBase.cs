using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TVO_EventosWindows
{

    public class EventArgsBase : EventArgs
    {
        public int opcion;
        public int perfil;

        public EventArgsBase()
        {
            opcion = 0;
            perfil = 1;
        }

        public EventArgsBase(int o)
        {
            opcion = o;
            perfil = 1;
        }

        public EventArgsBase(int o, int p) 
        {
            opcion = o;
            perfil = p;
        }
    }
}
