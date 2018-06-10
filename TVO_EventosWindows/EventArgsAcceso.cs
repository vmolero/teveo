using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace TVO_EventosWindows
{
    public class EventArgsAcceso : EventArgs
    {
        public string nif;
        public int tipo;
        public Hashtable persona;

        public EventArgsAcceso(Hashtable p)
        {
            persona = new Hashtable();

            persona["nif"] = p["nif"];
            persona["nombre"] = p["nombre"];
            persona["apellidos"] = p["apellidos"];
            persona["perfil"] = p["perfil"];
            persona["foto"] = p["foto"];
        }
        public EventArgsAcceso(string nif, int perfil)
        {
            persona = new Hashtable();

            persona["nif"] = nif;
            persona["perfil"] = perfil;
        }
    }
}
