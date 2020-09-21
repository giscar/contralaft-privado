<%@ Page Language="C#" MasterPageFile="plantilla.Master" AutoEventWireup="true" CodeBehind="listadoAcciones.aspx.cs" Inherits="SBS.UIF.CONTRALAFT.Web.pages.listadoAcciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphBody" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>




    <asp:GridView ID="GridView1" runat="server" AllowPaging="true" Class="table table-hover table-bordered" PageSize="10" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField ItemStyle-Width="10%" DataField="Codigo" HeaderText="Codigo" />
            <asp:BoundField ItemStyle-Width="20%" DataField="Nombre" HeaderText="Acción" />
            <asp:BoundField ItemStyle-Width="60%" DataField="Descripcion" HeaderText="Descripcion" />
            <asp:BoundField ItemStyle-Width="10%" DataField="Estado" HeaderText="Estado" />
        </Columns>
    </asp:GridView>
    
        <br />

    </asp:Content>