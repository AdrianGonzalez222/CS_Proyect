using System;

namespace Modelo
{
    /// <summary>
    /// Entidad que contiene los atributos y métodos de un cliente.
    /// <list type="bullet">
    /// <item>
    /// <term>Cliente()</term> <see cref="Cliente.Cliente(string, string, string, DateTime, string, string, string)"/>
    /// </item>
    /// <item>
    /// <term>ToString()</term> <see cref="Cliente.ToString"/>
    /// </item>
    /// </list>
    /// </summary>
    public class Cliente
    {
        protected String cedula;
        protected String nombre;
        protected String apellido;
        protected DateTime fechaNacimiento;
        protected String telefono;
        protected String direccion;
        protected String estado;

        public string Cedula { get => cedula; set => cedula = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Estado { get => estado; set => estado = value; }

        /// <summary>
        /// Constructor por defecto de la clase Cliente.
        /// </summary>
        public Cliente() { }

        /// <summary>
        /// Constructor que inicializa una nueva instancia de la clase Cliente con los valores proporcionados.
        /// </summary>
        /// <param name="cedula">La cédula de identidad del cliente.</param>
        /// <param name="nombre">El nombre del cliente.</param>
        /// <param name="apellido">El apellido del cliente.</param>
        /// <param name="fechaNacimiento">La fecha de nacimiento del cliente.</param>
        /// <param name="telefono">El número de teléfono del cliente.</param>
        /// <param name="direccion">La dirección del cliente.</param>
        /// <param name="estado">El estado actual del cliente.</param>
        public Cliente(string cedula, string nombre, string apellido, DateTime fechaNacimiento, string telefono, string direccion, string estado)
        {
            Cedula = cedula;
            Nombre = nombre;
            Apellido = apellido;
            FechaNacimiento = fechaNacimiento;
            Telefono = telefono;
            Direccion = direccion;
            Estado = estado;
        }

        /// <summary>
        /// Devuelve una cadena que representa los detalles del cliente.
        /// </summary>
        /// <returns>Una cadena con la información del cliente.</returns>
        public override string ToString()
        {
            return "> CEDULA: " + cedula + Environment.NewLine +
                   "> NOMBRE: " + nombre + Environment.NewLine +
                   "> APELLIDO: " + apellido + Environment.NewLine +
                   "> FECHA DE NACIMIENTO: " + fechaNacimiento.ToString("d") + Environment.NewLine +
                   "> TELEFONO: " + telefono + Environment.NewLine +
                   "> DIRECCION: " + direccion + Environment.NewLine ;
        }
        
    }
}
