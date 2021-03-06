﻿<%@ Page Language="C#" MasterPageFile="plantilla.Master" AutoEventWireup="true" CodeBehind="adminiatrarPlan.aspx.cs" Inherits="SBS.UIF.CONTRALAFT.Web.pages.adminiatrarPlan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphBody" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <style>
        .divTablePlan td {
            padding: 5px;
        }

        .divTablePlan th {
            padding: 10px;
        }
    </style>        
    <div class="form-group">
        <label for="txtNombre">Título del Plan</label>
        <input type="text" class="form-control txtNombrePlan" id="txtNombrePlan" runat="server" autocomplete="off" maxlength="80" placeholder="Ingrese el Plan" style="width: 50%"/>
        <small class="form-text text-muted txtNombrePlanLabel">Ingrese el título de la nueva versión del Plan</small>
    </div>
    <div class="form-group">
        <label for="txtContra">Descripción</label>
        <textarea class="form-control txtDescripcion" id="txtDescripcion" runat="server" autocomplete="off" maxlength="800" placeholder="Ingrese"></textarea>
        <small class="form-text text-muted txtDescripcionLabel">Ingrese la descripción del Plan</small>
    </div>
    
    <div class="form-group">
        <a class="btn btn-primary btn-sm" id="idConfirmacion" data-toggle="modal" style="color: white">Crear Versión del Plan</a> 
    </div>
    <br />
   
    <ContentTemplate> 
        <asp:GridView ID="GridView1" runat="server" AllowPaging="true" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridPlan_RowCommand" Class="table table-bordered divTablePlan" PageSize="10" AutoGenerateColumns="false">
            <Columns>
                <asp:TemplateField HeaderText="Nro." ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField ItemStyle-Width="25%" DataField="Nombre" HeaderText="Plan" />
                <asp:BoundField ItemStyle-Width="30%" DataField="Descripcion" HeaderText="Descripción del Plan" />
                <asp:BoundField ItemStyle-Width="10%" DataField="EstadoDescripcion" HeaderText="Estado" />    
                <asp:BoundField ItemStyle-Width="5%" DataField="Version" HeaderText="Versión" /> 
                <asp:BoundField ItemStyle-Width="10%" DataField="VigenteDetalle" HeaderText="Vigente" /> 
                <asp:TemplateField ShowHeader="false" ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <div class="row">
                            <div style="padding-right:5px; padding-left:20px">
                                <asp:LinkButton runat="server" Visible='<%# Eval("EstadoVisualizacionEditar") %>' CssClass="btn btn-icons btn-inverse-secondary" ToolTip="Editar" CommandArgument='<%# Eval("Id") %>' CommandName="editarPlan" ><i class="mdi mdi-pencil"></i></asp:LinkButton>
                            </div>  
                            <div style="padding-right:5px">
                                <asp:LinkButton runat="server" Visible='<%# Eval("EstadoVisualizacionInactivar") %>' CssClass="btn btn-icons btn-inverse-danger" ToolTip="Eliminar" CommandArgument='<%# Eval("Id") %>' CommandName="inactivarPlan" ><i class="mdi mdi-delete"></i></asp:LinkButton>  
                            </div>
                            <div>
                                <asp:LinkButton runat="server" Visible='<%# Eval("EstadoVisualizacionPublicar") %>' CssClass="btn btn-icons btn-inverse-primary" ToolTip="Publicar" CommandArgument='<%# Eval("Id") %>' CommandName="publicarPlan" ><i class="mdi mdi-check"></i></asp:LinkButton>     
                            </div> 
                        </div>        
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
                        <label for="recipient-name" class="col-form-label">Título:</label>
                        <input type="text" class="form-control txtEditarNombre" Id="txtEditarNombre" runat="server" autocomplete="off" maxlength="80" placeholder="Ingrese Título del Plan">
                        <small class="form-text text-muted txtEditarDescripcionLabel">Ingrese título del Plan</small>
                    </div>
                    <div class="form-group">
                        <label for="message-text" class="col-form-label">Descripción:</label>
                        <textarea class="form-control txtEditarDescripcion" Id="txtEditarDescripcion" rows="8" runat="server" autocomplete="off" maxlength="800" placeholder="Ingrese descripción"></textarea>
                        <small class="form-text text-muted txtEditarDescripcionLabel">Ingrese descripción del Plan</small>
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
                    <h5 class="modal-title">Ventana de Confirmación</h5>
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
                    <h5 class="modal-title">Ventana de Confirmación</h5>
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
    <!-- modal publicar -->
    <div class="modal fade" id="publicar" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-sm" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Ventana de Confirmación</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <p>Esta seguro de publicar el plan.</p>
                </div>
                <div class="modal-footer">
                    <asp:Button class="btn btn-primary" ID="btnPublicar" runat="server" Text="Publicar Plan" OnClick="Submit_publicar" />
                    <button type="button" class="btn btn-light" data-dismiss="modal">Cancelar</button>
                </div>
            </div>
        </div>
    </div>
    <!-- modal publicar Nuevo-->
    <div class="modal fade" id="publicarNuevo" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-sm" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Ventana de Confirmación</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <p>Esta seguro de publicar el nuevo Plan? tener en cuenta que el Plan anteior dejare de estar activo, esta accion no se puede revertir.</p>
                </div>
                <div class="modal-footer">
                    <asp:Button class="btn btn-primary" ID="btnPublicarNuevo" runat="server" Text="Publicar Plan" OnClick="Submit_publicar_nuevo" />
                    <button type="button" class="btn btn-primart" data-dismiss="modal">Cancelar</button>
                </div>
            </div>
        </div>
    </div>
   <script src="/js/pages/administrarPlan.js"></script>
</asp:Content>