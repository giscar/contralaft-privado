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
                            <input type="text" class="form-control" id="txtDescripcion" runat="server" autocomplete="off" maxlength="80" placeholder="Ingrese descripción" />
                            <small class="form-text text-muted">Ingrese la descripción del rol</small>
                        </div>
                        <div class="form-group">
                            <label style="vertical-align: bottom">Perfil</label>

                            
                            <asp:CheckBoxList id="ddlCodigoPerfil" CssClass="cllRadioButton" runat="server" AutoPostBack="false" DataValueField="idTipo" DataTextField="DesTipo"></asp:CheckBoxList>
                            <small class="form-text text-muted">Ingrese el Perfil</small>
                        </div>
                       <div class="form-group">
                        
                        <asp:Button class="btn btn-lg btn-primary" ID="btnNuevo" runat="server" Text="Crear rol" OnClick="Submit_nuevo" />
                        </div>
    <br />
        <asp:GridView ID="GridView1" runat="server" AllowPaging="true" OnPageIndexChanging="GridView1_PageIndexChanging" CssClass="table table-hover">
        </asp:GridView>
        <br />

    </asp:Content>