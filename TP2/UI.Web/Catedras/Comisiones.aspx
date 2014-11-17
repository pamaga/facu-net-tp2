<%@ Page Title="Comisiones" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Comisiones.aspx.cs" Inherits="UI.Web.Catedras.Comisiones" %>
<asp:Content ID="ContentComisiones" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="False" SelectedRowStyle-BackColor="Black" SelectedRowStyle-ForeColor="White" DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
        <Columns>
            <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
            <asp:BoundField HeaderText="IDPlan" DataField="IDPlan" />
            <asp:BoundField HeaderText="PlanDescripcion" DataField="PlanDescripcion" />
            <asp:BoundField HeaderText="AnioEspecialidad" DataField="AnioEspecialidad" />
            <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
    <asp:Panel ID="gridActionsPanel" runat="server">
        <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click">Editar</asp:LinkButton>
        <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click">Eliminar</asp:LinkButton>
        <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click">Nuevo</asp:LinkButton>
    </asp:Panel>
    <asp:Panel ID="formPanel" Visible="false" runat="server">
        <asp:Label ID="descripcionLabel" runat="server" Text="Descripcion: "></asp:Label>
        <asp:TextBox ID="descripcionTextBox" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="idPlanLabel" runat="server" Text="idPlan: "></asp:Label>
        <asp:TextBox ID="idPlanTextBox" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="planDescripcionLabel" runat="server" Text="planDescripcion: "></asp:Label>
        <asp:TextBox ID="planDescripcionTextBox" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="anioEspecialidadLabel" runat="server" Text="Año Especialidad: "></asp:Label>
        <asp:TextBox ID="anioEspecialidadTextBox" runat="server"></asp:TextBox>
        <br />
        <asp:Panel ID="formActionsPanel" runat="server">
            <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
            <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
        </asp:Panel>
    </asp:Panel>
</asp:Content>
