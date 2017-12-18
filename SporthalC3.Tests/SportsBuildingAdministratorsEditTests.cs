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
using Microsoft.AspNetCore.Mvc;
using SporthalC3.Models;

namespace SporthalC3.Tests
{

    
    public class SportsBuildingAdministratorTests
    {

        private T GetViewModel<T>(IActionResult result) where T : class
        {
            return (result as ViewResult)?.ViewData.Model as T;
        }
        public Mock<ISportHalRepository> getMock()
        {
            Mock<ISportHalRepository> mock = new Mock<ISportHalRepository>();

            mock.Setup(x => x.SportsBuilding).Returns(
                new SportsBuilding[] {
                    new SportsBuilding
                    {
                       SportsBuildingID = 1,
                        Canteen = true,
                            City = "Rijsbergen",
                            HouseNumber = 1,
                            Name = "DeZaal",
                            PostalCode = "4891CP",
                            Street = "Rechtweg",
                           
                    }
                }
                );

            mock.Setup(a => a.SportsHall).Returns(new SportsHall[]
                    {
                        new SportsHall
                        {
                            SportsHallID = 1,
                            Length = 100,
                            Width = 50,
                            NumberOfDressingSpace = 10,
                            NumberOfShowers = 5
                        }

                    }
                );

            mock.Setup(x => x.Sport).Returns(new Sport[]
                    {
                        new Sport{ SportID = 1, Name = "Voetbal"}

                    }
                );
            mock.Setup(m => m.SportsBuildingAdministrator).Returns(new SportsBuildingAdministrator[] 
            {
                new SportsBuildingAdministrator
                {
                    SportsBuildingAdministratorID = 1,
                    FirstName = "Tom",
                    LastName = "Haaster",
                    
                    
                   
                },
                new SportsBuildingAdministrator
                {
                    SportsBuildingAdministratorID = 2,
                    FirstName = "Henk",
                    LastName = "Peeters",


                }

            }

                );

            return mock;
        }


        //SportsBuildingAdministrator//
        [Fact]
        public void Can_Edit_SportsBuildingAdministrator()
        {
            //Arrange
            Mock<ISportHalRepository> mock = new Mock<ISportHalRepository>();
            mock = getMock();

            AdminController controller = new AdminController(mock.Object);

            

            //Act
            SportsBuildingAdministrator s1 = GetViewModel<SportsBuildingAdministrator>(controller.EditSportBuildingAdministratorView(1));
            SportsBuildingAdministrator s2 = GetViewModel<SportsBuildingAdministrator>(controller.EditSportBuildingAdministratorView(2));
            //Assert
            Assert.Equal("Tom", s1.FirstName);
            Assert.Equal("Haaster", s1.LastName);

            Assert.Equal("Henk", s2.FirstName);
            Assert.Equal("Peeters", s2.LastName);
        }

        [Fact]
        public void Cannot_edit_Noneexistent_Can_Edit_SportsBuildingAdministrator()
        {
            //Arrange
            Mock<ISportHalRepository> mock = new Mock<ISportHalRepository>();
            mock = getMock();

            AdminController controller = new AdminController(mock.Object);

            //Act
            SportsBuildingAdministrator result = GetViewModel<SportsBuildingAdministrator>(controller.EditSportBuildingAdministratorView(10));

            //Assert
            Assert.Null(result);
        }



        [Fact]
        public void Can_Save_Edit_SportsBuildingAdministrator()
        {
            //Arrange
            Mock<ISportHalRepository> mock = new Mock<ISportHalRepository>();
            
                                                                     
            AdminController controller = new AdminController(mock.Object);

            SportsBuildingAdministrator sportsBuildingAdministrator = new SportsBuildingAdministrator {SportsBuildingAdministratorID = 1 , FirstName = "Tom", LastName = "van Haaster" };

            //Act
            IActionResult result = controller.EditSportsBuildingAdministrator(sportsBuildingAdministrator);
            

            //Assert
            mock.Verify(m => m.SaveSportsBuildingAdministrator(sportsBuildingAdministrator));
            Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("SportsBuildingAdministrator", (result as RedirectToActionResult).ActionName);
                       
        }

