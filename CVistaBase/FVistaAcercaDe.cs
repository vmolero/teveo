////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	CVistaBase\FVistaAcercaDe.cs
//
// summary:	Implementa la clase publica FVistaAcercaDe
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

////////////////////////////////////////////////////////////////////////////////////////////////////
// namespace: TVO_VistaWindows
//
// summary:	Espacio de nombres TVO_VistaWindows.
////////////////////////////////////////////////////////////////////////////////////////////////////

namespace TVO_VistaWindows
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Clase FVistaAcercaDe. </summary>
    ///
    /// <remarks>   TVO DPAA 2009-2010. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    partial class FVistaAcercaDe : Form
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor por Defecto. </summary>
        ///
        /// <remarks>   TVO DPAA 2009-2010. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public FVistaAcercaDe()
        {
            InitializeComponent();
            //this.Text = String.Format("Acerca de {0} {0}", AssemblyTitle);
            this.labProductName.Text = this.labProductName.Text + " TeVeo - A la Carta";
            this.labelVersion.Text = this.labelVersion.Text + " TeVeo v1.0";
            this.labelCopyright.Text = labelCopyright.Text + " Creative Commons";
            this.labelCompanyName.Text = this.labelCompanyName.Text + " GRUPO DPAA - 2010" ;
            this.textBoxDescription.Text = this.textBoxDescription.Text  + "                                                                   Víctor Jesús Molero Tolinos - 48300154Q  (Coordinador)        Beatriz Alacid Soto - 74366339W                                    Alberto Torres Murcia - 74007759S                                       Antonio Calderón Heredia - 48560292R                                 Jose Manuel Martínez Payá - 44770796P";
        }

        #region Descriptores de acceso de atributos de ensamblado

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion
    }
}
