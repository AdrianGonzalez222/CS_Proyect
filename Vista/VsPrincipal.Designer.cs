namespace Vista
{
    partial class VsPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelTituloGym = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.btnVerRegistroFact = new System.Windows.Forms.Button();
            this.btnGM = new System.Windows.Forms.Button();
            this.buttonGestionActividad = new System.Windows.Forms.Button();
            this.btnMembresia = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTituloGym
            // 
            this.labelTituloGym.AutoSize = true;
            this.labelTituloGym.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTituloGym.Location = new System.Drawing.Point(0, 0);
            this.labelTituloGym.Name = "labelTituloGym";
            this.labelTituloGym.Size = new System.Drawing.Size(0, 55);
            this.labelTituloGym.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.btnRegistrar);
            this.panel1.Controls.Add(this.btnVerRegistroFact);
            this.panel1.Controls.Add(this.btnGM);
            this.panel1.Controls.Add(this.buttonGestionActividad);
            this.panel1.Controls.Add(this.btnMembresia);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(668, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(184, 489);
            this.panel1.TabIndex = 8;
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.BackColor = System.Drawing.Color.Transparent;
            this.btnRegistrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegistrar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnRegistrar.FlatAppearance.BorderSize = 2;
            this.btnRegistrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnRegistrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(111)))), ((int)(((byte)(111)))));
            this.btnRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrar.ForeColor = System.Drawing.Color.White;
            this.btnRegistrar.Image = global::Vista.Properties.Resources.Img_RegistroUser;
            this.btnRegistrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegistrar.Location = new System.Drawing.Point(18, 76);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(143, 49);
            this.btnRegistrar.TabIndex = 4;
            this.btnRegistrar.Text = "Registrar cliente";
            this.btnRegistrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRegistrar.UseVisualStyleBackColor = false;
            this.btnRegistrar.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnVerRegistroFact
            // 
            this.btnVerRegistroFact.BackColor = System.Drawing.Color.Transparent;
            this.btnVerRegistroFact.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerRegistroFact.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnVerRegistroFact.FlatAppearance.BorderSize = 2;
            this.btnVerRegistroFact.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnVerRegistroFact.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(111)))), ((int)(((byte)(111)))));
            this.btnVerRegistroFact.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerRegistroFact.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerRegistroFact.ForeColor = System.Drawing.Color.White;
            this.btnVerRegistroFact.Image = global::Vista.Properties.Resources.gestion1_img;
            this.btnVerRegistroFact.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVerRegistroFact.Location = new System.Drawing.Point(18, 383);
            this.btnVerRegistroFact.Margin = new System.Windows.Forms.Padding(2);
            this.btnVerRegistroFact.Name = "btnVerRegistroFact";
            this.btnVerRegistroFact.Size = new System.Drawing.Size(143, 54);
            this.btnVerRegistroFact.TabIndex = 64;
            this.btnVerRegistroFact.Text = "Gestion facturas";
            this.btnVerRegistroFact.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVerRegistroFact.UseVisualStyleBackColor = false;
            this.btnVerRegistroFact.Click += new System.EventHandler(this.btnVerRegistroFact_Click);
            // 
            // btnGM
            // 
            this.btnGM.BackColor = System.Drawing.Color.Transparent;
            this.btnGM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGM.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnGM.FlatAppearance.BorderSize = 2;
            this.btnGM.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnGM.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(111)))), ((int)(((byte)(111)))));
            this.btnGM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGM.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGM.ForeColor = System.Drawing.Color.White;
            this.btnGM.Image = global::Vista.Properties.Resources.gestion1_img;
            this.btnGM.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGM.Location = new System.Drawing.Point(18, 225);
            this.btnGM.Name = "btnGM";
            this.btnGM.Size = new System.Drawing.Size(143, 53);
            this.btnGM.TabIndex = 8;
            this.btnGM.Text = "Gestion Membresia";
            this.btnGM.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGM.UseVisualStyleBackColor = false;
            this.btnGM.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // buttonGestionActividad
            // 
            this.buttonGestionActividad.BackColor = System.Drawing.Color.Black;
            this.buttonGestionActividad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonGestionActividad.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonGestionActividad.FlatAppearance.BorderSize = 2;
            this.buttonGestionActividad.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.buttonGestionActividad.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(111)))), ((int)(((byte)(111)))));
            this.buttonGestionActividad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGestionActividad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGestionActividad.ForeColor = System.Drawing.Color.White;
            this.buttonGestionActividad.Image = global::Vista.Properties.Resources.gestion1_img;
            this.buttonGestionActividad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGestionActividad.Location = new System.Drawing.Point(18, 305);
            this.buttonGestionActividad.Name = "buttonGestionActividad";
            this.buttonGestionActividad.Size = new System.Drawing.Size(143, 53);
            this.buttonGestionActividad.TabIndex = 7;
            this.buttonGestionActividad.Text = "Gestion Actividad";
            this.buttonGestionActividad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonGestionActividad.UseVisualStyleBackColor = false;
            this.buttonGestionActividad.Click += new System.EventHandler(this.buttonGestionActividad_Click);
            // 
            // btnMembresia
            // 
            this.btnMembresia.BackColor = System.Drawing.Color.Transparent;
            this.btnMembresia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMembresia.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnMembresia.FlatAppearance.BorderSize = 2;
            this.btnMembresia.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnMembresia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(111)))), ((int)(((byte)(111)))));
            this.btnMembresia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMembresia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMembresia.ForeColor = System.Drawing.Color.White;
            this.btnMembresia.Image = global::Vista.Properties.Resources.gestion1_img;
            this.btnMembresia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMembresia.Location = new System.Drawing.Point(18, 146);
            this.btnMembresia.Name = "btnMembresia";
            this.btnMembresia.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnMembresia.Size = new System.Drawing.Size(143, 53);
            this.btnMembresia.TabIndex = 5;
            this.btnMembresia.Text = "Gestionar cliente";
            this.btnMembresia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMembresia.UseVisualStyleBackColor = false;
            this.btnMembresia.Click += new System.EventHandler(this.btnMembresia_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(201, 489);
            this.panel2.TabIndex = 9;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Vista.Properties.Resources.Gym_rat_letra_Img;
            this.pictureBox1.Location = new System.Drawing.Point(207, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(455, 142);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Vista.Properties.Resources.img_rataPrincipal;
            this.pictureBox2.Location = new System.Drawing.Point(278, 100);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(331, 389);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // VsPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(852, 489);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.labelTituloGym);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "VsPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Principal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VsPrincipal_FormClosing);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelTituloGym;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Button btnMembresia;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonGestionActividad;
        private System.Windows.Forms.Button btnGM;
        private System.Windows.Forms.Button btnVerRegistroFact;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

