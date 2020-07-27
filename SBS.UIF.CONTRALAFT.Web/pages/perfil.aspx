<%@ Page Language="C#" MasterPageFile="plantilla.Master" AutoEventWireup="true" CodeBehind="perfil.aspx.cs" Inherits="SBS.UIF.CONTRALAFT.Web.pages.perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphBody" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        
    <div class="form-group">
        <label for="txtNombre">Perfil</label>
        <input type="text" class="form-control soloLetras txtNombrePerfil" id="txtNombrePerfil" runat="server" autocomplete="off" maxlength="80" placeholder="Ingrese perfil" style="width: 50%"/>
        <small class="form-text text-muted">Ingrese el nuevo perfil</small>
    </div>
    <div class="form-group">
        <label for="txtContra">Descripción</label>
        <input type="text" class="form-control txtDescripcion" id="txtDescripcion" runat="server" autocomplete="off" maxlength="80" placeholder="Ingrese descripción" />
        <small class="form-text text-muted">Ingrese la descripción del perfil</small>
    </div>
    <div class="form-group">
        <a class="btn btn-primary btn-sm" id="idConfirmacion" data-toggle="modal" style="color: white">Crear Perfil<i class="mdi mdi-play-circle ml-1"></i></a> 
    </div>
    <br />
    
    <asp:GridView ID="GridView1" runat="server" AllowPaging="true" OnPageIndexChanging="GridView1_PageIndexChanging" Class="table table-hover table-striped table-bordered" 
                                PageSize="10" AutoGenerateColumns="false">
                            <Columns>
                                <asp:TemplateField HeaderText="Nro.">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField ItemStyle-Width="30%" DataField="DesTipo" HeaderText="Nombre del Perfil" />
                                <asp:BoundField ItemStyle-Width="50%" DataField="DetDetalle" HeaderText="Detalle del Perfil" />
                                <asp:TemplateField ShowHeader="false">
                                    <ItemTemplate>
                                        <a id="selectPerfil" onclick="showEdit(<%# Eval("IdTipo") %>, '<%# Eval("DesTipo") %>', '<%# Eval("DetDetalle") %>')" class="btn btn-success selectPerfil" >Editar</a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
   
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
                            <input type="hidden" class="txtId" id="txtId" runat="server"/>
                            <div class="form-group">
                              <label for="recipient-name" class="col-form-label">Perfil:</label>
                                <input type="text" class="form-control txtEditarPerfil" id="txtEditarPerfil" runat="server" autocomplete="off" maxlength="80" placeholder="Ingrese perfil">
                              </div>
                            <div class="form-group">
                              <label for="message-text" class="col-form-label">Descripción:</label>
                              <textarea class="form-control txtEditarDescripcion" id="txtEditarDescripcion" runat="server" autocomplete="off" maxlength="80" placeholder="Ingrese descripción"></textarea>
                            </div>
                         
                        </div>
                        <div class="modal-footer">
                          <asp:Button class="btn btn-success" ID="btnSeleccionar" runat="server" Text="Modificar Perfil" OnClick="Submit_edit" />
                          <button type="button" class="btn btn-light" data-dismiss="modal">Cerrar</button>
                        </div>
                      </div>
                    </div>
                  </div>

    
    <div class="modal fade" id="modal-confirmacion" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog modal-sm" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel-3">Ventana de Confirmación</h5>
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
   
   <script src="/js/pages/perfil.js"></script>
</asp:Content>