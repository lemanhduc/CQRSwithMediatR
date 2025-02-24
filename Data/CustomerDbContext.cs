﻿using CQRSwithMediatR.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRSwithMediatR.Data
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
        { }

        public DbSet<PersonalDetails> PersonalDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonalDetails>(p => p.HasKey(_ => _.Id));
        }
    }
}
