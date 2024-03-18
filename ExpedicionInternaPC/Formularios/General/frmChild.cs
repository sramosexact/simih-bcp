using DevExpress.XtraEditors;
using Interna.Entity;
using System;

namespace ExpedicionInternaPC
{
    public partial class frmChild : XtraForm
    {
        //protected Pagina oPagina = new Pagina();

        public frmChild()
        {
            InitializeComponent();
        }

        public virtual void Actualizar(String CommandName) { }

        public virtual void ExportExcel(String FileName) { }

        public virtual void PaginaInicio() { }

        public virtual void PaginaAtras() { }

        public virtual void PaginaAdelante() { }

        public virtual void PaginaFinal() { }

        public virtual void PaginaTamano(int Width) { }

        public virtual Pagina Pagina()
        { //return this.oPagina; 
            return null;
        }
    }
}
