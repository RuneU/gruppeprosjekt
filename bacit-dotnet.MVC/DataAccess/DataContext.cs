// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using bacit_dotnet.MVC.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace bacit_dotnet.MVC.DataAccess
{
    public class DataContext : IdentityDbContext<IdentityUser>
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().HasKey(x => x.Id);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<UserEntity> Users { get; set; }
    }
}
