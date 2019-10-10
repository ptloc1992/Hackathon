using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Enums;

namespace WebApi.Dtos.Profile.Request
{
    public class ProfileRequestDto
    {
        public string next_start_index { get; set; }
        public string major_type { get; set; }
        public string major_category { get; set; }
        public string status { get; set; }
        public string account_id { get; set; }
        public string currency { get; set; }
    }
}