        [Fact]
        public void Cannot_Save_Invalid_editSportsBuildingAdministrator()
        {

            //Arrange
            Mock<ISportHalRepository> mock = new Mock<ISportHalRepository>();
            

            AdminController controller = new AdminController(mock.Object);
            SportsBuildingAdministrator sportsBuildingAdministrator = new SportsBuildingAdministrator { SportsBuildingAdministratorID = 1, FirstName = "Tom", LastName = "Haaster" };
            controller.ModelState.AddModelError("error", "error");

            //Act
            IActionResult result = controller.EditSportsBuildingAdministrator(sportsBuildingAdministrator);


            //Assert
            mock.Verify(m => m.SaveSportsBuildingAdministrator(It.IsAny<SportsBuildingAdministrator>()), Times.Never());
            Assert.IsType<ViewResult>(result);

        }

        //SportsBuilding//
        [Fact]
        public void Can_Edit_SportsBuilding()
        {
            //Arrange
            Mock<ISportHalRepository> mock = new Mock<ISportHalRepository>();
            mock = getMock();

            AdminController controller = new AdminController(mock.Object);



            //Act
            SportsBuilding s1 = GetViewModel<SportsBuilding>(controller.EditSportBuildingView(1));

            //Assert
            Assert.Equal(true, s1.Canteen);
            Assert.Equal("Rijsbergen", s1.City);
            Assert.Equal(1, s1.HouseNumber);
            Assert.Equal(1, s1.HouseNumber);
            Assert.Equal("DeZaal", s1.Name);
            Assert.Equal("4891CP", s1.PostalCode);
            Assert.Equal("Rechtweg", s1.Street);



        }

        [Fact]
        public void Cannot_edit_Noneexistent_Can_Edit_SportsBuilding()
        {
            //Arrange
            Mock<ISportHalRepository> mock = new Mock<ISportHalRepository>();
            mock = getMock();

            AdminController controller = new AdminController(mock.Object);

            //Act
            SportsBuilding result = GetViewModel<SportsBuilding>(controller.EditSportBuildingView(10));

            //Assert
            Assert.Null(result);
        }


        [Fact]
        public void Can_Save_Edit_SportsBuilding()
        {
            //Arrange
            Mock<ISportHalRepository> mock = new Mock<ISportHalRepository>();
            

            AdminController controller = new AdminController(mock.Object);

            SportsBuilding sportsBuilding = new SportsBuilding
            {
                Name = "DeZaal",
                Canteen = false,
                City = "Rijsbergen",
                Street = "Rechtweg",
                HouseNumber = 1,
                PostalCode = "4892CP"
            };

            //Act
            IActionResult result = controller.EditSportsBuilding(sportsBuilding);


            //Assert
            mock.Verify(m => m.SaveSportsBuilding(sportsBuilding));
            Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("SportsBuilding", (result as RedirectToActionResult).ActionName);

        }

        [Fact]
        public void Cannot_Save_Invalid_editSportsBuilding()
        {

            //Arrange
            Mock<ISportHalRepository> mock = new Mock<ISportHalRepository>();
            

            AdminController controller = new AdminController(mock.Object);
            SportsBuilding sportsBuilding = new SportsBuilding
            {
                Name = "DeZaal",
                Canteen = false,
                City = "Rijsbergen",
                Street = "Rechtweg",
                HouseNumber = 1,
                PostalCode = "4892CP"
            };

            controller.ModelState.AddModelError("error", "error");

            //Act
            IActionResult result = controller.EditSportsBuilding(sportsBuilding);


            //Assert
            mock.Verify(m => m.SaveSportsBuilding(It.IsAny<SportsBuilding>()), Times.Never());
            Assert.IsType<ViewResult>(result);

        }
        //SportsHall//
        [Fact]
        public void Can_Edit_SportsHall()
        {
            //Arrange
            Mock<ISportHalRepository> mock = new Mock<ISportHalRepository>();
            mock = getMock();

            AdminController controller = new AdminController(mock.Object);



            //Act

            SportsHall s1 = GetViewModel<SportsHall>(controller.EditSportHallView(1));

            //Assert
            Assert.Equal(100, s1.Length);
            Assert.Equal(50, s1.Width);
            Assert.Equal(10, s1.NumberOfDressingSpace);
            Assert.Equal(5, s1.NumberOfShowers);
            


        }

