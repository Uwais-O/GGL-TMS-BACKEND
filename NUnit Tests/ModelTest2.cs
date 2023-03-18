/**

This class contains unit tests for the Member class in the Backend2.Models namespace.
*/
using Backend2.Models;
using NUnit.Framework;
namespace Backend2.Tests.Models
{
    [TestFixture]
    public class MemberTests
    {
        
         //Test that sets the properties of a Member object and verifies that they are set correctly.
       
        [Test]
        public void Member_SetProperties_PropertiesAreSetCorrectly()
        {
            // Arrange
            var member = new Member();

            
               // Act
            member.id = 1;
            member.mname = "John";
            member.role = "Developer";
            member.tstack = ".NET";
            member.blockers = "None";

            // Assert
            Assert.AreEqual(1, member.id);
            Assert.AreEqual("John", member.mname);
            Assert.AreEqual("Developer", member.role);
            Assert.AreEqual(".NET", member.tstack);
            Assert.AreEqual("None", member.blockers);
        }
    }
}