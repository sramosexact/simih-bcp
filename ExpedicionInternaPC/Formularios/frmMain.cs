using DevExpress.XtraBars;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using ExpedicionInternaPC.Formularios;
using ExpedicionInternaPC.Formularios.Expedicion;
using ExpedicionInternaPC.Formularios.Mantenimientos;
using ExpedicionInternaPC.Formularios.Reclamos;
using ExpedicionInternaPC.Properties;
using Interna.Entity;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpedicionInternaPC
{
    public partial class frmMain : RibbonForm
    {
        public int iEntregaContadorPisos = 0;
        public int iEntregaContadorAgencias = 0;
        public int iEntregaContadorSucursales = 0;
        public List<Expedicion> ole = new List<Expedicion>();

        private int botonElegido;

        #region LOGIN

        private void subCargarConfiguracion()
        {
            Metodos.listarConfiguracion();
        }

        public void subCargarUsuario()
        {
            this.Text = String.Format("{0} :: {1} :: {2}", Application.ProductName, Program.GetCurrentPublishVersion(), Program.oUsuario.Codigo);


            barNombreUsuario.EditValue = Program.oUsuario.Codigo.ToUpper();

            Usuario Us = new Usuario();
            Us.ID = Program.oUsuario.ID;

            ole = Metodos.GetExpedicionListaUsuarioPrueba(Us);

            bsExpedicion.DataSource = ole;
            lokExpedicionLista.ValueMember = "ID";
            lokExpedicionLista.DisplayMember = "Descripcion";
            lokExpedicionLista.DropDownRows = ole.Count();
            barExpedicionLista.EditValue = Program.oUsuario.IdExpedicion;

            DeshabilitarPaginacion();

            btnRegistrarDocumentos.Visibility = BarItemVisibility.Never;
            btnSupervision.Visibility = BarItemVisibility.Never;
            btnJefatura.Visibility = BarItemVisibility.Never;
            btnDocumentosExternos.Visibility = BarItemVisibility.Never;
            rpgExpedicion.Visible = false;
            rpgMesadePartes.Visible = false;
            rpgRecepcion.Visible = false;
            rpgEntregas.Visible = false;

            // Operario
            if (Program.oUsuario.IdTipoAcceso == 42)
            {
                rpgExpedicion.Visible = true;
                rpgMesadePartes.Visible = true;
                rpgRecepcion.Visible = true;
                rpgEntregas.Visible = true;
                rpgGrupos.Visible = true;
                ribbonPageGroup1.Visible = true;
                ribbonPageGroup2.Visible = false;
                btnDocumentosExternos.Visibility = BarItemVisibility.Always;

                if (Program.oUsuario.IdTipoCasilla == (int)EnumTipoCasilla.MESA_DE_PARTES)
                    btnRegistrarDocumentos.Visibility = BarItemVisibility.Always;
                else
                    btnRegistrarDocumentos.Visibility = BarItemVisibility.Never;



            }

            // Supervisor
            if (Program.oUsuario.IdTipoAcceso == 43)
            {
                rpgExpedicion.Visible = true;
                rpgMesadePartes.Visible = true;
                rpgRecepcion.Visible = true;
                rpgEntregas.Visible = true;
                rpgGrupos.Visible = true;
                ribbonPageGroup1.Visible = true;
                ribbonPageGroup2.Visible = true;
                btnSupervision.Visibility = BarItemVisibility.Always;
                btnDocumentosExternos.Visibility = BarItemVisibility.Always;
            }

            // Jefe
            if (Program.oUsuario.IdTipoAcceso == 80)
            {
                rpgGrupos.Visible = false;
                ribbonPageGroup1.Visible = true;
                ribbonPageGroup2.Visible = true;
                btnSupervision.Visibility = BarItemVisibility.Always;
                btnJefatura.Visibility = BarItemVisibility.Always;

            }

            //Expedición tipo : [1 - Sucursal]
            if (Program.oUsuario.IdTipoExpedicion == 1)
            {
                btnEntregaPisos.Visibility = BarItemVisibility.Always;
                btnEntregaSucursal.Visibility = BarItemVisibility.Always;
                btnEntregaAgencias.Visibility = BarItemVisibility.Never;
            }
            //Expedición tipo : [2 - Agencia Lima, 3 - Agencia Provincia]
            else
            {
                btnEntregaPisos.Visibility = BarItemVisibility.Always;
                btnEntregaSucursal.Visibility = BarItemVisibility.Always;
                btnEntregaAgencias.Visibility = BarItemVisibility.Always;
            }

        }

        #endregion

        #region SEGURIDAD


        public void OcultarRibLotes() { ribLotes.Visible = false; }
        public void OcultarRibConsultas() { ribConsultas.Visible = false; }
        public void OcultarRibSupervision() { ribSupervision.Visible = false; }
        public void OcultarRibJefatura() { ribSeguridad.Visible = false; }
        public void OcultarRibProcesos() { ribExpedicion.Visible = false; ribExpedicion.Visible = true; }
        public void OcultarRibValija() { ribValijaAgencia.Visible = false; }
        public void OcultarRibValijaSucursal() { ribValijaSucursal.Visible = false; }


        public void subMostrarEntregaSucursal(bool prmShow)
        {
            OcultarRibLotes();
            OcultarRibConsultas();
            OcultarRibSupervision();
            OcultarRibJefatura();
            OcultarRibValija();
            OcultarRibValijaSucursal();

            if (prmShow)
            {
                OcultarRibProcesos();
            }
            else rpcExpedicion.Visible = prmShow;
        }
        public void subMostrarEntrega(bool prmShow)
        {
            OcultarRibLotes();
            OcultarRibConsultas();
            OcultarRibSupervision();
            OcultarRibJefatura();
            OcultarRibValija();
            OcultarRibValijaSucursal();

            if (prmShow)
            {
                rpcExpedicion.Visible = true;
                OcultarRibProcesos();
            }
            else rpcExpedicion.Visible = prmShow;
        }
        public void subMostrarEntregaPisos(bool prmShow)
        {
            OcultarRibLotes();
            OcultarRibConsultas();
            OcultarRibSupervision();
            OcultarRibJefatura();
            OcultarRibValija();
            OcultarRibValijaSucursal();

            if (prmShow)
            {
                rpcExpedicion.Visible = true;
                OcultarRibProcesos();
            }
            else rpcExpedicion.Visible = prmShow;
        }

        // Funcional - Consultas
        public void subMostrarConsultas(bool prmShow)
        {
            OcultarRibLotes();
            OcultarRibSupervision();
            OcultarRibJefatura();
            OcultarRibValija();
            OcultarRibValijaSucursal();

            if (prmShow)
            {
                rpcConsultas.Visible = true;
                ribConsultas.Visible = true;
                OcultarRibProcesos();
            }
            else rpcConsultas.Visible = prmShow;
        }

        public void subMostrarSupervision(bool prmShow)
        {
            //OcultarRibLotes();
            //OcultarRibConsultas();
            //OcultarRibJefatura();
            //OcultarRibValija();
            //OcultarRibValijaSucursal();

            if (prmShow)
            {
                rpcSupervision.Visible = true;
                ribSupervision.Visible = true;
                OcultarRibProcesos();
            }
            else rpcSupervision.Visible = prmShow;
        }

        public void subMostrarJefatura(bool prmShow)
        {
            //OcultarRibLotes();
            //OcultarRibConsultas();
            //OcultarRibSupervision();
            //OcultarRibValija();
            //OcultarRibValijaSucursal();

            if (prmShow)
            {
                rpcSeguridad.Visible = true;
                ribSeguridad.Visible = true;
                OcultarRibProcesos();
            }
            else rpcSeguridad.Visible = prmShow;
        }

        public void subMostrarLotes(bool prmShow)
        {
            OcultarRibJefatura();
            OcultarRibConsultas();
            OcultarRibSupervision();
            OcultarRibValija();
            OcultarRibValijaSucursal();

            if (prmShow)
            {
                rpcLotes.Visible = true;
                ribLotes.Visible = true;
                OcultarRibProcesos();
            }
            else rpcLotes.Visible = prmShow;
        }

        public void subMostrarValija(bool prmShow)
        {
            OcultarRibJefatura();
            OcultarRibConsultas();
            OcultarRibSupervision();
            OcultarRibLotes();
            OcultarRibValijaSucursal();

            if (prmShow)
            {
                rpcValija.Visible = true;
                ribValijaAgencia.Visible = true;
                OcultarRibProcesos();
            }
            else rpcValija.Visible = prmShow;
        }

        public void subMostrarValijaSucursal(bool prmShow)
        {
            OcultarRibJefatura();
            OcultarRibConsultas();
            OcultarRibSupervision();
            OcultarRibLotes();
            OcultarRibValija();

            if (prmShow)
            {
                rpcValijaSucursal.Visible = true;
                ribValijaSucursal.Visible = true;
                OcultarRibProcesos();
            }
            else rpcValijaSucursal.Visible = prmShow;


        }


        #endregion

        #region MAIN

        public frmMain()
        {
            InitializeComponent();
            DeshabilitarPaginacion();
            SkinHelper.InitSkinPopupMenu(barBtnMenuSkins);
            this.Opacity = 0;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin oL = new frmLogin();
            DialogResult oR = oL.ShowDialog();

            if (oR != System.Windows.Forms.DialogResult.OK)
            {
                this.Close();
                Application.Exit();
                return;
            }
            else
            {
                /* CARGA NORMAL */
                subCargarUsuario();
                subCargarConfiguracion();
                this.Opacity = 100;
                this.Show();
            }
        }

        private void rigGaleria_ItemClick(object sender, DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs e)
        {
            Settings.Default["Look"] = e.Item.Caption;
            Settings.Default.Save();
        }
        // Funcional - Documentos por imprimir
        private void btnCorrespondencia_ItemClick(object sender, ItemClickEventArgs e)
        {
            Program.SetFormActive<frmImpresionEtiquetaCorrespondencia>("Documentos por Imprimir", this);
        }

        private void btnExterno_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnNuevaPlantilla_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnLote_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barCboCliente_EditValueChanged(object sender, EventArgs e)
        {
            subCerrarHijos();
            Program.oUsuario.IdCliente = Convert.ToInt32(barCboCliente.EditValue.ToString());

            List<Expedicion> lstExpediciones = Metodos.ListarExpediciones(Program.oUsuario.IdCliente);

            barCboExpedicionControl.DataSource = lstExpediciones;
            barCboExpedicionControl.DisplayMember = "Descripcion";
            barCboExpedicionControl.ValueMember = "ID";
            barCboExpedicionControl.DropDownRows = lstExpediciones.Count();

            try
            {
                barCboExpedicion.EditValue = lstExpediciones[0].ID;
            }
            catch
            {
                barCboExpedicion.EditValue = 0;
            }
        }

        private void barBtnCambioUsuario_ItemClick(object sender, ItemClickEventArgs e)
        {
            DialogResult oR = MessageBox.Show("Esta operación cerrará su sesión actual, desea continuar?", "Exact SIM", MessageBoxButtons.YesNo);
            if (oR == System.Windows.Forms.DialogResult.No) return;

            cerrarSesion();
        }

        delegate void cerrarSesionCallback();


        private async Task Logout()
        {

            var accounts = await Program.PublicClientApp.GetAccountsAsync();
            if (accounts.Any())
            {
                try
                {
                    await Program.PublicClientApp.RemoveAsync(accounts.FirstOrDefault());

                }
                catch (MsalException ex)
                {
                    throw new Exception($"Error signing-out user: {ex.Message}");
                }
            }
        }


        public async void cerrarSesion()
        {

            if (Program.AD)
            {
                Program.AD = false;
                await Logout();
            }

            if (this.InvokeRequired)
            {
                cerrarSesionCallback d = new cerrarSesionCallback(cerrarSesion);
                this.Invoke(d);
            }
            else
            {
                this.Hide();
                this.subCerrarHijos();
                frmLogin oL = new frmLogin();
                oL.UsuarioRecordar = 0;
                DialogResult oR = oL.ShowDialog();

                if (oR != System.Windows.Forms.DialogResult.OK)
                {
                    this.Close();
                    Application.Exit();
                }
                //
                try
                {
                    subCerrarHijos();
                    subCargarUsuario();
                    this.Show();
                }
                catch (Exception)
                {

                }
            }
        }

        private void barCboExpedicion_EditValueChanged(object sender, EventArgs e)
        {
            Program.oUsuario.IdExpedicion = Convert.ToInt32(barCboExpedicion.EditValue.ToString());
            ////////////////Program.oUsuario.idGeo = Metodos.rGeoExpedicion(int.Parse(barCboExpedicion.EditValue.ToString())).IdGeo;
        }

        public void subCerrarHijos()
        {
            foreach (Form frmHijo in this.MdiChildren)
            {
                frmHijo.Close();
                frmHijo.Dispose();
            }
        }

        private void btnExcel_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmChild oF = null;
            try
            {
                oF = (frmChild)Program.GetFormActive(this);
            }
            catch (Exception) { }
            finally
            {
            }
            if (oF == null) return;

            SaveFileDialog oSave = new SaveFileDialog();

            oSave.Filter = "Archivos Excel|*.xls";
            oSave.FilterIndex = 1;
            oSave.RestoreDirectory = true;

            if (oSave.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Cursor = Cursors.WaitCursor;

                    oF.ExportExcel(oSave.FileName);
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    process.StartInfo.FileName = oSave.FileName;
                    process.Start();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
        }

        private void facTotal_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void formularioactual()
        {
            Form frm = Program.GetFormActive(this);
            string nombre = frm.Name;

            botonElegido = 0;

            switch (nombre)
            {
                case "frmEntregaProcesos":
                    botonElegido = 1;
                    break;
                case "frmEntregaTarjeta":
                    botonElegido = 2;
                    break;
                case "frmEntregaExterna":
                    botonElegido = 3;
                    break;
            }
        }

        private void btnConsultaBandeja_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
        // Funcional - Correspondencia
        private void btnConsultaCorrespondencia_ItemClick(object sender, ItemClickEventArgs e)
        {
            Program.SetFormActive<frmConsultaCorrespondecia>("CorrespondenciaTotal", this);
        }

        // Funcional - Punto de Entrega
        private void btnPuntoEntrega_ItemClick(object sender, ItemClickEventArgs e)
        {
            Program.SetFormActive<frmGeo>("Punto de Entrega", this);
        }

        private void btnPalomares_ItemClick(object sender, ItemClickEventArgs e)
        {
            Program.SetFormActive<frmPalomar>("Palomar", this);
        }
        // Funcional - Consultas y reportes
        private void btnConsultas_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Program.SetFormActive<frmConsultaCorrespondenciaGeneral>("Consulta correspondencia general", this) != null)
            {
                subMostrarConsultas(true);
            }
        }

        private void btnMantenimiento_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Program.SetFormActive<frmPalomar>("Palomar", this) != null)
            {
                subMostrarSupervision(true);
            }
        }

        private void btnSeguridad_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Program.SetFormActive<frmGeo>("Punto de Entrega", this) != null)
            {

                subMostrarJefatura(true);
            }
        }

        private void frmMain_Closing(object sender, FormClosingEventArgs e)
        {

        }

        private void btnExpedicion_ItemClick(object sender, ItemClickEventArgs e)
        {
            Program.SetFormActive<frmExpedicion>("Expedición", this);
        }

        #endregion

        #region PAGINACION

        public void DeshabilitarPaginacion()
        {
            btnInicio.Enabled = false;
            btnAtras.Enabled = false;
            btnAdelante.Enabled = false;
            btnFinal.Enabled = false;
            txtPaginaActual.Caption = "0";
            txtPaginaTotal.Caption = "0";
            txtCuentaTotal.Caption = "0 en total";
        }

        public void DeshabilitarPaginas()
        {
            btnTamanoPagina.Enabled = false;
        }

        public void HabilitarPaginas()
        {
            btnTamanoPagina.Enabled = true;
        }

        public void ActualizarPaginacion(Pagina oP)
        {
            DeshabilitarPaginacion();

            if (oP.PageRecordLen <= 0)
            {
                cmbTamanoPagina.ReadOnly = true;
                return;
            }

            if (oP.PageIndex > 1)
            {
                btnInicio.Enabled = true;
                btnAtras.Enabled = true;
            }

            if (oP.PageIndex < oP.PageLen)
            {
                btnAdelante.Enabled = true;
                btnFinal.Enabled = true;
            }

            if (oP.PageRecordLen <= oP.PageWidth)
            {
                cmbTamanoPagina.ReadOnly = true;
            }
            else
            {
                cmbTamanoPagina.ReadOnly = false;
            }

            txtPaginaActual.Caption = oP.PageIndex.ToString();
            txtPaginaTotal.Caption = oP.PageLen.ToString();

            // Lanza nueva consulta
            btnTamanoPagina.EditValueChanged -= btnTamanoPagina_EditValueChanged;
            btnTamanoPagina.EditValue = oP.PageWidth.ToString();
            btnTamanoPagina.EditValueChanged += btnTamanoPagina_EditValueChanged;

            txtCuentaTotal.Caption = oP.PageRecordLen.ToString() + " en total";
        }

        private void btnInicio_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmChild oF = (frmChild)Program.GetFormActive(this);
            if (oF == null) return;
            oF.PaginaInicio();

            ActualizarPaginacion(oF.Pagina());
        }

        private void btnAtras_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmChild oF = (frmChild)Program.GetFormActive(this);
            if (oF == null) return;
            oF.PaginaAtras();

            ActualizarPaginacion(oF.Pagina());
        }

        private void btnAdelante_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmChild oF = (frmChild)Program.GetFormActive(this);
            if (oF == null) return;
            oF.PaginaAdelante();

            ActualizarPaginacion(oF.Pagina());
        }

        private void btnFinal_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmChild oF = (frmChild)Program.GetFormActive(this);
            if (oF == null) return;
            oF.PaginaFinal();

            ActualizarPaginacion(oF.Pagina());
        }

        private void btnTamanoPagina_EditValueChanged(object sender, EventArgs e)
        {
            if (btnTamanoPagina.EditValue == null) return;
            String s = btnTamanoPagina.EditValue.ToString();

            int iTamano = 0;
            bool resp = int.TryParse(s, out iTamano);

            if (!resp) return;
            if (iTamano < 1) return;

            frmChild oF = (frmChild)Program.GetFormActive(this);
            if (oF == null) return;

            oF.PaginaTamano(iTamano);
            ActualizarPaginacion(oF.Pagina());
        }

        private void cmbExpedicion_Change(object sender, EventArgs e) { }

        #endregion

        private void lokExpedicion_Change(object sender, EventArgs e)
        {
            DialogResult oR = MessageBox.Show("Esta operación cerrará todas las ventanas, desea continuar?", Program.titulo, MessageBoxButtons.YesNo);
            if (oR == System.Windows.Forms.DialogResult.No)
            {
                barExpedicionLista.EditValue = Program.oUsuario.IdExpedicion;
                return;
            }

            //
            try
            {
                subCerrarHijos();
            }
            catch (Exception)
            {

            }

            Program.oUsuario.IdExpedicion = (int)barExpedicionLista.EditValue;
            Program.oUsuario.IdTipoExpedicion = ole.Find(z => z.ID == Program.oUsuario.IdExpedicion).idTipoExpedicion;
        }
        // Funcional - Crear Autogenerado
        private void btnNuevaMesaParte_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmNuevaMesaParte frMP = new frmNuevaMesaParte();
            try
            {
                frMP.SubCargarBandeja();
                frMP.ShowDialog(this.Parent);
            }
            catch (Exception ex)
            {
                Program.mensaje(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMesaParte_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnActualizar2_ItemClick(object sender, ItemClickEventArgs e)
        {
            Program.Actualizar();
        }

        private void btnActualizar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Program.Actualizar();
        }

        private void btnLotes_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnMonitorResultados_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnConfig_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            frmConfiguracion frmCon = new frmConfiguracion();
            frmCon.ShowDialog();
        }

        private void btnIndicador_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnDocumentacion_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnCxCNoFac_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem7_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            Program.SetFormActive<frmTipoDocumento>("Mantenimiento - Tipo de Documentos", this);
        }

        private void btnRecepcionarValijasOficinas_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnRegistrarPrecinto_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnValija_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnRegistrarBolsasNaranjas_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
        // Funcional - Valija de Sucursal
        private void btnValijaSucursal_ItemClick(object sender, ItemClickEventArgs e)
        {
            Program.SetFormActive<frmValijaSucursal>("Administrar Valija de Sucursal", this);
        }

        private void barButtonItem17_ItemClick(object sender, ItemClickEventArgs e)
        {
            Program.SetFormActive<frmValijaSucursal>("Administrar Valija de Sucursal", this);
        }

        private void barButtonItem18_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnRecepcionJumbo_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnTamanoPagina_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
        // Funcional - Entrega Pisos
        private void barButtonItem16_ItemClick(object sender, ItemClickEventArgs e)
        {
            Program.SetFormActive<frmEntregaPisosPrin>("Entrega Pisos", this);
        }
        // Funcional - Entrega Sucursal
        private void btnEntregaSucursal_ItemClick(object sender, ItemClickEventArgs e)
        {
            Program.SetFormActive<frmListaEntregaSucursal>("Entrega Sucursales", this);
        }
        // Funcional - Entrega Agencia
        private void btnEntregaAgencias_ItemClick(object sender, ItemClickEventArgs e)
        {
            Program.SetFormActive<frmListaEntregaAgencias>("Entrega Agencias", this);
        }
        // Funcional - Documentos custodiados
        private void barButtonItemDocumentoCustodiados_ItemClick(object sender, ItemClickEventArgs e)
        {
            Program.SetFormActive<frmDocumentosCustodiados>("Documentos Custodiados", this);
        }

        private void barbtnCambiarEstado_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmCambioDeEstado frm = new frmCambioDeEstado();
            frm.ShowDialog();
        }
        // Funcional - Imprimir de otra sede
        private void barbtnImpresionDocOtraSede_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmDocumentosCustodiadosOtraSede fx = new frmDocumentosCustodiadosOtraSede();
            fx.ShowDialog(this.Parent);
        }
        // Funcional - Consulta Correspondencia General
        private void btnConsultarCorrespondenciaGeneral_ItemClick(object sender, ItemClickEventArgs e)
        {
            Program.SetFormActive<frmConsultaCorrespondenciaGeneral>("ConsultarCorrespondenciaGeneral", this);
        }
        // Funcional - Consulta Creados Pendientes
        private void barbtnConsultaCreadosPendientes_ItemClick(object sender, ItemClickEventArgs e)
        {
            Program.SetFormActive<FrmConsultaCreadosPendientes>("ConsultaCreadosPendientes", this);
        }

        private void barbtnTurnos_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmAgenciaTurno frm = new frmAgenciaTurno();
            frm.ShowDialog(this.Parent);
        }

        private void btnAgencia_ItemClick(object sender, ItemClickEventArgs e)
        {
            Program.SetFormActive<frmAgencia>("MantenimientoAgencias", this);
        }

        private void btnMantenimientoUsuario_ItemClick(object sender, ItemClickEventArgs e)
        {
            Program.SetFormActive<frmUsuario>("MantenimientoUsuarios", this);
        }

        private void btnMantenimientoBandejas_ItemClick(object sender, ItemClickEventArgs e)
        {
            Program.SetFormActive<frmListaBandeja>("MantenimientoBandeja", this);
        }
        // Funcional - Registrar Documentos
        private void btnRegistrarDocumento_ItemClick(object sender, ItemClickEventArgs e)
        {
            Program.SetFormActive<frmDocumentosProcesados>("DocumentosProcesados", this);
        }

        private void btnRecepcionarDocumentos_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
        // Funcional - Documentos Externos
        private void btnDocumentosExternos_ItemClick(object sender, ItemClickEventArgs e)
        {
            Program.SetFormActive<frmCargarDocumentosExternos>("DocumentosExternos", this);
        }

        private void btnContingencia_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmContingencia fx = new frmContingencia();
            fx.ShowDialog(this.Parent);
        }

        private void btnReclamos_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmListaReclamos fx = new frmListaReclamos();
            fx.ShowDialog(this.Parent);
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmListaResumenReclamos fx = new frmListaResumenReclamos();
            fx.ShowDialog(this.Parent);
        }
        // Reporte de Reclamos
        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
        // Funcional - Consulta Correspondencia Detalle
        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {
            Program.SetFormActive<frmConsultaCorrespondenciaGeneralDetalle>("ConsultarCorrespondenciaGeneralDetalle", this);
        }

        //Revisado
        private void barButtonItem10_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmDocumentosSobrantes fx = new frmDocumentosSobrantes();
            fx.ShowDialog(this.Parent);
        }

        private void btnFeriados_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmFeriado fx = new frmFeriado();
            fx.ShowDialog(this.Parent);
        }

        private void barButtonItem12_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem13_ItemClick(object sender, ItemClickEventArgs e)
        {

        }



        private void barButtonItem15_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem14_ItemClick(object sender, ItemClickEventArgs e)
        {
            Program.SetFormActive<frmReporteANS>("Reporte ANS", this);
        }

        private void barButtonItem16_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            Program.SetFormActive<frmIngresoEstadoReporte>("Ingreso Estado Reporte", this);
        }

        private void barButtonItem17_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            frmRegistroReclamo frm = new frmRegistroReclamo();
            frm.ShowDialog(this);
        }

        private void btnResumenReclamo_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem18_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            frmRetirarDocumentosExternos frm = new frmRetirarDocumentosExternos();
            frm.ShowDialog(this);
        }

        private void btnRegistrarIngreso_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmIngreso frm = new frmIngreso();
            frm.ShowDialog(this);
        }

        private void btnRegistrarSalida_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmSalida frm = new frmSalida();
            frm.ShowDialog(this);
        }

        private void btnReporteAsistencia_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmReporteAsistencia frm = new frmReporteAsistencia();
            frm.ShowDialog(this);
        }

        private void btnModificar_ItemClick(object sender, ItemClickEventArgs e)
        {
            int perfil = Metodos.ListarPerfilUsuarioAsistencia();

            if (perfil == 0)
            {
                Program.mensaje("El usuario no tiene un perfil de asistencia asociado.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            frmModificarAsistencia frm = new frmModificarAsistencia(perfil);
            frm.ShowDialog(this);
        }

        private void btnMantenimientoEmpleados_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmMantenimientoEmpleadoAsistencia frm = new frmMantenimientoEmpleadoAsistencia();
            frm.ShowDialog(this);
        }

        private void btnIniciarRecorrido_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmRegistrarRecorrido frm = new frmRegistrarRecorrido();
            frm.ShowDialog(this);
        }

        private void btnTerminarRecorrido_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmRegistrarRetorno frm = new frmRegistrarRetorno();
            frm.ShowDialog(this);
        }

        private void btnReporteRecorrido_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmReporteRecorridoPisos frm = new frmReporteRecorridoPisos();
            frm.ShowDialog(this);
        }

        private void btnMantenimientoColaboradoresPisos_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmMantenimientoColaboradorRecorridoPisos frm = new frmMantenimientoColaboradorRecorridoPisos();
            frm.ShowDialog(this);
        }

        private void btnBandejaFisica_ItemClick(object sender, ItemClickEventArgs e)
        {
            Program.SetFormActive<frmBandejaFisica>("Bandeja fisica", this);
        }

        private void barReporteEntregaIntersucursales_ItemClick(object sender, ItemClickEventArgs e)
        {
            Program.SetFormActive<frmReporteEntregaIntersucursales>("ReporteEntregaIntersucursales", this);
        }
    }
}