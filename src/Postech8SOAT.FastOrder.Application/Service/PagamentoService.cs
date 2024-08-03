﻿using Postech8SOAT.FastOrder.Domain.Entities;
using Postech8SOAT.FastOrder.Domain.Entities.Enums;
using Postech8SOAT.FastOrder.Domain.Exceptions;
using Postech8SOAT.FastOrder.Domain.Ports.Repository;
using Postech8SOAT.FastOrder.Domain.Ports.Service;

namespace Postech8SOAT.FastOrder.Application.Service;

public class PagamentoService : IPagamentoService
{
    private readonly IPagamentoRepository _pagamentoRepository;
    private static readonly StatusPagamento[] _statusPagamentosPodemConfirmar = [StatusPagamento.Autorizado, StatusPagamento.Rejeitado, StatusPagamento.Cancelado];

    public PagamentoService(IPagamentoRepository pagamentoRepository)
    {
        _pagamentoRepository = pagamentoRepository;
    }

    public Task<Pagamento?> GetPagamentoAsync(Guid pagamentoId) => _pagamentoRepository.GetById(pagamentoId);

    public async Task<Pagamento> CreatePagamentoAsync(Pedido pedido, MetodoDePagamento metodoDePagamento)
    {
        var pagamento = new Pagamento(pedido, metodoDePagamento, pedido.ValorTotal, null);
        await _pagamentoRepository.AddAsync(pagamento);
        return pagamento;
    }

    public async Task<Pagamento> UpdatePagamentoAsync(Pagamento pagamento)
    {
        await _pagamentoRepository.UpdateAsync(pagamento);
        return pagamento;
    }

    public Task<List<Pagamento>> ListPagamentos() => _pagamentoRepository.FindAllAsync();

    public Task<List<Pagamento>> FindPagamentoByPedidoId(Guid pedidoId) => _pagamentoRepository.ListByPedidoId(pedidoId);

    public Task<Pagamento?> GetPagamentoByPedidoAsync(Guid pedidoId) => _pagamentoRepository.GetByPedidoId(pedidoId);

    public async Task ConfirmarPagamento(Guid pagamentoId, StatusPagamento status)
    {
        var pagamento = await _pagamentoRepository.GetById(pagamentoId);

        DomainExceptionValidation.When(pagamento is null, "Pagamento não localizado.");
        DomainExceptionValidation.When(_statusPagamentosPodemConfirmar.Contains(status) is false, $"{status} inválido para confirmar o pagamento");

        if(status == StatusPagamento.Cancelado)
        {
            pagamento!.CancelarPagamento();
            return;
        }

        pagamento!.FinalizarPagamento(status is StatusPagamento.Autorizado);
    }
}