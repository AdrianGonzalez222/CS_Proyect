using System;

namespace Modelo
{
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

        public Cliente() { }

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
