using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNet5Angular2Demo.Models
{
    public class Seeder
    {
        private readonly AppDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;


        // ez a class egy rejtély.. ki hívja a konstruktort?
        public Seeder(AppDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task EnsureSeedData()
        {

            if (!_context.Users.Any())
            {
                for (int i = 0; i < 2; i++)
                {
                    var user = new IdentityUser()
                    {
                        UserName = $"test{i}",
                        Email = $"test{i}@lol.com"
                    };
                    await _userManager.CreateAsync(user, "Istenit5!");
                }
            }


            if (!_context.Wowclasses.Any())
            {
                var wowclass = new List<Wowclass>
                                {
                                new Wowclass
                                {
                                    Name = "Mage",
                                    Description = "Én egy varázsló vagyok",
                                    Username = "test0"
                                },
                                new Wowclass
                                {
                                    Name="Rogue",
                                    Description="Én egy rabló&bérgyilkos vagyok",
                                    Username = "test1"
                                },
                
                                new Wowclass
                                {
                                    Name="Priest",
                                    Description="Én egy pap vagyok",
                                    Username = "test0"
                                },
                                new Wowclass
                                {
                                    Name="Hunter",
                                    Description="Én egy vadász vagyok kis cuki állatokkal",
                                    Username = "test1"
                                },
                                new Wowclass
                                {
                                    Name="Warrior",
                                    Description="Én egy harcos vagyok",
                                    Username = "test0"
                                },
                                new Wowclass
                                {
                                    Name="Paladin",
                                    Description="Én egy szent lovag",
                                    Username = "test1"
                                },
                                new Wowclass
                                {
                                    Name="Death Knight",
                                    Description="Én egy sötét harcos vagyok",
                                    Username = "test0"
                                },
                                new Wowclass
                                {
                                    Name="Druid",
                                    Description="Én egy drudid vagyok",
                                    Username = "test1"
                                }};
                _context.Wowclasses.AddRange(wowclass);
                await _context.SaveChangesAsync();
            }
        }

    }
}
