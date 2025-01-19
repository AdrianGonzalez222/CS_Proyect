using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Modelo;
using Serilog;

namespace Control
{
    /// <summary>
    /// Clase que maneja la validación de datos de entrada y conversiones de tipos de datos.    
    /// </summary>
    public class Validacion
    {
        /// <summary>
        /// Convierte un string a entero.
        /// </summary>
        /// <param name="dato">El dato a convertir.</param>
        /// <returns>El valor entero convertido o -1 en caso de error.</returns>
        public int ConvertirEntero(String dato) // STRING a ENTERO
        {
            int valor = -1;
            try
            {
                if (dato.Equals("") && string.IsNullOrEmpty(dato))
                {
                    Console.WriteLine("ERROR: DATO VACIO.\n");
                    Log.Error("ERROR: DATO VACIO.");
                }
                else
                {
                    valor = Convert.ToInt32(dato);
                }

                if (valor == -1)
                {
                    Console.WriteLine("ERROR: DATO DEBE SER NUMERO ENTERO.\n");
                    Log.Error("ERROR: DATO DEBE SER NUMERO ENTERO.");
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("ERROR: DATO INVALIDO.\n");
                Log.Error(ex, "ERROR: DATO INVALIDO.");
            }
            return valor;
        }

        /// <summary>
        /// Convierte un string a double.
        /// </summary>
        /// <param name="dato">El dato a convertir.</param>
        /// <returns>El valor double convertido o -1 en caso de error.</returns>
        public double ConvertirDouble(string dato) // STRING a DOUBLE 1
        {
            double valor = -1;
            try
            {
                if (dato.Equals("") && string.IsNullOrEmpty(dato))
                {
                    Console.WriteLine("ERROR: DATO VACIO.\n");
                    Log.Error("ERROR: DATO VACIO.");
                }
                else
                {
                    valor = Convert.ToDouble(dato, CultureInfo.InvariantCulture);
                }

                if (valor <= 0)
                {
                    Console.WriteLine("ERROR: DATO DEBE SER MAYOR A CERO.\n");
                    Log.Error("ERROR: DATO DEBE SER MAYOR A CERO.");
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("ERROR: DATO INVALIDO.\n");
                Log.Error(ex, "ERROR: DATO INVALIDO.");
            }
            return valor;
        }

        /// <summary>
        /// Convierte un string a TimeSpan.
        /// </summary>
        /// <param name="dato">El dato a convertir.</param>
        /// <returns>El valor TimeSpan convertido o TimeSpan.MinValue en caso de error.</returns>
        public TimeSpan ConvertirTimeSpan(string dato) // STRING a TIMESPAN
        {
            TimeSpan valor = TimeSpan.MinValue;
            try
            {
                if (string.IsNullOrEmpty(dato))
                {
                    Console.WriteLine("ERROR: DATO VACIO.\n");
                    Log.Error("ERROR: DATO VACIO.");
                }
                else
                {
                    valor = TimeSpan.Parse(dato);
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("ERROR: DATO INVALIDO.\n");
                Log.Error(ex, "ERROR: DATO INVALIDO.");
            }
            return valor;
        }

        /// <summary>
        /// Convierte un string a DateTime.
        /// </summary>
        /// <param name="dato">El dato a convertir.</param>
        /// <returns>El valor DateTime convertido o DateTime.MinValue en caso de error.</returns>
        public DateTime ConvertirDateTime(string dato) // STRING a DATETIME
        {
            DateTime valor = DateTime.MinValue;
            try
            {
                if (string.IsNullOrEmpty(dato))
                {
                    Console.WriteLine("ERROR: DATO VACIO.\n");
                    Log.Error("ERROR: DATO VACIO.");
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
                Log.Error(ex, "ERROR: DATO INVALIDO.");
                //Console.WriteLine("ERROR namespace:Control/ class:Validacion/ ConvertirDateTime: {0}\n", ex);
            }
            return valor;
        }

        /// <summary>
        /// Convierte el texto ingresado en un TextBox a mayúsculas.
        /// </summary>
        /// <param name="textBox">El TextBox cuyo texto se convertirá a mayúsculas.</param>
        public void ConvertirMayuscula(TextBox textBox)
        {
            int cursorPosicion = textBox.SelectionStart;
            textBox.Text = textBox.Text.ToUpper();
            textBox.SelectionStart = cursorPosicion;
        }

        /// <summary>
        /// Convierte el texto ingresado en un RichTextBox a mayúsculas.
        /// </summary>
        /// <param name="richTextBox">El RichTextBox cuyo texto se convertirá a mayúsculas.</param>
        public void ConvertirMayusculaRich(RichTextBox richTextBox)
        {
            int cursorPosicion = richTextBox.SelectionStart;
            richTextBox.Text = richTextBox.Text.ToUpper();
            richTextBox.SelectionStart = cursorPosicion;
        }

        /// <summary>
        /// Valida que solo se ingresen letras (y espacios) en un control.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Argumentos del evento de tipo KeyPressEventArgs.</param>
        public void ValidarLetra(object sender, KeyPressEventArgs e) // ENTRADA DE SOLO LETRAS
        {
            char letra = e.KeyChar;
            if (!char.IsLetter(letra) && letra != ' ' && letra != (char)Keys.Back)
            {
                e.Handled = true;
                return;
            }
        }

        /// <summary>
        /// Valida que solo se ingresen números en un control.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Argumentos del evento de tipo KeyEventArgs.</param>
        public void ValidarNumero(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;

            if (txt == null) return;
            string textoOriginal = txt.Text;
            string textoValido = new string(textoOriginal.Where(char.IsDigit).ToArray());

            if (textoOriginal != textoValido)
            {
                txt.Text = textoValido;
                txt.SelectionStart = txt.Text.Length;
            }
        }

        /// <summary>
        /// Valida que solo se ingresen caracteres permitidos en un control.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Argumentos del evento de tipo KeyPressEventArgs.</param>
        public void ValidarCaracterEspecial(object sender, KeyPressEventArgs e) // ENTRADA DE CARACTERES DEFINIDOS
        {
            char letra = e.KeyChar;
            List<char> caracteresPermitidos = new List<char> { ',', '.', '-', '+', '*', '#', '(', ')', ':', '<', '>', '/', '%', '\n', '\r', ' ', (char)Keys.Back };
            if (!char.IsLetterOrDigit(letra) && !caracteresPermitidos.Contains(letra))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Valida que solo se ingresen números o un porcentaje válido (máximo 100%) en un control.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Argumentos del evento de tipo KeyPressEventArgs.</param>
        public void ValidarNumerosPorcentaje(object sender, KeyPressEventArgs e)
        {
            char letra = e.KeyChar;
            TextBox textBox = sender as TextBox; 
            // Obtener el texto actual del TextBox y combinarlo con el carácter que se está ingresando
            string textoActual = textBox.Text.Substring(0, textBox.SelectionStart) + letra + textBox.Text.Substring(textBox.SelectionStart + textBox.SelectionLength);

            // Validar que solo hay máximo tres números seguidos de un signo de porcentaje (%)
            if (!Regex.IsMatch(textoActual, @"^(100|[0-9]{1,2})?$") && letra != (char)Keys.Back)
            {
                e.Handled = true; // No permite ingresar el carácter
            }
        }

        /// <summary>
        /// Valida que solo se ingresen números y un formato de precio válido (con hasta dos decimales) en un control.
        /// </summary>
        /// <param name="sender">El objeto que generó el evento.</param>
        /// <param name="e">Argumentos del evento de tipo KeyPressEventArgs.</param>
        public void ValidarNumeroPrecio(object sender, KeyPressEventArgs e)
        {
            char letra = e.KeyChar;
            TextBox textBox = sender as TextBox; 
            // Obtener el texto actual del TextBox y combinarlo con el carácter que se está ingresando
            string textoActual = textBox.Text.Substring(0, textBox.SelectionStart) + letra + textBox.Text.Substring(textBox.SelectionStart + textBox.SelectionLength);

            // Validar si la entrada actual es válida
            if (!Regex.IsMatch(textoActual, @"^(?!0{2,})\d{0,3}(?:\.\d{0,2})?$") && letra != (char)Keys.Back)
            {
                e.Handled = true; // No permite ingresar el carácter
            }
        }

    }
}
