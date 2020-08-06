<%@ Page Language="C#" MasterPageFile="plantilla.Master" AutoEventWireup="true" CodeBehind="rol.aspx.cs" Inherits="SBS.UIF.CONTRALAFT.Web.pages.rol" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphBody" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <div class="form-group">
            <label for="txtNombre">Rol</label>
            <input type="text" class="form-control" id="txtNombreRol" runat="server" autocomplete="off" maxlength="80" placeholder="Ingrese perfil" />
            <small class="form-text text-muted">Ingrese el nuevo rol</small>
        </div>
        <div class="form-group">
            <label for="txtContra">Descripción</label>
            <textarea class="form-control txtDescripcion" id="txtDescripcion" runat="server" autocomplete="off" maxlength="800" placeholder="Ingrese descripción"></textarea>
            <small class="form-text text-muted">Ingrese la descripción del rol</small>
        </div>
        <div class="form-group">
            <label style="vertical-align: bottom">Seleccione el perfil </label>
            <div class="icheck-line">
                <asp:RadioButtonList id="ddlCodigoPerfil" runat="server" AutoPostBack="false" DataValueField="idTipo" DataTextField="DesTipo"/>
            </div>
        </div>
        <div class="form-group">
            <asp:Button class="btn btn-lg btn-primary" ID="btnNuevo" runat="server" Text="Crear rol" OnClick="Submit_nuevo" />
        </div>
    <br/>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="true" OnPageIndexChanging="GridView1_PageIndexChanging" Class="table table-hover table-striped table-bordered" PageSize="10" AutoGenerateColumns="false">
        <Columns>
            <asp:TemplateField HeaderText="Nro.">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField ItemStyle-Width="20%" DataField="DesTipo" HeaderText="Nombre del Rol" />
            <asp:BoundField ItemStyle-Width="20%" DataField="DetDetalle" HeaderText="Detalle del Rol" />
            <asp:TemplateField ShowHeader="false">
                <ItemTemplate>
                    <a id="selectPerfil" onclick="showEdit(<%# Eval("IdTipo") %>, '<%# Eval("DesTipo") %>', '<%# Eval("DetDetalle") %>')" class="btn btn-success selectPerfil" >Editar</a>
                    <a id="inactivarPerfil" style="color: white" onclick="showInactive(<%# Eval("IdTipo") %>)" class="btn btn-danger inactivePerfil" >Inactivar</a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
        

</asp:Content>