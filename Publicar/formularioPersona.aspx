<%@ Page Language="C#" MasterPageFile="~/plantilla.Master" AutoEventWireup="true" CodeBehind="formularioPersona.aspx.cs" Inherits="SBS.UIF.BUZ.Web.formularioPersona" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphBody" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <script src="https://www.google.com/recaptcha/api.js" type="text/javascript"></script>

    <style>
		body {overflow-x:hidden;}
		
        ol li {
            text-align: justify;
        }
        li {padding-bottom: 10px;}
        .ocultar {
            display: none;
        }

        .mostrar {
            display: inherit;
        }

        .JERF_subtitulo7 {
            color: #0168b1;
            font-size: 20px;
            margin-bottom: 15px;
            display: block;
            font-weight: 600;
        }

        .IMP_contenedorImpresion {
            background-color: #fff;
            box-shadow: 4px 4px 8px rgba(1,0,2,0.2);
            padding: 30px 40px 40px 40px;
            margin-bottom: 20px;
        }

        .MultiFile-remove {
            color: red;
            font-weight: bold;
        }

        /*.modal-backdrop {
            z-index: -1;
        }*/

        #idModalBody {
            height: 360px;
            overflow: auto;
        }

        #idInfoServer {
   position: absolute;
   top: 10px;
   bottom: 0;
   left: 0;
   z-index: 10040;
   overflow: auto;
   overflow-y: auto;
}
   .cllRadioButton td{
    padding-right: 50px;
        </style>




    <div class="row" style="text-align: center">
        <h4 style="color: #0168b1; font-family: trebuchet; font-size: 20px; font-weight: 600; text-align:left; margin-left:40px">Ayúdanos a combatir el lavado de activos</h4>
        <h5 style="color: #777; text-align:justify; margin-left:40px; margin-right: 20px">
            Si tienes información sobre posibles hechos de lavado de activos y/o financiamiento del terrorismo, puedes enviarla a la UIF llenando el siguiente formulario:
        </h5>
        <br />
        <h5 class="JERF_subtitulo7">¿ Sobre quién nos desea informar ?</h5>
        <br />
        <center>
        <asp:RadioButtonList ID="ddlTipoPersona" CssClass="cllRadioButton" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="ddlTipoPersona_SelectedIndexChanged"></asp:RadioButtonList>
            </center>
    </div>
    <br />
    <h5 class="JERF_subtitulo7" id="idSubtitulo"></h5>
    <div class="well" id="divPersona">
        <div class="row">
            <div id="divTxtNombrePersona" class="col-md-4 form-group">
                <label class="control-label" for="txtNombrePersona">Nombres<span class="field-required">*</span></label>
                <input type="text" class="form-control soloLetras" id="txtNombrePersona" runat="server" autocomplete="off" maxlength="80" />
            </div>
            <div id="divTxtApellidoPaternoPersona" class="col-md-4 form-group">
                <label class="control-label" for="txtApellidoPaternoPersona">Apellido Paterno<span class="field-required">*</span></label>
                <input type="text" class="form-control  soloLetras" id="txtApellidoPaternoPersona" runat="server" autocomplete="off" maxlength="80" />
            </div>
            <div id="divTxtApellidoMaternoPersona" class="col-md-4 form-group">
                <label class="control-label" for="txtApellidoMaternoPersona">Apellido Materno<span class="field-required">*</span></label>
                <input type="text" class="form-control soloLetras" id="txtApellidoMaternoPersona" runat="server" autocomplete="off" maxlength="80" />
            </div>

        </div>
        <br />
        <div class="row">
            <div class="col-md-6">
                <label style="vertical-align: bottom">Tipo documento</label>
                <asp:DropDownList class="form-control" ID="ddlTipoDocumentoPersona" runat="server" DataValueField="idTipo" DataTextField="DesTipo"></asp:DropDownList>
            </div>
            <div class="col-md-6">
                <label>Nro documento</label>
                <p></p>
                <input id="txtNroDocumentoPersona" class="form-control" type="text" runat="server" autocomplete="off" maxlength="15" />
            </div>
        </div>
    </div>

    <div class="well" id="divEmpresa">
        <div class="row">
            <div id="divTxtRuc" class="col-md-8 form-group">
                <label class="control-label" for="txtRuc">Nro RUC<span class="field-required">*</span></label>
                <input type="text" class="form-control soloNumeros" id="txtRuc" runat="server" autocomplete="off" maxlength="11" />
            </div>
            <div class="col-md-4">
                <br />
                <asp:Button ID="Button2" class="btn btn-primary" runat="server" OnClick="Button_Valida_SUNAT" Text="Valida RUC" />
            </div>
        </div>
        <br />
        <div class="row">
            <asp:UpdatePanel ID="upRazonSocial" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="col-md-12">
                        <label id="lblRazonSocial" for="txtRazonSocial">Razon Social</label>
                        <input id="txtRazonSocial" class="form-control" type="text" runat="server" readonly="true" />
                    </div>

                    <div id="idModalAlertaServer" runat="server">
                        <div class="modal show" id="idAlertaServer">
                            <div class="modal-dialog modal-sm">
                                <div class="modal-content" style="background: #FCF8E3">
                                    <div class="modal-header" style="padding: 5px;">
                                        <a onclick="cerrarModal()" class="close" data-dismiss="modal" aria-label="Close"><span style="color: red; font-size: large" class="glyphicon glyphicon-remove"></span></a>
                                        <p style="color: #8A6D3B">Alerta!</p>
                                    </div>
                                    <div style="background: white; box-sizing: border-box;">
                                        <div class="modal-body" style="padding: 7px;">
                                            <table style="width: 100%">
                                                <tr>
                                                    <td style="padding-right: 8px">
                                                        <img style="width: 30px" src="img/warning.png" />
                                                    </td>
                                                    <td>
                                                        <div id="mensaje" class="text-resalt-comun">
                                                            <asp:Label ID="lblMensajePeligro" runat="server" Text=""></asp:Label>
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

                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Button2" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </div>

    <div id="ocurrencia" class="ocultar">
        <h5 class="JERF_subtitulo7">II. Lugar de ocurrencia</h5>
        <div class="well" id="divDireccion">
            <div class="row">
                <div id="divDllDepartamento" class="col-md-6 form-group">
                    <label for="ddlDepartamento">Departamento<span class="field-required">*</span></label>
                    <asp:DropDownList ID="ddlDepartamento" runat="server" class="form-control" DataValueField="codDepartamento" DataTextField="NomDepartamento" AutoPostBack="true" OnSelectedIndexChanged="ddlDepartamento_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
                <div id="divDllProvincia" class="col-md-6 form-group">
                    <label>Provincia<span class="field-required">*</span></label>
                    <asp:UpdatePanel ID="upProvincia" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlProvincia" runat="server" class="form-control" DataValueField="codProvincia" DataTextField="NomProvincia">
                            </asp:DropDownList>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlDepartamento" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-12">
                    <label>Dirección</label>
                    <input id="txtDireccion" type="text" class="form-control" runat="server" autocomplete="off" maxlength="450" />
                </div>
            </div>
        </div>
    </div>
    <div id="hecho" class="ocultar">
        <h5 class="JERF_subtitulo7">III. Hecho a informar</h5>
        <div class="well" id="divInformacionBien">
            <div class="row">
                <div id="divDdlTipoHechoInformarPersona" class="col-md-12 form-group">

                    <asp:UpdatePanel ID="upHechoInformar" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>



                            <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
                                <div class="modal-dialog" role="document">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                            <h4 class="modal-title" id="myModalLabel">Ejemplos de hechos a informar</h4>
                                        </div>
                                        <div id="idModalBody" class="modal-body" style="text-align:justify">
                                            <asp:GridView ID="GridView_Ayuda" runat="server" BackColor="White"
                                                BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3"
                                                HorizontalAlign="Center" AutoGenerateColumns="False">
                                                <FooterStyle BackColor="White" ForeColor="#000066" />
                                                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White"
                                                    HorizontalAlign="Center" />
                                                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                                <RowStyle ForeColor="#000066" HorizontalAlign="Center" />
                                                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                                <SortedDescendingHeaderStyle BackColor="#00547E" />
                                                <Columns> 
                                                    <asp:BoundField DataField="detalleLista" HeaderText="Hechos"  HtmlEncode="false"/>
                                                    <asp:BoundField DataField="detalle" HeaderText="Ejemplo"  HtmlEncode="false"/>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-default" data-dismiss="modal">Cerrar ayuda</button>
                                        </div>
                                    </div>
                                </div>
                            </div>


                            <label class="control-label" for="ddlTipoHechoInformarPersona">
                                Qué hecho desea informar <a class="btn" data-toggle="modal" data-target="#myModal">
                                    <span class="glyphicon glyphicon-question-sign" style="color: red; font-size: 1.5em" />
                                </a><span class="field-required">*</span></label>
                            <asp:DropDownList ID="ddlTipoHechoInformarPersona" class="form-control" runat="server" DataValueField="idTipo" DataTextField="DesTipo" AutoPostBack="true" onchange="cargarHechoInformar()" OnSelectedIndexChanged="ddlTipoHechoInformarPersona_SelectedIndexChanged"></asp:DropDownList>

                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlTipoPersona" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>

            <br />
            <div class="row">
                <div id="divDdlBienRelacionado" class="col-md-4 form-group">
                    <label class="control-label" for="ddlBienRelacionado">Bien relacionado<span class="field-required">*</span></label>
                    <asp:UpdatePanel ID="upBienRelacionado" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlBienRelacionado" runat="server" class="form-control" DataValueField="idTipo" DataTextField="DesTipo" onchange="cargarBienRelacionado(this)"></asp:DropDownList>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlTipoHechoInformarPersona" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-6">
                    <label>Información adicional sobre el bien (dirección, nro de placa, importes, cuenta bancaria, etc )</label>
                </div>
                <div class="col-md-6">
                    <input id="txtInformacionAdicional" class="form-control" type="text" autocomplete="off" maxlength="450" />
                </div>
            </div>
            <div class="row">
                <div id="divTxtDetalleOtros" class="col-md-12 ocultar">
                    <br />
                    <label for="txtDetalleOtros">Detallar otros</label>
                    <input id="txtDetalleOtros" class="form-control" type="text" autocomplete="off" maxlength="450" />
                    <input type="text" runat="server" id="hdnJsonListaBien" style="display: none" />
                </div>
            </div>
            <div class="row" style="text-align: center">
                <div class="col-md-12">
                    <br />
                    <input type="button" class="btn btn-primary" id="createJson" value="Agrega otro bien" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <br />
                    <table class="table table-striped table-hover table-bordered" id="table_bienes">
                        <tr>
                            <th>Bien relacionado</th>
                            <th>informacion adicional</th>
                            <th>Eliminar</th>
                        </tr>
                    </table>
                </div>

            </div>
            <div class="row">
                <div id="idDivDescripcionHecho" class="col-md-12 form-group">
                    <br />
                    <label for="txtDescripcionHecho" class="field-required">Describa los hechos a informar<span class="field-required">*</span></label>
                    <span style="float: right; color: red">(Describir brevemente)</span>
                    <textarea id="txtDescripcionHecho" rows="6" class="form-control" runat="server" maxlength="2800"></textarea>
                </div>
            </div>
            <div id="divFileDocumento" class="row form-group">
                <div class="col-md-3">
                    <br />
                    <label class="control-label" for="fileDocumento">Agregar Archivo: </label>
                    <br />
                    <label class="control-label" for="fileDocumento">word, excel, pdf, jpg, bmp, tif y zip</label>
                </div>
                <div class="col-md-9">
                    <br />
                    <asp:FileUpload ID="fileDocumento" Text="ASPNET Button" type="file" class="multi-pt file-loading" data-maxfile="14336" data-show-preview="false" runat="server" Visible="true" />
                </div>
            </div>
        </div>
    </div>

    <div id="adicionales" class="ocultar">
        <h5 class="JERF_subtitulo7">IV. Información personal - Opcional</h5>
        <div class="well">
            <div class="row">
                <div class="col-md-4">
                    <label>Nombres</label>
                    <input id="txtNombresOpcional" class="form-control soloLetras" type="text" runat="server" autocomplete="off" maxlength="80" />
                </div>
                <div class="col-md-4">
                    <label>Apellido Paterno</label>
                    <input id="txtApellidoPaternoOpcional" class="form-control soloLetras" type="text" runat="server" autocomplete="off" maxlength="80" />
                </div>
                <div class="col-md-4">
                    <label>Apellido Materno</label>
                    <input id="txtApellidoMaternoOpcional" class="form-control soloLetras" type="text" runat="server" autocomplete="off" maxlength="80" />
                </div>
            </div>
            <br />
			
            <div id="divTxtEmailOpcional" class="row">
                <div class="col-md-4" style="text-align: left">
                    <label>Em@il</label>
                </div>
				
                <div class="col-md-8">
                    <input id="txtEmailOpcional" class="form-control" type="text" runat="server" autocomplete="off" maxlength="50" />
                </div>
            </div>
        </div>
        <br />
        <center>
        <div>
            <div id="recaptcha" class="g-recaptcha" data-sitekey="6LeOHzcUAAAAADxE04NijIaL9speF50VFUF9bcSy"></div>
            <br />
            <asp:Button ID="btn_enviar" runat="server" Class="btn btn-lg btn-primary" OnClick="Button_Guardar" Text="ENVIAR INFORMACIÓN" />
        </div>
            </center>
    </div>
    <br />
    <br />
    <!--Disclaimer-->
    <ol>
  <li>La presente comunicación es una alerta ciudadana que NO CONSTITUYE UNA DENUNCIA. En caso tenga información sobre la comisión de un delito debe denunciarlo de inmediato ante la Policía Nacional y/o el Ministerio Público</li>
  <li>La presente alerta a la UIF-Perú contribuirá sustancialmente en PREVENIR el lavado de activos y/o el financiamiento del terrorismo</li>
  <li>La UIF-Perú garantiza la reserva de la identidad de la persona que remite esta alerta ciudadana </li>
  <li>Este buzón no tiene por finalidad recibir solicitudes de información pública ni brindar los servicios de consultas, denuncias y reclamos contra el sistema financiero que ofrece la SBS. En caso requiera utilizar dichos servicios puede ingresar al siguiente enlace: <a href="http://www.sbs.gob.pe/usuarios/nuestros-servicios/servicios-sbs/denuncias-y-reclamos/denuncias">http://www.sbs.gob.pe/usuarios/nuestros-servicios/servicios-sbs/denuncias-y-reclamos/denuncias</a></li>
</ol>
 
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


    <div class="modal fade" id="idAlerta">
            <div class="modal-dialog modal-sm" >
                <div class="modal-content" style=" background: #FCF8E3">
                    <div class="modal-header" style="padding: 5px;">
                        <a  class="close" data-dismiss="modal" aria-label="Close"><span style="color: red; font-size: large" class="glyphicon glyphicon-remove" ></span></a>
                        <h5 style="color: #8A6D3B"><b>Alerta!</b></h5>
                    </div>
                    <div style="background: white;box-sizing: border-box;" >
                        <div class="modal-body" style="padding: 7px;">
                            <table style="width: 100%">
                                <tr>
                                    <td style="padding-right: 8px">
                                        <img style="width: 30px" src="img/warning.png" />
                                    </td>
                                    <td>
                                        <div id="mensaje" class="text-resalt-comun"></div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    <div class="modal fade" id="idInformativo">
            <div class="modal-dialog modal-sm" >
                <div class="modal-content " style="background: #D9EDF7">
                    <div class="modal-header" style="padding: 5px;">
                        <a onclick="cerrarModalInfo()" class="close" data-dismiss="modal" aria-label="Close"><span style="color: red; font-size: large" class="glyphicon glyphicon-remove"></span></a>
                        <h5 style="color: #8A6D3B"><b>Información:</b></h5>
                    </div>
                    <div style="background: white; box-sizing: border-box;">
                        <div class="modal-body" style="padding: 7px;">
                            <table style="width: 100%">
                                <tr>
                                    <td style="padding-right: 8px">
                                        <img style="width: 30px" src="img/info.png" />
                                    </td>
                                    <td>
                                        <div id="mensajeInf" class="text-resalt-comun"></div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    <script type="text/javascript">
        var response = [];

        function cerrarModal() {
            $("#idAlertaServer").remove();
            $("#divTxtRuc").addClass("has-error has-feedback");
            $("#<%= txtRuc.ClientID %>").focus();
        }
		
		function isEmail(email) {
			var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
			return regex.test(email);
		}

        function cerrarModalInfo() {
            $("#idInfoServer").remove();
        }

        function eliminarRow(valor) {
            row = valor.parentElement.parentElement.rowIndex;
            response.splice(row - 1, 1);
            var data = response;
            $("#table_bienes .columJSON").remove();
            $("#<%= hdnJsonListaBien.ClientID %>").val(JSON.stringify(data));
            $.each(data, function (i, item) {
                var $tr = $('<tr class="columJSON">').append($('<td>').text(item.bienRelacionado), $('<td>').text(item.descripcionAdicional)).append('<td><input type="button" class="btn btn-danger btn-xs deleteJson" value="Eliminar" onclick="eliminarRow(this)"/>').appendTo('#table_bienes');
            })
        }

        function cargarBienRelacionado(valor) {
            if ($("#<%= ddlBienRelacionado.ClientID %> option:selected").text() === 'Otros') {
                $('#divTxtDetalleOtros').removeClass('ocultar');
            } else {
                $('#divTxtDetalleOtros').addClass('ocultar');
            }
        }

        function cargarHechoInformar() {
            if ($("#<%= ddlTipoHechoInformarPersona.ClientID %> option:selected").text() !== '') {
                $("#table_bienes .columJSON").remove();
                response = [];
            }
        }

        function ValidarTamanio(val, args) {
            var validFileSize = 14 * 1024 * 1024;
            var idInput = document.getElementById("<%=fileDocumento.ClientID%>")
            var fileSize = idInput.files[0].size;
            if (fileSize !== 0 && fileSize <= validFileSize) {
                args.IsValid = true;
                $("#divFileDocumento").removeClass("has-error has-feedback");
            }
            else {
                args.IsValid = false;
                $("#divFileDocumento").addClass("has-error has-feedback");
            }
        }

        $(document).ready(function () {
            var cont1 = 0;
            var cont2 = 0;
            var cont3 = 0;
            $("#<%= btn_enviar.ClientID %>").click(function () {
                if ($("#<%= ddlTipoPersona.ClientID %> input:checked").val() === 'P') {
                    $("#idSubtitulo").text("I. Ingresa los datos de la persona sobre la cual desea informar");
                    if ($("#<%= txtNombrePersona.ClientID %>").val() === '') {
                        $("#divTxtNombrePersona").addClass("has-error has-feedback");
                        $("#<%= txtNombrePersona.ClientID %>").focus();
                        alertar("Verificar el nombre de la persona");
                        return false;
                    } else {
                        $("#divTxtNombrePersona").removeClass("has-error has-feedback");
                    }
                    if ($("#<%= txtApellidoPaternoPersona.ClientID %>").val() === '') {
                        $("#divTxtApellidoPaternoPersona").addClass("has-error has-feedback");
                        $("#<%= txtApellidoPaternoPersona.ClientID %>").focus();
                        alertar("Verificar el apellido paterno de la persona");
                        return false;
                    } else {
                        $("#divTxtApellidoPaternoPersona").removeClass("has-error has-feedback");
                    }
                    if ($("#<%= txtApellidoMaternoPersona.ClientID %>").val() === '') {
                        $("#divTxtApellidoMaternoPersona").addClass("has-error has-feedback");
                        $("#<%= txtApellidoMaternoPersona.ClientID %>").focus();
                        alertar("Verificar el apellido materno de la persona");
                        return false;
                    } else {
                        $("#divTxtApellidoMaternoPersona").removeClass("has-error has-feedback");
                    }
                }

                if ($("#<%= ddlTipoPersona.ClientID %> input:checked").val() === 'E') {
                    $("#idSubtitulo").text("I. Ingresa los datos de la empresa sobre la cual desea informar");
                    if ($("#<%= txtRuc.ClientID %>").val().length !== 11) {
                        $("#divTxtRuc").addClass("has-error has-feedback");
                        $("#<%= txtRuc.ClientID %>").focus();
                        alertar("Verificar el Nro. de RUC");
                        return false;
                    } else {
                        $("#divTxtRuc").removeClass("has-error has-feedback");
                    }
                }

                if ($("#<%= ddlDepartamento.ClientID %>").val() === '0') {
                    $("#<%= ddlDepartamento.ClientID %>").focus();
                    $("#divDllDepartamento").addClass("has-error has-feedback");
                    alertar("Ingresar el departamento");
                    return false;
                } else {
                    $("#divDllDepartamento").removeClass("has-error has-feedback");
                }

                if ($("#<%= ddlProvincia.ClientID %>").val() === '0') {
                    $("#<%= ddlProvincia.ClientID %>").focus();
                    $("#divDllProvincia").addClass("has-error has-feedback");
                    alertar("Ingresar la provincia");
                    return false;
                } else {
                    $("#divDllProvincia").removeClass("has-error has-feedback");
                }

                if ($("#<%= ddlTipoHechoInformarPersona.ClientID %>").val() === '0') {
                    $("#<%= ddlTipoHechoInformarPersona.ClientID %>").focus();
                    $("#divDdlTipoHechoInformarPersona").addClass("has-error has-feedback");
                    alertar("Ingresar el hecho a informar");
                    return false;
                } else {
                    $("#divDdlTipoHechoInformarPersona").removeClass("has-error has-feedback");
                }

                if (Object.keys(response).length === 0) {
                    $("#<%= ddlBienRelacionado.ClientID %>").focus();
                    $("#divDdlBienRelacionado").addClass("has-error has-feedback");
                    alertar("Tiene que ingresar un bien relacionado");
                    return false;
                } else {
                    $("#divDdlBienRelacionado").removeClass("has-error has-feedback");
                }
				
				/**email*/
				if ($("#<%= txtEmailOpcional.ClientID %>").val() !== '') {
					if(!isEmail($("#<%= txtEmailOpcional.ClientID %>").val())){
						$("#divTxtEmailOpcional").addClass("has-error has-feedback");
                        $("#<%= txtEmailOpcional.ClientID %>").focus();
                        alertar("El formato de email es incorrecto");
                        return false;
					}
                } 
					
					
                /**validaciones que pueden pasar*/
                if ($("#<%= ddlTipoPersona.ClientID %> input:checked").val() === 'P') {
                    var concatenado = $("#<%= txtNombrePersona.ClientID %>").val().concat($("#<%= txtApellidoPaternoPersona.ClientID %>").val()).concat($("#<%= txtApellidoMaternoPersona.ClientID %>").val());
                    if (concatenado.length <= 6) {
                        $("#divTxtNombrePersona").addClass("has-error has-feedback");
                        $("#divTxtApellidoPaternoPersona").addClass("has-error has-feedback");
                        $("#divTxtApellidoMaternoPersona").addClass("has-error has-feedback");
                        if (cont1 === 0) {
                            $("#<%= txtNombrePersona.ClientID %>").focus();
                            cont1++;
                            alertar("Verificar los nombres, apellido paterno y materno ingresados");
                            return false;
                        }
                    } else {
                        $("#divTxtApellidoMaternoPersona").removeClass("has-error has-feedback");
                        $("#divTxtApellidoPaternoPersona").removeClass("has-error has-feedback");
                        $("#divTxtNombrePersona").removeClass("has-error has-feedback");
                    }
                }

                if ($("#<%= ddlTipoPersona.ClientID %> input:checked").val() === 'E') {
                    if ($("#<%= txtRazonSocial.ClientID %>").val().length === 0) {
                        $("#divTxtRuc").addClass("has-error has-feedback");
                        $("#<%= txtRuc.ClientID %>").focus();
                        if (cont2 === 0) {
                            $("#<%= txtRuc.ClientID %>").focus();
                            cont2++;
                            alertar("Verificar el Nro. de RUC");
                            return false;
                        }
                    }
                }

                if ($(".MultiFile-title").toArray().length === 0) {
                    if ($("#<%= txtDescripcionHecho.ClientID %>").val().length < 250) {
                        if (cont3 === 0) {
                            $("#<%= txtDescripcionHecho.ClientID %>").focus();
                            cont3++;
                            $("#idDivDescripcionHecho").addClass("has-error has-feedback");
                            alertar("Debe describir los hechos con mayor detalle y/o adjuntar un archivo de sustento");
                            return false;
                        }
                    } else {
                        $("#idDivDescripcionHecho").removeClass("has-error has-feedback");
                    }
                } else {
                    $("#idDivDescripcionHecho").removeClass("has-error has-feedback");
                }

                var respo = grecaptcha.getResponse();
                if (respo.length == 0) {
                    alertar("Debe ingresar el captcha");
                    return false;
                }
                return true;
            });

            function alertar(msg) {
                $("#idAlerta").modal('show');
                $("#mensaje").html(msg);
            }

            function informar(msg) {
                $("#idInformativo").modal('show');
                $("#mensajeInf").html(msg);
            }

            $("#ocurrencia").addClass("ocultar");
            $("#hecho").addClass("ocultar");
            $("#adicionales").addClass("ocultar");
            $("#divPersona").css("display", "none");
            $("#divEmpresa").css("display", "none");

            $("#divPersona").css("display", "none");
            $("#divEmpresa").css("display", "none");
            $("#<%= ddlTipoHechoInformarPersona.ClientID %>").css("display", "none");



            $('.cllRadioButton input').click(function () {
                if ($("#<%= ddlTipoPersona.ClientID %> input:checked").val() === 'P') {
                    $("#idSubtitulo").text("I. Ingresa los datos de la persona sobre la cual desea informar");
                    $("#divPersona").css("display", "inherit");
                    $("#divEmpresa").css("display", "none");
                    $("#<%= ddlTipoHechoInformarPersona.ClientID %>").css("display", "inherit");
                    $("#ocurrencia").removeClass("ocultar");
                    $("#hecho").removeClass("ocultar");
                    $("#adicionales").removeClass("ocultar");
                }
                if ($("#<%= ddlTipoPersona.ClientID %> input:checked").val() === 'E') {
                    $("#idSubtitulo").text("I. Ingresa los datos de la empresa sobre la cual desea informar");
                    $("#divPersona").css("display", "none");
                    $("#divEmpresa").css("display", "inherit");
                    $("#<%= ddlTipoHechoInformarPersona.ClientID %>").css("display", "none");
                    $("#ocurrencia").removeClass("ocultar");
                    $("#hecho").removeClass("ocultar");
                    $("#adicionales").removeClass("ocultar");
                }
            });

            $('#createJson').click(function () {
                if ($("#<%= ddlBienRelacionado.ClientID %>").val() === '0') {
                    $("#<%= ddlBienRelacionado.ClientID %>").focus();
                    $("#divDdlBienRelacionado").addClass("has-error has-feedback");
                    alertar("Verificar el bien relacionado");
                    return false;
                } else {
                    $("#divDdlBienRelacionado").removeClass("has-error has-feedback");
                }

                $('#divInformacionBien').each(function () {
                    var bienRelacionado = $("#<%= ddlBienRelacionado.ClientID %>").find('option:selected').text();
                    var codigoBien = $("#<%= ddlBienRelacionado.ClientID %>").find('option:selected').val();
                    var descripcionOtros = $("#txtDetalleOtros").val();
                    var descripcionAdicional = $("#txtInformacionAdicional").val();
                    var obj = {
                        bienRelacionado: bienRelacionado,
                        codigoBien: codigoBien,
                        descripcionAdicional: descripcionAdicional,
                        descripcionOtros: descripcionOtros
                    };
                    response.push(obj);
                    $("#<%= ddlBienRelacionado.ClientID %>").val('0');
                    $("#txtDetalleOtros").val('');
                    $("#txtInformacionAdicional").val('');
                });
                $("#table_bienes .columJSON").remove();
                var data = response;
                $("#<%= hdnJsonListaBien.ClientID %>").val(JSON.stringify(data));
                $.each(data, function (i, item) {
                    var $tr = $('<tr class="columJSON">').append($('<td>').text(item.bienRelacionado), $('<td>').text(item.descripcionAdicional)).append('<td><input type="button" class="btn btn-danger btn-xs deleteJson" value="Eliminar" onclick="eliminarRow(this)"/>').appendTo('#table_bienes');
                });
                informar("Puede agregar más bienes");
            });

            $(function () {
                $('.multi-pt').MultiFile({
                    accept: 'doc|DOC|docx|DOCX|xls|XLS|xlsx|XLSX|pdf|PDF|jpg|JPG|bmp|BMP|tif|TIF|zip|ZIP',
                    max: 10,
                    STRING: {
                        selected: 'Selecionado: $file',
                        toomany: 'La cantidad máxima de archivos que se puede adjuntar es: $max',
                        denied: 'No se permiten las extenciones de tipo: $ext!',
                        duplicate: 'El archivo: $file \nya ha sido seleccionado!',
                        toobig: '$file sobrepasa el peso del archivo (max $size)'
                    }
                });
            });

            $(".soloLetras").bind('keypress', function (event) {
                var regex = new RegExp("^[a-zA-ZÀ-ÿ\u00f1\u00d1 ]+$");
                var key = String.fromCharCode(!event.charCode ? event.which : event.charCode);
                if (!regex.test(key)) {
                    event.preventDefault();
                    return false;
                }
            });

            $(".soloNumeros").bind('keypress', function (event) {
                var regex = new RegExp("^[0-9]+$");
                var key = String.fromCharCode(!event.charCode ? event.which : event.charCode);
                if (!regex.test(key)) {
                    event.preventDefault();
                    return false;
                }
            });
        });

    </script>

</asp:Content>
