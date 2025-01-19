using System;

namespace Modelo
{
    /// <summary>
    /// Entidad que representa una membresía asociada a un cliente junto a mas detalles.
    /// <list type="bullet">
    /// <item>
    /// <term>Membresia()</term> <see cref="Membresia.Membresia(string, DateTime, DateTime, string, string, int, double, int)"/>
    /// </item>
    /// <item>
    /// <term>ToString()</term> <see cref="Membresia.ToString"/>
    /// </item>
    /// </list>
    /// </summary>
    public class Membresia
    {
        protected string plan;
        protected DateTime fechaInicio;
        protected DateTime fechaFin;
        protected string promocion;
        protected int descuento;
        protected string detallePromocion;
        protected double precio;
        protected int idCliente;
        protected int estado;
        protected Cliente cliente;
       
        /// <summary>
        /// Constructor vacío de la clase Membresia.
        /// </summary>
        public Membresia() { }

        /// <summary>
        /// Constructor que inicializa una nueva instancia de la clase Membresia con los valores proporcionados.
        /// </summary>
        /// <param name="plan">El plan de la membresía.</param>
        /// <param name="fechaInicio">La fecha de inicio de la membresía.</param>
        /// <param name="fechaFin">La fecha de fin de la membresía.</param>
        /// <param name="promocion">La promoción asociada a la membresía.</param>
        /// <param name="detallePromocion">Los detalles de la promoción.</param>
        /// <param name="descuento">El descuento aplicado a la membresía.</param>
        /// <param name="precio">El precio de la membresía.</param>
        /// <param name="idCliente">El ID del cliente al que se le asigna la membresía.</param>
        public Membresia(string plan, DateTime fechaInicio, DateTime fechaFin, string promocion, string detallePromocion, int descuento, double precio, int idCliente)
        {
            Plan = plan;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
            Promocion = promocion;
            DetallePromocion = detallePromocion;
            Descuento = descuento;
            Precio = precio;
            IdCliente = idCliente;
            estado = 1;
        }

        public string Plan { get => plan; set => plan = value; }
        public DateTime FechaInicio { get => fechaInicio; set => fechaInicio = value; }
        public DateTime FechaFin { get => fechaFin; set => fechaFin = value; }
        public string Promocion { get => promocion; set => promocion = value; }
        public string DetallePromocion { get => detallePromocion; set => detallePromocion = value; }
        public int Descuento { get => descuento; set => descuento = value; }
        public double Precio { get => precio; set => precio = value; }
        public int IdCliente { get => idCliente; set => idCliente = value; }
        public int Estado { get => estado; set => estado = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }

        /// <summary>
        /// Devuelve una cadena que representa los detalles de la membresía.
        /// </summary>
        /// <returns>Una cadena con la información de la membresía.</returns>
        public override string ToString()
        {
            return ">PLAN DE MEMBRESIA: " + plan + Environment.NewLine +
                   ">FECHA INICIO: " + fechaInicio.ToString("d") + Environment.NewLine +
                   ">FECHA FIN: " + fechaFin.ToString("d") + Environment.NewLine +
                   ">PROMOCION: " + promocion + Environment.NewLine +
                   ">DETALLES PROMOCION: " + detallePromocion + Environment.NewLine +
                   ">DESCUENTO: " + descuento.ToString() + Environment.NewLine +
                   ">PRECIO: " + precio.ToString() + Environment.NewLine;
        }

    }
}
