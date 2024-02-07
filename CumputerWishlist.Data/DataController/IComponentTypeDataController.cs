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
    public interface IComponentTypeDataController
    {
        public GetComponentTypesResponse GetComponentTypes(GetComponentTypesRequest request);
        public SaveComponentTypeResponse SaveComponentType(SaveComponentTypeRequest request);
        public DeleteComponentTypeResponse DeleteComponentType(DeleteComponentTypeRequest request);
    }
}
