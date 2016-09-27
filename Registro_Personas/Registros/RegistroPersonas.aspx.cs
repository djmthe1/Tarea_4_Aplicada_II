using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;

namespace Registro_Personas.Registros
{
    public partial class RegistroPersonas : System.Web.UI.Page
    {

        Personas persona = new Personas();
        DataTable dt = new DataTable();
        int id;
        bool sexo = true;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.telefonosGridView.DataSource = ObtenerLista();
                this.telefonosGridView.DataBind();
            }
        }

        public List<PersonasTelefonos> ObtenerLista()
        {
            List<PersonasTelefonos> lista = new List<PersonasTelefonos>();
            PersonasTelefonos telefono = new PersonasTelefonos();
            lista.Add(telefono);
            return lista;
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
            Session["Personas"] = new Personas();
            int.TryParse(personaIdTextBox.Text, out id);
            persona.PersonaId = id;
            persona.Nombres = nombreTextBox.Text;
            Comparar();
            persona.Sexo = sexo;
            /*foreach (GridViewRow row in telefonosGridView.Rows)
            {
                persona.InsertarTelefono(1, row.Cells[1].Text, row.Cells[2].Text);
            }*/
        }

        private void DevolverValores()
        {
            personaIdTextBox.Text = persona.PersonaId.ToString();
            nombreTextBox.Text = persona.Nombres;
            if (persona.Sexo == true)
                masculinoRadioButton.Checked = true;
            if (persona.Sexo == false)
                femeninoRadioButton.Checked = true;
            telefonosGridView.DataSource = persona.telefonos;
            telefonosGridView.DataBind();
        }

        protected void buscarButton_Click(object sender, EventArgs e)
        {
            telefonosGridView.DataSource = null;
            ObtenerValores();
            if (personaIdTextBox.Text.Length == 0)
            {
                Response.Write("<script>alert('Debe insertar un Id, Error al Buscar')</script>");
            }
            else
            {
                if (persona.Buscar(persona.PersonaId))
                {
                    DevolverValores();
                }
                else
                {
                    Response.Write("<script>alert('Id no encontrado')</script>");
                    Limpiar();
                }
            }
        }

        protected void AgregarButton_Click(object sender, EventArgs e)
        {
            try
            {
                    /*Personas personas;

                    if (Session["Personas"] == null)
                    {
                        Session["Personas"] = new Personas();
                    }

                    personas = (Personas)Session["Personas"];

                    //persona.InsertarTelefono(1, TelefonoTextBox.Text, TipoDropDownList.Text);

                    Session["Personas"] = personas;

                    telefonosGridView.DataSource = personas.Telefono;
                    telefonosGridView.DataBind();

                DataTable dt = (DataTable)ViewState["Detalle"];
                dt.Rows.Add(1, TelefonoTextBox.Text, TipoDropDownList.Text);
                ViewState["Detalle"] = dt;
                ((TextBox)TelefonoTextBox).Text = string.Empty;
                TipoDropDownList.SelectedIndex = -1;*/

            }
            catch (Exception)
            {
                
            }
        }

        protected void nuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void guardarButton_Click(object sender, EventArgs e)
        {
            ObtenerValores();
            if (personaIdTextBox.Text == "")
            {
                if (nombreTextBox.Text != "" && (masculinoRadioButton.Checked == true || femeninoRadioButton.Checked == true))
                {
                    if (persona.Insertar())
                    {
                        Limpiar();
                        Response.Write("<script>alert('Insertado correctamente')</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Error al insertar')</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Debe llenar todos los campos, Error al insertar')</script>");
                }
            }
            else
            {
                if (nombreTextBox.Text != "" && (masculinoRadioButton.Checked == true || femeninoRadioButton.Checked == true))
                {
                    if (persona.Editar())
                    {
                        Limpiar();
                        Response.Write("<script>alert('Modificado correctamente')</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Error al modificar')</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Debe llenar todos los campos, Error al modificar')</script>");
                }
            }

        }

        protected void eliminarButton_Click(object sender, EventArgs e)
        {
            ObtenerValores();
            if (personaIdTextBox.Text.Length == 0)
            {
                Response.Write("<script>alert('Debe insertar un Id')</script>");
            }
            else
            {
                if (persona.Buscar(persona.PersonaId))
                {
                    if (persona.Eliminar())
                    {
                        Response.Write("<script>alert('Eliminado correctamente')</script>");
                        Limpiar();
                    }
                    else
                    {
                        Response.Write("<script>alert('Error al eliminar')</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Id no encontrado')</script>");
                    Limpiar();
                }
            }
        }
    }
}