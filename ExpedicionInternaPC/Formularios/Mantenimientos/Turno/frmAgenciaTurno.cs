using Interna.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ExpedicionInternaPC
{
    public partial class frmAgenciaTurno : frmChild
    {

        #region Variables
        List<Agencia> ListaAgenciasNoVinculadas;
        #endregion

        #region Metodos

        private void ListarTurnos()
        {
            try
            {
                List<Turno> lTurnos = Metodos.ListarTurnos();
                lTurnos.Remove(lTurnos.Find(x => x.iIdTurno == 1));
                cboTurno.Properties.DataSource = lTurnos;
                cboTurno.Properties.DisplayMember = "sDescripcionTurno";
                cboTurno.Properties.ValueMember = "iIdTurno";
                cboTurno.Properties.DropDownRows = lTurnos.Count;
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar cargar la lista de turnos.");
            }

        }

        private void ListarAgenciasNoVinculadas()
        {
            Turno oTurno = (Turno)cboTurno.GetSelectedDataRow();


            if (oTurno != null)
            {
                try
                {
                    ListaAgenciasNoVinculadas = Metodos.ListarAgenciasNoVinculadasTurno(oTurno);
                }
                catch (InvalidTokenException)
                {
                    Program.mensajeTokenInvalido();
                    return;
                }
                catch (Exception)
                {
                    Program.mensajeError("Ha ocurrido un error al intentar cargar la lista de agencias no vinculadas.");
                    return;
                }

            }
            else
            {
                ListaAgenciasNoVinculadas = new List<Agencia>();
            }

            grdAgencia.DataSource = ListaAgenciasNoVinculadas;

        }

        private void ListarAgenciasVinculadas()
        {
            List<Agencia> ListaAgenciasVinculadas = new List<Agencia>();
            try
            {
                ListaAgenciasVinculadas = Metodos.ListarAgenciasVinculadasTurno();
                grdAgenciaTurno.DataSource = ListaAgenciasVinculadas;
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar cargar la lista de agencias vinculadas.");
                return;
            }

        }

        private void AsociarAgenciaTurno()
        {
            List<Agencia> ListaAgenciasSeleccionadas = new List<Agencia>();
            ListaAgenciasSeleccionadas = ListaAgenciasNoVinculadas.FindAll(x => x.SeleccionGrafica == true).ToList();

            if (ListaAgenciasSeleccionadas.Count > 0)
            {
                Agencia oAgencia = new Agencia();
                oAgencia.sDescripcion = oAgencia.SerializeObjectWindows(ListaAgenciasSeleccionadas);
                oAgencia.IdTurno = int.Parse(cboTurno.EditValue.ToString());
                int res;

                try
                {
                    res = Metodos.VincularAgenciaTurno(oAgencia);
                }
                catch (InvalidTokenException)
                {
                    Program.mensajeTokenInvalido();
                    return;
                }
                catch (Exception)
                {
                    Program.mensajeError("Ha ocurrido un error al intentar vincular el turno a las agencias.");
                    return;
                }

                if (res == 1)
                {
                    Program.mensaje("Las agencias seleccionadas se vincularon al turno elegido de forma correcta.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboTurno.EditValue = null;
                    ListarAgenciasNoVinculadas();
                    ListarAgenciasVinculadas();

                }
                else
                {
                    Program.mensaje("Error de red. Vuelva a intentarlo.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                Program.mensaje("Debe seleccionar una agencia de la lista.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
        #endregion

        public frmAgenciaTurno()
        {
            InitializeComponent();
        }

        private void frmAgenciaTurno_Load(object sender, EventArgs e)
        {
            ListarTurnos();
            ListarAgenciasVinculadas();
        }

        private void cboTurno_EditValueChanged(object sender, EventArgs e)
        {
            ListarAgenciasNoVinculadas();
        }

        private void btnAsociar_Click(object sender, EventArgs e)
        {
            AsociarAgenciaTurno();
        }

        private void grvAgencia_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (grvAgencia.FocusedColumn.FieldName != "SeleccionGrafica")
                {
                    return;

                }

                Agencia obj = (Agencia)grvAgencia.GetFocusedRow();

                if (obj != null)
                {

                    Agencia oe = ListaAgenciasNoVinculadas.Find(x => x.iId == obj.iId);


                    if (oe != null)
                    {
                        if (oe.SeleccionGrafica == true)
                        {
                            oe.SeleccionGrafica = false;

                        }
                        else
                        {
                            obj.SeleccionGrafica = true;

                        }
                    }

                    grdAgencia.Refresh();
                    grvAgencia.RefreshData();

                }
            }
            catch
            {
                return;
            }
        }

        private void repositoryItemHyperLinkEdit1_Click(object sender, EventArgs e)
        {


            Agencia obj = (Agencia)grvAgenciaTurno.GetFocusedRow();

            if (obj.IdTurno == 1)
            {
                Program.mensaje("No se puede eliminar la relación entre una agencia y el turno 'Todos'.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                if (Program.mensaje(string.Format("¿Desea eliminar la relación entre la agencia {0} y el turno {1}?", obj.sDescripcion, obj.sTurno), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        if (Metodos.EliminarVinculoAgenciaTurno(obj) == 1)
                        {
                            Program.mensaje("Operación realizada con éxito.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ListarAgenciasVinculadas();
                        }
                        else
                        {
                            Program.mensaje("Error de red. Vuelva a intentarlo nuevamente.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (InvalidTokenException)
                    {
                        Program.mensajeTokenInvalido();
                    }
                    catch (Exception)
                    {
                        Program.mensajeError("Ha ocurrido un error al intentar eliminar la relación entre agencia y turno.");
                    }

                }
            }
        }
    }
}

