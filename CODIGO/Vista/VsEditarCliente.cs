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
    public partial class VsEditarCliente : Form
    {
        private CtrCliente ctrCli = new CtrCliente();
        private Validacion v = new Validacion();
        private bool cambios;
        public bool Cambios { get => cambios; set => cambios = value; }

        public VsEditarCliente(string cedulaCliente)
        {
            InitializeComponent();
            ctrCli.MostrarDatosCliente(cedulaCliente, txtCedula, txtNombre, txtApellido, dtpDate, txtTelefono, txtDireccion, txtComprobante, cmbEstado, cmbEstudiante);
            txtCedulaOriginal.Text = txtCedula.Text;

            
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            string aCedulaOrg = txtCedulaOriginal.Text.Trim();
            string aCedula = txtCedula.Text.Trim();
            string aNombre = txtNombre.Text.Trim();
            string aApellido = txtApellido.Text.Trim();
            string aDireccion = txtDireccion.Text.Trim();
            string aFechaNacimiento = dtpDate.Text.Trim();
            string aComprobante = txtComprobante.Text.Trim();
            string aTelefono = txtTelefono.Text.Trim();
            bool esEstudiante = ((string)cmbEstudiante.SelectedItem).Equals("SI",StringComparison.OrdinalIgnoreCase);
            string aEstado = (string)cmbEstado.SelectedItem;

            string msg = ctrCli.EditarCliente(aCedulaOrg, aCedula, aNombre, aApellido, aFechaNacimiento, aTelefono, aDireccion, aEstado, esEstudiante, aComprobante);

            MessageBox.Show(msg, "ACTUALIZACION", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (msg.Contains("CLIENTE EDITADO CORRECTAMENTE"))
            {
                Cambios = true;
                this.Close();
            }

        }
        private void txtCedula_TextChanged(object sender, EventArgs e)
        {
            v.ValidarNumero(sender, e);
        }
        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            v.ConvertirMayuscula(txtNombre);
        }
        private void txtApellido_TextChanged(object sender, EventArgs e)
        {
            v.ConvertirMayuscula(txtApellido);
        }
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.ValidarLetra(sender, e);
        }
        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.ValidarLetra(sender, e);
        }
        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            v.ValidarNumero(sender, e);
        }
        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {
            v.ConvertirMayuscula(txtDireccion);
        }
        private void txtComprobante_TextChanged(object sender, EventArgs e)
        {
            v.ConvertirMayuscula(txtComprobante);
        }
        
    }
}
