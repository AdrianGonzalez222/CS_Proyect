﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modelo;

namespace Control
{
    public class Validacion
    {
        private bool isUpdating = false;
        //
        // CONVERSIONES
        //
        public int ConvertirEntero(String dato) // STRING a ENTERO
        {
            int valor = -1;
            try
            {
                if (dato.Equals("") && string.IsNullOrEmpty(dato))
                {
                    Console.WriteLine("ERROR: DATO VACIO.\n");
                }
                else
                {
                    valor = Convert.ToInt32(dato);
                }

                if (valor == -1)
                {
                    Console.WriteLine("ERROR: DATO DEBE SER NUMERO ENTERO.\n");
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("ERROR: DATO INVALIDO.\n");
                //Console.WriteLine("ERROR namespace:Control/ class:Validacion/ ConvertirEntero: {0}\n", ex);
            }
            return valor;
        }

        public double ConvertirDouble(string dato) // STRING a DOUBLE 1
        {
            double valor = -1;
            try
            {
                if (dato.Equals("") && string.IsNullOrEmpty(dato))
                {
                    Console.WriteLine("ERROR: DATO VACIO.\n");
                }
                else
                {
                    valor = Convert.ToDouble(dato, CultureInfo.InvariantCulture);
                }

                if (valor <= 0)
                {
                    Console.WriteLine("ERROR: DATO DEBE SER MAYOR A CERO.\n");
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("ERROR: DATO INVALIDO.\n");
                //Console.WriteLine("ERROR namespace:Control/ class:Validacion/ ConvertirDouble: {0}\n", ex);
            }
            return valor;
        }

        public double ConvertirReal(string dato) // STRING a DOUBLE 2
        {
            double valor = -1;
            try
            {
                if (dato.Equals("") && string.IsNullOrEmpty(dato))
                {
                    Console.WriteLine("ERROR: DATO VACIO.\n");
                }
                else
                {
                    valor = Convert.ToDouble(dato);
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("ERROR: SE ESPERABA UN NUMERO REAL.");
                //Console.WriteLine("ERROR namespace:Control/ class:Validacion/ ConvertirReal: {0}\n", ex);
            }
            return valor;
        }

        public char ConvertirChar(string dato) // STRING a CHAR
        {
            char valor = ' ';
            try
            {
                if (dato.Equals("") && string.IsNullOrEmpty(dato))
                {
                    Console.WriteLine("ERROR: DATO VACIO.\n");
                }
                else
                {
                    valor = Convert.ToChar(dato[0]);
                }

                if (dato.Length > 1)
                {
                    Console.WriteLine("ERROR: SOLO PUEDE INGRESAR 1 LETRA.\n");
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("ERROR: DATO INVALIDO.\n");
                //Console.WriteLine("ERROR namespace:Control/ class:Validacion/ ConvertirChar: {0}\n", ex);
            }
            return valor;
        }

        public TimeSpan ConvertirTimeSpan(string dato) // STRING a TIMESPAN
        {
            TimeSpan valor = TimeSpan.MinValue;
            try
            {
                if (string.IsNullOrEmpty(dato))
                {
                    Console.WriteLine("ERROR: DATO VACIO.\n");
                }
                else
                {
                    valor = TimeSpan.Parse(dato);
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("ERROR: DATO INVALIDO.\n");
                //Console.WriteLine("ERROR namespace:Control/ class:Validacion/ ConvertirTimeSpan: {0}\n", ex);
            }
            return valor;
        }

        public DateTime ConvertirDateTime(string dato) // STRING a DATETIME
        {
            DateTime valor = DateTime.MinValue;
            try
            {
                if (string.IsNullOrEmpty(dato))
                {
                    Console.WriteLine("ERROR: DATO VACIO.\n");
                }
                else
                {
                    valor = DateTime.Parse(dato);
                    //valor = DateTime.ParseExact(dato, "d/M/yyyy", CultureInfo.InvariantCulture); // FECHA SIN FORMATO DE HORA
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("ERROR: DATO INVALIDO.\n");
                //Console.WriteLine("ERROR namespace:Control/ class:Validacion/ ConvertirDateTime: {0}\n", ex);
            }
            return valor;
        }

        public void ConvertirMayuscula(TextBox textBox)
        {
            int cursorPosicion = textBox.SelectionStart;
            textBox.Text = textBox.Text.ToUpper();
            textBox.SelectionStart = cursorPosicion;
            return;
        }

        //
        // VALIDACIONES
        //

        public void ValidarLetra(object sender, KeyPressEventArgs e) // ENTRADA DE SOLO LETRAS
        {
            char letra = e.KeyChar;
            if (!char.IsLetter(letra) && letra != ' ' && letra != (char)Keys.Back)
            {
                e.Handled = true;
                return;
            }
        }

        public void ValidarNumero(object sender, KeyPressEventArgs e) // ENTRADA DE SOLO NUMEROS
        {
            char letra = e.KeyChar;
            if (!char.IsDigit(letra) && letra != (char)Keys.Back)
            {
                e.Handled = true;
                return;
            }
        }

        public void ValidarCantidad(object sender, KeyPressEventArgs e) // ENTRADA DE NUMEROS Y LA COMA EJ: 20,5
        {
            char letra = e.KeyChar;
            if (!char.IsDigit(letra) && letra != (char)Keys.Back && letra != ',')
            {
                e.Handled = true;
                return;
            }
        }

        public void ValidarCaracterEspecial(object sender, KeyPressEventArgs e) // ENTRADA DE CARACTERES DEFINIDOS
        {
            char letra = e.KeyChar;
            List<char> caracteresPermitidos = new List<char> { ',', '.', '-', '+', '*', '#', '(', ')', ':', '<', '>', '/', '%', '\n', '\r', ' ', (char)Keys.Back };
            if (!char.IsLetterOrDigit(letra) && !caracteresPermitidos.Contains(letra))
            {
                e.Handled = true;
            }
        }

        public void ValidarMaximoDeDigito(object sender, KeyPressEventArgs e, int maxNumerico, int maxCaracter, TextBox txt) // VALIDAR DIGITOS NUMERICOS Y CARACTERES MAXIMOS DE LETRAS
        {
            int cantidadDigito = 0;
            int cantidadletra = 0;

            foreach (char c in txt.Text)
            {
                if (char.IsDigit(c)) cantidadDigito++;
                if (char.IsLetter(c)) cantidadletra++;
            }
            if (char.IsDigit(e.KeyChar) && cantidadDigito >= maxNumerico)
            {
                e.Handled = true; 
            }

            if (char.IsLetter(e.KeyChar) && cantidadletra >= maxCaracter)
            {
                e.Handled = true; 
            }
        }

        // FIN    
    }
}
