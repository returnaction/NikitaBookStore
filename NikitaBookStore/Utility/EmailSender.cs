using Microsoft.AspNetCore.Identity.UI.Services;

namespace NikitaBookStore.Utility
{
    public class EmailSender : IEmailSender
    {
        public  Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Task.CompletedTask; 
        }
    }
}
