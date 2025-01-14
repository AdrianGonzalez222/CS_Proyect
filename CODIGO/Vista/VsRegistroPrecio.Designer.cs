namespace Vista
{
    partial class VsRegistroPrecio
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvRegistroPrecio = new System.Windows.Forms.DataGridView();
            this.clmNroFactRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmCedulaClienteRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmApellidoClienteRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmNombreClienteRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmPlanRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmFechaInicioRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmFechaFinRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmTelefonoClienteRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmIVARegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPrecioFactRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmDescuentoRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmTotalRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmEstadoRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmMotivoRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.cmbiNFORME = new System.Windows.Forms.ComboBox();
            this.txtTotalFacturas = new System.Windows.Forms.TextBox();
            this.txtTotalConDescuento = new System.Windows.Forms.TextBox();
            this.txtTotalSinDescuento = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMontoTotal = new System.Windows.Forms.TextBox();
            this.btnInformePDF = new System.Windows.Forms.Button();
            this.dtInicoInforme = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtFinInforme = new System.Windows.Forms.DateTimePicker();
            this.btnMostrarInforme = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistroPrecio)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRegistroPrecio
            // 
            this.dgvRegistroPrecio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRegistroPrecio.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmNroFactRegistro,
            this.ClmCedulaClienteRegistro,
            this.ClmApellidoClienteRegistro,
            this.ClmNombreClienteRegistro,
            this.ClmPlanRegistro,
            this.ClmFechaInicioRegistro,
            this.ClmFechaFinRegistro,
            this.ClmTelefonoClienteRegistro,
            this.ClmIVARegistro,
            this.clmPrecioFactRegistro,
            this.ClmDescuentoRegistro,
            this.ClmTotalRegistro,
            this.ClmEstadoRegistro,
            this.ClmMotivoRegistro});
            this.dgvRegistroPrecio.Location = new System.Drawing.Point(50, 213);
            this.dgvRegistroPrecio.Name = "dgvRegistroPrecio";
            this.dgvRegistroPrecio.RowHeadersWidth = 51;
            this.dgvRegistroPrecio.RowTemplate.Height = 24;
            this.dgvRegistroPrecio.Size = new System.Drawing.Size(933, 227);
            this.dgvRegistroPrecio.TabIndex = 0;
            this.dgvRegistroPrecio.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRegistroPrecio_CellContentClick);
            // 
            // clmNroFactRegistro
            // 
            this.clmNroFactRegistro.HeaderText = "Número de factura";
            this.clmNroFactRegistro.MinimumWidth = 6;
            this.clmNroFactRegistro.Name = "clmNroFactRegistro";
            this.clmNroFactRegistro.ReadOnly = true;
            this.clmNroFactRegistro.Width = 125;
            // 
            // ClmCedulaClienteRegistro
            // 
            this.ClmCedulaClienteRegistro.HeaderText = "Cedula";
            this.ClmCedulaClienteRegistro.MinimumWidth = 6;
            this.ClmCedulaClienteRegistro.Name = "ClmCedulaClienteRegistro";
            this.ClmCedulaClienteRegistro.ReadOnly = true;
            this.ClmCedulaClienteRegistro.Width = 125;
            // 
            // ClmApellidoClienteRegistro
            // 
            this.ClmApellidoClienteRegistro.HeaderText = "Apellido";
            this.ClmApellidoClienteRegistro.MinimumWidth = 6;
            this.ClmApellidoClienteRegistro.Name = "ClmApellidoClienteRegistro";
            this.ClmApellidoClienteRegistro.ReadOnly = true;
            this.ClmApellidoClienteRegistro.Width = 125;
            // 
            // ClmNombreClienteRegistro
            // 
            this.ClmNombreClienteRegistro.HeaderText = "Nombre";
            this.ClmNombreClienteRegistro.MinimumWidth = 6;
            this.ClmNombreClienteRegistro.Name = "ClmNombreClienteRegistro";
            this.ClmNombreClienteRegistro.ReadOnly = true;
            this.ClmNombreClienteRegistro.Width = 125;
            // 
            // ClmPlanRegistro
            // 
            this.ClmPlanRegistro.HeaderText = "Plan";
            this.ClmPlanRegistro.MinimumWidth = 6;
            this.ClmPlanRegistro.Name = "ClmPlanRegistro";
            this.ClmPlanRegistro.ReadOnly = true;
            this.ClmPlanRegistro.Width = 125;
            // 
            // ClmFechaInicioRegistro
            // 
            this.ClmFechaInicioRegistro.HeaderText = "Fecha Inicio";
            this.ClmFechaInicioRegistro.MinimumWidth = 6;
            this.ClmFechaInicioRegistro.Name = "ClmFechaInicioRegistro";
            this.ClmFechaInicioRegistro.ReadOnly = true;
            this.ClmFechaInicioRegistro.Width = 125;
            // 
            // ClmFechaFinRegistro
            // 
            this.ClmFechaFinRegistro.HeaderText = "Fecha Fin";
            this.ClmFechaFinRegistro.MinimumWidth = 6;
            this.ClmFechaFinRegistro.Name = "ClmFechaFinRegistro";
            this.ClmFechaFinRegistro.ReadOnly = true;
            this.ClmFechaFinRegistro.Width = 125;
            // 
            // ClmTelefonoClienteRegistro
            // 
            this.ClmTelefonoClienteRegistro.HeaderText = "Teléfono";
            this.ClmTelefonoClienteRegistro.MinimumWidth = 6;
            this.ClmTelefonoClienteRegistro.Name = "ClmTelefonoClienteRegistro";
            this.ClmTelefonoClienteRegistro.ReadOnly = true;
            this.ClmTelefonoClienteRegistro.Width = 125;
            // 
            // ClmIVARegistro
            // 
            this.ClmIVARegistro.HeaderText = "IVA";
            this.ClmIVARegistro.MinimumWidth = 6;
            this.ClmIVARegistro.Name = "ClmIVARegistro";
            this.ClmIVARegistro.ReadOnly = true;
            this.ClmIVARegistro.Width = 125;
            // 
            // clmPrecioFactRegistro
            // 
            this.clmPrecioFactRegistro.HeaderText = "Precio";
            this.clmPrecioFactRegistro.MinimumWidth = 6;
            this.clmPrecioFactRegistro.Name = "clmPrecioFactRegistro";
            this.clmPrecioFactRegistro.ReadOnly = true;
            this.clmPrecioFactRegistro.Width = 125;
            // 
            // ClmDescuentoRegistro
            // 
            this.ClmDescuentoRegistro.HeaderText = "Descuento";
            this.ClmDescuentoRegistro.MinimumWidth = 6;
            this.ClmDescuentoRegistro.Name = "ClmDescuentoRegistro";
            this.ClmDescuentoRegistro.ReadOnly = true;
            this.ClmDescuentoRegistro.Width = 125;
            // 
            // ClmTotalRegistro
            // 
            this.ClmTotalRegistro.HeaderText = "Total";
            this.ClmTotalRegistro.MinimumWidth = 6;
            this.ClmTotalRegistro.Name = "ClmTotalRegistro";
            this.ClmTotalRegistro.ReadOnly = true;
            this.ClmTotalRegistro.Width = 125;
            // 
            // ClmEstadoRegistro
            // 
            this.ClmEstadoRegistro.HeaderText = "Estado";
            this.ClmEstadoRegistro.MinimumWidth = 6;
            this.ClmEstadoRegistro.Name = "ClmEstadoRegistro";
            this.ClmEstadoRegistro.ReadOnly = true;
            this.ClmEstadoRegistro.Width = 125;
            // 
            // ClmMotivoRegistro
            // 
            this.ClmMotivoRegistro.HeaderText = "Motivo";
            this.ClmMotivoRegistro.MinimumWidth = 6;
            this.ClmMotivoRegistro.Name = "ClmMotivoRegistro";
            this.ClmMotivoRegistro.ReadOnly = true;
            this.ClmMotivoRegistro.Width = 125;
            // 
            // btnRegresar
            // 
            this.btnRegresar.Location = new System.Drawing.Point(50, 512);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(99, 32);
            this.btnRegresar.TabIndex = 3;
            this.btnRegresar.Text = "VOLVER";
            this.btnRegresar.UseVisualStyleBackColor = true;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // cmbiNFORME
            // 
            this.cmbiNFORME.FormattingEnabled = true;
            this.cmbiNFORME.Items.AddRange(new object[] {
            "ACTIVO",
            "INACTIVO"});
            this.cmbiNFORME.Location = new System.Drawing.Point(305, 9);
            this.cmbiNFORME.Name = "cmbiNFORME";
            this.cmbiNFORME.Size = new System.Drawing.Size(121, 24);
            this.cmbiNFORME.TabIndex = 4;
            this.cmbiNFORME.SelectedIndexChanged += new System.EventHandler(this.cmbiNFORME_SelectedIndexChanged);
            // 
            // txtTotalFacturas
            // 
            this.txtTotalFacturas.Location = new System.Drawing.Point(791, 63);
            this.txtTotalFacturas.Name = "txtTotalFacturas";
            this.txtTotalFacturas.ReadOnly = true;
            this.txtTotalFacturas.Size = new System.Drawing.Size(100, 22);
            this.txtTotalFacturas.TabIndex = 9;
            this.txtTotalFacturas.TextChanged += new System.EventHandler(this.txtTotalFacturas_TextChanged);
            // 
            // txtTotalConDescuento
            // 
            this.txtTotalConDescuento.Location = new System.Drawing.Point(791, 108);
            this.txtTotalConDescuento.Name = "txtTotalConDescuento";
            this.txtTotalConDescuento.ReadOnly = true;
            this.txtTotalConDescuento.Size = new System.Drawing.Size(100, 22);
            this.txtTotalConDescuento.TabIndex = 10;
            this.txtTotalConDescuento.TextChanged += new System.EventHandler(this.txtTotalConDescuento_TextChanged);
            // 
            // txtTotalSinDescuento
            // 
            this.txtTotalSinDescuento.Location = new System.Drawing.Point(791, 159);
            this.txtTotalSinDescuento.Name = "txtTotalSinDescuento";
            this.txtTotalSinDescuento.ReadOnly = true;
            this.txtTotalSinDescuento.Size = new System.Drawing.Size(100, 22);
            this.txtTotalSinDescuento.TabIndex = 11;
            this.txtTotalSinDescuento.TextChanged += new System.EventHandler(this.txtTotalSinDescuento_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Bernard MT Condensed", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(47, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(184, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "MOSTRAR INFORME DE FACTURAS:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bernard MT Condensed", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(601, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "TOTAL DE FACTURAS:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bernard MT Condensed", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(601, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 17);
            this.label3.TabIndex = 14;
            this.label3.Text = "FACTURAS CON DESCUENTO:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bernard MT Condensed", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(601, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 17);
            this.label4.TabIndex = 15;
            this.label4.Text = "FACTURAS SIN DESCUENTO:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Bernard MT Condensed", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(575, 526);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 17);
            this.label5.TabIndex = 16;
            this.label5.Text = "MONTO TOTAL:";
            // 
            // txtMontoTotal
            // 
            this.txtMontoTotal.Location = new System.Drawing.Point(690, 524);
            this.txtMontoTotal.Name = "txtMontoTotal";
            this.txtMontoTotal.ReadOnly = true;
            this.txtMontoTotal.Size = new System.Drawing.Size(132, 22);
            this.txtMontoTotal.TabIndex = 17;
            this.txtMontoTotal.TextChanged += new System.EventHandler(this.txtMontoTotal_TextChanged);
            // 
            // btnInformePDF
            // 
            this.btnInformePDF.Location = new System.Drawing.Point(246, 512);
            this.btnInformePDF.Name = "btnInformePDF";
            this.btnInformePDF.Size = new System.Drawing.Size(150, 34);
            this.btnInformePDF.TabIndex = 18;
            this.btnInformePDF.Text = "GENERAR PDF";
            this.btnInformePDF.UseVisualStyleBackColor = true;
            this.btnInformePDF.Click += new System.EventHandler(this.btnInformePDF_Click);
            // 
            // dtInicoInforme
            // 
            this.dtInicoInforme.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtInicoInforme.Location = new System.Drawing.Point(184, 57);
            this.dtInicoInforme.Name = "dtInicoInforme";
            this.dtInicoInforme.Size = new System.Drawing.Size(140, 22);
            this.dtInicoInforme.TabIndex = 19;
            this.dtInicoInforme.ValueChanged += new System.EventHandler(this.dtInicoInforme_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bernard MT Condensed", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(47, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 20;
            this.label1.Text = "FECHA INICIO:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Bernard MT Condensed", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(47, 109);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 17);
            this.label7.TabIndex = 21;
            this.label7.Text = "FECHA FIN:";
            // 
            // dtFinInforme
            // 
            this.dtFinInforme.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFinInforme.Location = new System.Drawing.Point(184, 105);
            this.dtFinInforme.Name = "dtFinInforme";
            this.dtFinInforme.Size = new System.Drawing.Size(140, 22);
            this.dtFinInforme.TabIndex = 22;
            this.dtFinInforme.ValueChanged += new System.EventHandler(this.dtFinInforme_ValueChanged);
            // 
            // btnMostrarInforme
            // 
            this.btnMostrarInforme.Location = new System.Drawing.Point(50, 159);
            this.btnMostrarInforme.Name = "btnMostrarInforme";
            this.btnMostrarInforme.Size = new System.Drawing.Size(323, 25);
            this.btnMostrarInforme.TabIndex = 23;
            this.btnMostrarInforme.Text = "MOSTRAR SEGÚN PARÁMETROS";
            this.btnMostrarInforme.UseVisualStyleBackColor = true;
            this.btnMostrarInforme.Click += new System.EventHandler(this.btnMostrarInforme_Click);
            // 
            // VsRegistroPrecio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1023, 590);
            this.Controls.Add(this.btnMostrarInforme);
            this.Controls.Add(this.dtFinInforme);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtInicoInforme);
            this.Controls.Add(this.btnInformePDF);
            this.Controls.Add(this.txtMontoTotal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtTotalSinDescuento);
            this.Controls.Add(this.txtTotalConDescuento);
            this.Controls.Add(this.txtTotalFacturas);
            this.Controls.Add(this.cmbiNFORME);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.dgvRegistroPrecio);
            this.Name = "VsRegistroPrecio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VsRegistroPrecio";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistroPrecio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRegistroPrecio;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.ComboBox cmbiNFORME;
        private System.Windows.Forms.TextBox txtTotalFacturas;
        private System.Windows.Forms.TextBox txtTotalConDescuento;
        private System.Windows.Forms.TextBox txtTotalSinDescuento;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMontoTotal;
        private System.Windows.Forms.Button btnInformePDF;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNroFactRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmCedulaClienteRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmApellidoClienteRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmNombreClienteRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmPlanRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmFechaInicioRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmFechaFinRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmTelefonoClienteRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmIVARegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPrecioFactRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmDescuentoRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmTotalRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmEstadoRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmMotivoRegistro;
        private System.Windows.Forms.DateTimePicker dtInicoInforme;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtFinInforme;
        private System.Windows.Forms.Button btnMostrarInforme;
    }
}