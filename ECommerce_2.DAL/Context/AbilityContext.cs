using ECommerce_2.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_2.DAL.Context;

public class AbilityContext: IdentityDbContext<User2>
{
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<Cart> Carts => Set<Cart>();
    public DbSet<OrderProduct> OrderProducts => Set<OrderProduct>();
    public DbSet<CartProduct> CartProducts => Set<CartProduct>();

    public AbilityContext(DbContextOptions<AbilityContext> options)
     : base(options)
    {

    }         // This constructor forces me to enter my Connection string to use my Context in any connection string (SQl ,sql server,... to be flexable
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<OrderProduct>()
        .HasOne(e => e.Product)
        .WithMany(product => product.OrderProducts)
        .HasForeignKey(item => item.ProductId);

        builder.Entity<CartProduct>()
        .HasOne(e => e.Product)
        .WithMany(product => product.CartProducts)
        .HasForeignKey(item => item.ProductId);

        builder.Entity<OrderProduct>()
       .HasOne(e => e.Order)
        .WithMany(order => order.OrderItems)
        .HasForeignKey(item => item.OrderId);

        builder.Entity<CartProduct>()
        .HasOne(item => item.Cart)
        .WithMany(cart => cart.CartProducts)
        .HasForeignKey(item => item.CartId);

        builder.Entity<Cart>()
            .HasOne(item => item.User2)
            .WithOne(cart => cart.Cart);

        builder.Entity<Order>()
       .HasOne(item => item.User2)
       .WithMany(order => order.Orders)
       .HasForeignKey(r => r.User2Id);

        builder.Entity<Product>()
       .HasOne(item => item.Category)
       .WithMany(e => e.Products)
       .HasForeignKey(r => r.CategoryId);

        #region Seeding  products

        var products = new List<Product>
        {
          new Product {ProductId= 1,Name= "headphone",Description ="good product ",Color="red",CategoryId=1,Price=3000 },
          new Product {ProductId= 3,Name= "phone",Description ="good product oppo ",Color="red",CategoryId=3,Price=40000},
          new Product {ProductId= 2,Name= "Iphone",Description ="good product apple ",Color="red",CategoryId=2,Price=90000}
        };
        #endregion
        #region Seeding Categories
        var Categories = new List<Category>
            {
                new Category{CategoryId=1,CategoryName="electronic"},
                new Category{CategoryId=2,CategoryName="ios"},
                new Category{CategoryId=3,CategoryName="android"}

            };
        #endregion

        builder.Entity<Product>().HasData(products);
        builder.Entity<Category>().HasData(Categories);

    }

}
