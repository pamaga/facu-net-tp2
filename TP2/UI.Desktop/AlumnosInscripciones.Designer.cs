namespace UI.Desktop
{
    partial class AlumnosInscripciones
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
            this.tscAluInsc = new System.Windows.Forms.ToolStripContainer();
            this.tlpAluInsc = new System.Windows.Forms.TableLayoutPanel();
            this.dgvAluInsc = new System.Windows.Forms.DataGridView();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.tsAluInsc = new System.Windows.Forms.ToolStrip();
            this.btnNuevo = new System.Windows.Forms.ToolStripButton();
            this.btnEditar = new System.Windows.Forms.ToolStripButton();
            this.btnEliminar = new System.Windows.Forms.ToolStripButton();
            this.IdInscripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Materia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Anio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Condicion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tscAluInsc.ContentPanel.SuspendLayout();
            this.tscAluInsc.TopToolStripPanel.SuspendLayout();
            this.tscAluInsc.SuspendLayout();
            this.tlpAluInsc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAluInsc)).BeginInit();
            this.tsAluInsc.SuspendLayout();
            this.SuspendLayout();
            // 
            // tscAluInsc
            // 
            // 
            // tscAluInsc.ContentPanel
            // 
            this.tscAluInsc.ContentPanel.Controls.Add(this.tlpAluInsc);
            this.tscAluInsc.ContentPanel.Size = new System.Drawing.Size(584, 237);
            this.tscAluInsc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tscAluInsc.Location = new System.Drawing.Point(0, 0);
            this.tscAluInsc.Name = "tscAluInsc";
            this.tscAluInsc.Size = new System.Drawing.Size(584, 262);
            this.tscAluInsc.TabIndex = 0;
            this.tscAluInsc.Text = "toolStripContainer1";
            // 
            // tscAluInsc.TopToolStripPanel
            // 
            this.tscAluInsc.TopToolStripPanel.Controls.Add(this.tsAluInsc);
            // 
            // tlpAluInsc
            // 
            this.tlpAluInsc.ColumnCount = 2;
            this.tlpAluInsc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpAluInsc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpAluInsc.Controls.Add(this.dgvAluInsc, 0, 0);
            this.tlpAluInsc.Controls.Add(this.btnSalir, 1, 1);
            this.tlpAluInsc.Controls.Add(this.btnActualizar, 0, 1);
            this.tlpAluInsc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpAluInsc.Location = new System.Drawing.Point(0, 0);
            this.tlpAluInsc.Name = "tlpAluInsc";
            this.tlpAluInsc.RowCount = 2;
            this.tlpAluInsc.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpAluInsc.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpAluInsc.Size = new System.Drawing.Size(584, 237);
            this.tlpAluInsc.TabIndex = 0;
            // 
            // dgvAluInsc
            // 
            this.dgvAluInsc.AllowUserToAddRows = false;
            this.dgvAluInsc.AllowUserToDeleteRows = false;
            this.dgvAluInsc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvAluInsc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAluInsc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdInscripcion,
            this.Materia,
            this.Comision,
            this.Anio,
            this.Condicion,
            this.Nota});
            this.tlpAluInsc.SetColumnSpan(this.dgvAluInsc, 2);
            this.dgvAluInsc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAluInsc.Location = new System.Drawing.Point(3, 3);
            this.dgvAluInsc.Name = "dgvAluInsc";
            this.dgvAluInsc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAluInsc.Size = new System.Drawing.Size(578, 202);
            this.dgvAluInsc.TabIndex = 0;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(506, 211);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.Location = new System.Drawing.Point(425, 211);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(75, 23);
            this.btnActualizar.TabIndex = 2;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            // 
            // tsAluInsc
            // 
            this.tsAluInsc.Dock = System.Windows.Forms.DockStyle.None;
            this.tsAluInsc.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNuevo,
            this.btnEditar,
            this.btnEliminar});
            this.tsAluInsc.Location = new System.Drawing.Point(3, 0);
            this.tsAluInsc.Name = "tsAluInsc";
            this.tsAluInsc.Size = new System.Drawing.Size(81, 25);
            this.tsAluInsc.TabIndex = 0;
            // 
            // btnNuevo
            // 
            this.btnNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNuevo.Image = global::UI.Desktop.Properties.Resources.add;
            this.btnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(23, 22);
            this.btnNuevo.Text = "toolStripButton1";
            this.btnNuevo.ToolTipText = "Nuevo";
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEditar.Image = global::UI.Desktop.Properties.Resources.pencil;
            this.btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(23, 22);
            this.btnEditar.Text = "toolStripButton1";
            this.btnEditar.ToolTipText = "Editar";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEliminar.Image = global::UI.Desktop.Properties.Resources.delete;
            this.btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(23, 22);
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // IdInscripcion
            // 
            this.IdInscripcion.DataPropertyName = "IdInscripcion";
            this.IdInscripcion.HeaderText = "ID";
            this.IdInscripcion.Name = "IdInscripcion";
            this.IdInscripcion.Width = 43;
            // 
            // Materia
            // 
            this.Materia.DataPropertyName = "Materia";
            this.Materia.HeaderText = "Materia";
            this.Materia.Name = "Materia";
            this.Materia.Width = 67;
            // 
            // Comision
            // 
            this.Comision.DataPropertyName = "Comision";
            this.Comision.HeaderText = "Comisión";
            this.Comision.Name = "Comision";
            this.Comision.Width = 74;
            // 
            // Anio
            // 
            this.Anio.DataPropertyName = "AnioCalendario";
            this.Anio.HeaderText = "Año";
            this.Anio.Name = "Anio";
            this.Anio.Width = 51;
            // 
            // Condicion
            // 
            this.Condicion.DataPropertyName = "Condicion";
            this.Condicion.HeaderText = "Condición";
            this.Condicion.Name = "Condicion";
            this.Condicion.Width = 79;
            // 
            // Nota
            // 
            this.Nota.DataPropertyName = "Nota";
            this.Nota.HeaderText = "Nota";
            this.Nota.Name = "Nota";
            this.Nota.Width = 55;
            // 
            // AlumnosInscripciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 262);
            this.Controls.Add(this.tscAluInsc);
            this.Name = "AlumnosInscripciones";
            this.Text = "AlumnosInscripciones";
            this.Load += new System.EventHandler(this.AlumnosInscripciones_Load);
            this.tscAluInsc.ContentPanel.ResumeLayout(false);
            this.tscAluInsc.TopToolStripPanel.ResumeLayout(false);
            this.tscAluInsc.TopToolStripPanel.PerformLayout();
            this.tscAluInsc.ResumeLayout(false);
            this.tscAluInsc.PerformLayout();
            this.tlpAluInsc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAluInsc)).EndInit();
            this.tsAluInsc.ResumeLayout(false);
            this.tsAluInsc.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer tscAluInsc;
        private System.Windows.Forms.TableLayoutPanel tlpAluInsc;
        private System.Windows.Forms.DataGridView dgvAluInsc;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.ToolStrip tsAluInsc;
        private System.Windows.Forms.ToolStripButton btnNuevo;
        private System.Windows.Forms.ToolStripButton btnEditar;
        private System.Windows.Forms.ToolStripButton btnEliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdInscripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Materia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comision;
        private System.Windows.Forms.DataGridViewTextBoxColumn Anio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Condicion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nota;

    }
}