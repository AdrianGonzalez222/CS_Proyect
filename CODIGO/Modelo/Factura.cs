using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Factura
    {

        int numfactura;
        string serie;
        string preciofact;
        string descuentofact;
        string iva;
        string total;
        public string estadofact;
        public string motivoinactivacion;
        int idCliente;
        int idMembresia;
        int idActividad;
        Membresia membresia;
        Cliente cliente;



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

        public Factura(int numfactura, string serie, string preciofact, string descuentofact, string iva, string total/*, string estadofact*/, string motivoinactivacion, int idCliente, int idMembresia/*, int idActividad*/)
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
            //this.idActividad = idActividad;
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
    }
}