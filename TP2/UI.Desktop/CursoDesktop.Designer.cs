namespace UI.Desktop
{
    partial class CursoDesktop
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
            this.lblID = new System.Windows.Forms.Label();
            this.lblPlan = new System.Windows.Forms.Label();
            this.lblMateria = new System.Windows.Forms.Label();
            this.lblComision = new System.Windows.Forms.Label();
            this.lblAnio = new System.Windows.Forms.Label();
            this.lblCupo = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.cmbPlan = new System.Windows.Forms.ComboBox();
            this.cmbMateria = new System.Windows.Forms.ComboBox();
            this.cmbComision = new System.Windows.Forms.ComboBox();
            this.txtAnio = new System.Windows.Forms.TextBox();
            this.txtCupo = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(72, 28);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(18, 13);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "ID";
            // 
            // lblPlan
            // 
            this.lblPlan.AutoSize = true;
            this.lblPlan.Location = new System.Drawing.Point(62, 59);
            this.lblPlan.Name = "lblPlan";
            this.lblPlan.Size = new System.Drawing.Size(28, 13);
            this.lblPlan.TabIndex = 1;
            this.lblPlan.Text = "Plan";
            // 
            // lblMateria
            // 
            this.lblMateria.AutoSize = true;
            this.lblMateria.Location = new System.Drawing.Point(48, 90);
            this.lblMateria.Name = "lblMateria";
            this.lblMateria.Size = new System.Drawing.Size(42, 13);
            this.lblMateria.TabIndex = 2;
            this.lblMateria.Text = "Materia";
            // 
            // lblComision
            // 
            this.lblComision.AutoSize = true;
            this.lblComision.Location = new System.Drawing.Point(41, 121);
            this.lblComision.Name = "lblComision";
            this.lblComision.Size = new System.Drawing.Size(49, 13);
            this.lblComision.TabIndex = 3;
            this.lblComision.Text = "Comisión";
            // 
            // lblAnio
            // 
            this.lblAnio.AutoSize = true;
            this.lblAnio.Location = new System.Drawing.Point(11, 152);
            this.lblAnio.Name = "lblAnio";
            this.lblAnio.Size = new System.Drawing.Size(79, 13);
            this.lblAnio.TabIndex = 4;
            this.lblAnio.Text = "Año Calendario";
            // 
            // lblCupo
            // 
            this.lblCupo.AutoSize = true;
            this.lblCupo.Location = new System.Drawing.Point(58, 183);
            this.lblCupo.Name = "lblCupo";
            this.lblCupo.Size = new System.Drawing.Size(32, 13);
            this.lblCupo.TabIndex = 5;
            this.lblCupo.Text = "Cupo";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(105, 25);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(100, 20);
            this.txtID.TabIndex = 6;
            // 
            // cmbPlan
            // 
            this.cmbPlan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlan.FormattingEnabled = true;
            this.cmbPlan.Location = new System.Drawing.Point(105, 56);
            this.cmbPlan.Name = "cmbPlan";
            this.cmbPlan.Size = new System.Drawing.Size(205, 21);
            this.cmbPlan.TabIndex = 7;
            // 
            // cmbMateria
            // 
            this.cmbMateria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMateria.FormattingEnabled = true;
            this.cmbMateria.Location = new System.Drawing.Point(105, 87);
            this.cmbMateria.Name = "cmbMateria";
            this.cmbMateria.Size = new System.Drawing.Size(205, 21);
            this.cmbMateria.Sorted = true;
            this.cmbMateria.TabIndex = 8;
            // 
            // cmbComision
            // 
            this.cmbComision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbComision.FormattingEnabled = true;
            this.cmbComision.Location = new System.Drawing.Point(105, 118);
            this.cmbComision.Name = "cmbComision";
            this.cmbComision.Size = new System.Drawing.Size(205, 21);
            this.cmbComision.Sorted = true;
            this.cmbComision.TabIndex = 9;
            // 
            // txtAnio
            // 
            this.txtAnio.Location = new System.Drawing.Point(105, 149);
            this.txtAnio.Name = "txtAnio";
            this.txtAnio.Size = new System.Drawing.Size(100, 20);
            this.txtAnio.TabIndex = 10;
            // 
            // txtCupo
            // 
            this.txtCupo.Location = new System.Drawing.Point(105, 180);
            this.txtCupo.Name = "txtCupo";
            this.txtCupo.Size = new System.Drawing.Size(100, 20);
            this.txtCupo.TabIndex = 11;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(235, 227);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 12;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(154, 227);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 13;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // CursoDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 262);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.txtCupo);
            this.Controls.Add(this.txtAnio);
            this.Controls.Add(this.cmbComision);
            this.Controls.Add(this.cmbMateria);
            this.Controls.Add(this.cmbPlan);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.lblCupo);
            this.Controls.Add(this.lblAnio);
            this.Controls.Add(this.lblComision);
            this.Controls.Add(this.lblMateria);
            this.Controls.Add(this.lblPlan);
            this.Controls.Add(this.lblID);
            this.Name = "CursoDesktop";
            this.Text = "CursoDesktop";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblPlan;
        private System.Windows.Forms.Label lblMateria;
        private System.Windows.Forms.Label lblComision;
        private System.Windows.Forms.Label lblAnio;
        private System.Windows.Forms.Label lblCupo;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.ComboBox cmbPlan;
        private System.Windows.Forms.ComboBox cmbMateria;
        private System.Windows.Forms.ComboBox cmbComision;
        private System.Windows.Forms.TextBox txtAnio;
        private System.Windows.Forms.TextBox txtCupo;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
    }
}