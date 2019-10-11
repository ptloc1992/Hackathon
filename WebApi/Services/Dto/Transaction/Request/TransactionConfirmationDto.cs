using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Dto.Transaction.Request
{
    public class TransactionConfirmationDto
    {
        public string code { get; set; }
        public string authorization_id { get; set; }
        public string transaction_id { get; set; }
    }
}
