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

        //public IEnumerable<Shipment> Get()
        //{
        //    return new List<Shipment>
        //    {
        //        new Shipment
        //        {
        //            Id=1,
        //            Origin= "Sweden, Norakarmi",
        //            Destination="Oslo, Norway",
        //            ShippedDate = DateTime.UtcNow.AddDays(-1.4)
        //        },
        //        new Shipment
        //        {
        //            Id=2,
        //            Origin= "Masodik, menet",
        //            Destination="Akarhova, Mashova",
        //            ShippedDate = DateTime.UtcNow
        //        }
        //};
        //}

    }
}
