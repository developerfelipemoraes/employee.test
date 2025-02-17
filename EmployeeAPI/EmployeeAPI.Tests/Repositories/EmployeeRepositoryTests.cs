//using EmployeeAPI.Models;
//using EmployeeAPI.Repositories;
//using MongoDB.Driver;
//using Moq;
//using Xunit;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace EmployeeAPI.Tests.Repositories
//{
//    public class EmployeeRepositoryTests
//    {
//        private readonly Mock<IMongoCollection<Employee>> _mockCollection;
//        private readonly Mock<IMongoDatabase> _mockDatabase;
//        private readonly Mock<IMongoClient> _mockClient;
//        private readonly EmployeeRepository _repository;

//        public EmployeeRepositoryTests()
//        {
//            _mockCollection = new Mock<IMongoCollection<Employee>>();
//            _mockDatabase = new Mock<IMongoDatabase>();
//            _mockClient = new Mock<IMongoClient>();

//            _mockDatabase.Setup(db => db.GetCollection<Employee>(It.IsAny<string>(), null)).Returns(_mockCollection.Object);
//            _mockClient.Setup(client => client.GetDatabase(It.IsAny<string>(), null)).Returns(_mockDatabase.Object);

//            _repository = new EmployeeRepository(new EmployeeAPI.Data.ApplicationDbContext(_mockClient.Object));
//        }

//        [Fact]
//        public async Task GetAllAsync_CallsFindMethod()
//        {
//            // Act
//            await _repository.GetAllAsync();

//            // Assert
//            _mockCollection.Verify(coll => coll.Find(It.IsAny<FilterDefinition<Employee>>(), null), Times.Once);
//        }
//    }
//}