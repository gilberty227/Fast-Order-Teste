﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Postech8SOAT.FastOrder.Domain.Ports.Repository;
using Postech8SOAT.FastOrder.Infra.Data.Context;
using Postech8SOAT.FastOrder.Infra.Data.Repositories;

namespace Postech8SOAT.FastOrder.Infra.IOC;
public static class FastOrderRegisterDependencies
{

    public static void ConfigureDI(this IServiceCollection services, IConfiguration configuration)
    {
        //Registrar no container nativo de injeção de dependências.
       
        services.AddDbContext<FastOrderContext>(options =>
                   options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly(typeof(FastOrderContext).Assembly.FullName)));

        services.AddScoped<IClienteRepository,ClienteRepository>();
        services.AddScoped<ICategoriaRepository,CategoriaRepository>();
        services.AddScoped<IProdutoRepository,ProdutoRepository>();
        services.AddScoped<IPedidoRepository,PedidoRepository>();            
    }
}