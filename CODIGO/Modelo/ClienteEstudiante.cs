using System;

namespace Modelo
{
    public class ClienteEstudiante : Cliente
    {
        protected string comprobante;

        public string Comprobante { get => comprobante; set => comprobante = value; }

        public ClienteEstudiante(string cedula, string nombre, string apellido, DateTime fechaNacimiento, string telefono, string direccion, string estado, string comprobante) : 
                                 base (cedula, nombre, apellido, fechaNacimiento, telefono, direccion, estado)
        {
            Comprobante = comprobante;
        }

        public override string ToString()
        {
            return base.ToString() + "> COMPROBANTE: " + comprobante + Environment.NewLine;
        }

    }
}
