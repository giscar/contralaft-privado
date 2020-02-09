<%@ Page Language="C#" MasterPageFile="plantilla.Master" AutoEventWireup="true" CodeBehind="usuario.aspx.cs" Inherits="SBS.UIF.BUZ.Web.pages.usuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphBody" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <h5 class="card-title mb-4">Manage Tickets</h5>
                  <div class="fluid-container">
                    <div class="row ticket-card mt-3 pb-2 border-bottom pb-3 mb-3">
                      <div class="col-md-1">
                        <img class="img-sm rounded-circle mb-4 mb-md-0" src="https://placehold.it/100x100" alt="profile image">
                      </div>
                      <div class="ticket-details col-md-9">
                          <div class="container container-custom" style="border: 1px solid #fff;">



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
                            <label for="txtNombre">Nombre Completo</label>
                            <input type="text" class="form-control" id="txtNombre" runat="server" autocomplete="off" maxlength="80" placeholder="Ingrese usuario" />
                            <small class="form-text text-muted">Ingrese el nuevo usuario</small>
                        </div>
                        <div class="form-group">
                            <label for="txtNombre">DNI</label>
                            <input type="text" class="form-control" id="txtDocumento" runat="server" autocomplete="off" maxlength="80" placeholder="Ingrese el documento" />
                            <small class="form-text text-muted">Ingrese el documento de identidad</small>
                        </div>
                        <div class="form-group">
                            <label for="txtContra">Password</label>
                            <input type="text" class="form-control" id="txtContra" runat="server" autocomplete="off" maxlength="80" placeholder="Ingrese contraseña" />
                        </div>
                        <div class="form-group">
                            <label style="vertical-align: bottom">Entidad</label>
                            <asp:DropDownList class="form-control" ID="ddlCodigoEntidad" runat="server" DataValueField="idTipo" DataTextField="DesTipo"></asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label style="vertical-align: bottom">Perfil</label>
                            <asp:DropDownList class="form-control" ID="ddlCodigoPerfil" runat="server" DataValueField="idTipo" DataTextField="DesTipo"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                        <asp:Button class="btn btn-lg btn-primary" ID="btnNuevo" runat="server" Text="Nuevo usuario" OnClick="Submit_nuevo" />
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
        <asp:GridView ID="GridView1" runat="server" AllowPaging="true" OnPageIndexChanging="GridView1_PageIndexChanging" CssClass="table table-hover" PageSize="20" AutoGenerateColumns="false">
            <Columns>
        <asp:BoundField ItemStyle-Width="30%" DataField="DetCodigo" HeaderText="Customer ID" />
        <asp:BoundField ItemStyle-Width="30%" DataField="DetNombre" HeaderText="Contact Name" />
        <asp:BoundField ItemStyle-Width="40%" DataField="FecRegistro" HeaderText="FecRegistro" />
        
    </Columns>
        </asp:GridView>
        <br />
    </div>



                          </div>
    
                      </div>
                      
                    </div>
                    
                    
                  </div>



</asp:Content>
