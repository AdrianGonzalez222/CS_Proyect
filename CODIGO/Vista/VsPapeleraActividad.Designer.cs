namespace Vista
{
    partial class VsPapeleraActividad
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
            this.dgvActividad = new System.Windows.Forms.DataGridView();
            this.ClmNumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmFechaInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmFechaFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmHoraInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmHoraFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonBuscar = new System.Windows.Forms.Button();
            this.radioButtonDescripcion = new System.Windows.Forms.RadioButton();
            this.radioButtonNombre = new System.Windows.Forms.RadioButton();
            this.textBuscar = new System.Windows.Forms.TextBox();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonRestaurar = new System.Windows.Forms.Button();
            this.buttonEliminar = new System.Windows.Forms.Button();
            this.buttonGenerarPDF = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActividad)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvActividad
            // 
            this.dgvActividad.AllowUserToAddRows = false;
            this.dgvActividad.AllowUserToDeleteRows = false;
            this.dgvActividad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvActividad.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClmNumero,
            this.ClmEstado,
            this.ClmNombre,
            this.ClmDescripcion,
            this.ClmFechaInicio,
            this.ClmFechaFin,
            this.ClmHoraInicio,
            this.ClmHoraFin});
            this.dgvActividad.Location = new System.Drawing.Point(29, 134);
            this.dgvActividad.Name = "dgvActividad";
            this.dgvActividad.ReadOnly = true;
            this.dgvActividad.Size = new System.Drawing.Size(744, 162);
            this.dgvActividad.TabIndex = 25;
            // 
            // ClmNumero
            // 
            this.ClmNumero.HeaderText = "NRO";
            this.ClmNumero.Name = "ClmNumero";
            this.ClmNumero.ReadOnly = true;
            // 
            // ClmEstado
            // 
            this.ClmEstado.HeaderText = "ESTADO";
            this.ClmEstado.Name = "ClmEstado";
            this.ClmEstado.ReadOnly = true;
            this.ClmEstado.Visible = false;
            // 
            // ClmNombre
            // 
            this.ClmNombre.HeaderText = "NOMBRE";
            this.ClmNombre.Name = "ClmNombre";
            this.ClmNombre.ReadOnly = true;
            // 
            // ClmDescripcion
            // 
            this.ClmDescripcion.HeaderText = "DESCRIPCION";
            this.ClmDescripcion.Name = "ClmDescripcion";
            this.ClmDescripcion.ReadOnly = true;
            // 
            // ClmFechaInicio
            // 
            this.ClmFechaInicio.HeaderText = "FECHA INICIO";
            this.ClmFechaInicio.Name = "ClmFechaInicio";
            this.ClmFechaInicio.ReadOnly = true;
            // 
            // ClmFechaFin
            // 
            this.ClmFechaFin.HeaderText = "FECHA FIN";
            this.ClmFechaFin.Name = "ClmFechaFin";
            this.ClmFechaFin.ReadOnly = true;
            // 
            // ClmHoraInicio
            // 
            this.ClmHoraInicio.HeaderText = "HORA INICIO";
            this.ClmHoraInicio.Name = "ClmHoraInicio";
            this.ClmHoraInicio.ReadOnly = true;
            // 
            // ClmHoraFin
            // 
            this.ClmHoraFin.HeaderText = "HORA FIN";
            this.ClmHoraFin.Name = "ClmHoraFin";
            this.ClmHoraFin.ReadOnly = true;
            // 
            // buttonBuscar
            // 
            this.buttonBuscar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonBuscar.FlatAppearance.BorderSize = 2;
            this.buttonBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.buttonBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(111)))), ((int)(((byte)(111)))));
            this.buttonBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBuscar.ForeColor = System.Drawing.Color.White;
            this.buttonBuscar.Location = new System.Drawing.Point(217, 85);
            this.buttonBuscar.Name = "buttonBuscar";
            this.buttonBuscar.Size = new System.Drawing.Size(75, 23);
            this.buttonBuscar.TabIndex = 24;
            this.buttonBuscar.Text = "Buscar";
            this.buttonBuscar.UseVisualStyleBackColor = true;
            this.buttonBuscar.Click += new System.EventHandler(this.buttonBuscar_Click);
            // 
            // radioButtonDescripcion
            // 
            this.radioButtonDescripcion.AutoSize = true;
            this.radioButtonDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonDescripcion.ForeColor = System.Drawing.Color.White;
            this.radioButtonDescripcion.Location = new System.Drawing.Point(127, 65);
            this.radioButtonDescripcion.Name = "radioButtonDescripcion";
            this.radioButtonDescripcion.Size = new System.Drawing.Size(81, 17);
            this.radioButtonDescripcion.TabIndex = 23;
            this.radioButtonDescripcion.TabStop = true;
            this.radioButtonDescripcion.Text = "Descripcion";
            this.radioButtonDescripcion.UseVisualStyleBackColor = true;
            // 
            // radioButtonNombre
            // 
            this.radioButtonNombre.AutoSize = true;
            this.radioButtonNombre.Checked = true;
            this.radioButtonNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonNombre.ForeColor = System.Drawing.Color.White;
            this.radioButtonNombre.Location = new System.Drawing.Point(29, 65);
            this.radioButtonNombre.Name = "radioButtonNombre";
            this.radioButtonNombre.Size = new System.Drawing.Size(62, 17);
            this.radioButtonNombre.TabIndex = 22;
            this.radioButtonNombre.TabStop = true;
            this.radioButtonNombre.Text = "Nombre";
            this.radioButtonNombre.UseVisualStyleBackColor = true;
            // 
            // textBuscar
            // 
            this.textBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBuscar.Location = new System.Drawing.Point(29, 88);
            this.textBuscar.Name = "textBuscar";
            this.textBuscar.Size = new System.Drawing.Size(171, 20);
            this.textBuscar.TabIndex = 21;
            this.textBuscar.TextChanged += new System.EventHandler(this.textBuscar_TextChanged);
            this.textBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBuscar_KeyPress);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonCancelar.FlatAppearance.BorderSize = 2;
            this.buttonCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.buttonCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(111)))), ((int)(((byte)(111)))));
            this.buttonCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancelar.ForeColor = System.Drawing.Color.White;
            this.buttonCancelar.Location = new System.Drawing.Point(29, 319);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelar.TabIndex = 20;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(306, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(268, 24);
            this.label1.TabIndex = 19;
            this.label1.Text = "PAPELERA DE ACTIVIDADES";
            // 
            // buttonRestaurar
            // 
            this.buttonRestaurar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonRestaurar.FlatAppearance.BorderSize = 2;
            this.buttonRestaurar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.buttonRestaurar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(111)))), ((int)(((byte)(111)))));
            this.buttonRestaurar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRestaurar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRestaurar.ForeColor = System.Drawing.Color.White;
            this.buttonRestaurar.Location = new System.Drawing.Point(698, 85);
            this.buttonRestaurar.Name = "buttonRestaurar";
            this.buttonRestaurar.Size = new System.Drawing.Size(75, 23);
            this.buttonRestaurar.TabIndex = 26;
            this.buttonRestaurar.Text = "Restaurar";
            this.buttonRestaurar.UseVisualStyleBackColor = true;
            this.buttonRestaurar.Click += new System.EventHandler(this.buttonRestaurar_Click);
            // 
            // buttonEliminar
            // 
            this.buttonEliminar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonEliminar.FlatAppearance.BorderSize = 2;
            this.buttonEliminar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.buttonEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(111)))), ((int)(((byte)(111)))));
            this.buttonEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEliminar.ForeColor = System.Drawing.Color.White;
            this.buttonEliminar.Location = new System.Drawing.Point(616, 85);
            this.buttonEliminar.Name = "buttonEliminar";
            this.buttonEliminar.Size = new System.Drawing.Size(64, 23);
            this.buttonEliminar.TabIndex = 27;
            this.buttonEliminar.Text = "Eliminar";
            this.buttonEliminar.UseVisualStyleBackColor = true;
            this.buttonEliminar.Click += new System.EventHandler(this.buttonEliminar_Click);
            // 
            // buttonGenerarPDF
            // 
            this.buttonGenerarPDF.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonGenerarPDF.FlatAppearance.BorderSize = 2;
            this.buttonGenerarPDF.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.buttonGenerarPDF.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(111)))), ((int)(((byte)(111)))));
            this.buttonGenerarPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGenerarPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGenerarPDF.ForeColor = System.Drawing.Color.White;
            this.buttonGenerarPDF.Location = new System.Drawing.Point(688, 319);
            this.buttonGenerarPDF.Name = "buttonGenerarPDF";
            this.buttonGenerarPDF.Size = new System.Drawing.Size(85, 23);
            this.buttonGenerarPDF.TabIndex = 28;
            this.buttonGenerarPDF.Text = "Generar PDF";
            this.buttonGenerarPDF.UseVisualStyleBackColor = true;
            this.buttonGenerarPDF.Click += new System.EventHandler(this.buttonGenerarPDF_Click);
            // 
            // VsPapeleraActividad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(812, 374);
            this.Controls.Add(this.buttonGenerarPDF);
            this.Controls.Add(this.buttonEliminar);
            this.Controls.Add(this.buttonRestaurar);
            this.Controls.Add(this.dgvActividad);
            this.Controls.Add(this.buttonBuscar);
            this.Controls.Add(this.radioButtonDescripcion);
            this.Controls.Add(this.radioButtonNombre);
            this.Controls.Add(this.textBuscar);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "VsPapeleraActividad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Papelera de Actividades";
            ((System.ComponentModel.ISupportInitialize)(this.dgvActividad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvActividad;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmFechaInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmFechaFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmHoraInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmHoraFin;
        private System.Windows.Forms.Button buttonBuscar;
        private System.Windows.Forms.RadioButton radioButtonDescripcion;
        private System.Windows.Forms.RadioButton radioButtonNombre;
        private System.Windows.Forms.TextBox textBuscar;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonRestaurar;
        private System.Windows.Forms.Button buttonEliminar;
        private System.Windows.Forms.Button buttonGenerarPDF;
    }
}