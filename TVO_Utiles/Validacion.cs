using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TVO_Utiles
{
    public class Validacion
    {

        /// <summary>
        /// Comprueba que el nif introducido tiene el formato correcto
        /// (8 numeros y su letra correspondiente)
        /// </summary>
        /// <param name="cadena">Es el nif a validar</param>
        /// <returns>true si los datos son coherentes, false en caso contrario</returns>
        public static bool NifValido(string cadena)
        {
            bool salida = false;
            int numeros, posicion;
            string letra, letraAux, secuencia;

            secuencia = "TRWAGMYFPDXBNJZSQVHLCKE";

            try
            {
                if (cadena.Length == 9)
                {
                    letra = cadena.Substring(8);
                    numeros = int.Parse(cadena.Substring(0, 8));
                    posicion = numeros % 23;
                    letraAux = secuencia.Substring(posicion, 1);
                    if (letra.ToUpper() == letraAux)
                    {
                        salida = true;
                    }
                }
            }
            catch
            {
                return false;
            }
            return salida;
        }

        /// <summary>
        /// Comprueba que el email introducido tiene el formato correcto
        /// </summary>
        /// <param name="cadena">email a validar</param>
        /// <returns>true si los datos son coherentes, false en caso contrario</returns>
        public static bool EmailValido(string cadena)
        {
            string modelo = @"^([\w\d\-\.]+)@{1}(([\w\d\-]{1,67})| ([\w\d\-]+\.[\w\d\-]{1,67}))\.(([a-zA-Z\d]{2,4})(\.[a-zA-Z\d]{2})?)$";
            Regex re = new Regex(modelo);
            if (re.IsMatch(cadena))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Comprueba que la segunda fecha es mayor o igual que la primera
        /// </summary>
        /// <param name="f1">Primera fecha cronologicamente</param>
        /// <param name="f2">Segunda fecha cronologicamente</param>
        /// <returns>true si los datos son coherentes, false en caso contrario</returns>
        public static bool FechasValidas(DateTime f1, DateTime f2)
        {
            if (f1 > f2)
                return false;
            return true;
        }

        /// <summary>
        /// Comprueba que la cadena introducida sea correcta (alfanumérica)
        /// </summary>
        public static bool CadenaValida(string cadena)
        {
            bool correcta = false;
            string regla = @"([a-zA-Z0-9\sáéíóúÁÉÍÓÚÄËÏÖÜäëïöü]+)$";
            Regex error = new Regex(regla);

                if (error.IsMatch(cadena))
                    correcta = true;

           return correcta;
        }

        /// <summary>
        /// Comprueba que se haya seleccionado algún elemento en el combobox
        /// </summary>
        /// <returns></returns>
        public static bool ElementoSeleccionado(int valorElemento)
        {
            bool seleccionado = false;

            if (valorElemento != 0)
                seleccionado = true;

            return seleccionado;
        }

        public static bool ElementoSeleccionado(string elemento)
        {
            bool seleccionado = false;

            if (elemento != "")
                seleccionado = true;

            return seleccionado;
        }

        public static string SustituyeCaracteresRaros(string cadena_rarita)
        {

            // Castellano
            cadena_rarita = Regex.Replace(cadena_rarita, "Ã¡", "á");
            cadena_rarita = Regex.Replace(cadena_rarita, "Ã©", "é");
            cadena_rarita = Regex.Replace(cadena_rarita, "Ã­", "í");
            cadena_rarita = Regex.Replace(cadena_rarita, "Ã³", "ó");
            cadena_rarita = Regex.Replace(cadena_rarita, "Ãº", "ú");

            cadena_rarita = Regex.Replace(cadena_rarita, "Ã¼", "ü");

            cadena_rarita = Regex.Replace(cadena_rarita, "Ã±", "ñ");


            cadena_rarita = Regex.Replace(cadena_rarita, "Ã‰", "É");
            // cadena_rarita = Regex.Replace(cadena_rarita, "Ã­", "Í"); Igual que la í
            cadena_rarita = Regex.Replace(cadena_rarita, "Ã“", "Ó");
            cadena_rarita = Regex.Replace(cadena_rarita, "Ãš", "Ú");
            cadena_rarita = Regex.Replace(cadena_rarita, "Ã‘", "Ñ");

            // Català
            cadena_rarita = Regex.Replace(cadena_rarita, "lÂ¿", "l'");
            cadena_rarita = Regex.Replace(cadena_rarita, "dÂ¿", "d'");
            cadena_rarita = Regex.Replace(cadena_rarita, "nÂ¿", "n'");
            cadena_rarita = Regex.Replace(cadena_rarita, "sÂ¿", "s'");
            cadena_rarita = Regex.Replace(cadena_rarita, "tÂ¿", "t'");

            cadena_rarita = Regex.Replace(cadena_rarita, "Ã¯", "ï");

            cadena_rarita = Regex.Replace(cadena_rarita, "Ã ", "à");
            cadena_rarita = Regex.Replace(cadena_rarita, "Ã²", "ò");
            cadena_rarita = Regex.Replace(cadena_rarita, "Ã¨", "è");

            cadena_rarita = Regex.Replace(cadena_rarita, "Ã€", "À");


            cadena_rarita = Regex.Replace(cadena_rarita, "Ã§", "ç");
            cadena_rarita = Regex.Replace(cadena_rarita, "Âª", "ª");
            cadena_rarita = Regex.Replace(cadena_rarita, "Âº", "º");
            cadena_rarita = Regex.Replace(cadena_rarita, "Â·", "·");
            cadena_rarita = Regex.Replace(cadena_rarita, "Â¡", "·");

            cadena_rarita = Regex.Replace(cadena_rarita, "Ã¤", "ä");




            cadena_rarita = Regex.Replace(cadena_rarita, "Â´", "\"");
            cadena_rarita = Regex.Replace(cadena_rarita, " Â¿", " ¿");
            cadena_rarita = Regex.Replace(cadena_rarita, "Ã", "Á");
            // á  é  í  ó  ú Á  É   Í  Ó  Ú ñ Ñ
            // Ã¡ Ã© Ã­ Ã³ Ãº Ã� Ã‰ Ã� Ã“ Ãš Ã± Ã‘

            return cadena_rarita;
        }




    }
}
