using Xunit;
using Moq;
using PharmacyManagementAPI.Services;
using PharmacyManagementAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace PharmacyManagementAPI.Tests.Services
{
    public class PharmacyServiceTests
    {
        private readonly Mock<IPharmacyRepository> _mockRepo;
        private readonly PharmacyService _service;

        public PharmacyServiceTests()
        {
            _mockRepo = new Mock<IPharmacyRepository>();
            _service = new PharmacyService(_mockRepo.Object);
        }

        [Fact]
        public void GetAllPharmacies_ReturnsListOfPharmacies()
        {
            // Arrange
            var mockPharmacies = new List<Pharmacy>
            {
                new Pharmacy { Id = 1, Name = "PharmacyCat" },
                new Pharmacy { Id = 2, Name = "PharmacyDuck" }
            };
            _mockRepo.Setup(repo => repo.GetAllPharmacies()).Returns(mockPharmacies);

            // Act
            var result = _service.GetAllPharmacies();

            // Assert
            Assert.Equal(2, result.Count());
            Assert.Equal("PharmacyCat", result.ElementAt(0).Name);
            Assert.Equal("PharmacyDuck", result.ElementAt(1).Name);
        }
    }
}
