<%@ Page Language="C#" MasterPageFile="plantilla.Master" AutoEventWireup="true" CodeBehind="perfil.aspx.cs" Inherits="SBS.UIF.CONTRALAFT.Web.pages.perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphBody" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <style>
        .divTablePerfil td {
            padding: 5px;
        }

        .divTablePerfil th {
            padding: 10px;
        }
    </style>       
    <div class="form-group">
        <label for="txtNombre">Perfil</label>
        <input type="text" class="form-control soloLetras txtNombrePerfil" id="txtNombrePerfil" runat="server" autocomplete="off" maxlength="80" placeholder="Ingrese perfil" style="width: 50%"/>
        <small class="form-text text-muted txtNombrePerfilLabel">Ingrese el nuevo perfil</small>
    </div>
    <div class="form-group">
        <label for="txtContra">Descripción</label>
        <textarea class="form-control txtDescripcion" id="txtDescripcion" runat="server" autocomplete="off" maxlength="800" placeholder="Ingrese descripción"></textarea>
        <small class="form-text text-muted txtDescripcionLabel">Ingrese la descripción del perfil</small>
    </div>
    <div class="form-group">
        <a class="btn btn-primary btn-sm" id="idConfirmacion" data-toggle="modal" style="color: white">Crear Perfil</a> 
    </div>
    <br />
   
<ContentTemplate> 
    <asp:GridView ID="GridView1" runat="server" AllowPaging="true" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="gridPerfil_RowCommand" Class="table table-bordered divTablePerfil" PageSize="10" AutoGenerateColumns="false">
        <Columns>
            <asp:TemplateField HeaderText="Nro." ItemStyle-Width="5%">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField ItemStyle-Width="30%" DataField="DesTipo" HeaderText="Nombre del Perfil" />
            <asp:BoundField ItemStyle-Width="50%" DataField="DetDetalle" HeaderText="Detalle del Perfil" />
            <asp:TemplateField ShowHeader="false" ItemStyle-Width="15%">
                <ItemTemplate>
                    <div class="row" style="padding: 15px">
                        <div style="padding-right:5px">
                            <asp:LinkButton runat="server" CssClass="btn btn-icons btn-inverse-primary" ToolTip="Editar" CommandArgument='<%# Eval("IdTipo") %>' CommandName="editarPerfil" ><i class="mdi mdi-pencil"></i></asp:LinkButton>
                        </div>  
                        <div >
                            <asp:LinkButton runat="server" CssClass="btn btn-icons btn-inverse-danger" ToolTip="Eliminar" CommandArgument='<%# Eval("IdTipo") %>' CommandName="eliminarPerfil" ><i class="mdi mdi-delete"></i></asp:LinkButton> 
                        </div> 
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    </ContentTemplate>
    <!-- modal editar -->
    <div class="modal fade" id="editarPerfil" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Editar Perfil</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label for="recipient-name" class="col-form-label">Perfil:</label>
                        <input type="text" class="form-control txtEditarPerfil" Id="txtEditarPerfil" readonly="true" runat="server" autocomplete="off" maxlength="80" placeholder="Ingrese perfil">
                    </div>
                    <div class="form-group">
                        <label for="message-text" class="col-form-label">Descripción:</label>
                        <textarea class="form-control txtEditarDescripcion" Id="txtEditarDescripcion" rows="8" runat="server" autocomplete="off" maxlength="800" placeholder="Ingrese descripción"></textarea>
                        <small class="form-text text-muted txtEditarDescripcionLabel">Ingrese el nuevo perfil</small>
                    </div>  
                </div>
                <div class="modal-footer">
                    <asp:Button class="btn btn-success" ID="btnSeleccionar" runat="server" Text="Modificar Perfil" OnClientClick="return validaEditarPerfilClient()" OnClick="Submit_edit" />
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
     </div>
    <!-- modal confirmacion -->
    <div class="modal fade" id="confirmacion" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-sm" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Ventana de Confirmación</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <p>Esta seguro de registrar el nuevo perfil.</p>
                </div>
                <div class="modal-footer">
                    <asp:Button class="btn btn-success" ID="btnNuevo" runat="server" Text="Crear Perfil" OnClick="Submit_nuevo" />
                    <button type="button" class="btn btn-light" data-dismiss="modal">Cancelar</button>
                </div>
            </div>
        </div>
    </div>
    <!-- modal inactivar -->
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
                    <p>Esta seguro de inactivar el perfil.</p>
                </div>
                <div class="modal-footer">
                    <asp:Button class="btn btn-danger" ID="btnInactive" runat="server" Text="Inactivar Perfil" OnClick="Submit_inactive" />
                    <button type="button" class="btn btn-primary" data-dismiss="modal">Cancelar</button>
                </div>
            </div>
        </div>
    </div>
   <script src="/js/pages/perfil.js"></script>
</asp:Content>