using Interna.Entity;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ExpedicionInternaPC
{
    public partial class frmNuevaCasilla : Form
    {
        List<Geo> objGeo;
        int idDepartamento = 0;
        int idProvincia = 0;
        int idDistrito = 0;
        int idCalle = 0;
        int idOficina = 0;
        Geo oG;

        public int opc = 0;
        public string casilla = "";
        public string alias = "";
        public int idGeo = 0;
        public int idCasilla = 0;
        public int IDs = 0;

        public frmNuevaCasilla()
        {
            InitializeComponent();
        }

        public frmNuevaCasilla(Geo oG)
        {
            this.oG = oG;
            InitializeComponent();
        }

        private void NuevaCasilla_Load(object sender, EventArgs e)
        {
            try
            {
                cmbDepartamento.DataSource = Metodos.listarUbicacion(1);
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                return;
            }

            cmbDepartamento.ValueMember = "ID";
            cmbDepartamento.DisplayMember = "Descripcion";

            ObtenerDatos();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            int op = opc;

            if (op == 1)
            //if (simpleButton1.Text == "Actualizar Alias")
            {
                Usuario oUw = new Usuario();
                oUw.idCasilla = idCasilla;
                oUw.alias = txtAlias.Text;
                oUw.Descripcion = txtCasilla.Text;

                int i = 0;
                //1-Actualizar Alias
                //2-Actualizar Oficina

                try
                {
                    i = Metodos.ActualizarCasilla(oUw, 1, 0);
                }
                catch (InvalidTokenException)
                {
                    Program.mensajeTokenInvalido();
                    return;
                }

                if (i == 1)
                    MessageBox.Show("Se actualizo la Bandeja.", Program.titulo,
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Information,
                              MessageBoxDefaultButton.Button1);
                this.DialogResult = DialogResult.OK;
            }
            else

            if (op == 2)
            {
                Usuario oUw = new Usuario();
                oUw.idCasilla = idCasilla;
                oUw.alias = txtAlias.Text;
                oUw.Descripcion = txtCasilla.Text;

                String calle = grdCalle.Text;
                String oficina = cmbUbicacion.Text;

                if (calle == "" || oficina == "")
                {
                    MessageBox.Show("No ha seleccionado un punto de entrega valido", Program.titulo,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information,
                                MessageBoxDefaultButton.Button1);
                    this.DialogResult = DialogResult.OK;
                    return;
                }
                Geo oG = new Geo();
                oG.IdOficina = int.Parse(cmbUbicacion.EditValue.ToString());

                int i = 0, j = 0;

                try
                {
                    i = Metodos.ActualizarCasilla(oUw, 2, oG.IdOficina);
                }
                catch (InvalidTokenException)
                {
                    Program.mensajeTokenInvalido();
                    return;
                }

                if (i == 1)
                {

                    MessageBox.Show("Se actualizo la bandeja.", Program.titulo,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information,
                                MessageBoxDefaultButton.Button1);
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("No se puede cambiar el punto de entrega de la bandeja. Tiene documentos en custodia o se encuentran en ruta dentro de una entrega.", Program.titulo,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information,
                                MessageBoxDefaultButton.Button1);
                    this.DialogResult = DialogResult.OK;

                }
            }
            else
            {

                if (validador() == true)
                {
                    Geo oG = (Geo)cmbUbicacion.GetSelectedDataRow();
                    try
                    {
                        Usuario oU = new Usuario();
                        oU.idCasilla = 0;
                        oU.ID = IDs;
                        oU.Cas = txtCasilla.Text;
                        oU.idGeo = oG.ID;
                        oU.alias = txtAlias.Text;
                        int res = 0;

                        try
                        {
                            res = Metodos.GrabarCasilla(oU);
                        }
                        catch (InvalidTokenException)
                        {
                            Program.mensajeTokenInvalido();
                            return;
                        }

                        if (res == 1)
                        {
                            MessageBox.Show("Bandeja ya existe."
                                                , Program.titulo,
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Stop,
                                                MessageBoxDefaultButton.Button1);
                        }
                        if (res == 0)
                        {
                            MessageBox.Show("Operacion con exito."
                                                    , Program.titulo,
                                                    MessageBoxButtons.OK,
                                                    MessageBoxIcon.Information,
                                                    MessageBoxDefaultButton.Button1);
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                    catch (Exception) { }
                }
                else
                {
                    MessageBox.Show("Debe de ingresar los datos correctamente."
                                                    , Program.titulo,
                                                    MessageBoxButtons.OK,
                                                    MessageBoxIcon.Stop,
                                                    MessageBoxDefaultButton.Button1);
                }
            }
        }

        public Boolean validador()
        {
            if (txtCasilla.Text.Length == 0) return false;
            if (cmbUbicacion.Text == string.Empty) return false;
            return true;
        }

        public void ObtenerDatos()
        {
            int op = opc;

            Geo g;

            txtCasilla.Text = casilla;
            txtAlias.Text = alias;

            cmbDepartamento.SelectedValue = oG.IdDepartamento;
            cmbProvincia.SelectedValue = oG.IdProvincia;
            cmbDistrito.SelectedValue = oG.IdDistrito;
            grdCalle.EditValue = oG.IdCalle;
            cmbUbicacion.EditValue = oG.IdOficina;

            if (op == 1)
            {
                simpleButton1.Text = "Actualizar Alias";
                //simpleButton1.Text = "Actualizar datos de bandeja";
                txtCasilla.Text = casilla;
                txtAlias.Text = alias;

                cmbDepartamento.Enabled = false;
                cmbProvincia.Enabled = false;
                cmbDistrito.Enabled = false;
                grdCalle.Enabled = false;
                cmbUbicacion.Enabled = false;
                txtCasilla.Enabled = false;

                if (alias == "Asignar") txtAlias.Text = "";
                //opc = 0;
            }
            else if (op == 2)
            {
                simpleButton1.Text = "Actualizar datos de bandeja";
                txtCasilla.Text = casilla;
                txtAlias.Text = alias;
                txtAlias.Enabled = true;

                //opc = 0;
            }
            else
            {
                txtCasilla.Enabled = true;
                cmbUbicacion.Enabled = true;

                //opc = 0;
                simpleButton1.Text = "Asignar Bandeja";
            }
        }

        private void cmbDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idDep = int.Parse(cmbDepartamento.SelectedValue.ToString());

            try
            {
                cmbProvincia.DataSource = Metodos.listarUbicacion(idDep);
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }

            cmbProvincia.ValueMember = "ID";
            cmbProvincia.DisplayMember = "Descripcion";
            cmbUbicacion.Properties.DataSource = null;

            if (idProvincia != 0) cmbProvincia.SelectedValue = idProvincia;
        }

        private void cmbProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idPro = int.Parse(cmbProvincia.SelectedValue.ToString());

            try
            {
                cmbDistrito.DataSource = Metodos.listarUbicacion(idPro);
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                return;
            }

            cmbDistrito.ValueMember = "ID";
            cmbDistrito.DisplayMember = "Descripcion";
            cmbUbicacion.Properties.DataSource = null;

            if (idDistrito != 0) cmbDistrito.SelectedValue = idDistrito;
        }

        private void cmbDistrito_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idDis = int.Parse(this.cmbDistrito.SelectedValue.ToString());

            try
            {
                grdCalle.Properties.DataSource = Metodos.listarUbicacion(idDis);
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                return;
            }

            grdCalle.Properties.DisplayMember = "Descripcion";
            grdCalle.Properties.ValueMember = "ID";
            cmbUbicacion.Properties.DataSource = null;

            if (idCalle != 0) grdCalle.EditValue = idCalle;
        }

        private void grdCalle_EditValueChanged(object sender, EventArgs e)
        {
            int idCalle = int.Parse(grdCalle.EditValue.ToString());

            try
            {
                cmbUbicacion.Properties.DataSource = Metodos.listarUbicacion(idCalle);
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                return;
            }
            cmbUbicacion.Properties.DisplayMember = "Descripcion";
            cmbUbicacion.Properties.ValueMember = "ID";
            if (idOficina != 0) cmbUbicacion.EditValue = idOficina;
        }

        public void cargarBandeja(Usuario oU)
        {
            txtCasilla.Text = oU.descripcionCasilla;
        }
    }
}
