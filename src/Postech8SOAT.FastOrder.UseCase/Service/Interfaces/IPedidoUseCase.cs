﻿using Postech8SOAT.FastOrder.Domain.Entities;

namespace Postech8SOAT.FastOrder.UseCases.Service.Interfaces;
public interface IPedidoUseCase
{
    Task<Pedido> GetPedidoByIdAsync(Guid id);
    Task<Pedido> CreatePedidoAsync(Pedido pedido);
    Task<Pedido> IniciarPreparo(Guid id);
    Task<Pedido> FinalizarPreparo(Guid id);
    Task<Pedido> Entregar(Guid id);
    Task<Pedido> Cancelar(Guid id);
    Task<List<Pedido>> GetAllPedidosAsync();
}