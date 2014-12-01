<%@ Page Title="Reporte Alumnos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Alumno.aspx.cs" Inherits="UI.Web.Reportes.Alumno" %>
<asp:Content ID="ContentReporteAlumnos" runat="server" 
    contentplaceholderid="bodyContentPlaceHolder">
        <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False" 
            SelectedRowStyle-BackColor="Black" SelectedRowStyle-ForeColor="White" 
            CellPadding="4" ForeColor="#333333" GridLines="None" 
                DataSourceID="SqlDataSource1" >
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField HeaderText="Materia" DataField="desc_materia" 
                    SortExpression="desc_materia" />
                <asp:BoundField HeaderText="Año Cursado" DataField="anio_calendario" 
                    SortExpression="anio_calendario" />
                <asp:BoundField HeaderText="Condición" DataField="condicion" 
                    SortExpression="condicion" />
                <asp:BoundField HeaderText="Nota" DataField="nota" SortExpression="nota" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
            <asp:SqlDataSource ID="ReporteAlumno" runat="server" 
                ConnectionString="<%$ ConnectionStrings:ConnStringLocal %>" 
                SelectCommand="SPEstadoAcademicoAlumno" SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:SessionParameter Name="id_alumno" SessionField="id_usuario" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
    </asp:Panel>
</asp:Content>
