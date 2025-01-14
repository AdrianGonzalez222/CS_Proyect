using Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class VsPapeleraMembresia : Form
    {
        private CtrMembresia ctrMem = new CtrMembresia();
        private bool cambiosGuardados;

        public bool CambiosGuardados { get => cambiosGuardados; set => cambiosGuardados = value; }

        public VsPapeleraMembresia()
        {
            InitializeComponent();
            ctrMem.LlenarGridInactivos(dgvMembresia);
        }

        private void label1_Click(object sender, EventArgs e)
        {

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
