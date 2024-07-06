using EmployeeWebApi.Controllers;
using EmployeeWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;

namespace UnitTestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestCalculatorAdd()
        {
            //A. Arrange
            Calculator calc = new Calculator();
            int a = 100, b = 300;

            //A. Act
            int actualResult=calc.Add(a, b);

            //A. Assert
            int expectedResult=400;
            Assert.AreEqual(expectedResult,actualResult);            
        }
        [Test]
        public void TestCalculatorSubtract()
        {
            //A. Arrange
            Calculator calc = new Calculator();
            int a = 100, b = 300;

            //A. Act
            int actualResult = calc.Subtract(a, b);

            //A. Assert
            int expectedResult = -200;
            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public void TestCalculatorMultiply()
        {
            //A. Arrange
            Calculator calc = new Calculator();
            int a = 100, b = 300;

            //A. Act
            int actualResult = calc.Multiply(a, b);

            //A. Assert
            int expectedResult = 30000;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void TestEmployeeAPIGetAllEmps()
        {
            //A. Arrange

            DbContextOptions<EmployeeDbContext> dbOptions = new DbContextOptions<EmployeeDbContext>();
            EmployeeDbContext dbContext= new EmployeeDbContext(dbOptions);
            
            Mock<IConfiguration> mockConfig=new Mock<IConfiguration>();
            IConfiguration config = mockConfig.Object;
            
            EmployeeController controller = new EmployeeController(dbContext, config);

            int id = 101;

            //A. Act
            var actualResult = controller.GetEmpById(id);

            //A. Assert
            var expectedResult = new Employee
            {
                Ecode=101,
                Ename= "Ramnath Nishad",
                Salary=12345,
                Deptid=203
            };

            var ok = new OkObjectResult(expectedResult);
            Assert.AreEqual(ok, actualResult);
        }
    }
}

