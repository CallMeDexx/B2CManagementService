using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace B2CManagementService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IB2CDB _db;
        //private readonly IUserProvider _userProvider;
        //private readonly IUserRepository _userRepository;

        public UsersController(IB2CDB db)
        {
            _db = db;

        }


        // GET: api/<UsersController>
        [HttpGet("/all")]
        public IEnumerable<UserModel> GetAllUsers()
        {
            return _db.GetAllUsers();
        }


        // GET api/<UsersController>/5  
        [HttpGet("{emil}")]
        public UserModel? GetUser(string email)
        {
            return _db.GetUser(email);
        }

        // POST api/<UsersController>
        [HttpPost("//create")]
        public UserModel? CreateUser([FromBody] UserModel user)
        {
            return _db.CreateUser(user);
        }

        [HttpPut("/validate")]
        public bool ValidateUser([FromBody] UserModel user)
        {
            return _db.ValidateUser(user);

        }

        // PUT api/<UsersController>/5
        [HttpPut("update")]
        public UserModel? UpdateUser([FromBody] UserModel user)
        {
            return _db.UpdateUser(user);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("remove/{emil}")]
        public string Delete(string email)
        {
            return $"Removing user with the email: '{email}'";
        }
    }
}
