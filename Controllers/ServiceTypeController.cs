
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Task13_MovieAPI.DTO;

namespace backend.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ServiceTypeController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILogger<ServiceTypeController> _logger;
        private readonly IMapper _mapper;


        public ServiceTypeController(AppDbContext context, ILogger<ServiceTypeController> logger, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ServiceType>> GetAllAsync()
        {
            var serviceTypes = await _context.ServiceType.ToArrayAsync();
            if (serviceTypes == null) { NotFound("No Services found"); }
            return serviceTypes;
        }
        [HttpGet("{id}")]
        public async Task<ServiceType> GetByIdAsync(int id)
        {
            var serviceType = await _context.ServiceType
            .FirstAsync(serviceType => serviceType.Id == id);

            if (serviceType == null) { NotFound("No Services found"); }
            return serviceType;
        }
        // [HttpPost]
        // public async Task<ActionResult<Service>> PostService(ServiceDTO order)
        // {
        //     Service o = _mapper.Map<Service>(order);
        //     _context.Service.Add(o);
        //     await _context.SaveChangesAsync();
        //     return o;
        // }
        // [HttpDelete]
        // public async Task<ActionResult<Service>> DeleteService(int id)
        // {
        //     var service = await _context.Service.FindAsync(id);
        //     _context.Service.Remove(service);
        //     if (service == null) { return NotFound(); }
        //     await _context.SaveChangesAsync();
        //     return service;
        // }
    }
}
