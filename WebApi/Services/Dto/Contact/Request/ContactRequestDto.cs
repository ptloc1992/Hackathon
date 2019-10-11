using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Dto.Contact.Request
{
    public class ContactRequestDto
    {
        public string next_start_index { get; set; }
        public string bank_account_id { get; set; }
        public string card_number { get; set; }
        public string type { get; set; }
    }
}
