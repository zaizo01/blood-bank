﻿using Microsoft.EntityFrameworkCore;
using SellPoint.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellPoint.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Entidades> Entidades { get; set; }
        public DbSet<Donor> Donors { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<BloodDonations> BloodDonations { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }

}