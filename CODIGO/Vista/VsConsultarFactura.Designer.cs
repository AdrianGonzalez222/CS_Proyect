namespace Vista
{
    partial class VsConsultarFactura
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
            this.dgvRegistroFact = new System.Windows.Forms.DataGridView();
            this.btnBuscarFact = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnInactivarFact = new System.Windows.Forms.Button();
            this.txtingresarbuscar = new System.Windows.Forms.TextBox();
            this.btnVolverFact = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnActivarFact = new System.Windows.Forms.Button();
            this.buttonGenerarPDF = new System.Windows.Forms.Button();
            this.ClmCedulaCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FacturaRegistroFact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmApellidoCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmNombreCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmTelefonoCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmPlanMembresia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmFechaInicioMem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmFechaFinMem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmPromocionMembresia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmPrecioMembresia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmDescuentoMembresia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IvaDataFact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalDataFact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstadoDataFact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MotivoDataFact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistroFact)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRegistroFact
            // 
            this.dgvRegistroFact.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRegistroFact.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClmCedulaCliente,
            this.FacturaRegistroFact,
            this.ClmApellidoCliente,
            this.ClmNombreCliente,
            this.ClmTelefonoCliente,
            this.ClmPlanMembresia,
            this.ClmFechaInicioMem,
            this.ClmFechaFinMem,
            this.ClmPromocionMembresia,
            this.ClmPrecioMembresia,
            this.ClmDescuentoMembresia,
            this.IvaDataFact,
            this.TotalDataFact,
            this.EstadoDataFact,
            this.MotivoDataFact});
            this.dgvRegistroFact.Location = new System.Drawing.Point(72, 120);
            this.dgvRegistroFact.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvRegistroFact.Name = "dgvRegistroFact";
            this.dgvRegistroFact.RowHeadersWidth = 51;
            this.dgvRegistroFact.RowTemplate.Height = 24;
            this.dgvRegistroFact.Size = new System.Drawing.Size(1353, 246);
            this.dgvRegistroFact.TabIndex = 0;
            this.dgvRegistroFact.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRegistroFact_CellContentClick);
            // 
            // btnBuscarFact
            // 
            this.btnBuscarFact.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnBuscarFact.FlatAppearance.BorderSize = 2;
            this.btnBuscarFact.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnBuscarFact.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(111)))), ((int)(((byte)(111)))));
            this.btnBuscarFact.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarFact.Font = new System.Drawing.Font("Bernard MT Condensed", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarFact.ForeColor = System.Drawing.Color.White;
            this.btnBuscarFact.Location = new System.Drawing.Point(72, 41);
            this.btnBuscarFact.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBuscarFact.Name = "btnBuscarFact";
            this.btnBuscarFact.Size = new System.Drawing.Size(221, 30);
            this.btnBuscarFact.TabIndex = 11;
            this.btnBuscarFact.Text = "BUSCAR POR NOMBRE/APELLIDO";
            this.btnBuscarFact.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(357, 402);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(625, 96);
            this.richTextBox1.TabIndex = 8;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bernard MT Condensed", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(273, 404);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "MOTIVO:";
            // 
            // btnInactivarFact
            // 
            this.btnInactivarFact.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnInactivarFact.FlatAppearance.BorderSize = 2;
            this.btnInactivarFact.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnInactivarFact.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(111)))), ((int)(((byte)(111)))));
            this.btnInactivarFact.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInactivarFact.Font = new System.Drawing.Font("Bernard MT Condensed", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInactivarFact.ForeColor = System.Drawing.Color.White;
            this.btnInactivarFact.Location = new System.Drawing.Point(357, 529);
            this.btnInactivarFact.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnInactivarFact.Name = "btnInactivarFact";
            this.btnInactivarFact.Size = new System.Drawing.Size(248, 30);
            this.btnInactivarFact.TabIndex = 7;
            this.btnInactivarFact.Text = "Inactivar Factura Seleccionada";
            this.btnInactivarFact.UseVisualStyleBackColor = true;
            this.btnInactivarFact.Click += new System.EventHandler(this.btnInactivarFact_Click);
            // 
            // txtingresarbuscar
            // 
            this.txtingresarbuscar.Location = new System.Drawing.Point(357, 46);
            this.txtingresarbuscar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtingresarbuscar.Name = "txtingresarbuscar";
            this.txtingresarbuscar.Size = new System.Drawing.Size(213, 22);
            this.txtingresarbuscar.TabIndex = 12;
            this.txtingresarbuscar.TextChanged += new System.EventHandler(this.txtingresarbuscar_TextChanged_1);
            // 
            // btnVolverFact
            // 
            this.btnVolverFact.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnVolverFact.FlatAppearance.BorderSize = 2;
            this.btnVolverFact.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnVolverFact.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(111)))), ((int)(((byte)(111)))));
            this.btnVolverFact.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolverFact.Font = new System.Drawing.Font("Bernard MT Condensed", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolverFact.ForeColor = System.Drawing.Color.White;
            this.btnVolverFact.Location = new System.Drawing.Point(72, 529);
            this.btnVolverFact.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnVolverFact.Name = "btnVolverFact";
            this.btnVolverFact.Size = new System.Drawing.Size(100, 30);
            this.btnVolverFact.TabIndex = 13;
            this.btnVolverFact.Text = "VOLVER";
            this.btnVolverFact.UseVisualStyleBackColor = true;
            this.btnVolverFact.Click += new System.EventHandler(this.btnVolverFact_Click_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1124, 448);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(192, 38);
            this.button1.TabIndex = 14;
            this.button1.Text = "VER INFORME";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnActivarFact
            // 
            this.btnActivarFact.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnActivarFact.FlatAppearance.BorderSize = 2;
            this.btnActivarFact.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnActivarFact.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(111)))), ((int)(((byte)(111)))));
            this.btnActivarFact.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActivarFact.Font = new System.Drawing.Font("Bernard MT Condensed", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActivarFact.ForeColor = System.Drawing.Color.White;
            this.btnActivarFact.Location = new System.Drawing.Point(686, 529);
            this.btnActivarFact.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnActivarFact.Name = "btnActivarFact";
            this.btnActivarFact.Size = new System.Drawing.Size(248, 30);
            this.btnActivarFact.TabIndex = 15;
            this.btnActivarFact.Text = "Activar Factura Seleccionada";
            this.btnActivarFact.UseVisualStyleBackColor = true;
            this.btnActivarFact.Click += new System.EventHandler(this.btnActivarFact_Click);
            // 
            // buttonGenerarPDF
            // 
            this.buttonGenerarPDF.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonGenerarPDF.FlatAppearance.BorderSize = 2;
            this.buttonGenerarPDF.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.buttonGenerarPDF.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(111)))), ((int)(((byte)(111)))));
            this.buttonGenerarPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGenerarPDF.Font = new System.Drawing.Font("Bernard MT Condensed", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGenerarPDF.ForeColor = System.Drawing.Color.White;
            this.buttonGenerarPDF.Location = new System.Drawing.Point(988, 529);
            this.buttonGenerarPDF.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonGenerarPDF.Name = "buttonGenerarPDF";
            this.buttonGenerarPDF.Size = new System.Drawing.Size(186, 30);
            this.buttonGenerarPDF.TabIndex = 17;
            this.buttonGenerarPDF.Text = "Generar PDF";
            this.buttonGenerarPDF.UseVisualStyleBackColor = true;
            this.buttonGenerarPDF.Click += new System.EventHandler(this.buttonGenerarPDF_Click);
            // 
            // ClmCedulaCliente
            // 
            this.ClmCedulaCliente.HeaderText = "Cedula Cliente";
            this.ClmCedulaCliente.MinimumWidth = 6;
            this.ClmCedulaCliente.Name = "ClmCedulaCliente";
            this.ClmCedulaCliente.Width = 125;
            // 
            // FacturaRegistroFact
            // 
            this.FacturaRegistroFact.HeaderText = "Factura";
            this.FacturaRegistroFact.MinimumWidth = 6;
            this.FacturaRegistroFact.Name = "FacturaRegistroFact";
            this.FacturaRegistroFact.ReadOnly = true;
            this.FacturaRegistroFact.Width = 125;
            // 
            // ClmApellidoCliente
            // 
            this.ClmApellidoCliente.HeaderText = "Apellido Cliente";
            this.ClmApellidoCliente.MinimumWidth = 6;
            this.ClmApellidoCliente.Name = "ClmApellidoCliente";
            this.ClmApellidoCliente.Width = 125;
            // 
            // ClmNombreCliente
            // 
            this.ClmNombreCliente.HeaderText = "Nombre Cliente";
            this.ClmNombreCliente.MinimumWidth = 6;
            this.ClmNombreCliente.Name = "ClmNombreCliente";
            this.ClmNombreCliente.Width = 125;
            // 
            // ClmTelefonoCliente
            // 
            this.ClmTelefonoCliente.HeaderText = "Telefono Cliente";
            this.ClmTelefonoCliente.MinimumWidth = 6;
            this.ClmTelefonoCliente.Name = "ClmTelefonoCliente";
            this.ClmTelefonoCliente.Width = 125;
            // 
            // ClmPlanMembresia
            // 
            this.ClmPlanMembresia.HeaderText = "Plan Membresia";
            this.ClmPlanMembresia.MinimumWidth = 6;
            this.ClmPlanMembresia.Name = "ClmPlanMembresia";
            this.ClmPlanMembresia.Width = 125;
            // 
            // ClmFechaInicioMem
            // 
            this.ClmFechaInicioMem.HeaderText = "Fecha Inicio Membresía";
            this.ClmFechaInicioMem.MinimumWidth = 6;
            this.ClmFechaInicioMem.Name = "ClmFechaInicioMem";
            this.ClmFechaInicioMem.ReadOnly = true;
            this.ClmFechaInicioMem.Width = 125;
            // 
            // ClmFechaFinMem
            // 
            this.ClmFechaFinMem.HeaderText = "Fecha Fin Membresía";
            this.ClmFechaFinMem.MinimumWidth = 6;
            this.ClmFechaFinMem.Name = "ClmFechaFinMem";
            this.ClmFechaFinMem.ReadOnly = true;
            this.ClmFechaFinMem.Width = 125;
            // 
            // ClmPromocionMembresia
            // 
            this.ClmPromocionMembresia.HeaderText = "Promocion Membresia";
            this.ClmPromocionMembresia.MinimumWidth = 6;
            this.ClmPromocionMembresia.Name = "ClmPromocionMembresia";
            this.ClmPromocionMembresia.Width = 125;
            // 
            // ClmPrecioMembresia
            // 
            this.ClmPrecioMembresia.HeaderText = "Precio Membresia";
            this.ClmPrecioMembresia.MinimumWidth = 6;
            this.ClmPrecioMembresia.Name = "ClmPrecioMembresia";
            this.ClmPrecioMembresia.Width = 125;
            // 
            // ClmDescuentoMembresia
            // 
            this.ClmDescuentoMembresia.HeaderText = "Descuento Membresia";
            this.ClmDescuentoMembresia.MinimumWidth = 6;
            this.ClmDescuentoMembresia.Name = "ClmDescuentoMembresia";
            this.ClmDescuentoMembresia.Width = 125;
            // 
            // IvaDataFact
            // 
            this.IvaDataFact.HeaderText = "IVA";
            this.IvaDataFact.MinimumWidth = 6;
            this.IvaDataFact.Name = "IvaDataFact";
            this.IvaDataFact.ReadOnly = true;
            this.IvaDataFact.Width = 125;
            // 
            // TotalDataFact
            // 
            this.TotalDataFact.HeaderText = "Total";
            this.TotalDataFact.MinimumWidth = 6;
            this.TotalDataFact.Name = "TotalDataFact";
            this.TotalDataFact.ReadOnly = true;
            this.TotalDataFact.Width = 125;
            // 
            // EstadoDataFact
            // 
            this.EstadoDataFact.HeaderText = "Estado";
            this.EstadoDataFact.MinimumWidth = 6;
            this.EstadoDataFact.Name = "EstadoDataFact";
            this.EstadoDataFact.ReadOnly = true;
            this.EstadoDataFact.Width = 125;
            // 
            // MotivoDataFact
            // 
            this.MotivoDataFact.HeaderText = "Motivo";
            this.MotivoDataFact.MinimumWidth = 6;
            this.MotivoDataFact.Name = "MotivoDataFact";
            this.MotivoDataFact.Width = 125;
            // 
            // VsConsultarFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1494, 597);
            this.Controls.Add(this.buttonGenerarPDF);
            this.Controls.Add(this.btnActivarFact);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnVolverFact);
            this.Controls.Add(this.btnInactivarFact);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnBuscarFact);
            this.Controls.Add(this.dgvRegistroFact);
            this.Controls.Add(this.txtingresarbuscar);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "VsConsultarFactura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VsConsultarFactura";
            this.Load += new System.EventHandler(this.VsConsultarFactura_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistroFact)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvRegistroFact;
        private System.Windows.Forms.Button btnBuscarFact;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnInactivarFact;
        private System.Windows.Forms.TextBox txtingresarbuscar;
        private System.Windows.Forms.Button btnVolverFact;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnActivarFact;
        private System.Windows.Forms.Button buttonGenerarPDF;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmCedulaCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn FacturaRegistroFact;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmApellidoCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmNombreCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmTelefonoCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmPlanMembresia;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmFechaInicioMem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmFechaFinMem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmPromocionMembresia;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmPrecioMembresia;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmDescuentoMembresia;
        private System.Windows.Forms.DataGridViewTextBoxColumn IvaDataFact;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalDataFact;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstadoDataFact;
        private System.Windows.Forms.DataGridViewTextBoxColumn MotivoDataFact;
    }
}