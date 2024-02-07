using AutoMapper;
using ComputerWishlist.BusinessObjects.Request;
using ComputerWishlist.BusinessObjects.Response;
using ComputerWishlist.Server.ViewModels;
using CumputerWishlist.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CumputerWishlist.Data.DataController
{
    public class ComponentTypeDataController : IComponentTypeDataController
    {
        private CumputerWishlistDataContext _context;
        private readonly IMapper _mapper;

        public ComponentTypeDataController(CumputerWishlistDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GetComponentTypesResponse GetComponentTypes(GetComponentTypesRequest request)
        {
            var response = new GetComponentTypesResponse();

            try
            {
                var computerSpecComponents = _context.Components.Include(c => c.ComponentType).ToList();
                response.ComponentTypes = MapModelToViewModel(computerSpecComponents);
                response.Success = true;
            }
            catch (Exception ex)
            {
                //todo: log exception
            }


            return response;
        }

        private List<ComputerSpecComponentTypeViewModel> MapModelToViewModel(List<Component> dbData)
        {

            var componentTypes = _mapper.Map<List<ComputerSpecComponentTypeViewModel>>(dbData.
                    Select(c => c.ComponentType).DistinctBy(ct => ct.Id).ToList());
            foreach (var componentType in componentTypes)
            {
                componentType.Components = _mapper.Map<List<ComputerSpecComponentViewModel>>(dbData.
                Where(c => c.ComponentTypeId == componentType.Id).
                Select(c => c).DistinctBy(c => c.Id).ToList());
            }

            return componentTypes;
        }

        public SaveComponentTypeResponse SaveComponentType(SaveComponentTypeRequest request)
        {

            var response = new SaveComponentTypeResponse();

            try
            {
                bool newRocord = false;
                var dbComponentType = _context.ComponentTypes.FirstOrDefault(ct => ct.Id == request.ComponentType.Id);
                if (dbComponentType == null)
                {
                    dbComponentType = new ComponentType();
                    _context.ComponentTypes.Attach(dbComponentType);
                    newRocord = true;
                }
                dbComponentType.Name = request.ComponentType.Name;
                dbComponentType.MaxLimit = 1;
                _context.SaveChanges();

                if (newRocord)
                {
                    foreach (var newComponent in request.ComponentType.Components)
                    {
                        _context.Components.Add(new Component { ComponentTypeId = dbComponentType.Id, Name = newComponent.Name });
                    }
                    _context.SaveChanges();
                }
                else
                {
                    var dbComponents = _context.Components.Where(c => c.ComponentTypeId == dbComponentType.Id).ToList();
                    var dbComponentsToRemove = dbComponents.Where(csc => request.ComponentType.Components.Count(nc => nc.Id == csc.Id) == 0).ToList();
                    foreach (var dbComponentToRemove in dbComponentsToRemove)
                    {
                        _context.Remove(dbComponentToRemove);
                    }
                    var dbComponentIds = dbComponents.Select(dbc => dbc.Id);
                    var componentsToAdd = request.ComponentType.Components.Where(nc => !dbComponentIds.Contains(nc.Id));
                    foreach (var componentToAdd in componentsToAdd)
                    {
                        _context.Components.Add(new Component() { ComponentTypeId = dbComponentType.Id, Name = componentToAdd.Name });
                    }

                    foreach (var dbComponent in dbComponents)
                    {
                        var newComponent = request.ComponentType.Components.FirstOrDefault(c => c.Id == dbComponent.Id);
                        dbComponent.Name = newComponent?.Name;
                    }

                    _context.SaveChanges();
                }

                response.Success = true;
            }
            catch (Exception ex)
            {
                //todo: log exception
            }
            return response;
        }

        public DeleteComponentTypeResponse DeleteComponentType(DeleteComponentTypeRequest request)
        {
            var response = new DeleteComponentTypeResponse();

            try
            {
                var dbComponentType = _context.ComponentTypes.FirstOrDefault(c => c.Id == request.ComponentTypeId);
                if (dbComponentType != null)
                {
                    _context.Remove(dbComponentType);
                    _context.SaveChanges();
                }

                response.Success = true;
            }
            catch (Exception ex)
            {
                //todo: log exception
            }
            return response;
        }
    }
}
