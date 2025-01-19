using System;

namespace Modelo
{
    /// <summary>
    /// Esta clase representa un cliente con el rasgo de estudiante.
    /// <list type="bullet">
    /// <item>
    /// <term>ClienteEstudiante()</term> <see cref="ClienteEstudiante.ClienteEstudiante(string, string, string, DateTime, string, string, string, string)"/>
    /// </item>
    /// <item>
    /// <term>ToString()</term> <see cref="ClienteEstudiante.ToString"/>
    /// </item>
    /// </list>
    /// </summary>
    public class ClienteEstudiante : Cliente
    {
        protected string comprobante;

        public string Comprobante { get => comprobante; set => comprobante = value; }

        /// <summary>
        /// Constructor que inicializa una nueva instancia de la clase ClienteEstudiante con los valores proporcionados.
        /// </summary>
        /// <param name="cedula">La cédula de identidad del cliente.</param>
        /// <param name="nombre">El nombre del cliente.</param>
        /// <param name="apellido">El apellido del cliente.</param>
        /// <param name="fechaNacimiento">La fecha de nacimiento del cliente.</param>
        /// <param name="telefono">El número de teléfono del cliente.</param>
        /// <param name="direccion">La dirección del cliente.</param>
        /// <param name="estado">El estado actual del cliente (activo, inactivo, etc.).</param>
        /// <param name="comprobante">El comprobante que valida el estatus de estudiante del cliente.</param>
        public ClienteEstudiante(string cedula, string nombre, string apellido, DateTime fechaNacimiento, string telefono, string direccion, string estado, string comprobante) : 
                                 base (cedula, nombre, apellido, fechaNacimiento, telefono, direccion, estado)
        {
            Comprobante = comprobante;
        }

        /// <summary>
        /// Devuelve una cadena que representa los detalles del cliente con el rasgo de estudiante, incluyendo el comprobante.
        /// </summary>
        /// <returns>Una cadena con la información del cliente con el rasgo de estudiante.</returns>
        public override string ToString()
        {
            return base.ToString() + "> COMPROBANTE: " + comprobante + Environment.NewLine;
        }

    }
}
