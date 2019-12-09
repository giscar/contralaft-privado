<%@ Page Language="C#" MasterPageFile="~/plantilla.Master" AutoEventWireup="true" CodeBehind="formularioPersona.aspx.cs" Inherits="SBS.UIF.BUZ.Web.formularioPersona" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphBody" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    

    <div class="row" style="text-align: center">
        <h4 style="color: #0168b1; font-family: trebuchet; font-size: 20px; font-weight: 600; text-align:left; margin-left:40px">Ayúdanos a combatir el lavado de activos</h4>
        
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
                <label class="control-label" for="txtApellidoPaternoPersona">ID<span class="field-required">*</span></label>
                <input type="text" class="form-control  soloLetras" id="txtId" runat="server" autocomplete="off" maxlength="80" />
            </div>
            
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button_Guardar" />
        </div>
       
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
 
    
</asp:Content>
