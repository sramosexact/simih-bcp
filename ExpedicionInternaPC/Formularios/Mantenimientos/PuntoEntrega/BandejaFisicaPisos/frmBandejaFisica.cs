using ExpedicionInternaPC.Formularios.Mantenimientos.PuntoEntrega.BandejaFisicaPisos;
using ExpedicionInternaPC.Properties;
using ImpresionZebra;
using Interna.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


namespace ExpedicionInternaPC.Formularios
{
    public partial class frmBandejaFisica : frmChild
    {

        #region "Variables"      
        private List<Ubicacion> ubicacionesExpedicion = new List<Ubicacion>();
        private List<Ubicacion> ubicacionesNoAsociadas = new List<Ubicacion>();
        private List<Ubicacion> ubicacionesAsociadas = new List<Ubicacion>();
        private List<BandejaFisica> bandejasFisicasExpedicion;
        private bool autoajuste = bool.Parse(Settings.Default["autoajuste"].ToString());
        #endregion


        #region "Metodos"

        public void listarBandejasFisicas(int idExpedicion)
        {
            bandejasFisicasExpedicion = Metodos.ListarBandejaFisica(idExpedicion);
            grdBandejasFisicas.DataSource = bandejasFisicasExpedicion;
        }

        private void listarExpediciones()
        {
            List<Interna.Entity.Expedicion> expediciones = Metodos.ListarExpedicionesListaJson();
            //List<Interna.Entity.Expedicion> expedicionesPisos = expediciones.FindAll(x => x.idTipoExpedicion == 1).ToList();
            cboExpedicion.Properties.DataSource = expediciones;
            cboExpedicion.Properties.DisplayMember = "Descripcion";
            cboExpedicion.Properties.ValueMember = "ID";
            cboExpedicion.Properties.DropDownRows = expediciones.Count;
        }

        private void cargarUbicaciones(int idExpedicion)
        {
            ubicacionesExpedicion = Metodos.ListarUbicacionesExpedicion(idExpedicion);
        }

        private void cargarUbicacionesAsociadas(int idBandejaFisica)
        {
            ubicacionesAsociadas = null;
            if (ubicacionesExpedicion == null) return;
            ubicacionesAsociadas = ubicacionesExpedicion.FindAll(ubicacion => ubicacion.idBandejaFisica == idBandejaFisica).ToList();
            grdUbicaciones.DataSource = ubicacionesAsociadas;
            cargarUbicacionesNoAsociadas(idBandejaFisica);
        }

        private void cargarUbicacionesNoAsociadas(int idBandejaFisica)
        {
            ubicacionesNoAsociadas = null;
            if (ubicacionesExpedicion == null) return;
            ubicacionesNoAsociadas = ubicacionesExpedicion.FindAll(ubicacion => ubicacion.idBandejaFisica != idBandejaFisica).ToList();
        }

        private void imprimirEtiquetas()
        {
            try
            {
                if (grdBandejasFisicas.DefaultView.RowCount > 0)
                {
                    if (Program.mensaje(string.Format("Va a imprimir {0} etiquetas. ¿Desea continuar?", grdBandejasFisicas.DefaultView.RowCount), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        List<string> BadejasFisicas = new List<string>();
                        for (int i = 0; i <= grdBandejasFisicas.DefaultView.DataRowCount - 1; i++)
                        {
                            string codigo = grvBandejasFisicas.GetRowCellValue(i, "idBandejaFisica").ToString().PadLeft(6, '0');
                            string oficina = grvBandejasFisicas.GetRowCellValue(i, "nombre").ToString().ToUpper();
                            string area = "";
                            ZebraZpl zpl = new ZebraZpl();
                            zpl.NOMBRE_IMPRESORA = Settings.Default["RutaImpresoraZebra"].ToString();
                            string s = zpl.etiquetaPuntoEntrega(codigo, oficina, area, autoajuste);
                            if (!(BadejasFisicas.Contains(area)))
                            {
                                BadejasFisicas.Add(oficina);
                                zpl.imprimirEtiqueta(s);
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        #endregion

        public frmBandejaFisica()
        {
            InitializeComponent();
            listarExpediciones();
        }

        private void frmBuzon_Load(object sender, EventArgs e)
        {
            if (bandejasFisicasExpedicion != null && bandejasFisicasExpedicion.Count > 0) grvBandejasFisicas.SelectRow(0);
        }

        private void grvBuzones_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            BandejaFisica bandejaFisica = (BandejaFisica)grvBandejasFisicas.GetFocusedRow();
            if (bandejaFisica == null) return;
            cargarUbicacionesAsociadas(bandejaFisica.idBandejaFisica);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Interna.Entity.Expedicion expedicion = (Interna.Entity.Expedicion)cboExpedicion.GetSelectedDataRow();
            if (expedicion == null) return;
            frmNuevaBandejaFisica fx = new frmNuevaBandejaFisica(expedicion.ID);
            if (fx.ShowDialog(this) == DialogResult.OK) listarBandejasFisicas(expedicion.ID);
        }

        private void linkAsociarUbicaciones_Click(object sender, EventArgs e)
        {
            BandejaFisica bandejaFisica = (BandejaFisica)grvBandejasFisicas.GetFocusedRow();

            if (ubicacionesNoAsociadas == null)
            {
                Program.mensaje("No hay ubicaciones por asociar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            frmUbicacionesPorAsociar fx = new frmUbicacionesPorAsociar(bandejaFisica, ubicacionesNoAsociadas, ubicacionesAsociadas);
            if (fx.ShowDialog(this) == DialogResult.OK)
            {
                Interna.Entity.Expedicion expedicion = (Interna.Entity.Expedicion)cboExpedicion.GetSelectedDataRow();
                if (expedicion == null) return;
                cargarUbicaciones(expedicion.ID);
                cargarUbicacionesAsociadas(bandejaFisica.idBandejaFisica);
            }
        }

        private void cboExpedicion_EditValueChanged(object sender, EventArgs e)
        {
            Interna.Entity.Expedicion expedicion = (Interna.Entity.Expedicion)cboExpedicion.GetSelectedDataRow();
            if (expedicion == null) return;
            grdUbicaciones.DataSource = null;
            cargarUbicaciones(expedicion.ID);
            listarBandejasFisicas(expedicion.ID);

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            imprimirEtiquetas();
        }
    }
}
