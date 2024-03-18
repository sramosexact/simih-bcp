using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Interna.Entity.PF;
using System.Collections.Generic;

namespace ExpedicionInternaPC.Formularios.Controles_Comunes
{
    public class LookUpPeriodo : LookUpEdit
    {

        #region Propiedades

        public List<PF_Periodo> periodos = new List<PF_Periodo>();

        #endregion

        #region Metodos

        public void ListarPeriodos()
        {
            try
            {
                this.Properties.Columns.Add(new LookUpColumnInfo("iId", "iId")
                {
                    Visible = false
                });
                this.Properties.Columns.Add(new LookUpColumnInfo("fechaPeriodo", "Fecha"));
                periodos = Metodos.ListarPeriodos();
                this.Properties.DataSource = periodos;
                this.Properties.DisplayMember = "fechaPeriodo";
                this.Properties.ValueMember = "iId";
                this.Properties.DropDownRows = periodos.Count;
                this.Properties.ShowFooter = false;
                this.Properties.ShowHeader = false;
                this.EditValue = periodos[0].iId;
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
        }

        #endregion

        public LookUpPeriodo()
        {
            //ListarPeriodos();
        }
    }
}
