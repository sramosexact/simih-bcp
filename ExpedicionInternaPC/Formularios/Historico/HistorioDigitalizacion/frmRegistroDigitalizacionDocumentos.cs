using DevExpress.XtraEditors;
using ExpedicionInternaPC.Formularios.Gestion;
using Interna.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ExpedicionInternaPC
{
    public partial class frmRegistroDigitalizacionDocumentos : frmChild
    {
        #region Propiedades

        List<Casilla> ListaOrigen;
        List<Casilla> ListaDestino;
        List<TipoDocumento> ListaTipoDocumento;
        DevExpress.XtraEditors.PanelControl pnlContenedorControl;

        //FileStream imagenScaner;
        //FileInfo imageInfo;

        FileInfo pdfInfo;

        List<Moneda> ListaMoneda;

        List<CampoDigitalizacion> LCampos;

        private string codigo_documento = "";

        //private string PATH = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "scanSimih.jpeg";
        //private string PATHPDF = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "pdfSimih.pdf";

        //private string RUTA_IMAGEN_LOCAL = Settings.Default.RutaImagenLocal;
        //private string RUTA_IMAGEN_SERVIDOR = Settings.Default.RutaImagenServidor;
        private string RUTA_PDF_LOCAL = ""; // Settings.Default.RutaPDFLocal;
        private string RUTA_PDF_SERVIDOR = ""; //Settings.Default.RutaPDFServidor;
        private int PDF_MAX_LENGTH = 0; // int.Parse(Settings.Default.PdfSize);

        public Documento oDocumentoRechazado = new Documento();

        #endregion


        #region Metodos

        public void liberarRecurso(FileStream imagenScaner)
        {

            if (picDocumento.Image != null)
            {
                picDocumento.Image.Dispose();
            }
            if (imagenScaner != null)
            {
                imagenScaner.Close();
                imagenScaner.Dispose();
            }
        }

        public void liberarRecursoPDF(FileStream pdfFile)
        {

            pdfViewer1.CloseDocument();

            if (pdfFile != null)
            {
                pdfFile.Close();
                pdfFile.Dispose();
            }
            txtRutaArchivoPDF.Text = "";
        }

        private void ResetearControles()
        {
            cboMoneda.EditValue = null;
            txtMonto.Text = "";
            txtCentimos.Text = "00";

            foreach (CampoDigitalizacion oCampo in LCampos)
            {
                pnlContenedorControl.Controls[oCampo.sDescripcion].Text = "";
            }
        }

        private void CargarOrigen()
        {
            ListaOrigen = new List<Casilla>();
            Casilla oCasilla = new Casilla();
            oCasilla.ID = Program.oUsuario.idCasilla;
            oCasilla.Descripcion = "MESA DE PARTES";

            ListaOrigen.Add(oCasilla);

        }

        private void CargarTipo()
        {
            try
            {
                ListaTipoDocumento = Metodos.ListarTipoDocumentoDigital();
                cboTipoDocumento.Properties.DataSource = ListaTipoDocumento;
                cboTipoDocumento.Properties.DisplayMember = "sDescripcionTipoDocumento";
                cboTipoDocumento.Properties.ValueMember = "iIdTipoDocumento";
                cboTipoDocumento.Properties.DropDownRows = ListaTipoDocumento.Count;
                cboTipoDocumento.EditValue = null;
                cboTipoDocumento.Focus();
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                return;
            }

        }

        private void GenerarControles()
        {


            if (LCampos != null)
            {
                if (LCampos.Count > 0)
                {
                    List<TextEdit> ListaControles = new List<TextEdit>();

                    if (this.Controls["pnlContenedorControl"] != null)
                    {
                        this.Controls.Remove(pnlContenedorControl);
                        pnlContenedorControl = null;
                    }


                    int iAltoLabel = 13;
                    int iAnchoLabel = 23;
                    int iPosicionXLabel = 33;
                    int iNuevaPosicionYLabel = 6;
                    int iSeparacionAltoLabel = 33;


                    int iAltoCajaTexto = 20;
                    int iAnchoCajaTexto = 342;

                    int iSeparacionAltoControles = 26;
                    int iPosicionXCajaTexto = 33;
                    int iNuevaPosicionYCajaTexto = 25;

                    int iAltoPanel = (iAltoCajaTexto * LCampos.Count) + (iSeparacionAltoControles * (LCampos.Count + 1));
                    int iAnchoPanel = 399;
                    int iPosicionXPanel = 12;
                    int iPosicionYPanel = 80;

                    int iIndexTab = 1;


                    this.pnlContenedorControl = new DevExpress.XtraEditors.PanelControl();
                    ((System.ComponentModel.ISupportInitialize)(this.pnlContenedorControl)).BeginInit();
                    this.pnlContenedorControl.Location = new System.Drawing.Point(iPosicionXPanel, iPosicionYPanel);
                    this.pnlContenedorControl.Name = "pnlContenedorControl";
                    this.pnlContenedorControl.Size = new System.Drawing.Size(iAnchoPanel, iAltoPanel);
                    this.pnlContenedorControl.TabIndex = 13;
                    this.Controls.Add(this.pnlContenedorControl);
                    ((System.ComponentModel.ISupportInitialize)(this.pnlContenedorControl)).EndInit();



                    foreach (CampoDigitalizacion oCampo in LCampos)
                    {

                        LabelControl lblEtiqueta = new DevExpress.XtraEditors.LabelControl();
                        pnlContenedorControl.Controls.Add(lblEtiqueta);

                        LabelControl lblRequerido = new DevExpress.XtraEditors.LabelControl();
                        pnlContenedorControl.Controls.Add(lblRequerido);

                        lblEtiqueta.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F);
                        lblEtiqueta.Appearance.ForeColor = System.Drawing.Color.DimGray;
                        lblEtiqueta.Location = new System.Drawing.Point(iPosicionXLabel, iNuevaPosicionYLabel);
                        lblEtiqueta.Name = "lbl" + oCampo.sDescripcion;
                        lblEtiqueta.Size = new System.Drawing.Size(iAnchoLabel, iAltoLabel);
                        lblEtiqueta.TabIndex = 0;
                        lblEtiqueta.Text = oCampo.sDescripcion + " :";


                        TextEdit txtControl = new TextEdit();
                        ((System.ComponentModel.ISupportInitialize)(txtControl.Properties)).BeginInit();
                        txtControl.Name = oCampo.sDescripcion;
                        txtControl.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F);
                        txtControl.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F);
                        txtControl.Properties.Appearance.ForeColor = System.Drawing.Color.DimGray;
                        txtControl.Properties.Appearance.Options.UseFont = true;
                        txtControl.Properties.Appearance.Options.UseForeColor = true;
                        txtControl.Size = new System.Drawing.Size(iAnchoCajaTexto, iAltoCajaTexto);
                        txtControl.TabIndex = iIndexTab;
                        txtControl.KeyPress += new KeyPressEventHandler(this.TxtControl_KeyPress);
                        pnlContenedorControl.Controls.Add(txtControl);

                        txtControl.Location = new System.Drawing.Point(iPosicionXCajaTexto, iNuevaPosicionYCajaTexto);
                        ((System.ComponentModel.ISupportInitialize)(txtControl.Properties)).EndInit();


                        // -----------------------------------------------------------------------------------------
                        lblRequerido.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F);
                        lblRequerido.Appearance.ForeColor = System.Drawing.Color.Red;
                        lblRequerido.Location = new System.Drawing.Point(iPosicionXCajaTexto - 10, iNuevaPosicionYCajaTexto + 5);
                        lblRequerido.Name = "lblR" + oCampo.sDescripcion;
                        lblRequerido.Size = new System.Drawing.Size(iAnchoLabel, iAltoLabel);
                        lblRequerido.TabIndex = 0;
                        lblRequerido.Text = "*";
                        lblRequerido.Visible = !oCampo.opcional;
                        // -----------------------------------------------------------------------------------------


                        iNuevaPosicionYCajaTexto = iNuevaPosicionYCajaTexto + iAltoCajaTexto + iSeparacionAltoControles;
                        iNuevaPosicionYLabel = iNuevaPosicionYLabel + iAltoLabel + iSeparacionAltoLabel;

                        if (oCampo.iIdentificador == 1)
                        {
                            this.codigo_documento = txtControl.Name;
                        }

                        iIndexTab++;
                    }

                    if (((TipoDocumento)cboTipoDocumento.GetSelectedDataRow()).iMoneda == 1)
                    {
                        int iPosicionGrupoMoneda = iAltoPanel + iPosicionYPanel + 6;
                        this.pnlMoneda.Location = new System.Drawing.Point(iPosicionXPanel, iPosicionGrupoMoneda);
                        this.pnlMoneda.Visible = true;
                    }
                    else
                    {
                        this.pnlMoneda.Visible = false;
                    }

                    pnlContenedorControl.Controls[1].Focus();

                }
            }
        }

        private bool ValidarCamposRequeridos()
        {
            bool resultado = false;
            foreach (Control c in pnlContenedorControl.Controls)
            {
                string cs = c.GetType().ToString();
                if (c.GetType().ToString().Equals("DevExpress.XtraEditors.TextEdit"))
                {
                    if (LCampos.Exists(x => (x.sDescripcion == c.Name && x.opcional == false)))
                    {
                        if (c.Text.Trim().Length == 0)
                        {
                            Program.mensaje($"El campo {c.Name} es requerido.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            c.Focus();
                            resultado = true;
                            break;
                        }
                    }
                }
            }


            return resultado;
            //if (resultado)
            //{
            //    return resultado;
            //}
            //else
            //{
            //    TipoDocumento oT = (TipoDocumento)cboTipoDocumento.GetSelectedDataRow();

            //    if (oT.requiereDigitalizacion)
            //    {
            //        if (txtRutaArchivoPDF.Text.Trim().Length == 0)
            //        {
            //            Program.mensaje($"El tipo de documento {oT.sDescripcionTipoDocumento} requiere un archivo PDF adjunto.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //            btnPDF.Focus();
            //            resultado = true;
            //        }
            //    }
            //    return resultado;
            //}



        }

        private void CargarDestino()
        {
            try
            {
                ListaDestino = Metodos.ListarBandejaTipoDocumento();
                cboDestino.Properties.DataSource = ListaDestino;
                cboDestino.Properties.DisplayMember = "Descripcion";
                cboDestino.Properties.ValueMember = "ID";
                cboDestino.Properties.DropDownRows = ListaDestino.Count;
                cboDestino.EditValue = null;
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }


        }

        private void CargarMoneda()
        {
            try
            {
                ListaMoneda = new List<Moneda>();
                cboMoneda.Properties.DataSource = Metodos.ListarMonedasMesaDePartes();
                cboMoneda.Properties.DisplayMember = "sDescripcionMoneda";
                cboMoneda.Properties.ValueMember = "iIdMoneda";
                cboMoneda.Properties.DropDownRows = ListaMoneda.Count;
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }

        }

        private void SeleccionarArchivo()
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                    txtRutaArchivoPDF.Text = filePath;
                    this.pdfViewer1.LoadDocument(filePath);
                    this.pdfViewer1.ZoomMode = DevExpress.XtraPdfViewer.PdfZoomMode.PageLevel;
                    ////Read the contents of the file into a stream
                    //var fileStream = openFileDialog.OpenFile();

                    //using (StreamReader reader = new StreamReader(fileStream))
                    //{
                    //    fileContent = reader.ReadToEnd();
                    //}
                }
            }
        }

        private void GuardarDocumento()
        {

            TipoDocumento oT = (TipoDocumento)cboTipoDocumento.GetSelectedDataRow();

            FileStream pdfFile;

            if (ValidarCamposRequeridos())
            {
                return;
            }

            if (oT.requiereDigitalizacion)
            {
                if (txtRutaArchivoPDF.Text.Trim().Length == 0)
                {
                    Program.mensaje("Debe adjuntar un archivo PDF para poder generar el registro.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                try
                {
                    pdfInfo = new FileInfo(txtRutaArchivoPDF.Text.Trim());
                    if (pdfInfo.Length > (PDF_MAX_LENGTH * 1024 * 1024))
                    {
                        Program.mensaje("El tamaño del archivo no puede ser mayor a 5MB", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    pdfFile = pdfInfo.OpenRead();
                }
                catch (System.IO.FileNotFoundException ex)
                {
                    pdfFile = null;
                    Program.mensaje("Debe adjuntar un archivo PDF para poder generar el registro.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            Documento oDocumento = new Documento();

            List<CampoExterno> LCampoExterno = new List<CampoExterno>();
            foreach (CampoDigitalizacion oCampo in LCampos)
            {
                CampoExterno oExterno = new CampoExterno();
                oExterno.iIdCampoDigitalizacion = oCampo.iIdCampoDigitalizacion;
                oExterno.sValor = pnlContenedorControl.Controls[oCampo.sDescripcion].Text;
                LCampoExterno.Add(oExterno);
                if (oCampo.iIdentificador == 1) oDocumento.sCodigoDocumento = oExterno.sValor;
            }

            if (oT.iMoneda == 1)
            {
                if (cboMoneda.EditValue == null)
                {
                    Program.mensaje("Debe elegir una moneda de la lista.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cboMoneda.Focus();
                    return;
                }

                if (txtMonto.Text.Trim().Length == 0)
                {
                    Program.mensaje("Debe ingresar el monto correspondiente.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtMonto.Focus();
                    return;
                }

                if (txtCentimos.Text.Trim().Length == 0)
                {
                    Program.mensaje("Debe ingresar el monto correspondiente.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtCentimos.Focus();
                    return;
                }

                oDocumento.iMoneda = oT.iMoneda;
                oDocumento.iMonto = decimal.Parse(txtMonto.Text.Trim()) + decimal.Parse(txtCentimos.Text.Trim());
            }
            else
            {
                oDocumento.iMoneda = 0;
                oDocumento.iMonto = 1;
            }

            oDocumento.iIdEmpaque = (int)(oT.iIdTipoCorrespondencia);
            oDocumento.iIdCasillaDe = Program.oUsuario.idCasilla;
            oDocumento.iIdCasillaPara = (int)cboDestino.EditValue;
            oDocumento.iIdUsuarioCreador = Program.oUsuario.ID;
            oDocumento.iIdTipoDocumento = (int)(oT.iIdTipoDocumento);
            oDocumento.sNombreImagen = "";

            if (oT.requiereDigitalizacion)
            {
                oDocumento.sNombreImagen = string.Format("{0}.pdf", oDocumento.sCodigoDocumento.Trim());
            }

            oDocumento.sProcedencia = "";
            oDocumento.sObservacion = "";
            oDocumento.Descripcion = oDocumento.SerializeObjectWindows(LCampoExterno);

            //int res = 0;

            List<Objeto> lobj;

            try
            {
                lobj = Metodos.RegistrarDocumento(oDocumento, chkConAutogenerado.Checked, oDocumentoRechazado.iId);

                if (lobj[0].ID > 0)
                {
                    ResetearControles();

                    frmDocumentosProcesados fx = (frmDocumentosProcesados)Program.SetFormActive<frmDocumentosProcesados>("DocumentosProcesados", Program.oMain);
                    fx.CargarDocumentosProcesados();
                    this.Activate();
                    cboTipoDocumento.Focus();
                }
                else if (lobj[0].ID == -2)
                {
                    Program.mensaje("El documento ya se encuentra asociado a otro registro.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    Program.mensaje("Ha ocurrido un error, inténtelo nuevamente.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                return;
            }

            if (oT.requiereDigitalizacion)
            {
                try
                {
                    pdfFile = pdfInfo.OpenRead();

                }
                catch (System.IO.FileNotFoundException ex)
                {
                    pdfFile = null;
                    Program.mensaje("Debe adjuntar un archivo PDF para poder generar el registro.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (lobj[0].ID > 0)
                {

                    string nuevoNombreArchivo = string.Format("{0}.pdf", lobj[0].ID);
                    int resultado = 0;

                    try
                    {

                        resultado = Metodos.GuardarPDFServidor(pdfFile, nuevoNombreArchivo);
                        if (resultado != 1)
                        {
                            Program.mensaje("Ha ocurrido un error, inténtelo nuevamente.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    catch (InvalidTokenException)
                    {
                        Program.mensajeTokenInvalido();
                        return;
                    }
                    catch (Exception e)
                    {
                        Program.mensaje(e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (chkConAutogenerado.Checked)
                    {
                        frmCodigoAutogenerado frm = new frmCodigoAutogenerado();
                        frm.autogenerado = lobj[0].Autogenerado;
                        frm.ShowDialog(this);
                        //chkConAutogenerado.Checked = false;
                        //Program.mensaje($"Se registró el documento con el autogenerado: { lobj[0].Autogenerado }", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        Program.mensaje("Registrado satisfactoriamente.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    //File.Delete(PATH);
                    //liberarRecurso(imagenScaner);

                    liberarRecursoPDF(pdfFile);

                    if (oDocumentoRechazado.iId > 0)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    //File.Delete(txtRutaArchivoPDF.Text.Trim());

                }
                else
                {
                    Program.mensaje("Ha ocurrido un error, inténtelo nuevamente.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (oDocumentoRechazado.iId > 0)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    if (chkConAutogenerado.Checked)
                    {
                        frmCodigoAutogenerado frm = new frmCodigoAutogenerado();
                        frm.autogenerado = lobj[0].Autogenerado;
                        frm.ShowDialog(this);
                        //Program.mensaje($"Se registró el documento con el autogenerado: { lobj[0].Autogenerado }", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        Program.mensaje("Registrado satisfactoriamente.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            chkConAutogenerado.Checked = true;
        }

        //private void Cancelar()
        //{
        //    if (cboTipoDocumento.EditValue != null)
        //    {
        //        foreach (CampoDigitalizacion oCampo in LCampos)
        //        {
        //            pnlContenedorControl.Controls[oCampo.sDescripcion].Text = "";
        //        }
        //        if (((TipoDocumento)cboTipoDocumento.GetSelectedDataRow()).iMoneda == 1)
        //        {
        //            txtMonto.Text = "";
        //            txtCentimos.Text = "00";
        //        }

        //        cboTipoDocumento.EditValue = null;
        //        cboDestino.EditValue = null;
        //        cboMoneda.EditValue = null;

        //        //if (picDocumento.Image != null)
        //        //{
        //        //    picDocumento.Image.Dispose();
        //        //    File.Delete(PATH);
        //        //}
        //        LCampos = null;

        //    }
        //}

        //private void AdquirirImagen()
        //{
        //    FileStream imagenScaner;
        //    imagenScaner = null;

        //    string nombreCampoIdentificador = "";

        //    if (LCampos == null)
        //    {
        //        Program.mensaje("Debe indicar los datos del documento antes de adquirir la imagen.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //        return;
        //    }

        //    foreach (CampoDigitalizacion oCampo in LCampos)
        //    {
        //        if (oCampo.iIdentificador == 1)
        //        {
        //            nombreCampoIdentificador = oCampo.sDescripcion;
        //            break;
        //        }
        //    }

        //    if (pnlContenedorControl.Controls[nombreCampoIdentificador].Text.Trim().Length == 0)
        //    {
        //        Program.mensaje(string.Format("Debe ingresar un valor en el campo '{0}' para poder realizar la digitalización del documento.", nombreCampoIdentificador.ToUpper()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //        return;
        //    }

        //    try
        //    {

        //        Scanner oScanner = new Scanner();

        //        frmEscanearDocumento frm = new frmEscanearDocumento();
        //        frm.ShowDialog(this.Parent);
        //        if (frm.DialogResult == DialogResult.OK)
        //        {

        //            imageInfo = new FileInfo(PATH);
        //            imagenScaner = imageInfo.OpenRead();

        //            //Carga el objeto FileStream a la propiedad Image del control picDocumento
        //            picDocumento.Image = Image.FromStream(imagenScaner); //Image.FromFile(path)
        //            picDocumento.Properties.ZoomPercent = 50;
        //            //Crear un nuevo objeto de tipo Image a partir del contenido de picDocumento.Image
        //            Image img = new Bitmap(picDocumento.Image);
        //            //Asignar el objeto img a la propiedad Image del picDocumento para que la imagen se visualize en el control
        //            picDocumento.Image = img;
        //            picDocumento.Properties.ZoomPercent = 50;
        //            //Liberar recursos del FileStream utilizado
        //            imagenScaner.Close();
        //            imagenScaner.Dispose();


        //        }

        //    }
        //    catch (System.IO.FileNotFoundException ex)
        //    {
        //        Program.mensaje(string.Format("No existe imagen del documento Nro. ", pnlContenedorControl.Controls[nombreCampoIdentificador].Text.Trim()), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //    }
        //    catch (Exception ex)
        //    {
        //        Program.mensaje(string.Format("Ha ocurrido un error. Vuelva a intentarlo.", pnlContenedorControl.Controls[nombreCampoIdentificador].Text.Trim()), MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }


        //}

        private void RequiereDigitalizacion(bool requiere)
        {
            lblRutaPDF.Enabled = requiere;
            txtRutaArchivoPDF.Enabled = requiere;
            btnPDF.Enabled = requiere;
            pdfViewer1.Enabled = requiere;
        }
        #endregion


        public frmRegistroDigitalizacionDocumentos()
        {
            InitializeComponent();
        }

        private void cboTipoDocumento_EditValueChanged(object sender, EventArgs e)
        {
            if (cboTipoDocumento.EditValue != null)
            {
                cboDestino.EditValue = (ListaDestino.Find(x => x.TipoDocumentoAsociado == (int)(((TipoDocumento)cboTipoDocumento.GetSelectedDataRow()).iIdTipoDocumento))).ID;
                CampoDigitalizacion oc = new CampoDigitalizacion();
                //oc.iIdTipoDocumento = (short)(((TipoDocumento)(cboTipoDocumento.GetSelectedDataRow())).iIdTipoDocumento);
                //TipoDocumento oTipoDocumento = new TipoDocumento() { iIdTipoDocumento = oc.iIdTipoDocumento };
                TipoDocumento oTipoDocumento = (TipoDocumento)(cboTipoDocumento.GetSelectedDataRow());


                RequiereDigitalizacion(oTipoDocumento.requiereDigitalizacion);

                pdfViewer1.CloseDocument();
                txtRutaArchivoPDF.Text = "";

                try
                {
                    LCampos = Metodos.ListarCamposActivosPorTipoDocumento(oTipoDocumento);
                }
                catch (InvalidTokenException)
                {
                    Program.mensajeTokenInvalido();
                    return;
                }

                GenerarControles();
            }
        }

        private void frmRegistroDigitalizacionDocumentos_Load(object sender, EventArgs e)
        {
            CargarMoneda();
            CargarOrigen();
            CargarTipo();
            CargarDestino();
        }

        private void TxtControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.mayusculas(e);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarDocumento();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //Cancelar();
        }

        private void btnAdquirirImagen_Click(object sender, EventArgs e)
        {
            //AdquirirImagen();
        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.soloNumeros(e);
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

        private void cboMoneda_EditValueChanged(object sender, EventArgs e)
        {
            if (cboMoneda.EditValue != null)
            {
                txtMonto.Focus();
            }
        }

        private void frmRegistroDigitalizacionDocumentos_FormClosed(object sender, FormClosedEventArgs e)
        {
            picDocumento.Image = null;
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            SeleccionarArchivo();
        }

        private void pdfViewer1_PopupMenuShowing(object sender, DevExpress.XtraPdfViewer.PdfPopupMenuShowingEventArgs e)
        {
            e.ItemLinks.Clear();
        }

        private void frmRegistroDigitalizacionDocumentos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (oDocumentoRechazado.iId == 0)
            {
                if (cboTipoDocumento.EditValue != null)
                {
                    if (Program.mensaje("¿Desea salir del formulario?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        e.Cancel = true;
                    }
                }
            }
        }
    }
}
