<%@ Page Language="C#" MasterPageFile="plantilla.Master" AutoEventWireup="true" CodeBehind="rol.aspx.cs" Inherits="SBS.UIF.CONTRALAFT.Web.pages.rol" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphBody" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <div class="form-group">
            <label>Rol</label>
            <input type="text" class="form-control txtNombreRol soloLetras" id="txtNombreRol" runat="server" autocomplete="off" maxlength="80" placeholder="Ingrese perfil" />
            <small class="form-text text-muted">Ingrese el nuevo rol</small>
        </div>
        <div class="form-group">
            <label>Descripción</label>
            <textarea class="form-control txtDescripcion" id="txtDescripcion" runat="server" autocomplete="off" maxlength="800" placeholder="Ingrese descripción"></textarea>
            <small class="form-text text-muted">Ingrese la descripción del rol</small>
        </div>
        <div class="form-group">
            <label style="vertical-align: bottom">Seleccione el perfil </label>
            <div class="icheck-square">
                <asp:RadioButtonList id="ddlCodigoPerfil" runat="server" class="ddlCodigoPerfil" AutoPostBack="false" DataValueField="idTipo" DataTextField="DesTipo"/>
            </div>
        </div>
        <div class="form-group">
            <a class="btn btn-primary btn-sm" id="idConfirmacion" data-toggle="modal" style="color: white">Crear Rol<i class="mdi mdi-play-circle ml-1"></i></a>
        </div>
    <br/>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="true" OnPageIndexChanging="GridView1_PageIndexChanging" Class="table table-hover table-striped table-bordered" PageSize="10" AutoGenerateColumns="false">
        <Columns>
            <asp:TemplateField HeaderText="Nro.">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField ItemStyle-Width="20%" DataField="DesTipo" HeaderText="Nombre del Rol" />
            <asp:BoundField ItemStyle-Width="20%" DataField="DetDetalle" HeaderText="Detalle del Rol" />
            <asp:TemplateField ShowHeader="false">
                <ItemTemplate>
                    <a id="selectPerfil" onclick="showEdit(<%# Eval("IdTipo") %>, '<%# Eval("DesTipo") %>', '<%# Eval("DetDetalle") %>')" class="btn btn-success selectPerfil" >Editar</a>
                    <a id="inactivarPerfil" style="color: white" onclick="showInactive(<%# Eval("IdTipo") %>)" class="btn btn-danger inactivePerfil" >Inactivar</a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView> 
    
    <div class="modal fade" id="modal-confirmacion" tabindex="-1" role="dialog" aria-hidden="true">
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
                    <asp:Button class="btn btn-success" ID="btnNuevo" runat="server" Text="Crear Rol" OnClick="Submit_nuevo" />
                    <button type="button" class="btn btn-light" data-dismiss="modal">Cancelar</button>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
    $('#idConfirmacion').click(function () {
        if ($('.txtNombreRol').val().trim() === '') {
            mensaje('Debe ingresar el nombre del rol', 'Alerta');
            $('.txtNombreRol').addClass('form-control-danger')
            return;
        } else {
            $('.txtNombreRol').removeClass('form-control-danger');
        }
        if ($('.txtDescripcion').val().trim() === '') {
            mensaje('Debe ingresar la descripción del rol', 'Alerta');
            $('.txtDescripcion').addClass('form-control-danger')
            return;
        } else {
            $('.txtDescripcion').removeClass('form-control-danger');
        }
        if ($("#<%= ddlCodigoPerfil.ClientID %> input:checked").val()){
            $('#modal-confirmacion').modal('show');
        }else {
            mensaje('Debe seleccionar un perfil', 'Alerta');
        }

        
    })
    </script>
    <script src="/js/pages/rol.js"></script>
</asp:Content>