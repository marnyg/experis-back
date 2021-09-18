
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
    public class AddressController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILogger<AddressController> _logger;
        private readonly IMapper _mapper;


        public AddressController(AppDbContext context, ILogger<AddressController> logger, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<IEnumerable<Address>> GetAllAsync()
        {
            var address = await _context.Address.Select(address => address).ToArrayAsync();
            if (address == null) { NotFound("No Addresss found"); }
            return address;
        }
        [HttpGet("{id}")]
        public async Task<Address> GetByIdAsync(int id)
        {
            var address= await _context.Address
            .FirstAsync(order => order.Id == id);

            if (address == null) { NotFound("No categories found"); }
            return address;
        }
        // [HttpPost]
        // public async Task<ActionResult<Address>> PostAddress(AddressDTO order)
        // {
        //     Address o = _mapper.Map<Address>(order);
        //     _context.Address.Add(o);
        //     await _context.SaveChangesAsync();
        //     return o;
        // }
        [HttpDelete]
        public async Task<ActionResult<Address>> DeleteAddress(int id)
        {
            var address = await _context.Address.FindAsync(id);
            _context.Address.Remove(address);
            if (address == null) { return NotFound(); }
            await _context.SaveChangesAsync();
            return address;
        }
    }
}
