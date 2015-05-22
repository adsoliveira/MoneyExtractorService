using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyExtractorService.Entities
{
    public class PaymentDataResponse : AbstractResponse
    {
        public PaymentDataResponse() { }

        public long  TotalAmountInCents { get; set; }

        public ChangeData changeData { get; set; }

        public string  Message { get; set; }
    }
}