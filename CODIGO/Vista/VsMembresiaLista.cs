using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Control;

namespace Vista
{
    public partial class VsMembresiaLista : Form
    {
        CtrMembresia ctrMem = new CtrMembresia();
        private string cedula;
        public VsMembresiaLista(string cedula)
        {
            InitializeComponent();
            Cedula= cedula;
            this.cedula = cedula;
            Cedula = cedula;
        }

        public string Cedula { get => cedula; set => cedula = value; }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtBoxLMA_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
