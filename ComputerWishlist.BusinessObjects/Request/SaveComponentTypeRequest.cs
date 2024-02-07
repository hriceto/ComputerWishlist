using ComputerWishlist.Server.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerWishlist.BusinessObjects.Request
{
    public class SaveComponentTypeRequest
    {
        public ComputerSpecComponentTypeViewModel ComponentType { get; set; }
    }
}
