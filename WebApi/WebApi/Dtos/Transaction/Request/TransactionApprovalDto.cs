using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Dtos.Transaction.Request
{
    public class TransactionApprovalDto
    {
        public string tfa_type { get; set; }
        public bool approve { get; set; }
        public string transaction_id { get; set; }
    }
}
