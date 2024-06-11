using Moq;
using MyProject.Tests.Service;
using Xunit;

namespace MyProject.Tests
{
    public class MyServiceTests
    {
        [Fact]
        public void GetData_ReturnsMockData()
        {
            // Arrange
            var mockService = new Mock<IMyService>();
            mockService.Setup(service => service.GetData()).Returns("Mock Data");

            // Act
            var result = mockService.Object.GetData();

            // Assert
            Assert.Equal("Mock Data", result);
        }

        [Fact]
        public void GetData_ReturnsRealData()
        {
            // Arrange
            var realService = new MyService(); // Thay bằng DI nếu cần
            var expectedResult = "Real Data";

            // Act
            var result = realService.GetData();

            // Assert
            Assert.Equal(expectedResult, result);
        }
    }
}
