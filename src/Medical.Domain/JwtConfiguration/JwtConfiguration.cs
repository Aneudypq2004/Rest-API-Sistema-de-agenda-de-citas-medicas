using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Domain.JwtConfiguration
{
    public class JwtConfiguration
    {
        public string Section { get; set; } = "JwtOptions";
        public string? ValidIssuer { get; set; }

        public string? ValidAudience { get; set; }

    }
}
