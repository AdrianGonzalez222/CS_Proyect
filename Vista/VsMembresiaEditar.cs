﻿using Control;
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
    public partial class VsMembresiaEditar : Form
    {
        private CtrMembresia ctrMem = new CtrMembresia();
        private bool cambiosGuardados;


        public bool CambiosGuardados { get => cambiosGuardados; set => cambiosGuardados = value; }
        public VsMembresiaEditar(string nombrePlan)
        {
            InitializeComponent();
            ctrMem.PresentarDatosMembresia(txtBoxME, dateTPFIE, dateTPFFE, comboBoxPE, txtBoxDPE, txtBoxDE, txtBoxPME, nombrePlan);
            lblPMA.Text = txtBoxME.Text;
        }

        private void labelTitulo_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBoxME_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBoxDPE_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBoxDE_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string msj = "";
            string nombrePlan = lblPMA.Text.Trim();
            string planE= txtBoxME.Text.Trim();
            string SFInicioE = dateTPFIE.Text.Trim();
            string SFFinE = dateTPFFE.Text.Trim();
            string promocionE = comboBoxPE.Text.Trim();
            string detallePromocionE = txtBoxDPE.Text.Trim();
            string descuentoE = txtBoxDE.Text.Trim();
            string cedulaCliente = txtBoxPME.Text.Trim();
            string SprecioE = txtBoxPME.Text.Trim();
 

            msj = ctrMem.editarMembresia(nombrePlan, planE, SFInicioE, SFFinE, promocionE, descuentoE, detallePromocionE, cedulaCliente, SprecioE);
            MessageBox.Show(msj, "NOTIFICACION", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (msj.Contains("MEMBRESIA EDITADA CORRECTAMENTE"))
            {
                CambiosGuardados = true;
                this.Close();
            }
        }
    }
}
