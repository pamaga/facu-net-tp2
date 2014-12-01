<%@ Page Title="Reporte Docente" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Docente.aspx.cs" Inherits="UI.Web.Reportes.Docente" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="ContentReporteDocente" runat="server" 
    contentplaceholderid="bodyContentPlaceHolder">
    <asp:Panel ID="formPanel" runat="server" CssClass="wrapForm">
        <asp:Label ID="lblAnio" runat="server" Text="Año:"></asp:Label>
        <asp:TextBox ID="txtAnio" runat="server" AutoPostBack="True"></asp:TextBox>
        <asp:Panel ID="formActionsPanel" runat="server">
        </asp:Panel>
    </asp:Panel>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
        <asp:Panel ID="gridPanel" runat="server">
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
                Font-Size="8pt" InteractiveDeviceInfos="(Colección)" 
                WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="80%">
                <LocalReport ReportPath="Reportes\ReporteDocente.rdlc">
                    <DataSources>
                        <rsweb:ReportDataSource DataSourceId="ReporteDocenteDataSource" 
                            Name="ReporteDocente" />
                    </DataSources>
                </LocalReport>
            </rsweb:ReportViewer>
            <asp:SqlDataSource ID="ReporteDocenteDataSource" runat="server" 
                ConnectionString="<%$ ConnectionStrings:ConnStringLocal %>" 
                SelectCommand="SPreporteAlumnosYMateriasDocentes" 
                SelectCommandType="StoredProcedure">
                <SelectParameters>
                    <asp:ControlParameter ControlID="txtAnio" DefaultValue="2014" Name="anio" 
                        PropertyName="Text" Type="Int32" />
                    <asp:SessionParameter Name="idDocente" SessionField="id_usuario" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
            <br />
    </asp:Panel>
</asp:Content>
