<%@ Page Language="C#" MasterPageFile="plantilla.Master" AutoEventWireup="true" CodeBehind="adminiatrarPlan.aspx.cs" Inherits="SBS.UIF.CONTRALAFT.Web.pages.adminiatrarPlan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphBody" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        
    <div class="form-group">
        <label for="txtNombre">Título del Plan</label>
        <input type="text" class="form-control soloLetras txtNombrePlan" id="txtNombrePlan" runat="server" autocomplete="off" maxlength="80" placeholder="Ingrese el Plan" style="width: 50%"/>
        <small class="form-text text-muted txtNombrePlanLabel">Ingrese el título de la nueva versión del Plan</small>
    </div>
    <div class="form-group">
        <label for="txtContra">Descripción</label>
        <textarea class="form-control txtDescripcion" id="txtDescripcion" runat="server" autocomplete="off" maxlength="800" placeholder="Ingrese descripción"></textarea>
        <small class="form-text text-muted txtDescripcionLabel">Ingrese la descripción del Plan</small>
    </div>
    
    <div class="form-group">
        <a class="btn btn-primary btn-sm" id="idConfirmacion" data-toggle="modal" style="color: white">Crear Versión del Plan<i class="mdi mdi-play-circle ml-1"></i></a> 
    </div>
    <br />
   
<ContentTemplate> 
    <asp:GridView ID="GridView1" runat="server" AllowPaging="true" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridPlan_RowCommand" Class="table table-hover table-striped table-bordered" PageSize="10" AutoGenerateColumns="false">
        <Columns>
            <asp:TemplateField HeaderText="Nro.">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField ItemStyle-Width="20%" DataField="Nombre" HeaderText="Plan" />
            <asp:BoundField ItemStyle-Width="40%" DataField="Descripcion" HeaderText="Descripción del Plan" />
            <asp:TemplateField ShowHeader="false">
                <ItemTemplate>
                    <asp:LinkButton runat="server" CssClass="btn btn-success" CommandArgument='<%# Eval("Id") %>' CommandName="editarPlan" >Editar</asp:LinkButton>
                    <asp:LinkButton runat="server" CssClass="btn btn-danger" CommandArgument='<%# Eval("Id") %>' CommandName="inactivarPlan" >Eliminar</asp:LinkButton>    
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    </ContentTemplate>
    <!-- modal editar -->
    <div class="modal fade" id="editarPlan" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Editar Plan</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label for="recipient-name" class="col-form-label">Titulo:</label>
                        <input type="text" class="form-control txtEditarNombre" Id="txtEditarNombre" runat="server" autocomplete="off" maxlength="80" placeholder="Ingrese Titulo del Plan">
                    </div>
                    <div class="form-group">
                        <label for="message-text" class="col-form-label">Descripción:</label>
                        <textarea class="form-control txtEditarDescripcion" Id="txtEditarDescripcion" rows="8" runat="server" autocomplete="off" maxlength="800" placeholder="Ingrese descripción"></textarea>
                        <small class="form-text text-muted txtEditarDescripcionLabel">Ingrese descripción del plan</small>
                    </div>  
                </div>
                <div class="modal-footer">
                    <asp:Button class="btn btn-success" ID="btnSeleccionar" runat="server" Text="Modificar Plan" OnClientClick="return validaEditarPerfilClient()" OnClick="Submit_edit" />
                    <button type="button" class="btn btn-light" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
     </div>
    <!-- modal confirmacion -->
    <div class="modal fade" id="confirmacion" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-sm" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel-3">Ventana de Confirmación</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <p>Esta seguro de crear un nuevo Plan?.</p>
                </div>
                <div class="modal-footer">
                    <asp:Button class="btn btn-success" ID="btnNuevo" runat="server" Text="Crear Plan" OnClick="Submit_nuevo" />
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
                    <h5 class="modal-title" id="exampleModalLabel-3">Ventana de Confirmación</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <p>Esta seguro de inactivar el plan.</p>
                </div>
                <div class="modal-footer">
                    <asp:Button class="btn btn-danger" ID="btnInactive" runat="server" Text="Inactivar Plan" OnClick="Submit_inactive" />
                    <button type="button" class="btn btn-light" data-dismiss="modal">Cancelar</button>
                </div>
            </div>
        </div>
    </div>
   <script src="/js/pages/administrarPlan.js"></script>
</asp:Content>