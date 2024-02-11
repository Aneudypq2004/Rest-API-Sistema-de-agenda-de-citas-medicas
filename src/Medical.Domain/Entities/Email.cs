namespace Medical.Domain.Entities
{
    public class Email
    {
        public string? To { get; set; }
        public string? From { get; set; } = "Dluisaneudy82@gmail.com";

        public string? Message { get; set; }

        public string? Subject { get; set; }
    }
}
