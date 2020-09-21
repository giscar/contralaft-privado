<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="SBS.UIF.CONTRALAFT.Web.pages.Login" %>
<!DOCTYPE html>
<html lang="en">

<head>
  <!-- Required meta tags -->
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
  <title>CONTRALAFT</title>
  <!-- plugins:css -->
  <link rel="stylesheet" href="../../vendors/iconfonts/mdi/css/materialdesignicons.min.css">
  <link rel="stylesheet" href="../../vendors/css/vendor.bundle.base.css">
  <link rel="stylesheet" href="../../vendors/css/vendor.bundle.addons.css">
  <!-- endinject -->
  <!-- plugin css for this page -->
  <!-- End plugin css for this page -->
  <!-- inject:css -->
  <link rel="stylesheet" href="../../css/style.css">
  <!-- endinject -->
  <link rel="shortcut icon" href="../../images/favicon.png" />
</head>
<body>
    <style>
        .auth.theme-two .banner-section .slide-content.bg-1 {
            background: url(../images/sbs.jpg) no-repeat center center;
            background-size: cover;
        }

        .mdi:before, .mdi-set {
    display: inline-block;
    font: normal normal normal 24px/1 "Material Design Icons";
    text-rendering: auto;
    line-height: inherit;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
}

        .login-input-text {
            font-size: 14px;
        }
    </style>
      <div class="container-scroller">
    <div class="container-fluid page-body-wrapper full-page-wrapper">
      <div class="content-wrapper auth p-0 theme-two">
        <div class="row d-flex align-items-stretch">
          <div class="col-md-4 banner-section d-none d-md-flex align-items-stretch justify-content-center">
            <div class="slide-content bg-1">
            </div>
          </div>
          <div class="col-12 col-md-8 h-100 bg-white">
            <div class="auto-form-wrapper d-flex align-items-center justify-content-center flex-column">
              
              <form id="form1" runat="server">
                <h3 class="mr-auto">Registro de indicadores de CONTRALAFT</h3>
                <p class="mb-5 mr-auto">Ingresar el usuario y contraseña asignados</p>
                <div class="form-group">
                  <div class="input-group">
                    <div class="input-group-prepend">
                      <span class="input-group-text"><i class="mdi mdi-account-outline"></i></span>
                    </div>
                    <input type="text" class="form-control login-input-text" id="txtCodigo" runat="server" autocomplete="off" maxlength="80" placeholder="Usuario"/>
                  </div>
                </div>
                <div class="form-group">
                  <div class="input-group">
                    <div class="input-group-prepend">
                      <span class="input-group-text"><i class="mdi mdi-lock-outline"></i></span>
                    </div>
                    <input type="password" class="form-control login-input-text" placeholder="Contraseña" id="txtContra" runat="server" />
                  </div>
                </div>
                <div class="form-group">
                  <asp:Button  class="btn btn-primary submit-btn" ID="Button1" runat="server" Text="Acceder" OnClick="Submit_Login" />
                </div>
                <div class="wrapper mt-5" style="float:right">
                    <img src="../images/giz.jpg" />
                </div>
              </form>
            </div>
          </div>
        </div>
      </div>
      <!-- content-wrapper ends -->
    </div>
    <!-- page-body-wrapper ends -->
  </div>

    <script src="../../vendors/js/vendor.bundle.base.js"></script>
  <script src="../../vendors/js/vendor.bundle.addons.js"></script>
</body>
</html>



