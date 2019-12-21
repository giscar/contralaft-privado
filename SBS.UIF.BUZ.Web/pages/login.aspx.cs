using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Text;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Data;
using SBS.UIF.BUZ.BusinessLogic.Core;
using SBS.UIF.BUZ.Entity.Common;

namespace SBS.UIF.BUZ.Web.pages.login
{
    public partial class login : System.Web.UI.Page
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
                _usuario.password = BitConverter.ToString(passCifrado).Replace("-", "");
                _usuario.nombre = txtNombrePersona.Value;
                _usuario = new UsuarioBusinessLogic().buscarUsuario(_usuario);
                Session["Usuario"] = _usuario;
                Response.Redirect("usuario.aspx");
                MsgServidor("sadasd");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void MsgServidor(string pmessage)
        {
            /*idModalInfoServer.Visible = true;
            lblMensajeOk.Text = pmessage;*/
        }
    }
}