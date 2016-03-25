using AspNet5Angular2Demo.Models;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNet5Angular2Demo.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class DataController: Controller
    {
        protected readonly AppDbContext _context;

        public DataController(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Wowclass> Get()
        {
            return _context.Wowclasses.Where(x=>x.Username == User.Identity.Name).ToList();
        }

       /* public IActionResult Post(string str)
        {
            Console.WriteLine(str);
            return null;
        }*/

        [HttpPost]
        //[Route("login")]
        public string postTest([FromBody]string str)
        {
            Console.WriteLine(str);
            return "postTest Return";
        }

    }
}
