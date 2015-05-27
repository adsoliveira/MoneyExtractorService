using MoneyExtractorClient.MoneyExtractorServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyExtractorClient
{
     public partial class Program
    {
        static void Main(string[] args)
        {
            ClienteServiceClient client = new ClienteServiceClient();
            
            PaymentDataRequest paymentDataRequest = new PaymentDataRequest();

            //Valor a pagar
            Console.WriteLine("Valor do Produto: ");
            paymentDataRequest.ProductAmountInCents = long.Parse(Console.ReadLine());

            //Valor pago
            Console.WriteLine("Valor Pago: ");
            paymentDataRequest.PaidAmountInCents = long.Parse(Console.ReadLine());

            PaymentDataResponse paymentDataResponse = client.SellProduct(paymentDataRequest);

            Console.WriteLine(paymentDataResponse.Message ?? string.Empty);
            if (paymentDataResponse.changeData != null)
            {

                String changeInfo = string.Format("Valor do troco: {0}\r\n", ((decimal)paymentDataResponse.TotalAmountInCents / 100).ToString("N2"));

                foreach (KeyValuePair<MoneyExtractorClient.MoneyExtractorServiceReference.ChangeType, Dictionary<long, long>> change in paymentDataResponse.changeData.ChangeTotalResult)
                {

                    foreach (KeyValuePair<long, long> item in change.Value)
                    {

                        changeInfo += string.Format("{0} {1} de {2}\r\n", item.Value, change.Key, ((decimal)item.Key / 100).ToString("N2"));
                    }
                }
                Console.WriteLine("Troco: " + changeInfo);
            }
        }
    }
}
