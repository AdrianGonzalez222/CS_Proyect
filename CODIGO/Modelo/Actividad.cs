using System;

namespace Modelo
{
    /// <summary>
    /// Entidad que contiene los atributos y métodos de una actividad.
    /// <list type="bullet">
    /// <item>
    /// <term>Actividad()</term> <see cref="Actividad.Actividad(string, string, DateTime, DateTime, TimeSpan, TimeSpan)"/>
    /// </item>
    /// <item>
    /// <term>ToString()</term> <see cref="Actividad.ToString"/>
    /// </item>
    /// </list>
    /// </summary>
    public class Actividad
    {
        protected int estado;
        protected string nombre;
        protected string descripcion;
        protected DateTime fechaInicio;
        protected DateTime fechaFin;
        protected TimeSpan horaInicio;
        protected TimeSpan horaFin;

        /// <summary>
        /// Constructor por defecto de la clase Actividad.
        /// </summary>
        public Actividad() {}

        /// <summary>
        /// Constructor que inicializa una nueva instancia de la clase Actividad con los valores proporcionados.
        /// </summary>
        /// <param name="nombre">El nombre de la actividad.</param>
        /// <param name="descripcion">Una breve descripción de la actividad.</param>
        /// <param name="fechaInicio">La fecha en la que comienza la actividad.</param>
        /// <param name="fechaFin">La fecha en la que termina la actividad.</param>
        /// <param name="horaInicio">La hora de inicio de la actividad.</param>
        /// <param name="horaFin">La hora de fin de la actividad.</param>
        public Actividad(string nombre, string descripcion, DateTime fechaInicio, DateTime fechaFin, TimeSpan horaInicio, TimeSpan horaFin)
        {
            this.estado = 1; // ESTADO 1 = ACTIVO
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.fechaInicio = fechaInicio;
            this.fechaFin = fechaFin;
            this.horaInicio = horaInicio;
            this.horaFin = horaFin;
        }

        public int Estado { get => estado; set => estado = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public DateTime FechaInicio { get => fechaInicio; set => fechaInicio = value; }
        public DateTime FechaFin { get => fechaFin; set => fechaFin = value; }
        public TimeSpan HoraInicio { get => horaInicio; set => horaInicio = value; }
        public TimeSpan HoraFin { get => horaFin; set => horaFin = value; }

        /// <summary>
        /// Convierte la información de la actividad en una cadena de texto.
        /// </summary>
        /// <returns>Una cadena con la informacion de la actividad.</returns>
        public override string ToString()
        {
            return "-> NOMBRE: " + nombre + Environment.NewLine +
                   "-> DESCRIPCION: " + Environment.NewLine + descripcion + Environment.NewLine +
                   "-> FECHA INICIO: " + fechaInicio.ToString("d") + Environment.NewLine +
                   "-> FECHA FIN: " + fechaFin.ToString("d") + Environment.NewLine +
                   "-> HORA INICIO: " + horaInicio.ToString(@"hh\:mm") + Environment.NewLine +
                   "-> HORA FIN: " + horaFin.ToString(@"hh\:mm") + Environment.NewLine;
        }

    }
}
