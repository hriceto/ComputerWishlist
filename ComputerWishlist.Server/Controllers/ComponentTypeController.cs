using ComputerWishlist.BusinessObjects.Request;
using ComputerWishlist.BusinessObjects.Response;
using ComputerWishlist.Server.ViewModels;
using CumputerWishlist.Data.DataController;
using Microsoft.AspNetCore.Mvc;

namespace ComputerWishlist.Server.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ComponentTypeController : ControllerBase
    {
        private readonly ILogger<ComputerSpecController> _logger;
        private IComponentTypeDataController _componentTypeDataController;

        public ComponentTypeController(ILogger<ComputerSpecController> logger, IComponentTypeDataController componentTypeDataController)
        {
            _logger = logger;
            _componentTypeDataController = componentTypeDataController;
        }

        [HttpPost(Name = "GetComponentTypes")]
        public GetComponentTypesResponse GetComponentTypes(GetComponentTypesRequest request)
        {
            return _componentTypeDataController.GetComponentTypes(request);
        }

        [HttpPost(Name = "SaveComponentType")]
        public SaveComponentTypeResponse SaveComponentType(SaveComponentTypeRequest request)
        {
            return _componentTypeDataController.SaveComponentType(request);
        }

        [HttpPost(Name = "DeleteComponentType")]
        public DeleteComponentTypeResponse DeleteComponentType(DeleteComponentTypeRequest request)
        {
            return _componentTypeDataController.DeleteComponentType(request);
        }
    }
}
