using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO
{
    public class LoginDTO
    {
        public string? Mail { get; set; }
        public string? Password { get; set; }
        public int Code {get;set;}
    }
}
