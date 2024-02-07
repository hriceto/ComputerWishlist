using ComputerWishlist.Server.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerWishlist.BusinessObjects.Response
{
    public class GetComponentTypesResponse
    {
        public bool Success {  get; set; }
        public List<ComputerSpecComponentTypeViewModel> ComponentTypes { get; set; } = new List<ComputerSpecComponentTypeViewModel>();
    }
}
