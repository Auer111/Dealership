using Dealership.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Dealership.Data
{
    public class DbInitializer
    {
        public static async Task<int> Initialize(IServiceProvider serviceProvider)
        {
            DealershipContext context = serviceProvider.GetService<DealershipContext>();

            context.Database.EnsureCreated();

            if (!context.Users.Any())
            {

                string[] roles = new string[] { "Administrator" };

                foreach (string role in roles)
                {
                    var roleStore = new RoleStore<IdentityRole>(context);

                    if (!context.Roles.Any(r => r.Name == role))
                    {
                        await roleStore.CreateAsync(new IdentityRole(role));
                    }
                }

                var user = new IdentityUser
                {
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    Email = "jjauer95@gmail.com",
                    NormalizedEmail = "JJAUER95@EXAMPLE.COM",
                    PhoneNumber = "9899759606",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString("D")
                };


                if (!context.Users.Any(u => u.UserName == user.UserName))
                {
                    var password = new PasswordHasher<IdentityUser>();
                    var hashed = password.HashPassword(user, "1q2w3e");
                    user.PasswordHash = hashed;

                    var userStore = new UserStore<IdentityUser>(context);
                    var result = userStore.CreateAsync(user);

                }

                UserManager<IdentityUser> _userManager = serviceProvider.GetService<UserManager<IdentityUser>>();
                IdentityUser _user = _userManager.FindByEmailAsync(user.Email).Result;
                _ = _userManager.AddToRolesAsync(_user, roles);

            }
            if (!context.Vehicles.Any())
            {
                var vehicles = new Vehicle[]
                {
                    new Vehicle
                    {
                        Condition = Vehicle.VehicleCondition.New,
                        Color="blue",
                        Make="honda",
                        Model="civic",
                        Trim="touring",
                        VIN="1JCCN18N0CT047552",
                        Image = "/cars/1JCCN18N0CT047552/default.jpg",
                        Price=27250,
                        Year =2020,
                        Mileage=250
                    },
                    new Vehicle
                    {
                        Condition = Vehicle.VehicleCondition.Used,
                        Color="black",
                        Make="honda",
                        Model="accord",
                        Trim="accord sport",
                        VIN="2C4GM68475R667819",
                        Image = "/cars/2C4GM68475R667819/default.jpg",
                        Price=20911,
                        Year =2018,
                        Mileage=27558
                    },
                    new Vehicle
                    {
                        Condition = Vehicle.VehicleCondition.New,
                        Color="green",
                        Make="honda",
                        Model="odyssey",
                        Trim="lx",
                        VIN="4S3BK4252X7305536",
                        Image = "/cars/4S3BK4252X7305536/default.jpg",
                        Price=36852,
                        Year =2021,
                        Mileage=53
                    },
                    new Vehicle
                    {
                        Condition = Vehicle.VehicleCondition.Used,
                        Color="red",
                        Make="honda",
                        Model="s2000",
                        Trim="cr",
                        VIN="1FV3GFBC0YHA74039",
                        Image = "/cars/1FV3GFBC0YHA74039/default.jpg",
                        Price=20991,
                        Year =2002,
                        Mileage=81886
                    },
                    new Vehicle
                    {
                        Condition = Vehicle.VehicleCondition.New,
                        Color="white",
                        Make="honda",
                        Model="crv",
                        Trim="lx",
                        VIN="JH4DA1842JS003823",
                        Image = "/cars/JH4DA1842JS003823/default.jpg",
                        Price=25350,
                        Year =2020,
                        Mileage=13
                    },
                    new Vehicle
                    {
                        Condition = Vehicle.VehicleCondition.Used,
                        Color="green",
                        Make="honda",
                        Model="pilot",
                        Trim="ex-l",
                        VIN="1GCFG25F6V1059733",
                        Image = "/cars/1GCFG25F6V1059733/default.jpg",
                        Price=27495,
                        Year =2018,
                        Mileage=47375
                    },
                    new Vehicle
                    {
                        Condition = Vehicle.VehicleCondition.Used,
                        Color="purple",
                        Make="honda",
                        Model="hrv",
                        Trim="ex",
                        VIN="JH4DC4460SS000830",
                        Image = "/cars/JH4DC4460SS000830/default.jpg",
                        Price=24070,
                        Year =2016,
                        Mileage=33598
                    },
                    new Vehicle
                    {
                        Condition = Vehicle.VehicleCondition.Used,
                        Color="blue",
                        Make="honda",
                        Model="fit",
                        Trim="ex",
                        VIN="1J4GZ78Y5PC574443",
                        Image = "/cars/1J4GZ78Y5PC574443/default.jpg",
                        Price=17278,
                        Year =2018,
                        Mileage=3652
                    },
                    new Vehicle
                    {
                        Condition = Vehicle.VehicleCondition.Used,
                        Color="black",
                        Make="honda",
                        Model="ridgeline",
                        Trim="rtl",
                        VIN="JT2SV12E8G0417278",
                        Image = "/cars/JT2SV12E8G0417278/default.jpg",
                        Price=30373,
                        Year =2017,
                        Mileage=61087
                    },
                    new Vehicle
                    {
                        Condition = Vehicle.VehicleCondition.Used,
                        Color="green",
                        Make="honda",
                        Model="passport",
                        Trim="ex-l",
                        VIN="2A8HR44H88R105590",
                        Image = "/cars/2A8HR44H88R105590/default.jpg",
                        Price=29990,
                        Year =2019,
                        Mileage=10511
                    },
                    new Vehicle
                    {
                        Condition = Vehicle.VehicleCondition.New,
                        Color="red",
                        Make="nissan",
                        Model="rogue",
                        Trim="sv",
                        VIN="1N4AB41D7VC757660",
                        Image = "/cars/1N4AB41D7VC757660/default.jpg",
                        Price=26745,
                        Year =2020,
                        Mileage=12
                    },
                    new Vehicle
                    {
                        Condition = Vehicle.VehicleCondition.New,
                        Color="white",
                        Make="nissan",
                        Model="altima",
                        Trim="sr",
                        VIN="JHLRE38357C030678",
                        Image = "/cars/JHLRE38357C030678/default.jpg",
                        Price=20500,
                        Year =2020,
                        Mileage=123
                    },
                    new Vehicle
                    {
                        Condition = Vehicle.VehicleCondition.New,
                        Color="yellow",
                        Make="nissan",
                        Model="juke",
                        Trim="sv",
                        VIN="WP0AA2991YS620631",
                        Image = "/cars/WP0AA2991YS620631/default.jpg",
                        Price=19852,
                        Year =2017,
                        Mileage=74326
                    },
                    new Vehicle
                    {
                        Condition = Vehicle.VehicleCondition.New,
                        Color="purple",
                        Make="nissan",
                        Model="sentra",
                        Trim="sv",
                        VIN="1GTEK19RXVE536194",
                        Image = "/cars/1GTEK19RXVE536194/default.jpg",
                        Price=24250,
                        Year =2020,
                        Mileage=80
                    },
                    new Vehicle
                    {
                        Condition = Vehicle.VehicleCondition.New,
                        Color="blue",
                        Make="nissan",
                        Model="maxima",
                        Trim="sl",
                        VIN="JH4KA8250MC004002",
                        Image = "/cars/JH4KA8250MC004002/default.jpg",
                        Price=31990,
                        Year =2020,
                        Mileage=7
                    },
                    new Vehicle
                    {
                        Condition = Vehicle.VehicleCondition.Used,
                        Color="black",
                        Make="nissan",
                        Model="370z",
                        Trim="base",
                        VIN="4T4BF1FK4CR236137",
                        Image = "/cars/4T4BF1FK4CR236137/default.jpg",
                        Price=23800,
                        Year =2017,
                        Mileage=9456
                    },
                    new Vehicle
                    {
                        Condition = Vehicle.VehicleCondition.Used,
                        Color="grey",
                        Make="nissan",
                        Model="kicks",
                        Trim="sv",
                        VIN="JH4DA1842JS003822",
                        Image = "/cars/JH4DA1842JS003822/default.jpg",
                        Price=16607,
                        Year =2018,
                        Mileage=16304
                    },
                    new Vehicle
                    {
                        Condition = Vehicle.VehicleCondition.Used,
                        Color="red",
                        Make="nissan",
                        Model="pathfinder",
                        Trim="sl",
                        VIN="JH4KA7560RC003647",
                        Image = "/cars/JH4KA7560RC003647/default.jpg",
                        Price=15998,
                        Year =2014,
                        Mileage=77000
                    },
                    new Vehicle
                    {
                        Condition = Vehicle.VehicleCondition.Used,
                        Color="blue",
                        Make="nissan",
                        Model="titan",
                        Trim="platinum reserve",
                        VIN="1HGCM66537A023172",
                        Image = "/cars/1HGCM66537A023172/default.jpg",
                        Price=35500,
                        Year =2018,
                        Mileage=39344
                    },
                    new Vehicle
                    {
                        Condition = Vehicle.VehicleCondition.Used,
                        Color="black",
                        Make="nissan",
                        Model="frontier",
                        Trim="sl",
                        VIN="JH4DA9350LS003644",
                        Image = "/cars/JH4DA9350LS003644/default.jpg",
                        Price=28488,
                        Year =2019,
                        Mileage=11750
                    },
                    new Vehicle
                    {
                        Condition = Vehicle.VehicleCondition.Used,
                        Color="white",
                        Make="ford",
                        Model="focus",
                        Trim="se",
                        VIN="1FTCR15XXRTB03260",
                        Image = "/cars/1FTCR15XXRTB03260/default.jpg",
                        Price=10994,
                        Year =2018,
                        Mileage=48205
                    },
                    new Vehicle
                    {
                        Condition = Vehicle.VehicleCondition.New,
                        Color="yellow",
                        Make="ford",
                        Model="f150",
                        Trim="xl",
                        VIN="JKBVNKD167A013982",
                        Image = "/cars/JKBVNKD167A013982/default.jpg",
                        Price=40998,
                        Year =2020,
                        Mileage=7000
                    },
                    new Vehicle
                    {
                        Condition = Vehicle.VehicleCondition.New,
                        Color="purple",
                        Make="ford",
                        Model="mustang",
                        Trim="gt",
                        VIN="JH4DB1640LS003578",
                        Image = "/cars/JH4DB1640LS003578/default.jpg",
                        Price=38420,
                        Year =2020,
                        Mileage=1258
                    },
                    new Vehicle
                    {
                        Condition = Vehicle.VehicleCondition.New,
                        Color="blue",
                        Make="ford",
                        Model="fusion",
                        Trim="se",
                        VIN="1B4HS28N9YF105991",
                        Image = "/cars/1B4HS28N9YF105991/default.jpg",
                        Price=25695,
                        Year =2020,
                        Mileage=562
                    },
                    new Vehicle
                    {
                        Condition = Vehicle.VehicleCondition.New,
                        Color="black",
                        Make="ford",
                        Model="escape",
                        Trim="sel",
                        VIN="1GKDT13S852309288",
                        Image = "/cars/1GKDT13S852309288/default.jpg",
                        Price=20989,
                        Year =2020,
                        Mileage=258
                    },
                    new Vehicle
                    {
                        Condition = Vehicle.VehicleCondition.New,
                        Color="grey",
                        Make="ford",
                        Model="expedition",
                        Trim="platinum",
                        VIN="WDBRF40J43F433102",
                        Image = "/cars/WDBRF40J43F433102/default.jpg",
                        Price=77085,
                        Year =2020,
                        Mileage=742
                    },
                    new Vehicle
                    {
                        Condition = Vehicle.VehicleCondition.Used,
                        Color="red",
                        Make="ford",
                        Model="explorer",
                        Trim="xlt",
                        VIN="1HD1GPM15CC339172",
                        Image = "/cars/1HD1GPM15CC339172/default.jpg",
                        Price=7900,
                        Year =2012,
                        Mileage=111400
                    },
                    new Vehicle
                    {
                        Condition = Vehicle.VehicleCondition.Used,
                        Color="white",
                        Make="ford",
                        Model="flex",
                        Trim="sel",
                        VIN="1B7HF16Y8TS510206",
                        Image = "/cars/1B7HF16Y8TS510206/default.jpg",
                        Price=17588,
                        Year =2016,
                        Mileage=63387
                    },
                    new Vehicle
                    {
                        Condition = Vehicle.VehicleCondition.Used,
                        Color="red",
                        Make="ford",
                        Model="taurus",
                        Trim="sel",
                        VIN="2GCEK13T961100610",
                        Image = "/cars/2GCEK13T961100610/default.jpg",
                        Price=12034,
                        Year =2014,
                        Mileage=56399
                    },
                    new Vehicle
                    {
                        Condition = Vehicle.VehicleCondition.Used,
                        Color="green",
                        Make="ford",
                        Model="f250",
                        Trim="f250",
                        VIN="YS3AL76L1R7002116",
                        Image = "/cars/YS3AL76L1R7002116/default.jpg",
                        Price=500,
                        Year =1978,
                        Mileage=75000
                    },
                    new Vehicle
                    {
                        Condition = Vehicle.VehicleCondition.New,
                        Color="green",
                        Make="toyota",
                        Model="tundra",
                        Trim="sr 5.7l v8",
                        VIN="ZDM1UB5W86B016210",
                        Image = "/cars/ZDM1UB5W86B016210/default.jpg",
                        Price=33575,
                        Year =2020,
                        Mileage=364
                    },
                    new Vehicle
                    {
                        Condition = Vehicle.VehicleCondition.New,
                        Color="red",
                        Make="toyota",
                        Model="camry",
                        Trim="le",
                        VIN="JT4RN61D8F5061251",
                        Image = "/cars/JT4RN61D8F5061251/default.jpg",
                        Price=23247,
                        Year =2020,
                        Mileage=24
                    },
                    new Vehicle
                    {
                        Condition = Vehicle.VehicleCondition.New,
                        Color="white",
                        Make="toyota",
                        Model="rav4",
                        Trim="xle premium",
                        VIN="1GKFK16K0RJ736886",
                        Image = "/cars/1GKFK16K0RJ736886/default.jpg",
                        Price=31801,
                        Year =2020,
                        Mileage=5929
                    },
                    new Vehicle
                    {
                        Condition = Vehicle.VehicleCondition.New,
                        Color="white",
                        Make="toyota",
                        Model="sequoia",
                        Trim="sr5",
                        VIN="3G1JC1245WS848211",
                        Image = "/cars/3G1JC1245WS848211/default.jpg",
                        Price=53205,
                        Year =2020,
                        Mileage=2358
                    },
                    new Vehicle
                    {
                        Condition = Vehicle.VehicleCondition.New,
                        Color="grey",
                        Make="toyota",
                        Model="highlander",
                        Trim="l",
                        VIN="JH4DB1560PS003184",
                        Image = "/cars/JH4DB1560PS003184/default.jpg",
                        Price=34810,
                        Year =2021,
                        Mileage=963
                    },
                    new Vehicle
                    {
                        Condition = Vehicle.VehicleCondition.Used,
                        Color="blue",
                        Make="toyota",
                        Model="4runner",
                        Trim="sr5",
                        VIN="1P3BP36D3HF192068",
                        Image = "/cars/1P3BP36D3HF192068/default.jpg",
                        Price=32089,
                        Year =2016,
                        Mileage=34888
                    },
                    new Vehicle
                    {
                        Condition = Vehicle.VehicleCondition.Used,
                        Color="black",
                        Make="toyota",
                        Model="sienna",
                        Trim="xle",
                        VIN="JH4DB7650RS000250",
                        Image = "/cars/JH4DB7650RS000250/default.jpg",
                        Price=4588,
                        Year =2004,
                        Mileage=168528
                    },
                    new Vehicle
                    {
                        Condition = Vehicle.VehicleCondition.Used,
                        Color="green",
                        Make="toyota",
                        Model="prius",
                        Trim="two",
                        VIN="WP0CB29906S769518",
                        Image = "/cars/WP0CB29906S769518/default.jpg",
                        Price=9599,
                        Year =2010,
                        Mileage=102000
                    },
                    new Vehicle
                    {
                        Condition = Vehicle.VehicleCondition.Used,
                        Color="red",
                        Make="toyota",
                        Model="supra",
                        Trim="sport",
                        VIN="JH4DA9340MS002938",
                        Image = "/cars/JH4DA9340MS002938/default.jpg",
                        Price=89800,
                        Year =1993,
                        Mileage=43660
                    },
                    new Vehicle
                    {
                        Condition = Vehicle.VehicleCondition.Used,
                        Color="white",
                        Make="toyota",
                        Model="corolla",
                        Trim="le",
                        VIN="JH4CC2642RC001364",
                        Image = "/cars/JH4CC2642RC001364/default.jpg",
                        Price=8100,
                        Year =2013,
                        Mileage=97250
                    },
                    new Vehicle
                    {
                        Condition = Vehicle.VehicleCondition.New,
                        Color="yellow",
                        Make="audi",
                        Model="r8",
                        Trim="Spyder",
                        VIN="JH4DA3440KS029436",
                        Image = "/cars/JH4DA3440KS029436/default.jpg",
                        Price=166900,
                        Year =2018,
                        Mileage=3851
                    },
                    new Vehicle
                    {
                        Condition = Vehicle.VehicleCondition.New,
                        Color="purple",
                        Make="audi",
                        Model="a8",
                        Trim="55 tfsi",
                        VIN="1GTGK29U5XE550656",
                        Image = "/cars/1GTGK29U5XE550656/default.jpg",
                        Price=86195,
                        Year =2020,
                        Mileage=0
                    },
                    new Vehicle
                    {
                        Condition = Vehicle.VehicleCondition.New,
                        Color="blue",
                        Make="audi",
                        Model="a7",
                        Trim="premium plus",
                        VIN="3VWLL7AJ9BM053541",
                        Image = "/cars/3VWLL7AJ9BM053541/default.jpg",
                        Price=74595,
                        Year =2020,
                        Mileage=64
                    },
                    new Vehicle
                    {
                        Condition = Vehicle.VehicleCondition.New,
                        Color="black",
                        Make="audi",
                        Model="a6",
                        Trim="premium plus",
                        VIN="WDBRN40J54A591238",
                        Image = "/cars/WDBRN40J54A591238/default.jpg",
                        Price=52990,
                        Year =2020,
                        Mileage=7794
                    },
                    new Vehicle
                    {
                        Condition = Vehicle.VehicleCondition.New,
                        Color="green",
                        Make="audi",
                        Model="a5",
                        Trim="prestige",
                        VIN="1J4FA29P4YP728937",
                        Image = "/cars/1J4FA29P4YP728937/default.jpg",
                        Price=53595,
                        Year =2020,
                        Mileage=12
                    },
                    new Vehicle
                    {
                        Condition = Vehicle.VehicleCondition.Used,
                        Color="red",
                        Make="audi",
                        Model="q3",
                        Trim="prestige",
                        VIN="1GCDC14K2LE198114",
                        Image = "/cars/1GCDC14K2LE198114/default.jpg",
                        Price=13985,
                        Year =2015,
                        Mileage=121245
                    },
                    new Vehicle
                    {
                        Condition = Vehicle.VehicleCondition.Used,
                        Color="white",
                        Make="audi",
                        Model="q5",
                        Trim="premium",
                        VIN="1GTEK19RXVE536195",
                        Image = "/cars/1GTEK19RXVE536195/default.jpg",
                        Price=11995,
                        Year =2009,
                        Mileage=65620
                    },
                    new Vehicle
                    {
                        Condition = Vehicle.VehicleCondition.Used,
                        Color="grey",
                        Make="audi",
                        Model="q7",
                        Trim="premium plus",
                        VIN="1A8HW58268F133559",
                        Image = "/cars/1A8HW58268F133559/default.jpg",
                        Price=33980,
                        Year =2017,
                        Mileage=37916
                    },
                    new Vehicle
                    {
                        Condition = Vehicle.VehicleCondition.Used,
                        Color="purple",
                        Make="audi",
                        Model="q8",
                        Trim="prestige",
                        VIN="JH4NA1261RT000013",
                        Image = "/cars/JH4NA1261RT000013/default.jpg",
                        Price=59950,
                        Year =2019,
                        Mileage=20395
                    },
                    new Vehicle
                    {
                        Condition = Vehicle.VehicleCondition.Used,
                        Color="blue",
                        Make="audi",
                        Model="a4",
                        Trim="premium ultra",
                        VIN="JF2AC53B3GE202643",
                        Image = "/cars/JF2AC53B3GE202643/default.jpg",
                        Price=21588,
                        Year =2017,
                        Mileage=22522
                    }
                };
                foreach (Vehicle v in vehicles)
                {
                    context.Vehicles.Add(v);
                    context.VehiclesFull.Add(new VehicleFull { VIN = v.VIN, Details = new List<Auer.Models.KVP>() }.ToDB());

                    if (!context.Makes.Any(m => m.Name == v.Make))
                    {
                        context.Makes.Add(new Make { Name = v.Make });
                    }


                    if (!context.Colors.Any(c => c.Name == v.Color))
                    {
                        context.Colors.Add(new BodyColor { Name = v.Color });
                    }
                    context.SaveChanges();
                }

                foreach (Vehicle v in vehicles)
                {
                    long _id = context.Makes.FirstOrDefault(m => m.Name == v.Make).ID;
                    if (!context.Models.Any(mo => mo.MakeID == _id && mo.Name == v.Model))
                    {
                        context.Models.Add(new Model { Name = v.Model, MakeID = _id });
                    }
                    context.SaveChanges();
                }
            }

            return context.SaveChanges();
        }





    }


}
