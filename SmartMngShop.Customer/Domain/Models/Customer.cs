﻿namespace SmartMngShop.Customer.Domain.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string RoleCustomer { get; set; }
        public List <DateCustomerWork> customerWork { get; set; }
    }
}
