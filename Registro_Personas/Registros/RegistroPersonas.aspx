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
        .auto-style8 {
            margin-left: 0px;
            margin-bottom: 3px;
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
            width: 170px;
            height: 22px;
        }
        .auto-style15 {
            text-align: left;
            height: 22px;
        }
        .auto-style16 {
            width: 170px;
        }
        .auto-style17 {
            text-align: center;
            width: 170px;
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
            <td class="auto-style4">Registro Personas</td>
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
                <asp:Button ID="buscarButton" runat="server" Text="Buscar" Width="75px" OnClick="buscarButton_Click" />
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
                <asp:ListItem>Casa</asp:ListItem>
                <asp:ListItem>Trabajo</asp:ListItem>
                <asp:ListItem>Celular</asp:ListItem>
                </asp:DropDownList>
&nbsp;Telefono:<asp:TextBox ID="TelefonoTextBox" runat="server" Width="61px"></asp:TextBox>
                <asp:Button ID="AgregarButton" runat="server" Text="A" Width="27px" OnClick="AgregarButton_Click" />
            </td>
        </tr>
        <tr>
            <td class="auto-style12">&nbsp;</td>
            <td class="auto-style16">
                <asp:GridView ID="telefonosGridView" runat="server" CssClass="auto-style8" Width="270px">
                </asp:GridView>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style13">
                &nbsp;</td>
            <td class="auto-style17">
                &nbsp;</td>
            <td class="auto-style3">
                &nbsp;</td>
        </tr>
    </table>
    <table style="width:100%;">
        <tr>
            <td class="auto-style9">
                <asp:Button ID="nuevoButton" runat="server" Text="Nuevo" Width="75px" OnClick="nuevoButton_Click" />
            </td>
            <td class="auto-style6">
                <asp:Button ID="guardarButton" runat="server" Text="Guardar" Width="75px" OnClick="guardarButton_Click" />
            </td>
            <td>
                <asp:Button ID="eliminarButton" runat="server" Text="Eliminar" Width="75px" OnClick="eliminarButton_Click" />
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
