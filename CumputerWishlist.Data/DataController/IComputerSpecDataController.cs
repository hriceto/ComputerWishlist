using ComputerWishlist.BusinessObjects.Request;
using ComputerWishlist.BusinessObjects.Response;
using CumputerWishlist.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CumputerWishlist.Data.DataController
{
    public interface IComputerSpecDataController
    {
        public GetComputerSpecsResponse GetSystemComputerSpecs(GetSystemComputerSpecsRequest request);
        public GetComputerSpecsResponse GetUserComputerSpecs(GetUserComputerSpecsRequest request);
        public SaveComputerSpecResponse SaveComputerSpec(SaveComputerSpecRequest request);
        public DeleteComputerSpecResponse DeleteComputerSpec(DeleteComputerSpecRequest request);
    }
}
