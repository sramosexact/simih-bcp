using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using ExpedicionInternaPC.Enumeracion;
using ExpedicionInternaPC.Properties;
using ImpresionZebra;
using Interna.Entity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ExpedicionInternaPC
{
    public partial class frmPalomar : frmChild
    {
        private List<Palomar> oLista = null;
        private Boolean SeleccionClicDerecho = false;
        private Boolean SeleccionMover = false;
        private Palomar PalomarElegido;
        private Palomar GrupoDestino;
        private TreeListNode oNodex;

        #region Metodos

        //2022
        private void ListarPalomares()
        {
            try
            {
                oLista = Metodos.ListarPalomarExpedicion(Program.oUsuario.IdCliente, Program.oUsuario.IdExpedicion);
                trePalomar.DataSource = oLista;
                trePalomar.RefreshDataSource();
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar cargar los palomares.");
            }

        }
        //2022
        private void ListarPuntosEntregaAsociados()
        {
            Palomar oPalomar = PalomarActual();
            List<Geo> oGeoPorPalomar = new List<Geo>();
            try
            {
                oGeoPorPalomar = Metodos.ListarGeoPorPalomar(oPalomar.ID);
                griGeo.DataSource = null;
                griGeo.DataSource = oGeoPorPalomar;

                List<Geo> oGeoPorAsignar = new List<Geo>();

                oGeoPorAsignar = Metodos.ListarGeoPorAsociarAlPalomar(Program.oUsuario.IdExpedicion);
                oGeoPorAsignar.AddRange(oGeoPorPalomar);
                lookGeoPorAsignar.DataSource = null;
                lookGeoPorAsignar.DataSource = oGeoPorAsignar;
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar cargar los puntos de entrega.");
            }
        }
        //2022
        private void NuevoPalomarGrupo(Enumeracion.TipoPalomarDestino oT)
        {
            try
            {
                Palomar oPalomar = PalomarActual();
                int ID1 = Metodos.NuevoPalomarGrupo(oPalomar.IdExpedicion, (int)oT);
                UbicarPalomar(ID1);
                trePalomar.OptionsBehavior.Editable = true;
                trePalomar.ShowEditor();
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar agregar un nuevo grupo palomar.");
            }
        }
        //2022
        private void NuevoPalomar()
        {
            try
            {
                Palomar oPalomar = PalomarActual();
                int ID2 = Metodos.NuevoPalomar(oPalomar.ID);
                UbicarPalomar(ID2);
                trePalomar.OptionsBehavior.Editable = true;
                trePalomar.ShowEditor();
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar agregar un nuevo palomar.");
            }
        }
        //2022
        public override void Actualizar(string CommandName)
        {
            base.Actualizar(CommandName);
            ListarPalomares();
        }
        //2022
        private Palomar PalomarActual()
        {

            Palomar oPalomar = new Palomar();
            oPalomar.ID = (int)oNodex.GetValue("ID");
            oPalomar.Descripcion = (string)oNodex.GetValue("Descripcion");
            oPalomar.IdExpedicion = (int)oNodex.GetValue("IdExpedicion");
            oPalomar.IdPadre = (int)oNodex.GetValue("IdPadre");
            oPalomar.IdSistema = (int)oNodex.GetValue("IdSistema");
            oPalomar.IdTipoPalomar = (int)oNodex.GetValue("IdTipoPalomar");
            oPalomar.IdTipoDestino = (int)oNodex.GetValue("IdTipoDestino");

            return oPalomar;
        }
        //2022
        private void UbicarPalomar(int IdPalomar)
        {
            ListarPalomares();
            oNodex = trePalomar.FindNodeByKeyID(IdPalomar);
            oNodex.Visible = true;
            oNodex.Expanded = true;
            oNodex.Selected = true;
        }
        //2022
        private void ModificarPalomar()
        {
            Palomar oP = PalomarActual();
            if ((TipoPalomar)oP.IdTipoPalomar != TipoPalomar.Expedicion)
            {
                trePalomar.OptionsBehavior.Editable = true;
                trePalomar.ShowEditor();
            }
        }
        //2022
        private void EliminarPalomarSeleccionado()
        {
            Palomar oPalomar = PalomarActual();
            if (oPalomar.IdTipoPalomar == (int)TipoPalomar.Expedicion) return;

            int resp = 0;

            if (oPalomar.IdTipoPalomar == (int)TipoPalomar.Palomar)
            {
                if (Program.mensaje(string.Format("¿Desea eliminar el palomar {0}?", oPalomar.nombre), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;
                try
                {
                    resp = Metodos.EliminarPalomar(oPalomar.ID);
                    if (resp == 1)
                        UbicarPalomar(oPalomar.IdPadre);
                    else if (resp == -2)
                        MessageBox.Show("No se puede eliminar el palomar debido a que existe una o mas oficinas/pisos", Program.titulo);
                }
                catch (InvalidTokenException)
                {
                    Program.mensajeTokenInvalido();
                }
                catch (Exception)
                {
                    Program.mensajeError("Ha ocurrido un error al intentar eliminar el palomar.");
                }
            }
            else if (oPalomar.IdTipoPalomar == (int)TipoPalomar.Grupo)
            {
                if (Program.mensaje(string.Format("¿Desea eliminar el grupo palomar {0}?", oPalomar.nombre), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;
                try
                {
                    resp = Metodos.EliminarGrupoPalomar(oPalomar.ID);
                    if (resp == 1) UbicarPalomar(oPalomar.IdPadre);
                }
                catch (InvalidTokenException)
                {
                    Program.mensajeTokenInvalido();
                }
                catch (Exception)
                {
                    Program.mensajeError("Ha ocurrido un error al intentar eliminar el grupo palomar.");
                }
            }
        }
        //2022
        private void ImprimirEtiquetaPalomares()
        {
            try
            {
                Palomar oPalomar = PalomarActual();
                List<Palomar> lPalomar = Metodos.ListaPalomares(Program.oUsuario.IdExpedicion, oPalomar.ID);

                if (lPalomar.Count == 0)
                {
                    string codigo = oPalomar.ID.ToString();
                    string descripcion = oPalomar.Descripcion;
                    ZebraZpl zpl = new ZebraZpl();
                    zpl.NOMBRE_IMPRESORA = Settings.Default["RutaImpresoraZebra"].ToString();
                    string s = zpl.etiquetaPalomar(codigo.PadLeft(6, '0'), descripcion);
                    zpl.imprimirEtiqueta(s);
                }
                else
                {
                    foreach (Palomar p in lPalomar)
                    {
                        string codigo = p.ID.ToString();
                        string descripcion = p.Descripcion;
                        ZebraZpl zpl = new ZebraZpl();
                        zpl.NOMBRE_IMPRESORA = Settings.Default["RutaImpresoraZebra"].ToString();
                        string s = zpl.etiquetaPalomar(codigo.PadLeft(6, '0'), descripcion);
                        zpl.imprimirEtiqueta(s);
                    }
                }

            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar obtener los datos para imprimir.");
            }
        }
        //2022
        private void DesvincularPuntoEntrega()
        {

            String sTipoDestino = oNodex.GetValue("sTipoDestino").ToString();

            if (sTipoDestino.ToUpper().Contains("AGENCIA"))
            {
                Program.mensaje("No se puede desvincular el punto de entrega de una Agencia.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (sTipoDestino.ToUpper().Contains("SUCURSALES"))
            {
                Program.mensaje("No se puede desvincular el punto de entrega de una Sucursal.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Geo oGeo = (Geo)gvwGeo.GetFocusedRow();

            if (oGeo == null) return;
            if (Program.mensaje(string.Format("¿Desea desvincular el punto de entrega {0} del palomar seleccionado?", oGeo.Area), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;

            try
            {
                int i = Metodos.DesvincularPalomarPuntoEntrega(oGeo.ID);
                ListarPuntosEntregaAsociados();
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar desvincular el punto de entrega del palomar.");
            }
        }
        //2022
        public override void ExportExcel(String FileName)
        {
            gvwGeo.ExportToXls(FileName);
        }

        #endregion


        private void trePalomar_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            try
            {
                oNodex = e.Node;
                if (oNodex.Level == 2)
                {
                    if (oNodex.GetValue("sTipoDestino").ToString() == "PISOS")
                    {
                        gvwGeo.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
                    }
                    else
                    {
                        gvwGeo.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                        lookGeoPorAsignar.ReadOnly = true;
                    }
                }
                else
                {
                    gvwGeo.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                    lookGeoPorAsignar.ReadOnly = true;
                }
                ListarPuntosEntregaAsociados();
                trePalomar.OptionsBehavior.Editable = false;
            }
            catch
            {
            }
        }

        private void trePalomar_ShownEditor(object sender, EventArgs e)
        {
            Palomar oP = PalomarActual();
            if ((TipoPalomar)oP.IdTipoPalomar == TipoPalomar.Expedicion)
            {
                trePalomar.HideEditor();
                return;
            }
            TreeList tlist = sender as TreeList;
            tlist.FocusedNode.StateImageIndex = 5;
        }

        private void trePalomar_HiddenEditor(object sender, EventArgs e)
        {
            TreeList tlist = sender as TreeList;
            tlist.FocusedNode.StateImageIndex = -1;
        }

        private void trePalomar_CellValueChanged(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
            Palomar oPalomar = PalomarActual();

            if (oPalomar.Descripcion.Length > 0 && (TipoPalomar)oPalomar.IdTipoPalomar > TipoPalomar.Expedicion)
            {
                try
                {
                    if (Metodos.ModificarPalomar(oPalomar) != 0)
                    {
                        e.Node.SetValue("Descripcion", oPalomar.Descripcion.ToUpper());
                    }
                }
                catch (InvalidTokenException)
                {
                    Program.mensajeTokenInvalido();
                }
                catch (Exception)
                {
                    Program.mensajeError("Ha ocurrido un error al intentar modificar el palomar.");
                }
            }
        }

        private void trePalomar_MouseClick(object sender, MouseEventArgs e)
        {
            if (SeleccionClicDerecho == false)
                return;

            if (e.Button == MouseButtons.Right)
            {
                Palomar oP = PalomarActual();

                if ((TipoPalomar)oP.IdTipoPalomar == TipoPalomar.Expedicion)
                {
                    btnGrupoNuevo.Visibility = BarItemVisibility.Always;
                    btnNuevoGrupoPisos.Visibility = Program.oUsuario.IdTipoExpedicion == (int)TipoExpedicion.SUCURSAL ? BarItemVisibility.Always : BarItemVisibility.Never;
                    btnNuevoGrupoAgenciasLima.Visibility = Program.oUsuario.IdTipoExpedicion == (int)TipoExpedicion.AGENCIAS_LIMA ? BarItemVisibility.Always : BarItemVisibility.Never;
                    btnNuevoGrupoAgenciasProvincia.Visibility = Program.oUsuario.IdTipoExpedicion == (int)TipoExpedicion.AGENCIAS_PROVINCIA ? BarItemVisibility.Always : BarItemVisibility.Never;
                    btnNuevoGrupoSucursales.Visibility = BarItemVisibility.Never;
                    btnNuevoPalomar.Visibility = BarItemVisibility.Never;
                    btnRenombrar.Visibility = BarItemVisibility.Never;
                    btnEliminar.Visibility = BarItemVisibility.Never;
                    btnImprimir.Visibility = BarItemVisibility.Never;
                    btnMover.Visibility = BarItemVisibility.Never;
                }

                if ((TipoPalomar)oP.IdTipoPalomar == TipoPalomar.Grupo)
                {
                    btnGrupoNuevo.Visibility = BarItemVisibility.Never;
                    btnNuevoGrupoPisos.Visibility = Program.oUsuario.IdTipoExpedicion == (int)TipoExpedicion.SUCURSAL ? BarItemVisibility.Always : BarItemVisibility.Never;
                    btnNuevoGrupoAgenciasLima.Visibility = Program.oUsuario.IdTipoExpedicion == (int)TipoExpedicion.AGENCIAS_LIMA ? BarItemVisibility.Always : BarItemVisibility.Never;
                    btnNuevoGrupoAgenciasProvincia.Visibility = Program.oUsuario.IdTipoExpedicion == (int)TipoExpedicion.AGENCIAS_PROVINCIA ? BarItemVisibility.Always : BarItemVisibility.Never;
                    btnNuevoGrupoSucursales.Visibility = BarItemVisibility.Never;

                    if (oP.IdTipoDestino == (int)TipoPalomarDestino.PISOS)
                    {
                        btnNuevoPalomar.Visibility = BarItemVisibility.Always;
                        btnEliminar.Visibility = BarItemVisibility.Always;
                    }
                    else
                    {
                        btnNuevoPalomar.Visibility = BarItemVisibility.Never;
                        btnEliminar.Visibility = BarItemVisibility.Never;
                    }

                    btnRenombrar.Visibility = BarItemVisibility.Always;
                    btnImprimir.Visibility = BarItemVisibility.Always;

                    if (SeleccionMover == true)
                    {
                        this.btnMover.ImageIndex = 11;
                        btnMover.Visibility = BarItemVisibility.Always;
                        btnMover.Caption = "Mover seleccionado";

                    }
                    else
                    {
                        btnMover.Visibility = BarItemVisibility.Never;
                    }

                }
                if ((TipoPalomar)oP.IdTipoPalomar == TipoPalomar.Palomar)
                {
                    btnGrupoNuevo.Visibility = BarItemVisibility.Never;
                    btnNuevoGrupoPisos.Visibility = BarItemVisibility.Never;
                    btnNuevoGrupoAgenciasLima.Visibility = BarItemVisibility.Never;
                    btnNuevoGrupoAgenciasProvincia.Visibility = BarItemVisibility.Never;
                    btnNuevoGrupoSucursales.Visibility = BarItemVisibility.Never;
                    btnNuevoPalomar.Visibility = BarItemVisibility.Never;
                    btnRenombrar.Visibility = BarItemVisibility.Always;

                    if (oP.IdTipoDestino == (int)TipoPalomarDestino.PISOS)
                    {
                        btnEliminar.Visibility = BarItemVisibility.Always;
                    }
                    else
                    {
                        btnEliminar.Visibility = BarItemVisibility.Never;
                    }

                    btnImprimir.Visibility = BarItemVisibility.Always;

                    if (oP.IdTipoDestino == (int)TipoPalomarDestino.PISOS || oP.IdTipoDestino == (int)TipoPalomarDestino.AGENCIAS_LIMA || oP.IdTipoDestino == (int)TipoPalomarDestino.AGENCIAS_PROVINCIA)
                    {
                        btnMover.Visibility = BarItemVisibility.Always;
                        this.btnMover.ImageIndex = 12;
                        btnMover.Caption = "Seleccionar";
                    }
                    else
                    {
                        btnMover.Visibility = BarItemVisibility.Never;
                        this.btnMover.ImageIndex = 12;
                        btnMover.Caption = "Seleccionar";
                    }


                }
                popMenu.ShowPopup(Control.MousePosition);
            }
        }

        private void btnNuevoPalomar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            NuevoPalomar();
        }

        private void btnNuevoGrupoPisos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            NuevoPalomarGrupo(Enumeracion.TipoPalomarDestino.PISOS);
        }

        private void btnNuevoGrupoAgencias_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            NuevoPalomarGrupo(Enumeracion.TipoPalomarDestino.AGENCIAS_LIMA);
        }

        private void btnNuevoGrupoAgenciasProvincia_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            NuevoPalomarGrupo(Enumeracion.TipoPalomarDestino.AGENCIAS_PROVINCIA);
        }

        private void btnNuevoGrupoSucursales_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            NuevoPalomarGrupo(Enumeracion.TipoPalomarDestino.SUCURSALES);
        }

        private void btnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EliminarPalomarSeleccionado();
        }

        private void btnRenombrar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ModificarPalomar();
        }

        private void lnkEliminar_Click(object sender, EventArgs e)
        {
            DesvincularPuntoEntrega();
        }

        private void btnImprimir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ImprimirEtiquetaPalomares();
        }

        public frmPalomar()
        {
            InitializeComponent();

        }

        private void frmPalomar_Load(object sender, EventArgs e)
        {
            ListarPalomares();
        }

        private void gvwGeo_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if (((ColumnView)(gvwGeo)).FocusedValue == null)
            {
                lookGeoPorAsignar.ReadOnly = false;
            }
            else
            {
                lookGeoPorAsignar.ReadOnly = true;
            }
        }

        private void frmPalomar_Activated(object sender, EventArgs e)
        {
            frmMain frmPadre = this.MdiParent as frmMain;
            frmPadre.subMostrarSupervision(true);
        }

        private void frmPalomar_Deactivate(object sender, EventArgs e)
        {
            frmMain frmPadre = this.MdiParent as frmMain;
            frmPadre.subMostrarSupervision(false);
        }

        private void trePalomar_DragDrop(object sender, DragEventArgs e)
        {
            /*SOLTAR*/
            TreeListNode node = GetDragNode(e.Data);
            TreeListNode targetNode;
            TreeListNode dragNode;

            TreeList treeList = sender as TreeList;
            Point point = treeList.PointToClient(new Point(e.X, e.Y));

            targetNode = treeList.CalcHitInfo(point).Node;
            dragNode = e.Data.GetData(typeof(TreeListNode)) as TreeListNode;


            treeList.SetNodeIndex(dragNode, treeList.GetNodeIndex(targetNode));

        }

        private string GetStringByNode(DevExpress.XtraTreeList.Nodes.TreeListNode node)
        {
            string ret = "";
            for (int i = 0; i < trePalomar.Columns.Count; i++)
            {
                ret += node.GetDisplayText(i) + (i < trePalomar.Columns.Count - 1 ? "; " : ".");
            }
            return ret;
        }

        private void trePalomar_DragOver(object sender, DragEventArgs e)
        {
            /*AGARRAR*/
            TreeListNode dragNode = e.Data.GetData(typeof(TreeListNode)) as TreeListNode;
            e.Effect = GetDragDropEffect(sender as TreeList, dragNode);
        }

        private DevExpress.XtraTreeList.Nodes.TreeListNode GetDragNode(IDataObject data)
        {
            return data.GetData(typeof(DevExpress.XtraTreeList.Nodes.TreeListNode)) as DevExpress.XtraTreeList.Nodes.TreeListNode;
        }

        private DragDropEffects GetDragDropEffect(TreeList tl, TreeListNode dragNode)
        {
            TreeListNode targetNode;
            Point p = tl.PointToClient(MousePosition);

            targetNode = tl.CalcHitInfo(p).Node;


            if (dragNode != null
                && targetNode != null
                && dragNode != targetNode
                && targetNode.GetValue("sTipoDestino") == dragNode.GetValue("sTipoDestino")
                && targetNode.ParentNode.Level == 0
                && targetNode.GetValue("sTipoDestino").ToString() == "PISOS"
                && dragNode.Level == targetNode.Level + 1
                && dragNode.Level == 2
                && dragNode.Level != 1
                )
            {
                return DragDropEffects.Move;
            }
            else
            {
                return DragDropEffects.None;
            }


        }

        private void trePalomar_MouseDown(object sender, MouseEventArgs e)
        {
            TreeList tree = sender as TreeList;
            TreeListHitInfo hitInfo = tree.CalcHitInfo(e.Location);
            if (e.Button == MouseButtons.Right && (hitInfo.HitInfoType == HitInfoType.Cell || hitInfo.HitInfoType == HitInfoType.SelectImage || hitInfo.HitInfoType == HitInfoType.StateImage || hitInfo.HitInfoType == HitInfoType.RowIndent))
            {
                SeleccionClicDerecho = true;
                hitInfo.Node.Selected = !hitInfo.Node.Selected;
            }
            else
            {
                SeleccionClicDerecho = false;
            }
        }

        private void btnMover_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (SeleccionMover == true)
            {
                GrupoDestino = PalomarActual();
                if (GrupoDestino.IdTipoPalomar == (int)TipoPalomar.Grupo)
                {
                    try
                    {
                        PalomarElegido.IdPadre = GrupoDestino.ID;
                        int ID = Metodos.ModificarPalomar(PalomarElegido);
                        if (ID >= 0)
                        {
                            UbicarPalomar(ID);
                            GrupoDestino = null;
                        }
                        SeleccionMover = false;
                    }
                    catch (InvalidTokenException)
                    {
                        Program.mensajeTokenInvalido();
                    }
                    catch (Exception)
                    {
                        Program.mensajeError("Ha ocurrido un error al intentar modificar el palomar.");
                    }

                }
                else
                {
                    PalomarElegido = PalomarActual();
                    SeleccionMover = true;
                }
            }
            else
            {
                PalomarElegido = PalomarActual();
                SeleccionMover = true;
            }

        }

        private void repositoryItemGridLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (trePalomar.FocusedNode.Level == 2)
            {

                try
                {
                    int intIdPalomar = PalomarActual().ID;
                    int intIdGeo = (int)((GridLookUpEdit)(sender)).EditValue;
                    Metodos.VincularPalomarPuntoEntrega(intIdPalomar, intIdGeo, Program.oUsuario.IdExpedicion);
                    ListarPuntosEntregaAsociados();
                }
                catch (InvalidTokenException)
                {
                    Program.mensajeTokenInvalido();
                }
                catch (Exception)
                {
                    Program.mensajeError("Ha ocurrido un error al intentar vincular el punto de entrega al palomar.");
                }

            }
        }
    }

}