using System;
using System.ComponentModel.DataAnnotations;

namespace DrinkVendingMachine.Model
{
    
    public static class Coin
    {
        public const decimal Five = 5;
        public const decimal Two = 2;
        public const decimal One = 1;
        public const decimal FiftyCent = 0.50m;
        public const decimal TwentyCent = 0.20m;
        public const decimal TenCent = 0.10m;
        public const decimal FiveCent = 0.05m;
    }


    public class CoinStore
    {
        public int ID { get; set; }
        public decimal Value { get; set; }
        public int Quantity { get; set; }
        public int Capacity { get; set; }

        public CoinStore()
        {
        }
    }
}
