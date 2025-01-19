using System;

namespace Modelo
{
    /// <summary>
    /// Entidad que representa una factura asociada a un cliente y su membresía junto a mas detalles.
    /// <list type="bullet">
    /// <item>
    /// <term>Factura()</term> <see cref="Factura.Factura(int, string, string, string, string, string, string, int, int)"/>
    /// </item>
    /// <item>
    /// <term>ToString()</term> <see cref="Factura.ToString"/>
    /// </item>
    /// </list>
    /// </summary>
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

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
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

        /// <summary>
        /// Constructor que inicializa una nueva instancia de la clase Factura con los valores proporcionados.
        /// </summary>
        /// <param name="numfactura">El número de la factura.</param>
        /// <param name="serie">La serie de la factura.</param>
        /// <param name="preciofact">El precio de la factura.</param>
        /// <param name="descuentofact">El descuento aplicado a la factura.</param>
        /// <param name="iva">El valor del IVA aplicado a la factura.</param>
        /// <param name="total">El total de la factura después de aplicar el IVA y descuento.</param>
        /// <param name="motivoinactivacion">El motivo de inactivación (si aplica) de la factura.</param>
        /// <param name="idCliente">El ID del cliente asociado a la factura.</param>
        /// <param name="idMembresia">El ID de la membresía asociada a la factura.</param>
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

        /// <summary>
        /// Devuelve una cadena que representa los detalles de la factura.
        /// </summary>
        /// <returns>Una cadena con la información de la factura.</returns>
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
