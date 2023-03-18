using Backend2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        // Define a private readonly instance of the MemberDbContext class.
        private readonly MemberDbContext _memberDbContext;

        // Define a constructor for the MemberController class that takes a MemberDbContext parameter.
        public MemberController(MemberDbContext memberDbContext)
        {
            // Assign the value of the memberDbContext parameter to the private _memberDbContext field.
            _memberDbContext = memberDbContext;
        }

        // Define an HTTP GET method that returns a list of all Member objects.
        [HttpGet]
        [Route("GetMember")]
        public async Task<IEnumerable<Member>> GetMembers()
        {
            // Retrieve all Member objects from the database and return them as a list.
            return await _memberDbContext.Member.ToListAsync();
        }

        // Define an HTTP POST method that adds a new Member object to the database.
        [HttpPost]
        [Route("AddMember")]
        public async Task<Member> AddMember(Member objMember)
        {
            // Add the new Member object to the database and save the changes.
            _memberDbContext.Member.Add(objMember);
            await _memberDbContext.SaveChangesAsync();
            // Return the newly added Member object.
            return objMember;
        }

        // Define an HTTP PATCH method that updates an existing Member object in the database.
        [HttpPatch]
        [Route("UpdateMember/{id}")]
        public async Task<Member> UpdateMember(Member objMember)
        {
            // Mark the specified Member object as modified in the database and save the changes.
            _memberDbContext.Entry(objMember).State = EntityState.Modified;
            await _memberDbContext.SaveChangesAsync();
            // Return the updated Member object.
            return objMember;
        }

        // Define an HTTP DELETE method that deletes a Member object from the database.
        [HttpDelete]
        [Route("DeleteMember/{id}")]
        public bool DeleteMember(int id)
        {
            bool a = false;
            // Find the Member object with the specified ID in the database.
            var member = _memberDbContext.Member.Find(id);
            if (member != null)
            {
                a = true;
                // Mark the specified Member object as deleted in the database and save the changes.
                _memberDbContext.Entry(member).State = EntityState.Deleted;
                _memberDbContext.SaveChanges();
            }
            else
            {
                a = false;
            }
            // Return a boolean value indicating whether the Member object was deleted.
            return a;
        }
    }
}
