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
 
            //Armazenar o resultado
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

                long totalAmountInCents = change;

                //Chamar o Factory enquanto houver troco
                AbstractProcessor processor = null;
                                
                Dictionary<ChangeType, Dictionary<long, long>> changeTotalResult = new Dictionary<ChangeType, Dictionary<long, long>>();

                    while (change > 0)
                    {
                        processor = ProcessorFactory.Create(change);

                        if (processor == null)
                        {
                            paymentDataResponse.Message = "Não foi possível efetuar sua compra.";
                            break;
                        }
                        Dictionary<long, long> calculateChangeResult = processor.CalculateChange(change);
                                                
                        changeTotalResult.Add(processor.GetChangeType(), calculateChangeResult);

                        //TODO: Montar o ChangeData com os valores retornados
                        long remainingAmount = calculateChangeResult.Sum(c => c.Key * c.Value);

                        change = change - remainingAmount;
                    }

                   if (change == 0)
                    {

                        paymentDataResponse.Success = true;

                        paymentDataResponse.TotalAmountInCents = totalAmountInCents;
                        paymentDataResponse.ChangeData.ChangeTotalResult = changeTotalResult;
                    }
            }
            catch (Exception)
            {                
                paymentDataResponse.Message = "Error ao processar sua compra.";
            }
            
            return paymentDataResponse;
        }
    }
}
