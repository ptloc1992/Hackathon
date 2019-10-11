using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Dtos.Transaction.Request
{
    public class TransactionRequestDto
    {
        public string next_start_index { get; set; }
        public string fromdate { get; set; }
        public string todate { get; set; }
        public string trace_number { get; set; }
    }
}
