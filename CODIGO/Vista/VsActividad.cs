using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Control;

namespace Vista
{
    // GONZALEZ ASTUDILLO ADRIAN
    public partial class VsActividad : Form
    {
        private CtrActividad ctrActividad = new CtrActividad();

        public VsActividad()
        {
            InitializeComponent();
        }

        private void buttonRegistrar_Click(object sender, EventArgs e)
        {
            VsRegistrarActividad vRegActividad = new VsRegistrarActividad(); vRegActividad.ShowDialog();
        }

        private void buttonConsultar_Click(object sender, EventArgs e)
        {
            VsConsultarActividad vConsActividad = null;
            if (ctrActividad.GetTotal() > 0)
            {
                vConsActividad = new VsConsultarActividad(); vConsActividad.ShowDialog();
            }
            else
            {
                MessageBox.Show("ERROR: NO EXISTEN ACTIVIDADES REGISTRADAS.", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonPapelera_Click(object sender, EventArgs e)
        {
            VsPapeleraActividad vPapeleraAct = null;
            if (ctrActividad.GetTotalInactivas() > 0)
            {
                vPapeleraAct = new VsPapeleraActividad(); vPapeleraAct.ShowDialog();
            }
            else
            {
                MessageBox.Show("ERROR: NO EXISTEN ACTIVIDADES ELIMINADAS DENTRO DE LA PAPELERA.", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // FIN
    }
}
