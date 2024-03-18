using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Interna.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ExpedicionInternaPC
{
    public partial class frmIngresoEstadoReporte : frmChild
    {

        #region Propiedades

        public struct EstadoReporte
        {

            public bool bCumple { get; set; }

            public string sDescripcion { get; set; }

            public EstadoReporte(bool bCumple, string sDescripcion)
            {
                this.bCumple = bCumple;
                this.sDescripcion = sDescripcion;
            }
        }

        public List<ReportePeriodo> ListaReportePeriodo { get; set; }

        public List<EstadoReporte> ListaEstadosReporte = new List<EstadoReporte>() {
            new EstadoReporte(true, "Cumple"),
            new EstadoReporte(false, "No cumple"),
        };


        #endregion

        public frmIngresoEstadoReporte()
        {
            InitializeComponent();
        }

        public void ListarReportesPeriodo(int iIdPeriodo)
        {
            try
            {
                ListaReportePeriodo = Metodos.ListarReportesPeriodo(iIdPeriodo);
                int i = 0;
                panelReportes.Controls.Clear();
                foreach (ReportePeriodo item in ListaReportePeriodo)
                {

                    AgregarControlReporte(item, i);

                    i += 30;
                }



            }
            catch (InvalidTokenException)
            {

                Program.mensajeTokenInvalido();
            }

        }

        public void lookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            ((LookUpEdit)sender).Properties.Appearance.BackColor = (bool)((LookUpEdit)sender).EditValue ? Color.FromArgb(169, 208, 142) : Color.FromArgb(246, 113, 110);

        }

        public void ActualizarEstadosReporte()
        {

            if (Program.mensaje("Se actualizará el estado de los reportes. ¿Desea continuar?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                List<Dictionary<string, object>> estadosReporte = new List<Dictionary<string, object>>();
                foreach (ReportePeriodo item in ListaReportePeriodo)
                {
                    estadosReporte.Add(new Dictionary<string, object>() {
                    { "iId", item.iIdReportePeriodo },
                    { "bCumple", Convert.ToInt32(((LookUpEdit)panelReportes.Controls[item.sDescripcionReporte]).EditValue)}
                });
                }

                string estadosReporteJson = JsonConvert.SerializeObject(estadosReporte);

                try
                {
                    int respuesta = Metodos.ActualizarReportesPeriodo(estadosReporteJson);

                    if (respuesta == 1)
                    {
                        Program.mensaje("Se ha guardado el estado de los reportes correctamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        Program.mensaje("Ha ocurrido un error. Inténtelo nuevamente.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (InvalidTokenException)
                {
                    Program.mensajeTokenInvalido();
                }
            }
        }

        public void AgregarControlReporte(ReportePeriodo reportePeriodo, int lineaY)
        {

            Label label = new Label();
            label.Name = "lbl" + reportePeriodo.sDescripcionReporte;
            label.AutoSize = true;
            label.Text = reportePeriodo.sDescripcionReporte + ":";
            label.Left = 50;
            label.ForeColor = Color.Black;
            label.Top = lineaY;
            panelReportes.Controls.Add(label);
            LookUpEdit lookUpEdit = new LookUpEdit();
            lookUpEdit.Name = reportePeriodo.sDescripcionReporte;
            lookUpEdit.Properties.Columns.Add(new LookUpColumnInfo("bCumple", "Cumple")
            {
                Visible = false
            });
            lookUpEdit.Properties.Columns.Add(new LookUpColumnInfo("sDescripcion", "Descripcion"));
            lookUpEdit.Properties.DataSource = ListaEstadosReporte;
            lookUpEdit.Properties.DisplayMember = "sDescripcion";
            lookUpEdit.Properties.ValueMember = "bCumple";
            lookUpEdit.Properties.DropDownRows = ListaEstadosReporte.Count;
            lookUpEdit.EditValue = reportePeriodo.bCumple;
            lookUpEdit.Properties.ShowFooter = false;
            lookUpEdit.Properties.ShowHeader = false;
            lookUpEdit.Properties.Appearance.BackColor = reportePeriodo.bCumple ? Color.FromArgb(169, 208, 142) : Color.FromArgb(246, 113, 110);
            lookUpEdit.EditValueChanged += new System.EventHandler(lookUpEdit_EditValueChanged);

            lookUpEdit.Left = 300;
            lookUpEdit.Top = lineaY;
            panelReportes.Controls.Add(lookUpEdit);
        }

        private void frmIngresoEstadoReporte_Load(object sender, EventArgs e)
        {
            luePeriodo.ListarPeriodos();
            ListarReportesPeriodo((int)luePeriodo.EditValue);
        }

        private void btnCajasServicio_Click(object sender, EventArgs e)
        {
            ActualizarEstadosReporte();
        }

        private void luePeriodo_EditValueChanged(object sender, EventArgs e)
        {
            ListarReportesPeriodo((int)luePeriodo.EditValue);
        }
    }
}
