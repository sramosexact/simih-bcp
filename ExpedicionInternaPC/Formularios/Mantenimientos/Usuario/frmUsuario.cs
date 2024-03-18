using Interna.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Windows.Forms;

namespace ExpedicionInternaPC
{
    public partial class frmUsuario : frmChild
    {
        #region Variables
        List<Agencia> lAgenciasAsociadas;
        List<Casilla> ListaCasillaUsuario;
        List<Objeto> listaLimite = new List<Objeto>();
        List<Usuario> ListaUsuarios = new List<Usuario>();
        private string oledbCnx64 = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0;HDR=YES;IMEX=1;'";
        private string oledbCnx32 = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR=YES;IMEX=1;'";
        private string oledbCnx = "";
        public List<UsuarioIngesta> ListaUsuarioIngesta;
        #endregion

        #region Metodos
        //2022
        public override void Actualizar(string CommandName)
        {
            base.Actualizar(CommandName);
            BuscarUsuarios(txtUsuario.Text.Trim().ToUpper());
        }
        //2022
        private void RefrescarEstadoUsuario(Usuario usuario, int estado)
        {
            Usuario usu = ListaUsuarios.Find(x => x.ID == usuario.ID);
            if (usu == null)
            {
                return;
            }
            usu.iActivo = estado;
            if (estado == 1)
            {
                usu.sActivo = "ACTIVO";
            }
            else
            {
                usu.sActivo = "INACTIVO";
            }
            grdUsuario.RefreshDataSource();
        }
        //2022
        private void CargarListaBandejaAgencias(int idUsuario)
        {
            try
            {
                List<string> resultado = Metodos.ListarBandejaAsociada(idUsuario);
                ListaCasillaUsuario = Metodos.deserializarPrueba<Casilla>(resultado[0]);
                lAgenciasAsociadas = Metodos.deserializarPrueba<Agencia>(resultado[1]);
                grdBandeja.DataSource = ListaCasillaUsuario;
                grdBandeja.RefreshDataSource();
                grdAgencia.DataSource = lAgenciasAsociadas;
                grdAgencia.RefreshDataSource();
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar cargar la lista de bandejas y agencias asociadas.");
            }
        }
        //2022
        private void NuevoUsuario()
        {
            frmCrearModificarUsuario frm = new frmCrearModificarUsuario()
            {
                oUsuario = null
            };
            frm.ShowDialog(this.Parent);
            if (frm.DialogResult == DialogResult.OK)
            {
                BuscarUsuarios(frm.oUsuario.Descripcion.Trim().ToUpper());
            }
        }
        //2022
        private void ModificarUsuario()
        {
            Usuario oUsuario = (Usuario)grvUsuario.GetFocusedRow();
            if (oUsuario == null)
            {
                Program.mensaje("Debe seleccionar un registro de usuario.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            int IdTipoAcceso = Program.oUsuario.IdTipoAcceso;

            switch (IdTipoAcceso)
            {
                case (int)EnumTipoUsuario.SUPERVISOR:
                    if (oUsuario.IdTipoAcceso == (int)EnumTipoUsuario.ADMINISTRADOR || oUsuario.IdTipoAcceso == (int)EnumTipoUsuario.JEFE)
                    {
                        Program.mensaje("No tiene los privilegios suficientes para modificar el registro.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    //if (oUsuario.IdExpedicion != Program.oUsuario.IdExpedicion && oUsuario.IdExpedicion != 0)
                    //{
                    //    Program.mensaje("No puede modificar usuarios que pertenecen a otra expedición.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //    return;
                    //}
                    break;
                case (int)EnumTipoUsuario.JEFE:

                    if (oUsuario.IdTipoAcceso == (int)EnumTipoUsuario.ADMINISTRADOR)
                    {
                        Program.mensaje("No tiene los privilegios suficientes para modificar el registro.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    break;
            }

            Usuario oUsuarioSeleccionado = new Usuario();

            try
            {
                oUsuarioSeleccionado = Metodos.UsuarioSeleccionado(oUsuario)[0];
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                return;
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar obtener información del usuario seleccionado.");
                return;
            }

            frmCrearModificarUsuario frm = new frmCrearModificarUsuario();
            frm.oUsuario = oUsuarioSeleccionado;
            frm.ShowDialog(this.Parent);

            if (frm.DialogResult == DialogResult.OK)
            {
                BuscarUsuarios(oUsuario.Descripcion.Trim().ToUpper());
            }

        }
        //2022
        private void DarDeBajaUsuario(Usuario usuario)
        {
            int respuesta;

            try
            {
                respuesta = Metodos.DarDeBajaUsuario(usuario);
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                return;
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar dar de baja al usuario.");
                return;
            }

            switch (respuesta)
            {
                case 1:
                    Program.mensaje(String.Format("Se ha desactivado correctamente el usuario {0}", usuario.Descripcion), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefrescarEstadoUsuario(usuario, 0);
                    break;
                case -1:
                    Program.mensaje(String.Format("No existe el usuario {0} en el sistema.", usuario.Descripcion), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case -2:
                    Program.mensaje(String.Format("Hubo un error en la transacción. Inténtelo nuevamente más tarde."), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }
        //2022
        private void DarDeAltaUsuario(Usuario usuario)
        {
            int respuesta;

            try
            {
                respuesta = Metodos.DarDeAltaUsuario(usuario);
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                return;
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar dar de alta al usuario seleccionado.");
                return;
            }

            switch (respuesta)
            {
                case 1:
                    Program.mensaje(String.Format("Se ha activado correctamente el usuario {0}", usuario.Descripcion), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefrescarEstadoUsuario(usuario, 1);
                    break;
                case -1:
                    Program.mensaje(String.Format("No existe el usuario {0} en el sistema.", usuario.Descripcion), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case -2:
                    Program.mensaje(String.Format("Hubo un error en la transacción. Inténtelo nuevamente más tarde."), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }
        //2022
        private void CambiarEstadoUsuario(Usuario usuario)
        {

            int IdTipoAcceso = Program.oUsuario.IdTipoAcceso;

            switch (IdTipoAcceso)
            {
                case 43:
                    if (usuario.IdTipoAcceso == 43 || usuario.IdTipoAcceso == 44 || usuario.IdTipoAcceso == 80)
                    {
                        Program.mensaje("No tiene los privilegios suficientes para modificar el registro.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    //if (usuario.IdExpedicion != Program.oUsuario.IdExpedicion || usuario.IdExpedicion == 0)
                    //{
                    //    Program.mensaje("No puede modificar usuarios que pertenecen a otra expedición.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //    return;
                    //}
                    break;
                case 80:

                    if (usuario.IdTipoAcceso == 44 || usuario.IdTipoAcceso == 80)
                    {
                        Program.mensaje("No tiene los privilegios suficientes para modificar el registro.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    break;
            }

            if (usuario.sActivo == "ACTIVO")
            {
                if (Program.mensaje(String.Format("Se desactivará el usuario {0}. ¿Desea continuar?", usuario.Descripcion), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DarDeBajaUsuario(usuario);
                }
            }
            else
            {
                if (Program.mensaje(String.Format("Se activará el usuario {0}. ¿Desea continuar?", usuario.Descripcion), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DarDeAltaUsuario(usuario);
                }
            }
        }
        //2022
        private void VincularBandeja()
        {
            frmAsociarUsuarioBandeja frm = new frmAsociarUsuarioBandeja();
            frm.oUsuario = (Usuario)grvUsuario.GetFocusedRow();

            if (frm.oUsuario == null)
            {
                Program.mensaje("Seleccione algún usuario de la lista.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (frm.oUsuario.sActivo == "INACTIVO")
            {
                Program.mensaje("No puedes vincular bandejas a usuarios inactivos.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            //if (frm.oUsuario.IdTipoAcceso != 41)
            //{
            //    Program.mensaje("No puedes vincular bandejas a usuarios Exact.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return;
            //}

            frm.ShowDialog(this.Parent);
            grdUsuario.RefreshDataSource();

        }
        //2022
        public void ManejarEventoVincularAgencia()
        {
            Usuario oUsuario = (Usuario)grvUsuario.GetFocusedRow();

            if (oUsuario == null)
            {
                Program.mensaje("Seleccione algún usuario de la lista.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (oUsuario.sActivo == "INACTIVO")
            {
                Program.mensaje("No puedes vincular agencias a usuarios inactivos.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            //if (oUsuario.IdTipoAcceso != 41)
            //{
            //    Program.mensaje("No puedes vincular agencias a usuarios Exact.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return;
            //}

            int respuesta;
            try
            {
                respuesta = Metodos.VerificarSiUsuarioEsDeAgencia(oUsuario);
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                return;
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar verificar si el usuario es de agencia.");
                return;
            }

            switch (respuesta)
            {
                case 1:
                    frmAsociarEncargadoAgencia frm = new frmAsociarEncargadoAgencia();
                    frm.oUsuario = oUsuario;
                    frm.ShowDialog(this.Parent);
                    grdUsuario.RefreshDataSource();
                    break;
                case -1:
                    Program.mensaje(String.Format("El usuario {0} no es de agencia. No se puede vincular.", oUsuario.sCodigo), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    break;
                case -2:
                    Program.mensaje(String.Format("El usuario {0} no está activo o no existe.", oUsuario.sCodigo), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    break;
                default:
                    Program.mensaje(String.Format("Hubo un problema en la conexión, inténtelo nuevamente más tarde."), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    break;
            }
        }
        //2022
        public void SeleccionarUsuario(Usuario oUsuario)
        {
            BuscarUsuarios(oUsuario.Descripcion);
            for (int i = 0; i < grvUsuario.RowCount; i++)
            {
                int rowHandle = grvUsuario.GetVisibleRowHandle(i);
                if (((Usuario)grvUsuario.GetRow(rowHandle)).ID == oUsuario.ID)
                {
                    grvUsuario.FocusedRowHandle = rowHandle;
                    break;
                }
            }
        }
        //2022
        public void BuscarUsuarios(string texto)
        {
            string usuario = texto.Trim().ToUpper();

            if (texto.Length <= 2)
            {
                Program.mensaje("Debe ingresar al menos 3 caracteres para realizar una búsqueda.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                ListaUsuarios = Metodos.BuscarUsuarios(usuario);
                grdUsuario.DataSource = new List<Usuario>();
                grdUsuario.DataSource = ListaUsuarios;
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar obtener resultados de la búsqueda.");
            }

        }
        //2022
        private void BuscarArchivo()
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Seleccionar archivo";
            op.Filter = "Todos los archivos Excel (*.xlsx)|*.xlsx|Todos los archivos Excel 2003 (*.xls)|*.xls";
            op.Multiselect = false;
            op.InitialDirectory = "C:\\";

            if (op.ShowDialog() == DialogResult.OK)
            {
                txtArchivoDatos.Text = op.FileName;

            }
        }
        //2022
        public void ObtenerDatosArchivo()
        {
            if (txtArchivoDatos.Text.Trim().Length == 0)
            {
                MessageBox.Show("Debe elegir una archivo para realizar la carga", Program.titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string fileExcel = txtArchivoDatos.Text;
            string stringCnx = string.Format(oledbCnx, fileExcel);
            string sheetName = "USUARIOS";
            string query = $"SELECT * FROM [{sheetName}$]";

            OleDbConnection ConnectToExcel = new OleDbConnection(stringCnx);

            if (!existeHojaExcel(sheetName, stringCnx))
            {
                Program.mensaje("No se encuentra la hoja con el nombre USUARIOS.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            OleDbCommand excelcmd = new OleDbCommand(query, ConnectToExcel);
            OleDbDataAdapter da = new OleDbDataAdapter(excelcmd);
            System.Data.DataTable dt = new System.Data.DataTable();

            try
            {
                da.Fill(dt);
            }
            catch (OleDbException ex)
            {
                Program.mensajeError("Ha ocurrido un error al intentar acceder al origen de datos.");

                return;
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar extraer los datos del archivo.");
            }


            ListaUsuarioIngesta = new List<UsuarioIngesta>();

            foreach (DataRow dr in dt.Rows)
            {
                if (dr[0] == null || dr[2] == null) break;

                UsuarioIngesta usuarioIngesta = new UsuarioIngesta();

                usuarioIngesta.Matricula = dr[0].ToString().Trim().ToUpper();
                usuarioIngesta.ApellidoPaterno = dr[1].ToString().Trim().ToUpper();
                usuarioIngesta.ApellidoMaterno = dr[2].ToString().Trim().ToUpper();
                usuarioIngesta.Nombres = dr[3].ToString().Trim().ToUpper();
                usuarioIngesta.Dni = dr[4].ToString().Trim().ToUpper();
                usuarioIngesta.Ubicacion = dr[5].ToString().Trim().ToUpper();
                usuarioIngesta.UnidadOrganizativa = dr[6].ToString().Trim().ToUpper();
                usuarioIngesta.CodigoAgencia = dr[7].ToString().Trim().ToUpper();
                usuarioIngesta.Sede = dr[8].ToString().Trim().ToUpper();
                usuarioIngesta.Correo = dr[9].ToString().Trim().ToUpper();

                ListaUsuarioIngesta.Add(usuarioIngesta);

            }

            if (ListaUsuarioIngesta.Count == 0)
            {
                MessageBox.Show("No se encontraron datos en las posiciones señaladas de la plantilla elegida.", Program.titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

        }
        //2022
        private bool existeHojaExcel(string sheetName, string cnx)
        {
            bool existe = false;
            OleDbConnection cn = new OleDbConnection(cnx);
            System.Data.DataTable dt = null;
            try
            {
                cn.Open();
                dt = cn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                if (dt == null) return false;

                foreach (DataRow row in dt.Rows)
                {
                    if (row["TABLE_NAME"].ToString().Equals($"{sheetName}$"))
                    {
                        existe = true;
                        break;
                    }
                }

            }
            catch (Exception ex)
            {
                existe = false;
            }
            finally
            {

                if (cn != null)
                {
                    cn.Close();
                    cn.Dispose();
                }
                if (dt != null)
                {
                    dt.Dispose();
                }
            }

            return existe;
        }
        //2022
        private void CargarRegistros()
        {
            if (ListaUsuarioIngesta == null || ListaUsuarioIngesta.Count == 0)
            {
                Program.mensaje("No hay elementos para cargar al sistema.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //int grupos = 10;

            //for (int i = 0; ListaUsuarioIngesta)

            UsuarioIngesta u = new UsuarioIngesta();
            string jsonUsuarioIngesta = JsonConvert.SerializeObject(ListaUsuarioIngesta);
            //prueba(jsonUsuarioIngesta);
            try
            {
                Program.ShowPopWaitScreen();
                string resultado = Metodos.IngestaUsuario(jsonUsuarioIngesta);

                if (resultado != null && resultado.All(char.IsNumber) && int.Parse(resultado) == 1)
                {
                    Program.mensaje("Archivo procesado correctamente.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Program.mensajeError("Ha ocurrido un error al intentar procesar el archivo.");
                }

            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception ex)
            {
                Program.mensajeError(ex.Message);
            }
            finally
            {
                Program.HidePopWaitScreen();
            }


        }
        void prueba(string json)
        {
            UsuarioIngesta u = new UsuarioIngesta();
            u.IngestaUsuario(json);
        }
        #endregion

        public frmUsuario()
        {
            InitializeComponent();
        }

        private void frmUsuarioBandeja_Load(object sender, EventArgs e)
        {
            if (Environment.Is64BitProcess) oledbCnx = oledbCnx64;
            else oledbCnx = oledbCnx32;
        }

        private void grvUsuario_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            Usuario oUsuario = (Usuario)grvUsuario.GetFocusedRow();
            if (oUsuario == null) return;
            CargarListaBandejaAgencias(oUsuario.ID);
        }

        #region Nav-Usuario

        private void btnNuevoUsuario_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            NuevoUsuario();
        }

        private void btnModificarUsuario_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ModificarUsuario();
        }

        private void btnEliminarUsuario_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Usuario oUsuario = (Usuario)grvUsuario.GetFocusedRow();
            if (oUsuario == null)
            {
                Program.mensaje("Debe seleccionar un registro de usuario.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            CambiarEstadoUsuario(oUsuario);
        }

        #endregion

        #region Nav-Bandeja

        private void btnVincularBandeja_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            VincularBandeja();
        }

        #endregion

        #region Nav-FAC

        private void btnVincularFac_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ManejarEventoVincularAgencia();
        }

        #endregion

        private void frmUsuarioBandeja_Activated(object sender, EventArgs e)
        {
            frmMain oM = (frmMain)this.MdiParent;
            if (oM == null) return;
            if (Program.oUsuario.IdTipoAcceso == 43) oM.subMostrarSupervision(true);
            if (Program.oUsuario.IdTipoAcceso == 80) oM.subMostrarJefatura(true);
        }

        private void frmUsuarioBandeja_Deactivate(object sender, EventArgs e)
        {
            frmMain oM = (frmMain)this.MdiParent;
            if (oM == null) return;
            if (Program.oUsuario.IdTipoAcceso == 43) oM.subMostrarSupervision(false);
            if (Program.oUsuario.IdTipoAcceso == 80) oM.subMostrarJefatura(false);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarUsuarios(txtUsuario.Text.Trim().ToUpper());
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BuscarUsuarios(txtUsuario.Text.Trim().ToUpper());
            }
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.alfanumericosAndSpace(e);
            Program.mayusculas(e);
        }

        private void btnBuscarArchivo_Click(object sender, EventArgs e)
        {
            BuscarArchivo();
            ObtenerDatosArchivo();
        }

        private void btnCargarUsuarios_Click(object sender, EventArgs e)
        {

            CargarRegistros();
        }
    }
}
