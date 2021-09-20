
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using backend.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Task13_MovieAPI.DTO;

namespace backend.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
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
        public async Task<Object> GetByIdAsync(int id)
        {
            var order = await _context.Order
            .Select(order => new
            {
                order.Id,
                order.OrderComment,
                order.Customer,
                order.FromAddress,
                order.ToAddress,
                Services = order.Services.ToList()
            })
            // .Include(order => order.ToAddress)
            // .Include(order => order.FromAddress)
            .FirstAsync(order => order.Id == id);

            if (order == null) { NotFound("No categories found"); }
            return order;
        }
        [HttpGet("by-customer-id/{id}")]
        public async Task<IEnumerable<object>> GetByCustomerIdAsync(int id)
        {
            var order = await _context.Order
            .Include(o => o.Services)
            .Select(order => new
            {
                order.Id,
                order.OrderComment,
                order.Customer,
                order.FromAddress,
                order.ToAddress,
                Services = order.Services.Select(s =>
                new { s.Date, s.Id, s.ServiceType, s.ServiceTypeId })
            })
            .Where(order => order.Customer.Id == id)
            .ToArrayAsync();

            if (order == null)
            {
                NotFound("No categories found");
            }
            return order;
        }
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(OrderDTO orderDTO)
        {
            Order order = _mapper.Map<Order>(orderDTO);
            _context.Order.Add(order);
            await _context.SaveChangesAsync();

            orderDTO.ServiceIds.ToList().ForEach(s =>
            {
                Service newService = new Service()
                {
                    OrderId = order.Id,
                    ServiceTypeId = s,
                    Date = orderDTO.Date,
                };
                _context.Service.Add(newService);
            });
            await _context.SaveChangesAsync();
            return order;
        }
        [HttpPut]
        public async Task<ActionResult<Order>> PutOrder(OrderDTO orderDTO)
        {
            Order existingOrder = await _context.Order.Where(o => o.Id == orderDTO.Id).FirstOrDefaultAsync();
            var orderServices = await _context.Service
            .Where(s => s.OrderId == orderDTO.Id)
            .ToListAsync();

            orderServices.ForEach(s => _context.Remove(s));
            if (existingOrder != null)
            {
                existingOrder.CustomerId = orderDTO.CustomerId;
                existingOrder.FromAddressId = orderDTO.FromAddressId;
                existingOrder.ToAddressId = orderDTO.ToAddressId;
                existingOrder.OrderComment = orderDTO.OrderComment;

                orderDTO.ServiceIds.ToList().ForEach(s =>
                {
                    Service newService = new Service()
                    {
                        OrderId = orderDTO.Id,
                        ServiceTypeId = s,
                        Date = orderDTO.Date,
                    };
                    _context.Service.Add(newService);
                });
                await _context.SaveChangesAsync();
            }
            else
            {
                return NotFound();
            }

            return Ok(existingOrder);
        }
        [HttpDelete("{id}")]
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
