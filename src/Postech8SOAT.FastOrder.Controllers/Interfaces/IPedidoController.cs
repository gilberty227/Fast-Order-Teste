﻿using Postech8SOAT.FastOrder.Domain.Entities;
using Postech8SOAT.FastOrder.Domain.Entities.Enums;

namespace Postech8SOAT.FastOrder.Controllers.Interfaces;
public interface IPedidoController
{
    Task<Pedido> GetPedidoByIdAsync(Guid id);
    Task<Pedido> CreatePedidoAsync(Pedido pedido);
    Task<Pedido> IniciarPreparo(Guid id);
    Task<Pedido> FinalizarPreparo(Guid id);
    Task<Pedido> Entregar(Guid id);
    Task<Pedido> Cancelar(Guid id);
    Task<List<Pedido>> GetAllPedidosAsync();
    Task AtualizaStatus(StatusPedido status, Guid pedidoId);
}
