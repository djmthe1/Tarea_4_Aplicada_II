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
        int id;
        bool sexo = true;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InsertarColumnas();
            }
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
            InsertarColumnas();
            ObtenerValoresGridView();
        }

        public void InsertarColumnas()
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[2] { new DataColumn("Tipo"), new DataColumn("Numero") });
            ViewState["Detalle"] = dt;
        }

        public void ObtenerValoresGridView()
        {
            telefonosGridView.DataSource = (DataTable)ViewState["Detalle"];
            telefonosGridView.DataBind();
        }

        private void ObtenerValores()
        {
            int.TryParse(personaIdTextBox.Text, out id);
            persona.PersonaId = id;
            persona.Nombres = nombreTextBox.Text;
            Comparar();
            persona.Sexo = sexo;
            foreach (GridViewRow row in telefonosGridView.Rows)
            {
                persona.InsertarTelefono(row.Cells[0].Text, row.Cells[1].Text);
            }
        }

        private void DevolverValores()
        {
            personaIdTextBox.Text = persona.PersonaId.ToString();
            nombreTextBox.Text = persona.Nombres;
            if (persona.Sexo == true)
                masculinoRadioButton.Checked = true;
            if (persona.Sexo == false)
                femeninoRadioButton.Checked = true;
            foreach (var item in persona.telefonos)
            {
                DataTable dt = (DataTable)ViewState["Detalle"];
                dt.Rows.Add(item.TipoTelefono, item.Telefono);
                ViewState["Detalle"] = dt;
                ObtenerValoresGridView();
            }
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
                    Limpiar();
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
                if (TipoDropDownList.Text != "")
                {
                    DataTable dt = (DataTable)ViewState["Detalle"];
                    DataRow Valores;

                    Valores = dt.NewRow();
                    Valores["Tipo"] = TipoDropDownList.SelectedValue;
                    Valores["Numero"] = TelefonoTextBox.Text;

                    dt.Rows.Add(Valores);
                    ViewState["Detalle"] = dt;
                    ObtenerValoresGridView();

                    ((TextBox)TelefonoTextBox).Text = string.Empty;
                    TipoDropDownList.SelectedIndex = -1;
                }
                else
	            {
                    Response.Write("<script>alert('Debe seleccionar un tipo de telefono')</script>");
                }
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