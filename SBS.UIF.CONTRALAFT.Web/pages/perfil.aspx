<%@ Page Language="C#" MasterPageFile="plantilla.Master" AutoEventWireup="true" CodeBehind="perfil.aspx.cs" Inherits="SBS.UIF.CONTRALAFT.Web.pages.perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphBody" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>




    <div class="form-group">
                            <label for="txtNombre">Perfil</label>
                            <input type="text" class="form-control soloLetras txtNombrePerfil" id="txtNombrePerfil" runat="server" autocomplete="off" maxlength="80" placeholder="Ingrese perfil" />
                            <small class="form-text text-muted">Ingrese el nuevo perfil</small>
                        </div>
                        <div class="form-group">
                            <label for="txtContra">Descripción</label>
                            <input type="text" class="form-control txtDescripcion" id="txtDescripcion" runat="server" autocomplete="off" maxlength="80" placeholder="Ingrese descripción" />
                            <small class="form-text text-muted">Ingrese la descripción del perfil</small>
                        </div>
                       <div class="form-group">
                            <a class="btn btn-primary btn-sm" id="idConfirmacion" data-toggle="modal">Crear Perfil<i class="mdi mdi-play-circle ml-1"></i></a>
                        
                        </div>
    <br />
        
        <asp:GridView ID="GridView1" runat="server" AllowPaging="true" OnPageIndexChanging="GridView1_PageIndexChanging" CssClass="table table-hover">
        </asp:GridView>
        <br />
    
    
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
                  <!-- Modal Ends -->
                  <div class="modal fade" id="modal-alerta" tabindex="-1" role="dialog" aria-hidden="true">
                    <div class="modal-dialog modal-sm" role="document">
                      <div class="modal-content">
                        <div class="modal-header">
                          <h5 class="modal-title" id="exampleModalLabel-3">Ventana de Alerta</h5>
                          <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                          </button>
                        </div>
                        <div class="modal-body">
                          <p id="mensaje"></p>
                        </div>
                        <div class="modal-footer">
                          <button type="button" class="btn btn-light" data-dismiss="modal">Aceptar</button>
                        </div>
                      </div>
                    </div>
                  </div>

                     <script src="/js/pages/perfil.js"></script>
    </asp:Content>