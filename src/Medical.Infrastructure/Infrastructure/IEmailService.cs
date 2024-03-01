using Medical.Domain.Entities;

namespace Medical.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(Email EmailSend);
    }
}
