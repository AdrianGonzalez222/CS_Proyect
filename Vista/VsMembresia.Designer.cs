﻿namespace Vista
{
    partial class VsMembresia
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
            this.labelTitulo = new System.Windows.Forms.Label();
            this.labelC = new System.Windows.Forms.Label();
            this.labelM = new System.Windows.Forms.Label();
            this.labelFI = new System.Windows.Forms.Label();
            this.labelFF = new System.Windows.Forms.Label();
            this.labelP = new System.Windows.Forms.Label();
            this.labelDP = new System.Windows.Forms.Label();
            this.labelD = new System.Windows.Forms.Label();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.btnAnular = new System.Windows.Forms.Button();
            this.txtBoxC = new System.Windows.Forms.TextBox();
            this.txtBoxM = new System.Windows.Forms.TextBox();
            this.dateTPFI = new System.Windows.Forms.DateTimePicker();
            this.dateTPFF = new System.Windows.Forms.DateTimePicker();
            this.comboBoxP = new System.Windows.Forms.ComboBox();
            this.txtBoxDP = new System.Windows.Forms.TextBox();
            this.txtBoxD = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo.Location = new System.Drawing.Point(294, 9);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(199, 39);
            this.labelTitulo.TabIndex = 0;
            this.labelTitulo.Text = "Membresía";
            this.labelTitulo.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelC
            // 
            this.labelC.AutoSize = true;
            this.labelC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelC.Location = new System.Drawing.Point(142, 67);
            this.labelC.Name = "labelC";
            this.labelC.Size = new System.Drawing.Size(50, 13);
            this.labelC.TabIndex = 1;
            this.labelC.Text = "Cédula:";
            // 
            // labelM
            // 
            this.labelM.AutoSize = true;
            this.labelM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelM.Location = new System.Drawing.Point(121, 93);
            this.labelM.Name = "labelM";
            this.labelM.Size = new System.Drawing.Size(71, 13);
            this.labelM.TabIndex = 2;
            this.labelM.Text = "Membresia:";
            // 
            // labelFI
            // 
            this.labelFI.AutoSize = true;
            this.labelFI.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFI.Location = new System.Drawing.Point(112, 119);
            this.labelFI.Name = "labelFI";
            this.labelFI.Size = new System.Drawing.Size(80, 13);
            this.labelFI.TabIndex = 3;
            this.labelFI.Text = "Fecha inicio:";
            // 
            // labelFF
            // 
            this.labelFF.AutoSize = true;
            this.labelFF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFF.Location = new System.Drawing.Point(128, 146);
            this.labelFF.Name = "labelFF";
            this.labelFF.Size = new System.Drawing.Size(64, 13);
            this.labelFF.TabIndex = 4;
            this.labelFF.Text = "Fecha fin:";
            // 
            // labelP
            // 
            this.labelP.AutoSize = true;
            this.labelP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelP.Location = new System.Drawing.Point(122, 173);
            this.labelP.Name = "labelP";
            this.labelP.Size = new System.Drawing.Size(70, 13);
            this.labelP.TabIndex = 5;
            this.labelP.Text = "Promoción:";
            // 
            // labelDP
            // 
            this.labelDP.AutoSize = true;
            this.labelDP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDP.Location = new System.Drawing.Point(72, 194);
            this.labelDP.Name = "labelDP";
            this.labelDP.Size = new System.Drawing.Size(120, 13);
            this.labelDP.TabIndex = 6;
            this.labelDP.Text = "Detalles Promoción:";
            // 
            // labelD
            // 
            this.labelD.AutoSize = true;
            this.labelD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelD.Location = new System.Drawing.Point(120, 262);
            this.labelD.Name = "labelD";
            this.labelD.Size = new System.Drawing.Size(72, 13);
            this.labelD.TabIndex = 7;
            this.labelD.Text = "Descuento:";
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrar.Location = new System.Drawing.Point(294, 298);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(75, 23);
            this.btnRegistrar.TabIndex = 8;
            this.btnRegistrar.Text = "Registrar ";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // btnAnular
            // 
            this.btnAnular.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnular.Location = new System.Drawing.Point(418, 298);
            this.btnAnular.Name = "btnAnular";
            this.btnAnular.Size = new System.Drawing.Size(75, 23);
            this.btnAnular.TabIndex = 9;
            this.btnAnular.Text = "Anular";
            this.btnAnular.UseVisualStyleBackColor = true;
            this.btnAnular.Click += new System.EventHandler(this.btnAnular_Click);
            // 
            // txtBoxC
            // 
            this.txtBoxC.Location = new System.Drawing.Point(294, 60);
            this.txtBoxC.Name = "txtBoxC";
            this.txtBoxC.Size = new System.Drawing.Size(199, 20);
            this.txtBoxC.TabIndex = 10;
            this.txtBoxC.TextChanged += new System.EventHandler(this.txtBoxC_TextChanged);
            this.txtBoxC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxC_KeyPress);
            // 
            // txtBoxM
            // 
            this.txtBoxM.Location = new System.Drawing.Point(295, 86);
            this.txtBoxM.Name = "txtBoxM";
            this.txtBoxM.Size = new System.Drawing.Size(199, 20);
            this.txtBoxM.TabIndex = 11;
            this.txtBoxM.TextChanged += new System.EventHandler(this.txtBoxM_TextChanged);
            this.txtBoxM.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxM_KeyPress);
            // 
            // dateTPFI
            // 
            this.dateTPFI.Location = new System.Drawing.Point(295, 112);
            this.dateTPFI.Name = "dateTPFI";
            this.dateTPFI.Size = new System.Drawing.Size(200, 20);
            this.dateTPFI.TabIndex = 12;
            // 
            // dateTPFF
            // 
            this.dateTPFF.Location = new System.Drawing.Point(295, 139);
            this.dateTPFF.Name = "dateTPFF";
            this.dateTPFF.Size = new System.Drawing.Size(200, 20);
            this.dateTPFF.TabIndex = 13;
            // 
            // comboBoxP
            // 
            this.comboBoxP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxP.FormattingEnabled = true;
            this.comboBoxP.Items.AddRange(new object[] {
            "SI",
            "NO"});
            this.comboBoxP.Location = new System.Drawing.Point(295, 165);
            this.comboBoxP.Name = "comboBoxP";
            this.comboBoxP.Size = new System.Drawing.Size(47, 21);
            this.comboBoxP.TabIndex = 14;
            this.comboBoxP.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // txtBoxDP
            // 
            this.txtBoxDP.Location = new System.Drawing.Point(294, 191);
            this.txtBoxDP.Multiline = true;
            this.txtBoxDP.Name = "txtBoxDP";
            this.txtBoxDP.Size = new System.Drawing.Size(200, 58);
            this.txtBoxDP.TabIndex = 15;
            this.txtBoxDP.TextChanged += new System.EventHandler(this.txtBoxDP_TextChanged);
            this.txtBoxDP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxDP_KeyPress);
            // 
            // txtBoxD
            // 
            this.txtBoxD.Location = new System.Drawing.Point(294, 255);
            this.txtBoxD.Name = "txtBoxD";
            this.txtBoxD.Size = new System.Drawing.Size(199, 20);
            this.txtBoxD.TabIndex = 16;
            this.txtBoxD.TextChanged += new System.EventHandler(this.txtBoxD_TextChanged);
            this.txtBoxD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxD_KeyPress);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Vista.Properties.Resources.Img_Gym2;
            this.pictureBox1.Location = new System.Drawing.Point(564, 40);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(187, 269);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // VsMembresia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtBoxD);
            this.Controls.Add(this.txtBoxDP);
            this.Controls.Add(this.comboBoxP);
            this.Controls.Add(this.dateTPFF);
            this.Controls.Add(this.dateTPFI);
            this.Controls.Add(this.txtBoxM);
            this.Controls.Add(this.txtBoxC);
            this.Controls.Add(this.btnAnular);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.labelD);
            this.Controls.Add(this.labelDP);
            this.Controls.Add(this.labelP);
            this.Controls.Add(this.labelFF);
            this.Controls.Add(this.labelFI);
            this.Controls.Add(this.labelM);
            this.Controls.Add(this.labelC);
            this.Controls.Add(this.labelTitulo);
            this.Name = "VsMembresia";
            this.Text = "Modulo Membresia";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Label labelC;
        private System.Windows.Forms.Label labelM;
        private System.Windows.Forms.Label labelFI;
        private System.Windows.Forms.Label labelFF;
        private System.Windows.Forms.Label labelP;
        private System.Windows.Forms.Label labelDP;
        private System.Windows.Forms.Label labelD;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Button btnAnular;
        private System.Windows.Forms.TextBox txtBoxC;
        private System.Windows.Forms.TextBox txtBoxM;
        private System.Windows.Forms.DateTimePicker dateTPFI;
        private System.Windows.Forms.DateTimePicker dateTPFF;
        private System.Windows.Forms.ComboBox comboBoxP;
        private System.Windows.Forms.TextBox txtBoxDP;
        private System.Windows.Forms.TextBox txtBoxD;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}