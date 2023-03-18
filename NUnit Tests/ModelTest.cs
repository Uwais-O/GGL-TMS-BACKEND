using Backend2.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Backend2.Tests
{
    
    /// This class contains unit tests for the MemberDbContext class.
    [TestFixture]
    public class MemberDbContextTests
    {
        
        /// This test checks whether a new MemberDbContext can be created successfully.
        [Test]
        public void Can_Create_MemberDbContext()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<MemberDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            // Act
            var dbContext = new MemberDbContext(options);

            // Assert
            Assert.IsNotNull(dbContext);
        }
    }
}
