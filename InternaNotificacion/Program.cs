using CsvHelper;
using Interna.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Messaging;
using System.Net.Mail;
using System.Net;
using System.Threading;
using System.Text;
using System.Collections;

namespace InternaNotificacion
{
    public class Program
    {
        static string queuePathEntregaPisos = ConfigurationManager.AppSettings["queuePathEntregaPisos"];
        static string queuePathEntregaAgencias = ConfigurationManager.AppSettings["queuePathEntregaAgencias"];
        static string from = ConfigurationManager.AppSettings["from"];
        static string alias = ConfigurationManager.AppSettings["alias"];
        static string password = ConfigurationManager.AppSettings["password"];
        static string subject = ConfigurationManager.AppSettings["subject"];
        static string smtpHost = ConfigurationManager.AppSettings["smtpHost"];
        static string entregaRutaAgenciasJos = ConfigurationManager.AppSettings["entregaRutaAgenciasJos"];
        static string linkConfirmar = ConfigurationManager.AppSettings["linkConfirmar"];
        static string linkRecepcionarJos = ConfigurationManager.AppSettings["linkRecepcionarJos"];
        static string correoContacto = ConfigurationManager.AppSettings["correoContacto"];
        static string nombreArchivoAdjuntoJOS = ConfigurationManager.AppSettings["nombreArchivoAdjuntoJOS"];
        static string nombreArchivoAdjuntoPisos = ConfigurationManager.AppSettings["nombreArchivoAdjuntoPisos"];
        static string correosPrueba = ConfigurationManager.AppSettings["correosPrueba"];
        static string pruebaHabilitada = ConfigurationManager.AppSettings["pruebaHabilitada"];
        static string colorFondoCabeceraTabla = ConfigurationManager.AppSettings["colorFondoCabeceraTabla"];
        static string colorTextoCabeceraTabla = ConfigurationManager.AppSettings["colorTextoCabeceraTabla"];
        static string archivoAdjuntoFullPath = ConfigurationManager.AppSettings["archivoAdjuntoFullPath"];
        static string archivoAdjuntoAgenciasFullPath = ConfigurationManager.AppSettings["archivoAdjuntoAgenciasFullPath"];

        

        static void Main()
        {


            Thread thread1 = new Thread(() => EscucharColaNotificacionPisos(queuePathEntregaPisos, "Cola Pisos"));

            thread1.Start();

            Thread thread2 = new Thread(() => EscucharColaNotificacionAgencias(queuePathEntregaAgencias, "Cola Agencias"));

            thread2.Start();

            Console.WriteLine("Presione [Enter] para salir.");
            Console.ReadLine();

        }

