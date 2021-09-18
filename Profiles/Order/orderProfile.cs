using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using backend.Models;
using Task13_MovieAPI.DTO;

namespace Task13_MovieAPI.Profiles.Characters
{
    //Profile for automapper to map between Character and its DTO
    public class OrderProfile: Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderDTO, Order>();
            CreateMap<Order, OrderDTO>();
        }

    }
}
