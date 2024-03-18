using ExpedicionInternaPC.Formularios.Gestion;
using ExpedicionInternaPC.Formularios.Mesa_de_Partes;
using Interna.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ExpedicionInternaPC
{
    public partial class frmDocumentosProcesados : frmChild
    {
        #region Variables
        public List<Documento> ListaDocumentos = new List<Documento>();
        public List<Documento> ListaAsociados = new List<Documento>();
        public string TipoDoc;
        public string NumeroDoc;
        public string Para;
        #endregion

        #region Metodos

        // Revisado
        public void CargarDocumentosProcesados()
        {
            try
            {
                ListaDocumentos = Metodos.ListarDocumentosRegistrados();
                grdDocumentos.DataSource = ListaDocumentos;
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }

        }
        // Revisado
        public override void Actualizar(string CommandName)
        {
            base.Actualizar(CommandName);
            CargarDocumentosProcesados();
        }
        // Revisado
        public void ExportExcel(DevExpress.XtraGrid.GridControl g)
        {
            SaveFileDialog oSave = new SaveFileDialog();

            oSave.Filter = "Archivos Excel|*.xls";
            oSave.FilterIndex = 1;
            oSave.RestoreDirectory = true;

            if (oSave.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    g.ExportToXls(oSave.FileName);
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    process.StartInfo.FileName = oSave.FileName;
                    process.Start();
                }
                catch (Exception ex)
                {
                    Program.mensaje(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Activate();
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
        }

        // Revisado
        private void CrearAutogenerado()
        {
            frmAsociarDocumentoAutogenerado fx = new frmAsociarDocumentoAutogenerado();
            List<Casilla> ListaDestino = new List<Casilla>();
            List<Tipo> ListaTipoDocumento = new List<Tipo>();

            List<Objeto> lDetalle = new List<Objeto>();

            int iDestino = 0;
            int iTipoDocumento = 0;

            foreach (Documento oDocumento in ListaDocumentos)
            {
                if (ListaDestino.Find(x => x.ID == oDocumento.iIdCasillaPara) == null)
                {
                    ListaDestino.Add(new Casilla() { ID = oDocumento.iIdCasillaPara, sDescripcion = oDocumento.CasillaPara });
                }
                if (ListaTipoDocumento.Find(x => x.ID == oDocumento.iIdTipoDocumento) == null)
                {
                    ListaTipoDocumento.Add(new Tipo() { ID = oDocumento.iIdTipoDocumento, Descripcion = oDocumento.TipoDocumento });
                }
            }

            fx.ListaDestino = ListaDestino;
            fx.ListaTipoDocumento = ListaTipoDocumento;

            List<Documento> lFiltrados = new List<Documento>();

            if (fx.ShowDialog(this.Parent) == System.Windows.Forms.DialogResult.OK)
            {

                iDestino = fx.iDestino;
                iTipoDocumento = fx.iTipoDocumento;

                if (iDestino > 0 && iTipoDocumento > 0)
                {
                    lFiltrados = ListaDocumentos.FindAll(x => (x.iIdCasillaPara == iDestino && x.iIdTipoDocumento == iTipoDocumento)).ToList();
                }
                else if (iDestino > 0)
                {
                    lFiltrados = ListaDocumentos.FindAll(x => x.iIdCasillaPara == iDestino).ToList();
                }
                else if (iTipoDocumento > 0)
                {
                    lFiltrados = ListaDocumentos.FindAll(x => x.iIdTipoDocumento == iTipoDocumento).ToList();
                }

                foreach (Documento oDocumento in lFiltrados)
                {

                    Objeto o = new Objeto();
                    o.ID = oDocumento.iId;
                    o.IdTipoDocumento = oDocumento.iIdTipoDocumento;
                    o.TipoDocumento = oDocumento.TipoDocumento;
                    o.Descripcion = oDocumento.sProcedencia;
                    o.MonedaS = oDocumento.Moneda;
                    if (o.cantidadBd == "0.00")
                    {
                        o.cantidadBd = "1";
                    }
                    else
                    {
                        o.cantidadBd = oDocumento.iMonto.ToString().Replace(',', '.');
                    }

                    o.Observacion = oDocumento.sObservacion;
                    o.Empaque = 40;
                    o.IdCasillaDe = oDocumento.iIdCasillaDe;
                    o.IdCasillaPara = oDocumento.iIdCasillaPara;
                    lDetalle.Add(o);
                }

                Objeto oObj = new Objeto();
                oObj.IdCasillaDe = lDetalle[0].IdCasillaDe;
                oObj.IdCasillaPara = lDetalle[0].IdCasillaPara;
                oObj.IdUsuario = Program.oUsuario.ID;
                oObj.Asunto = "Creado por Mesa de Partes";
                oObj.Mensaje = "";
                oObj.IdTipoDocumento = 1;
                oObj.ListaXML = oObj.SerializeObjectWindows(lDetalle);

                try
                {
                    oObj = Metodos.AsociarAutogeneradoDocumentos(oObj);
                }
                catch (InvalidTokenException)
                {
                    Program.mensajeTokenInvalido();
                    return;
                }


                if (oObj != null)
                {
                    CargarDocumentosProcesados();
                    frmCodigoAutogenerado frm = new frmCodigoAutogenerado();
                    frm.autogenerado = oObj.Ticket;
                    frm.ShowDialog(this);

                    //Program.mensaje(string.Format("Se creo el Autogenerado {0} ", oObj.Ticket), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    Program.mensaje(string.Format("No se pudo crear el Autogenerado"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                return;
            }
        }
        // Revisado
        private void BuscarHistoricos()
        {
            DateTime FechaDesde = new DateTime();
            DateTime FechaHasta = new DateTime();

            if (cboDesde.EditValue == null || cboHasta.EditValue == null)
            {
                Program.mensaje("Selecciona un rango de fechas.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            FechaDesde = (DateTime)cboDesde.EditValue;
            FechaHasta = (DateTime)cboHasta.EditValue;

            try
            {
                ListaAsociados = Metodos.ListarDocumentosHistoricos(FechaDesde, FechaHasta);
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                return;
            }



            grdAsociados.DataSource = ListaAsociados;
        }
        // Revisado
        private void VerDetalle()
        {
            Documento oDocumento = new Documento();
            oDocumento = ((Documento)grvAsociados.GetFocusedRow()) == null ? ((Documento)grvDocumentos.GetFocusedRow()) : ((Documento)grvAsociados.GetFocusedRow());

            if (oDocumento == null)
            {
                Program.mensaje("Ha ocurrido un problema al seleccionar el documento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Campos fijos
            List<CampoExterno> lcExterno = new List<CampoExterno>();

            CampoExterno oCampofijo1 = new CampoExterno();
            oCampofijo1.sDescripcionCampoExterno = "Tipo documento";
            oCampofijo1.sValor = oDocumento.TipoDocumento;

            CampoExterno oCampofijo2 = new CampoExterno();
            oCampofijo2.sDescripcionCampoExterno = "Destino";
            oCampofijo2.sValor = oDocumento.CasillaPara;

            lcExterno.Add(oCampofijo1);
            lcExterno.Add(oCampofijo2);

            CampoExterno oCampo = new CampoExterno();
            oCampo.iIdDocumento = oDocumento.iId;

            //Campos Varialbles
            List<CampoExterno> lcMoneda = new List<CampoExterno>();

            CampoExterno oCampoMoneda = new CampoExterno();
            oCampoMoneda.sDescripcionCampoExterno = "Moneda";
            oCampoMoneda.sValor = oDocumento.Moneda;

            CampoExterno oCampoMonto = new CampoExterno();
            oCampoMonto.sDescripcionCampoExterno = "Monto";
            oCampoMonto.sValor = oDocumento.iMonto.ToString();

            lcMoneda.Add(oCampoMoneda);
            lcMoneda.Add(oCampoMonto);

            frmDetalleDocumento fx = new frmDetalleDocumento();
            fx.LCampoExternoComun = lcExterno;

            try
            {
                fx.LCampoExterno = Metodos.ListarDetalleDocumento(oCampo);
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                return;
            }

            if (oDocumento.iMoneda == 1) fx.LCampoMoneda = lcMoneda;
            fx.oDocumento = oDocumento;
            fx.GenerarControles();
            fx.Show(this.Parent);
        }
        // Revisado
        private void VerSeguimiento(DevExpress.XtraGrid.Views.Grid.GridView grv)
        {
            Documento oDocumento = (Documento)grv.GetFocusedRow();
            frmDocumentoSeguimiento fx = new frmDocumentoSeguimiento();
            fx.oDocumento = oDocumento;
            fx.Text = string.Format("{0} : {1}", oDocumento.TipoDocumento, oDocumento.sCodigoDocumento);
            fx.CargarSeguimiento();
            fx.ShowDialog(this.Parent);
        }

        #endregion

        // Revisado
        public frmDocumentosProcesados()
        {
            InitializeComponent();
        }
        // Revisado
        private void frmDocumentosProcesados_Load(object sender, EventArgs e)
        {
            CargarDocumentosProcesados();
        }
        // Revisado
        private void btnRegistrarDocumento_Click(object sender, EventArgs e)
        {
            frmRegistroDigitalizacionDocumentos frm = new frmRegistroDigitalizacionDocumentos();
            frm.ShowDialog(Program.oMain);
        }
        // Revisado
        private void repositoryItemHyperLinkEdit1_Click(object sender, EventArgs e)
        {
            VerDetalle();
        }
        // Revisado
        private void btnCrearAutogenerado_Click(object sender, EventArgs e)
        {
            CrearAutogenerado();
        }
        // Revisado
        private void btnExportar_Click(object sender, EventArgs e)
        {
            ExportExcel(this.grdDocumentos);
        }
        // Revisado
        private void repositoryItemHyperLinkEdit2_Click(object sender, EventArgs e)
        {
            VerDetalle();
        }
        // Revisado
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarHistoricos();
        }
        // Revisado
        private void repositoryItemHyperLinkEdit3_Click(object sender, EventArgs e)
        {
            VerSeguimiento(grvDocumentos);
        }
        // Revisado
        private void repositoryItemHyperLinkEdit4_Click(object sender, EventArgs e)
        {
            VerSeguimiento(grvAsociados);
        }

        private void btnCargaArchivo_Click(object sender, EventArgs e)
        {
            frmCargaMasivaDocumentoEspeciales fx = new frmCargaMasivaDocumentoEspeciales();

            fx.ShowDialog();
        }

        private void btnExportarDocumentosAsociados_Click(object sender, EventArgs e)
        {
            ExportExcel(this.grdAsociados);
        }
    }
}
