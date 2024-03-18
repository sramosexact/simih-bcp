using DevExpress.XtraEditors;
using Interna.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace ExpedicionInternaPC
{
    public partial class frmDetalleDocumento : frmChild
    {

        #region Variables

        public List<CampoExterno> LCampoExternoComun = new List<CampoExterno>();
        public List<CampoExterno> LCampoExterno = new List<CampoExterno>();
        public List<CampoExterno> LCampoMoneda = new List<CampoExterno>();
        public Documento oDocumento;
        private string RUTA_PDF_SERVIDOR = ""; // Settings.Default.RutaPDFServidor;

        #endregion

        #region Metodos

        // Revisado
        public void GenerarControles()
        {
            //size ancho 405, alto 658  
            //Etiquetas
            int lblX = 20;
            int lblY = 20;
            int lblSeparacion = 40;
            //TextEdit
            int txtX = 20;
            int txtY = 35;
            int txtSeparacion = 40;
            int iAltoCajaTexto = 20;
            int iAnchoCajaTexto = 342;
            int iIndexTab = 1;

            foreach (CampoExterno c in LCampoExternoComun)
            {
                LabelControl lblEtiqueta = new DevExpress.XtraEditors.LabelControl();
                lblEtiqueta.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F);
                lblEtiqueta.Appearance.ForeColor = System.Drawing.Color.DimGray;
                lblEtiqueta.Name = "lbl" + iIndexTab.ToString();
                lblEtiqueta.TabIndex = 0;
                lblEtiqueta.Text = c.sDescripcionCampoExterno + " :";
                pnlContenedor.Controls.Add(lblEtiqueta);
                lblEtiqueta.Location = new System.Drawing.Point(lblX, lblY);
                TextEdit txtControl = new TextEdit();
                ((System.ComponentModel.ISupportInitialize)(txtControl.Properties)).BeginInit();
                txtControl.Name = c.sDescripcionCampoExterno;
                txtControl.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F);
                txtControl.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F);
                txtControl.Properties.Appearance.ForeColor = System.Drawing.Color.DimGray;
                txtControl.Properties.Appearance.Options.UseFont = true;
                txtControl.Properties.Appearance.Options.UseForeColor = true;
                txtControl.Size = new System.Drawing.Size(iAnchoCajaTexto, iAltoCajaTexto);
                txtControl.TabIndex = iIndexTab;
                txtControl.KeyPress += new KeyPressEventHandler(this.TxtControl_KeyPress);
                pnlContenedor.Controls.Add(txtControl);
                txtControl.Text = c.sValor.ToUpper();
                txtControl.Location = new System.Drawing.Point(txtX, txtY);
                txtControl.ReadOnly = true;
                ((System.ComponentModel.ISupportInitialize)(txtControl.Properties)).EndInit();
                txtY = txtY + txtSeparacion;
                lblY = lblY + lblSeparacion;
                iIndexTab++;
            }

            foreach (CampoExterno c in LCampoExterno)
            {
                LabelControl lblEtiqueta = new DevExpress.XtraEditors.LabelControl();
                lblEtiqueta.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F);
                lblEtiqueta.Appearance.ForeColor = System.Drawing.Color.DimGray;
                lblEtiqueta.Name = "lbl" + iIndexTab.ToString();
                lblEtiqueta.TabIndex = 0;
                lblEtiqueta.Text = c.sDescripcionCampoExterno + " :";
                pnlContenedor.Controls.Add(lblEtiqueta);
                lblEtiqueta.Location = new System.Drawing.Point(lblX, lblY);
                TextEdit txtControl = new TextEdit();
                ((System.ComponentModel.ISupportInitialize)(txtControl.Properties)).BeginInit();
                txtControl.Name = c.sDescripcionCampoExterno;
                txtControl.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F);
                txtControl.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F);
                txtControl.Properties.Appearance.ForeColor = System.Drawing.Color.DimGray;
                txtControl.Properties.Appearance.Options.UseFont = true;
                txtControl.Properties.Appearance.Options.UseForeColor = true;
                txtControl.Size = new System.Drawing.Size(iAnchoCajaTexto, iAltoCajaTexto);
                txtControl.TabIndex = iIndexTab;
                txtControl.KeyPress += new KeyPressEventHandler(this.TxtControl_KeyPress);
                pnlContenedor.Controls.Add(txtControl);
                txtControl.Text = c.sValor.ToUpper();
                txtControl.Location = new System.Drawing.Point(txtX, txtY);
                txtControl.ReadOnly = true;
                ((System.ComponentModel.ISupportInitialize)(txtControl.Properties)).EndInit();
                txtY = txtY + txtSeparacion;
                lblY = lblY + lblSeparacion;
                iIndexTab++;
            }

            if (LCampoMoneda != null)
            {
                if (LCampoMoneda.Count > 0)
                {
                    foreach (CampoExterno c in LCampoMoneda)
                    {
                        LabelControl lblEtiqueta = new DevExpress.XtraEditors.LabelControl();
                        lblEtiqueta.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F);
                        lblEtiqueta.Appearance.ForeColor = System.Drawing.Color.DimGray;
                        lblEtiqueta.Name = "lbl" + iIndexTab.ToString();
                        lblEtiqueta.TabIndex = 0;
                        lblEtiqueta.Text = c.sDescripcionCampoExterno + " :";
                        pnlContenedor.Controls.Add(lblEtiqueta);
                        lblEtiqueta.Location = new System.Drawing.Point(lblX, lblY);
                        TextEdit txtControl = new TextEdit();
                        ((System.ComponentModel.ISupportInitialize)(txtControl.Properties)).BeginInit();
                        txtControl.Name = c.sDescripcionCampoExterno;
                        txtControl.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F);
                        txtControl.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F);
                        txtControl.Properties.Appearance.ForeColor = System.Drawing.Color.DimGray;
                        txtControl.Properties.Appearance.Options.UseFont = true;
                        txtControl.Properties.Appearance.Options.UseForeColor = true;
                        txtControl.Size = new System.Drawing.Size(iAnchoCajaTexto, iAltoCajaTexto);
                        txtControl.TabIndex = iIndexTab;
                        txtControl.KeyPress += new KeyPressEventHandler(this.TxtControl_KeyPress);
                        pnlContenedor.Controls.Add(txtControl);
                        txtControl.Text = c.sValor.ToUpper();
                        txtControl.Location = new System.Drawing.Point(txtX, txtY);
                        ((System.ComponentModel.ISupportInitialize)(txtControl.Properties)).EndInit();
                        txtY = txtY + txtSeparacion;
                        lblY = lblY + lblSeparacion;
                        iIndexTab++;
                    }
                }
            }

            if (oDocumento.requiereDigitalizacion == true)
            {
                try
                {
                    using (WebClient client = new WebClient())
                    {
                        Uri uri = new Uri(RUTA_PDF_SERVIDOR + oDocumento.sNombreImagen);
                        Program.ShowPopWaitScreen();
                        using (var imgStream = new MemoryStream(client.DownloadData(uri.AbsoluteUri)))
                        {
                            Program.HidePopWaitScreen();

                            this.pdfViewer1.LoadDocument(imgStream);
                            this.pdfViewer1.ZoomMode = DevExpress.XtraPdfViewer.PdfZoomMode.PageLevel;


                            //picDocumento.Image = Image.FromStream(imgStream);
                            //Image img = new Bitmap(picDocumento.Image);
                            //picDocumento.Image = img;//new Bitmap(picDocumento.Image, new Size(picDocumento.Width, picDocumento.Height));
                            //picDocumento.Properties.ZoomPercent = 50;
                        }
                    }
                }
                catch (Exception e)
                {
                    Program.HidePopWaitScreen();
                    Program.mensaje(e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        // Revisado
        private void AmpliarImagen()
        {
            if (picDocumento.Image != null)
            {
                frmImagenAmpliada fx = new frmImagenAmpliada();
                fx.NombreImagen = oDocumento.sNombreImagen;
                fx.ImagenAdquirida = picDocumento.Image;
                fx.Documento = oDocumento.TipoDocumento;
                fx.CodigoDocumento = oDocumento.sCodigoDocumento;
                fx.ShowDialog(this.Parent);
            }
            else
            {
                Program.mensaje("No hay imagen para ampliar.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void CargarFormulario()
        {
            this.Text = $"Detalle del documento {oDocumento.iId}";
            if (oDocumento.iIdEstado == (int)EnumEstadoDocumento.RECHAZADO)
            {
                btnAsociar.Visible = true;
            }
        }

        private void Asociar()
        {
            frmRegistroDigitalizacionDocumentos fx = new frmRegistroDigitalizacionDocumentos();
            fx.oDocumentoRechazado = oDocumento;
            if (fx.ShowDialog() == DialogResult.OK)
            {
                this.Close();
            }

        }
        #endregion

        // Revisado
        public frmDetalleDocumento()
        {
            InitializeComponent();
        }
        // Revisado
        private void TxtControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.mayusculas(e);
        }
        // Revisado
        private void btnAmpliarImagen_Click(object sender, EventArgs e)
        {
            AmpliarImagen();
        }

        private void frmDetalleDocumento_Load(object sender, EventArgs e)
        {
            CargarFormulario();
        }

        private void pdfViewer1_PopupMenuShowing(object sender, DevExpress.XtraPdfViewer.PdfPopupMenuShowingEventArgs e)
        {
            e.ItemLinks.Clear();
        }

        private void btnAsociar_Click(object sender, EventArgs e)
        {
            Asociar();
        }
    }
}
