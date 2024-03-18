using DevExpress.XtraEditors;
using Interna.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ExpedicionInternaPC
{
    public partial class frmConsultaCorrespondenciaGeneral : frmChild
    {

        #region Metodos

        //2022
        private void CargarFechas()
        {
            dteDesde.EditValue = DateTime.Now;
            dteHasta.EditValue = DateTime.Now;
        }
        //2022
        private void CargarTipoDeEntrega()
        {
            List<Entrega> lEntrega = new List<Entrega>();
            lEntrega.Add(new Entrega() { IdTipoEntrega = 0, TipoEntrega = "TODOS" });
            lEntrega.Add(new Entrega() { IdTipoEntrega = 1, TipoEntrega = "NORMAL" });
            lEntrega.Add(new Entrega() { IdTipoEntrega = 2, TipoEntrega = "ENTREGA EXPRESS" });
            List<Entrega> lEntregaOrderBy = lEntrega.OrderBy(hol => hol.IdTipoEntrega).ToList();
            lueTipoEntrega.Properties.DataSource = lEntregaOrderBy;
            lueTipoEntrega.Properties.ValueMember = "IdTipoEntrega";
            lueTipoEntrega.Properties.DisplayMember = "TipoEntrega";
            lueTipoEntrega.Properties.DropDownRows = lEntregaOrderBy.Count;
            lueTipoEntrega.EditValue = 0;
        }
        //2022
        private void CargarOpcionRadioButton()
        {
            radioGroupFechaDe.Properties.Items.Add(new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Creación"));
            radioGroupFechaDe.Properties.Items.Add(new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "Recibido"));
            radioGroupFechaDe.Properties.Items.Add(new DevExpress.XtraEditors.Controls.RadioGroupItem(3, "Ruta por agencia"));
            radioGroupFechaDe.EditValue = 1;
        }
        //2022
        private void CargarEstados()
        {

            List<Estado> lEstado = new List<Estado>();

            try
            {
                lEstado = Metodos.rListarEstado();
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                return;
            }

            lEstado.Add(new Estado() { IdEstado = 0, estado = "TODOS" });
            List<Estado> lEstadoOrderBy = lEstado.OrderBy(hol => hol.IdEstado).ToList();
            lueEstado.Properties.DataSource = lEstadoOrderBy;
            lueEstado.Properties.DisplayMember = "estado";
            lueEstado.Properties.ValueMember = "IdEstado";
            lueEstado.Properties.DropDownRows = lEstadoOrderBy.Count;
            lueEstado.EditValue = 0;
        }
        //2022
        private void CargarSedes()
        {
            List<Expedicion> lE = new List<Expedicion>();

            try
            {
                lE = Metodos.rListarExpediciones();
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                return;
            }

            lE.Add(new Expedicion() { ID = 0, Descripcion = "TODOS" });
            List<Expedicion> lE1 = lE.OrderBy(x => x.ID).ToList();
            lueSedeOrigen.Properties.DataSource = lE1;
            lueSedeDestino.Properties.DataSource = lE1;
            lueSedeOrigen.Properties.DisplayMember = "Descripcion";
            lueSedeDestino.Properties.DisplayMember = "Descripcion";
            lueSedeOrigen.Properties.ValueMember = "ID";
            lueSedeDestino.Properties.ValueMember = "ID";
            lueSedeDestino.Properties.DropDownRows = lE1.Count();
            lueSedeOrigen.Properties.DropDownRows = lE1.Count();
            lueSedeOrigen.EditValue = 0;
            lueSedeDestino.EditValue = 0;
        }
        //2022
        private void Buscar()
        {
            grdDatos.DataSource = null;
            /*Verificación*/
            if (!((((DateTime)dteDesde.EditValue).Date.CompareTo((DateTime)dteHasta.EditValue)) <= 0))
            {
                Program.mensaje(String.Format("Seleccione un rango de fecha válido."), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (lueSedeOrigen.EditValue == null && lueSedeDestino.EditValue == null)
            {
                Program.mensaje(String.Format("Seleccione las expediciones correctamente."), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (lueTipoEntrega.EditValue == null)
            {
                lueTipoEntrega.EditValue = 0;
            }
            List<Objeto> lObjetos = new List<Objeto>();

            try
            {
                lObjetos = Metodos.ConsultaElementosReporteGeneral((int)lueEstado.EditValue, (int)lueTipoEntrega.EditValue, (int)lueSedeOrigen.EditValue, (int)lueSedeDestino.EditValue, (int)radioGroupFechaDe.EditValue, (DateTime)dteDesde.EditValue, (DateTime)dteHasta.EditValue);
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                return;
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar obtener los resultados.");
                return;
            }


            grdDatos.DataSource = lObjetos;
            if (lObjetos.Count == 0)
            {
                Program.mensaje(String.Format("No se encontró ningún resultado que coincida con esta búsqueda."), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        //2022
        public override void ExportExcel(String FileName)
        {
            grvDatos.ExportToXlsx(FileName);
            //grdDatos.MainView = gridView2;            
            //gridView2.ExportToXls(FileName);
            //grdDatos.MainView = grvDatos;
        }

        #endregion


        public frmConsultaCorrespondenciaGeneral()
        {
            InitializeComponent();
        }

        private void frmConsultaCorrespondenciaGeneral_Load(object sender, EventArgs e)
        {
            try
            {
                CargarSedes();
                CargarOpcionRadioButton();
                CargarEstados();
                CargarTipoDeEntrega();
                CargarFechas();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar cargar las listas");
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void lueEstado_EditValueChanged(object sender, EventArgs e)
        {
            Estado eleg = ((Estado)((LookUpEdit)sender).GetSelectedDataRow());
            if (eleg.estado == "CREADO" || eleg.estado == "RUTA" || eleg.estado == "CUSTODIA")
            {
                lueTipoEntrega.Enabled = false;
                lueTipoEntrega.EditValue = null;
                radioGroupFechaDe.EditValue = 1;
                radioGroupFechaDe.Properties.Items[1].Enabled = false;
            }
            else
            {
                lueTipoEntrega.Enabled = true;
                radioGroupFechaDe.Properties.Items[1].Enabled = true;
            }
        }

        private void repositoryItemHyperLinkEdit1_Click(object sender, EventArgs e)
        {
            Objeto oo = (Objeto)grvDatos.GetFocusedRow();
            Metodos.VerTracking(oo);
        }

        private void frmConsultaCorrespondenciaGeneral_Activated(object sender, EventArgs e)
        {
            frmMain oM = (frmMain)this.MdiParent;

            oM.subMostrarConsultas(true);
        }

        private void frmConsultaCorrespondenciaGeneral_Deactivate(object sender, EventArgs e)
        {

        }



    }
}
