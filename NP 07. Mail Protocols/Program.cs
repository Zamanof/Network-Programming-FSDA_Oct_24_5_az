using MailKit.Net.Smtp;
using MimeKit;
//using System.Net;
//using System.Net.Mail;

//SMTP();
SMTPMailKit();

//void SMTP() {
//    var client = new SmtpClient("smtp.gmail.com", 587);
//    client.EnableSsl = true;

//    client.Credentials = new NetworkCredential("fbms.1223@gmail.com", "adppsroljzdrznri");

//    var message = new MailMessage
//    {
//        Subject = "Test",
//        Body = "WINTER IS COMING!!! (WINTER = EXAM)"
//    };
//    message.From = new MailAddress("fbms.1223@gmail.com", "Qurban Qurbanov");

//    message.To.Add(new MailAddress("romandadasov13@gmail.com"));
//    message.To.Add(new MailAddress("abbasesgerli343@gmail.com"));
//    message.To.Add(new MailAddress("ayxanm803@gmail.com"));
//    message.To.Add(new MailAddress("zamanov@itstep.org"));

//    client.Send(message);

//}


void SMTPMailKit()
{
    var client = new SmtpClient();
    client.Connect("smtp.gmail.com", 587);
    client.Authenticate("fbms.1223@gmail.com", "adppsroljzdrznri");

    var message = new MimeKit.MimeMessage();

    message.From.Add(new MailboxAddress("Camel from Refrigirator", "fbms.1223@gmail.com"));

    message.To.AddRange(new[]
    {
        MailboxAddress.Parse("romandadasov13@gmail.com"),
        MailboxAddress.Parse("abbasesgerli343@gmail.com"),
        MailboxAddress.Parse("ayxanm803@gmail.com"),
        MailboxAddress.Parse("zamanov@itstep.org")
    });
    message.Subject = "Exam";
    //message.Body = new TextPart("plain")
    //{
    //    Text = "WINTER IS COMING!!!(WINTER = EXAM)"
    //};

    message.Body = new TextPart("html")
    {
        Text = """
        <h1 style='color:blue;'>WINTER IS COMING!!!(WINTER = EXAM)</h1>
        <br/>
        <img src='https://upload.wikimedia.org/wikipedia/en/1/18/Wana_Decrypt0r_screenshot.png'/>
        <br/>
        <a href="https://pranx.com/hacker/" style="display:inline-block;padding:10px 18px;background:#e53935;color:#fff;text-decoration:none;border-radius:6px;font-weight:600;border:1px solid rgba(0,0,0,0.15);box-shadow:0 2px 0 rgba(0,0,0,0.08);" role="button" aria-label="Dont Click">Dont Click</a>
        """
    };


    client.Send(message);
    client.Disconnect(true);
}
void IMAP() { }
