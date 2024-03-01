namespace Medical.Domain.JwtConfiguration
{
    public class JwtConfiguration
    {
        public string Section { get; set; } = "JwtOptions";
        public string? ValidIssuer { get; set; }

        public string? ValidAudience { get; set; }

    }
}
