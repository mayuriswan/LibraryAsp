﻿using Microsoft.AspNetCore.Identity.UI.Services;

namespace LibrairieDTICRosemont
{
    public class DummyEmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // Do nothing, as this is a dummy implementation
            return Task.CompletedTask;
        }
    }
}
