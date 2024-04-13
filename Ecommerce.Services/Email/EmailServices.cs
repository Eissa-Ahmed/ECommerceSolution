namespace Ecommerce.Services.Email;

public sealed class EmailServices : IEmailServices
{
    private readonly EmailSettings _emailSettings;
    public EmailServices(EmailSettings emailSettings)
    {
        _emailSettings = emailSettings;
    }
    public async Task<string> SendEmail(string sendTo, string message, string subject)
    {
        try
        {
            //MimeMessage
            MimeMessage mimeMessage = new MimeMessage();
            mimeMessage.From.Add(new MailboxAddress(_emailSettings.fromName, _emailSettings.fromEmail));
            mimeMessage.To.Add(new MailboxAddress(sendTo.Substring(sendTo.IndexOf("@")), sendTo));
            mimeMessage.Subject = subject;
            var bodybuilder = new BodyBuilder
            {
                HtmlBody = message,
            };
            mimeMessage.Body = bodybuilder.ToMessageBody();

            //sending the Message of passwordResetLink
            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(_emailSettings.host, _emailSettings.port, false);
                await client.AuthenticateAsync(_emailSettings.fromEmail, _emailSettings.password);

                await client.SendAsync(mimeMessage);
                await client.DisconnectAsync(true);
            }
            //end of sending email
            return "Success";
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
