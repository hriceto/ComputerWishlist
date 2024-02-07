using ComputerWishlist.BusinessObjects.Request;
using ComputerWishlist.BusinessObjects.Response;
using ComputerWishlist.Server.ViewModels;
using CumputerWishlist.Data.DataController;
using Microsoft.AspNetCore.Mvc;

namespace ComputerWishlist.Server.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private IUserDataController _userDataController;

        public UserController(ILogger<UserController> logger, IUserDataController userDataController)
        {
            _logger = logger;
            _userDataController = userDataController;
        }

        [HttpPost(Name = "CreateUser")]
        public CreateUserResponse CreateUser(CreateUserRequest request)
        {
            return _userDataController.CreateUser(request);
        }
    }
}
