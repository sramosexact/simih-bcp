using Interna.Entity;
using System;
using System.Collections.Generic;

namespace ExpedicionInternaPC.Formularios.Agencias
{
    public partial class frmElementosDeGeoCambiado : frmChild
    {
        #region Variables 
        public List<Objeto> lObjetosConGeoCambiado = new List<Objeto>();
        public bool Exportacion { get; set; }

        public const string IndicacionesExportacion =
            "No se exportarán los elementos presentados en la tabla, se han retirado de la entrega; debido a que han cambiado de destino. Imprima nuevamente sus etiquetas.";
        public const string IndicacionesImportacion =
            "No se importarán los elementos presentados en la tabla, se han retirado de la entrega; debido a que han cambiado de destino. Imprima nuevamente sus etiquetas.";
        public string Indicaciones
        {
            get
            {
                return Exportacion == true ? IndicacionesExportacion : IndicacionesImportacion;
            }
        }

        #endregion

        #region Metodos

        //2022
        public void cargarFormulario()
        {
            grdObjetos.DataSource = lObjetosConGeoCambiado;
            grdObjetos.RefreshDataSource();
            lblIndicaciones.Text = Indicaciones;
        }

        #endregion


        public frmElementosDeGeoCambiado()
        {
            InitializeComponent();
            Exportacion = true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmElementosDeGeoCambiado_Load(object sender, EventArgs e)
        {
            cargarFormulario();
        }
    }
}
