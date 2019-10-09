using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Dtos.User.Response
{
    public class LoginDto
    {
        public string Access_Token { get; set; }
        public long Expires_In { get; set; }
        public long Refresh_Expires_In { get; set; }
        public string Refresh_Token { get; set; }
        public string Token_Type { get; set; }
        public string Session_State { get; set; }
        public string Scope { get; set; }
    }
}
