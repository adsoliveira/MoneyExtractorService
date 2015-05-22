using MoneyExtractorService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MoneyExtractorService.Services
{    
    [ServiceContract] // Contrato do serviço
    public interface IClienteService
    {
        [OperationContract]
         PaymentDataResponse SellProduct(PaymentDataRequest paymentData);
    }
}
