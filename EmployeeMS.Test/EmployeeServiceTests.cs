using EmployeeMS.Data.Entities;
using EmployeeMS.Data;
using EmployeeMS.Services;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace EmployeeMS.Test
{
    [TestFixture]
    public class EmployeeServiceTests
    {
        private EmployeeService _employeeService;
        private Mock<ApplicationDbContext> _mockContext;

        [SetUp]
        public void Setup()
        {
            _mockContext = new Mock<ApplicationDbContext>(new DbContextOptions<ApplicationDbContext>());
            _employeeService = new EmployeeService(_mockContext.Object);
        }

        [Test]
        public async Task GetEmployeeByIdAsync_WithValidId_ShouldReturnEmployee()
        {
            // Arrange
            var expectedEmployeeId = Guid.NewGuid();
            var expectedEmployee = new Employee
            {
                Id = expectedEmployeeId,
                Name = "Test Employee",
                // Set other properties as needed
            };

            // Set up the mock DbSet and queryable
            var mockDbSet = new Mock<DbSet<Employee>>();

            // Set up the mock ApplicationDbContext
            _mockContext.Setup(x => x.Employee).Returns(mockDbSet.Object);

            // Act
            var result = await _employeeService.GetEmployeeByIdAsync(expectedEmployeeId);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(expectedEmployeeId, result.Id);
            // Assert other properties as needed
        }

        [Test]
        public async Task GetEmployeeByIdAsync_WithInvalidId_ShouldReturnNull()
        {
            // Arrange
            var invalidEmployeeId = Guid.NewGuid();

            // Set up the mock DbSet with no employees
            var mockDbSet = new Mock<DbSet<Employee>>();
            mockDbSet.As<IQueryable<Employee>>().Setup(m => m.Provider).Returns(new Employee[0].AsQueryable().Provider);
            mockDbSet.As<IQueryable<Employee>>().Setup(m => m.Expression).Returns(new Employee[0].AsQueryable().Expression);
            mockDbSet.As<IQueryable<Employee>>().Setup(m => m.ElementType).Returns(new Employee[0].AsQueryable().ElementType);
            mockDbSet.As<IQueryable<Employee>>().Setup(m => m.GetEnumerator()).Returns(new Employee[0].AsQueryable().GetEnumerator());

            // Set up the mock ApplicationDbContext
            _mockContext.Setup(x => x.Employee).Returns(mockDbSet.Object);

            // Act
            var result = await _employeeService.GetEmployeeByIdAsync(invalidEmployeeId);

            // Assert
            Assert.Null(result);
        }

        [TearDown]
        public void TearDown()
        {
            _employeeService = null;
            _mockContext = null;
        }
    }
}