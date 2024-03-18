using DevExpress.XtraReports.UI;
using Interna.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Interna.Rep
{
    public partial class Rep_ObjetoTracking : DevExpress.XtraReports.UI.XtraReport
    {

        private Objeto oObjCab = null;
        private List<Objeto> lstDet = null;
        private List<Objeto> lstSeg = null;

        public Rep_ObjetoTracking(Objeto oObj, List<Objeto> lstDet, List<Objeto> lstSeg)
        {

            try
            {
                this.oObjCab = oObj;
                this.lstDet = lstDet;
                this.lstSeg = lstSeg;

                //String fecha = "";
                //fecha = DateTime.Now.ToString();
                //lblFecha.Text = fecha;
                oObjCab.EntregaFecha = DateTime.Now.ToLongDateString();
                oObjCab.EmpaqueS = lstDet[0].EmpaqueBD;


            }
            catch { }

            InitializeComponent();
        }

        private void Rep_ObjetoTracking_BeforePrint(object sender, CancelEventArgs e)
        {
            try
            {
                for (int o = 0; o < lstSeg.Count; o++)
                {
                    if (lstSeg[o].IdTipoEstado == 6)
                    {
                        oObjCab.Observacion = lstSeg[o].Observacion;
                        txtObservacion.Text = oObjCab.Observacion;
                        lblObservacion.Visible = true;
                        txtObservacion.Visible = true;
                        break;
                    }
                    else
                    {
                        lblObservacion.Visible = false;
                        txtObservacion.Visible = false;
                    }
                }

                bsObjeto.DataSource = oObjCab;
            }
            catch
            { }


        }

        private void xrSubreport1_BeforePrint(object sender, CancelEventArgs e)
        {
            try
            {
                ((Rep_ObjetoDet)((XRSubreport)sender).ReportSource).bsDetalle.DataSource = lstDet;
            }
            catch { }

        }

        private void xrSubreport2_BeforePrint(object sender, CancelEventArgs e)
        {
            try
            {
                ((Rep_TrackingDet)((XRSubreport)sender).ReportSource).bsTracking.DataSource = lstSeg;
            }
            catch { }

        }


    }
}
