using Interna.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ExpedicionInternaPC
{
    public partial class frmNuevaEntregaPisos : frmChild
    {
        #region Variables

        int tipo;
        public Entrega En;
        private List<Palomar> listaPalomar;
        private List<Palomar> listaPalomaresSeleccionados = new List<Palomar>();
        private List<Palomar> listaPalomaresBase = new List<Palomar>();

        #endregion

        #region Metodos

        //2022
        private void llenarCboGrupoPalomares()
        {
            List<Palomar> dt = new List<Palomar>();
            try
            {
                dt = Metodos.rListaPalomarGrupoPisosJSON(Program.oUsuario.IdExpedicion);
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                return;
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar cargar los grupos palomares.");
                return;
            }

            lupGrupoPalomar.Properties.DataSource = dt;
            lupGrupoPalomar.Properties.ValueMember = "IdGrupo";
            lupGrupoPalomar.Properties.DisplayMember = "Grupo";
            lupGrupoPalomar.Properties.DropDownRows = dt.Count;
            if (tipo == 1)
            {
                /*Opcion*/
                /*Modificar*/
                if (En == null)
                {
                    return;
                }
                obtenerPalomaresAsociados(En.ID);
                btnCrear.Text = "Modificar";
            }
            else { lupGrupoPalomar.Enabled = true; }
        }
        //2022
        private void obtenerPalomaresAsociados(int idEntrega)
        {
            try
            {
                listaPalomaresSeleccionados = Metodos.rObtenerPalomaresEntregaAsociados(idEntrega);
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                return;
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar obtener los palomares asociados.");
                return;
            }

            listaPalomaresSeleccionados.ForEach(hol => listaPalomaresBase.Add(hol));
            grdPalomaresEscogidos.DataSource = listaPalomaresSeleccionados;
            gridView2.RefreshData();
        }
        //2022
        private void llenarCboOperativo()
        {
            List<Operario> dt = new List<Operario>();
            try
            {
                dt = Metodos.listaOperarioJSON(Program.oUsuario.IdExpedicion);
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

            lupOperativo.Properties.DataSource = dt;
            lupOperativo.Properties.ValueMember = "ID";
            lupOperativo.Properties.DisplayMember = "Descripcion";
            lupOperativo.Properties.DropDownRows = dt.Count;
            lupOperativo.Properties.PopupWidth = 300;
            if (tipo == 1)
            {
                lupOperativo.EditValue = En.IdUsuarioCreador;
            }
        }
        //2022
        private void llenarGrillaPalomar(int idGrupo)
        {
            try
            {
                listaPalomar = Metodos.rListaPalomarPorGrupoJSON(Program.oUsuario.IdExpedicion, idGrupo);
                if (listaPalomaresSeleccionados.Count > 0)
                {
                    listaPalomaresSeleccionados.ForEach(hol =>
                    {
                        Palomar pa = listaPalomar.Find(hl => hl.ID == hol.ID);
                        if (pa != null)
                        { pa.SeleccionGrafica = true; }
                    });
                }
                grdPalomaresEscogidos.DataSource = listaPalomaresSeleccionados;
                grdPalomares.DataSource = listaPalomar.Where(hol => hol.SeleccionGrafica == false).ToList();
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                return;
            }
            catch
            {
                Program.mensajeError("Ha ocurrido un error al intentar cargar los palomares");
                return;
            }
        }
        //2022
        private void actualizarGrillas()
        {
            try
            {
                grdPalomares.DataSource = null;
                grdPalomaresEscogidos.DataSource = null;
                grdPalomaresEscogidos.DataSource = listaPalomaresSeleccionados;
                grdPalomares.DataSource = listaPalomar.Where(hol => hol.SeleccionGrafica == false).ToList();
                grdPalomares.RefreshDataSource();
                grdPalomares.Refresh();
                grdPalomaresEscogidos.Refresh();
                grdPalomaresEscogidos.RefreshDataSource();
                gridView2.RefreshData();
                gridView3.RefreshData();
            }
            catch
            {

            }
        }
        //2022
        private void eliminarEntrega()
        {
            int valor = 0;

            try
            {
                valor = Metodos.rEliminarEntregaPisos(En.ID);
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                return;
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar eliminar la entrega.");
                return;
            }


            if (valor != -1)
            {
                frmEntregaPisosPrin frm = (frmEntregaPisosPrin)Program.SetFormActive<frmEntregaPisosPrin>("Entrega Pisos", Program.oMain);

                frm.CargarRecorridoDePisos(TipoEntrega.RECORRIDO_PISOS, 1);
                this.Activate();
                Program.mensaje(string.Format("La entrega {0} ha sido eliminada correctamente", En.ID), MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Activate();
                this.Close();
                this.Dispose();
            }
            else
            {
                Program.mensaje(String.Format("No se ha podido eliminar la entrega ya que otro usuario ha modificado el estado."), MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Activate();
                return;
            }
        }
        //2022
        private void ejecutar()
        {
            try
            {   //Crear
                if (tipo == 0)
                {
                    if (lupGrupoPalomar.ItemIndex != -1 && lupOperativo.ItemIndex != -1)
                    {
                        //listaPalomar por listaPalomaresSeleccionados
                        if (listaPalomaresSeleccionados.Where(hol => hol.SeleccionGrafica == true).ToList().Count > 0)
                        {
                            Objeto O = new Objeto();
                            O.ListaXML = O.SerializeObjectWindows(listaPalomaresSeleccionados.Where(hol => hol.SeleccionGrafica == true).ToList());
                            int valor = 0;
                            try
                            {
                                valor = Metodos.CrearEntregaPisos(Program.oUsuario.IdExpedicion, Int32.Parse(lupOperativo.EditValue.ToString()), O.ListaXML);
                            }
                            catch (InvalidTokenException)
                            {
                                Program.mensajeTokenInvalido();
                                return;
                            }

                            if (valor != -1)
                            {
                                /*actualiza formulario que invoco este formulario*/
                                frmEntregaPisosPrin frm = (frmEntregaPisosPrin)Program.SetFormActive<frmEntregaPisosPrin>("Entrega Pisos", Program.oMain);

                                frm.CargarRecorridoDePisos(TipoEntrega.RECORRIDO_PISOS, 1);
                                this.Activate();
                                Program.mensaje(String.Format("La entrega Nro: {0} ha sido creada correctamente.", valor), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                                this.Dispose();
                            }
                            else
                            {
                                Program.mensaje("Los palomares elegidos no tienen ningún elemento en CUSTODIA.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Activate();
                                return;
                            }
                        }
                        else
                        {
                            Program.mensaje("Por favor seleccione los palomares que desea asociar a la entrega.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Activate();
                            return;
                        }
                    }
                    else
                    {
                        if (lupGrupoPalomar.ItemIndex == -1)
                        {
                            Program.mensaje("Por favor seleccione el grupo palomar.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Activate();
                            return;
                        }
                        else if (lupOperativo.ItemIndex == -1)
                        {
                            Program.mensaje("Por favor seleccione el Operativo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Activate();
                            return;
                        }
                        else
                        {
                            Program.mensaje("Por favor seleccione el plan de recorrido.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Activate();
                            return;

                        }

                    }
                }
                else
                {
                    if (lupOperativo.ItemIndex != -1)
                    {
                        DialogResult rs;
                        Objeto O = new Objeto();
                        O.ListaXML = O.SerializeObjectWindows(listaPalomaresSeleccionados);
                        /*Verificar si los palomares que voy a retirar tienen autogenerados validados*/

                        int resultado = 0;
                        try
                        {
                            resultado = Metodos.rVerificarAutogeneradoValidadosPorPalomares(O.ListaXML, En.ID);
                        }
                        catch (InvalidTokenException)
                        {
                            Program.mensajeTokenInvalido();
                            return;
                        }

                        /*Si resultado > 0 quiere decir que hay elementos que estan validados*/
                        if (resultado > 0)
                        {
                            rs = Program.mensaje(String.Format("Existen elementos validados a los palomares que desea retirar. Desea continuar?"), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            this.Activate();
                            if (rs == DialogResult.No)
                                return;
                        }
                        int Valor = 0;

                        try
                        {
                            Valor = Metodos.ModificarEntregaPisos(En.ID, (int)lupOperativo.EditValue, O.ListaXML, Program.oUsuario.IdExpedicion);
                        }
                        catch (InvalidTokenException)
                        {
                            Program.mensajeTokenInvalido();
                            return;
                        }

                        if (Valor > 0)
                        {
                            /*actualiza formulario que invoco este formulario*/
                            frmEntregaPisosPrin frm = (frmEntregaPisosPrin)Program.SetFormActive<frmEntregaPisosPrin>("Entrega Pisos", Program.oMain);

                            frm.CargarRecorridoDePisos(TipoEntrega.RECORRIDO_PISOS, 1);
                            this.Activate();
                            Program.mensaje(string.Format("La entrega : {0} ha sido modificada correctamente", En.ID), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Activate();
                            this.Dispose();
                            this.Close();
                        }
                        else if (Valor == 0)
                        {

                            frmEntregaPisosPrin frm = (frmEntregaPisosPrin)Program.SetFormActive<frmEntregaPisosPrin>("Entrega Pisos", Program.oMain);

                            frm.CargarRecorridoDePisos(TipoEntrega.RECORRIDO_PISOS, 1);
                            this.Activate();
                            DialogResult res = Program.mensaje(string.Format("Los palomares elegidos no tienen ningún elemento en CUSTODIA. Desea eliminar la entrega?", En.ID), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            this.Activate();
                            if (res == DialogResult.Yes)
                            {
                                eliminarEntrega();
                            }
                            return;
                        }
                        else if (Valor == -2)
                        {
                            /*actualiza formulario que invoco este formulario*/
                            frmEntregaPisosPrin frm = (frmEntregaPisosPrin)Program.SetFormActive<frmEntregaPisosPrin>("Entrega Pisos", Program.oMain);

                            frm.CargarRecorridoDePisos(TipoEntrega.RECORRIDO_PISOS, 1);
                            this.Activate();
                            Program.mensaje(string.Format("La entrega : {0} no ha sido modificada, ya que se encuentra en un estado diferente", En.ID), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Activate();
                        }
                        else
                        {
                            frmEntregaPisosPrin frm = (frmEntregaPisosPrin)Program.SetFormActive<frmEntregaPisosPrin>("Entrega Pisos", Program.oMain);

                            frm.CargarRecorridoDePisos(TipoEntrega.RECORRIDO_PISOS, 1);
                            this.Activate();
                            Program.mensaje(string.Format("Ha ocurrido un error, por favor verifique su conexión"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Activate();
                        }
                    }
                }
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar completar la acción. Verifique su conexión.");
                this.Activate();
            }
        }
        #endregion


        public frmNuevaEntregaPisos(int tipo)
        {
            InitializeComponent();
            this.tipo = tipo;
        }

        public void frmNuevaEntregaPisos_Load(object sender, EventArgs e)
        {
            llenarCboGrupoPalomares();
            llenarCboOperativo();
        }

        private void lupGrupoPalomar_EditValueChanged(object sender, EventArgs e)
        {
            llenarGrillaPalomar(Int32.Parse(lupGrupoPalomar.EditValue.ToString()));
            if (lupOperativo.ItemIndex != -1) btnCrear.Enabled = true;
        }
        //2022
        private void button1_Click(object sender, EventArgs e)
        {
            ejecutar();
        }

        private void lupOperativo_EditValueChanged(object sender, EventArgs e)
        {
            if (lupGrupoPalomar.ItemIndex != -1) btnCrear.Enabled = true;
        }

        private void btnIntroducirTodos_Click(object sender, EventArgs e)
        {
            try
            {
                listaPalomar.Where(hol => hol.SeleccionGrafica == false).ToList().ForEach(h =>
                {
                    if (listaPalomaresBase.Find(hol => hol.ID == h.ID) != null)
                    {
                        h.Base = 1;
                    }
                    listaPalomaresSeleccionados.Add(h);
                });
                listaPalomar.ForEach(hol => hol.SeleccionGrafica = true);
                actualizarGrillas();
            }
            catch (Exception)
            {

            }
        }

        private void btnExtraerTodos_Click(object sender, EventArgs e)
        {
            try
            {
                listaPalomaresSeleccionados.ForEach(hol =>
                {
                    Palomar pa = null;
                    pa = listaPalomar.Find(h => h.ID == hol.ID);

                    if (pa != null)
                    {
                        pa.SeleccionGrafica = false;
                    }
                });
            }
            catch { }

            listaPalomaresSeleccionados.Clear();
            actualizarGrillas();
        }

        private void gridView3_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (gridView3.FocusedColumn.FieldName != "SeleccionGrafica")
                {
                    return;
                }

                Palomar oO = (Palomar)gridView3.GetFocusedRow();
                Palomar obj = (Palomar)listaPalomar.Find(hol => hol.ID == oO.ID);
                if (obj != null)
                {
                    if (obj.SeleccionGrafica == true)
                    {
                        oO.SeleccionGrafica = false;
                        actualizarGrillas();
                    }
                    else
                    {
                        oO.SeleccionGrafica = true;
                        actualizarGrillas();
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void gridView2_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (gridView2.FocusedColumn.FieldName != "SeleccionGrafica")
                {
                    return;
                }
            }
            catch (Exception)
            {
            }
        }

        private void gridView2_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {

        }

        public void eliminarPalomarEscogido(object sender, EventArgs e)
        {
            Palomar oO = (Palomar)gridView2.GetFocusedRow();
            Palomar obj = null;
            if (listaPalomar != null)
            {
                obj = (Palomar)listaPalomar.Find(hol => hol.ID == oO.ID);
            }

            if (obj != null)
            {
                obj.SeleccionGrafica = false;
                listaPalomaresSeleccionados.Remove(oO);
            }
            else
            {
                listaPalomaresSeleccionados.Remove(oO);
            }
            actualizarGrillas();
        }

        private void DoubleClickEscogePalomar(object sender, EventArgs e)
        {
            Palomar oO = (Palomar)gridView3.GetFocusedRow();
            Palomar obj = (Palomar)listaPalomaresSeleccionados.Find(hol => hol.ID == oO.ID);
            if (obj == null)
            {
                if (listaPalomaresBase.Find(hol => hol.ID == oO.ID) != null)
                {
                    oO.Base = 1;
                }
                listaPalomaresSeleccionados.Add(oO);
                listaPalomar.Find(hol => hol.ID == oO.ID).SeleccionGrafica = true;
                actualizarGrillas();
            }
            else
            {
                Program.mensaje(string.Format("El palomar ya se encuentra seleccionado"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Activate();
                return;
            }
        }

    }
}
