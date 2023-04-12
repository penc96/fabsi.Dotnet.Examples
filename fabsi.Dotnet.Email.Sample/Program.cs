
using System.Net;
using System.Net.Mail;

string smtpServer = "smtp.web.de";
string senderEmail = "fabian.veltkamp@web.de";
string senderPassword = "b7e4n34zbNekbrZVsKZg";
string[] receivers =
{
    "pencmailer@gmail.com",
    "sarahotten@freenet.de"
};
string emailTitle = "Hello World";
string emailBody = "Hello World";

var emailClient = new SmtpClient
{
    Host = smtpServer,
    Port = 587,
    Credentials = new NetworkCredential(senderEmail, senderPassword),
    EnableSsl = true,
};
CancellationTokenSource ctSource = new CancellationTokenSource();
await emailClient.SendMailAsync(new MailMessage(senderEmail, string.Join(',', receivers), emailTitle, emailBody), ctSource.Token);

Console.Write("Press any key to exit ...");
Console.ReadKey();
