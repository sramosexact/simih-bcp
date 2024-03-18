using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Interna.Entity;

namespace ExpedicionInternaPC
{
    public partial class frmListaUsuario : frmChild
    {
        #region Variables

        
        #endregion

        #region Metodos
        private void ListarUsuarios()
        {
            List<Usuario> lUsuario = new List<Usuario>();
            lUsuario = Metodos.ListarUsuarios();
            grdUsuario.DataSource = lUsuario;
        }

        private void NuevoUsuario()
        {
            frmCrearModificarUsuario frm = new frmCrearModificarUsuario();
            frm.oUsuario = null;
            frm.ShowDialog(this.Parent);
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                ListarUsuarios();
            }
        }

        private void ModificarUsuario()
        {
            Usuario oUsuario = (Usuario)grvUsuario.GetFocusedRow();
            if (oUsuario == null)
            {
                Program.mensaje("Debe seleccionar un registro de usuario.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            frmCrearModificarUsuario frm = new frmCrearModificarUsuario();
            frm.oUsuario = oUsuario;
            frm.ShowDialog(this.Parent);

            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                ListarUsuarios();
            }
        }

        private void EliminarUsuario()
        {
            Usuario oUsuario = (Usuario)grvUsuario.GetFocusedRow();
            if (oUsuario == null)
            {
                Program.mensaje("Debe seleccionar un registro de usuario.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            ////// completar
        }
        #endregion

        public frmListaUsuario()
        {
            InitializeComponent();
        }

        private void frmListaUsuario_Load(object sender, EventArgs e)
        {
            ListarUsuarios();
        }

        private void frmListaUsuario_Activated(object sender, EventArgs e)
        {
            frmMain frmPadre = this.MdiParent as frmMain;
            frmPadre.subMostrarJefatura(true);
        }

        private void frmListaUsuario_Deactivate(object sender, EventArgs e)
        {

            frmMain frmPadre = this.MdiParent as frmMain;
            frmPadre.subMostrarJefatura(false);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            NuevoUsuario();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ModificarUsuario();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarUsuario();
        }
    }
}
