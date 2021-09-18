
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
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILogger<OrderController> _logger;
        private readonly IMapper _mapper;


        public OrderController(AppDbContext context, ILogger<OrderController> logger, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            var orders = await _context.Order.Select(customer => customer).ToArrayAsync();
            if (orders == null) { NotFound("No Orders found"); }
            return orders;
        }
        [HttpGet("{id}")]
        public async Task<Order> GetByIdAsync(int id)
        {
            var order = await _context.Order
            .Include(order => order.ToAddress)
            .Include(order => order.FromAddress)
            .FirstAsync(order => order.Id == id);

            if (order == null) { NotFound("No categories found"); }
            return order;
        }
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(OrderDTO orderDTO)
        {
            Order order = _mapper.Map<Order>(orderDTO);
            _context.Order.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }
        [HttpDelete]
        public async Task<ActionResult<Order>> DeleteOrder(int id)
        {
            var order = await _context.Order.FindAsync(id);
            _context.Order.Remove(order);
            if (order == null) { return NotFound(); }
            await _context.SaveChangesAsync();
            return order;
        }
    }
}
