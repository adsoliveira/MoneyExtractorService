using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyExtractorService.Entities
{
    public class Coin
    {
        //Construtor
        public Coin()
        {
            this.CoinCollection = new List<long>{
            100, 50, 25, 10, 5, 1
            };
        }
        //Propriedade
        public List<long> CoinCollection { get; set; }

        public Dictionary<long, long> CalculateChange(long change)
        {
            Dictionary<long, long> changeTotalResult = new Dictionary<long, long>();

            foreach (long item in this.CoinCollection)
            {
                long coinCount = (change / item);
                
                if (coinCount > 0)
                {
                    changeTotalResult.Add(item, coinCount);

                    change = change - (coinCount * item);
                }
                
            }
            return changeTotalResult;
        }
    }
}