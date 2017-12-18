using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Moq;
using Xunit;
using SporthalC3.Controllers;
using SporthalC3;
using SporthalC3.Domain;
using SporthalC3.ViewModels;
using SporthalC3.Models;


namespace SporthalC3.Tests
{
    public class FilterControllerTests
    {
        [Fact]
        public void Can_Filter()
        {
            //Arrange
            Mock<ISportHalRepository> mock = new Mock<ISportHalRepository>();          
            mock.Setup(m => m.SportsHall).Returns( new SportsHall[]
            {
                new SportsHall
                {
                    Length = 100,
                    Width = 50,
                    NumberOfDressingSpace = 40,
                    NumberOfShowers = 10,
                    OpenTime = new DateTime(1990,1,1,8,0,0),
                    CloseTime = new DateTime(1990,1,1,17,0,0),
                    Price = 100,                    
                    SportsBuilding = new SportsBuilding
                    {
                        Name = "TrefPunt",
                        Canteen = true,
                        City = "Rijsbergen",
                        Street = "Rechtweg",
                        PostalCode= "4891 CP",
                        HouseNumber = 5,
                    },
                    SportsHallSports = new SportsHallSports[]
                    {
                        new SportsHallSports{SportsHallId = 1, Sport = new Sport{Name = "Voetbal" } },
                        new SportsHallSports{SportsHallId = 1, Sport = new Sport{Name = "Badminton" } },
                        new SportsHallSports{ SportsHallId = 1, Sport = new Sport{Name = "Basketbal" } }
                    }
                },
                new SportsHall
                {
                    Length = 100,
                    Width = 50,
                    NumberOfDressingSpace = 40,
                    NumberOfShowers = 10,
                    OpenTime = new DateTime(1990,1,1,8,0,0),
                    CloseTime = new DateTime(1990,1,1,17,0,0),
                    Price = 100,
                    SportsBuilding = new SportsBuilding
                    {
                        Name = "TrefPunt",
                        Canteen = true,
                        City = "Rijsbergen",
                        Street = "Rechtweg",
                        PostalCode= "4891 CP",
                        HouseNumber = 5,
                    },
                    SportsHallSports = new SportsHallSports[]
                    {
                        new SportsHallSports{SportsHallId = 2, Sport = new Sport{Name = "Voetbal" } },
                        new SportsHallSports{SportsHallId = 2, Sport = new Sport{Name = "Badminton" } },

                    }
                },new SportsHall
                {
                    Length = 100,
                    Width = 50,
                    NumberOfDressingSpace = 40,
                    NumberOfShowers = 10,
                    OpenTime = new DateTime(1990,1,1,8,0,0),
                    CloseTime = new DateTime(1990,1,1,17,0,0),
                    Price = 100,
                    SportsBuilding = new SportsBuilding
                    {
                        Name = "TrefPunt",
                        Canteen = false,
                        City = "Rijsbergen",
                        Street = "Rechtweg",
                        PostalCode= "4891 CP",
                        HouseNumber = 5,
                    },
                    SportsHallSports = new SportsHallSports[]
                    {
                        new SportsHallSports{SportsHallId = 1, Sport = new Sport{Name = "Voetbal" } },
                        new SportsHallSports{SportsHallId = 1, Sport = new Sport{Name = "Badminton" } },
                        new SportsHallSports{ SportsHallId = 1, Sport = new Sport{Name = "Basketbal" } }
                    }
                },
                new SportsHall
                {
                    Length = 100,
                    Width = 50,
                    NumberOfDressingSpace = 50,
                    NumberOfShowers = 20,
                    OpenTime = new DateTime(1990,1,1,8,0,0),
                    CloseTime = new DateTime(1990,1,1,17,0,0),
                    Price = 100,
                    SportsBuilding = new SportsBuilding
                    {
                        Name = "DeZaal",
                        Canteen = true,
                        City = "Etten-Leur",
                        Street = "Scheefweg",
                        PostalCode= "2000 GP",
                        HouseNumber = 4,
                    },
                    SportsHallSports = new SportsHallSports[]
                    {
                        new SportsHallSports{SportsHallId = 1, Sport = new Sport{Name = "Voetbal" } },
                        new SportsHallSports{SportsHallId = 1, Sport = new Sport{Name = "Basketbal" } },
                    }
                },
                new SportsHall
                {
                    Length = 50,
                    Width = 20,
                    NumberOfDressingSpace = 40,
                    NumberOfShowers = 10,
                    OpenTime = new DateTime(1990,1,1,8,0,0),
                    CloseTime = new DateTime(1990,1,1,17,0,0),
                    Price = 100,  
                    SportsBuilding = new SportsBuilding
                    {
                        Name = "DeZaal",
                        Canteen = true,
                        City = "Etten-Leur",
                        Street = "Scheefweg",
                        PostalCode= "2000 GP",
                        HouseNumber = 4,
                    },
                    SportsHallSports = new SportsHallSports[]
                    {

                        new SportsHallSports{SportsHallId = 1, Sport = new Sport{Name = "Badminton" } },
                        new SportsHallSports{ SportsHallId = 1, Sport = new Sport{Name = "Basketbal" } }
                    }

                },
                           
                        
                

                }

             

            );

            FilterController controller = new FilterController(mock.Object);

            //Act
            FilterViewModel model = controller.FilterView("Basketbal", null , 100, 50, 20, 10, "on", false, null, null, 100)
                       .ViewData.Model as FilterViewModel;
            
            //Assert
            IEnumerable<SportsHall> result = model.SportsHalls;
            SportsHall[] sporthallArray = result.ToArray();
            Assert.True(sporthallArray.Length == 2);
            //Hall 1
            Assert.Equal(20, sporthallArray[0].NumberOfShowers);
            Assert.Equal(50, sporthallArray[0].NumberOfDressingSpace);
            Assert.True(sporthallArray[0].SportsHallSports.Select(x => x.Sport).ToList().Count() == 2);
            Assert.Equal(true, sporthallArray[0].SportsBuilding.Canteen);
            //Hall 2
            Assert.Equal(10, sporthallArray[1].NumberOfShowers);
            Assert.Equal(40, sporthallArray[1].NumberOfDressingSpace);
            Assert.True(sporthallArray[1].SportsHallSports.Select(x => x.Sport).ToList().Count() == 3);
            Assert.Equal(true, sporthallArray[1].SportsBuilding.Canteen);

        }

    }
}
