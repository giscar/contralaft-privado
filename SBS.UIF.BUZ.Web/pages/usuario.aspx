<%@ Page Language="C#" MasterPageFile="plantilla.Master" AutoEventWireup="true" CodeBehind="usuario.aspx.cs" Inherits="SBS.UIF.BUZ.Web.pages.usuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphBody" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>


    <div>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Button" />
        <!-- Button trigger modal -->
        <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#usuarioModal">
            Crear usuario
        </button>
        <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#entidadModal">
            Crear entidad
        </button>
        <!-- Modal nuevo usuario-->
        <div class="modal fade" id="usuarioModal" tabindex="-1" role="dialog" aria-labelledby="usuarioModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="usuarioModalLabel">Nuevo Usuario</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <label for="txtNombre">Nombre</label>
                            <input type="text" class="form-control" id="txtNombre" runat="server" autocomplete="off" maxlength="80" placeholder="Ingrese usuario" />
                            <small class="form-text text-muted">Ingrese el nuevo usuario</small>
                        </div>
                        <div class="form-group">
                            <label for="txtContra">Password</label>
                            <input type="text" class="form-control" id="txtContra" runat="server" autocomplete="off" maxlength="80" placeholder="Ingrese contraseña" />
                        </div>
                        <div class="form-group">
                            <label style="vertical-align: bottom">Entidad</label>
                            <asp:DropDownList class="form-control" ID="ddlCodigoEntidad" runat="server" DataValueField="idTipo" DataTextField="DesTipo"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                        <asp:Button class="btn btn-lg btn-primary" ID="btnNuevo" runat="server" Text="Nueva Entidad" OnClick="Submit_nuevo" />
                    </div>
                </div>
            </div>
        </div>
        <!-- Modal nueva entidad-->
        <div class="modal fade" id="entidadModal" tabindex="-1" role="dialog" aria-labelledby="entidadModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="entidadModalLabel">Nueva Entidad</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <label for="txtNombre">Nombre</label>
                            <input type="text" class="form-control" id="txtEntidad" runat="server" autocomplete="off" maxlength="80" placeholder="Ingrese entidad" />
                            <small class="form-text text-muted">Ingrese el nombre de la entidad.</small>
                        </div>
                        <div class="form-group">
                            <label for="txtContra">RUC</label>
                            <input type="text" class="form-control" id="txtRuc" runat="server" autocomplete="off" maxlength="80" placeholder="Ingrese RUC" />
                            <small class="form-text text-muted">Ingrese el RUC de la entidad.</small>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                        <asp:Button class="btn btn-lg btn-primary" ID="Button2" runat="server" Text="Nueva entidad" OnClick="Submit_nuevo_entidad" />
                    </div>
                </div>
            </div>
        </div>
        <br />
        <asp:GridView ID="GridView1" runat="server" AllowPaging="true" OnPageIndexChanging="GridView1_PageIndexChanging" CssClass="table table-hover">
        </asp:GridView>
        <br />
    </div>


</asp:Content>
