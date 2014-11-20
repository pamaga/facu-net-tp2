namespace UI.Desktop
{
    partial class Comisiones
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
            this.components = new System.ComponentModel.Container();
            this.tlUsuarios = new System.Windows.Forms.TableLayoutPanel();
            this.dgvComisiones = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tsUsuarios = new System.Windows.Forms.ToolStrip();
            this.tsbNuevo = new System.Windows.Forms.ToolStripButton();
            this.tsbEditar = new System.Windows.Forms.ToolStripButton();
            this.tsbEliminar = new System.Windows.Forms.ToolStripButton();
            this.comisionLogicBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AnioEspecialidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlanDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tlUsuarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComisiones)).BeginInit();
            this.tsUsuarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comisionLogicBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tlUsuarios
            // 
            this.tlUsuarios.ColumnCount = 2;
            this.tlUsuarios.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlUsuarios.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlUsuarios.Controls.Add(this.dgvComisiones, 0, 0);
            this.tlUsuarios.Controls.Add(this.button3, 0, 1);
            this.tlUsuarios.Controls.Add(this.button4, 1, 1);
            this.tlUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlUsuarios.Location = new System.Drawing.Point(0, 25);
            this.tlUsuarios.Name = "tlUsuarios";
            this.tlUsuarios.RowCount = 2;
            this.tlUsuarios.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlUsuarios.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlUsuarios.Size = new System.Drawing.Size(484, 237);
            this.tlUsuarios.TabIndex = 11;
            // 
            // dgvComisiones
            // 
            this.dgvComisiones.AllowUserToAddRows = false;
            this.dgvComisiones.AllowUserToDeleteRows = false;
            this.dgvComisiones.AllowUserToResizeColumns = false;
            this.dgvComisiones.AllowUserToResizeRows = false;
            this.dgvComisiones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvComisiones.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvComisiones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComisiones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.AnioEspecialidad,
            this.Descripcion,
            this.PlanDescripcion});
            this.tlUsuarios.SetColumnSpan(this.dgvComisiones, 2);
            this.dgvComisiones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvComisiones.Location = new System.Drawing.Point(3, 3);
            this.dgvComisiones.MultiSelect = false;
            this.dgvComisiones.Name = "dgvComisiones";
            this.dgvComisiones.ReadOnly = true;
            this.dgvComisiones.RowHeadersVisible = false;
            this.dgvComisiones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvComisiones.Size = new System.Drawing.Size(478, 202);
            this.dgvComisiones.TabIndex = 0;
            this.dgvComisiones.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvComisiones_CellDoubleClick);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(325, 211);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 1;
            this.button3.Text = "Actualizar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(406, 211);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 2;
            this.button4.Text = "Salir";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(320, 227);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Actualizar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(401, 227);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Salir";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // tsUsuarios
            // 
            this.tsUsuarios.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNuevo,
            this.tsbEditar,
            this.tsbEliminar});
            this.tsUsuarios.Location = new System.Drawing.Point(0, 0);
            this.tsUsuarios.Name = "tsUsuarios";
            this.tsUsuarios.Size = new System.Drawing.Size(484, 25);
            this.tsUsuarios.TabIndex = 8;
            // 
            // tsbNuevo
            // 
            this.tsbNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNuevo.Image = global::UI.Desktop.Properties.Resources.add;
            this.tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNuevo.Name = "tsbNuevo";
            this.tsbNuevo.Size = new System.Drawing.Size(23, 22);
            this.tsbNuevo.Text = "Nuevo";
            this.tsbNuevo.ToolTipText = "Nuevo";
            this.tsbNuevo.Click += new System.EventHandler(this.tsbNuevo_Click);
            // 
            // tsbEditar
            // 
            this.tsbEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEditar.Image = global::UI.Desktop.Properties.Resources.pencil;
            this.tsbEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditar.Name = "tsbEditar";
            this.tsbEditar.Size = new System.Drawing.Size(23, 22);
            this.tsbEditar.Text = "Editar";
            this.tsbEditar.ToolTipText = "Editar";
            this.tsbEditar.Click += new System.EventHandler(this.tsbEditar_Click);
            // 
            // tsbEliminar
            // 
            this.tsbEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEliminar.Image = global::UI.Desktop.Properties.Resources.delete;
            this.tsbEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEliminar.Name = "tsbEliminar";
            this.tsbEliminar.Size = new System.Drawing.Size(23, 22);
            this.tsbEliminar.Text = "Eliminar";
            this.tsbEliminar.ToolTipText = "Eliminar";
            this.tsbEliminar.Click += new System.EventHandler(this.tsbEliminar_Click);
            // 
            // comisionLogicBindingSource
            // 
            this.comisionLogicBindingSource.DataSource = typeof(Business.Logic.ComisionLogic);
            // 
            // id
            // 
            this.id.DataPropertyName = "ID";
            this.id.FillWeight = 64F;
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // AnioEspecialidad
            // 
            this.AnioEspecialidad.DataPropertyName = "AnioEspecialidad";
            this.AnioEspecialidad.HeaderText = "Año Especialidad";
            this.AnioEspecialidad.Name = "AnioEspecialidad";
            this.AnioEspecialidad.ReadOnly = true;
            // 
            // Descripcion
            // 
            this.Descripcion.DataPropertyName = "Descripcion";
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            // 
            // PlanDescripcion
            // 
            this.PlanDescripcion.DataPropertyName = "PlanDescripcion";
            this.PlanDescripcion.HeaderText = "Plan - Especialidad";
            this.PlanDescripcion.Name = "PlanDescripcion";
            this.PlanDescripcion.ReadOnly = true;
            // 
            // Comisiones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 262);
            this.Controls.Add(this.tlUsuarios);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tsUsuarios);
            this.Name = "Comisiones";
            this.Text = "Comisiones";
            this.Load += new System.EventHandler(this.Comisiones_Load);
            this.tlUsuarios.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvComisiones)).EndInit();
            this.tsUsuarios.ResumeLayout(false);
            this.tsUsuarios.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comisionLogicBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsUsuarios;
        private System.Windows.Forms.ToolStripButton tsbNuevo;
        private System.Windows.Forms.ToolStripButton tsbEditar;
        private System.Windows.Forms.ToolStripButton tsbEliminar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TableLayoutPanel tlUsuarios;
        private System.Windows.Forms.DataGridView dgvComisiones;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.BindingSource comisionLogicBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn AnioEspecialidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlanDescripcion;
    }
}