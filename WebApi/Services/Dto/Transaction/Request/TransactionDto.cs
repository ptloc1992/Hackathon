using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Dto.Transaction.Request
{
    public class TransactionDto
    {
        public string transaction_amount { get; set; }
        public string source_account_id { get; set; }
        public string transaction_currency { get; set; }
        public string remarks { get; set; }
        public string trace_number { get; set; }
        public string destination_contact_id { get; set; }
    }
}
