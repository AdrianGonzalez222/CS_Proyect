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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Vista
{
    public partial class VsConsultarCliente : Form
    {
        private CtrMembresia ctrMen = new CtrMembresia();
        private CtrCliente ctrCli = new CtrCliente();
        private Validacion v = new Validacion();
        private VsRegistrarCliente vRC = new VsRegistrarCliente();
        private int poc;


        public VsConsultarCliente()
        {
            InitializeComponent();
            ctrCli.LlenarGrid(dgvClientes);

        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string filtroPorCedula =txtCedula.Text.Trim();
            string filtroPorNombre = txtNombre.Text.Trim();
            ctrCli.BuscarCliente(dgvClientes,filtroPorCedula, filtroPorNombre);
        }
        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.ValidarNumero(sender, e);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dgvClientes.SelectedRows[0];
                string cedulaCliente = filaSeleccionada.Cells["clmCedula"].Value.ToString();
                VsEditarCliente editarCliente = new VsEditarCliente(cedulaCliente); editarCliente.ShowDialog();

                if (editarCliente.Cambios)
                {
                    ctrCli.LlenarGrid(dgvClientes);
                }
            }
            else
            {
                MessageBox.Show("ERROR: DEBE SELECCIONAR UNA FILA PARA EDITAR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnConsultarM_Click(object sender, EventArgs e)
        {

            if (dgvClientes.SelectedRows.Count > 0)
            {
                string cedula;
                ctrMen.ExtraerDatosTablaMembresia(dgvClientes, out cedula);
                VsMembresiaLista vListaM = new VsMembresiaLista(cedula);
                vListaM.Show();
            }
            else
            {
                MessageBox.Show("ERROR: SELECCIONA UNA FILA DE CLIENTE.", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            dgvClientes.Rows.Clear();
            ctrCli.LlenarGrid(dgvClientes);

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDarBaja_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count > 0) 
            {
                var filaSeleccionada = dgvClientes.SelectedRows[0];
                var cedula = (string)filaSeleccionada.Cells["clmCedula"].Value;

                ctrCli.InactivarCliente(cedula, dgvClientes);
                ctrCli.LlenarGrid(dgvClientes);
            }
            else
            {
                MessageBox.Show("ERROR: Selecciona una fila antes de dar de baja a un cliente", "ADVERTENCIA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox textBox = sender as System.Windows.Forms.TextBox;
            v.ConvertirMayuscula(textBox);
        }

    }
}
