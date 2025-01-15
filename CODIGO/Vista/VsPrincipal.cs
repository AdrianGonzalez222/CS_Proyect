using Control;
using System;
using System.Windows.Forms;

namespace Vista
{
    public partial class VsPrincipal : Form
    {
        private CtrMembresia ctrMembresia = new CtrMembresia();
        private VsConexion VsConn;
        private CtrCliente ctrCliente = new CtrCliente();
        private CtrFactura ctrFactura = new CtrFactura();

        public VsPrincipal(VsConexion VsConn)
        {
            InitializeComponent();
            this.VsConn = VsConn;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VsRegistrarCliente rgCliente = new VsRegistrarCliente();
            rgCliente.ShowDialog();
        }

        private void btnMembresia_Click(object sender, EventArgs e)
        {
            VsConsultarCliente conCli = null; 
            if(ctrCliente.GetTotal() > 0)
            {
                conCli = new VsConsultarCliente();
                conCli.ShowDialog();
            }
            else
            {
                MessageBox.Show("ERROR: NO EXISTEN CLIENTES REGISTRADAS.", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void buttonGestionActividad_Click(object sender, EventArgs e)
        {
            VsActividad vActividad = new VsActividad(); vActividad.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            VsMembresiaConsulta vConsMembresia = null;
            if (ctrMembresia.GetTotal() > 0)
            {
                vConsMembresia = new VsMembresiaConsulta(); vConsMembresia.ShowDialog();
            }
            else
            {
                MessageBox.Show("ERROR: NO EXISTEN MEMBRESIA REGISTRADAS.", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnVerRegistroFact_Click(object sender, EventArgs e)
        {
            ctrFactura.GetTotal();
            VsConsultarFactura vRegistroFact = new VsConsultarFactura();
            vRegistroFact.ShowDialog();
        }

        private void VsPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            VsConn.Close();
        }

    }
}
