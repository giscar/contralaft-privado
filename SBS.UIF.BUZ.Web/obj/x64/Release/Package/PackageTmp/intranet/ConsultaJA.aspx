<%@ Page Title="" Language="C#" MasterPageFile="~/intranet/Intranet.Master" AutoEventWireup="true" CodeBehind="ConsultaJA.aspx.cs" Inherits="SBS.UIF.SISDEL.Web.Extranet.intranet.ConsultaJA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphBody" runat="server">
    
        <div class="panel panel-default">
        <div class="panel-body">
        <div class="form-horizontal">
            <div class="form-group">
                <label for="" class="col-sm-2 control-label">RUC:</label>
                <div class="col-sm-2">
                    <asp:TextBox ID="txtRuc" runat="server" placeholder="N° de RUC" MaxLength="11" class="form-control"></asp:TextBox>
                </div>
                <label for="" class="col-sm-2 control-label">Raz&oacute;n Social:</label>
                <div class="col-sm-4">
                    <asp:TextBox ID="txtRazonSocial" runat="server" class="form-control" placeholder="Razón Social" MaxLength="60"></asp:TextBox>
                </div>
            </div>

            <div class="form-group">
                <label for="" class="col-sm-2 control-label">Periodo:</label>
                <div class="col-sm-4 form-inline">
                    <asp:TextBox ID="txtFechaDesde" runat="server" Width="100" MaxLength="10" class="form-control"></asp:TextBox> - 
                    <asp:TextBox ID="txtFechaHasta" runat="server" Width="100" MaxLength="10" class="form-control"></asp:TextBox>
                </div>
                <div class="col-sm-3 form-inline">
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" ValidationGroup="btnBuscar" OnClick="btnBuscar_Click" /> &nbsp;&nbsp;
                    <asp:Button ID="btnExportar" runat="server" Text="Exportar" CssClass="btn btn-primary" OnClick="btnExportar_Click" />&nbsp;&nbsp;
                    <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" CssClass="btn btn-primary" OnClick="btnLimpiar_Click" />

                </div>
            </div>
        </div>
         </div>
      </div>
    

    <div class="alert alert-danger alert-dismissible" role="alert" runat="server" id="divAlertDanger">
        <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <asp:Label ID="lblMensajePeligro" runat="server" Text=""></asp:Label>
    </div>

    <div class="alert alert-success alert-dismissible" role="alert" runat="server" id="divAlertSuccess">
        <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <asp:Label ID="lblMensajeOk" runat="server" Text=""></asp:Label>
    </div>

        
        <div class="panel panel-default">
        <div class="panel-body">

        <div class="table-responsive" id="tabla">
        <asp:GridView ID="gvSolicitudDesig"
            runat="server"
            AutoGenerateColumns="False"
            EnableModelValidation="True"
            Width="100%"
            CssClass="table table-hover table-bordered table-condensed table-responsive" AllowPaging="True" OnPageIndexChanging="gvSolicitudDesig_PageIndexChanging" OnRowDataBound="gvSolicitudDesig_RowDataBound" OnRowCommand="gvSolicitudDesig_RowCommand">
            <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
            <PagerStyle CssClass="pagination-ma" />
            <Columns>
                <asp:TemplateField HeaderText="Seleccionar" ItemStyle-CssClass="text-center">
                    <HeaderTemplate>
                        <input id="chkCabecera" type="checkbox" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkAsig" runat="server" />
                        <asp:HiddenField ID="hdfIdSD" runat="server" Value='<%#Eval("IdSolicitudDesignacion") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Codigo" HeaderText="Codigo" ItemStyle-Width="12%">
                </asp:BoundField>
                <%--<asp:BoundField DataField="Supervisor" HeaderText="Supervisor" ItemStyle-Width="10%">
                    <ItemStyle Width="10%"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="TipoSujeto" HeaderText="Tipo Sujeto Obligado" ItemStyle-Width="15%">
                    <ItemStyle Width="15%"></ItemStyle>
                </asp:BoundField>--%>
                <asp:BoundField DataField="NumDocumentoSO" HeaderText="RUC" ItemStyle-Width="5%">
                </asp:BoundField>
                <asp:BoundField DataField="RazonSocial" HeaderText="Sujeto Obligado" ItemStyle-Width="15%">
                </asp:BoundField>
                <asp:BoundField DataField="NumDocumentoOC" HeaderText="Documento OC" ItemStyle-Width="10%">
                </asp:BoundField>
                <asp:BoundField DataField="NombreCompleto" HeaderText="Nombre OC" />
                <asp:BoundField DataField="TipoDesignacion" HeaderText="Tipo Designación" ItemStyle-Width="12%">
                </asp:BoundField>
                <asp:BoundField DataField="TipoCategoria" HeaderText="Categoría" ItemStyle-Width="7%">
                </asp:BoundField>
                <asp:BoundField DataField="FechaSolicitud" HeaderText="Fecha Solic." ItemStyle-Width="7%" DataFormatString="{0:d}">
                </asp:BoundField>
                <asp:TemplateField HeaderText="Obs." ItemStyle-CssClass="text-center">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbVerFlujo" runat="server" CommandName="VerFlujo" CommandArgument='<%#Eval("IdSolicitudDesignacion") %>'> <span class="glyphicon glyphicon-tasks"></span> </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Det." ItemStyle-CssClass="text-center">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbVerSolicitud" runat="server" CommandName="VerSolicitud" CommandArgument='<%#Eval("IdSolicitudDesignacion") %>'> <span class="glyphicon glyphicon-search"></span> </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                No hay elementos disponibles en esta vista.
            </EmptyDataTemplate>
        </asp:GridView>
    </div>

        <div class="form-group">
        <label for="" class="col-sm-3 control-label"></label>
        <div class="col-sm-2">
            <button id="btnDerivar" type="button" class="btn btn-primary">Derivar</button>
        </div>
        </div>
        </div>
        </div>
    

    <div class="modal fade" tabindex="-1" role="dialog" id="ModalAsig">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <%--<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>--%>
                    <h4 class="modal-title">Derivar Solicitudes a: <b>Grupo Coordinador<b></h4>
                </div>
                <div class="modal-body">
                    <div class="form-horizontal">
                        <div class="form-group">
                        <label for="" class="col-sm-3 control-label">Prioridad:<span class="field-required">*</span></label>
                        <div class="col-sm-7">
                            <asp:DropDownList ID="ddlPrioridad" runat="server" class="form-control" DataValueField="CodElemento" DataTextField="Nombre">
                                </asp:DropDownList>
                            <asp:CustomValidator ID="cvPrioridad" runat="server" Display="Dynamic" EnableClientScript="true" ControlToValidate="ddlPrioridad" ValidationGroup="btnGuardarAsig" ClientValidationFunction="validarCombo">
                                <em class="error-message">Seleccione la prioridad</em>
                            </asp:CustomValidator>
                        </div>
                        </div>

                    <div class="form-group">
                        <label for="" class="col-sm-3 control-label">Comentarios:<span class="field-required">*</span></label>
                        <div class="col-sm-7">
                            <asp:TextBox ID="txtComentarios" runat="server" class="form-control" placeholder="Comentarios" TextMode="MultiLine" Columns="30" Rows="3"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvComentarios" runat="server" Display="Dynamic" EnableClientScript="true" ControlToValidate="txtComentarios" ValidationGroup="btnGuardarAsig">
                                <em class="error-message">Ingrese un comentario</em>
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                  </div>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnGuardarAsig" runat="server" Text="Derivar" class="btn btn-default" ValidationGroup="btnGuardarAsig" OnClick="btnGuardarAsig_Click" />&nbsp;
                    <button id="btnCancelarAsig" type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                </div>

            </div><!-- /.modal-content -->
        </div><!-- /.modal-dialog -->
    </div><!-- /.modal -->

    <div class="modal fade" tabindex="-1" role="dialog" id="ModalFlujo">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title">Datos del Expediente</h4>
                </div>
                <div class="modal-body">
                    <div class="form-horizontal">                        
                        <div class="form-group">
                            <label for="" class="col-sm-4 control-label">N° Expediente:</label>
                            <div class="col-sm-8">
                                <asp:Label ID="lblNumeroExpediente" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="" class="col-sm-4 control-label">Fecha Expediente:</label>
                            <div class="col-sm-8">
                                <asp:Label ID="lblFechaExpediente" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="" class="col-sm-4 control-label">Asunto Expediente:</label>
                            <div class="col-sm-8">
                                <asp:Label ID="lblAsuntoExpediente" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="" class="col-sm-4 control-label">Fecha Designación:</label>
                            <div class="col-sm-8">
                                <asp:Label ID="lblFechaDesignacion" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="" class="col-sm-4 control-label">Fecha Derivación:</label>
                            <div class="col-sm-8">
                                <asp:Label ID="lblFechaDerivacion" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button id="btnCerrarFlujo" type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>
                </div>
            </div><!-- /.modal-content -->
        </div><!-- /.modal-dialog -->
    </div><!-- /.modal -->

    <script type="text/javascript">
        function openModalAsig() {
            $('#ModalAsig').modal({
                backdrop: 'static',
                keyboard: true
            });
        }

        function openModalFlujo() {
            $('#ModalFlujo').modal({
                backdrop: 'static',
                keyboard: true
            });
        }

        $(document).ready(function () {
            $('input[id*=txtFecha]').datepicker({
                format: "dd/mm/yyyy",
                language: "es",
                autoclose: true,
                todayHighlight: true
            });

            $("#btnDerivar").click(function () {
                var checks = $('#<%=gvSolicitudDesig.ClientID%>').find('input[type="checkbox"]:checked').length;
                if (checks > 0) {
                    openModalAsig();
                } else {
                    alert("Por favor seleccione la solicitud");
                }

            });

            $("#chkCabecera").click(function () {
                var chk = $(this);
                $("#tabla input[type=checkbox]").each(function () {
                    $(this).prop("checked", chk.is(":checked"));
                });
            });

        });
    </script>
</asp:Content>
