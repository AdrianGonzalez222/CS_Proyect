using Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Vista
{
    public partial class VsFactura : Form
    {
        CtrFactura ctrfact = new CtrFactura();



        public VsFactura()
        {
            InitializeComponent();
            ctrfact = new CtrFactura();
            lblNumFactura.Text = ctrfact.GenerarFactura();
            //lblTotalFact.Text = ctrfact.IngresarFact();

        }



        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void lblNombreFact_Click(object sender, EventArgs e)
        {

        }

        private void lblApellidoFact_Click(object sender, EventArgs e)
        {

        }

        private void dtFechaNacimientoFact_ValueChanged(object sender, EventArgs e)
        {

        }

        private void lblTelefonoFact_Click(object sender, EventArgs e)
        {

        }

        private void lblDireccionFact_Click(object sender, EventArgs e)
        {

        }

        private void lblEstudianteFact_Click(object sender, EventArgs e)
        {

        }

        private void lblComprobanteFact_Click(object sender, EventArgs e)
        {

        }

        private void lblPlanFact_Click(object sender, EventArgs e)
        {

        }

        private void lblPromocionFact_Click(object sender, EventArgs e)
        {

        }

        private void dtFechaFactura_ValueChanged_1(object sender, EventArgs e)
        {

        }



        private void lblFechaNacimientoFact_Click(object sender, EventArgs e)
        {

        }

        private void VsFactura_Load(object sender, EventArgs e)
        {

        }

        private void lblNumFactura_Click(object sender, EventArgs e)
        {

        }

        private void lblFechaInicioFact_Click(object sender, EventArgs e)
        {

        }

        private void lblFechaFinFact_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click_1(object sender, EventArgs e)
        {

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
            //mensaje += "TOTAL: " + lblTotalFact.Text + "\n";
            mensaje += "FECHA INICIO: " + lblFechaInicioFact.Text + "\n";
            mensaje += "FECHA FIN: " + lblFechaFinFact.Text + "\n";
            MessageBox.Show(mensaje, "REGISTRO DE FACTURA", MessageBoxButtons.OK);

            mensaje = ctrfact.IngresarFact(rnumfact, rpreciofact, rdescuentofact, riva, rseriefact, cedula, planMembresia);

            this.Close();
        }


        private void lblTotalFact_Click(object sender, EventArgs e)
        {

        }

        private void lblTotalFact_Click_1(object sender, EventArgs e)
        {

        }
    }
}