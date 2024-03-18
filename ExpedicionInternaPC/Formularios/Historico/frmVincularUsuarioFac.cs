using Interna.Entity;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ExpedicionInternaPC.Mantenimiento
{
    public partial class frmVincularUsuarioFac : DevExpress.XtraEditors.XtraForm
    {
        List<Geo> objGeo;
        int idDepartamento = 0;
        int idProvincia = 0;
        int idDistrito = 0;
        int idCalle = 0;
        int idOficina = 0;
        public int IDs = 0;
        public int idGeo = 0;
        public int opc = 0;
        public frmVincularUsuarioFac()
        {
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

            if (validador() == true)
            {
                Geo oG = (Geo)grdCalle.GetSelectedDataRow();
                try
                {
                    if (oG != null)
                    {
                        Usuario oU = new Usuario();
                        oU.ID = IDs;
                        oU.idGeo = oG.ID;

                        int res1 = 0;
                        int res2 = 0;

                        try
                        {
                            res1 = Metodos.VincularUsuarioFac(oU);
                        }
                        catch (InvalidTokenException)
                        {
                            Program.mensajeTokenInvalido();
                            return;
                        }

                        if (res1 == 0)
                        {
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            try
                            {
                                res2 = Metodos.VincularUsuarioFac(oU);
                            }
                            catch (InvalidTokenException)
                            {
                                Program.mensajeTokenInvalido();
                                return;
                            }

                            if (res2 == -3)
                            {
                                MessageBox.Show("No se puede vincular FAC a esta bandeja porque existe una Expedición."
                                                    , "Sistema Integral de Mensajería ",
                                                    MessageBoxButtons.OK,
                                                    MessageBoxIcon.Stop,
                                                    MessageBoxDefaultButton.Button1);
                                this.DialogResult = DialogResult.Cancel;
                            }
                        }

                    }
                    else
                    {
                        MessageBox.Show("No ha relacionado la calle"
                                                , "Sistema Integral de Mensajería ",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Stop,
                                                MessageBoxDefaultButton.Button1);
                    }

                }
                catch (Exception) { }
            }
            else
            {
                MessageBox.Show("Debe de ingresar los datos correctamente."
                                                , "Sistema Integral de Mensajería ",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Stop,
                                                MessageBoxDefaultButton.Button1);
                this.DialogResult = DialogResult.Cancel;
            }
        }

        public Boolean validador()
        {
            if (grdCalle.Text == string.Empty) return false;
            return true;
        }

        public void ObtenerDatos()
        {
            int op = opc;
            if (op == 1)
            {
                grdCalle.EditValue = idGeo;
                //List<Geo> objGeoItem = objGeo.FindAll(hol => (hol.ID == frmUsuario.idGeo));
                //cmbUbicacion.EditValue = objGeoItem[0].ID; // frmUsuario.idGeo;
                //cmbUbicacion.EditValue = objGeoItem[0].Descripcion;
                opc = 0;
            }
            else
            {
                grdCalle.Enabled = true;
                opc = 0;
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
                return;
            }

            cmbProvincia.ValueMember = "ID";
            cmbProvincia.DisplayMember = "Descripcion";
            grdCalle.Properties.DataSource = null;
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
            grdCalle.Properties.DataSource = null;
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
            if (idCalle != 0) grdCalle.EditValue = idCalle;

        }

        private void grdCalle_EditValueChanged(object sender, EventArgs e)
        {

            //List<Geo> oListGValidos = 
            //Metodos.ListarGeo2(frmUsuario.IDs, Program.oUsuario.IdCliente);

            //List<Geo> oListNewGeo = new List<Geo>();

            //int idCalle = int.Parse(grdCalle.EditValue.ToString());
            //List<Geo> oListG = Metodos.listarUbicacion(idCalle);
            //foreach (Geo oO in oListG) 
            //{
            //    foreach (Geo oOv in oListGValidos) 
            //    {
            //        if (oOv.ID == oO.ID) 
            //        {
            //            Geo O = new Geo();
            //            O.CopyToMe(oOv);
            //            oListNewGeo.Add(O);
            //        }                        
            //    }                    
            //}
            //grdCalle.Properties.DataSource = oListNewGeo;
            //grdCalle.Properties.DisplayMember = "Descripcion";
            //grdCalle.Properties.ValueMember = "ID";
            //if (idOficina != 0) cmbUbicacion.EditValue = idOficina;

        }
    }
}

