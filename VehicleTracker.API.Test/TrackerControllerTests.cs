using Core.BaseRepository;
using VehicleTracker.API.BL;
using VehicleTracker.DTO;
using Xunit;
using Moq;
using System.Threading.Tasks;
using System.Collections.Generic;
using VehicleTracker.BusinessModel;
using System;
using VehicleTracker.API.Controllers;
using System.Linq;
using Core.DbEntites.Helpers;
using MockQueryable.Moq;
using System.Linq.Expressions;

namespace VehicleTracker.API.Test
{
    public class TrackerControllerTests
    {
        
        [Fact]
        public async Task Get_ReturnsAResult_WithAListOfStatusHistory()
        {
            // Arrange
            var mockRepo = new Mock<IBaseRepository<VehicleStatus>>();
            mockRepo.Setup(repo => repo.WhereOrdered(It.IsAny<Expression<Func<VehicleStatus, bool>>>(), It.IsAny<Expression<Func<VehicleStatus, object>>>(),
                It.IsAny<Expression<Func<VehicleStatus, object>>>())).Returns(Task.FromResult(GetTestData().ToList()));
            var controller = new TrackerController(mockRepo.Object);

            // Act
            var result = await controller.Get();

            // Assert
            var viewResult = Assert.IsType<List<StatusHistory>>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<StatusHistory>>(viewResult);
            Assert.Equal(2, model.Count());
        }

        private List<VehicleStatus> GetTestData()
        {
            var vehiclestatus = new List<VehicleStatus>
            {
                new VehicleStatus()
                {
                    CreatedDate = DateTime.Now,
                    Vehicle = new Vehicle()
                    {
                        RegistrationNumber = "ABC333",
                        Id = new Guid(),
                        CreatedDate = DateTime.Now
                    },
                    Status = true,
                    Id = new Guid(),
                    VehicleId = new Guid()
                },
                new VehicleStatus()
                {
                    CreatedDate = DateTime.Now,
                    Vehicle = new Vehicle()
                    {
                        RegistrationNumber = "EHJ333",
                        Id = new Guid(),
                        CreatedDate = DateTime.Now
                    },
                    Status = false,
                    Id = new Guid(),
                    VehicleId = new Guid()
                }
            };
            return vehiclestatus;
        }
    }
}