using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TVO_EventosWindows
{
    public class EventArgsPortadaBase : EventArgsBase
    {
        bool sesion;

        public EventArgsPortadaBase()
            : base()
        {
            this.sesion = true;
        }

        public EventArgsPortadaBase(bool s) : base()
        {
            this.sesion = s;
        }
    }
}
