<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RegistroPersonas.aspx.cs" Inherits="Registro_Personas.Registros.RegistroPersonas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        .auto-style3 {
            text-align: left;
        }
        .auto-style4 {
            text-align: center;
            width: 270px;
        }
        .auto-style5 {
            width: 270px;
        }
        .auto-style6 {
            text-align: center;
            width: 190px;
        }
        .auto-style7 {
            width: 190px;
        }
        .auto-style9 {
            text-align: right;
        }
        .auto-style10 {
            text-align: right;
            width: 268px;
        }
        .auto-style11 {
            text-align: right;
            width: 267px;
            height: 22px;
        }
        .auto-style12 {
            width: 267px;
        }
        .auto-style13 {
            text-align: center;
            width: 267px;
        }
        .auto-style14 {
            text-align: right;
            width: 234px;
            height: 22px;
        }
        .auto-style15 {
            text-align: left;
            height: 22px;
        }
        .auto-style16 {
            width: 234px;
        }
        .auto-style17 {
            text-align: center;
            width: 234px;
        }
    .auto-style18 {
        text-align: center;
        width: 270px;
        color: #33CC33;
        font-size: large;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style1">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style18"><strong>Registro Personas</strong></td>
            <td class="auto-style1">&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <table style="width:100%;">
        <tr>
            <td class="auto-style10">&nbsp;</td>
            <td class="auto-style10">
                PersonaId:</td>
            <td>
                <asp:TextBox ID="personaIdTextBox" runat="server" Width="75px"></asp:TextBox>
                <asp:Button ID="buscarButton" Class="btn-primary" runat="server" Text="Buscar" Width="75px" OnClick="buscarButton_Click" />
            </td>
        </tr>
        <tr>
            <td class="auto-style10">&nbsp;</td>
            <td class="auto-style10">
                Nombre:</td>
            <td>
                <asp:TextBox ID="nombreTextBox" runat="server" Width="149px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style10">&nbsp;</td>
            <td class="auto-style10">
                Sexo:</td>
            <td>
                <asp:Panel ID="Panel1" runat="server">
                    <asp:RadioButton ID="masculinoRadioButton" runat="server" Text="Masculino" />
                    <asp:RadioButton ID="femeninoRadioButton" runat="server" Text="Femenino" />
                </asp:Panel>
            </td>
        </tr>
    </table>
    <table style="width:100%;">
        <tr>
            <td class="auto-style11"></td>
            <td class="auto-style14">&nbsp; </td>
            <td class="auto-style15">&nbsp;Tipo:<asp:DropDownList ID="TipoDropDownList" runat="server">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>Casa</asp:ListItem>
                <asp:ListItem>Trabajo</asp:ListItem>
                <asp:ListItem>Celular</asp:ListItem>
                </asp:DropDownList>
&nbsp;Telefono:<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TelefonoTextBox" ErrorMessage="El numero es incorrecto" ForeColor="Red" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}">*</asp:RegularExpressionValidator>
                <asp:TextBox ID="TelefonoTextBox" runat="server" Width="75px"></asp:TextBox>
                <asp:Button ID="AgregarButton" Class="btn-primary" runat="server" Text="Agregar" Width="75px" OnClick="AgregarButton_Click" />
            </td>
        </tr>
        <tr>
            <td class="auto-style12">&nbsp;</td>
            <td class="auto-style16">
                &nbsp;</td>
            <td class="text-left">
                <asp:GridView ID="telefonosGridView" runat="server" AutoGenerateColumns="False" Height="101px" Width="214px" >
                    <Columns>
                            <asp:BoundField DataField="Tipo" HeaderText="Tipo" />
                            <asp:BoundField DataField="Numero" HeaderText="Numero" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="auto-style13">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" Width="216px" />
            </td>
            <td class="auto-style17">
                &nbsp;</td>
            <td class="auto-style3">
                &nbsp;</td>
        </tr>
    </table>
    <table style="width:100%;">
        <tr>
            <td class="auto-style9">
                <asp:Button ID="nuevoButton" Class="btn-primary" runat="server" Text="Nuevo" Width="75px" OnClick="nuevoButton_Click" />
            </td>
            <td class="auto-style6">
                <asp:Button ID="guardarButton" Class="btn-primary" runat="server" Text="Guardar" Width="75px" OnClick="guardarButton_Click" />
            </td>
            <td>
                <asp:Button ID="eliminarButton" Class="btn-primary" runat="server" Text="Eliminar" Width="75px" OnClick="eliminarButton_Click" />
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style7">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style7">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
