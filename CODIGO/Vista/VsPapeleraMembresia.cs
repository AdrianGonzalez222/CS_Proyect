using Control;
using System;
using System.Windows.Forms;

namespace Vista
{
    public partial class VsPapeleraMembresia : Form
    {
        private CtrMembresia ctrMem = new CtrMembresia();
        private bool cambiosGuardados;

        public VsPapeleraMembresia()
        {
            InitializeComponent();
            ctrMem.LlenarGridInactivos(dgvMembresia);
        }

        private void btnCerrarMembresia_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ctrMem.RestaurarMembresia(dgvMembresia);
        }

    }
}
