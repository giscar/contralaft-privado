<%@ Page Language="C#" MasterPageFile="plantilla.Master" AutoEventWireup="true" CodeBehind="usuario.aspx.cs" Inherits="SBS.UIF.CONTRALAFT.Web.pages.usuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphBody" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <style>
    .divTableUsuarios td {
        padding: 5px;
    }

    .divTableUsuarios th {
        padding: 10px;
    }
    </style>
    <div class="row">
        <div class="col-md-8">
            <h5 class="card-title mb-4">usuarios activos</h5>
        </div>
        <div class="col-md-4">
            <asp:Button class="btn btn-primary" ID="btnNuevoUsuario" runat="server" Text="Crear usuario" OnClick="Modal_nuevo_usuario" />
            <asp:Button class="btn btn-warning" ID="btnNuevoEntidad" runat="server" Text="Crear Entidad" OnClick="Modal_nuevo_entidad" />
        </div>
    </div>
    <div>
        <br />
        <asp:GridView ID="GridView1" runat="server" AllowPaging="true" Class="table table-bordered divTableUsuarios" PageSize="20" AutoGenerateColumns="false" OnRowCommand="GridUsuario_RowCommand" style="width:100%">
            <Columns>
                <asp:BoundField ItemStyle-Width="10%" DataField="DetCodigo" HeaderText="Usuario" />
                <asp:BoundField ItemStyle-Width="20%" DataField="DetNombre" HeaderText="Nombre completo" />
                <asp:BoundField ItemStyle-Width="30%" DataField="RazonSocialEntidad" HeaderText="Entidad" />
                <asp:BoundField ItemStyle-Width="10%" DataField="FecRegistro" HeaderText="Fecha de registro" />
                <asp:BoundField ItemStyle-Width="10%" DataField="NombrePerfil" HeaderText="Perfil" />
                <asp:TemplateField HeaderText="Documento" ItemStyle-Width="10%">
                    <ItemTemplate>
                        <asp:LinkButton runat="server" CommandArgument='<%# Eval("CodDocumento") %>' CommandName="downloadDocumento" >Descargar</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="false" ItemStyle-Width="10%">
                    <ItemTemplate>
                        <div class="row" style="padding: 15px">
                            <div style="padding-right:5px">
                                <asp:LinkButton runat="server" CssClass="btn btn-icons btn-inverse-primary" ToolTip="Editar" CommandArgument='<%# Eval("Id") %>' CommandName="editarUsuario" ><i class="mdi mdi-pencil"></i></asp:LinkButton>
                            </div>  
                            <div >
                                <asp:LinkButton runat="server" CssClass="btn btn-icons btn-inverse-danger" ToolTip="Eliminar" CommandArgument='<%# Eval("Id") %>' CommandName="eliminarUsuario" ><i class="mdi mdi-delete"></i></asp:LinkButton> 
                            </div> 
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
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
                            <label for="txtNombre">DNI</label>
                            <input type="text" class="form-control txtDocumento soloNumeros" ID="txtDocumento" runat="server" autocomplete="off" maxlength="8" placeholder="Ingrese el documento" />
                            <small class="form-text text-muted txtDocumentoLabel">Ingrese el documento de identidad</small>
                        </div>
                        <div class="form-group">
                            <label style="vertical-align: bottom">Perfil</label>
                            <asp:DropDownList class="form-control ddlCodigoPerfil" ID="ddlCodigoPerfil" runat="server" DataValueField="idTipo" DataTextField="DesTipo" AutoPostBack="true" OnSelectedIndexChanged="DDlCodigoPerfil_SelectedIndexChanged"></asp:DropDownList>
                            <small class="form-text text-muted ddlCodigoPerfilLabel">Ingrese el perfil del usuario</small>
                        </div>
                        <div class="form-group">
                            <label for="txtNombre">Nombre Completo</label>
                            <input type="text" class="form-control txtNombre" ID="txtNombre" runat="server" autocomplete="off" maxlength="80" placeholder="Ingrese usuario" />
                            <small class="form-text text-muted txtNombreLabel">Ingrese el nombre completo del usuario</small>
                        </div>
                        <div class="form-group">
                            <label for="txtContra">Correo Electrónico</label>
                            <input type="text" class="form-control txtEmail" ID="txtEmail" runat="server" autocomplete="off" maxlength="200" placeholder="Ingrese correo" />
                            <small class="form-text text-muted txtEmailLabel">Ingrese el correo electrónico el formato debe ser valido</small>
                        </div>
                        <div class="form-group">
                            <label>Documento de creación</label>
                            <input type="file" id="fileDocumento" name="fileDocumento" class="file-upload-default fileDocumento">
                            <div class="input-group col-xs-12">
                                <input type="text" class="form-control file-upload-info" disabled="disabled" placeholder="Subir documento">
                                <span class="input-group-append">
                                    <button class="file-upload-browse btn btn-info" type="button">Cargar al sistema</button>
                                </span>
                            </div>
                            <small class="form-text text-muted fileDocumentoLabel">Ingrese el documento de sustento</small>
                        </div>                                        
                        <asp:UpdatePanel ID="upEntidad" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div class="form-group" ID="divEntidad" runat="server">
                                    <label style="vertical-align: bottom">Entidad</label>
                                    <asp:DropDownList class="form-control ddlCodigoEntidad" ID="ddlCodigoEntidad" runat="server" DataValueField="idTipo" DataTextField="DesTipo"></asp:DropDownList>
                                    <small class="form-text text-muted ddlCodigoEntidadLabel">Ingrese la entidad a la que pertenece el usuario</small>
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ddlCodigoPerfil" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>         
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                        <asp:Button class="btn btn-lg btn-primary btnNuevo" OnClientClick="return validaCrearUsuarioClient()" ID="btnNuevo" runat="server" Text="Nuevo usuario" OnClick="Submit_nuevo_usuario" />
                    </div>
                </div>
            </div>
        </div>
        <!-- Modal editar usuario-->
        <div class="modal fade" id="editarUsuarioModal" tabindex="-1" role="dialog" aria-labelledby="entidadModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Editar usuario</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="form-group">
                            <label for="txtContra">DNI</label>
                            <input type="text" class="form-control soloNumeros" ID="DNIedit" readonly="readonly" runat="server" autocomplete="off" maxlength="8" placeholder="Ingrese DNI" />
                        </div>
                        <div class="form-group">
                            <label style="vertical-align: bottom">Perfil</label>
                            <asp:DropDownList class="form-control ddlCodigoPerfilEdit" ID="ddlCodigoPerfilEdit" runat="server" DataValueField="idTipo" DataTextField="DesTipo" AutoPostBack="true" OnSelectedIndexChanged="DDlCodigoPerfilEdit_SelectedIndexChanged"></asp:DropDownList>
                            <small class="form-text text-muted ddlCodigoPerfilEditLabel">Ingrese el perfil del usuario</small>
                        </div>
                        <div class="form-group">
                            <label for="txtNombre">Nombre</label>
                            <input type="text" class="form-control nombreEdit" ID="nombreEdit" runat="server" autocomplete="off" maxlength="80" placeholder="Ingrese nombre" />
                            <small class="form-text text-muted nombreEditLabel">Edite el nombre del usuario.</small>
                        </div>
                        <div class="form-group">
                            <label for="txtContra">Correo Electrónico</label>
                            <input type="text" class="form-control txtEmailEdit" ID="txtEmailEdit" runat="server" autocomplete="off" maxlength="200" placeholder="Ingrese correo" />
                            <small class="form-text text-muted txtEmailEditLabel">Ingrese el correo electrónico el formato debe ser valido</small>
                        </div>
                        <asp:UpdatePanel ID="upEntidadEdit" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div class="form-group" ID="divEntidadEdit" runat="server">
                                    <label style="vertical-align: bottom">Entidad</label>
                                    <asp:DropDownList class="form-control" ID="ddlCodigoEntidadEdit" runat="server" DataValueField="idTipo" DataTextField="DesTipo"></asp:DropDownList>
                                    <small class="form-text text-muted ddlCodigoPerfilEditLabel">Ingrese la entidad a la que pertenece el usuario</small>
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ddlCodigoPerfilEdit" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                        <asp:Button class="btn btn-lg btn-primary" ID="Button1" runat="server" Text="Editar usuario" OnClientClick="return validaEditarUsuarioClient()" OnClick="Submit_editar_usuario" />
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
                            <input type="text" class="form-control txtEntidad" id="txtEntidad" runat="server" autocomplete="off" maxlength="80" placeholder="Ingrese entidad" />
                            <small class="form-text text-muted">Ingrese el nombre de la entidad.</small>
                        </div>
                        <div class="form-group">
                            <label for="txtContra">RUC</label>
                            <input type="text" class="form-control soloNumeros txtRuc" id="txtRuc" runat="server" autocomplete="off" maxlength="11" placeholder="Ingrese RUC" />
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
        <!-- Modal inactivacion-->
        <div class="modal fade" id="inactivacion" tabindex="-1" role="dialog" aria-hidden="true">
            <div class="modal-dialog modal-sm" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Ventana de Confirmación</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <p>Esta seguro de inactivar el usuario.</p>
                    </div>
                    <div class="modal-footer">
                        <asp:Button class="btn btn-danger" ID="btnInactive" runat="server" Text="Inactivar" OnClick="Submit_inactive" />
                        <button type="button" class="btn btn-light" data-dismiss="modal">Cancelar</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="/js/pages/usuario.js"></script>
</asp:Content>
