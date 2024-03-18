using Interna.Entity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ExpedicionInternaPC
{
    public partial class frmRegistroDocumentos : frmChild
    {

        #region Variables

        List<Casilla> ListaOrigen;
        List<Casilla> ListaDestino;
        List<Tipo> ListaTipoDocumento;
        List<Tipo> ListaMoneda;

        public Documento oDocumentoRechazado;

        #endregion


        #region Metodos

        private void CargarMoneda()
        {
            ListaMoneda = new List<Tipo>();
            ListaMoneda.Add(new Tipo { ID = 1, Descripcion = "SOLES" });
            ListaMoneda.Add(new Tipo { ID = 2, Descripcion = "DOLARES" });
            ListaMoneda.Add(new Tipo { ID = 3, Descripcion = "EUROS" });
            cboMoneda.Properties.DataSource = ListaMoneda;
            cboMoneda.Properties.DisplayMember = "Descripcion";
            cboMoneda.Properties.ValueMember = "ID";
            cboMoneda.Properties.DropDownRows = ListaMoneda.Count;
        }

        private void CargarBandejaDestinoTipoDocumento()
        {
            try
            {
                ListaDestino = Metodos.ListarBandejaTipoDocumento();
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }

        }

        private void CargarOrigen()
        {
            ListaOrigen = new List<Casilla>();
            Casilla oCasilla = new Casilla();
            oCasilla.ID = Program.oUsuario.idCasilla;
            oCasilla.Descripcion = "MESA DE PARTES";

            ListaOrigen.Add(oCasilla);

            txtOrigen.Text = ListaOrigen[0].Descripcion.ToUpper();
        }

        private void CargarDestino()
        {
            cboDestino.Properties.DataSource = ListaDestino;
            cboDestino.Properties.DisplayMember = "Descripcion";
            cboDestino.Properties.ValueMember = "ID";
            cboDestino.Properties.DropDownRows = ListaDestino.Count;
            cboDestino.EditValue = null;
        }

        private void CargarTipo()
        {
            cboTipoDocumento.Properties.DataSource = ListaTipoDocumento;
            cboTipoDocumento.Properties.DisplayMember = "Descripcion";
            cboTipoDocumento.Properties.ValueMember = "ID";
            cboTipoDocumento.Properties.DropDownRows = ListaTipoDocumento.Count;
            cboTipoDocumento.EditValue = null;
            cboTipoDocumento.Focus();
        }

        private void AdquirirImagen()
        {
            if (txtNumeroDocumento.Text.Trim().Length > 0)
            {
                try
                {
                    Scanner oScanner = new Scanner();
                    //oScanner.Scann(WIA.WiaImageBias.MaximizeQuality); 
                    picDocumento.Image = Image.FromFile(string.Format(@"D:\img\{0}.jpg", txtNumeroDocumento.Text.Trim()));
                    picDocumento.Properties.ZoomPercent = 50;
                }
                catch (System.IO.FileNotFoundException ex)
                {
                    Program.mensaje(string.Format("No existe imagen del documento Nro. ", txtNumeroDocumento.Text.Trim()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                catch (Exception ex)
                {
                    Program.mensaje(string.Format("Ha ocurrido un error. Vuelva a intentarlo.", txtNumeroDocumento.Text.Trim()), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                Program.mensaje("Debe ingresar el número de documento para adquirir la imagen.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void AmpliarImagen()
        {
            if (picDocumento.Image != null)
            {
                frmImagenAmpliada fx = new frmImagenAmpliada();
                fx.NombreImagen = txtNumeroDocumento.Text.Trim();
                fx.ImagenAdquirida = picDocumento.Image;
                fx.Documento = ((Tipo)cboTipoDocumento.GetSelectedDataRow()).Descripcion;
                fx.CodigoDocumento = txtNumeroDocumento.Text.Trim();
                fx.ShowDialog(this.Parent);
            }
            else
            {
                Program.mensaje(string.Format("No hay imagen para ampliar.", txtNumeroDocumento.Text.Trim()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void GuardarDocumento()
        {
            Documento oDocumento = new Documento()
            {
                iIdCasillaDe = Program.oUsuario.idCasilla,
                iIdCasillaPara = (int)cboDestino.EditValue,
                iIdUsuarioCreador = Program.oUsuario.ID,
                iIdTipoDocumento = (int)cboTipoDocumento.EditValue,
                sCodigoDocumento = txtNumeroDocumento.Text.Trim().ToUpper(),
                sProcedencia = txtProcedencia.Text.Trim().ToUpper(),
                sObservacion = txtObservacion.Text.Trim().ToUpper(),
                iMoneda = (int)cboMoneda.EditValue,
                iMonto = decimal.Parse(txtMonto.Text.Trim()),
                sNombreImagen = string.Format(@"D:\img\{0}.jpg", txtNumeroDocumento.Text.Trim())
            };

            int res = 0;
            List<Objeto> lobj;

            if (oDocumentoRechazado != null)
            {
                oDocumento.iId = oDocumentoRechazado.iId;
                try
                {
                    res = Metodos.ModificarDocumento(oDocumento);
                }
                catch (InvalidTokenException)
                {
                    Program.mensajeTokenInvalido();
                    return;
                }

            }
            else
            {
                try
                {
                    lobj = Metodos.RegistrarDocumento(oDocumento, false, oDocumentoRechazado.iId);
                }
                catch (InvalidTokenException)
                {
                    Program.mensajeTokenInvalido();
                    return;
                }

            }



            if (res >= 0)
            {
                cboTipoDocumento.EditValue = null;
                cboDestino.EditValue = null;
                txtNumeroDocumento.Text = "";
                txtProcedencia.Text = "";
                cboMoneda.EditValue = null;
                txtMonto.Text = "";
                txtCentimos.Text = "00";
                txtObservacion.Text = "";
                picDocumento.Image = null;
                Program.mensaje("Registrado satisfactoriamente.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboTipoDocumento.Focus();
            }
            else
            {
                Program.mensaje("Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }





        }

        private void CargarDatosRechazado()
        {

            string[] valor;
            valor = oDocumentoRechazado.iMonto.ToString().Split('.');

            cboTipoDocumento.EditValue = oDocumentoRechazado.iIdTipoDocumento;
            txtNumeroDocumento.Text = oDocumentoRechazado.sCodigoDocumento;
            txtProcedencia.Text = oDocumentoRechazado.sProcedencia;
            cboMoneda.EditValue = oDocumentoRechazado.iMoneda;
            txtMonto.Text = valor[0];
            txtCentimos.Text = valor[1];
            txtObservacion.Text = oDocumentoRechazado.sObservacion;

            try
            {
                picDocumento.Image = Image.FromFile(oDocumentoRechazado.sNombreImagen);
            }
            catch { }

            if (oDocumentoRechazado.iIdEstado > 2)
            {

            }

        }

        #endregion


        public frmRegistroDocumentos()
        {
            InitializeComponent();
            cboTipoDocumento.Focus();
        }

        private void frmRegistroDocumentos_Load(object sender, EventArgs e)
        {
            CargarMoneda();
            CargarBandejaDestinoTipoDocumento();
            CargarTipo();
            CargarDestino();
            CargarOrigen();

            if (oDocumentoRechazado != null)
            {
                CargarDatosRechazado();
            }
        }

        private void cboTipoDocumento_EditValueChanged(object sender, EventArgs e)
        {
            if (cboTipoDocumento.EditValue != null)
            {
                cboDestino.EditValue = (ListaDestino.Find(x => x.TipoDocumentoAsociado == ((Tipo)cboTipoDocumento.GetSelectedDataRow()).ID)).ID;
                txtNumeroDocumento.Focus();
            }
        }

        private void txtNumeroDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.soloNumeros(e);
        }

        private void txtProcedencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.mayusculas(e);
        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.soloNumeros(e);
        }

        private void btnAdquirirImagen_Click(object sender, EventArgs e)
        {
            AdquirirImagen();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarDocumento();
        }

        private void btnAmpliarImagen_Click(object sender, EventArgs e)
        {
            AmpliarImagen();
        }

        private void txtObservacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.mayusculas(e);
        }

        private void cboMoneda_EditValueChanged(object sender, EventArgs e)
        {
            if (cboMoneda.EditValue != null)
            {
                txtMonto.Focus();
            }
        }

        private void txtMonto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Decimal || e.KeyCode == Keys.OemPeriod)
            {
                txtCentimos.Focus();
                txtCentimos.SelectAll();
            }
        }

        private void txtCentimos_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.soloNumeros(e);
        }

    }
}
