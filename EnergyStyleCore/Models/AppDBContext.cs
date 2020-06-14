using EnergyStyleCore.Models.Classes;
using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace EnergyStyleCore.Models
{
    public class AppDBContext : DbContext, IDataProtectionKeyContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Characteristic> Characteristics { get; set; }
        public DbSet<DataProtectionKey> DataProtectionKeys { get; set; }

        public DbSet<Service> Service { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new ServiceConfiguration());
        }

        public class ProductConfiguration : IEntityTypeConfiguration<Product>
        {
            public void Configure(EntityTypeBuilder<Product> builder)
            {
                // This Converter will perform the conversion to and from Json to the desired type
                builder.Property(e => e.Images).HasConversion(
                    v => JsonConvert.SerializeObject(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                    v => JsonConvert.DeserializeObject<List<string>>(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
            }
        }

        public class ServiceConfiguration : IEntityTypeConfiguration<Service>
        {
            public void Configure(EntityTypeBuilder<Service> builder)
            {
                // This Converter will perform the conversion to and from Json to the desired type
                builder.Property(e => e.Images).HasConversion(
                    v => JsonConvert.SerializeObject(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                    v => JsonConvert.DeserializeObject<List<string>>(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
            }
        }

        //public AppDBContext()
        //{ }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        IConfigurationRoot configuration = new ConfigurationBuilder()

        //        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        //        .AddJsonFile("appsettings.json")
        //        .Build();
        //        optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        //    }
        //}

    }
}
