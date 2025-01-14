namespace Vista
{
    partial class VsMembresiaConsulta
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VsMembresiaConsulta));
            this.dgvMembresia = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.radioBDP = new System.Windows.Forms.RadioButton();
            this.txtBoxBM = new System.Windows.Forms.TextBox();
            this.radioBCM = new System.Windows.Forms.RadioButton();
            this.ButtonMPM = new System.Windows.Forms.Button();
            this.buttonGenerarMembresiaPDF = new System.Windows.Forms.Button();
            this.btnCerrarMembresia = new System.Windows.Forms.Button();
            this.btnBM = new System.Windows.Forms.Button();
            this.btnEM = new System.Windows.Forms.Button();
            this.btnEliminarM = new System.Windows.Forms.Button();
            this.clmCedulaCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmNombreCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmApellidoCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmFIM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmFFM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDPM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPREM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembresia)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMembresia
            // 
            this.dgvMembresia.AllowUserToAddRows = false;
            this.dgvMembresia.AllowUserToDeleteRows = false;
            this.dgvMembresia.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(16)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(16)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Bernard MT Condensed", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ButtonShadow;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMembresia.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMembresia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMembresia.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmCedulaCliente,
            this.clmNombreCliente,
            this.clmApellidoCliente,
            this.clmPM,
            this.clmFIM,
            this.clmFFM,
            this.clmP,
            this.clmDPM,
            this.clmDM,
            this.clmPREM});
            this.dgvMembresia.Cursor = System.Windows.Forms.Cursors.IBeam;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(16)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Bernard MT Condensed", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ButtonShadow;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMembresia.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMembresia.EnableHeadersVisualStyles = false;
            this.dgvMembresia.Location = new System.Drawing.Point(67, 197);
            this.dgvMembresia.Name = "dgvMembresia";
            this.dgvMembresia.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(12)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Bernard MT Condensed", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ButtonShadow;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMembresia.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMembresia.Size = new System.Drawing.Size(844, 279);
            this.dgvMembresia.TabIndex = 3;
            this.dgvMembresia.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMembresia_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bernard MT Condensed", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(365, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(266, 34);
            this.label1.TabIndex = 4;
            this.label1.Text = "CONSULTAR MEMBRESIA";
            // 
            // radioBDP
            // 
            this.radioBDP.AutoSize = true;
            this.radioBDP.Font = new System.Drawing.Font("Bernard MT Condensed", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBDP.ForeColor = System.Drawing.Color.White;
            this.radioBDP.Location = new System.Drawing.Point(158, 122);
            this.radioBDP.Name = "radioBDP";
            this.radioBDP.Size = new System.Drawing.Size(94, 17);
            this.radioBDP.TabIndex = 6;
            this.radioBDP.TabStop = true;
            this.radioBDP.Text = "Plan membresia";
            this.radioBDP.UseVisualStyleBackColor = true;
            // 
            // txtBoxBM
            // 
            this.txtBoxBM.Font = new System.Drawing.Font("Bernard MT Condensed", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxBM.Location = new System.Drawing.Point(67, 158);
            this.txtBoxBM.Name = "txtBoxBM";
            this.txtBoxBM.Size = new System.Drawing.Size(201, 21);
            this.txtBoxBM.TabIndex = 7;
            // 
            // radioBCM
            // 
            this.radioBCM.AutoSize = true;
            this.radioBCM.Checked = true;
            this.radioBCM.Font = new System.Drawing.Font("Bernard MT Condensed", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBCM.ForeColor = System.Drawing.Color.White;
            this.radioBCM.Location = new System.Drawing.Point(67, 122);
            this.radioBCM.Name = "radioBCM";
            this.radioBCM.Size = new System.Drawing.Size(52, 17);
            this.radioBCM.TabIndex = 16;
            this.radioBCM.TabStop = true;
            this.radioBCM.Text = "Cedula";
            this.radioBCM.UseVisualStyleBackColor = true;
            // 
            // ButtonMPM
            // 
            this.ButtonMPM.BackColor = System.Drawing.Color.Transparent;
            this.ButtonMPM.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ButtonMPM.FlatAppearance.BorderSize = 2;
            this.ButtonMPM.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.ButtonMPM.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(111)))), ((int)(((byte)(111)))));
            this.ButtonMPM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonMPM.Font = new System.Drawing.Font("Bernard MT Condensed", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonMPM.ForeColor = System.Drawing.Color.White;
            this.ButtonMPM.Image = global::Vista.Properties.Resources.papelera_de_reciclaje;
            this.ButtonMPM.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonMPM.Location = new System.Drawing.Point(583, 138);
            this.ButtonMPM.Name = "ButtonMPM";
            this.ButtonMPM.Size = new System.Drawing.Size(96, 41);
            this.ButtonMPM.TabIndex = 24;
            this.ButtonMPM.Text = "Mostrar la papelera";
            this.ButtonMPM.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ButtonMPM.UseVisualStyleBackColor = false;
            this.ButtonMPM.Click += new System.EventHandler(this.ButtonMPM_Click);
            // 
            // buttonGenerarMembresiaPDF
            // 
            this.buttonGenerarMembresiaPDF.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonGenerarMembresiaPDF.FlatAppearance.BorderSize = 2;
            this.buttonGenerarMembresiaPDF.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.buttonGenerarMembresiaPDF.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(111)))), ((int)(((byte)(111)))));
            this.buttonGenerarMembresiaPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGenerarMembresiaPDF.Font = new System.Drawing.Font("Bernard MT Condensed", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGenerarMembresiaPDF.ForeColor = System.Drawing.Color.White;
            this.buttonGenerarMembresiaPDF.Image = global::Vista.Properties.Resources.pdf_img;
            this.buttonGenerarMembresiaPDF.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGenerarMembresiaPDF.Location = new System.Drawing.Point(67, 489);
            this.buttonGenerarMembresiaPDF.Name = "buttonGenerarMembresiaPDF";
            this.buttonGenerarMembresiaPDF.Size = new System.Drawing.Size(104, 40);
            this.buttonGenerarMembresiaPDF.TabIndex = 23;
            this.buttonGenerarMembresiaPDF.Text = "Generar PDF";
            this.buttonGenerarMembresiaPDF.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonGenerarMembresiaPDF.UseVisualStyleBackColor = true;
            this.buttonGenerarMembresiaPDF.Click += new System.EventHandler(this.buttonGenerarMembresiaPDF_Click);
            // 
            // btnCerrarMembresia
            // 
            this.btnCerrarMembresia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrarMembresia.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCerrarMembresia.FlatAppearance.BorderSize = 2;
            this.btnCerrarMembresia.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnCerrarMembresia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(111)))), ((int)(((byte)(111)))));
            this.btnCerrarMembresia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarMembresia.Font = new System.Drawing.Font("Bernard MT Condensed", 9F);
            this.btnCerrarMembresia.ForeColor = System.Drawing.Color.White;
            this.btnCerrarMembresia.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrarMembresia.Image")));
            this.btnCerrarMembresia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrarMembresia.Location = new System.Drawing.Point(821, 489);
            this.btnCerrarMembresia.Name = "btnCerrarMembresia";
            this.btnCerrarMembresia.Size = new System.Drawing.Size(90, 41);
            this.btnCerrarMembresia.TabIndex = 18;
            this.btnCerrarMembresia.Text = "Cerrar";
            this.btnCerrarMembresia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCerrarMembresia.UseVisualStyleBackColor = true;
            this.btnCerrarMembresia.Click += new System.EventHandler(this.btnCerrarMembresia_Click);
            // 
            // btnBM
            // 
            this.btnBM.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnBM.FlatAppearance.BorderSize = 2;
            this.btnBM.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnBM.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(111)))), ((int)(((byte)(111)))));
            this.btnBM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBM.Font = new System.Drawing.Font("Bernard MT Condensed", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBM.ForeColor = System.Drawing.Color.White;
            this.btnBM.Image = global::Vista.Properties.Resources.buscar;
            this.btnBM.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBM.Location = new System.Drawing.Point(285, 137);
            this.btnBM.Name = "btnBM";
            this.btnBM.Size = new System.Drawing.Size(82, 41);
            this.btnBM.TabIndex = 17;
            this.btnBM.Text = "Buscar";
            this.btnBM.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBM.UseVisualStyleBackColor = true;
            this.btnBM.Click += new System.EventHandler(this.btnBM_Click);
            // 
            // btnEM
            // 
            this.btnEM.BackColor = System.Drawing.Color.Transparent;
            this.btnEM.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnEM.FlatAppearance.BorderSize = 2;
            this.btnEM.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnEM.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(111)))), ((int)(((byte)(111)))));
            this.btnEM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEM.Font = new System.Drawing.Font("Bernard MT Condensed", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEM.ForeColor = System.Drawing.Color.White;
            this.btnEM.Image = global::Vista.Properties.Resources.editarUsuario;
            this.btnEM.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEM.Location = new System.Drawing.Point(711, 137);
            this.btnEM.Name = "btnEM";
            this.btnEM.Size = new System.Drawing.Size(80, 41);
            this.btnEM.TabIndex = 9;
            this.btnEM.Text = "Editar";
            this.btnEM.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEM.UseVisualStyleBackColor = false;
            this.btnEM.Click += new System.EventHandler(this.btnEM_Click);
            // 
            // btnEliminarM
            // 
            this.btnEliminarM.BackColor = System.Drawing.Color.Transparent;
            this.btnEliminarM.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnEliminarM.FlatAppearance.BorderSize = 2;
            this.btnEliminarM.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnEliminarM.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(111)))), ((int)(((byte)(111)))));
            this.btnEliminarM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarM.Font = new System.Drawing.Font("Bernard MT Condensed", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarM.ForeColor = System.Drawing.Color.White;
            this.btnEliminarM.Image = global::Vista.Properties.Resources.desactivar_usuario;
            this.btnEliminarM.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminarM.Location = new System.Drawing.Point(816, 137);
            this.btnEliminarM.Name = "btnEliminarM";
            this.btnEliminarM.Size = new System.Drawing.Size(95, 42);
            this.btnEliminarM.TabIndex = 8;
            this.btnEliminarM.Text = "Desactivar";
            this.btnEliminarM.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminarM.UseVisualStyleBackColor = false;
            this.btnEliminarM.Click += new System.EventHandler(this.btnEliminarM_Click);
            // 
            // clmCedulaCliente
            // 
            this.clmCedulaCliente.HeaderText = "CEDULA CLIENTE";
            this.clmCedulaCliente.Name = "clmCedulaCliente";
            this.clmCedulaCliente.ReadOnly = true;
            // 
            // clmNombreCliente
            // 
            this.clmNombreCliente.HeaderText = "NOMBRE DEL CLIENTE";
            this.clmNombreCliente.Name = "clmNombreCliente";
            this.clmNombreCliente.ReadOnly = true;
            // 
            // clmApellidoCliente
            // 
            this.clmApellidoCliente.HeaderText = "APELLIDO DEL CLIENTE";
            this.clmApellidoCliente.Name = "clmApellidoCliente";
            this.clmApellidoCliente.ReadOnly = true;
            // 
            // clmPM
            // 
            this.clmPM.HeaderText = "PLAN DE MEMBRESIA";
            this.clmPM.Name = "clmPM";
            this.clmPM.ReadOnly = true;
            // 
            // clmFIM
            // 
            this.clmFIM.HeaderText = "FECHA DE INICIO";
            this.clmFIM.Name = "clmFIM";
            this.clmFIM.ReadOnly = true;
            // 
            // clmFFM
            // 
            this.clmFFM.HeaderText = "FECHA DE FIN ";
            this.clmFFM.Name = "clmFFM";
            this.clmFFM.ReadOnly = true;
            // 
            // clmP
            // 
            this.clmP.HeaderText = "PROMOCIÓN";
            this.clmP.Name = "clmP";
            this.clmP.ReadOnly = true;
            // 
            // clmDPM
            // 
            this.clmDPM.HeaderText = "DETALLE PROMOCION";
            this.clmDPM.Name = "clmDPM";
            this.clmDPM.ReadOnly = true;
            // 
            // clmDM
            // 
            this.clmDM.HeaderText = "DESCUENTO";
            this.clmDM.Name = "clmDM";
            this.clmDM.ReadOnly = true;
            // 
            // clmPREM
            // 
            this.clmPREM.HeaderText = "PRECIO";
            this.clmPREM.Name = "clmPREM";
            this.clmPREM.ReadOnly = true;
            // 
            // VsMembresiaConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(980, 542);
            this.Controls.Add(this.ButtonMPM);
            this.Controls.Add(this.buttonGenerarMembresiaPDF);
            this.Controls.Add(this.btnCerrarMembresia);
            this.Controls.Add(this.btnBM);
            this.Controls.Add(this.radioBCM);
            this.Controls.Add(this.btnEM);
            this.Controls.Add(this.btnEliminarM);
            this.Controls.Add(this.txtBoxBM);
            this.Controls.Add(this.radioBDP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvMembresia);
            this.Name = "VsMembresiaConsulta";
            this.Text = "VsMembresiaConsulta";
            this.Load += new System.EventHandler(this.VsMembresiaConsulta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembresia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMembresia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioBDP;
        private System.Windows.Forms.TextBox txtBoxBM;
        private System.Windows.Forms.Button btnEliminarM;
        private System.Windows.Forms.Button btnEM;
        private System.Windows.Forms.RadioButton radioBCM;
        private System.Windows.Forms.Button btnBM;
        private System.Windows.Forms.Button btnCerrarMembresia;
        private System.Windows.Forms.Button buttonGenerarMembresiaPDF;
        private System.Windows.Forms.Button ButtonMPM;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCedulaCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNombreCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmApellidoCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPM;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmFIM;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmFFM;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmP;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDPM;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDM;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPREM;
    }
}