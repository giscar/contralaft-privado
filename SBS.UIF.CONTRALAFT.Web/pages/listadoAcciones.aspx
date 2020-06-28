<%@ Page Language="C#" MasterPageFile="plantilla.Master" AutoEventWireup="true" CodeBehind="listadoAcciones.aspx.cs" Inherits="SBS.UIF.CONTRALAFT.Web.pages.listadoAcciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphBody" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>




    
        <asp:GridView ID="GridView1" runat="server" AllowPaging="true" OnPageIndexChanging="GridView1_PageIndexChanging" CssClass="table table-hover">
        </asp:GridView>
        <br />

    </asp:Content>