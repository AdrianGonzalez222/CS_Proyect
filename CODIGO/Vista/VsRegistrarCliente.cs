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
    public partial class VsRegistrarCliente : Form
    {
        private CtrCliente ctrCli = new Control.CtrCliente();
        private Validacion v = new Validacion();
        //private bool edicion = false;
        public VsRegistrarCliente()
        {
            InitializeComponent();
            lblEstado.Visible = false;
            cmbEstado.Visible = false;
            lblComprobante.Visible = false;
            txtComprobante.Visible = false;
        }

        private void cmbEstudiante_SelectedIndexChanged(object sender, EventArgs e)
        {
            string comprobante = (string)cmbEstudiante.SelectedItem;
            if (comprobante.Equals("SI"))
            {
                lblComprobante.Visible=true;
                txtComprobante.Visible = true;
            }
            else
            {
                lblComprobante.Visible = false;
                txtComprobante.Visible = false;
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            DateTime fechaActual = DateTime.Now;
            DateTime fechaLimite = new DateTime(2014,12,31);
            bool camposValidos = false;
            do
            {
                string rCedula = txtCedula.Text.Trim(), rTelefono = txtTelefono.Text.Trim();
                string rNombre = txtNombre.Text.Trim(), rDireccion = txtDireccion.Text.Trim();
                DateTime rFechaNacimiento = dtpDate.Value;  
                string esEstudiante = (string)cmbEstudiante.SelectedItem;
                string rApellido = txtApellido.Text.Trim(), rEstado = "ACTIVO";
                string rComprobante = txtComprobante.Text.Trim();
                string msg = "";
                
                if (string.IsNullOrEmpty(rCedula) || string.IsNullOrEmpty(rNombre) || string.IsNullOrEmpty(rTelefono) ||
                    string.IsNullOrEmpty(rDireccion) || string.IsNullOrEmpty(rApellido) || string.IsNullOrEmpty(esEstudiante))
                {
                    MessageBox.Show("ERROR: NO PUEDEN EXISTIR CAMPOS VACIOS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
                else if (rFechaNacimiento >= fechaActual)
                {
                    MessageBox.Show("ERROR: INGRESE FECHA DE NACIIENTO VALIDA", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
                else if (rFechaNacimiento >= fechaLimite)
                {
                    MessageBox.Show("ERROR: LA FECHA DE NACIMIENTO INVALIDA", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
                else if (ctrCli.ClienteExistente(rCedula))
                {
                    MessageBox.Show("ERROR: ESTA CEDULA YA ESTÁ ASIGNADA CON UN CLIENTE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
                

                // Ingresar datos del cliente
                if (esEstudiante.Equals("SI"))
                {
                    msg = ctrCli.IngresarCliEst(rCedula, rNombre, rApellido, rFechaNacimiento.ToString("yyyy-MM-dd"), rTelefono, rEstado, rDireccion, rComprobante);
                }
                else
                {
                    msg = ctrCli.IngresarCli(rCedula, rNombre, rApellido, rFechaNacimiento.ToString("yyyy-MM-dd"), rTelefono, rEstado, rDireccion);
                }

                MessageBox.Show(msg);
                this.Close();

                camposValidos = true;

            } while (!camposValidos);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
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
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.ValidarLetra(sender, e);
        }
        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.ValidarLetra(sender, e);
        }
    }
}
