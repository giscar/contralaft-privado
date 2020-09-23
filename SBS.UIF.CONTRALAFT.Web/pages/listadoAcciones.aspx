<%@ Page Language="C#" MasterPageFile="plantilla.Master" AutoEventWireup="true" CodeBehind="listadoAcciones.aspx.cs" Inherits="SBS.UIF.CONTRALAFT.Web.pages.listadoAcciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphBody" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <h5 class="card-title mb-4">Acciones del Plan</h5>
    <br/>
    <div class="form-group">
        <label>Número</label>
        <input type="text" class="form-control soloLetras txtCodigoAccion" id="txtCodigoAccion" runat="server" autocomplete="off" maxlength="80" placeholder="Ingrese el número de la Acción" style="width: 50%"/>
        <small class="form-text text-muted txtCodigoAccionLabel">Ingrese el código de la Acción</small>
    </div>
    <div class="form-group">
        <label>Acción</label>
        <textarea class="form-control txtAccion" id="txtAccion" runat="server" autocomplete="off" maxlength="800" placeholder="Ingrese la Acción"></textarea>
        <small class="form-text text-muted txtAccionLabel">Ingrese la acción</small>
    </div>
    <div class="form-group">
        <label>Descripción</label>
        <textarea class="form-control txtDescripcion" id="txtDescripcion" runat="server" autocomplete="off" maxlength="800" placeholder="Ingrese descripción"></textarea>
        <small class="form-text text-muted txtDescripcionLabel">Ingrese la descripción de la acción</small>
    </div>
    <div class="form-group">
        <a class="btn btn-primary btn-sm" id="idConfirmacion" data-toggle="modal" style="color: white">Crear Acción<i class="mdi mdi-play-circle ml-1"></i></a> 
    </div>
    
    <asp:GridView ID="GridView1" runat="server" AllowPaging="true" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridAccion_RowCommand" Class="table table-hover table-striped table-bordered" PageSize="10" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField ItemStyle-Width="10%" DataField="Codigo" HeaderText="Codigo" />
            <asp:BoundField ItemStyle-Width="20%" DataField="Nombre" HeaderText="Acción" />
            <asp:BoundField ItemStyle-Width="60%" DataField="Descripcion" HeaderText="Descripcion" />
            <asp:TemplateField ShowHeader="false">
                <ItemTemplate>
                    <asp:LinkButton runat="server" CssClass="btn btn-success" CommandArgument='<%# Eval("Id") %>' CommandName="editar" >Editar</asp:LinkButton>
                    <asp:LinkButton runat="server" CssClass="btn btn-danger" CommandArgument='<%# Eval("Id") %>' CommandName="inactivar" >Eliminar</asp:LinkButton> 
                    <asp:LinkButton runat="server" CssClass="btn btn-primary" CommandArgument='<%# Eval("Id") %>' CommandName="agregar" >Agregar Indicador</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <!-- modal editar -->
    <div class="modal fade" id="editar" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Editar Acción</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label for="recipient-name" class="col-form-label">Codigo:</label>
                        <input type="text" class="form-control txtEditarCodigoAccion" Id="txtEditarCodigoAccion" runat="server" autocomplete="off" maxlength="80" placeholder="Ingrese perfil">
                    </div>
                    <div class="form-group">
                        <label for="txtContra">Acción</label>
                        <textarea class="form-control txtEditarAccion" id="txtEditarAccion" runat="server" autocomplete="off" maxlength="800" placeholder="Ingrese la Acción"></textarea>
                        <small class="form-text text-muted txtEditarAccionLabel">Ingrese la acción</small>
                    </div>
                    <div class="form-group">
                        <label for="message-text" class="col-form-label">Descripción:</label>
                        <textarea class="form-control txtEditarDescripcion" Id="txtEditarDescripcion" rows="8" runat="server" autocomplete="off" maxlength="800" placeholder="Ingrese descripción"></textarea>
                        <small class="form-text text-muted txtEditarDescripcionLabel">Ingrese el nuevo perfil</small>
                    </div>  
                </div>
                <div class="modal-footer">
                    <asp:Button class="btn btn-success" ID="btnSeleccionar" runat="server" Text="Modificar Perfil" OnClientClick="return validaEditarAccionClient()" OnClick="Submit_edit" />
                    <button type="button" class="btn btn-light" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
     </div>
    <!-- modal indicador -->
    <div class="modal fade" id="indicador" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Agregar Indicador</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label for="recipient-name" class="col-form-label">Codigo:</label>
                        <input type="text" class="form-control txtEditarCodigoAccion" Id="txtEditarCodigoAccion" runat="server" autocomplete="off" maxlength="80" placeholder="Ingrese perfil">
                    </div>
                    <div class="form-group">
                        <label for="txtContra">Acción</label>
                        <textarea class="form-control txtEditarAccion" id="txtEditarAccion" runat="server" autocomplete="off" maxlength="800" placeholder="Ingrese la Acción"></textarea>
                        <small class="form-text text-muted txtEditarAccionLabel">Ingrese la acción</small>
                    </div>
                    <div class="form-group">
                        <label for="message-text" class="col-form-label">Descripción:</label>
                        <textarea class="form-control txtEditarDescripcion" Id="txtEditarDescripcion" rows="8" runat="server" autocomplete="off" maxlength="800" placeholder="Ingrese descripción"></textarea>
                        <small class="form-text text-muted txtEditarDescripcionLabel">Ingrese el nuevo perfil</small>
                    </div>  
                </div>
                <div class="modal-footer">
                    <asp:Button class="btn btn-success" ID="btnSeleccionar" runat="server" Text="Modificar Perfil" OnClientClick="return validaEditarAccionClient()" OnClick="Submit_edit" />
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
                    <p>Esta seguro de registrar la acción.</p>
                </div>
                <div class="modal-footer">
                    <asp:Button class="btn btn-success" ID="btnNuevo" runat="server" Text="Crear Acción" OnClick="Submit_nuevo" />
                    <button type="button" class="btn btn-light" data-dismiss="modal">Cancelar</button>
                </div>
            </div>
        </div>
    </div>
    <!-- modal inactivar -->
    <div class="modal fade" id="inactivar" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-sm" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Ventana de Confirmación</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <p>Esta seguro de inactivar la acción.</p>
                </div>
                <div class="modal-footer">
                    <asp:Button class="btn btn-danger" ID="btnInactive" runat="server" Text="Inactivar Acción" OnClick="Submit_inactive" />
                    <button type="button" class="btn btn-light" data-dismiss="modal">Cancelar</button>
                </div>
            </div>
        </div>
    </div>
    <script src="/js/pages/listadoAcciones.js"></script>
    </asp:Content>