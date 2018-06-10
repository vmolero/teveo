using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TVO_VistaWindows
{
    public partial class FVistaSeccionProgramasModerador : TVO_VistaWindows.FVistaSeccionBase
    {
        private static readonly FVistaSeccionProgramasModerador instancia = new FVistaSeccionProgramasModerador();

        private FVistaSeccionProgramasModerador()
            : base() 
        {
            InitializeComponent();
            this.etSeccion.Text = "Gestión de Programas";
            base.vistaModerador();
        }

        public static FVistaSeccionProgramasModerador Instancia
        {
          get 
          {
              return instancia; 
          }
        }
        
    }
}
