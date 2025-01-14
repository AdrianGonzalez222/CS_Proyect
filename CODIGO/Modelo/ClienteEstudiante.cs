using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ClienteEstudiante : Cliente
    {
        string comprobante;
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
