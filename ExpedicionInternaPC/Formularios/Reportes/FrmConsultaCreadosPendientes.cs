using Interna.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ExpedicionInternaPC
{
    public partial class FrmConsultaCreadosPendientes : frmChild
    {

        #region Metodos

        //2022
        private void Buscar()
        {
            if (grdLookUpEdit.EditValue != null && (grdLookUpEdit.EditValue == null || grdLookUpEdit.EditValue.ToString() != "-1"))
            {
                int idExpedicion = (int)grdLookUpEdit.EditValue;
                CargarDatos(idExpedicion);
            }
            else
            {
                Program.mensaje(String.Format("Por favor, seleccione una expedición."), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
        //2022
        private void VerTracking(object sender, EventArgs e)
        {
            Objeto oo = (Objeto)grvDatos.GetFocusedRow();
            Metodos.VerTracking(oo);
        }
        //2022
        public override void ExportExcel(String FileName)
        {
            grdDatos.ExportToXls(FileName);
        }
        //2022
        private void CargarDatos(int idExpedicion)
        {
            try
            {
                LimpiarDatos();
                List<Objeto> lobjeto = Metodos.rReportesListarElementosCreadosPediente(idExpedicion);
                if (lobjeto != null)
                {
                    if (lobjeto.Count() != 0)
                    {
                        grdDatos.DataSource = lobjeto;
                    }
                    else
                    {
                        Program.mensaje(String.Format("No tiene ningún creado pendiente."), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch
            {
                Program.mensajeError("Ha ocurrido un error al intentar obtener los resultados.");
            }
        }
        //2022
        private void LimpiarDatos()
        {
            grdDatos.DataSource = null;
        }
        //2022
        private void cargarExpedicion()
        {
            List<Expedicion> lExpedicion = new List<Expedicion>();

            try
            {
                lExpedicion = Metodos.rListarExpediciones();
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                return;
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar cargar la lista de Expediciones.");
                return;
            }

            Expedicion exp = new Expedicion();
            exp.ID = 0;
            exp.Descripcion = "TODOS";
            lExpedicion.Insert(0, exp);

            grdLookUpEdit.Properties.DataSource = lExpedicion;
            grdLookUpEdit.Properties.ValueMember = "ID";
            grdLookUpEdit.Properties.DisplayMember = "Descripcion";
            grdLookUpEdit.Properties.ShowFooter = false;
            grdLookUpEdit.Properties.NullText = "Seleccione Expedición";
        }

        #endregion


        public FrmConsultaCreadosPendientes()
        {
            InitializeComponent();
        }

        private void FrmConsultaCreadosPendientes_Load(object sender, EventArgs e)
        {
            cargarExpedicion();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void FrmConsultaCreadosPendientes_Activated(object sender, EventArgs e)
        {
            frmMain oM = (frmMain)this.MdiParent;
            oM.subMostrarConsultas(true);
        }

        private void FrmConsultaCreadosPendientes_Deactivate(object sender, EventArgs e)
        {

        }

    }
}
