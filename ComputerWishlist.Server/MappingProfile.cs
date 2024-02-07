using AutoMapper;
using ComputerWishlist.Server.ViewModels;
using CumputerWishlist.Data.Model;

namespace ComputerWishlist.Server
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<ComputerSpecViewModel, ComputerSpec>();
            CreateMap<ComputerSpec, ComputerSpecViewModel>();
            
            CreateMap<ComputerSpecComponentTypeViewModel, ComponentType>();
            CreateMap<ComponentType, ComputerSpecComponentTypeViewModel>();

            CreateMap<ComputerSpecComponentViewModel, ComputerSpecComponent>();
            CreateMap<ComputerSpecComponent, ComputerSpecComponentViewModel>().
                ForMember(d => d.Id, opt => opt.MapFrom(s => s.ComponentId)).
                ForMember(d => d.Name, opt => opt.MapFrom(s => s.Component.Name));

            CreateMap<ComputerSpecComponentViewModel, Component>();
            CreateMap<Component, ComputerSpecComponentViewModel>();
        }
    }
}
