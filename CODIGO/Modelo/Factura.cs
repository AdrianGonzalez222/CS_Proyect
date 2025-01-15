using System;

namespace Modelo
{
    public class Factura
    {
        protected int numfactura;
        protected string serie;
        protected string preciofact;
        protected string descuentofact;
        protected string iva;
        protected string total;
        public string estadofact;
        public string motivoinactivacion;
        protected int idCliente;
        protected int idMembresia;
        protected int idActividad;
        protected Membresia membresia;
        protected Cliente cliente;

        public Factura()
        {
            Numfactura = 0;
            Serie = string.Empty;
            Preciofact = string.Empty;
            Descuentofact = string.Empty;
            iva = string.Empty;
            total = string.Empty;
            motivoinactivacion = string.Empty;
            Estadofact = "ACTIVO";
        }

        public Factura(int numfactura, string serie, string preciofact, string descuentofact, string iva, string total, string motivoinactivacion, int idCliente, int idMembresia)
        {
            this.numfactura = numfactura;
            this.serie = serie;
            this.preciofact = preciofact;
            this.descuentofact = descuentofact;
            this.iva = iva;
            this.total = total;
            this.estadofact = "ACTIVO";
            this.motivoinactivacion = motivoinactivacion;
            this.idCliente = idCliente;
            this.idMembresia = idMembresia;
        }

        public string Motivoinactivacion { get => motivoinactivacion; set => motivoinactivacion = value; }
        public string Estadofact { get => estadofact; set => estadofact = value; }
        public int Numfactura { get => numfactura; set => numfactura = value; }
        public string Preciofact { get => preciofact; set => preciofact = value; }
        public string Descuentofact { get => descuentofact; set => descuentofact = value; }
        public string Iva { get => iva; set => iva = value; }
        public string Total { get => total; set => total = value; }
        public string Serie { get => serie; set => serie = value; }
        public int IdCliente { get => idCliente; set => idCliente = value; }
        public int IdMembresia { get => idMembresia; set => idMembresia = value; }
        public int IdActividad { get => idActividad; set => idActividad = value; }
        public Membresia Membresia { get => membresia; set => membresia = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }

        public override string ToString()
        {
            return "-> NUMERO DE FACTURA: " + numfactura + Environment.NewLine +
                   "-> SERIE: " + serie + Environment.NewLine +
                   "-> PRECIO: " + preciofact + Environment.NewLine +
                   "-> DESCUENTO: " + descuentofact + Environment.NewLine +
                   "-> IVA: " + iva + Environment.NewLine +
                   "-> TOTAL: " + total + Environment.NewLine +
                   "-> ESTADO: " + estadofact + Environment.NewLine +
                   "-> MOTIVO DE INACTIVACION: " + motivoinactivacion + Environment.NewLine +
                   "-> ID CLIENTE: " + idCliente + Environment.NewLine +
                   "-> ID MEMBRESÍA: " + idMembresia + Environment.NewLine +
                   "-> ID ACTIVIDAD: " + idActividad + Environment.NewLine;
        }

    }
}
