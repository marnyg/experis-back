
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
    public class CustomerController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILogger<CustomerController> _logger;
        private readonly IMapper _mapper;


        public CustomerController(AppDbContext context, ILogger<CustomerController> logger, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            var customer = await _context.Customer.Select(customer => customer).ToArrayAsync();
            if (customer == null) { NotFound("No Customers found"); }
            return customer;
        }
        [HttpGet("{id}")]
        public async Task<Customer> GetByIdAsync(int id)
        {
            var customer = await _context.Customer
            .Include(customer => customer.CurrentAddress)
            .FirstAsync(customer => customer.Id == id);

            if (customer == null) { NotFound("No customer found"); }
            return customer;
        }
        // [HttpPost]
        // public async Task<ActionResult<Customer>> PostCustomer(CustomerDTO order)
        // {
        //     Customer o = _mapper.Map<Customer>(order);
        //     _context.Customer.Add(o);
        //     await _context.SaveChangesAsync();
        //     return o;
        // }
        [HttpDelete]
        public async Task<ActionResult<Customer>> DeleteCustomer(int id)
        {
            var customer = await _context.Customer.FindAsync(id);
            _context.Customer.Remove(customer);
            if (customer == null) { return NotFound(); }
            await _context.SaveChangesAsync();
            return customer;
        }
    }
}
