using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using DevExtremeDemo.Models;
using DevExtremeDemo.Models.EFDbContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DevExtremeDemo.Controllers.API
{
    [Route("api/[controller]/[action]")]
    public class DataGridWebApiController : Controller
    {

        private readonly World_EFDbContext _dbContext;
        public DataGridWebApiController(World_EFDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public object Customers(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(_dbContext.Customer, loadOptions);
        }

        [HttpPost]
        public IActionResult InsertCustomer(string values)
        {
            var Model = new Customer();
            JsonConvert.PopulateObject(values, Model);

            if (!TryValidateModel(Model))
                return BadRequest(ModelState.GetFullErrorMessage());

            _dbContext.Customer.Add(Model);
            _dbContext.SaveChanges();

            return Ok(Model);
        }

        [HttpPut]
        public IActionResult UpdateCustomer(int key, string values)
        {
            var Model = _dbContext.Customer.First(o => o.customer_id == key);
            JsonConvert.PopulateObject(values, Model);

            if (!TryValidateModel(Model))
                return BadRequest(ModelState.GetFullErrorMessage());

            _dbContext.SaveChanges();

            return Ok(Model);
        }

        [HttpDelete]
        public void DeleteCustomer(int key)
        {
            var Model = _dbContext.Customer.First(o => o.customer_id == key);
            _dbContext.Customer.Remove(Model);
            _dbContext.SaveChanges();
        }

        // additional actions

        [HttpGet]
        public object CustomerDetails(int key, DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(
                from i in _dbContext.Customer
                where i.customer_id == key
                select i,
                loadOptions
            );
        }

        [HttpGet]
        public object StoreLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _dbContext.Store
                         orderby i.store_id
                         select new
                         {
                             Value = i.store_id,
                             Text = i.store_id
                         };

            return DataSourceLoader.Load(lookup, loadOptions);
        }
        [HttpGet]
        public object ActiveLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in new List<int>() { 1, 0 }
                         orderby i
                         select new
                         {
                             Value = i,
                             Text = i == 1 ? "✔" : "✖"
                         };

            return DataSourceLoader.Load(lookup, loadOptions);
        }

        [HttpGet]
        public object AddressLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _dbContext.Address
                         let text = i.address_id + " (" + i.address + ")"
                         orderby i.address_id
                         select new
                         {
                             Value = i.address_id,
                             Text = text
                         };

            return DataSourceLoader.Load(lookup, loadOptions);
        }

    }

}
