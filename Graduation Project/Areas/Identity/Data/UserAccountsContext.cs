﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraduationProject.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GraduationProject.Data
{
    public class UserAccountsContext : IdentityDbContext<User>
    {
        public UserAccountsContext(DbContextOptions<UserAccountsContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>()
             .HasIndex(u => u.Email)
              .IsUnique();
            /*
            builder.Entity<User>()
                .HasOne(u => u.UserEntity)
                .WithOne(u => u.UserIdentity)
                .HasForeignKey<User>(u => u.Id); 
        */
        }
    }
}
