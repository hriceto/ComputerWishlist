using ComputerWishlist.Server.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerWishlist.BusinessObjects.Request
{
    public class SaveComputerSpecRequest
    {
        public ComputerSpecViewModel ComputerSpec { get; set; }
        public bool IsAdmin { get; set; }
        public int UserId { get; set; }
    }
}
