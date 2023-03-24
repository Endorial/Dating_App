//  This code is defining a C# class called UsersController that handles HTTP requests related to user data in an API.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
// (2-8) This section of the code is importing necessary libraries and namespaces for the class.

// (12-19) This section of the code is defining the UsersController class within the API.Controllers namespace. The [ApiController] attribute tells ASP.NET Core that this class will handle HTTP requests, and the [Route] attribute specifies the URL path that clients can use to access this controller.
namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // / api/users 'how they will acces this controller'


    public class UsersController : ControllerBase
    {
        // (21-28) These lines define a private field _context of type DataContext, which will be used to access the database. The constructor takes a DataContext parameter and sets the _context field to this parameter.
        private readonly DataContext _context; // we use "_"(underscore) character instead of declaring DataContext "context" so we won't have to declare it in the constructor as this.context = context

        //ctr shortcut

        public UsersController(DataContext context) // 
        {
            _context = context; //  _context = this.context
        }

        // (31-34) This line defines a HTTP GET method called GetUsers which returns a collection of AppUser objects. It uses the _context field to access the list of users from the database and return them as a list.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();

            return users;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {

            return await _context.Users.FindAsync(id);
        }
    } // Overall, this code is defining a basic API endpoint that allows clients to access a list of users stored in a database.
}