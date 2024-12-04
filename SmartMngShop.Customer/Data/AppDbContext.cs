﻿using Microsoft.EntityFrameworkCore;
using SmartMngShop.Customer.Domain.Models;

namespace SmartMngShop.Customer.Data
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<CustomerUser> customers { get; set; }
        public DbSet<DateCustomerWork> works { get; set; }
    }
}
