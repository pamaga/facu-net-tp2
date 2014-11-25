<%@ Page Title="Cursos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cursos.aspx.cs" Inherits="UI.Web.Catedras.Cursos" %>
<asp:Content ID="ContentCursos" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="False" SelectedRowStyle-BackColor="Black" SelectedRowStyle-ForeColor="White" DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" CaptionAlign="Top">
        <Columns>
            <asp:BoundField HeaderText="Año" DataField="AnioCalendario" />
            <asp:BoundField HeaderText="Cupo" DataField="Cupo" />
            <asp:BoundField HeaderText="Plan" DataField="DescPlan" />
            <asp:BoundField HeaderText="ID comision" DataField="IDComision" />
            <asp:BoundField HeaderText="Comision" DataField="DescComision" />
            <asp:BoundField HeaderText="ID materia" DataField="IDMateria" />
            <asp:BoundField HeaderText="Materia" DataField="DescMateria" />
            <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
    <asp:Panel ID="gridActionsPanel" runat="server">
        <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click" BorderWidth="btn btnEditar">Editar</asp:LinkButton>
        <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click" BorderWidth="btn btnEliminar">Eliminar</asp:LinkButton>
        <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click" BorderWidth="btn btnNuevo">Nuevo</asp:LinkButton>
    </asp:Panel>
    <asp:Panel ID="formPanel" Visible="false" runat="server" CssClass="wrapForm">
        <asp:Label ID="anioLabel" runat="server" Text="Año: "></asp:Label>
        <asp:TextBox ID="anioTextBox" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="cupoLabel" runat="server" Text="Cupo: "></asp:Label>
        <asp:TextBox ID="cupoTextBox" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="planLabel" runat="server" Text="Plan: "></asp:Label>
        <asp:TextBox ID="planTextBox" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="comisionLabel" runat="server" Text="Comision: "></asp:Label>
        <asp:DropDownList ID="comisionDropDownList" runat="server">
        </asp:DropDownList>
        <br />
        <asp:Label ID="materiaLabel" runat="server" Text="Materia: "></asp:Label>
        <asp:DropDownList ID="materiaDropDownList" runat="server">
        </asp:DropDownList>
        <br />
        <asp:Panel ID="formActionsPanel" runat="server">
            <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click" CssClass="btn">Aceptar</asp:LinkButton>
            <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click" CssClass="btn">Cancelar</asp:LinkButton>
        </asp:Panel>
    </asp:Panel>
</asp:Content>
