using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MoneyExtractorService.Entities;

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

                if (change == 0)
                {
                    paymentDataResponse.Message = "Pagamento Efetuado, não há troco.";                    
                }
                //else
                //{
                //    Dictionary<long, long> billCollection = new Bill().CalculateChange(change);

                //    //TODO: Ler nas configuraçôes a ordem dos tipos de retorno (Cédula > Moeda > ...)
                //    long remainingAmount = change - billCollection.Sum(amount => amount.Key * amount.Value);

                //    paymentDataResponse.ChangeData = new ChangeData();

                //    paymentDataResponse.ChangeData.ChangeTotalResult.Add(ChangeType.Bill, billCollection);

                //    //TODO: Montar loop para os tipos de retorno
                //    if (remainingAmount > 0) {

                //        Dictionary<long, long> coinCollection = new Coin().CalculateChange(remainingAmount);

                //        paymentDataResponse.ChangeData.ChangeTotalResult.Add(ChangeType.Coin, coinCollection);
                //    }

                //    //TODO: Montar o ChangeData com os valores retornados
                //}

            }
            catch (Exception)
            {
                throw;
            }

            return paymentDataResponse;
        }
    }
}
