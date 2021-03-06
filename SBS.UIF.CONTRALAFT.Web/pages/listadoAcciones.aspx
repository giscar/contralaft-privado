﻿<%@ Page Language="C#" MasterPageFile="plantilla.Master" AutoEventWireup="true" CodeBehind="listadoAcciones.aspx.cs" Inherits="SBS.UIF.CONTRALAFT.Web.pages.listadoAcciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphBody" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <style>
        .divTableAcciones td {
            padding: 5px;
        }

        .divTableAcciones th {
            padding: 10px;
        }
    </style> 
    <h5 class="card-title mb-4">Acciones del Plan</h5>
    <br/>
    <div class="form-group">
        <label>Número</label>
        <input type="text" class="form-control txtCodigoAccion" id="txtCodigoAccion" runat="server" autocomplete="off" maxlength="80" placeholder="Ingrese el número de la Acción" style="width: 50%"/>
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
        <a class="btn btn-primary btn-sm" id="idConfirmacion" data-toggle="modal" style="color: white">Crear Acción</a> 
    </div>
    
    <asp:GridView ID="GridView1" runat="server" AllowPaging="true" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridAccion_RowCommand" Class="table table-bordered divTableAcciones" PageSize="10" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" DataField="VersionPlan" HeaderText="Versión del Plan" />
            <asp:BoundField ItemStyle-Width="10%" DataField="Codigo" HeaderText="Codigo" />
            <asp:BoundField ItemStyle-Width="20%" DataField="Nombre" HeaderText="Acción" />
            <asp:BoundField ItemStyle-Width="40%" DataField="Descripcion" HeaderText="Descripcion" />
            <asp:TemplateField HeaderText="Acciones" ItemStyle-Width="20%" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <div class="row">
                        <div class="column" style="padding-right:5px; padding-left:20px">
                            <asp:LinkButton runat="server" CssClass="btn btn-icons btn-inverse-secondary" ToolTip="Editar" CommandArgument='<%# Eval("Id") %>' CommandName="editar" ><i class="mdi mdi-pencil"></i></asp:LinkButton>
                        </div>  
                        <div class="column" style="padding-right:5px">
                            <asp:LinkButton runat="server" CssClass="btn btn-icons btn-inverse-danger" ToolTip="Eliminar" CommandArgument='<%# Eval("Id") %>' CommandName="inactivar" ><i class="mdi mdi-delete"></i></asp:LinkButton> 
                        </div>
                        <div class="column">
                            <asp:LinkButton runat="server" CssClass="btn btn-icons btn-inverse-primary" ToolTip="Agregar Indicador" CommandArgument='<%# Eval("Id") %>' CommandName="indicador" ><i class="mdi mdi-plus"></i></asp:LinkButton>
                        </div> 
                    </div>
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
                <div class="modal-footer">
                    <asp:Button class="btn btn-success" ID="btnSeleccionar" runat="server" Text="Modificar Indicador" OnClick="Submit_edit" />
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
                    <asp:UpdatePanel id="upSeccionBotonIndicador" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="form-group" runat="server" >
                                <asp:Button class="btn btn-success" id="btnSeleccionarIndicador" runat="server" Text="Agregar Indicador" OnClick="Guardar_Indicador" />
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
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
                            <asp:GridView ID="GridView2" runat="server" AllowPaging="true" Class="table table-bordered" PageSize="10" AutoGenerateColumns="false" OnRowCommand="GridAccion_RowCommandEntidad">
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
                    <button type="button" class="btn btn-lg btn-primary" data-dismiss="modal">Cerrar</button>
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