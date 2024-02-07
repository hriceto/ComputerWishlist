using ComputerWishlist.BusinessObjects.Request;
using ComputerWishlist.BusinessObjects.Response;
using ComputerWishlist.Server.ViewModels;
using CumputerWishlist.Data.DataController;
using Microsoft.AspNetCore.Mvc;

namespace ComputerWishlist.Server.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ComputerSpecController : ControllerBase
    {
        private readonly ILogger<ComputerSpecController> _logger;
        private IComputerSpecDataController _computerSpecsDataController;

        public ComputerSpecController(ILogger<ComputerSpecController> logger, IComputerSpecDataController computerSpecsDataController)
        {
            _logger = logger;
            _computerSpecsDataController = computerSpecsDataController;
        }

        [HttpPost(Name = "GetSystemComputerSpecs")]
        public GetComputerSpecsResponse GetSystemComputerSpecs(GetSystemComputerSpecsRequest request)
        {
            return _computerSpecsDataController.GetSystemComputerSpecs(request);
        }

        [HttpPost(Name = "GetUserComputerSpecs")]
        public GetComputerSpecsResponse GetUserComputerSpecs(GetUserComputerSpecsRequest request)
        {
            return _computerSpecsDataController.GetUserComputerSpecs(request);
        }

        [HttpPost(Name = "SaveComputerSpec")]
        public SaveComputerSpecResponse SaveComputerSpec(SaveComputerSpecRequest request)
        {
            return _computerSpecsDataController.SaveComputerSpec(request);
        }

        [HttpPost(Name = "DeleteComputerSpec")]
        public DeleteComputerSpecResponse DeleteComputerSpec(DeleteComputerSpecRequest request)
        {
            return _computerSpecsDataController.DeleteComputerSpec(request);
        }
    }
}
