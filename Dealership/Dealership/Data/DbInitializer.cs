using Dealership.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Auer.Security;

namespace Dealership.Data
{
    public class DbInitializer
    {
        public static async Task<int> Initialize(IServiceProvider serviceProvider)
        {
            DealershipContext context = serviceProvider.GetService<DealershipContext>();

            context.Database.EnsureCreated();

            
            if (!context.Vehicles.Any())
            {

                var Dealer = new Dealer { Name = "Test Dealership" };
                context.Dealers.Add(Dealer);
                context.SaveChanges();


                long Dealer_id = context.Dealers.First().Id;

                var vehicles = new Vehicle[]
                {
                    new Vehicle
                    {
                        DealerId = Dealer_id,
                        Condition = Vehicle.VehicleCondition.New,
                        Color="blue",
                        Make="honda",
                        Model="civic",
                        trim="touring",
                        Vin="1JCCN18N0CT047552",
                        Image = "/cars/1JCCN18N0CT047552/default.jpg",
                        Price=27250,
                        Year =2020,
                        Mileage=250
                    },
                    new Vehicle
                    {
                        DealerId = Dealer_id,
                        Condition = Vehicle.VehicleCondition.Used,
                        Color="black",
                        Make="honda",
                        Model="accord",
                        trim="accord sport",
                        Vin="2C4GM68475R667819",
                        Image = "/cars/2C4GM68475R667819/default.jpg",
                        Price=20911,
                        Year =2018,
                        Mileage=27558
                    },
                    new Vehicle
                    {
                        DealerId = Dealer_id,
                        Condition = Vehicle.VehicleCondition.New,
                        Color="green",
                        Make="honda",
                        Model="odyssey",
                        trim="lx",
                        Vin="4S3BK4252X7305536",
                        Image = "/cars/4S3BK4252X7305536/default.jpg",
                        Price=36852,
                        Year =2021,
                        Mileage=53
                    },
                    new Vehicle
                    {
                        DealerId = Dealer_id,
                        Condition = Vehicle.VehicleCondition.Used,
                        Color="red",
                        Make="honda",
                        Model="s2000",
                        trim="cr",
                        Vin="1FV3GFBC0YHA74039",
                        Image = "/cars/1FV3GFBC0YHA74039/default.jpg",
                        Price=20991,
                        Year =2002,
                        Mileage=81886
                    },
                    new Vehicle
                    {
                        DealerId = Dealer_id,
                        Condition = Vehicle.VehicleCondition.New,
                        Color="white",
                        Make="honda",
                        Model="crv",
                        trim="lx",
                        Vin="JH4DA1842JS003823",
                        Image = "/cars/JH4DA1842JS003823/default.jpg",
                        Price=25350,
                        Year =2020,
                        Mileage=13
                    },
                    new Vehicle
                    {
                        DealerId = Dealer_id,
                        Condition = Vehicle.VehicleCondition.Used,
                        Color="green",
                        Make="honda",
                        Model="pilot",
                        trim="ex-l",
                        Vin="1GCFG25F6V1059733",
                        Image = "/cars/1GCFG25F6V1059733/default.jpg",
                        Price=27495,
                        Year =2018,
                        Mileage=47375
                    },
                    new Vehicle
                    {
                        DealerId = Dealer_id,
                        Condition = Vehicle.VehicleCondition.Used,
                        Color="purple",
                        Make="honda",
                        Model="hrv",
                        trim="ex",
                        Vin="JH4DC4460SS000830",
                        Image = "/cars/JH4DC4460SS000830/default.jpg",
                        Price=24070,
                        Year =2016,
                        Mileage=33598
                    },
                    new Vehicle
                    {
                        DealerId = Dealer_id,
                        Condition = Vehicle.VehicleCondition.Used,
                        Color="blue",
                        Make="honda",
                        Model="fit",
                        trim="ex",
                        Vin="1J4GZ78Y5PC574443",
                        Image = "/cars/1J4GZ78Y5PC574443/default.jpg",
                        Price=17278,
                        Year =2018,
                        Mileage=3652
                    },
                    new Vehicle
                    {
                        DealerId = Dealer_id,
                        Condition = Vehicle.VehicleCondition.Used,
                        Color="black",
                        Make="honda",
                        Model="ridgeline",
                        trim="rtl",
                        Vin="JT2SV12E8G0417278",
                        Image = "/cars/JT2SV12E8G0417278/default.jpg",
                        Price=30373,
                        Year =2017,
                        Mileage=61087
                    },
                    new Vehicle
                    {
                        DealerId = Dealer_id,
                        Condition = Vehicle.VehicleCondition.Used,
                        Color="green",
                        Make="honda",
                        Model="passport",
                        trim="ex-l",
                        Vin="2A8HR44H88R105590",
                        Image = "/cars/2A8HR44H88R105590/default.jpg",
                        Price=29990,
                        Year =2019,
                        Mileage=10511
                    },
                    new Vehicle
                    {
                        DealerId = Dealer_id,
                        Condition = Vehicle.VehicleCondition.New,
                        Color="red",
                        Make="nissan",
                        Model="rogue",
                        trim="sv",
                        Vin="1N4AB41D7VC757660",
                        Image = "/cars/1N4AB41D7VC757660/default.jpg",
                        Price=26745,
                        Year =2020,
                        Mileage=12
                    },
                    new Vehicle
                    {
                        DealerId = Dealer_id,
                        Condition = Vehicle.VehicleCondition.New,
                        Color="white",
                        Make="nissan",
                        Model="altima",
                        trim="sr",
                        Vin="JHLRE38357C030678",
                        Image = "/cars/JHLRE38357C030678/default.jpg",
                        Price=20500,
                        Year =2020,
                        Mileage=123
                    },
                    new Vehicle
                    {
                        DealerId = Dealer_id,
                        Condition = Vehicle.VehicleCondition.New,
                        Color="yellow",
                        Make="nissan",
                        Model="juke",
                        trim="sv",
                        Vin="WP0AA2991YS620631",
                        Image = "/cars/WP0AA2991YS620631/default.jpg",
                        Price=19852,
                        Year =2017,
                        Mileage=74326
                    },
                    new Vehicle
                    {
                        DealerId = Dealer_id,
                        Condition = Vehicle.VehicleCondition.New,
                        Color="purple",
                        Make="nissan",
                        Model="sentra",
                        trim="sv",
                        Vin="1GTEK19RXVE536194",
                        Image = "/cars/1GTEK19RXVE536194/default.jpg",
                        Price=24250,
                        Year =2020,
                        Mileage=80
                    },
                    new Vehicle
                    {
                        DealerId = Dealer_id,
                        Condition = Vehicle.VehicleCondition.New,
                        Color="blue",
                        Make="nissan",
                        Model="maxima",
                        trim="sl",
                        Vin="JH4KA8250MC004002",
                        Image = "/cars/JH4KA8250MC004002/default.jpg",
                        Price=31990,
                        Year =2020,
                        Mileage=7
                    },
                    new Vehicle
                    {
                        DealerId = Dealer_id,
                        Condition = Vehicle.VehicleCondition.Used,
                        Color="black",
                        Make="nissan",
                        Model="370z",
                        trim="base",
                        Vin="4T4BF1FK4CR236137",
                        Image = "/cars/4T4BF1FK4CR236137/default.jpg",
                        Price=23800,
                        Year =2017,
                        Mileage=9456
                    },
                    new Vehicle
                    {
                        DealerId = Dealer_id,
                        Condition = Vehicle.VehicleCondition.Used,
                        Color="grey",
                        Make="nissan",
                        Model="kicks",
                        trim="sv",
                        Vin="JH4DA1842JS003822",
                        Image = "/cars/JH4DA1842JS003822/default.jpg",
                        Price=16607,
                        Year =2018,
                        Mileage=16304
                    },
                    new Vehicle
                    {
                        DealerId = Dealer_id,
                        Condition = Vehicle.VehicleCondition.Used,
                        Color="red",
                        Make="nissan",
                        Model="pathfinder",
                        trim="sl",
                        Vin="JH4KA7560RC003647",
                        Image = "/cars/JH4KA7560RC003647/default.jpg",
                        Price=15998,
                        Year =2014,
                        Mileage=77000
                    },
                    new Vehicle
                    {
                        DealerId = Dealer_id,
                        Condition = Vehicle.VehicleCondition.Used,
                        Color="blue",
                        Make="nissan",
                        Model="titan",
                        trim="platinum reserve",
                        Vin="1HGCM66537A023172",
                        Image = "/cars/1HGCM66537A023172/default.jpg",
                        Price=35500,
                        Year =2018,
                        Mileage=39344
                    },
                    new Vehicle
                    {
                        DealerId = Dealer_id,
                        Condition = Vehicle.VehicleCondition.Used,
                        Color="black",
                        Make="nissan",
                        Model="frontier",
                        trim="sl",
                        Vin="JH4DA9350LS003644",
                        Image = "/cars/JH4DA9350LS003644/default.jpg",
                        Price=28488,
                        Year =2019,
                        Mileage=11750
                    },
                    new Vehicle
                    {
                        DealerId = Dealer_id,
                        Condition = Vehicle.VehicleCondition.Used,
                        Color="white",
                        Make="ford",
                        Model="focus",
                        trim="se",
                        Vin="1FTCR15XXRTB03260",
                        Image = "/cars/1FTCR15XXRTB03260/default.jpg",
                        Price=10994,
                        Year =2018,
                        Mileage=48205
                    },
                    new Vehicle
                    {
                        DealerId = Dealer_id,
                        Condition = Vehicle.VehicleCondition.New,
                        Color="yellow",
                        Make="ford",
                        Model="f150",
                        trim="xl",
                        Vin="JKBVNKD167A013982",
                        Image = "/cars/JKBVNKD167A013982/default.jpg",
                        Price=40998,
                        Year =2020,
                        Mileage=7000
                    },
                    new Vehicle
                    {
                        DealerId = Dealer_id,
                        Condition = Vehicle.VehicleCondition.New,
                        Color="purple",
                        Make="ford",
                        Model="mustang",
                        trim="gt",
                        Vin="JH4DB1640LS003578",
                        Image = "/cars/JH4DB1640LS003578/default.jpg",
                        Price=38420,
                        Year =2020,
                        Mileage=1258
                    },
                    new Vehicle
                    {
                        DealerId = Dealer_id,
                        Condition = Vehicle.VehicleCondition.New,
                        Color="blue",
                        Make="ford",
                        Model="fusion",
                        trim="se",
                        Vin="1B4HS28N9YF105991",
                        Image = "/cars/1B4HS28N9YF105991/default.jpg",
                        Price=25695,
                        Year =2020,
                        Mileage=562
                    },
                    new Vehicle
                    {
                        DealerId = Dealer_id,
                        Condition = Vehicle.VehicleCondition.New,
                        Color="black",
                        Make="ford",
                        Model="escape",
                        trim="sel",
                        Vin="1GKDT13S852309288",
                        Image = "/cars/1GKDT13S852309288/default.jpg",
                        Price=20989,
                        Year =2020,
                        Mileage=258
                    },
                    new Vehicle
                    {
                        DealerId = Dealer_id,
                        Condition = Vehicle.VehicleCondition.New,
                        Color="grey",
                        Make="ford",
                        Model="expedition",
                        trim="platinum",
                        Vin="WDBRF40J43F433102",
                        Image = "/cars/WDBRF40J43F433102/default.jpg",
                        Price=77085,
                        Year =2020,
                        Mileage=742
                    },
                    new Vehicle
                    {
                        DealerId = Dealer_id,
                        Condition = Vehicle.VehicleCondition.Used,
                        Color="red",
                        Make="ford",
                        Model="explorer",
                        trim="xlt",
                        Vin="1HD1GPM15CC339172",
                        Image = "/cars/1HD1GPM15CC339172/default.jpg",
                        Price=7900,
                        Year =2012,
                        Mileage=111400
                    },
                    new Vehicle
                    {
                        DealerId = Dealer_id,
                        Condition = Vehicle.VehicleCondition.Used,
                        Color="white",
                        Make="ford",
                        Model="flex",
                        trim="sel",
                        Vin="1B7HF16Y8TS510206",
                        Image = "/cars/1B7HF16Y8TS510206/default.jpg",
                        Price=17588,
                        Year =2016,
                        Mileage=63387
                    },
                    new Vehicle
                    {
                        DealerId = Dealer_id,
                        Condition = Vehicle.VehicleCondition.Used,
                        Color="red",
                        Make="ford",
                        Model="taurus",
                        trim="sel",
                        Vin="2GCEK13T961100610",
                        Image = "/cars/2GCEK13T961100610/default.jpg",
                        Price=12034,
                        Year =2014,
                        Mileage=56399
                    },
                    new Vehicle
                    {
                        DealerId = Dealer_id,
                        Condition = Vehicle.VehicleCondition.Used,
                        Color="green",
                        Make="ford",
                        Model="f250",
                        trim="f250",
                        Vin="YS3AL76L1R7002116",
                        Image = "/cars/YS3AL76L1R7002116/default.jpg",
                        Price=500,
                        Year =1978,
                        Mileage=75000
                    },
                    new Vehicle
                    {
                        DealerId = Dealer_id,
                        Condition = Vehicle.VehicleCondition.New,
                        Color="green",
                        Make="toyota",
                        Model="tundra",
                        trim="sr 5.7l v8",
                        Vin="ZDM1UB5W86B016210",
                        Image = "/cars/ZDM1UB5W86B016210/default.jpg",
                        Price=33575,
                        Year =2020,
                        Mileage=364
                    },
                    new Vehicle
                    {
                        DealerId = Dealer_id,
                        Condition = Vehicle.VehicleCondition.New,
                        Color="red",
                        Make="toyota",
                        Model="camry",
                        trim="le",
                        Vin="JT4RN61D8F5061251",
                        Image = "/cars/JT4RN61D8F5061251/default.jpg",
                        Price=23247,
                        Year =2020,
                        Mileage=24
                    },
                    new Vehicle
                    {
                        DealerId = Dealer_id,
                        Condition = Vehicle.VehicleCondition.New,
                        Color="white",
                        Make="toyota",
                        Model="rav4",
                        trim="xle premium",
                        Vin="1GKFK16K0RJ736886",
                        Image = "/cars/1GKFK16K0RJ736886/default.jpg",
                        Price=31801,
                        Year =2020,
                        Mileage=5929
                    },
                    new Vehicle
                    {
                        DealerId = Dealer_id,
                        Condition = Vehicle.VehicleCondition.New,
                        Color="white",
                        Make="toyota",
                        Model="sequoia",
                        trim="sr5",
                        Vin="3G1JC1245WS848211",
                        Image = "/cars/3G1JC1245WS848211/default.jpg",
                        Price=53205,
                        Year =2020,
                        Mileage=2358
                    },
                    new Vehicle
                    {
                        DealerId = Dealer_id,
                        Condition = Vehicle.VehicleCondition.New,
                        Color="grey",
                        Make="toyota",
                        Model="highlander",
                        trim="l",
                        Vin="JH4DB1560PS003184",
                        Image = "/cars/JH4DB1560PS003184/default.jpg",
                        Price=34810,
                        Year =2021,
                        Mileage=963
                    },
                    new Vehicle
                    {
                        DealerId = Dealer_id,
                        Condition = Vehicle.VehicleCondition.Used,
                        Color="blue",
                        Make="toyota",
                        Model="4runner",
                        trim="sr5",
                        Vin="1P3BP36D3HF192068",
                        Image = "/cars/1P3BP36D3HF192068/default.jpg",
                        Price=32089,
                        Year =2016,
                        Mileage=34888
                    },
                    new Vehicle
                    {
                        DealerId = Dealer_id,
                        Condition = Vehicle.VehicleCondition.Used,
                        Color="black",
                        Make="toyota",
                        Model="sienna",
                        trim="xle",
                        Vin="JH4DB7650RS000250",
                        Image = "/cars/JH4DB7650RS000250/default.jpg",
                        Price=4588,
                        Year =2004,
                        Mileage=168528
                    },
                    new Vehicle
                    {
                        DealerId = Dealer_id,
                        Condition = Vehicle.VehicleCondition.Used,
                        Color="green",
                        Make="toyota",
                        Model="prius",
                        trim="two",
                        Vin="WP0CB29906S769518",
                        Image = "/cars/WP0CB29906S769518/default.jpg",
                        Price=9599,
                        Year =2010,
                        Mileage=102000
                    },
                    new Vehicle
                    {
                        DealerId = Dealer_id,
                        Condition = Vehicle.VehicleCondition.Used,
                        Color="red",
                        Make="toyota",
                        Model="supra",
                        trim="sport",
                        Vin="JH4DA9340MS002938",
                        Image = "/cars/JH4DA9340MS002938/default.jpg",
                        Price=89800,
                        Year =1993,
                        Mileage=43660
                    },
                    new Vehicle
                    {
                        DealerId = Dealer_id,
                        Condition = Vehicle.VehicleCondition.Used,
                        Color="white",
                        Make="toyota",
                        Model="corolla",
                        trim="le",
                        Vin="JH4CC2642RC001364",
                        Image = "/cars/JH4CC2642RC001364/default.jpg",
                        Price=8100,
                        Year =2013,
                        Mileage=97250
                    },
                    new Vehicle
                    {
                        DealerId = Dealer_id,
                        Condition = Vehicle.VehicleCondition.New,
                        Color="yellow",
                        Make="audi",
                        Model="r8",
                        trim="Spyder",
                        Vin="JH4DA3440KS029436",
                        Image = "/cars/JH4DA3440KS029436/default.jpg",
                        Price=166900,
                        Year =2018,
                        Mileage=3851
                    },
                    new Vehicle
                    {
                        DealerId = Dealer_id,
                        Condition = Vehicle.VehicleCondition.New,
                        Color="purple",
                        Make="audi",
                        Model="a8",
                        trim="55 tfsi",
                        Vin="1GTGK29U5XE550656",
                        Image = "/cars/1GTGK29U5XE550656/default.jpg",
                        Price=86195,
                        Year =2020,
                        Mileage=0
                    },
                    new Vehicle
                    {
                        DealerId = Dealer_id,
                        Condition = Vehicle.VehicleCondition.New,
                        Color="blue",
                        Make="audi",
                        Model="a7",
                        trim="premium plus",
                        Vin="3VWLL7AJ9BM053541",
                        Image = "/cars/3VWLL7AJ9BM053541/default.jpg",
                        Price=74595,
                        Year =2020,
                        Mileage=64
                    },
                    new Vehicle
                    {
                        DealerId = Dealer_id,
                        Condition = Vehicle.VehicleCondition.New,
                        Color="black",
                        Make="audi",
                        Model="a6",
                        trim="premium plus",
                        Vin="WDBRN40J54A591238",
                        Image = "/cars/WDBRN40J54A591238/default.jpg",
                        Price=52990,
                        Year =2020,
                        Mileage=7794
                    },
                    new Vehicle
                    {
                        DealerId = Dealer_id,
                        Condition = Vehicle.VehicleCondition.New,
                        Color="green",
                        Make="audi",
                        Model="a5",
                        trim="prestige",
                        Vin="1J4FA29P4YP728937",
                        Image = "/cars/1J4FA29P4YP728937/default.jpg",
                        Price=53595,
                        Year =2020,
                        Mileage=12
                    },
                    new Vehicle
                    {
                        DealerId = Dealer_id,
                        Condition = Vehicle.VehicleCondition.Used,
                        Color="red",
                        Make="audi",
                        Model="q3",
                        trim="prestige",
                        Vin="1GCDC14K2LE198114",
                        Image = "/cars/1GCDC14K2LE198114/default.jpg",
                        Price=13985,
                        Year =2015,
                        Mileage=121245
                    },
                    new Vehicle
                    {
                        DealerId = Dealer_id,
                        Condition = Vehicle.VehicleCondition.Used,
                        Color="white",
                        Make="audi",
                        Model="q7",
                        trim="premium",
                        Vin="1GTEK19RXVE536195",
                        Image = "/cars/1GTEK19RXVE536195/default.jpg",
                        Price=11995,
                        Year =2009,
                        Mileage=65620
                    },
                    new Vehicle
                    {
                        DealerId = Dealer_id,
                        Condition = Vehicle.VehicleCondition.Used,
                        Color="grey",
                        Make="audi",
                        Model="q7",
                        trim="premium plus",
                        Vin="1A8HW58268F133559",
                        Image = "/cars/1A8HW58268F133559/default.jpg",
                        Price=33980,
                        Year =2017,
                        Mileage=37916
                    },
                    new Vehicle
                    {
                        DealerId = Dealer_id,
                        Condition = Vehicle.VehicleCondition.Used,
                        Color="purple",
                        Make="audi",
                        Model="q8",
                        trim="prestige",
                        Vin="JH4NA1261RT000013",
                        Image = "/cars/JH4NA1261RT000013/default.jpg",
                        Price=59950,
                        Year =2019,
                        Mileage=20395
                    },
                    new Vehicle
                    {
                        DealerId = Dealer_id,
                        Condition = Vehicle.VehicleCondition.Used,
                        Color="blue",
                        Make="audi",
                        Model="a4",
                        trim="premium ultra",
                        Vin="JF2AC53B3GE202643",
                        Image = "/cars/JF2AC53B3GE202643/default.jpg",
                        Price=21588,
                        Year =2017,
                        Mileage=22522
                    }
                };

                try
                {
                    vehicles.Select(v => v.Make.ToUpper())
                        .Distinct()
                        .ToList()
                        .ForEach(m => context.Makes.Add(new Make
                        {
                            Name = m.ToUpper()
                        }));
                    context.SaveChanges();



                    vehicles.GroupBy(v => new { Model = v.Model.ToUpper(), Make = v.Make.ToUpper() })
                        .Distinct()
                        .ToList()
                        .ForEach(ma => context.Models.Add(new Model
                        {
                            MakeId = context.Makes.FirstOrDefault(makes => makes.Name == ma.Key.Make).Id,
                            Name = ma.Key.Model
                        }));
                    context.SaveChanges();



                    
                    vehicles.GroupBy(v => new { Model = v.Model.ToUpper(), Make = v.Make.ToUpper(), trim = v.trim.ToUpper() })
                        .Distinct()
                        .ToList()
                        .ForEach(tr => context.Trims.Add(new Trim
                        {
                            ModelId = GetTrimForignKey(context,tr.Key.Model,tr.Key.Make),
                            Name = tr.Key.trim
                        }));
                    context.SaveChanges();


                    vehicles.Select(v => v.Color.ToUpper())
                            .Distinct()
                            .ToList()
                            .ForEach(m => context.Colors.Add(new BodyColor
                            {
                                Name = m.ToUpper()
                            }));
                    context.SaveChanges();


                    foreach(Vehicle v in vehicles)
                    {
                        v.ColorId = context.Colors.FirstOrDefault(c => c.Name == v.Color).Id;
                        v.TrimId = GetTrimId(context, v.Make.ToUpper(), v.Model.ToUpper(), v.trim.ToUpper());

                        context.Vehicles.Add(v);
                    }


                    context.Issues.Add(new Notification
                    {
                        Name = "Link a new Data Source",
                        Description = "Click here to download a client to link this website and your DMS.",
                        Type = Notification.NotificationType.Installer,
                        Url = "/Admin/Download"
                    });
                    context.Issues.Add(new Notification
                    {
                        Name = "Dealership Information - John Doe Auto",
                        Description = "Click here to change Dealership name, splash photo and other settings.",
                        Type = Notification.NotificationType.DealershipInfo,
                        Url = "/Admin/Download"
                    });

                    context.SaveChanges();
                }
                catch (Exception ex) { Console.WriteLine(ex); }

                
            }

            if (!context.Users.Any())
            {

                string[] roles = new string[] { "Admin" };

                foreach (string role in roles)
                {
                    var roleStore = new RoleStore<IdentityRole>(context);

                    if (!context.Roles.Any(r => r.Name == role))
                    {
                        roleStore.CreateAsync(new IdentityRole(role)).Wait();
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
                    userStore.CreateAsync(user).Wait();

                }
                context.Accounts.Add(new Account
                {
                    CryptoPass = Crypto.Encrypt("1q2w3e"),
                    DealerId = context.Dealers.First().Id,
                    IdentityId = context.Users.First().Id
                });
                context.SaveChanges();

                UserManager<IdentityUser> _userManager = serviceProvider.GetService<UserManager<IdentityUser>>();
                IdentityUser _user = _userManager.FindByEmailAsync(user.Email).Result;
                _ = _userManager.AddToRolesAsync(_user, roles);

            }

            return context.SaveChanges();
        }



        private static long GetTrimForignKey(DealershipContext context, string model, string make)
        {

            foreach(Make ma in context.Makes)
            {
                if (ma.Name == make) { 
                    foreach(Model mo in context.Models)
                    {
                        if (mo.Name == model && mo.MakeId == ma.Id) {
                            return mo.Id;
                        }
                    }
                }

            }
            throw new Exception("Could not find Make or Model for trim");
        }

        
        private static long GetTrimId(DealershipContext context, string make, string model, string trim)
        {

            foreach (Make ma in context.Makes)
            {
                if (ma.Name == make)
                {
                    foreach (Model mo in context.Models)
                    {
                        if (mo.Name == model && mo.MakeId == ma.Id)
                        {
                            foreach(Trim t in context.Trims)
                            {
                                if(t.Name == trim && t.ModelId == mo.Id)
                                {
                                    return t.Id;
                                }
                            }
                        }
                    }
                }

            }
            throw new Exception("Could not find Make, Model, or Trim for Vehicle");
        }

    }


}
