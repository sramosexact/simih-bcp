using ExpedicionInternaPC.Enumeracion;
using Interna.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ExpedicionInternaPC.Formularios.Expedicion
{
    public partial class frmNuevaEntregaAgencias : frmChild
    {

        #region Variables

        private List<AgenciaLote> lAgencias = new List<AgenciaLote>();
        public Entrega oe;
        public EntregaEstado iEstado;
        private byte tamCodAgencia = 6;
        public List<Entrega> lEntregasYaCreadas = new List<Entrega>();
        private List<AgenciaLote> lAgenciasParaCrear = new List<AgenciaLote>();
        private int iTipoAgencia = 0;


        #endregion

        #region Metodos

        //2022
        private void CargarColaboradores()
        {
            try
            {
                List<Usuario> lUsuario = Metodos.ListarColaboradoresExpedicion();
                cboColaborador.Properties.DataSource = lUsuario;
                cboColaborador.Properties.DisplayMember = "Descripcion";
                cboColaborador.Properties.ValueMember = "ID";
                cboColaborador.Properties.DropDownRows = lUsuario.Count;
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                return;
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar cargar la lista de colaboradores.");
                return;
            }

        }
        //2022
        private void CargarGrupoPalomar()
        {
            try
            {
                List<Palomar> lPalomar = Metodos.ListarPalomaresAgencia();
                cboPalomar.Properties.DataSource = lPalomar;
                cboPalomar.Properties.DisplayMember = "Descripcion";
                cboPalomar.Properties.ValueMember = "ID";
                cboPalomar.Properties.DropDownRows = lPalomar.Count;
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar cargar la lista de palomares");
                return;
            }

        }
        //2022
        private void listarTurnos()
        {
            try
            {
                List<Turno> lTurnos = Metodos.ListarTurnos();
                cboTurno.Properties.DataSource = lTurnos;
                cboTurno.Properties.DisplayMember = "sDescripcionTurno";
                cboTurno.Properties.ValueMember = "iIdTurno";
                cboTurno.Properties.DropDownRows = lTurnos.Count;
                cboTurno.EditValue = null;
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                return;
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar cargar la lista de turnos");
                return;
            }

        }
        //2022
        private void cargarFormulario()
        {
            if (Program.oUsuario.IdTipoExpedicion == 2)
            {
                iTipoAgencia = (int)TipoPalomarDestino.AGENCIAS_LIMA;
            }
            else if (Program.oUsuario.IdTipoExpedicion == 3)
            {
                iTipoAgencia = (int)TipoPalomarDestino.AGENCIAS_PROVINCIA;
            }

            CargarColaboradores();
            CargarGrupoPalomar();
            listarTurnos();
        }
        //2022
        private void CargarDestino()
        {
            if (cboPalomar.EditValue != null && cboTurno.EditValue != null)
            {
                try
                {
                    lAgencias = Metodos.ListarAgenciasPalomarTurno((Turno)cboTurno.GetSelectedDataRow(), (Palomar)cboPalomar.GetSelectedDataRow());
                }
                catch (InvalidTokenException)
                {
                    Program.mensajeTokenInvalido();
                }
                catch (Exception)
                {
                    Program.mensajeError("Ha ocurrido un error al intentar cargar la lista de agencias.");
                    return;
                }

            }
            else
            {
                lAgencias = new List<AgenciaLote>();
            }
            grdAgencia.DataSource = lAgencias;
        }
        //2022
        private void agregarAgencia()
        {
            if (lAgencias.Find(x => x.sCodigoAgencia == txtAgencia.Text.Trim()) == null)
            {
                try
                {
                    Agencia oAgencia = Metodos.ObtenerAgenciaPorCodigo(txtAgencia.Text.Trim());
                    if (oAgencia != null)
                    {

                        if (oAgencia.iTipo != iTipoAgencia)
                        {
                            Program.mensaje("El código de agencia ingresado no corresponde a la Expedición actual.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.Activate();
                            txtAgencia.Focus();
                            txtAgencia.SelectAll();
                            return;
                        }
                        AgenciaLote agenciaLote = new AgenciaLote();
                        agenciaLote.sCodigoAgencia = oAgencia.sCodigoAgencia;
                        agenciaLote.sDescripcion = oAgencia.sDescripcion;


                        lAgencias.Add(agenciaLote);
                        grdAgencia.RefreshDataSource();
                        grvAgencia.RefreshData();

                    }
                    else
                    {
                        Program.mensaje("No se encontró agencia, verifique el código ingresado.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtAgencia.SelectionStart = 0;
                        txtAgencia.SelectionLength = txtAgencia.Text.Length;
                        txtAgencia.Focus();
                    }
                }
                catch (InvalidTokenException)
                {
                    Program.mensajeTokenInvalido();
                    return;
                }
                catch (Exception)
                {
                    Program.mensajeError("Ha ocurrido un error al intentar obtener la agencia.");
                    return;
                }

            }
            else
            {
                Program.mensaje("La Agencia ya se encuentra en la lista.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtAgencia.SelectionStart = 0;
                txtAgencia.SelectionLength = txtAgencia.Text.Length;
                txtAgencia.Focus();
            }
        }
        //2022
        private void quitarAgencia()
        {
            lAgencias.Remove((AgenciaLote)grvAgencia.GetFocusedRow());
            grdAgencia.RefreshDataSource();
            grvAgencia.RefreshData();
        }
        //2022
        private void cancelar()
        {
            this.Close();
        }
        //2022
        private void crearEnviosAgencias()
        {
            if (lAgencias.Count > 0)
            {
                if (cboColaborador.EditValue == null)
                {
                    Program.mensaje("Debe elegir un colaborador de la lista.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Activate();
                    cboColaborador.Focus();
                    return;
                }
                lAgenciasParaCrear.Clear();
                lAgenciasParaCrear = lAgencias.ToList();

                Agencia oAgencia = new Agencia();
                string xmlLote = "";
                int resultado = 0;
                xmlLote = oAgencia.SerializeObjectWindows(lAgenciasParaCrear);
                try
                {
                    resultado = Metodos.CrearEnvioAgencias(xmlLote, (Usuario)cboColaborador.GetSelectedDataRow(), Program.oUsuario.ID);

                    if (resultado > 0)
                    {
                        this.DialogResult = System.Windows.Forms.DialogResult.Yes;
                        Program.mensaje(string.Format("Se ha creado un nuevo lote con {0} elemento(s).", resultado), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else if (resultado == 0)
                    {
                        Program.mensaje("No existen documentos en custodia para los destinos elegidos que no esten asignados a una entrega.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Activate();
                    }
                    else
                    {
                        Program.mensaje("Ocurrió un problema. Revise su conexión a la red.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Activate();
                    }
                }
                catch (InvalidTokenException)
                {
                    Program.mensajeTokenInvalido();
                    return;
                }
                catch (Exception)
                {
                    Program.mensajeError("Ha ocurrido un error al intentar crear un lote.");
                    return;
                }

            }
            else
            {
                Program.mensaje("Agregue agencias a la lista para crear la entrega.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Activate();
            }

        }

        #endregion


        public frmNuevaEntregaAgencias()
        {
            InitializeComponent();
        }

        private void frmNuevaEntregaAgencias_Load(object sender, EventArgs e)
        {
            cargarFormulario();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            crearEnviosAgencias();
        }

        private void cboTurno_EditValueChanged(object sender, EventArgs e)
        {
            CargarDestino();
        }

        private void txtAgencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.soloNumeros(e);
        }

        private void txtAgencia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtAgencia.Text.Length == 0)
                {
                    return;
                }
                if (txtAgencia.Text.Length == tamCodAgencia)
                {
                    agregarAgencia();
                }
                else
                {
                    Program.mensaje("No se encontró agencia, verifique el código ingresado.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtAgencia.SelectionStart = 0;
                    txtAgencia.SelectionLength = txtAgencia.Text.Length;
                    txtAgencia.Focus();
                }

            }
        }

        private void repositoryItemHyperLinkEdit1_Click(object sender, EventArgs e)
        {
            quitarAgencia();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtAgencia.Text.Length == 0)
            {
                Program.mensaje("Ingrese el código de la agencia que desea agregar.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAgencia.Focus();
                return;
            }
            if (txtAgencia.Text.Length == tamCodAgencia)
            {
                agregarAgencia();
            }
            else
            {
                Program.mensaje("No se encontró agencia, verifique el código ingresado.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAgencia.SelectionStart = 0;
                txtAgencia.SelectionLength = txtAgencia.Text.Length;
                txtAgencia.Focus();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            cancelar();
        }

        private void cboPalomar_EditValueChanged(object sender, EventArgs e)
        {
            CargarDestino();
        }
    }
}
