﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrinkVendingMachine.Data;
using DrinkVendingMachine.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DrinkVendingMachine.API
{
    [Route("api/[controller]")]
    public class DrinkController : Controller
    {

        private readonly DataBaseContext _context;
        public DrinkController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Drink> Get()
        {
            return _context.Drinks.ToList();
        }

        // POST api/values
        [HttpPost]
        public bool Post([FromBody]Order order)
        {
            if( order.selectedDrinkCan != null && order.selectedDrinkCan.ID > 0){
                CatalogItem item = _context.CatalogItems.Where((arg) => arg.DrinkID == order.selectedDrinkCan.ID).First();

                //order.coinInserted

                if(item.Quantity > 0 ){
                    item.Quantity--;
                    _context.CatalogItems.Update(item);
                    _context.SaveChanges();
                    return true;
                }
            }

           
            return true;
        }

        //// GET: api/values
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
