using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Text;

namespace Interna.Entity
{
    public class NotificacionEmail : Core.Entity
    {
        #region Propiedades

        public string correoOrigen { get; set; }
        public string nombreCorreo { get; set; }
        public string claveCorreoOrigen { get; set; }

        public List<string> correosDestino { get; set; }
        public List<string> correosDestinoCc { get; set; }
        public string asunto { get; set; }

        public string mensaje { get; set; }

        public string pathImagen { get; set; }

        public string contentId { get; set; }
        public string smtpHost { get; set; }
        
        public MemoryStream adjunto { get; set; }
        public string nombreAdjunto { get; set; }

        #endregion

        public NotificacionEmail(string smtpHost)
        {
            correosDestino = new List<string>();
            correosDestinoCc = new List<string>();
            this.smtpHost = smtpHost;
        }

        public void EnviarCorreo()
        {
            if (this.correosDestino == null) return;
            if (this.correosDestino.Count == 0) return;
            if (this.correoOrigen == null) return;
            if (this.correoOrigen.Trim().Length == 0) return;
            if (this.claveCorreoOrigen.Trim().Length == 0) return;

            //Aquí es donde se hace lo especial
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential(correoOrigen, claveCorreoOrigen);
            client.Port = 587;
            client.Host = this.smtpHost;
            client.EnableSsl = true; //Esto es para que vaya a través de SSL que es obligatorio con GMail


            try
            {
                using (var msg = new MailMessage())
                {
                    msg.From = new MailAddress(correoOrigen, nombreCorreo, System.Text.Encoding.UTF8);
                    msg.Subject = this.asunto;
                    msg.SubjectEncoding = Encoding.UTF8;
                    foreach (string destino in correosDestino) msg.To.Add(destino);
                    foreach (string destinoCc in correosDestinoCc) msg.CC.Add(destinoCc);                                       


                    if (pathImagen != null)
                    {
                        if (pathImagen.Length > 0)
                        {
                            this.contentId = "testImage";

                            msg.Attachments.Add(new Attachment(pathImagen));
                            //msg.Attachments[0].ContentId = this.contentId;
                        }
                    }

                    msg.Body = this.mensaje;
                    msg.BodyEncoding = Encoding.UTF8;
                    msg.IsBodyHtml = true;

                    if (this.adjunto != null)
                    {
                        var attachment = new Attachment(adjunto, nombreAdjunto, "text/csv");
                        msg.Attachments.Add(attachment);
                    }


                    client.Send(msg);
                }
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
    }
}
