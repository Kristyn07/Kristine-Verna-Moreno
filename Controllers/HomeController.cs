using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using KristineVernaMorenoV1._2.Models;
using Microsoft.Extensions.Options;


namespace KristineVernaMorenoV1._2.Controllers
{
    public class HomeController : Controller
    {
        private readonly SmtpSettings _smtpSettings;

        public HomeController(IOptions<SmtpSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings.Value;
        }
        public IActionResult Index()
        {
            return View();
        }        
        
        
        [HttpPost]
        // Contact Form
        public IActionResult Index(KristineVernaMorenoV1._2.Models.HomeModel model)
        {

            MailMessage mail = new MailMessage(_smtpSettings.User, model.MailTo)
            {
                Subject = model.Subject ?? "Thank you for reaching out to us!",
                Body = $@"
                        <html>
                            <body style='font-family: Arial, sans-serif;'>
                                <div style='max-width: 80%; margin: 0 auto; padding: 20px; background-color: #f4f4f4; border-radius: 15px;'>
                                    <!-- Logo Image -->
                                    <div style='text-align: center; margin-bottom: 20px;'>
                                        <img src='https://kristinevernamoreno-dbdxhpgzg2gcgjdw.southeastasia-01.azurewebsites.net/images/logo.png' alt='TYN' style='max-width: 150px; height: auto;' />
                                    </div>
        
                                    <h2 style='text-align: center; color: #2c3e50;'>Thank you for reaching out, <span style='color: #c762f6;'>{model.Name}</span>!</h2>
                                    <p style='font-size: 16px; color: #34495e;'>I have successfully received your message and will respond as soon as possible.</p>
        
                                    <hr style='border: 1px solid #ecf0f1;'> 

                                    <h3 style='color: #49b6b6;'>Here are the details of your submission:</h3>
                                    <table style='width: 100%; margin-top: 10px; border-collapse: collapse;'>
                                        <tr>
                                            <td style='font-size: 14px; color: #7f8c8d; padding: 5px 0;vertical-align: top;'><strong>Name:</strong></td>
                                            <td style='font-size: 14px; color: #2c3e50; padding: 5px 0;'>{model.Name}</td>
                                        </tr>
                                        <tr>
                                            <td style='font-size: 14px; color: #7f8c8d; padding: 5px 0;vertical-align: top;'><strong>Email:</strong></td>
                                            <td style='font-size: 14px; color: #2c3e50; padding: 5px 0;'>{model.MailTo}</td>
                                        </tr>
                                        <tr>
                                            <td style='font-size: 14px; color: #7f8c8d; padding: 5px 0;vertical-align: top;'><strong>Subject:</strong></td>
                                            <td style='font-size: 14px; color: #2c3e50; padding: 5px 0;'>{model.Subject}</td>
                                        </tr>
                                        <tr>
                                            <td style='font-size: 14px; color: #7f8c8d; padding: 5px 0;vertical-align: top;'><strong>Message:</strong></td>
                                            <td style='font-size: 14px; color: #2c3e50; padding: 5px 0;'>{model.Body}</td>
                                        </tr>
                                    </table>

                                    <hr style='border: 1px solid #ecf0f1;'> 

                                    <p style='font-size: 12px; color: #34495e; margin-top:20px '>Best regards,</p>
                                    <p style='font-size: 12px; color: #34495e;'>Kristine Verna Moreno<br>kristinevernamoreno1@gmail.com</p>
        
                                    <p style='font-size: 12px; color: #95a5a6; text-align:center'>This is an automated response. Feel free to reply to this email if you have any further questions or need additional assistance.</p>

                                    <hr style='border: 1px solid #ecf0f1;'> 

                                    <p style='text-align: center; color: #7f8c8d; font-size: 14px;'>kristinevernamoreno.com</p>
                                </div>
                            </body>
                        </html>",
                IsBodyHtml = true
            };

            mail.CC.Add(_smtpSettings.User); 
            mail.Bcc.Add(_smtpSettings.User);

            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                Credentials = new NetworkCredential(_smtpSettings.User, _smtpSettings.Pass) 
            };

            try
            {
                smtp.Send(mail);
                return Json(new { success = true, message = "Mail has been sent successfully" });
            }
            catch (SmtpException ex)
            {
                return Json(new { success = false, message = ex.Message });

            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}
