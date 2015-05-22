using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyExtractorService.Entities
{
    public class ChangeData
    {
        public ChangeData()
        {
            ChangeTotalResult = new Dictionary<ChangeType, Dictionary<long, long>>();
        }
        public Dictionary<ChangeType, Dictionary<long, long>> ChangeTotalResult { get; set; }
    }
}