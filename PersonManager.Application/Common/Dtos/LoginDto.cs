using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonManager.Application.Account.Queries.Dto
{
    public class LoginDto
    {
        public bool IsOk{ get; set; }
        public string ErrorMess{ get; set; }
        public string Token { get; set; }
    }
}
