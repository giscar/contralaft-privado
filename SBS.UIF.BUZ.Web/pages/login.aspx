<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="SBS.UIF.BUZ.Web.pages.login.login" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>sistema de login</title>
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no">
    
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
    <script src="https://ajax.aspnetcdn.com/ajax/jQuery/jquery-3.4.1.min.js"></script>
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
    
    <style>


body{
font-size: 12px;
}

#Contenedor{
width: 400px;
margin: 50px auto;
background-color: #F3EDED;
    border: 1px solid #ECE8E8;
height: 400px;
border-radius:8px;
padding: 0px 9px 0px 9px;
}


.Icon span{
      background: #A8A6A6;
      padding: 20px;
      border-radius: 120px;
}

.Icon{
     margin-top: 10px;
     margin-bottom:10px;
     color: #FFF;
     font-size: 50px;
     text-align: center;
}

.opcioncontra{
text-align: center;
margin-top: 20px;
font-size: 14px;
}




    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="Contenedor">
        <div class="Icon">
            <!--Icono de usuario-->
            <span class="glyphicon glyphicon-user"></span>
        </div>
        <div class="ContentForm">
            
                <div class="input-group input-group-lg">
                    <span class="input-group-addon"><i class="glyphicon glyphicon-envelope"></i></span>
                    <input type="text" class="form-control" id="txtNombrePersona" runat="server" autocomplete="off" maxlength="80" placeholder="Usuario"/>
                </div>
                <br>
                <div class="input-group input-group-lg">
                    <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                    <input type="text" class="form-control" id="txtContra" runat="server" autocomplete="off" maxlength="80" placeholder="*********"/>
                </div>
                <br>
                    
                <asp:Button class="btn btn-lg btn-primary btn-block btn-signin" ID="Button1" runat="server" Text="Button" OnClick="Submit_Login" />
                
        </div>
    </div>
    </form>

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
</body>
</html>



