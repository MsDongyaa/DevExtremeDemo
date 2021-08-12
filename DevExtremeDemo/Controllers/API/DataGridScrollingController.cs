using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using DevExtremeDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DevExtremeDemo.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataGridScrollingController : ControllerBase
    {
        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(GenerateData(100000), loadOptions);
        }


        IEnumerable<User> GenerateData(int count)
        {
            var surnames = new[] { "Smith", "Johnson", "Brown", "Taylor", "Anderson", "Harris", "Clark", "Allen", "Scott", "Carter" };
            var names = new[] { "James", "John", "Robert", "Christopher", "George", "Mary", "Nancy", "Sandra", "Michelle", "Betty" };
            var gender = new[] { "Male", "Female" };
            var startBirthDate = DateTime.Parse("1/1/1975");
            var endBirthDate = DateTime.Parse("1/1/1992");

            double s = 123456789;
            double NextRandom()
            {
                s = (1103515245 * s + 12345) % 2147483647;
                return s % (names.Length - 1);
            }

            for (var i = 0; i < count; i++)
            {
                var birthDate = new DateTime(startBirthDate.Ticks + Convert.ToInt64(Math.Floor(NextRandom() * (endBirthDate.Ticks - startBirthDate.Ticks) / 10)));

                birthDate.AddHours(12);

                var nameIndex = Convert.ToInt32(NextRandom());
                yield return new User
                {
                    Id = i + 1,
                    FirstName = names[nameIndex],
                    LastName = surnames[Convert.ToInt32(NextRandom())],
                    Gender = gender[Convert.ToInt32(Math.Floor(Convert.ToDouble(nameIndex / 5)))],
                    BirthDate = birthDate
                };
            }
        }

        // GET api/<DataGridScrollingController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DataGridScrollingController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DataGridScrollingController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DataGridScrollingController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
