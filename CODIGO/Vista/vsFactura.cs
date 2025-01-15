using Control;
using System;
using System.Windows.Forms;

namespace Vista
{
    public partial class VsFactura : Form
    {
        private CtrFactura ctrfact = new CtrFactura();

        public VsFactura()
        {
            InitializeComponent();
            ctrfact = new CtrFactura();
            lblNumFactura.Text = ctrfact.GenerarFactura();
        }

        private void btnRegistrarDatosFact_Click(object sender, EventArgs e)
        {
            string mensaje;
            int rnumfact = 0;
            string rseriefact = lblNumFactura.Text.Trim();
            string rpreciofact = lblPrecioFact.Text.Trim();
            string rdescuentofact = lblDescuentoFact.Text.Trim();
            string riva = lblIVA.Text.Trim();
            string cedula = lblCedulaFact.Text.Trim();
            string planMembresia = lblPlanFact.Text.Trim();

            // Mostrar mensaje con los datos de la factura
            mensaje = "\nDATOS DE SU FACTURA REGISTRADOS\n";
            mensaje += "NÚNERO DE FACTURA: " + lblNumFactura.Text + "\n";
            mensaje += "NÚNMERO DE CÉDULA: " + lblCedulaFact.Text + "\n";
            mensaje += "NOMBRE: " + lblNombreFact.Text + "\n";
            mensaje += "APELLIDO: " + lblApellidoFact.Text + "\n";
            mensaje += "FECHA DE NACIMIENTO: " + lblFechaNacimientoFact.Text + "\n";
            mensaje += "TELÉFONO: " + lblTelefonoFact.Text + "\n";
            mensaje += "DIRECCIÓN: " + lblDireccionFact.Text + "\n";
            mensaje += "ESTUDIANTE: " + lblEstudianteFact.Text + "\n";
            mensaje += "COMPROBANTE: " + lblComprobanteFact.Text + "\n";
            mensaje += "PLAN: " + lblPlanFact.Text + "\n";
            mensaje += "PROMOCIÓN: " + lblPromocionFact.Text + "\n";
            mensaje += "PRECIO: " + lblPrecioFact.Text + "\n";
            mensaje += "DESCUENTO: " + lblDescuentoFact.Text + "\n";
            mensaje += "IVA: " + lblIVA.Text + "\n";
            mensaje += "FECHA INICIO: " + lblFechaInicioFact.Text + "\n";
            mensaje += "FECHA FIN: " + lblFechaFinFact.Text + "\n";

            MessageBox.Show(mensaje, "REGISTRO DE FACTURA", MessageBoxButtons.OK);
            mensaje = ctrfact.IngresarFact(rnumfact, rpreciofact, rdescuentofact, riva, rseriefact, cedula, planMembresia);
            this.Close();
        }

    }
}
