﻿using Company.Delivery.Core;
using Microsoft.EntityFrameworkCore;

namespace Company.Delivery.Database;

public class DeliveryDbContext : DbContext
{
    public DeliveryDbContext(DbContextOptions<DeliveryDbContext> options) : base(options)
    {
    }
    public DbSet<CargoItem> CargoItems { get; protected init; } = null!;

    public DbSet<Waybill> Waybills { get; protected init; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<CargoItem>();
        modelBuilder.Entity<Waybill>();
    }
}