using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TribeAccelerator.Models;

namespace TribeAccelerator.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Feedback> Feedbacks { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}
