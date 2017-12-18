using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Moq;
using Xunit;
using SporthalC3.Controllers;
using SporthalC3.Models;
using Microsoft.AspNetCore.Mvc;
using SporthalC3.ViewModels;
using SporthalC3.Domain;

using SporthalC3.Migrations;

namespace SporthalC3.Tests
{
    public class ReserveControllerTests
    {

        private T GetViewModel<T>(IActionResult result) where T : class
        {
            return (result as ViewResult)?.ViewData.Model as T;
        }
        public Mock<ISportHalRepository> getMock()
        {
            Mock<ISportHalRepository> mock = new Mock<ISportHalRepository>();

            mock.Setup(x => x.SportsHall).Returns(
                new SportsHall[]
                {
                    new SportsHall
                    {
                        Length = 100,
                        Width = 50,
                        NumberOfShowers = 10,
                        NumberOfDressingSpace = 20,
                        Price = 100,
                        OpenTime = new DateTime(1990,1,1,8,0,0),
                        CloseTime = new DateTime(1990,1,1,17,0,0),
                        Reserve = new Reserve[]
                {
                    new Reserve
                    {
                        Datum = new DateTime(2000, 5, 19),
                        Email = "Tomvanhaaster@hotmail.com",
                        PhoneNumber = 0645784578,
                        FirstName = "Tom",
                        LastName = "Haaster",
                        StartTime = new DateTime(1990,1,1,9,0,0),
                        EndTime = new DateTime(1990,1,1,10,0,0)
                    },
                    new Reserve
                    {
                        Datum = new DateTime(2000, 5, 19),
                        Email = "HansJns@hotmail.com",
                        PhoneNumber = 0645784577,
                        FirstName = "Hans",
                        LastName = "Jansen",
                        StartTime = new DateTime(1990,1,1,12,0,0),
                        EndTime = new DateTime(1990,1,1,15,0,0)
                    },
                    new Reserve
                    {
                        Datum = new DateTime(2000, 5, 12),
                        Email = "HansJns@hotmail.com",
                        PhoneNumber = 0645784577,
                        FirstName = "Hans",
                        LastName = "Jansen",
                        StartTime = new DateTime(1990,1,1,12,0,0),
                        EndTime = new DateTime(1990,1,1,15,0,0)
                    }
                }

                    }
                }



                );

            return mock;
        }
        
        [Fact]
        public void Can_Save_Reserve()
        {
            //Arrange
            Mock<ISportHalRepository> mock = new Mock<ISportHalRepository>();
            mock = getMock();

            ReserveController controller = new ReserveController(mock.Object);

            ReserveViewModel ViewModel = new ReserveViewModel();

            
            Reserve reserve = new Reserve
            {
                Datum = new DateTime(2000, 5, 19),
                Email = "Kees@test.com",
                PhoneNumber = 0645784578,
                FirstName = "Kees",
                LastName = "Test",                
                StartTime = new DateTime(1990, 1, 1, 10, 0, 0),
                EndTime = new DateTime(1990, 1, 1, 12, 0, 0)
            };
            ViewModel.Reserve = reserve;

            //Act
            IActionResult result = controller.ReserveStatus(ViewModel, 2, 10, 1, new DateTime(1990, 1, 1));


            //Assert
            mock.Verify(m => m.SaveReserve(reserve));
            Assert.IsType<ViewResult>(result);
            Assert.Equal("ReservationStatus", (result as ViewResult).ViewName);

        }


        
        [Fact]
        public void Cannot_Save_Invalid_Reserve()
        {
            //Arrange
            Mock<ISportHalRepository> mock = new Mock<ISportHalRepository>();
            mock = getMock();

            ReserveController controller = new ReserveController(mock.Object);

            ReserveViewModel ViewModel = new ReserveViewModel();

            
            Reserve reserve = new Reserve
            {
                Datum = new DateTime(2018, 1, 1),
                Email = "Kees@test.com",
                PhoneNumber = 0645784578,
                
                LastName = "Test",
                StartTime = new DateTime(1990, 1, 1, 10, 0, 0),
                EndTime = new DateTime(1990, 1, 1, 12, 0, 0)
            };
            ViewModel.Reserve = reserve;

            //Act
            IActionResult result = controller.ReserveStatus(ViewModel, 2, 10, 1, new DateTime(2018, 1, 1));


            //Assert            
            Assert.IsType<ViewResult>(result);
            Assert.Equal("NaamInvul", (result as ViewResult).ViewName);


        }
    }
}
 
