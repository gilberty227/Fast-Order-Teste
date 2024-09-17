﻿using Postech8SOAT.FastOrder.Domain.Entities;
using Postech8SOAT.FastOrder.Domain.ValueObjects;

namespace Postech8SOAT.FastOrder.Application.Gateways;

public interface IClienteGateway
{
    Task<Cliente?> GetClienteByCpfAsync(Cpf cpf);
}