        [Fact]
        public void Cannot_edit_Noneexistent_Can_Edit_SportsHall()
        {
            //Arrange
            Mock<ISportHalRepository> mock = new Mock<ISportHalRepository>();
            mock = getMock();

            AdminController controller = new AdminController(mock.Object);

            //Act
            SportsHall result = GetViewModel<SportsHall>(controller.EditSportHallView(10));

            //Assert
            Assert.Null(result);
        }


        [Fact]
        public void Can_Save_Edit_SportsHall()
        {
            //Arrange
            Mock<ISportHalRepository> mock = new Mock<ISportHalRepository>();


            AdminController controller = new AdminController(mock.Object);

            SportsHall sportsHall = new SportsHall
            {
               Length = 100,
               Width = 50,
               NumberOfDressingSpace = 20,
               NumberOfShowers = 10,
               
            };

            //Act
            IActionResult result = controller.EditSportsHall(sportsHall);


            //Assert
            mock.Verify(m => m.SaveSportsHall(sportsHall));
            Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("SportsHall", (result as RedirectToActionResult).ActionName);

        }

        [Fact]
        public void Cannot_Save_Invalid_editSportsHall()
        {

            //Arrange
            Mock<ISportHalRepository> mock = new Mock<ISportHalRepository>();


            AdminController controller = new AdminController(mock.Object);
            SportsHall sportsHall = new SportsHall
            {
                Length = 100,
                Width = 50,
                NumberOfDressingSpace = 20,
                NumberOfShowers = 10,

            };

            controller.ModelState.AddModelError("error", "error");

            //Act
            IActionResult result = controller.EditSportsHall(sportsHall);


            //Assert
            mock.Verify(m => m.SaveSportsHall(It.IsAny<SportsHall>()), Times.Never());
            Assert.IsType<ViewResult>(result);

        }

        //Sport//

        [Fact]
        public void Can_Edit_Sports()
        {
            //Arrange
            Mock<ISportHalRepository> mock = new Mock<ISportHalRepository>();
            mock = getMock();

            AdminController controller = new AdminController(mock.Object);



            //Act
            Sport s1 = GetViewModel<Sport>(controller.EditSportView(1));

            //Assert
            Assert.Equal("Voetbal", s1.Name);
            



        }

        [Fact]
        public void Cannot_edit_Noneexistent_Can_Edit_Sports()
        {
            //Arrange
            Mock<ISportHalRepository> mock = new Mock<ISportHalRepository>();
            mock = getMock();

            AdminController controller = new AdminController(mock.Object);

            //Act
            Sport result = GetViewModel<Sport>(controller.EditSportView(10));

            //Assert
            Assert.Null(result);
        }
        [Fact]
        public void Can_Save_Edit_Sports()
        {
            //Arrange
            Mock<ISportHalRepository> mock = new Mock<ISportHalRepository>();


            AdminController controller = new AdminController(mock.Object);

            Sport sport = new Sport
            {
                Name = "voetbal"

            };

            //Act
            IActionResult result = controller.EditSport(sport);


            //Assert
            mock.Verify(m => m.SaveSport(sport));
            Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Sport", (result as RedirectToActionResult).ActionName);

        }

        [Fact]
        public void Cannot_Save_Invalid_editSport()
        {

            //Arrange
            Mock<ISportHalRepository> mock = new Mock<ISportHalRepository>();


            AdminController controller = new AdminController(mock.Object);
            Sport sport = new Sport
            {
                Name = "voetbal"

            };

            controller.ModelState.AddModelError("error", "error");

            //Act
            IActionResult result = controller.EditSport(sport);


            //Assert
            mock.Verify(m => m.SaveSport(It.IsAny<Sport>()), Times.Never());
            Assert.IsType<ViewResult>(result);

        }



    }
}
