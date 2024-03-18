using Interna.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ExpedicionInternaPC
{
    public partial class frmRegistrarRecorrido : frmChild
    {
        private List<Horario> horarios = new List<Horario>();
        private List<Sede> sedes = new List<Sede>();

        private void EnlazarCamposControles()
        {
            cboHorario.Properties.DisplayMember = "Descripcion";
            cboHorario.Properties.ValueMember = "Id";

            cboSede.Properties.DisplayMember = "Nombre";
            cboSede.Properties.ValueMember = "Id";

        }
        private void CargarListas()
        {
            horarios = Metodos.ListarHorariosSedesAsignadas();

            foreach (Horario horario in horarios)
            {
                if (!sedes.Exists(x => x.Id == horario.SedeId))
                {
                    Sede sede = new Sede();
                    sede.Id = horario.SedeId;
                    sede.Nombre = horario.Sede;
                    sedes.Add(sede);
                }
            }

            cboSede.Properties.DataSource = sedes;
            cboSede.Properties.DropDownRows = sedes.Count();
        }

        private void CargarHorario(Sede sede)
        {
            List<Horario> horarioSede = horarios.Where(x => x.SedeId == sede.Id).ToList();
            cboHorario.Properties.DataSource = horarioSede;
            cboHorario.Properties.DropDownRows = horarioSede.Count();
        }

        private void RegistrarInicioRecorrido()
        {
            Horario horario = (Horario)cboHorario.GetSelectedDataRow();
            if (horario == null)
            {
                Program.mensaje("Debe elegir un horario de la lista", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                Registro registro = Metodos.RegistrarInicioRecorrido(horario, txtDni.Text);
                if (registro.Resultado == 1) MensajeResultado(registro.Mensaje, Color.Green);
                else MensajeResultado(registro.Mensaje, Color.Red);
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception ex)
            {
                Program.mensajeError("Ha ocurrido un error al intentar registrar el inicio de recorrido.");
            }
            lblResultado.Visible = true;
        }
        private bool DniEsValido()
        {
            if (txtDni.Text.Trim().Length < 8) return false;
            return true;
        }
        private void SeleccionarTexto()
        {
            this.Focus();
            txtDni.Focus();
            txtDni.SelectAll();
        }
        private void MensajeDNIInvalido()
        {
            lblResultado.Text = "El código debe tener 8 caracteres.";
            lblResultado.ForeColor = Color.Red;
        }
        private void MensajeResultado(string mensaje, Color color)
        {
            lblResultado.Text = mensaje;
            lblResultado.ForeColor = color;
        }


        public frmRegistrarRecorrido()
        {
            InitializeComponent();
        }
        private void frmRegistrarRecorrido_Load(object sender, EventArgs e)
        {
            EnlazarCamposControles();
            CargarListas();
            txtDni.Text = "";
            lblResultado.Text = "";
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (!DniEsValido())
            {
                SeleccionarTexto();
                MensajeDNIInvalido();
                lblResultado.Visible = true;
                return;
            }

            RegistrarInicioRecorrido();
        }

        private void cboSede_EditValueChanged(object sender, EventArgs e)
        {
            Sede sede = (Sede)cboSede.GetSelectedDataRow();
            CargarHorario(sede);
        }

        private void txtDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.soloNumeros(e);
        }

        private void txtDni_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Enter)
            {
                return;
            }

            if (!DniEsValido())
            {
                SeleccionarTexto();
                MensajeDNIInvalido();
                lblResultado.Visible = true;
                return;
            }

            RegistrarInicioRecorrido();
        }
    }
}