        static byte[] GenerateCsvInMemory(List<CorrespondenciaNotificacionExportar> data)
        {

            var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream))
            using (var csvWriter = new CsvHelper.CsvWriter(streamWriter, CultureInfo.CurrentCulture, false))
            {
                csvWriter.WriteRecords(data);
                streamWriter.Flush();
                memoryStream.Seek(0, SeekOrigin.Begin);

                return memoryStream.ToArray();
            }

        }
                
        static void GenerarMensajePisos(int entregaId)
        {
            try
            {
                Objeto objeto = new Objeto();
                string correspondenciaPorNotificarJSON = objeto.CorrespondenciaPorNotificarEntregaBandejaFisica(entregaId);
                if (correspondenciaPorNotificarJSON == null) return;
                List<CorrespondenciaNotificacion> correspondenciaNotificacionList = JsonConvert.DeserializeObject<List<CorrespondenciaNotificacion>>(correspondenciaPorNotificarJSON);
                List<string> bandejaList = correspondenciaNotificacionList.Select(correspondencia => correspondencia.BandejaVirtualDestino).Distinct().ToList();
                foreach (string bandeja in bandejaList)
                {
                    List<CorrespondenciaNotificacion> correspondenciaGrupo = correspondenciaNotificacionList.Where(correspondencia => correspondencia.BandejaVirtualDestino == bandeja).ToList();

                    string bandejaFisica = correspondenciaGrupo[0].BandejaFisica;
                    string[] correosNotificacion = correspondenciaGrupo[0].CorreoUsuario.Split(',');
                    DateTime fechaHoraResultado = correspondenciaGrupo[0].FechaHoraResultado;

                    List<string> listaDocumentos = new List<string>();
                    foreach (CorrespondenciaNotificacion correspondencia in correspondenciaGrupo) listaDocumentos.Add(correspondencia.Autogenerado);

                    string textoMensaje = "";
                    string tablaDatos = "";
                    if (listaDocumentos.Count() > 1)
                    {
                        //{string.Join(", ", listaDocumentos)}
                        textoMensaje = $"se han dejado los siguientes documentos en tu bandeja física <span style=\"color: #002D74; font-weight: bold; \">({bandejaFisica})</span>.";
                    }
                    else
                    {
                        //{listaDocumentos[0]} 
                        textoMensaje = $"se ha dejado el siguiente documento en tu bandeja física <span style=\"color: #002D74; font-weight: bold; \">({bandejaFisica})</span>.";
                    }

                    tablaDatos += "<table  style=\"border-collapse: collapse; width: 50%; margin: 0 0; border: 2px solid #002D74;\">";
                    tablaDatos += "<tr>";
                    tablaDatos += $"<th style=\"background-color:{colorFondoCabeceraTabla}; color: {colorTextoCabeceraTabla}; padding: 10px; border: 2px solid #002D74;\">Documento</th>";
                    tablaDatos += $"<th style=\"background-color:{colorFondoCabeceraTabla}; color: {colorTextoCabeceraTabla}; padding: 10px; border: 2px solid #002D74;\">Tipo</th>";
                    tablaDatos += "</tr>";

                    List<CorrespondenciaNotificada> listaCorrespondenciaNotificada = new List<CorrespondenciaNotificada>();
                    foreach (CorrespondenciaNotificacion correspondencia in correspondenciaGrupo)
                    {
                        CorrespondenciaNotificacionExportar item = new CorrespondenciaNotificacionExportar();
                        item.Autogenerado = correspondencia.Autogenerado;
                        item.TipoDocumento = correspondencia.TipoDocumento;
                        CorrespondenciaNotificada correspondenciaNotificada = new CorrespondenciaNotificada();
                        correspondenciaNotificada.autogenerado = correspondencia.Autogenerado;
                        listaCorrespondenciaNotificada.Add(correspondenciaNotificada);

                        tablaDatos += $"<tr>";
                        tablaDatos += $"<td style=\"background-color: #FFF; color: #333; padding: 10px; border: 2px solid #333;\">{correspondencia.Autogenerado}</td>";
                        tablaDatos += $"<td style=\"background-color: #FFF; color: #333; padding: 10px; border: 2px solid #333;\">{correspondencia.TipoDocumento}</td>";
                        tablaDatos += $"</tr>";
                    }
                    tablaDatos += "</table>";

                    string emailBody = "<!DOCTYPE html><html><body>";
                   
                    emailBody += tablaDatos;

                    emailBody += "<p style=\"font-style: italic;\">¡Aprovecha en realizar una pausa activa y pasa a recoger el documento a la bandeja!</p>";
                    emailBody += $"<p style=\"font-style: italic;\">Una vez realizado, favor ingresar al siguiente link <a href='{linkConfirmar}'>{linkConfirmar}</a> para realizar el descargo y confirmar la entrega.</p>";
                    emailBody += "<p style=\"font-style: italic;\">También adjuntamos manual para que puedas realizar el mismo.</p>";
                    emailBody += $"<p style=\"font-style: italic;\">Que tengas un excelente día</p>";
                    emailBody += $"<p><span style=\"color: #002D74; font-weight: bold; \">SIMIH</span></p>";
                    emailBody += "</body></html>";

                    string pathFile = $@"{archivoAdjuntoFullPath}";

                    if (pruebaHabilitada == "1")
                    {
                        List<string> correosPermitidos = correosPrueba.Split(',').ToList();
                        List<string> listaCorreos = correosNotificacion.ToList();
                        List<string> listaCorreosFinal = new List<string>();
                        foreach (string correo in listaCorreos)
                            if (correosPermitidos.Exists(c => c.ToLower().Trim() == correo.ToLower().Trim()))
                                listaCorreosFinal.Add(correo);

                        if (listaCorreosFinal.Count > 0)
                            SendEmailWithPDFAttachment(smtpHost, 587, from, password, alias, listaCorreosFinal, new List<string>(), subject, emailBody, pathFile, $"Manual.pdf");

                    }
                    else
                    {
                        SendEmailWithPDFAttachment(smtpHost, 587, from, password, alias, correosNotificacion.ToList(),
                        new List<string>(), subject, emailBody, pathFile, $"Manual.pdf");
                    }

                    objeto.ActualizarCorrespondenciaNotificada(entregaId, listaCorrespondenciaNotificada);

                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        static void ProcesarMensaje(Message mensaje, string nombreCola)
        {
            if (nombreCola == "Cola Pisos")
            {
                int entregaId = int.Parse(mensaje.Body.ToString());
                Console.WriteLine($"Mensaje recibido en {nombreCola}: {entregaId}");
                GenerarMensajePisos(entregaId);

                

            }
            else if (nombreCola == "Cola Agencias")
            {
                int loteId = int.Parse(mensaje.Body.ToString());
                Console.WriteLine($"Mensaje recibido en {nombreCola} :  {loteId}");

                Objeto objeto = new Objeto();
                string correspondenciaPorNotificarJSON = "";

                if (entregaRutaAgenciasJos == "1")
                {
                    correspondenciaPorNotificarJSON = objeto.CorrespondenciaPorNotificarEntregaRutaAgenciaJos(loteId);
                    if (correspondenciaPorNotificarJSON == null) return;
                    List<CorrespondenciaNotificacionRutaJos> correspondenciaNotificacionList = JsonConvert.DeserializeObject<List<CorrespondenciaNotificacionRutaJos>>(correspondenciaPorNotificarJSON);
                    List<string> codigoAgenciaList = correspondenciaNotificacionList.Select(correspondencia => correspondencia.CodigoAgencia).Distinct().ToList();

                    foreach (string codigoAgencia in codigoAgenciaList)
                    {
                        List<CorrespondenciaNotificacionRutaJos> correspondenciaGrupo = correspondenciaNotificacionList.Where(correspondencia => correspondencia.CodigoAgencia == codigoAgencia).ToList();
                        string agencia = correspondenciaGrupo[0].Agencia;
                        string[] correosNotificacion = correspondenciaGrupo[0].CorreoUsuario.Split(',');
                        string emailBody = "<!DOCTYPE html><html><body>";
                        emailBody += $"<p style=\"font-style: italic;\">Estimado Sr. Supervisor:</p>";
                        emailBody += $"<p style=\"font-style: italic;\">El día de hoy se está procediendo con el despacho de su(s) valija(s) hacia su agencia, la cual llegará en 01 día útil a su destino.</p>";
                        emailBody += $"<p style=\"font-style: italic;\"><span style=\"font-style: bold;\">Nota:</span> se considera las entregas de Lunes a Viernes.</p>";
                        emailBody += $"<br></br>";
                        emailBody += $"<p style=\"font-style: italic;\">La entrega se realizará de la siguiente forma:</p>";
                        emailBody += $"<p style=\"font-style: italic;\"><ul><li>Lima:</li><li>Provincia: </li></ul></p>";
                        emailBody += $"<p>Al momento de recibir la valija, agradecemos ingrese al siguiente link “Confirmación de Valijas SIMIH” <a href='{linkRecepcionarJos}'>{linkRecepcionarJos}</a></p>";
                        emailBody += $"<br>";
                        emailBody += $"<p style=\"font-style: italic;\">Adjunto el manual con los pasos a seguir para la confirmación de las valijas por partes del JOS (Representantes de las Agencias).</p>";
                        emailBody += $"<br>";
                        emailBody += $"<p style=\"font-style: italic;\"><span style=\"font-style: bold;\">NOTAS ADICIONALES</span></p>";
                        emailBody += $"<br>";
                        emailBody += $"<p style=\"font-style: italic;\"><ul><li> De no recibir su valija dentro del plazo establecido informar misma vía al buzón <a href='mailto:{correoContacto}'>{correoContacto}</a></li><li>De no recibir su confirmación del SIMIH (aplicativo valorados), dentro de las 24hrs de recibida la valija se dará por conforme.</li></ul></p>";
                        emailBody += "<br>";
                        emailBody += $"<p style=\"font-style: italic;\">Según la <span style=\"font-style: bold;\">Norma 4034-011-04-08</span> (Expedición Procesos) se deberá validar la recepción de todos los valorados (autogenerados, verbales, chequeras, campañas) enviado en la valija(s) y/o caja(s).</p>";
                        emailBody += "</body></html>";

                        string pathFile = $@"{archivoAdjuntoAgenciasFullPath}";

                        if (pruebaHabilitada == "1")
                        {
                            List<string> correosPermitidos = correosPrueba.Split(',').ToList();

                            List<string> listaCorreos = correosNotificacion.ToList();
                            List<string> listaCorreosFinal = new List<string>();
                            foreach (string correo in listaCorreos)
                            {
                                if (correosPermitidos.Exists(c => c.ToLower().Trim() == correo.ToLower().Trim()))
                                {
                                    listaCorreosFinal.Add(correo);
                                }

                            }

                            if (listaCorreosFinal.Count > 0)
                            {
                                SendEmailWithPDFAttachment(smtpHost, 587, from, password, alias, listaCorreosFinal,
                                new List<string>(), subject, emailBody, pathFile, $"ManualConfirmaciónValijas.pdf");
                            }                          

                           
                        }
                        else
                        {
                            Console.WriteLine("Se envió correo a : " + string.Join(",", correosNotificacion));

                            SendEmailWithPDFAttachment(smtpHost, 587, from, password, alias, correosNotificacion.ToList(),
                       new List<string>(), subject, emailBody, pathFile, $"ManualConfirmaciónValijas.pdf");
                            
                        }

                    }
                }
                else
                {
                    ////correspondenciaPorNotificarJSON = objeto.CorrespondenciaPorNotificarEntregaRutaAgencia(loteId);
                    ////if (correspondenciaPorNotificarJSON == null) break;
                    ////List<CorrespondenciaNotificacion> correspondenciaNotificacionList =
                    ////JsonConvert.DeserializeObject<List<CorrespondenciaNotificacion>>(correspondenciaPorNotificarJSON);
                    ////List<string> bandejaList = correspondenciaNotificacionList.Select(correspondencia => correspondencia.BandejaVirtualDestino).Distinct().ToList();


                    ////foreach (string bandeja in bandejaList)
                    ////{
                    ////    List<CorrespondenciaNotificacion> correspondenciaGrupo = correspondenciaNotificacionList.Where(correspondencia => correspondencia.BandejaVirtualDestino == bandeja).ToList();

                    ////    string bandejaFisica = correspondenciaGrupo[0].BandejaFisica;
                    ////    string bandejaDestinoVirtual = bandeja;
                    ////    string[] correosNotificacion = correspondenciaGrupo[0].CorreoUsuario.Split(',');

                    ////    Console.WriteLine("Correos destinatarios: " + correosNotificacion);


                    ////    //notificar correo (pasar parametros)

                    ////    NotificacionEmail notificacionEmail = new NotificacionEmail(smtpHost);
                    ////    notificacionEmail.correoOrigen = from;
                    ////    notificacionEmail.nombreCorreo = alias;
                    ////    notificacionEmail.claveCorreoOrigen = password;
                    ////    notificacionEmail.correosDestino.Add("cbaltazar@exact.com.pe");
                    ////    notificacionEmail.correosDestino.Add("cbaltazar@exactsac.onmicrosoft.com");
                    ////    notificacionEmail.asunto = subject;
                    ////    string emailBody = "<!DOCTYPE html><html><body>";
                    ////    emailBody += $"<p>Estimado colaborador, los siguientes documentos se encuentran en ruta hacia  ({bandejaFisica}).</p>";
                    ////    emailBody += "<h3>Documento:</h3>";

                    ////    foreach (CorrespondenciaNotificacion correspondencia in correspondenciaGrupo)
                    ////    {
                    ////        emailBody += $"<p>{correspondencia.Autogenerado}</p>";
                    ////    }

                    ////    emailBody += "<br>";
                    ////    emailBody += "<p>Verifica y confirma a través del sistema ingresando al siguiente enlace:.</p>";
                    ////    emailBody += $"<p><a href='{linkConfirmar}'>{linkConfirmar}</a></p>";
                    ////    emailBody += "</body></html>";
                    ////    notificacionEmail.mensaje = emailBody;
                    ////    notificacionEmail.EnviarCorreo();
                    ////}

                }



            }



        }

        static void EscucharColaNotificacionPisos(string queuePath, string nombreCola)
        {
            using (MessageQueue queue = new MessageQueue(queuePath))
            {
                queue.Formatter = new XmlMessageFormatter(new string[] { "System.String,mscorlib" });
                Console.WriteLine($"Escuchando mensajes desde {nombreCola}...");

                while (true)
                {
                    try
                    {
                        Message mensaje = queue.Receive();
                        ProcesarMensaje(mensaje, nombreCola);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error al procesar mensaje en {nombreCola}: {ex.Message}");
                    }
                }

            }
        }

        static void EscucharColaNotificacionAgencias(string queuePath, string nombreCola)
        {
            using (MessageQueue queue = new MessageQueue(queuePath))
            {
                queue.Formatter = new XmlMessageFormatter(new string[] { "System.String,mscorlib" });
                Console.WriteLine($"Escuchando mensajes desde {nombreCola}...");

                while (true)
                {
                    try
                    {
                        Message mensaje = queue.Receive();
                        ProcesarMensaje(mensaje, nombreCola);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error al procesar mensaje en {nombreCola}: {ex.Message}");
                    }


                }
            }
        }

        static void SendEmailWithAttachment(string smtpServer, int smtpPort, string smtpUsername, string smtpPassword,
        string fromEmail, List<string> toEmail, List<string> toEmailCC, string subject, string body, byte[] attachmentBytes, string attachmentFileName)
        {
            try
            {
                using (var smtpClient = new SmtpClient(smtpServer))
                {
                    smtpClient.Port = smtpPort;
                    smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                    smtpClient.EnableSsl = true;

                    using (var mailMessage = new MailMessage())
                    {
                        mailMessage.From = new MailAddress(smtpUsername, fromEmail, System.Text.Encoding.UTF8);
                        foreach (string email in toEmail) mailMessage.To.Add(email);
                        foreach (string email in toEmailCC) mailMessage.CC.Add(email);
                        mailMessage.Subject = subject;
                        mailMessage.SubjectEncoding = Encoding.UTF8;
                        mailMessage.Body = body;
                        mailMessage.BodyEncoding = Encoding.UTF8;
                        mailMessage.IsBodyHtml = true;

                        // Adjuntar el archivo CSV
                        if (attachmentBytes != null)
                        {
                            var attachment = new Attachment(new MemoryStream(attachmentBytes), attachmentFileName, "text/csv");
                            mailMessage.Attachments.Add(attachment);
                        }

                        // Enviar el correo electrónico
                        smtpClient.Send(mailMessage);
                    }
                }

                Console.WriteLine("Correo electrónico enviado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al enviar el correo electrónico: {ex.Message}");
            }
        }

        static void SendEmailWithPDFAttachment(string smtpServer, int smtpPort, string smtpUsername, string smtpPassword,
        string fromEmail, List<string> toEmail, List<string> toEmailCC, string subject, string body, string pathFile, string attachmentFileName)
        {
            try
            {
                using (var smtpClient = new SmtpClient(smtpServer))
                {
                    smtpClient.Port = smtpPort;
                    smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                    smtpClient.EnableSsl = true;

                    using (var mailMessage = new MailMessage())
                    {
                        mailMessage.From = new MailAddress(smtpUsername, fromEmail, System.Text.Encoding.UTF8);
                        foreach (string email in toEmail) mailMessage.To.Add(email);
                        foreach (string email in toEmailCC) mailMessage.CC.Add(email);
                        mailMessage.Subject = subject;
                        mailMessage.SubjectEncoding = Encoding.UTF8;
                        mailMessage.Body = body;
                        mailMessage.BodyEncoding = Encoding.UTF8;
                        mailMessage.IsBodyHtml = true;

                        // Adjuntar el archivo CSV
                        if (pathFile != null || pathFile.Length > 0)
                        {
                            var attachment = new Attachment(pathFile);
                            mailMessage.Attachments.Add(attachment);
                        }

                        // Enviar el correo electrónico
                        smtpClient.Send(mailMessage);
                    }
                }

                Console.WriteLine("Correo electrónico enviado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al enviar el correo electrónico: {ex.Message}");
            }
        }


    }
}

