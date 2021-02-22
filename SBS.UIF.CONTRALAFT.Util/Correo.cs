using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
using System.Web.Configuration;
using System.Text;

namespace SBS.UIF.CONTRALAFT.Util
{
    public class Correo
    {

        public void SendMail(Comunicacion _comunicacion)
        {
            var Mensaje = new MailMessage();
            Mensaje.To.Add(new MailAddress(_comunicacion.CorreoUsuario));
            Mensaje.From = new MailAddress(WebConfigurationManager.AppSettings["AdminUser"]);
            Mensaje.Subject = _comunicacion.Subject;
            Mensaje.Body = Plantilla_Nuevo_Usuario(_comunicacion);
            Mensaje.IsBodyHtml = true;
         

            using (var smtp = new SmtpClient())
            {
                var credencial = new NetworkCredential
                {
                    UserName = WebConfigurationManager.AppSettings["AdminUser"],
                    Password = WebConfigurationManager.AppSettings["AdminPassword"],
                };

                smtp.Credentials = credencial;
                smtp.Host = WebConfigurationManager.AppSettings["SMTPName"];
                smtp.Port = int.Parse(WebConfigurationManager.AppSettings["SMTPPort"]);
                smtp.EnableSsl = true;
                smtp.Send(Mensaje);

            }
        }

        public String Plantilla_Nuevo_Usuario(Comunicacion _comunicacion)
        {
            
            StringBuilder msg = new StringBuilder();
            msg.Append("<table border='0' align='center'>");
            msg.Append("<tr style='line - height:24px; font-size:16px'><td align='center'><strong>");
            msg.Append("Se le ha creado el acceso para ingresar al módulo de monitoreo en el cumplimiento de las acciones del Plan Nacional contra el LA/FT 2018-2021:</strong></td></tr>");
            msg.Append("<tr><td>&nbsp;</td></tr>");
            msg.Append("<tr><td align='center'>Datos de acceso:</td></tr>");
            msg.Append("<tr><td>&nbsp;</td></tr>");
            if (_comunicacion.IdPerfil > 2)
                msg.Append("<tr><td align='center'>Entidad: <strong>"); msg.Append(_comunicacion.Entidad);msg.Append("</strong></td></tr>");
            msg.Append("<tr><td align='center'>Perfil: <strong>"); msg.Append(_comunicacion.Perfil); msg.Append("</strong></td></tr>");
            msg.Append("<tr><td align='center'>Destinatario: <strong>"); msg.Append(_comunicacion.NombreUsuario); msg.Append("</strong></td></tr>");
            msg.Append("<tr><td align='center'>Acceso: <strong>"); msg.Append(_comunicacion.UserId); msg.Append("</strong></td></tr>");
            msg.Append("<tr><td align='center'>Contraseña: <strong>"); msg.Append(_comunicacion.Pass); msg.Append("</strong></td></tr>");
            msg.Append("</table>");
            return msg.ToString();

        }

    }
}