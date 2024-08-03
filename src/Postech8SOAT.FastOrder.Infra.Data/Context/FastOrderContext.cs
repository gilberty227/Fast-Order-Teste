﻿using Microsoft.EntityFrameworkCore;
using Postech8SOAT.FastOrder.Domain.Entities;

namespace Postech8SOAT.FastOrder.Infra.Data.Context;
public class FastOrderContext : DbContext
{
    public FastOrderContext()
    {

    }
    public FastOrderContext(DbContextOptions<FastOrderContext> options) : base(options)
    {
    }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<ItemDoPedido> ItensDoPedido { get; set; }
    public DbSet<Pagamento> Pagamentos { get; set; }

    //private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=FastOrderDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

    private string connectionString = "Server=localhost\\sqlserver-fc,11433;Database=FastOrderDB;User Id=sa;Password=tech#2024;Encrypt=false;TrustServerCertificate=true;MultipleActiveResultSets=true;";
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        if (optionsBuilder.IsConfigured)
        {
            return;
        }
        optionsBuilder
            .UseSqlServer(connectionString);

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(FastOrderContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
