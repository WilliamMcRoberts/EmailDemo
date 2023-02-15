using MailKit.Net.Smtp;
using MimeKit;

MimeMessage message = new MimeMessage();

message.From.Add(new MailboxAddress("William", "devsknow@gmail.com"));

message.To.Add(MailboxAddress.Parse("wamcroberts2@gmail.com"));

message.Subject = "Test";

message.Body = new TextPart("plain")
{
    Text = @"Yes, 
    Hello!.
    This is a test!."
};

try
{
    using (var client = new SmtpClient())
    {
        client.Connect("smtp.gmail.com", 465);

        Console.WriteLine("Connected!");

        // 1. Enable IMAP 2. Create an "App Password" in Gmail 3. Use that password to authenticate
        client.Authenticate("devsmeknow@gmail.com", "<YOURAPPPASSWORD>");

        Console.WriteLine("Authenticated!");

        client.Send(message);

        client.Disconnect(true);

        Console.WriteLine("Email Sent!");

    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

