using Backend2.Controllers;
using Backend2.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//NUnit testing for the controller class
namespace Backend2.Tests
{
    [TestFixture]
    public class MemberControllerTests
    {
        private MemberController _controller;
        private MemberDbContext _dbContext;

        [SetUp]
        public void SetUp()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<MemberDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _dbContext = new MemberDbContext(options);
            _controller = new MemberController(_dbContext);
        }

        [TearDown]
        public void TearDown()
        {
            // Deletes the in-memory database after each test.
            _dbContext.Database.EnsureDeleted();
        }

        [Test]
        public async Task GetMembers_Returns_All_Members()
        {
            // Arrange
            var members = new List<Member>()
            {
                new Member { id = 1, mname = "John" },
                new Member { id = 2, mname = "Jane" },
                new Member { id = 3, mname = "Jack" }
            };
            _dbContext.Member.AddRange(members);
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await _controller.GetMembers();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IEnumerable<Member>>(result);
            Assert.That(3, result.Count());
        }

        [Test]
        public async Task AddMember_Adds_New_Member()
        {
            // Arrange
            var member = new Member { mname = "John" };

            // Act
            var result = await _controller.AddMember(member);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(member.mname, result.mname);

            // Verifies that the new member is added to the in-memory database.
            var savedMember = _dbContext.Member.Find(result.id);
            Assert.IsNotNull(savedMember);
            Assert.That(member.mname, savedMember.mname);
        }

        [Test]
        public async Task UpdateMember_Updates_Existing_Member()
        {
            // Arrange
            var existingMember = new Member { mname = "John" };
            _dbContext.Member.Add(existingMember);
            await _dbContext.SaveChangesAsync();

            var updatedMember = new Member { id = existingMember.id, mname = "Jane" };

            // Act
            var result = await _controller.UpdateMember(updatedMember);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(updatedMember.mname, result.mname);

            // Verifies that the existing member is updated in the in-memory database.
            var savedMember = _dbContext.Member.Find(result.id);
            Assert.IsNotNull(savedMember);
            Assert.That(updatedMember.mname, savedMember.mname);
        }

        [Test]
        public async Task DeleteMember_Deletes_Existing_Member()
        {
            // Arrange
            var existingMember = new Member { mname = "John" };
            _dbContext.Member.Add(existingMember);
            await _dbContext.SaveChangesAsync();

            // Act
            var result = _controller.DeleteMember(existingMember.id);

            // Assert
            Assert.IsTrue(result);

            // Verifies that the existing member is deleted from the in-memory database.
            var savedMember = _dbContext.Member.Find(existingMember.id);
            Assert.IsNull(savedMember);
        }

        [Test]
        public void DeleteMember_Returns_False_For_Nonexistent_Member()
        {
            // Arrange
            var nonexistentMemberId = 100;

            // Act
            var result = _controller.DeleteMember(nonexistentMemberId);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
