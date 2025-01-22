﻿using Control;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Vista
{
    public partial class VsMembresiaEditar : Form
    {
        private CtrMembresia ctrMem = new CtrMembresia();
        private bool cambiosGuardados;
        private Validacion v = new Validacion();

        public bool CambiosGuardados { get => cambiosGuardados; set => cambiosGuardados = value; }

        public VsMembresiaEditar(string nombrePlan)
        {
            InitializeComponent();
            ctrMem.PresentarDatosMembresia(txtBoxME, dateTPFIE, dateTPFFE, comboBoxPE, txtBoxDPE, txtBoxDE, txtBoxPME, lblCME, nombrePlan);
            lblPMA.Text = txtBoxME.Text;
            lblPorcentajeE.Visible = false;
            comboBoxPE.SelectedItem = "NO";
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
            string SprecioE = txtBoxPME.Text.Trim();

            msj = ctrMem.editarMembresia(nombrePlan, planE, SFInicioE, SFFinE, promocionE, descuentoE, detallePromocionE, SprecioE);
            MessageBox.Show(msj, "NOTIFICACION", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (msj.Contains("MEMBRESIA EDITADA CORRECTAMENTE"))
            {
                CambiosGuardados = true;
                this.Close();
            }
        }

        private void btnCME_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBoxPME_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.ValidarNumeroPrecio(sender, e);
        }

        private void txtBoxDE_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.ValidarNumerosPorcentaje(sender, e);
        }

        private void comboBoxPE_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tienePromocion = (String)comboBoxPE.SelectedItem;
            if (tienePromocion.Equals("SI"))
            {
                labelDPE.Visible = true;
                txtBoxDPE.Visible = true;
                labelDE.Visible = true;
                txtBoxDE.Visible = true;
                lblPorcentajeE.Visible = true;
            }
            else
            {
                labelDPE.Visible = false;
                txtBoxDPE.Visible = false;
                labelDE.Visible = false;
                txtBoxDE.Visible = false;
                lblPorcentajeE.Visible = false;
            }
        }

    }
}
