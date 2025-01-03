using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestJWT.Data.Models
{
    public class Account
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}