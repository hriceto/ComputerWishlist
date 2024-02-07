using AutoMapper;
using ComputerWishlist.BusinessObjects.Request;
using ComputerWishlist.BusinessObjects.Response;
using ComputerWishlist.Server.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CumputerWishlist.Data.DataController
{
    public class UserDataController : IUserDataController
    {
        private CumputerWishlistDataContext _context;
        private readonly IMapper _mapper;

        public UserDataController(CumputerWishlistDataContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }

        public CreateUserResponse CreateUser(CreateUserRequest request)
        {
            var response = new CreateUserResponse();

            try
            {

                var user = new Model.User();
                user.Name = Guid.NewGuid().ToString();
                _context.Users.Add(user);
                _context.SaveChanges();
                response.UserId = user.Id;
                response.Success = true;
            }
            catch(Exception ex)
            {
                //todo: log exception
            }

            return response;
        }
    }
}
