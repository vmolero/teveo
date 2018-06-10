using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TVO_EventosWindows
{
    public class EventArgsPortadaModerador : EventArgsPortadaBase
    {
        public string nif;
        
        public EventArgsPortadaModerador(string nif, int opcion, bool s) : base(s)
        {
            this.nif = nif;
        }
    }
}
