using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyExtractorService.Entities
{
    public class PaymentDataRequest : AbstractRequest
    {
        //Valor do produto
        public long ProductAmountInCents { get; set; }

        //Valor pago pelo cliente
        public long PaidAmountInCents { get; set; }

        protected  override void Validate()
        {
            //varificar se valor pago é maior que 0
            if (this.PaidAmountInCents <= 0)
            {
                this.AddError("PaidAmountInCents", "Paid amount must be greater than zero.");
            }

            //verifica se o velor do produto é maior que 0
            if (this.ProductAmountInCents <= 0)
            {
                this.AddError("ProductAmountInCents", "Product amount must be greater then zero");
            }

            //Verifica se o valor pago e maior que o valor do produto
            if (this.PaidAmountInCents<this.ProductAmountInCents)
            {
                this.AddError("PaidAmountInCents", "The paid amount must be grater or equal than the product amount.");
            }


        }
    }
}