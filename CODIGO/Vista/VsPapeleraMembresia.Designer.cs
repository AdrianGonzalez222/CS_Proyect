namespace Vista
{
    partial class VsPapeleraMembresia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VsPapeleraMembresia));
            this.dgvMembresia = new System.Windows.Forms.DataGridView();
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
            this.ClmEST = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.radioBCM = new System.Windows.Forms.RadioButton();
            this.radioBDP = new System.Windows.Forms.RadioButton();
            this.txtBoxBM = new System.Windows.Forms.TextBox();
            this.lblTPM = new System.Windows.Forms.Label();
            this.btnActivarM = new System.Windows.Forms.Button();
            this.btnCerrarMembresia = new System.Windows.Forms.Button();
            this.btnBM = new System.Windows.Forms.Button();
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
            this.clmPREM,
            this.ClmEST});
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
            this.dgvMembresia.Location = new System.Drawing.Point(64, 188);
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
            this.dgvMembresia.TabIndex = 4;
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
            // ClmEST
            // 
            this.ClmEST.HeaderText = "ESTADO";
            this.ClmEST.Name = "ClmEST";
            this.ClmEST.ReadOnly = true;
            // 
            // radioBCM
            // 
            this.radioBCM.AutoSize = true;
            this.radioBCM.Checked = true;
            this.radioBCM.Font = new System.Drawing.Font("Bernard MT Condensed", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBCM.ForeColor = System.Drawing.Color.White;
            this.radioBCM.Location = new System.Drawing.Point(64, 125);
            this.radioBCM.Name = "radioBCM";
            this.radioBCM.Size = new System.Drawing.Size(52, 17);
            this.radioBCM.TabIndex = 17;
            this.radioBCM.TabStop = true;
            this.radioBCM.Text = "Cedula";
            this.radioBCM.UseVisualStyleBackColor = true;
            // 
            // radioBDP
            // 
            this.radioBDP.AutoSize = true;
            this.radioBDP.Font = new System.Drawing.Font("Bernard MT Condensed", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioBDP.ForeColor = System.Drawing.Color.White;
            this.radioBDP.Location = new System.Drawing.Point(171, 125);
            this.radioBDP.Name = "radioBDP";
            this.radioBDP.Size = new System.Drawing.Size(94, 17);
            this.radioBDP.TabIndex = 18;
            this.radioBDP.TabStop = true;
            this.radioBDP.Text = "Plan membresia";
            this.radioBDP.UseVisualStyleBackColor = true;
            // 
            // txtBoxBM
            // 
            this.txtBoxBM.Font = new System.Drawing.Font("Bernard MT Condensed", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxBM.Location = new System.Drawing.Point(64, 148);
            this.txtBoxBM.Name = "txtBoxBM";
            this.txtBoxBM.Size = new System.Drawing.Size(201, 21);
            this.txtBoxBM.TabIndex = 19;
            // 
            // lblTPM
            // 
            this.lblTPM.AutoSize = true;
            this.lblTPM.Font = new System.Drawing.Font("Bernard MT Condensed", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTPM.ForeColor = System.Drawing.Color.White;
            this.lblTPM.Location = new System.Drawing.Point(391, 49);
            this.lblTPM.Name = "lblTPM";
            this.lblTPM.Size = new System.Drawing.Size(292, 34);
            this.lblTPM.TabIndex = 22;
            this.lblTPM.Text = "PAPELERA DE MEMBRESIA";
            this.lblTPM.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnActivarM
            // 
            this.btnActivarM.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnActivarM.FlatAppearance.BorderSize = 2;
            this.btnActivarM.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnActivarM.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(111)))), ((int)(((byte)(111)))));
            this.btnActivarM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActivarM.Font = new System.Drawing.Font("Bernard MT Condensed", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActivarM.ForeColor = System.Drawing.Color.White;
            this.btnActivarM.Image = global::Vista.Properties.Resources.restaurar_png;
            this.btnActivarM.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActivarM.Location = new System.Drawing.Point(810, 128);
            this.btnActivarM.Name = "btnActivarM";
            this.btnActivarM.Size = new System.Drawing.Size(98, 41);
            this.btnActivarM.TabIndex = 23;
            this.btnActivarM.Text = "Restaurar";
            this.btnActivarM.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnActivarM.UseVisualStyleBackColor = true;
            this.btnActivarM.Click += new System.EventHandler(this.button1_Click);
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
            this.btnCerrarMembresia.Location = new System.Drawing.Point(782, 489);
            this.btnCerrarMembresia.Name = "btnCerrarMembresia";
            this.btnCerrarMembresia.Size = new System.Drawing.Size(126, 41);
            this.btnCerrarMembresia.TabIndex = 21;
            this.btnCerrarMembresia.Text = "Volver al menu";
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
            this.btnBM.Location = new System.Drawing.Point(302, 128);
            this.btnBM.Name = "btnBM";
            this.btnBM.Size = new System.Drawing.Size(82, 41);
            this.btnBM.TabIndex = 20;
            this.btnBM.Text = "Buscar";
            this.btnBM.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBM.UseVisualStyleBackColor = true;
            // 
            // VsPapeleraMembresia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(980, 542);
            this.Controls.Add(this.btnActivarM);
            this.Controls.Add(this.lblTPM);
            this.Controls.Add(this.btnCerrarMembresia);
            this.Controls.Add(this.btnBM);
            this.Controls.Add(this.txtBoxBM);
            this.Controls.Add(this.radioBDP);
            this.Controls.Add(this.radioBCM);
            this.Controls.Add(this.dgvMembresia);
            this.Name = "VsPapeleraMembresia";
            this.Text = "VsPapeleraMembresia";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembresia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMembresia;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmEST;
        private System.Windows.Forms.RadioButton radioBCM;
        private System.Windows.Forms.RadioButton radioBDP;
        private System.Windows.Forms.TextBox txtBoxBM;
        private System.Windows.Forms.Button btnBM;
        private System.Windows.Forms.Button btnCerrarMembresia;
        private System.Windows.Forms.Label lblTPM;
        private System.Windows.Forms.Button btnActivarM;
    }
}