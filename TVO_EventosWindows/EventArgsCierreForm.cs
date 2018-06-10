using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TVO_EventosWindows
{
    public enum tipo { tUsuario, tCodigo };
    public class EventArgsCierreForm : FormClosingEventArgs
    {
        private tipo motivo;
        private CloseReason closeReason;
        private bool cancel;

        public EventArgsCierreForm(CloseReason cR, bool cancelar, tipo m)
            : base(cR, cancelar)
        {
            closeReason = cR;
            cancel = cancelar;
            this.motivo = m;
        }

     /*   public EventArgsCierreForm(tipo m) : base(CloseReason)
        {
            this.motivo = m;
        } */
    }
}
