using System;
using DrinkVendingMachine.Business.Impl;
using Xunit;

namespace DrinkVendingMachine.Test
{
    /// <summary>
    /// Unit test for the recursive algorithm that gives back the change 
    /// </summary>
    public class UnitTest1
    {
        private readonly MoneyHandler _moneyHandler;

        public UnitTest1()
        {
            _moneyHandler = new MoneyHandler();
        }

        [Fact]
        public void BasicCase()
        {
            var result = _moneyHandler.GiveBackMoney(1.2m, 2, new System.Collections.Generic.List<decimal>(),
                                        new System.Collections.Generic.List<decimal>()
                                            {5, 5, 2, 2, 1, 1, 0.5m, 0.5m, 0.5m, 0.2m, 0.2m, 0.2m, 0.2m, 0.2m, 0.10m, 0.10m, 0.10m });
            Assert.Equal(new System.Collections.Generic.List<decimal>() { 0.50m, 0.20m, 0.10m }, result);

        }

        [Fact]
        public void EmptyInput(){

            var result = _moneyHandler.GiveBackMoney(1.20m, 0, new System.Collections.Generic.List<decimal>(),
                                        new System.Collections.Generic.List<decimal>()
                                            {5, 5, 2, 2, 1, 1, 0.5m, 0.5m, 0.5m, 0.2m, 0.2m, 0.2m, 0.2m, 0.2m, 0.10m, 0.10m, 0.10m });

            Assert.Null(result);

        }


        [Fact]
        public void EmptyStorage()
        {

            var result = _moneyHandler.GiveBackMoney(1.20m, 2, new System.Collections.Generic.List<decimal>(),
                                        new System.Collections.Generic.List<decimal>()
                                           );
            Assert.Null(result);
        }

        [Fact]
        public void Thief(){
            var result = _moneyHandler.GiveBackMoney(1.2m, 5, new System.Collections.Generic.List<decimal>(),
                            new System.Collections.Generic.List<decimal>()
                                {5, 5, 2, 2, 1, 1, 0.5m, 0.5m, 0.5m});

            Assert.Equal(new System.Collections.Generic.List<decimal>() { 2, 1, 0.50m}, result);
        }

        [Fact]
        public void MissingMoney(){
            var result = _moneyHandler.GiveBackMoney(1.2m, 0.80m, new System.Collections.Generic.List<decimal>(),
                            new System.Collections.Generic.List<decimal>()
                                {5, 5, 2, 2, 1, 1, 0.5m, 0.5m, 0.5m});

            Assert.Null(result);
        }

        [Fact]
        public void AreCoinsStorableBasic(){

            var storage = new System.Collections.Generic.List<Model.CoinStore>();
            storage.Add(new Model.CoinStore(){
                ID = 1,
                Quantity = 18,
                Capacity = 20,
                Value = 2});

            var result = _moneyHandler.AreCoinsStorable(new System.Collections.Generic.List<decimal>(){2, 2}, storage);

            Assert.True(result);
        }

        [Fact]
        public void CoinStorageFull()
        {
            var storage = new System.Collections.Generic.List<Model.CoinStore>();
            storage.Add(new Model.CoinStore()
            {
                ID = 1,
                Quantity = 20,
                Capacity = 20,
                Value = 2
            });

            var result = _moneyHandler.AreCoinsStorable(new System.Collections.Generic.List<decimal>() { 2}, storage);

            Assert.False(result);
        }

        [Fact]
        public void CoinStorageFullTwo()
        {
            var storage = new System.Collections.Generic.List<Model.CoinStore>();
            storage.Add(new Model.CoinStore()
            {
                ID = 1,
                Quantity = 19,
                Capacity = 20,
                Value = 2
            });

            var result = _moneyHandler.AreCoinsStorable(new System.Collections.Generic.List<decimal>() { 2, 2 }, storage);

            Assert.False(result);
        }

        [Fact]
        public void CoinStorageFullThree()
        {

            var storage = new System.Collections.Generic.List<Model.CoinStore>();
            storage.Add(new Model.CoinStore()
            {
                ID = 1,
                Quantity = 18,
                Capacity = 20,
                Value = 2
            });

            var result = _moneyHandler.AreCoinsStorable(new System.Collections.Generic.List<decimal>() { 2, 2, 2 }, storage);

            Assert.False(result);
        }

        [Fact]
        public void CoinStorageFullTen()
        {

            var storage = new System.Collections.Generic.List<Model.CoinStore>();
            storage.Add(new Model.CoinStore()
            {
                ID = 1,
                Quantity = 10,
                Capacity = 20,
                Value = 2
            });

            var result = _moneyHandler.AreCoinsStorable(new System.Collections.Generic.List<decimal>() { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 }, storage);

            Assert.True(result);
        }

        [Fact]
        public void CoinStorageFullEleven()
        {

            var storage = new System.Collections.Generic.List<Model.CoinStore>();
            storage.Add(new Model.CoinStore()
            {
                ID = 1,
                Quantity = 10,
                Capacity = 20,
                Value = 2
            });

            var result = _moneyHandler.AreCoinsStorable(new System.Collections.Generic.List<decimal>() { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 }, storage);

            Assert.False(result);
        }

        [Fact]
        public void CoinStorageNotFullForDifferentCoin()
        {
            var storage = new System.Collections.Generic.List<Model.CoinStore>();
            storage.Add(new Model.CoinStore()
            {
                ID = 1,
                Quantity = 20,
                Capacity = 20,
                Value = 2
            });

            var result = _moneyHandler.AreCoinsStorable(new System.Collections.Generic.List<decimal>() { 1, 1 }, storage);

            Assert.True(result);
        }

    }
}
