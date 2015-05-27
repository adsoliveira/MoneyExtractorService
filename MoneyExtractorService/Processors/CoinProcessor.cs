using MoneyExtractorService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyExtractorService.Processors
{
    public sealed class CoinProcessor : AbstractProcessor
    {
        internal override IEnumerable<long> MoneyTypeList
        {
            get
            {
                return new long[] { 100, 50, 25, 10, 5, 1 };
            }
        }
        public override string GetName()
        {
            return "Coin";
        }

        public override Entities.ChangeType GetChangeType()
        {
            return ChangeType.Coin;
        }
    }
}