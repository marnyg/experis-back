using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }
        public DbSet<Address> Address { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Service> Service { get; set; }
        public DbSet<ServiceType> ServiceType { get; set; }
        public string DbPath { get; private set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            SeedData(builder);
        }

        public static void SeedData(ModelBuilder builder)
        {
            var address1 = new Address { Id = 1, AddressText = "Tollefsengrenda 475, 0946 Mandal" };
            var address2 = new Address { Id = 2, AddressText = "Søndreskrenten 33B, 4326 Stathelle" };
            var address3 = new Address { Id = 3, AddressText = "Gamlestubben 8288, 0899 Moelv" };
            var address4 = new Address { Id = 4, AddressText = "Nedrehaugen 4855, 1093 Kirkenes" };
            var address5 = new Address { Id = 5, AddressText = "Lunde veien 3717, 0088 Hønefoss " };
            var address6 = new Address { Id = 6, AddressText = "Gamleåsen 40, 8565 Namsos " };

            var serviceType1 = new ServiceType { Id = 1, ServiceTypeName = "Moving", ServiceTypeDescription = "Moving your belongings to your new address" };
            var serviceType2 = new ServiceType { Id = 2, ServiceTypeName = "Packing", ServiceTypeDescription = "Packing up your belongings" };
            var serviceType3 = new ServiceType { Id = 3, ServiceTypeName = "Cleaning", ServiceTypeDescription = "Cleaning your old home" };

            var customer1 = new Customer { Id = 1, FirstName = "Ola", LastName = "Nordman", Email = "asdf@b.com", CurrentAddressId = address1.Id };
            var customer2 = new Customer { Id = 2, FirstName = "Svein", LastName = "Lund", Email = "gggs@gda.com", CurrentAddressId = address2.Id };
            var customer3 = new Customer { Id = 3, FirstName = "knut", LastName = "Sørlig", Email = "kasdf@g.com", CurrentAddressId = address2.Id };

            var order1 = new Order { Id = 1, CustomerId = customer1.Id, FromAddressId = address1.Id, ToAddressId = address2.Id, OrderComment = "ikke kom før kl 10", };
            var order2 = new Order { Id = 2, CustomerId = customer2.Id, FromAddressId = address3.Id, ToAddressId = address3.Id, OrderComment = "kom etter kl 15" };
            var order3 = new Order { Id = 3, CustomerId = customer3.Id, FromAddressId = address4.Id, ToAddressId = address2.Id, OrderComment = "kom etter kl 15" };

            var service1 = new Service { Id = 1, OrderId = order1.Id, ServiceTypeId = serviceType1.Id, Date = new DateTime(2021, 10, 1), };
            var service2 = new Service { Id = 2, OrderId = order1.Id, ServiceTypeId = serviceType2.Id, Date = new DateTime(2021, 10, 1), };
            var service3 = new Service { Id = 3, OrderId = order1.Id, ServiceTypeId = serviceType3.Id, Date = new DateTime(2021, 10, 1), };


            builder.Entity<Address>().HasData(address1, address2, address3, address4, address5, address6);
            builder.Entity<ServiceType>().HasData(serviceType1, serviceType2, serviceType3);
            builder.Entity<Service>().HasData(service1, service2, service3);
            builder.Entity<Customer>().HasData(customer1, customer2, customer3);
            builder.Entity<Order>().HasData(order1, order2, order3);
        }
    }

}
