using Interna.Entity;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ExpedicionInternaPC
{
    public partial class frmCrearModificarBandeja : frmChild
    {

        #region Variables

        public Casilla oCasilla;

        private List<Geo> lGeo;
        private List<Geo> ListaDepartamento;
        private List<Geo> ListaProvincia;
        private List<Geo> ListaDistrito;
        private List<Geo> ListaCalle;
        private List<Geo> ListaOficinaArea;
        #endregion

        #region Metodos

        //2022
        private void CargarDepartamento()
        {
            try
            {
                ListaDepartamento = Metodos.ListarDepartamento();
                cboDepartamento.Properties.DataSource = ListaDepartamento;
                cboDepartamento.Properties.ValueMember = "ID";
                cboDepartamento.Properties.DisplayMember = "Descripcion";
                cboDepartamento.Properties.DropDownRows = ListaDepartamento.Count;
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar cargar la lista de departamentos.");
            }

        }
        //2022
        private void CargarProvincia(Geo oDepartamento)
        {
            if (oDepartamento == null)
            {
                oDepartamento = new Geo();
            }

            try
            {
                ListaProvincia = Metodos.ListarProvincia(oDepartamento);
                cboProvincia.Properties.DataSource = ListaProvincia;
                cboProvincia.Properties.ValueMember = "ID";
                cboProvincia.Properties.DisplayMember = "Descripcion";
                cboProvincia.Properties.DropDownRows = ListaProvincia.Count;
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar cargar la lista de provincias.");
            }

        }
        //2022
        private void CargarDistrito(Geo oProvincia)
        {
            if (oProvincia == null)
            {
                oProvincia = new Geo();
            }

            try
            {
                ListaDistrito = Metodos.ListarDistrito(oProvincia);
                cboDistrito.Properties.DataSource = ListaDistrito;
                cboDistrito.Properties.ValueMember = "ID";
                cboDistrito.Properties.DisplayMember = "Descripcion";
                cboDistrito.Properties.DropDownRows = ListaDistrito.Count;
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar cargar la lista de distritos");
            }


        }
        //2022
        private void CargarCalle(Geo oDistrito)
        {
            if (oDistrito == null)
            {
                oDistrito = new Geo();
            }

            try
            {
                ListaCalle = Metodos.ListarCalle(oDistrito);
                cboDireccion.Properties.DataSource = ListaCalle;
                cboDireccion.Properties.ValueMember = "ID";
                cboDireccion.Properties.DisplayMember = "Descripcion";
                cboDireccion.Properties.DropDownRows = ListaCalle.Count;
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar cargar la lista de direcciones.");
            }

        }
        //2022
        private void CargarOficinaArea(Geo oDireccion)
        {
            if (oDireccion == null)
            {
                oDireccion = new Geo();
            }

            try
            {
                ListaOficinaArea = Metodos.ListarOficina(oDireccion);
                cboOficinaArea.Properties.DataSource = ListaOficinaArea;
                cboOficinaArea.Properties.ValueMember = "ID";
                cboOficinaArea.Properties.DisplayMember = "Oficina";
                cboOficinaArea.Properties.DropDownRows = ListaOficinaArea.Count;
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar cargar la lista de oficinas.");
            }

        }
        //2022
        private void CargarOpciones()
        {
            CargarDepartamento();
            if (ListaDepartamento == null || ListaDepartamento.Count == 0)
            {
                return;
            }

            if (oCasilla == null) //Crear bandeja
            {
                this.Text = "Crear bandeja.";
            }
            else //Modificar bandeja
            {
                this.Text = "Modificar bandeja.";
                txtBandeja.Text = oCasilla.sDescripcion;
                cboDepartamento.EditValue = oCasilla.IdDepartamento;
                cboProvincia.EditValue = oCasilla.IdProvincia;
                cboDistrito.EditValue = oCasilla.IdDistrito;
                cboDireccion.EditValue = oCasilla.IdCalle;
                cboOficinaArea.EditValue = oCasilla.IdGeo;
                txtBandeja.Enabled = false;

                if (oCasilla.IdTipoCasilla == 1)
                {
                    txtBandeja.Enabled = false;
                    cboDepartamento.Enabled = true;
                    cboProvincia.Enabled = true;
                    cboDistrito.Enabled = true;
                    cboDireccion.Enabled = true;
                    cboOficinaArea.Enabled = true;
                }
                else if (oCasilla.IdTipoCasilla == 4)
                {
                    txtBandeja.Enabled = true;
                    cboDepartamento.Enabled = true;
                    cboProvincia.Enabled = true;
                    cboDistrito.Enabled = true;
                    cboDireccion.Enabled = true;
                    cboOficinaArea.Enabled = true;
                }

            }
        }
        //2022
        private bool ValidarCampos()
        {
            if (txtBandeja.Text.Trim().Length == 0)
            {
                Program.mensaje("Debe ingresar el nombre de la casilla.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return true;
            }
            if (cboOficinaArea.EditValue == null)
            {
                Program.mensaje("Debe seleccionar un área de la lista.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return true;
            }
            return false;
        }
        //2022
        private void GuardarBandeja()
        {
            Casilla _casilla = new Casilla();

            if (oCasilla == null) //Nuevo
            {
                if (ValidarCampos())
                {
                    return;
                }

                _casilla.ID = 0;
                _casilla.sDescripcion = txtBandeja.Text.Trim().ToUpper();
                _casilla.IdGeo = (int)cboOficinaArea.EditValue;

                try
                {
                    int resultado = Metodos.CrearBandeja(_casilla);

                    if (resultado > 0)
                    {
                        Program.mensaje("Bandeja creada correctamente.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    }
                    else if (resultado == -2)
                    {
                        Program.mensaje("No se puede crear la bandeja.El nombre ingresado ya existe.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtBandeja.Focus();
                        txtBandeja.SelectAll();
                    }
                    else
                    {
                        Program.mensaje("Ha ocurrido un error, intente nuevamente.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (InvalidTokenException)
                {
                    Program.mensajeTokenInvalido();
                }
                catch (Exception)
                {
                    Program.mensajeError("Ha ocurrido un error al intentar crear la bandeja.");
                }

            }
            else //Modificar
            {
                if (ValidarCampos())
                {
                    return;
                }

                _casilla.ID = oCasilla.ID;
                _casilla.sDescripcion = txtBandeja.Text.Trim().ToUpper();
                _casilla.IdGeo = (int)cboOficinaArea.EditValue;
                try
                {
                    int resultado = Metodos.ModificarBandeja(_casilla);

                    if (resultado > 0)
                    {
                        Program.mensaje("Se actualizó correctamente.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    }
                    else if (resultado == -2)
                    {
                        Program.mensaje("No se puede modificar la bandeja.El nombre ingresado ya existe.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtBandeja.Focus();
                        txtBandeja.SelectAll();
                    }
                    else if (resultado == -3)
                    {
                        Program.mensaje("No se puede modificar la bandeja. El tipo de bandeja no se puede modificar.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtBandeja.Focus();
                        txtBandeja.SelectAll();
                    }
                    else
                    {
                        Program.mensaje("Ha ocurrido un error, intente nuevamente.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (InvalidTokenException)
                {
                    Program.mensajeTokenInvalido();
                }
                catch (Exception)
                {
                    Program.mensajeError("Ha ocurrido un error al intentar modificar la bandeja.");
                }

            }
        }
        #endregion

        public frmCrearModificarBandeja()
        {
            InitializeComponent();
        }

        private void frmCrearModificarBandeja_Load(object sender, EventArgs e)
        {
            CargarOpciones();
        }

        private void txtBandeja_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.mayusculas(e);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarBandeja();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboDepartamento_EditValueChanged(object sender, EventArgs e)
        {
            Geo oGeo = (Geo)cboDepartamento.GetSelectedDataRow();
            CargarProvincia(oGeo);
            CargarDistrito(null);
            CargarCalle(null);
            CargarOficinaArea(null);
        }

        private void cboProvincia_EditValueChanged(object sender, EventArgs e)
        {
            Geo oGeo = (Geo)cboProvincia.GetSelectedDataRow();
            CargarDistrito(oGeo);
            CargarCalle(null);
            CargarOficinaArea(null);
        }

        private void cboDistrito_EditValueChanged(object sender, EventArgs e)
        {
            Geo oGeo = (Geo)cboDistrito.GetSelectedDataRow();
            CargarCalle(oGeo);
            CargarOficinaArea(null);
        }

        private void cboDireccion_EditValueChanged(object sender, EventArgs e)
        {
            Geo oGeo = (Geo)cboDireccion.GetSelectedDataRow();
            CargarOficinaArea(oGeo);
        }

    }
}
