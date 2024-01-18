using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Domain.Entities
{
    public class AuthenticateResponse
    {
        public string Token { get; set; } = string.Empty;
    }
}
