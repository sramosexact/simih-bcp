using DevExpress.XtraEditors;
using ExpedicionInternaPC.Formularios.Gestion;
using Interna.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ExpedicionInternaPC
{
    public partial class frmNuevaMesaParte : frmChild
    {
        #region Variables

        List<Objeto> lDetalle = new List<Objeto>();
        List<TipoDocumento> lTipoDocumento = new List<TipoDocumento>();
        List<TipoCorrespondencia> lTipoCorrespondencia = new List<TipoCorrespondencia>();
        List<Moneda> lMoneda = new List<Moneda>();

        #endregion

        #region Metodos

        //2022
        private void AgregarDetalle()
        {
            if (cboPara.EditValue == null)
            {
                Program.mensaje("Debe elegir un destinatario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Activate();
                cboPara.Focus();
                return;
            }
            if (cbTipoDocumento.EditValue == null)
            {
                Program.mensaje("Debe seleccionar un tipo de documento de la lista.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Activate();
                cbTipoDocumento.Focus();
                return;
            }
            if (txt_Procedencia.Text.Trim().Length == 0)
            {
                Program.mensaje("Debe ingresar la procedencia del documento.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Activate();
                txt_Procedencia.Focus();
                return;
            }
            if (txt_Observacion.Text.Trim().Length == 0)
            {
                Program.mensaje("Debe ingresar una observación.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Activate();
                txt_Observacion.Focus();
                return;
            }
            if (cboMoneda.EditValue == null)
            {
                Program.mensaje("Debe seleccionar una valor en el campo Moneda.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Activate();
                cboMoneda.Focus();
                return;
            }
            if (txt_Monto.Value <= 0)
            {
                Program.mensaje("Debe ingresar una valor mayor a cero.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Activate();
                txt_Monto.Focus();
                txt_Monto.SelectAll();
                return;
            }
            Objeto o = new Objeto();
            o.ID = ((TipoDocumento)cbTipoDocumento.GetSelectedDataRow()).iIdTipoDocumento;
            o.TipoDocumento = ((TipoDocumento)cbTipoDocumento.GetSelectedDataRow()).sDescripcionTipoDocumento;
            o.Descripcion = txt_Procedencia.Text.ToUpper().Trim();
            o.MonedaS = cboMoneda.Properties.GetDisplayText(cboMoneda.EditValue);
            o.cantidadBd = txt_Monto.Value.ToString();
            o.Observacion = txt_Observacion.Text.Trim();
            o.Empaque = ((TipoCorrespondencia)cboTipoEmpaque.GetSelectedDataRow()).iIdTipoCorrespondencia;
            lDetalle.Add(o);
            grvDetalle.RefreshData();
            cbTipoDocumento.EditValue = null;
            cboMoneda.Properties.DataSource = null;
            txt_Procedencia.Text = "";
            txt_Monto.Value = 1;
            cbTipoDocumento.Focus();
            txt_Observacion.Text = "";
        }
        //2022
        public void CargarTipoCorrespondencia()
        {
            try
            {
                lTipoCorrespondencia = Metodos.ListarTiposCorrespondenciaEnMesaDePartes();
                cboTipoEmpaque.Properties.DataSource = lTipoCorrespondencia;
                cboTipoEmpaque.Properties.ValueMember = "iIdTipoCorrespondencia";
                cboTipoEmpaque.Properties.DisplayMember = "sDescripcionTipoCorrespondencia";
                cboTipoEmpaque.Properties.DropDownRows = lTipoCorrespondencia.Count;
                cboTipoEmpaque.Enabled = true;
                cboTipoEmpaque.ItemIndex = 0;
            }
            catch (InvalidTokenException)
            {
                cboTipoEmpaque.Properties.DataSource = null;
                cboTipoEmpaque.EditValue = null;
                Program.mensajeTokenInvalido();
            }
            catch (Exception ex)
            {
                cboTipoEmpaque.Properties.DataSource = null;
                cboTipoEmpaque.EditValue = null;
                Program.mensajeError("Ha ocurrido un error al intentar cargar los Tipos de Correspondencia");
            }
        }
        //2022
        public void CargarTiposDeDocumento(Byte iIdTipoCorrespondencia)
        {
            try
            {
                TipoDocumento pTipoDocumento = new TipoDocumento();
                pTipoDocumento.iIdTipoCorrespondencia = iIdTipoCorrespondencia;
                lTipoDocumento = Metodos.ListarTipoDocumentoPorTipoCorrespondenciaMesaDePartes(pTipoDocumento);
                cbTipoDocumento.Properties.DataSource = lTipoDocumento;
                cbTipoDocumento.Properties.ValueMember = "iIdTipoDocumento";
                cbTipoDocumento.Properties.DisplayMember = "sDescripcionTipoDocumento";
                cbTipoDocumento.Properties.DropDownRows = lTipoDocumento.Count;
                cbTipoDocumento.EditValue = null;
            }
            catch (InvalidTokenException)
            {
                cbTipoDocumento.Properties.DataSource = null;
                cbTipoDocumento.EditValue = null;
                Program.mensajeTokenInvalido();
            }
            catch
            {
                cbTipoDocumento.Properties.DataSource = null;
                cbTipoDocumento.EditValue = null;
                Program.mensajeError("Ha ocurrido un error al intentar cargar los Tipos de Documento");
            }
        }
        //2022
        public void SubCargarBandeja()
        {
            try
            {
                List<Casilla> lCasilla = Metodos.BandejasUsuarioExpedicion();
                if (lCasilla == null)
                {
                    Program.mensaje("No cuenta con Bandejas en esta ubicación (expedición).", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Activate();
                    this.Close();
                    return;
                }
                if (lCasilla.Count == 0)
                {
                    Program.mensaje("No cuenta con Bandejas en esta ubicación (expedición).", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Activate();
                    this.Close();
                    return;
                }
                cboBandejaOrigen.Properties.DataSource = lCasilla;
                cboBandejaOrigen.Properties.DisplayMember = "Descripcion";
                cboBandejaOrigen.Properties.ValueMember = "ID";
                cboBandejaOrigen.EditValue = lCasilla[0].ID;
                CargarTipoCorrespondencia();
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                return;
            }
            catch (Exception ex)
            {
                Program.mensajeError("Ha ocurrido un error al intentar de cargar la Bandeja del Usuario.");
                return;
            }


        }
        //2022
        public void MostrarMonedaCantidadDocumento(int iMoneda)
        {
            if (iMoneda == 0)
            {
                DataTable dCantidad = new DataTable();
                dCantidad.Columns.Add("iIdMoneda");
                dCantidad.Columns.Add("sDescripcionMoneda");
                dCantidad.Rows.Add(0, "NINGUNA");
                cboMoneda.Properties.DataSource = dCantidad;
                cboMoneda.Properties.ValueMember = "iIdMoneda";
                cboMoneda.Properties.DisplayMember = "sDescripcionMoneda";
                cboMoneda.Properties.DropDownRows = dCantidad.Rows.Count;
                cboMoneda.ItemIndex = 0;
                return;
            }
            cboMoneda.Properties.DataSource = lMoneda;
            cboMoneda.Properties.ValueMember = "iIdMoneda";
            cboMoneda.Properties.DisplayMember = "sDescripcionMoneda";
            cboMoneda.Properties.DropDownRows = lMoneda.Count;
            cboMoneda.ItemIndex = 0;
        }
        //2022
        public void CargarMonedas()
        {
            try
            {
                lMoneda = Metodos.ListarMonedasMesaDePartes();
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception ex)
            {
                Program.mensajeError("Ha ocurrido un error al intentar cargar el tipo de monedas.");
            }

        }

        //2022
        public void RegistrarAutogenerado()
        {
            if (lDetalle.Count == 0)
            {
                Program.mensaje("Debe agregar al menos un elemento al detalle.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btn_Buscar.Focus();
                return;
            }

            Casilla origen = new Casilla();
            Casilla destino = new Casilla();
            if (cboBandejaOrigen.Properties.DataSource == null) return;
            if (cboPara.Properties.DataSource == null) return;
            origen.ID = (int)cboBandejaOrigen.EditValue;
            destino.ID = ((Casilla)cboPara.GetSelectedDataRow()).ID;

            if (origen.ID == 0) return;
            if (destino.ID == 0) return;

            if (origen.ID == destino.ID)
            {
                Program.mensaje("Debes elegir dos bandejas diferentes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Activate();
                btn_Buscar.Focus();
                return;
            }

            Objeto oObj = new Objeto();
            oObj.IdCasillaDe = origen.ID;
            oObj.IdCasillaPara = destino.ID;
            oObj.IdUsuario = Program.oUsuario.ID;
            oObj.Asunto = "Creado por Mesa de Partes";
            oObj.Mensaje = "";
            oObj.IdTipoDocumento = 1;
            oObj.ListaXML = oObj.SerializeObjectWindows(lDetalle);

            Program.ShowPopWaitScreen();
            try
            {
                oObj = Metodos.RegistrarCorrespondenciaMesaDePartes(oObj);
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                return;
            }
            catch (Exception ex)
            {
                Program.mensajeError("Ha ocurrido un error al intentar crear el Autogenerado.");
                return;
            }
            finally
            {
                Program.HidePopWaitScreen();
            }

            if (oObj != null)
            {
                lbl_Resultado.ForeColor = Color.Green;
                lbl_Resultado.Text = "Se ha creado el autogenerado " + oObj.Ticket;
                cboPara.Properties.DataSource = null;
                cboTipoEmpaque.EditValue = null;
                cboTipoEmpaque.Enabled = true;
                this.Activate();
                btn_Buscar.Focus();
                frmImpresionEtiquetaCorrespondencia fx = (frmImpresionEtiquetaCorrespondencia)Program.SetFormActive<frmImpresionEtiquetaCorrespondencia>("Documentos por Imprimir", Program.oMain);
                fx.CargarCorrespondenciaCreado();
                lDetalle = new List<Objeto>();
                grdDetalle.DataSource = lDetalle;
                frmCodigoAutogenerado frm = new frmCodigoAutogenerado();
                frm.autogenerado = oObj.Ticket;
                frm.ShowDialog(this);
                this.Activate();
                btn_Buscar.Focus();
            }
            else
            {
                lbl_Resultado.ForeColor = Color.Red;
                lbl_Resultado.Text = "Ha ocurrido un error, por favor vuelva a intentar";
            }
        }
        #endregion


        public frmNuevaMesaParte()
        {
            InitializeComponent();
        }

        private void frmNuevaMesaParte_Load(object sender, EventArgs e)
        {
            btn_Buscar.Select();
            CargarMonedas();
            grdDetalle.DataSource = lDetalle;
        }

        private void imgeliminar_Click(object sender, EventArgs e)
        {
            if (grvDetalle.GetFocusedRow() == null) return;

            try
            {
                Objeto o = (Objeto)grvDetalle.GetFocusedRow();
                if (o == null) return;

                lDetalle.Remove(o);
                grdDetalle.RefreshDataSource();
                grvDetalle.RefreshData();
            }
            catch (Exception) { }
            this.Activate();
            grvDetalle.Focus();
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            frmBuscarBandejaOrigen frmBBO = new frmBuscarBandejaOrigen();
            frmBBO.ShowDialog(this.Parent);
            if (frmBBO.DialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                List<Casilla> lC = new List<Casilla>();
                lC.Add(frmBBO.oC);

                cboPara.Properties.DataSource = lC;
                cboPara.Properties.DisplayMember = "Descripcion";
                cboPara.Properties.ValueMember = "ID";
                cboPara.EditValue = lC[0].ID;
                this.Activate();
                cboTipoEmpaque.Focus();

            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            AgregarDetalle();
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Grabar_Click(object sender, EventArgs e)
        {
            RegistrarAutogenerado();
        }

        private void txt_Procedencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.mayusculas(e);
        }

        private void cboMoneda_EditValueChanged(object sender, EventArgs e)
        {
            if (cboMoneda.EditValue == null)
            {
                return;
            }
            if (cboMoneda.Properties.GetDisplayText(cboMoneda.EditValue) == "NINGUNA")
            {
                lblMonto.Text = "Cantidad";
                txt_Monto.Properties.IsFloatValue = false;
                txt_Monto.EditValue = 1;
                txt_Monto.Focus();
                txt_Monto.SelectAll();
            }
            else
            {
                lblMonto.Text = "Monto";
                txt_Monto.Properties.IsFloatValue = true;
                txt_Monto.EditValue = 1.0;
                txt_Monto.Focus();
                txt_Monto.SelectAll();
            }
        }

        private void cboTipoEmpaque_EditValueChanged(object sender, EventArgs e)
        {
            if (cboTipoEmpaque.EditValue == null)
            {
                cbTipoDocumento.Properties.DataSource = null;
                cbTipoDocumento.EditValue = null;
                return;
            }
            BaseEdit be = (BaseEdit)sender;
            CargarTiposDeDocumento((Byte)be.EditValue);
        }

        private void txt_Observacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.mayusculas(e);
        }

        private void cbTipoDocumento_EditValueChanged_1(object sender, EventArgs e)
        {
            if (cbTipoDocumento.EditValue == null)
            {
                cboMoneda.Properties.DataSource = null;
                cboMoneda.EditValue = null;
                return;
            }
            MostrarMonedaCantidadDocumento(((TipoDocumento)cbTipoDocumento.GetSelectedDataRow()).iMoneda);
        }
    }
}