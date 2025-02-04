﻿using System;
using System.Windows.Forms;
using Control;

namespace Vista
{
    public partial class VsConexion : Form
    {
        CtrConexion conexion = new CtrConexion();

        public VsConexion()
        {
            InitializeComponent();
        }

        private void buttonConectar_Click(object sender, EventArgs e)
        {
            conexion.Conectar();
            string msj = conexion.MsjConexion;
            if (msj.Contains("CONEXION EXITOSA!"))
            {
                this.Visible = false;
                VsPrincipal vsPrincipal = new VsPrincipal(this);
                vsPrincipal.FormClosing += (s, args) => this.Close();
                vsPrincipal.Show();
            }
            else
            {
                this.Close();
            }
        }

    }
}
