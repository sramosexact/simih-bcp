using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using Interna.Entity.Estructuras;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace ExpedicionInternaPC.Formularios.Reclamos
{
    public partial class frmListaResumenReclamos : frmChild
    {
        #region Propiedades        

        List<ListaTipoReclamoUTDView> listaTipoReclamoUTD = new List<ListaTipoReclamoUTDView>();

        #endregion

        #region Metodos

        private void ListarResumenTipoReclamoMes(DateTime fecha)
        {
            try
            {
                listaTipoReclamoUTD = Metodos.ListarResumenTipoReclamoMes(fecha);
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                return;
            }

            grdTiposReclamo.DataSource = listaTipoReclamoUTD;
            grdTiposReclamo.RefreshDataSource();
        }

        private void setFecha()
        {
            switch (Convert.ToInt16(rgPeriodos.EditValue))
            {
                case 0: //Periodo actual
                    dePeriodo.Properties.ReadOnly = true;
                    dePeriodo.DateTime = DateTime.Now;
                    ListarResumenTipoReclamoMes(dePeriodo.DateTime);
                    break;
                case 1: //Periodo a evaluar
                    dePeriodo.Properties.ReadOnly = true;
                    DateTime fecha = DateTime.Now;
                    fecha = fecha.AddMonths(-1);
                    dePeriodo.DateTime = fecha;
                    ListarResumenTipoReclamoMes(dePeriodo.DateTime);
                    break;
                case 2: //Periodo históricos
                    dePeriodo.Properties.ReadOnly = false;
                    DateTime fechaMax = DateTime.Now;
                    fechaMax = fechaMax.AddMonths(-2);
                    dePeriodo.Properties.MaxValue = fechaMax;
                    break;
            }
        }

        #endregion

        public frmListaResumenReclamos()
        {
            InitializeComponent();
        }

        private void frmListaResumenReclamos_Load(object sender, EventArgs e)
        {
            DateTime fecha = DateTime.Now;
            ListarResumenTipoReclamoMes(fecha);
            dePeriodo.DateTime = fecha;
        }

        private void linkIdTipoReclamoUTD_Click(object sender, EventArgs e)
        {
            ListaTipoReclamoUTDView tipoReclamoSeleccionado = (ListaTipoReclamoUTDView)grvTiposReclamo.GetFocusedRow();
            frmListaReclamosPorTipoReclamo frm = new frmListaReclamosPorTipoReclamo();
            frm.iIdTipoReclamoUTD = tipoReclamoSeleccionado.iIdTipoReclamoUTD;
            frm.iIdExpedicion = tipoReclamoSeleccionado.iExpedicion;
            frm.dFecha = dePeriodo.DateTime;
            frm.iCantidadFundado = tipoReclamoSeleccionado.iCantidadFundados;
            frm.ShowDialog(this.Parent);

        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            setFecha();
        }

        private void dePeriodo_EditValueChanged(object sender, EventArgs e)
        {
            if (dePeriodo.Properties.ReadOnly == false)
            {
                ListarResumenTipoReclamoMes(dePeriodo.DateTime);
            }
        }

        private void grvTiposReclamo_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                GridColumn iCantidadFundados = null;

                int iFundados = 0;

                try
                {
                    iCantidadFundados = (GridColumn)View.Columns["iCantidadFundados"];
                }
                catch (Exception) { }

                if (iCantidadFundados != null)
                {
                    try
                    {
                        iFundados = Convert.ToInt32(View.GetRowCellValue(e.RowHandle, iCantidadFundados).ToString());
                    }
                    catch (Exception) { }


                    if (iFundados >= 3)
                    {
                        if (e.Column.FieldName == "iCantidadFundados")
                        {
                            e.Appearance.BackColor = Color.White;
                            e.Appearance.BackColor2 = Color.LightCoral;
                        }

                    }
                    else
                    {
                        if (e.Column.FieldName == "iCantidadFundados")
                        {
                            e.Appearance.BackColor = Color.White;
                            e.Appearance.BackColor2 = Color.White;
                        }
                    }
                }

            }
        }

        private void grvTiposReclamo_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                GridColumn iCantidadFundados = null;


                int iFundados = 0;

                try
                {
                    iCantidadFundados = (GridColumn)View.Columns["iCantidadFundados"];
                }
                catch (Exception) { }

                if (iCantidadFundados != null)
                {
                    try
                    {
                        iFundados = Convert.ToInt32(View.GetRowCellValue(e.RowHandle, iCantidadFundados).ToString());
                    }
                    catch (Exception) { }


                    if (iFundados >= 3)
                    {
                        e.Appearance.BackColor = Color.White;
                        e.Appearance.BackColor2 = Color.LightCoral;

                    }
                    else
                    {
                        e.Appearance.BackColor = Color.White;
                        e.Appearance.BackColor2 = Color.White;
                    }
                }

            }
        }

        private void linkTipoReclamoUTD_Click(object sender, EventArgs e)
        {
            ListaTipoReclamoUTDView tipoReclamoSeleccionado = (ListaTipoReclamoUTDView)grvTiposReclamo.GetFocusedRow();
            frmListaReclamosPorTipoReclamo frm = new frmListaReclamosPorTipoReclamo();
            frm.iIdTipoReclamoUTD = tipoReclamoSeleccionado.iIdTipoReclamoUTD;
            frm.iIdExpedicion = tipoReclamoSeleccionado.iExpedicion;
            frm.dFecha = dePeriodo.DateTime;
            frm.iCantidadFundado = tipoReclamoSeleccionado.iCantidadFundados;
            frm.ShowDialog(this.Parent);
        }
    }
}
