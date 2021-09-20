
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
    public class ServiceController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILogger<ServiceController> _logger;
        private readonly IMapper _mapper;


        public ServiceController(AppDbContext context, ILogger<ServiceController> logger, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<Service>> GetAllAsync()
        {
            var orders = await _context.Service
            .Include(service => service.ServiceType)
            .ToArrayAsync();
            if (orders == null) { NotFound("No Services found"); }
            return orders;
        }
        [HttpGet("{id}")]
        public async Task<Service> GetByIdAsync(int id)
        {
            var order = await _context.Service
            .Include(service => service.ServiceType)
            .FirstAsync(service => service.Id == id);

            if (order == null) { NotFound("No Services found"); }
            return order;
        }
        // [HttpPost]
        // public async Task<ActionResult<Service>> PostService(ServiceDTO order)
        // {
        //     Service o = _mapper.Map<Service>(order);
        //     _context.Service.Add(o);
        //     await _context.SaveChangesAsync();
        //     return o;
        // }
        [HttpDelete]
        public async Task<ActionResult<Service>> DeleteService(int id)
        {
            var service = await _context.Service.FindAsync(id);
            _context.Service.Remove(service);
            if (service == null) { return NotFound(); }
            await _context.SaveChangesAsync();
            return service;
        }
    }
}
