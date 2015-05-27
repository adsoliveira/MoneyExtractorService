using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyExtractorService.Entities
{
    public class PaymentDataResponse : AbstractResponse
    {
       public PaymentDataResponse()
        {
            this.ChangeData = new ChangeData();
        }

        public long  TotalAmountInCents { get; set; }

        public ChangeData ChangeData { get; set; }

        public string  Message { get; set; }
    }
}