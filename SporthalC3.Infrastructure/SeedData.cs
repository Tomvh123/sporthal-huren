using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using SporthalC3.Models;


namespace SporthalC3
{
    public static class SeedData
    {


        public static void EnsurePopulated(IApplicationBuilder app)
        {


            ApplicationDbContext context = app.ApplicationServices
                .GetRequiredService<ApplicationDbContext>();

            //context.RemoveRange(context.Reserve);
            //context.RemoveRange(context.SportsHall);
            //context.RemoveRange(context.SportsBuilding);
            //context.SportsBuildingAdministrators.RemoveRange(context.SportsBuildingAdministrators);
            //context.SaveChanges();

            if (!context.Sport.Any())
            {
                context.AddRange(
                    new Sport
                    {
                        Name = "Voetbal"
                    },
                    new Sport
                    {
                        Name = "Volleybal"
                    },
                    new Sport
                    {
                        Name = "Basketbal"
                    },
                    new Sport
                    {
                        Name = "Badminton"
                    },
                    new Sport
                    {
                        Name = "Korfbal"
                    },
                    new Sport
                    {
                        Name = "Tafeltennis"
                    }
                    );
                context.SaveChanges();
            }

            if (!context.SportsBuildingAdministrators.Any())
            {
                context.SportsBuildingAdministrators.AddRange(

                    new SportsBuildingAdministrator
                    {
                        FirstName = "Klaas",
                        LastName = "Verhoeven",
                        SportBuildingList = new List<SportsBuilding> {
                            new SportsBuilding{
                                Name = "Ballonentent",
                            City = "Rijsbergen",
                            Street = "Rechtweg",
                            PostalCode = "4891 CP",
                            HouseNumber = 1,
                            Canteen = true,
                            SportsHallList = new List<SportsHall>{
                                new SportsHall
                                {
                                    Length = 15,
                                    Width = 20,
                                    NumberOfDressingSpace = 20,
                                    NumberOfShowers =10,
                                    Price = 101,
                                    OpenTime = new DateTime(1990,01,1,8,0,0),
                                    CloseTime = new DateTime(1990,01,1,17,0,0),
                                    SportsHallSports = new List<SportsHallSports>
                                    {
                                      new SportsHallSports
                                      {
                                          Sport = context.Sport.Where(x => x.Name == "Voetbal").FirstOrDefault()
                                      },
                                      new SportsHallSports
                                      {
                                          Sport = context.Sport.Where(x => x.Name == "Tafeltennis").FirstOrDefault()
                                      },
                                      new SportsHallSports
                                      {
                                          Sport = context.Sport.Where(x => x.Name == "Korfbal").FirstOrDefault()
                                      }
                                    },
                                    Reserve = new List<Reserve>
                                    {
                                        new Reserve
                                        {
                                            FirstName = "Tom",
                                            LastName = "van Haaster",
                                            Email = "Email@Email.com",
                                            PhoneNumber = 0646010205,
                                            Datum = new DateTime(2017,10,19),
                                            StartTime = new DateTime(1990,1,1,9,0,0),
                                            EndTime = new DateTime(1999,1,1,10,0,0),
                                            Context = "reserved",
                                            
                                        },
                                        new Reserve
                                        {
                                            FirstName = "Tom",
                                            LastName = "van Haaster",
                                            Email = "Email@Email.com",
                                            PhoneNumber = 0646010205,
                                            Datum = new DateTime(2017,10,6),
                                            StartTime = new DateTime(1990,1,1,10,0,0),
                                            EndTime = new DateTime(1999,1,1,11,0,0),
                                            Context = "reserved"
                                        },
                                        new Reserve
                                        {
                                            FirstName = "Tom",
                                            LastName = "van Haaster",
                                            Email = "Email@Email.com",
                                            PhoneNumber = 0646010205,
                                            Datum = new DateTime(2017,10,6),
                                            StartTime = new DateTime(1990,1,1,12,0,0),
                                            EndTime = new DateTime(1999,1,1,13,0,0),
                                            Context = "reserved"
                                        }
                                    }
                                },
                                new SportsHall
                                {
                                    Length = 40,
                                    Width = 35,
                                    NumberOfDressingSpace = 20,
                                    NumberOfShowers =10,
                                    Price = 19,
                                    OpenTime = new DateTime(1990,01,1,8,0,0),
                                    CloseTime = new DateTime(1990,01,1,17,0,0),
                                    SportsHallSports = new List<SportsHallSports>
                                    {
                                      new SportsHallSports
                                      {
                                          Sport = context.Sport.Where(x => x.Name == "Volleybal").FirstOrDefault()
                                      },
                                      new SportsHallSports
                                      {
                                          Sport = context.Sport.Where(x => x.Name == "Badminton").FirstOrDefault()
                                      },
                                      new SportsHallSports
                                      {
                                          Sport = context.Sport.Where(x => x.Name == "Korfbal").FirstOrDefault()
                                      }
                                    }
                                }
                            }
                            }
                        }
                    },

                    new SportsBuildingAdministrator
                    {
                        FirstName = "Henk",
                        LastName = "De Wit",
                        SportBuildingList = new List<SportsBuilding> {
                            new SportsBuilding{
                                Name = "Boterhal",
                            City = "Etten-Leur",
                            Street = "Schuinweg",
                            PostalCode = "4891 CP",
                            HouseNumber = 1,
                            Canteen = true,
                            SportsHallList = new List<SportsHall>{
                                new SportsHall
                                {
                                    Length = 45,
                                    Width = 50,
                                    NumberOfDressingSpace = 20,
                                    NumberOfShowers =12,
                                    Price = 104,
                                    OpenTime = new DateTime(1990,01,1,8,0,0),
                                    CloseTime = new DateTime(1990,01,1,20,0,0),
                                    SportsHallSports = new List<SportsHallSports>
                                    {
                                      new SportsHallSports
                                      {
                                          Sport = context.Sport.Where(x => x.Name == "Basketbal").FirstOrDefault()
                                      },
                                      new SportsHallSports
                                      {
                                          Sport = context.Sport.Where(x => x.Name == "Tafeltennis").FirstOrDefault()
                                      },
                                      new SportsHallSports
                                      {
                                          Sport = context.Sport.Where(x => x.Name == "Volleybal").FirstOrDefault()
                                      }
                                    },

                                },
                                new SportsHall
                                {
                                    Length = 35,
                                    Width = 63,
                                    NumberOfDressingSpace = 30,
                                    NumberOfShowers =5,
                                    Price = 103,
                                    OpenTime = new DateTime(1990,01,1,10,0,0),
                                    CloseTime = new DateTime(1990,01,1,23,0,0),
                                    SportsHallSports = new List<SportsHallSports>
                                    {
                                      new SportsHallSports
                                      {
                                          Sport = context.Sport.Where(x => x.Name == "Voetbal").FirstOrDefault()
                                      },
                                      new SportsHallSports
                                      {
                                          Sport = context.Sport.Where(x => x.Name == "Badminton").FirstOrDefault()
                                      },
                                      new SportsHallSports
                                      {
                                          Sport = context.Sport.Where(x => x.Name == "Volleybal").FirstOrDefault()
                                      }
                                    },
                                }
                            }
                            }
                        }
                    },
                     new SportsBuildingAdministrator
                     {
                         FirstName = "Frank",
                         LastName = "De Boer",
                         SportBuildingList = new List<SportsBuilding> {
                            new SportsBuilding{
                                Name = "De beemd",
                            City = "Veghel",
                            Street = "Stadhuisplein",
                            PostalCode = "5464PA",
                            HouseNumber = 8,
                            Canteen = true,
                            SportsHallList = new List<SportsHall>{
                                new SportsHall
                                {
                                    Length = 20,
                                    Width = 54,
                                    NumberOfDressingSpace = 20,
                                    NumberOfShowers =10,
                                    Price = 10,
                                    OpenTime = new DateTime(1990,01,1,1,0,0),
                                    CloseTime = new DateTime(1990,01,1,12,0,0),
                                    SportsHallSports = new List<SportsHallSports>
                                    {
                                      new SportsHallSports
                                      {
                                          Sport = context.Sport.Where(x => x.Name == "Voetbal").FirstOrDefault()
                                      }
                                    },

                                },
                                new SportsHall
                                {
                                    Length = 35,
                                    Width = 82,
                                    NumberOfDressingSpace = 30,
                                    NumberOfShowers =20,
                                    Price = 1008,
                                    OpenTime = new DateTime(1990,01,1,12,0,0),
                                    CloseTime = new DateTime(1990,01,1,20,0,0),
                                    SportsHallSports = new List<SportsHallSports>
                                    {
                                      new SportsHallSports
                                      {
                                          Sport = context.Sport.Where(x => x.Name == "Badminton").FirstOrDefault()
                                      },
                                      new SportsHallSports
                                      {
                                          Sport = context.Sport.Where(x => x.Name == "Korfbal").FirstOrDefault()
                                      }
                                    },
                                }
                            }
                            }
                        }
                     },
                      new SportsBuildingAdministrator
                      {
                          FirstName = "Pieter-Jan",
                          LastName = "Kind",
                          SportBuildingList = new List<SportsBuilding> {
                            new SportsBuilding{
                                Name = "De Speelboederij",
                            City = "sint-michielsgestel",
                            Street = "Spijt",
                            PostalCode = "4811 AC",
                            HouseNumber = 1,
                            Canteen = false,
                            SportsHallList = new List<SportsHall>{
                                new SportsHall
                                {
                                    Length = 45,
                                    Width = 35,
                                    NumberOfDressingSpace = 10,
                                    NumberOfShowers =5,
                                    Price = 155,
                                    OpenTime = new DateTime(1990,01,1,5,0,0),
                                    CloseTime = new DateTime(1990,01,1,15,0,0),
                                    SportsHallSports = new List<SportsHallSports>
                                    {
                                      new SportsHallSports
                                      {
                                          Sport = context.Sport.Where(x => x.Name == "Voetbal").FirstOrDefault()
                                      },
                                      new SportsHallSports
                                      {
                                          Sport = context.Sport.Where(x => x.Name == "Tafeltennis").FirstOrDefault()
                                      },
                                      new SportsHallSports
                                      {
                                          Sport = context.Sport.Where(x => x.Name == "Korfbal").FirstOrDefault()
                                      },
                                      new SportsHallSports
                                      {
                                          Sport = context.Sport.Where(x => x.Name == "Volleybal").FirstOrDefault()
                                      },
                                      new SportsHallSports
                                      {
                                          Sport = context.Sport.Where(x => x.Name == "Basketbal").FirstOrDefault()
                                      },
                                      new SportsHallSports
                                      {
                                          Sport = context.Sport.Where(x => x.Name == "Badminton").FirstOrDefault()
                                      }
                                    },

                                }
                            }
                            }
                        }
                      },
                       new SportsBuildingAdministrator
                       {
                           FirstName = "Thijs",
                           LastName = "De mol",
                           SportBuildingList = new List<SportsBuilding> {
                            new SportsBuilding{
                                Name = "Sporthal Andersom",
                            City = "Bladel",
                            Street = "Moerven",
                            PostalCode = "5464TP",
                            HouseNumber = 1,
                            Canteen = false,
                            SportsHallList = new List<SportsHall>{
                                new SportsHall
                                {
                                    Length = 25,
                                    Width = 35,
                                    NumberOfDressingSpace = 20,
                                    NumberOfShowers =12,
                                    Price = 44,
                                    OpenTime = new DateTime(1990,01,1,8,0,0),
                                    CloseTime = new DateTime(1990,01,1,17,0,0),
                                    SportsHallSports = new List<SportsHallSports>
                                    {
                                      new SportsHallSports
                                      {
                                          Sport = context.Sport.Where(x => x.Name == "Volleybal").FirstOrDefault()
                                      },
                                      new SportsHallSports
                                      {
                                          Sport = context.Sport.Where(x => x.Name == "Tafeltennis").FirstOrDefault()
                                      },
                                      new SportsHallSports
                                      {
                                          Sport = context.Sport.Where(x => x.Name == "Badminton").FirstOrDefault()
                                      }
                                    },
                                }
                            }
                            }
                        }
                       }
                    );
                context.SaveChanges();
            }


        }

    }
}
