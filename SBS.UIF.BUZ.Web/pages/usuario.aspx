<%@ Page Language="C#" MasterPageFile="plantilla.Master" AutoEventWireup="true" CodeBehind="usuario.aspx.cs" Inherits="SBS.UIF.BUZ.Web.pages.usuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphBody" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <link rel="stylesheet" href="/css/style.css">
    <div class="row">
        <div class="col-md-6">
            <h5 class="card-title mb-4">Listado de usuarios activos</h5>
        </div>
        <div class="col-md-6">
            <!-- Button trigger modal -->
                        <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#usuarioModal">
                            Crear usuario
                        </button>
                        <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#entidadModal">
                            Crear entidad
                        </button>
        </div>
    </div>
    
    <div class="fluid-container">
        <div class="row ticket-card mt-3 pb-2 border-bottom pb-3 mb-3">
            
            <div class="ticket-details col-md-9">
                <div class="container container-custom" style="border: 1px solid #fff;">
                    <div>
                        <br />
                        
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
                        <!-- Modal editar usuario-->
                        <div class="modal fade" id="editarUsuarioModal" tabindex="-1" role="dialog" aria-labelledby="entidadModalLabel" aria-hidden="true">
                            <div class="modal-dialog" role="document">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h5 class="modal-title" id="editarUsuarioModalLabel">Editar usuario</h5>
                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                            <span aria-hidden="true">&times;</span>
                                        </button>
                                    </div>
                                    <div class="modal-body">
                                        <div class="form-group">
                                            <label for="txtNombre">Nombre</label>
                                            <input type="text" class="form-control" id="editNombre" runat="server" autocomplete="off" maxlength="80" placeholder="Ingrese nombre" />
                                            <small class="form-text text-muted">Edite el nombre del usuario.</small>
                                        </div>
                                        <div class="form-group">
                                            <label for="txtContra">DNI</label>
                                            <input type="text" class="form-control" id="editDNI" runat="server" autocomplete="off" maxlength="80" placeholder="Ingrese DNI" />
                                            <small class="form-text text-muted">Edite el DNI del usuario.</small>
                                        </div>
                                    </div>
                                    <div class="modal-footer">
                                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                                        <asp:Button class="btn btn-lg btn-primary" ID="Button1" runat="server" Text="Nueva entidad" OnClick="Submit_nuevo_entidad" />
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
                        <div class="table*responsive">
                            <asp:GridView ID="GridView1" runat="server" AllowPaging="true" OnSelectedIndexChanged = "OnSelectedIndexChanged"
                                OnPageIndexChanging="GridView1_PageIndexChanging" Class="table table-hover table-striped table-bordered" 
                                PageSize="20" AutoGenerateColumns="false">
                            <Columns>
                                <asp:TemplateField>
    <ItemTemplate>
        <%# Container.DataItemIndex + 1 %>
    </ItemTemplate>
</asp:TemplateField>
                                <asp:BoundField ItemStyle-Width="15%" DataField="DetCodigo" HeaderText="Usuario" />
                                <asp:BoundField ItemStyle-Width="30%" DataField="DetNombre" HeaderText="Nombre completo" />
                                <asp:BoundField ItemStyle-Width="30%" DataField="RazonSocialEntidad" HeaderText="Entidad" />
                                <asp:BoundField ItemStyle-Width="15%" DataField="FecRegistro" HeaderText="Fecha de registro" />
                                <asp:ButtonField ItemStyle-Width="10%" Text="Editar usuario" CommandName="Select"/>
                               <asp:TemplateField ShowHeader="false">
                            <ItemTemplate>
                                <asp:LinkButton ID="userProfile" runat="server" OnCommand="userProfile_Command"
   CommandArgument='<%# Eval("Id") %>'
   Text="Open User Profile" CssClass="btn btn-success"  />
                            </ItemTemplate>
                        </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                            
                        </div>
                        
                        <br />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
