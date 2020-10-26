<%@ Page Language="C#" MasterPageFile="plantilla.Master" AutoEventWireup="true" CodeBehind="listadoIndicadores.aspx.cs" Inherits="SBS.UIF.CONTRALAFT.Web.pages.listadoIndicadores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphBody" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <h5 class="card-title mb-4">Indicadores del Plan</h5>
    <br/>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="true" OnRowCommand="GridAccion_RowCommand" Class="table table-hover table-striped table-bordered" PageSize="10" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField ItemStyle-Width="20%" DataField="Codigo" HeaderText="Código" />
            <asp:BoundField ItemStyle-Width="20%" DataField="Nombre" HeaderText="Acción" />
            <asp:TemplateField  HeaderText="Indicadores">
                <ItemTemplate>
                    <asp:GridView ID="GridView2" ShowHeader="false" runat="server" AutoGenerateColumns="false" DataSource='<%# Bind("ListaIndicadores")%>' >
                        <Columns>
                            <asp:BoundField DataField="Nombre" />
                            <asp:TemplateField  HeaderText="Indicadores">
                                <ItemTemplate>
                                    <asp:GridView ID="GridView3" ShowHeader="false" runat="server" AutoGenerateColumns="false" DataSource='<%# Bind("ListaEntidades")%>' >
                                        <Columns>
                                            <asp:BoundField DataField="DesTipo" />
                                        </Columns>
                                    </asp:GridView>    
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ShowHeader="false">
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" CssClass="btn btn-success" CommandArgument='<%# Eval("Id") %>' CommandName="editar" >Editar</asp:LinkButton>
                                    <asp:LinkButton runat="server" CssClass="btn btn-danger" CommandArgument='<%# Eval("Id") %>' CommandName="inactivar" >Eliminar</asp:LinkButton> 
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>    
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
                        <input type="text" class="form-control txtEditarCodigo" Id="txtEditarCodigo" runat="server" autocomplete="off" maxlength="80" placeholder="Ingrese perfil">
                    </div>
                    <div class="form-group">
                        <label for="txtContra">Acción</label>
                        <textarea class="form-control txtEditarAccion" id="txtEditarAccion" runat="server" autocomplete="off" maxlength="800" placeholder="Ingrese la Acción"></textarea>
                        <small class="form-text text-muted txtEditarAccionLabel">Ingrese la acción</small>
                    </div>
                    <div class="form-group">
                        <label for="message-text" class="col-form-label">Descripción:</label>
                        <textarea class="form-control txtEditarDescripcion" Id="txtEditarDescripcion" rows="8" runat="server" autocomplete="off" maxlength="800" placeholder="Ingrese descripción"></textarea>
                        <small class="form-text text-muted txtEditarDescripcionLabel">Ingrese la descripcion de la acción</small>
                    </div> 
                    
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
                
            </div>
        </div>
    </div>
    <script src="/js/pages/listadoAcciones.js"></script>
    </asp:Content>