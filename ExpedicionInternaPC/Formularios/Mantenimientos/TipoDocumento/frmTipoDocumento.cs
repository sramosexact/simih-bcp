using ExpedicionInternaPC.Formularios.Mantenimientos;
using Interna.Entity;
using Interna.Entity.Estructuras;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ExpedicionInternaPC
{
    public partial class frmTipoDocumento : frmChild
    {

        #region Variables

        private int proceso = 0;
        private List<ListaTipoDocumentoView> LTipoDocumentoView;
        private List<ListaTipoDocumentoView> LTipoDocumentoSeleccionados = new List<ListaTipoDocumentoView>();
        private List<ModuloCreacion> LModulos;
        TipoDocumento oTipoDocumento = new TipoDocumento();
        TipoDocumento oTD;
        #endregion

        #region Metodos
        //2022
        public override void Actualizar(string CommandName)
        {
            base.Actualizar(CommandName);
            CargarTipoCorrespondenciaRegistrados();
        }
        //2022
        private void CargarTipoCorrespondencia()
        {
            try
            {
                List<TipoCorrespondencia> LTipoCorrespondencia = Metodos.ListarTipoCorrespondencia();
                cboTipoCorrespondencia.Properties.DataSource = LTipoCorrespondencia;
                cboTipoCorrespondencia.Properties.DisplayMember = "sDescripcionTipoCorrespondencia";
                cboTipoCorrespondencia.Properties.ValueMember = "iIdTipoCorrespondencia";
                cboTipoCorrespondencia.Properties.DropDownRows = LTipoCorrespondencia.Count;
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar cargar el tipo de correspondencia.");
            }

        }
        //2022
        private void CargarTipoValor()
        {
            List<Tipo> LTipoValor = new List<Tipo>();
            LTipoValor.Add(new Tipo() { ID = (int)TipoValor.CANTIDAD, Descripcion = TipoValor.CANTIDAD.ToString() });
            LTipoValor.Add(new Tipo() { ID = (int)TipoValor.MONEDA, Descripcion = TipoValor.MONEDA.ToString() });
            cboValor.Properties.DataSource = LTipoValor;
            cboValor.Properties.DisplayMember = "Descripcion";
            cboValor.Properties.ValueMember = "ID";
            cboValor.Properties.DropDownRows = LTipoValor.Count;
        }
        //2022
        private void CargarTipoCorrespondenciaRegistrados()
        {
            try
            {
                LTipoDocumentoView = Metodos.ListarTipoDocumentoRegistrados();
                grdDocumentos.DataSource = LTipoDocumentoView;
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar cargar los tipos de correspondencia registrados.");
            }

        }
        //2022
        private void CargarModuloCreacion()
        {
            try
            {
                LModulos = Metodos.ListarModulosCreacion();
                grdModulo.DataSource = LModulos;
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar cargar los tipo de módulo.");
            }
        }
        //2022
        private void CargarModuloTipoDocumento()
        {
            LModulos.ForEach(x => x.SeleccionGrafica = false);

            if (LTipoDocumentoSeleccionados.Count > 0)
            {
                TipoDocumento oTipoDocumentoSeleccionado = new TipoDocumento();
                LTipoDocumentoSeleccionados[0].CopyToObject(oTipoDocumentoSeleccionado);

                try
                {
                    List<ModuloCreacion> listaModulo = Metodos.ListarModulosCreacionPorTipoDocumento(oTipoDocumentoSeleccionado);

                    LModulos.ForEach(x =>
                    {
                        if (listaModulo.Find(y => y.iId == x.iId) != null)
                        {
                            x.SeleccionGrafica = true;
                            if (x.iId == 2)
                            {
                                btnEditarCamposDinamicos.Enabled = true;
                                oTD = new TipoDocumento();
                                oTD.CopyToMe(oTipoDocumentoSeleccionado);
                            }
                            else
                            {
                                btnEditarCamposDinamicos.Enabled = false;
                                oTD = null;
                            }
                        }

                    });

                    if (listaModulo.Count == 0)
                    {
                        btnEditarCamposDinamicos.Enabled = false;
                        oTD = null;
                    }

                    grdModulo.Enabled = true;
                }
                catch (InvalidTokenException)
                {
                    Program.mensajeTokenInvalido();
                }
                catch (Exception)
                {
                    Program.mensajeError("Ha ocurrido un error al intentar cargar los módulos por tipo de documento."); ;
                }
            }
            else
            {
                grdModulo.Enabled = false;
            }
            grdModulo.RefreshDataSource();
            grvModulo.RefreshData();
        }
        //2022
        private bool ValidarCampos()
        {
            if (txtDescripcion.Text.Trim() == "")
            {
                Program.mensaje("Debe completa el campo 'Descripción'.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDescripcion.Focus();
                return false;
            }

            if (cboTipoCorrespondencia.EditValue == null)
            {
                Program.mensaje("Debe seleccionar un 'Tipo de correspondencia' de la lista.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboTipoCorrespondencia.Focus();
                return false;
            }

            if (cboValor.EditValue == null)
            {
                Program.mensaje("Debe seleccionar un 'Tipo de valor' de la lista.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboValor.Focus();
                return false;
            }

            return true;
        }
        //2022
        private void Nuevo()
        {
            proceso = 1;
            txtDescripcion.Enabled = true;
            cboTipoCorrespondencia.Enabled = true;
            cboValor.Enabled = true;
            btnNuevo.Enabled = false;
            btnModificar.Enabled = false;
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            grdDocumentos.Enabled = false;
            grdModulo.Enabled = false;
            chkEntregaPersonalizada.Enabled = true;
        }
        //2022
        private void Modificar()
        {
            if (LTipoDocumentoSeleccionados.Count == 0)
            {
                Program.mensaje("Debe seleccionar un registro para modificar.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            proceso = 2;
            txtDescripcion.Enabled = true;
            cboTipoCorrespondencia.Enabled = true;
            cboValor.Enabled = true;
            btnNuevo.Enabled = false;
            btnModificar.Enabled = false;
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
            grdDocumentos.Enabled = false;
            grdModulo.Enabled = false;
            chkEntregaPersonalizada.Enabled = true;

            txtDescripcion.Text = LTipoDocumentoSeleccionados[0].sDescripcionTipoDocumento;
            cboValor.EditValue = (int)(LTipoDocumentoSeleccionados[0].iMoneda);
            cboTipoCorrespondencia.EditValue = LTipoDocumentoSeleccionados[0].iIdTipoCorrespondencia;
            chkEntregaPersonalizada.Checked = LTipoDocumentoSeleccionados[0].entregaPersonalizada;
        }
        //2022
        private void Cancelar()
        {
            proceso = 0;
            txtDescripcion.Enabled = false;
            cboTipoCorrespondencia.Enabled = false;
            cboValor.Enabled = false;
            btnNuevo.Enabled = true;
            btnModificar.Enabled = true;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            txtDescripcion.Text = "";
            cboTipoCorrespondencia.EditValue = null;
            cboValor.EditValue = null;
            grdDocumentos.Enabled = true;
            grdModulo.Enabled = true;
            chkEntregaPersonalizada.Checked = false;
            chkEntregaPersonalizada.Enabled = false;
        }
        //2022
        private void Guardar()
        {
            if (ValidarCampos())
            {
                int resultado = 0;

                if (proceso == 1)
                {
                    TipoDocumento oTipo = new TipoDocumento()
                    {
                        sDescripcionTipoDocumento = txtDescripcion.Text.Trim().ToUpper(),
                        iIdTipoCorrespondencia = ((TipoCorrespondencia)cboTipoCorrespondencia.GetSelectedDataRow()).iIdTipoCorrespondencia,
                        iMoneda = (Byte)((Tipo)cboValor.GetSelectedDataRow()).ID,
                        entregaPersonalizada = chkEntregaPersonalizada.Checked
                    };

                    try
                    {
                        resultado = Metodos.RegistrarTipoDocumento(oTipo);

                        if (resultado == 1)
                        {
                            Program.mensaje("Se registró correctamente.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Cancelar();
                            CargarTipoCorrespondenciaRegistrados();
                            grdModulo.Enabled = false;
                        }
                        else if (resultado == -2)
                        {
                            Program.mensaje("La descripción del tipo de documento ya existe.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtDescripcion.Focus();
                            txtDescripcion.SelectAll();
                        }
                        else
                        {
                            Program.mensaje("No se pudo guardar el registro.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (InvalidTokenException)
                    {
                        Program.mensajeTokenInvalido();
                    }
                    catch (Exception)
                    {
                        Program.mensajeError("Ha ocurrido un error al intentar registrar el tipo de documento.");
                    }


                }
                else if (proceso == 2)
                {

                    TipoDocumento oTipo = new TipoDocumento()
                    {
                        iIdTipoDocumento = LTipoDocumentoSeleccionados[0].iIdTipoDocumento,
                        sDescripcionTipoDocumento = txtDescripcion.Text.Trim().ToUpper(),
                        iIdTipoCorrespondencia = (byte)cboTipoCorrespondencia.EditValue,
                        iMoneda = (Byte)((Tipo)cboValor.GetSelectedDataRow()).ID,
                        entregaPersonalizada = chkEntregaPersonalizada.Checked
                    };
                    try
                    {
                        resultado = Metodos.ModificarTipoDocumento(oTipo);

                        if (resultado == 1)
                        {
                            Program.mensaje("Se modificó correctamente.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Cancelar();
                            CargarTipoCorrespondenciaRegistrados();
                            grdModulo.Enabled = false;
                            LTipoDocumentoSeleccionados.Clear();
                        }
                        else if (resultado == -2)
                        {
                            Program.mensaje("La descripción del tipo de documento ya existe.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            txtDescripcion.Focus();
                            txtDescripcion.SelectAll();
                        }
                        else
                        {
                            Program.mensaje("No se pudo guardar los cambios.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (InvalidTokenException)
                    {
                        Program.mensajeTokenInvalido();
                    }
                    catch (Exception)
                    {
                        Program.mensajeError("Ha ocurrido un error al intentar modificar el tipo de documento.");
                    }
                }
            }
        }
        //2022
        private void AsociarModulo(ModuloCreacion oModuloCreacion, TipoDocumento oTipoDocumento)
        {
            if (LTipoDocumentoSeleccionados.Count > 0)
            {
                Casilla casilla = new Casilla
                {
                    iId = 0
                };
                try
                {
                    int resultado = Metodos.AsociarModulo(oModuloCreacion, oTipoDocumento, casilla, "");

                    if (resultado < 1)
                    {
                        Program.mensaje("No se puede completar la acción.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        oModuloCreacion.SeleccionGrafica = true;
                    }
                }
                catch (InvalidTokenException)
                {
                    Program.mensajeTokenInvalido();
                }
                catch (Exception)
                {
                    Program.mensajeError("Ha ocurrido un error al intentar asociar el módulo al tipo de documento.");
                }
            }
        }

        private void QuitarAsociacionModulo(ModuloCreacion oModuloCreacion, TipoDocumento oTipoDocumento, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (LTipoDocumentoSeleccionados.Count > 0)
            {
                if (oModuloCreacion.iId == 2 && Program.mensaje("Se desvinculará el TipoDocumento con el Módulo de Digitalización."
                    + " ¿Desea continuar?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                    oModuloCreacion.SeleccionGrafica = true;
                    return;
                }
                try
                {
                    int resultado = Metodos.QuitarAsociacionModulo(oModuloCreacion, oTipoDocumento);

                    if (resultado < 1)
                    {
                        e.Cancel = true;
                        Program.mensaje("No se puede completar la acción.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        oModuloCreacion.SeleccionGrafica = false;
                    }
                }
                catch (InvalidTokenException)
                {
                    Program.mensajeTokenInvalido();
                }
                catch (Exception)
                {
                    Program.mensajeError("Ha ocurrido un error al intentar quitar la asociación del módulo.");
                }

            }
        }

        public void SeleccionarTipoDocumento(TipoDocumento oTipoDocumento)
        {
            for (int i = 0; i < grvDocumentos.RowCount; i++)
            {
                int rowHandle = grvDocumentos.GetVisibleRowHandle(i);
                if (((ListaTipoDocumentoView)grvDocumentos.GetRow(rowHandle)).iIdTipoDocumento == oTipoDocumento.iIdTipoDocumento)
                {
                    try
                    {
                        grvDocumentos.FocusedRowHandle = rowHandle;
                        grvDocumentos.SetRowCellValue(rowHandle, "SeleccionGrafica", true);
                        break;
                    }
                    catch (Exception)
                    {

                    }

                }
            }
        }

        #endregion

        public frmTipoDocumento()
        {
            InitializeComponent();
        }

        private void frmTipoDocumento_Load(object sender, EventArgs e)
        {
            CargarTipoCorrespondencia();
            CargarTipoValor();
            CargarTipoCorrespondenciaRegistrados();
            CargarModuloCreacion();
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.mayusculas(e);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Modificar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Cancelar();
        }

        private void grvDocumentos_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (grvDocumentos.FocusedColumn.FieldName != "SeleccionGrafica")
                {
                    return;
                }

                ListaTipoDocumentoView obj = (ListaTipoDocumentoView)grvDocumentos.GetFocusedRow();

                if (obj != null)
                {
                    if (LTipoDocumentoSeleccionados.Count == 0)
                    {
                        obj.SeleccionGrafica = true;
                        LTipoDocumentoSeleccionados.Add(obj);
                        grdDocumentos.Refresh();
                        grvDocumentos.RefreshData();

                    }
                    else
                    {
                        LTipoDocumentoView.Find(hol => hol.iIdTipoDocumento == LTipoDocumentoSeleccionados[0].iIdTipoDocumento).SeleccionGrafica = false;

                        if (obj.iIdTipoDocumento == LTipoDocumentoSeleccionados[0].iIdTipoDocumento)
                        {
                            LTipoDocumentoSeleccionados.Clear();
                        }
                        else
                        {
                            LTipoDocumentoSeleccionados.Clear();
                            obj.SeleccionGrafica = true;
                            LTipoDocumentoSeleccionados.Add(obj);
                        }

                        grdDocumentos.Refresh();
                        grvDocumentos.RefreshData();
                    }

                    CargarModuloTipoDocumento();
                }
            }
            catch
            {
                return;
            }
        }

        private void grvModulo_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

        }

        private void frmTipoDocumento_Deactivate(object sender, EventArgs e)
        {
            frmMain frmPadre = this.MdiParent as frmMain;
            if (Program.oUsuario.IdTipoAcceso == 43) frmPadre.subMostrarSupervision(false);
            if (Program.oUsuario.IdTipoAcceso == 80) frmPadre.subMostrarJefatura(false);
        }

        private void frmTipoDocumento_Activated(object sender, EventArgs e)
        {
            frmMain frmPadre = this.MdiParent as frmMain;
            if (Program.oUsuario.IdTipoAcceso == 43) frmPadre.subMostrarSupervision(true);
            if (Program.oUsuario.IdTipoAcceso == 80) frmPadre.subMostrarJefatura(true);
        }

        private void grvModulo_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

        }

        private void grvModulo_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {

        }

        private void CheckSeleccionGrafica_CheckStateChanged(object sender, EventArgs e)
        {

        }

        private void CheckSeleccionGrafica_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CheckSeleccionGrafica_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                if (LTipoDocumentoSeleccionados.Count == 0)
                {
                    return;
                }

                if (grvModulo.FocusedColumn.FieldName != "SeleccionGrafica")
                {
                    return;
                }
                else
                {
                    ModuloCreacion oModuloCreacion = (ModuloCreacion)grvModulo.GetFocusedRow();

                    if (oModuloCreacion != null)
                    {
                        oTipoDocumento = new TipoDocumento
                        {
                            iIdTipoDocumento = LTipoDocumentoSeleccionados[0].iIdTipoDocumento,
                            sDescripcionTipoDocumento = LTipoDocumentoSeleccionados[0].sDescripcionTipoDocumento
                        };

                        if (oModuloCreacion.SeleccionGrafica == false)
                        {
                            if (oModuloCreacion.iId == 2)
                            {
                                frmAsociarModuloTipoDocumentoCasilla frm = new frmAsociarModuloTipoDocumentoCasilla
                                {
                                    oTipoDocumento = oTipoDocumento
                                };
                                frm.ShowDialog(this.Parent);
                                if (frm.DialogResult != DialogResult.OK)
                                {
                                    e.Cancel = true;
                                }
                            }
                            else
                            {
                                AsociarModulo(oModuloCreacion, oTipoDocumento);
                            }

                        }
                        else
                        {
                            QuitarAsociacionModulo(oModuloCreacion, oTipoDocumento, e);
                        }
                    }
                }
            }
            catch
            {
                return;
            }
        }

        private void btnEditarCamposDinamicos_Click(object sender, EventArgs e)
        {
            if (oTD != null)
            {
                frmEditarCamposDinamicos fx = new frmEditarCamposDinamicos(oTD);
                if (fx.ShowDialog(this.Parent) == DialogResult.OK)
                {
                    grdDocumentos.Refresh();
                    grvDocumentos.RefreshData();
                }

            }


        }
    }
}
