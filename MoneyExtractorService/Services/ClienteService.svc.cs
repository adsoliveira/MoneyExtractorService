using System;
using System.Collections.Generic;
using System.Linq;
using MoneyExtractorService.Entities;
using MoneyExtractorService.Processors;

namespace MoneyExtractorService.Services
{
   
    public class ClienteService : IClienteService
    {
        public PaymentDataResponse SellProduct(PaymentDataRequest paymentData)
        {

            PaymentDataResponse paymentDataResponse = new PaymentDataResponse();

            try
            {
                //Validando valor recebido
                if (paymentData.IsValid == false)
                {
                    paymentDataResponse.ErrorReportList = paymentData.ValidationMessageList;
                    return paymentDataResponse;
                }

                //Calculando o troco
                long change = paymentData.PaidAmountInCents - paymentData.ProductAmountInCents;

                paymentDataResponse.TotalAmountInCents = change;

                //Chamar o Factory enquanto houver troco
                AbstractProcessor processor = null;
                                
                // Dictionary<ChangeType, Dictionary<long, long>> changeTotalResult = new Dictionary<ChangeType, Dictionary<long, long>>();

                    while (change > 0)
                    {
                        processor = ProcessorFactory.Create(change);

                        if (processor == null)
                        {
                            break;
                        }
                        Dictionary<long, long> calculateChangeResult = processor.CalculateChange(change);

                        paymentDataResponse.ChangeData.ChangeTotalResult.Add(processor.GetChangeType(), calculateChangeResult);

                        //TODO: Montar o ChangeData com os valores retornados
                        long remainingAmount = calculateChangeResult.Sum(c => c.Key * c.Value);

                        change = change - remainingAmount;
                    }

                    paymentDataResponse.Success = true;

                
            }
            catch (Exception)
            {
                throw;
            }

            return paymentDataResponse;
        }
    }
}
