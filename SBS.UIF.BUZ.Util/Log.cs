using System;
using System.Collections.Generic;
using System.Web;
using System.Configuration;
using System.IO;
using System.Xml;
using System.Text;
using System.Net;

namespace SBS.UIF.BUZ.Util
{
    public class Log {
        public static void Registrar(string pnamespace, string pclass, string pmethod, string plevel, string perrorMessage, string perrorMessageDetail) {
            StringBuilder sb = new StringBuilder();
            string logPath = ConfigurationManager.AppSettings["logPath"].ToString();
            string applicationName = ConfigurationManager.AppSettings["applicationName"].ToString();

            if (string.IsNullOrEmpty(logPath)) {
                logPath = HttpContext.Current.Server.MapPath("\\");

            } else if (!Directory.Exists(logPath)) {
                Directory.CreateDirectory(logPath);
            }

            string fileNameWithPath = string.Format("{0}\\logs\\{1}_LOG_{2}.log", logPath, applicationName, DateTime.Now.ToString("yyyyMM"));

            if (File.Exists(fileNameWithPath)) {
                using (StreamReader sr = new StreamReader(fileNameWithPath)) {
                    sb.Append(sr.ReadToEnd());
                }
            }

            using (StreamWriter sw = new StreamWriter(fileNameWithPath)) {
                sw.Write(sb);
                sw.WriteLine("Date:{0}", DateTime.Now.ToString("dd/MM/yyyy"));
                sw.WriteLine("Time:{0}", DateTime.Now.ToString("hh:mm:ss tt"));
                sw.WriteLine("Host:{0}", ObtenerDireccionIP());
                sw.WriteLine("User:{0}\\{1}", Environment.UserDomainName, Environment.UserName);
                sw.WriteLine("Application:{0}", applicationName);
                sw.WriteLine("Namespace:{0}", pnamespace);
                sw.WriteLine("Class:{0}", pclass);
                sw.WriteLine("Method:{0}", pmethod);
                sw.WriteLine("Level:{0}", plevel);
                sw.WriteLine("ErrorMessage:{0}", perrorMessage);
                sw.WriteLine("ErrorMessageDetail:{0}", perrorMessageDetail);
                sw.WriteLine(new String('_', 100));
            }
        }

        public static string ObtenerDireccionIP() {
            HttpRequest currentRequest = HttpContext.Current.Request;
            string ipAddress = currentRequest.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (ipAddress == null || ipAddress.ToLower() == "unknown")
                ipAddress = currentRequest.ServerVariables["REMOTE_ADDR"];

            //ADD IPLAN;
            if (ipAddress == "::1") {
                foreach (IPAddress IPA in Dns.GetHostAddresses(Dns.GetHostName())) {
                    if (IPA.AddressFamily.ToString() == "InterNetwork") {
                        ipAddress = IPA.ToString();
                        break;
                    }
                }
            }

            return ipAddress;
        }

    }
}