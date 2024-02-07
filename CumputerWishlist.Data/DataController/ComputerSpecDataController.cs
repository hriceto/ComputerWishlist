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
    public class ComputerSpecDataController : IComputerSpecDataController
    {
        private CumputerWishlistDataContext _context;
        private readonly IMapper _mapper;

        public ComputerSpecDataController(CumputerWishlistDataContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }

        public GetComputerSpecsResponse GetSystemComputerSpecs(GetSystemComputerSpecsRequest request)
        {
            var response = new GetComputerSpecsResponse();

            try
            {
                var computerSpecComponents = _context.ComputerSpecComponents.Include(csc => csc.ComputerSpec).Include(csc => csc.Component).ThenInclude(c => c.ComponentType).
                    Where(csc => csc.ComputerSpec.IsSystem == true).ToList();                
                response.ComputerSpecs = MapModelToViewModel(computerSpecComponents);
                response.Success = true;
            }
            catch (Exception ex)
            {
                //todo: log exception
            }
            

            return response;
        }

        public GetComputerSpecsResponse GetUserComputerSpecs(GetUserComputerSpecsRequest request)
        {
            var response = new GetComputerSpecsResponse();

            try
            {
                var computerSpecComponents = _context.ComputerSpecComponents.Include(csc => csc.ComputerSpec).Include(csc => csc.Component).ThenInclude(c => c.ComponentType).
                    Where(csc => csc.ComputerSpec.IsSystem == false && csc.ComputerSpec.UserId == request.UserId).ToList();
                response.ComputerSpecs = MapModelToViewModel(computerSpecComponents);
                response.Success = true;
            }
            catch (Exception ex)
            {
                //todo: log exception
            }
            return response;
        }

        private List<ComputerSpecViewModel> MapModelToViewModel(List<ComputerSpecComponent> dbData)
        {
            var computerSpecs = _mapper.Map<List<ComputerSpecViewModel>>(dbData.Select(csc => csc.ComputerSpec).DistinctBy(cs => cs.Id).ToList());

            foreach (var computerSpec in computerSpecs)
            {
                computerSpec.ComponentTypes = _mapper.Map<List<ComputerSpecComponentTypeViewModel>>(dbData.
                    Where(csc => csc.ComputerSpecId == computerSpec.Id).
                    Select(csc => csc.Component.ComponentType).DistinctBy(ct => ct.Id).ToList());
                foreach (var componentType in computerSpec.ComponentTypes)
                {
                    componentType.Components = _mapper.Map<List<ComputerSpecComponentViewModel>>(dbData.
                    Where(csc => csc.ComputerSpecId == computerSpec.Id && csc.Component.ComponentTypeId == componentType.Id).
                    Select(csc => csc).DistinctBy(c => c.Id).ToList());
                }

            }
            return computerSpecs;
        }

        public SaveComputerSpecResponse SaveComputerSpec(SaveComputerSpecRequest request)
        {
            var response = new SaveComputerSpecResponse();

            try
            {
                bool newRocord = false;
                var dbComputerSpec = _context.ComputerSpecs.FirstOrDefault(cs => cs.Id == request.ComputerSpec.Id);
                if(dbComputerSpec == null || (dbComputerSpec.IsSystem && !request.IsAdmin))
                {
                    dbComputerSpec = new ComputerSpec();
                    _context.ComputerSpecs.Attach(dbComputerSpec);
                    newRocord = true;
                }

                dbComputerSpec.IsSystem = request.IsAdmin;
                dbComputerSpec.UserId = request.UserId;
                dbComputerSpec.Name = request.ComputerSpec.Name;
                dbComputerSpec.Weight = "";
                _context.SaveChanges();

                var newComponents = request.ComputerSpec.ComponentTypes.SelectMany(ct => ct.Components);
                if (newRocord)
                {
                    foreach(var newComponent in newComponents)
                    {
                        _context.ComputerSpecComponents.Add(new ComputerSpecComponent() { ComponentId = newComponent.Id, ComputerSpecId = dbComputerSpec.Id, Count = 1 });
                    }
                    _context.SaveChanges();
                }
                else
                {
                    var dbComponents = _context.ComputerSpecComponents.Where(csc => csc.ComputerSpecId == dbComputerSpec.Id).ToList();
                    var dbComponentsToRemove = dbComponents.Where(csc => newComponents.Count(nc => nc.Id == csc.ComponentId) == 0);
                    foreach (var dbComponentToRemove in dbComponentsToRemove)
                    {
                        _context.Remove(dbComponentToRemove);
                    }
                    var dbComponentIds = dbComponents.Select(dbc => dbc.ComponentId);
                    var componentsToAdd = newComponents.Where(nc => !dbComponentIds.Contains(nc.Id));
                    foreach(var componentToAdd in componentsToAdd)
                    {
                        _context.ComputerSpecComponents.Add(new ComputerSpecComponent() { ComponentId = componentToAdd.Id, ComputerSpecId = dbComputerSpec.Id, Count = 1 });
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

        public DeleteComputerSpecResponse DeleteComputerSpec(DeleteComputerSpecRequest request)
        {
            var response = new DeleteComputerSpecResponse();

            try
            {
                var dbComputerSpec = _context.ComputerSpecs.FirstOrDefault(c => c.Id == request.ComputerSpecId);
                if (dbComputerSpec != null)
                {
                    _context.Remove(dbComputerSpec);
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
