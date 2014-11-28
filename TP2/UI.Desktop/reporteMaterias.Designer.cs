namespace UI.Desktop
{
    partial class reporteMaterias
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.MateriaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DataSet1 = new UI.Desktop.DataSet1();
            this.SPreporteAlumnosYMateriasDocentesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SPreporteAlumnosYMateriasDocentesTableAdapter = new UI.Desktop.DataSet1TableAdapters.SPreporteAlumnosYMateriasDocentesTableAdapter();
            this.SPEstadoAcademicoAlumnoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SPEstadoAcademicoAlumnoTableAdapter = new UI.Desktop.DataSet1TableAdapters.SPEstadoAcademicoAlumnoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.MateriaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SPreporteAlumnosYMateriasDocentesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SPEstadoAcademicoAlumnoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // MateriaBindingSource
            // 
            this.MateriaBindingSource.DataSource = typeof(Business.Entities.Materia);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet2";
            reportDataSource1.Value = this.SPEstadoAcademicoAlumnoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "UI.Desktop.reporteMateriasXPlan.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(657, 283);
            this.reportViewer1.TabIndex = 0;
            // 
            // DataSet1
            // 
            this.DataSet1.DataSetName = "DataSet1";
            this.DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // SPreporteAlumnosYMateriasDocentesBindingSource
            // 
            this.SPreporteAlumnosYMateriasDocentesBindingSource.DataMember = "SPreporteAlumnosYMateriasDocentes";
            this.SPreporteAlumnosYMateriasDocentesBindingSource.DataSource = this.DataSet1;
            // 
            // SPreporteAlumnosYMateriasDocentesTableAdapter
            // 
            this.SPreporteAlumnosYMateriasDocentesTableAdapter.ClearBeforeFill = true;
            // 
            // SPEstadoAcademicoAlumnoBindingSource
            // 
            this.SPEstadoAcademicoAlumnoBindingSource.DataMember = "SPEstadoAcademicoAlumno";
            this.SPEstadoAcademicoAlumnoBindingSource.DataSource = this.DataSet1;
            // 
            // SPEstadoAcademicoAlumnoTableAdapter
            // 
            this.SPEstadoAcademicoAlumnoTableAdapter.ClearBeforeFill = true;
            // 
            // reporteMaterias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 283);
            this.Controls.Add(this.reportViewer1);
            this.Name = "reporteMaterias";
            this.Text = "reporteMaterias";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.reporteMaterias_FormClosing);
            this.Load += new System.EventHandler(this.reporteMaterias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MateriaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SPreporteAlumnosYMateriasDocentesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SPEstadoAcademicoAlumnoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource MateriaBindingSource;
        private System.Windows.Forms.BindingSource SPreporteAlumnosYMateriasDocentesBindingSource;
        private DataSet1 DataSet1;
        private DataSet1TableAdapters.SPreporteAlumnosYMateriasDocentesTableAdapter SPreporteAlumnosYMateriasDocentesTableAdapter;
        private System.Windows.Forms.BindingSource SPEstadoAcademicoAlumnoBindingSource;
        private DataSet1TableAdapters.SPEstadoAcademicoAlumnoTableAdapter SPEstadoAcademicoAlumnoTableAdapter;

    }
}