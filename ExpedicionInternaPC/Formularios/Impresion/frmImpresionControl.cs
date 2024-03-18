using ExpedicionInternaPC.Properties;
using ImpresionZebra;
using Interna.Entity;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;

namespace ExpedicionInternaPC
{
    public partial class frmImpresionControl : frmChild
    {
        #region Metodos

        //2022
        public void LlenarGrilla(List<Objeto> lstObjeto)
        {
            grdControl.DataSource = null;
            grdControl.DataSource = lstObjeto;
        }

        //2022
        private void VistaPreviaEtiqueta(Objeto oO)
        {
            string De = oO.CasillaDe;
            string AreaOrigen = oO.De;
            string Origen = oO.Origen;
            string Para = oO.CasillaPara;
            string AreaDestino = oO.Para;
            string Destino = oO.Destino;
            string Autogenerado = oO.Autogenerado;
            string Prefijo = oO.Prefijo;
            string Recibido = oO.RecibidoEl.ToShortDateString();
            frmEtiquetaAutogenedoModelo fea = new frmEtiquetaAutogenedoModelo(oO);
            if (fea.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("");
            }
        }
        //2022
        public void ImprimirZebra(Objeto oO)
        {
            EtiquetaCustodia etiqueta = new EtiquetaCustodia();
            etiqueta.De = oO.De.ToUpper();
            etiqueta.AreaOrigen = oO.AreaOrigen;
            etiqueta.Origen = oO.Origen.ToUpper();
            etiqueta.Para = oO.Para.ToUpper();
            etiqueta.AreaDestino = oO.AreaDestino;
            etiqueta.Destino = oO.sDestino;
            etiqueta.Autogenerado = oO.Autogenerado.ToUpper();
            etiqueta.Prefijo = oO.Prefijo.ToUpper();
            //VistaPreviaEtiqueta(oO);
            ZebraZpl zpl = new ZebraZpl();
            zpl.NOMBRE_IMPRESORA = Settings.Default["RutaImpresoraZebra"].ToString();
            string s = zpl.etiquetaCustodia(etiqueta.De, etiqueta.AreaOrigen, etiqueta.Origen, etiqueta.Para, etiqueta.AreaDestino, etiqueta.Destino, etiqueta.Autogenerado, etiqueta.Prefijo);
            zpl.imprimirEtiqueta(s);
        }
        //2022
        public bool ValidarUsuario(String Dato)
        {
            Boolean res = false;
            Usuario oO = new Usuario();
            try
            {
                oO = Metodos.ListarUsuarioDato1(Dato, Program.oUsuario.IdExpedicion)[0];
                int x = oO.Preferida;
                if (x == 1) res = true;
                return res;
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //2022
        private void Imprimir()
        {
            if (txtPass.Text.Trim().Length == 0)
            {
                Program.mensaje("Ingrese la clave del supervisor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPass.Focus();
                return;
            }

            if (ValidarUsuario(txtPass.Text.Trim()) == true)
            {
                List<Objeto> lstImprimir = (List<Objeto>)(grdControl.DataSource);
                List<Objeto> lstImprimirPendientes = new List<Objeto>();

                Objeto O = new Objeto();
                O.ListaXML = O.SerializeObjectWindows(lstImprimir);
                Objeto ORes = new Objeto();
                try
                {
                    ORes = Metodos.uObjetoImpresoXML1(O.ListaXML);
                    String xml = ORes.ListaXML;

                    XmlDocument xDoc = new XmlDocument();
                    xDoc.LoadXml(xml);
                    XmlNodeList personas = xDoc.GetElementsByTagName("ARRAYOFOBJETO");
                    XmlNodeList lista = ((XmlElement)personas[0]).GetElementsByTagName("t");

                    foreach (XmlElement nodo in lista)
                    {
                        XmlNodeList ID = nodo.GetElementsByTagName("ID");
                        XmlNodeList sysncOk = nodo.GetElementsByTagName("LOTE");
                        XmlNodeList impresionActual = nodo.GetElementsByTagName("IMPRESO");
                        XmlNodeList sEstado = nodo.GetElementsByTagName("ESTADO");
                        /* sysncOk = 0 >> CORRECTO ; sysncOk = 1 >> SEPARAR ; */
                        int iid = Convert.ToInt32(ID[0].InnerText);
                        string estado = Convert.ToString(sEstado[0].InnerText);
                        int Lote = Convert.ToInt32(sysncOk[0].InnerText);
                        Objeto oOO = new Objeto();
                        oOO = lstImprimir.Find(p => p.ID == iid);
                        if (Lote == 1)
                        {
                            oOO.Estado = estado;
                            oOO.Impreso = Convert.ToInt32(impresionActual[0].InnerText);
                            lstImprimirPendientes.Add(oOO);

                        }
                        else if (Lote == 0)
                        {
                            ImprimirZebra(oOO);

                        }


                    }
                    if (lstImprimirPendientes.Count > 0)
                    {

                        String mstring = "";
                        mstring += "Los siguientes Autogenerados no han sido impresos por motivo que no coinciden con el numero de impresión.";
                        mstring += Environment.NewLine;
                        mstring += "Si desea imprimir los siguientes Autogenerados con esta salvedad presione el boton imprimir.";

                        Program.mensaje(mstring, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.Activate();

                        grdControl.DataSource = null;
                        grdControl.DataSource = lstImprimirPendientes;
                    }
                    else
                    {
                        this.Activate();
                        DialogResult = DialogResult.OK;
                    }
                }
                catch (InvalidTokenException)
                {
                    Program.mensajeTokenInvalido();
                }
                catch (Exception)
                {
                    Program.mensajeError("Ha ocurrido un error al intentar imprimir.");
                }

            }
            else
            {
                Program.mensaje("Clave de supervisor incorrecta.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Focus();
                return;
            }
        }
        #endregion

        // Revisado
        public frmImpresionControl()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Imprimir();
        }

    }
}
