using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Persons.Api.Model;

namespace Persons.Api.Controllers
{
    public class PersonsController : Controller
    {
        List<Person> _person = new List<Person>();
        public PersonsController(List<Person> person)
        {
            _person = person;
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetPerson(Guid Id)
        {
            throw new Exception();
        }

        public IEnumerable<Person> GetAllPersons()
        {
            return _person;
        }

        [HttpGet]
        public async Task<IEnumerable<Person>> GetAllPersonsAsync()
        {
             return await Task.FromResult(GetAllPersons());
        }

        
    }
}