using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using EFGameShopDatabase.Entities;
using System.Collections.Generic;
using EFGameShopDatabase.Models;

namespace EFGameShopDatabase
{
    public partial class GameShopDatabase : DbContext
    {
        public GameShopDatabase() : base("name=DbConnectionString")
        {
        }

        public virtual DbSet<ItemDb> Items { get; set; }
        public virtual DbSet<OrderEntries> OrderEntries { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemDb>()
                .Property(e => e.price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ItemDb>()
                .HasMany(e => e.OrderEntries)
                .WithRequired(e => e.Items)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Orders>()
                .HasMany(e => e.OrderEntries)
                .WithRequired(e => e.Orders)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Users)
                .WillCascadeOnDelete(false);            
        }        
    }
}
