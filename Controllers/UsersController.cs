using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Model;
using WebAPI.DBHelper;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        DBManager dbManager = new DBManager();
        [HttpGet]
        public List<User> AllUser()
        {
            List<User> users = new List<User>();
            users = dbManager.readUser();
            return users;
        }

        //[Route("/api/users")]
        [HttpPost]
        public void Post([FromBody] User user)
        {
            if (user == null)
            {
                return;
            }
            dbManager.createUser(user);
        }

        [HttpGet("{id}")]
        public User FindUserByID(int id)
        {
            List<User> users = new List<User>();
            User cur = new User();
            users = dbManager.readUser();
            foreach (User user in users)
            {
                if (user.ID == id) return user;
            }
            return cur;
        }

        [HttpPut("{id}")]
        public void UpdateUser([FromBody] User user)
        {
            if (user == null) return;
            dbManager.updateUser(user);
        }
    }
}