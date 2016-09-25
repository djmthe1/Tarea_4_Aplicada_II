using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace Registro_Personas.Registros
{
    public partial class RegistroPersonas : System.Web.UI.Page
    {

        Personas persona = new Personas();
        int id;
        bool sexo = true;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void Comparar()
        {
            if (masculinoRadioButton.Checked == true)
                sexo = true;
            if (femeninoRadioButton.Checked == true)
                sexo = false;
        }

        private void Limpiar()
        {
            ((TextBox)personaIdTextBox).Text = string.Empty;
            ((TextBox)nombreTextBox).Text = string.Empty;
            ((RadioButton)masculinoRadioButton).Checked = false;
            ((RadioButton)femeninoRadioButton).Checked = false;
            TipoDropDownList.SelectedIndex = -1;
            ((TextBox)TelefonoTextBox).Text = string.Empty;
            telefonosGridView.DataSource = null;
        }

        private void ObtenerValores()
        {
            int.TryParse(personaIdTextBox.Text, out id);
            persona.PersonaId = id;
            persona.Nombres = nombreTextBox.Text;
            Comparar();
            persona.Sexo = sexo;
            /*foreach (var numeros in persona.telefonos)
            {
                telefonosGridView.Rows.Add(numeros.Tipo, numeros.Telefono);
            }*/
        }

        protected void buscarButton_Click(object sender, EventArgs e)
        {

        }

        protected void AgregarButton_Click(object sender, EventArgs e)
        {

        }

        protected void nuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void guardarButton_Click(object sender, EventArgs e)
        {

        }

        protected void eliminarButton_Click(object sender, EventArgs e)
        {

        }
    }
}