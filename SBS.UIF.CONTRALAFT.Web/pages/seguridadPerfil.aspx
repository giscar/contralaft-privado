<%@ Page Language="C#" MasterPageFile="plantilla.Master" AutoEventWireup="true" CodeBehind="perfil.aspx.cs" Inherits="SBS.UIF.CONTRALAFT.Web.pages.perfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphBody" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="form-group">
        <label for="txtNombre">Perfil</label>
        <input type="text" class="form-control" id="txtNombrePerfil" runat="server" autocomplete="off" maxlength="80"
            placeholder="Ingrese perfil" />
        <small class="form-text text-muted">Ingrese el nuevo perfil</small>
    </div>
    <div class="form-group">
        <label for="txtContra">Descripción</label>
        <textarea placeholder="Ingrese descripción" runat="server" autocomplete="off" id="txtDescripcion" class="form-control" ></textarea>
        <small class="form-text text-muted">Ingrese la descripción del perfil</small>
    </div>
    <div class="form-group">
        <asp:Button class="btn btn-lg btn-primary" ID="btnNuevo" runat="server" Text="Crear Perfil"
            OnClick="Submit_nuevo" />
    </div>
    <br />
    <asp:GridView ID="GridView1" runat="server" AllowPaging="true" OnPageIndexChanging="GridView1_PageIndexChanging"
        CssClass="table table-hover table-striped table-bordered" AutoGenerateColumns="false">
        <Columns>
            <asp:TemplateField ItemStyle-Width="10%" HeaderText="Nro">
                <ItemTemplate>
                    <%# Container.DataItemIndex + 1 %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField ItemStyle-Width="40%" DataField="DesTipo" HeaderText="Nombre del Perfil" />
            <asp:BoundField ItemStyle-Width="50%" DataField="DetDetalle" HeaderText="Detalle del Perfil" />
        </Columns>
    </asp:GridView>
    <br />
    <div id="idModalInfoServer" runat="server">
        <div class="modal show" id="idInfoServer">
            <div class="modal-dialog ">
                <div class="modal-content" style="background: #D9EDF7">
                    <div class="modal-header" style="padding: 5px;">
                        <a onclick="cerrarModalInfo()" class="close" data-dismiss="modal" aria-label="Close"><span style="color: red; font-size: large" class="glyphicon glyphicon-remove"></span></a>
                        <p style="color: #3170A5; font-size: 1.5em">Se enviaron los datos</p>
                    </div>
                    <div style="background: white; box-sizing: border-box;">
                        <div class="modal-body" style="padding: 7px;">
                            <table style="width: 100%">
                                <tr>
                                    <td style="padding-right: 8px">
                                        <img style="width: 30px" src="img/info.png" />
                                    </td>
                                    <td>
                                        <div id="mensajeInfo" style="font-size: 1.4em">
                                            <asp:Label ID="lblMensajeOk" runat="server" Text=""></asp:Label>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>