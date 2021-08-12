using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using DevExtremeDemo.Models;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using DevExtremeDemo.Models.EFDbContext;

namespace DevExtremeDemo.Controllers {

    [Route("api/[controller]")]
    public class SampleDataController : Controller {

        private readonly World_EFDbContext _dbContext;
        public SampleDataController(World_EFDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions) {
            return DataSourceLoader.Load(_dbContext.Customer.ToList(), loadOptions);
        }

    }
}