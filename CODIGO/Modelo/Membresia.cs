
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Membresia
    {
        string plan;
        DateTime fechaInicio;
        DateTime fechaFin;
        string promocion;
        int descuento;
        string detallePromocion;
        double precio;
        int idCliente;
        int estado;



        Cliente cliente;
        public Cliente Cliente { get => cliente; set => cliente = value; }
        public Membresia() { }

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
