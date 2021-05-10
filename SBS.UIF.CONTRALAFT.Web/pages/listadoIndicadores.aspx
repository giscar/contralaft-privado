<%@ Page Language="C#" MasterPageFile="plantilla.Master" AutoEventWireup="true" CodeBehind="listadoIndicadores.aspx.cs" Inherits="SBS.UIF.CONTRALAFT.Web.pages.listadoIndicadores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphBody" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <h5 class="card-title mb-4">Indicadores del Plan</h5>
    <br/>
    <style>
    .divTableEntidades td {
        border-color: white;
        padding: 0px;
    }

    .divTableIndicadores td {
        padding: 5px;
    }

    .divTableAcciones td {
        padding: 5px;
    }
    </style>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="true" OnRowCommand="GridAccion_RowCommand" PageSize="10" AutoGenerateColumns="false" Class="table table-bordered divTableAcciones">
        <Columns>
            <asp:BoundField ItemStyle-Width="10%" DataField="Codigo" HeaderText="Código" />
            <asp:BoundField ItemStyle-Width="15%" DataField="Nombre" HeaderText="Acción" />
            <asp:TemplateField  HeaderText="Indicadores">
                <ItemTemplate>
                    <asp:GridView ID="GridView2" ShowHeader="false" runat="server" AutoGenerateColumns="false" DataSource='<%# Bind("ListaIndicadores")%>' Class="table divTableIndicadores" OnRowCommand="GriIndicador_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="Nombre" ItemStyle-Width="30%"/>
                            <asp:TemplateField  HeaderText="Indicadores" ItemStyle-Width="55%">                                
                                <ItemTemplate style="border:0px;">
                                    <asp:GridView ID="GridView3" ShowHeader="false" runat="server" OnRowCommand="GridAccion2_RowCommand" AutoGenerateColumns="false" DataSource='<%# Bind("ListaEntidades")%>' Class="table divTableEntidades">
                                        <Columns>
                                            <asp:BoundField DataField="DesTipo"/>
                                            <asp:TemplateField ShowHeader="false">
                                                <ItemTemplate>
                                                    <div class="column" style="text-align: right">
                                                        <asp:LinkButton runat="server" CssClass="btn btn-icons btn-inverse-secondary" ToolTip="Ver avance" CommandArgument='<%#Eval("IdTipo") + ";" +Eval("IdIndicador") + ";" +Eval("IdAccion")%>' CommandName="avance" ><i class="mdi mdi-file-find"></i></asp:LinkButton>
                                                    </div> 
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ShowHeader="false" ItemStyle-Width="15%">
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" CssClass="btn btn-icons btn-inverse-primary" ToolTip="Editar" CommandArgument='<%# Eval("Id") %>' CommandName="editar" ><i class="mdi mdi-pencil"></i></asp:LinkButton>
                                    <asp:LinkButton runat="server" CssClass="btn btn-icons btn-inverse-danger" ToolTip="Eliminar" CommandArgument='<%# Eval("Id") %>' CommandName="inactivar" ><i class="mdi mdi-delete"></i></asp:LinkButton> 
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
    <!-- modal resultado -->
    <div class="modal fade" id="resultado" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">
                        <label>Acción: </label>
                        <asp:Label ID="lblAccionTitulo" runat="server"></asp:Label>
                    </h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-header">
                    <h5 class="modal-title">
                        <label>Indicador: </label>
                        <asp:Label ID="lblIndicadorTitulo" runat="server"></asp:Label>
                    </h5>
                    <br/>
                    <h5 class="modal-title">
                        <label>Año: </label>
                        <asp:Label ID="lblIndicadorAnho" runat="server"></asp:Label>
                    </h5>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label class="col-form-label">Medio de verificación:</label>
                        <input type="text" class="form-control txtMedioVerificacion" readonly="true" Id="txtMedioVerificacion" runat="server" autocomplete="off" maxlength="80" placeholder="Ingrese el medio de verificacion">
                    </div>
                    <div class="form-group">
                        <label for="txtContra">Número:</label>
                        <input type="text" class="form-control txtNumero" Id="txtNumero" readonly="true" runat="server" autocomplete="off" maxlength="80" placeholder="Ingrese número" />
                    </div>
                    <div class="form-group">
                        <label for="message-text" class="col-form-label">Descripción:</label>
                        <textarea class="form-control txtDescripcion" Id="txtDescripcion" readonly="true" rows="8" runat="server" autocomplete="off" maxlength="800" placeholder="Ingrese descripción"></textarea>
                    </div> 
                    <div class="form-group" ID="divVisualizarDocumento" runat="server">
                        <label for="message-text" class="col-form-label">Descargar:</label>
                        <a href="<%=rutaDocumento%>" target="_blank">
                            <img src="<%=tipoDocumentoMeta%>" width="50" height="50"></img>
                        </a>
                    </div>
                    <div class="form-group">
                        <label>Estado</label>
                        <select class="form-control">
                            <option>Seleccione estado</option>
                            <option>Pendiente</option>
                            <option>Culminado</option>
                        </select>
                    </div> 
                </div>
                <div class="modal-footer">
                    <asp:Button class="btn btn-success" Id="borradorMeta" runat="server" Text="Guardar Estado" OnClick="Submit_guardar_estado" />
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
                    <h5 class="modal-title">Modificar Indicador</h5>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label for="recipient-name" class="col-form-label">Indicador:</label>
                        <input type="text" class="form-control txtNombreIndicador" id="txtNombreIndicador" runat="server" autocomplete="off" maxlength="80" placeholder="Ingrese el nombre del indicador">
                        <small class="form-text text-muted txtNombreIndicadorLabel">Ingrese el Indicador</small>
                    </div>
                    <div class="form-group">
                        <label for="txtContra">Detalle</label>
                        <textarea class="form-control txtDetalleIndicador" runat="server" id="txtDetalleIndicador" autocomplete="off" maxlength="800" placeholder="Ingrese la Acción"></textarea>
                        <small class="form-text text-muted txtDetalleIndicadorLabel">Ingrese la descripción del indicador</small>
                    </div>
                    <div class="form-group" runat="server">
                        <label style="vertical-align: bottom">Año</label>
                        <asp:DropDownList class="form-control ddlCodigoAnho" ID="ddlCodigoAnho" runat="server" DataValueField="idTipo" DataTextField="DesTipo"></asp:DropDownList>
                        <small class="form-text text-muted dddlCodigoAnhoLabel">Ingrese el año</small>
                    </div>
                    <asp:UpdatePanel id="upSeccionEntidad" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="form-group" ID="divEntidad" runat="server">
                                <label style="vertical-align: bottom">Entidad</label>
                                    <div class="input-group">
                                    <asp:DropDownList class="form-control ddlCodigoEntidad" ID="ddlCodigoEntidad" runat="server" DataValueField="idTipo" DataTextField="DesTipo"></asp:DropDownList>
                                    <div class="input-group-append bg-primary border-primary">
                                        <asp:LinkButton runat="server" CssClass="btn btn-warning" id="IdBotonAgregarEntidad" OnClick="DdlTipoEntidad_SelectedIndexChanged">Agregar Entidad</asp:LinkButton>
                                    </div>
                                </div>
                                <small class="form-text text-muted ddlCodigoEntidadLabel">Ingrese la entidad relacionada al indicador</small>
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnSeleccionarIndicador" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                    <asp:UpdatePanel ID="upListadoEntidades" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:GridView ID="GridView2" runat="server" AllowPaging="true" Class="table table-hover table-striped table-bordered" PageSize="10" AutoGenerateColumns="false" OnRowCommand="GridAccion_RowCommandEntidad">
                                <Columns>
                                    <asp:BoundField DataField="DesTipo" HeaderText="Entidad" />
                                    <asp:TemplateField HeaderText="Acciones" ItemStyle-Width="20%" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <div class="row">
                                                <div class="column" style="padding-right:5px">
                                                    <asp:LinkButton runat="server" CssClass="btn btn-icons btn-inverse-danger" ToolTip="Eliminar" CommandArgument='<%# Eval("IdTipo") %>' CommandName="inactivar" ><i class="mdi mdi-delete"></i></asp:LinkButton> 
                                                </div>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="IdBotonAgregarEntidad" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
                <div class="modal-footer">
                    <asp:Button type="submit" class="btn btn-success" ID="btnSeleccionarIndicador" runat="server" Text="Editar Indicador" OnClick="Editar_Indicador" />
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
                    <p>Esta seguro de inactivar el indicador?</p>
                </div>
                <div class="modal-footer">
                    <asp:Button class="btn btn-danger" ID="btnInactive" runat="server" Text="Si" OnClick="Submit_inactiveIndicador" />
                    <button type="button" class="btn btn-primary" data-dismiss="modal">No</button>
                </div>
            </div>
        </div>
    </div>
    <script src="/js/pages/listadoAcciones.js"></script>
    </asp:Content>