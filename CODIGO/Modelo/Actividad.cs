using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    // GONZALEZ ASTUDILLO ADRIAN
    public class Actividad
    {
        protected int idActividad;
        protected int estado;
        protected string nombre;
        protected string descripcion;
        protected DateTime fechaInicio;
        protected DateTime fechaFin;
        protected TimeSpan horaInicio;
        protected TimeSpan horaFin;

        public Actividad() {}

        public Actividad(/*int idActividad,*//* int estado,*/ string nombre, string descripcion, DateTime fechaInicio, DateTime fechaFin, TimeSpan horaInicio, TimeSpan horaFin)
        {
            //this.estado = estado;
            //IdActividad = idActividad;
            this.estado = 1; // ESTADO 1 = ACTIVO
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.fechaInicio = fechaInicio;
            this.fechaFin = fechaFin;
            this.horaInicio = horaInicio;
            this.horaFin = horaFin;
        }

        protected int IdActividad { get => idActividad; set => idActividad = value; }
        public int Estado { get => estado; set => estado = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public DateTime FechaInicio { get => fechaInicio; set => fechaInicio = value; }
        public DateTime FechaFin { get => fechaFin; set => fechaFin = value; }
        public TimeSpan HoraInicio { get => horaInicio; set => horaInicio = value; }
        public TimeSpan HoraFin { get => horaFin; set => horaFin = value; }

        public override string ToString()
        {
            return "-> NOMBRE: " + nombre + Environment.NewLine +
                   "-> DESCRIPCION: " + Environment.NewLine + descripcion + Environment.NewLine +
                   "-> FECHA INICIO: " + fechaInicio.ToString("d") + Environment.NewLine +
                   "-> FECHA FIN: " + fechaFin.ToString("d") + Environment.NewLine +
                   "-> HORA INICIO: " + horaInicio.ToString(@"hh\:mm") + Environment.NewLine +
                   "-> HORA FIN: " + horaFin.ToString(@"hh\:mm") + Environment.NewLine;
        }

        // FIN
    }
}
