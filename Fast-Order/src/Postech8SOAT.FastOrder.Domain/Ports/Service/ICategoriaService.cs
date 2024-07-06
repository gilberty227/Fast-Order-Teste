﻿using Postech8SOAT.FastOrder.Domain.Entities;

namespace Postech8SOAT.FastOrder.Domain.Ports.Service;
public interface ICategoriaService
{
    Task<Categoria> GetCategoriaByIdAsync(int id);
    Task<Categoria> GetCategoriaByNomeAsync(string nome);
    Task<Categoria> CreateCategoriaAsync(Categoria categoria);
    Task<Categoria> UpdateCategoriaAsync(Categoria categoria);
    Task DeleteCategoriaAsync(Categoria categoria);
    Task<IEnumerable<Categoria>> GetAllCategoriasAsync();
}
