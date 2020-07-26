﻿using System;
using System.Text;
using System.Security.Cryptography;
using SBS.UIF.CONTRALAFT.BusinessLogic.Core;
using SBS.UIF.CONTRALAFT.Entity.Core;

namespace SBS.UIF.CONTRALAFT.Web.pages
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_Login(object sender, EventArgs e)
        {
            try
            {
                Usuario _usuario = new Usuario();
                SHA256Managed sha = new SHA256Managed();
                byte[] pass = Encoding.Default.GetBytes(txtContra.Value);
                byte[] passCifrado = sha.ComputeHash(pass);
                _usuario.DetContrasenia = BitConverter.ToString(passCifrado).Replace("-", "");
                _usuario.DetCodigo = txtCodigo.Value;
                _usuario = new UsuarioBusinessLogic().buscarUsuario(_usuario);
                Session["Usuario"] = _usuario;
                Response.Redirect("usuario.aspx");
                MsgServidor("sadasd");
            }
            catch (Exception ex)
            {
                Console.Write( ex);
            }

        }

        private void MsgServidor(string pmessage)
        {
            /*idModalInfoServer.Visible = true;
            lblMensajeOk.Text = pmessage;*/
        }
    }
}