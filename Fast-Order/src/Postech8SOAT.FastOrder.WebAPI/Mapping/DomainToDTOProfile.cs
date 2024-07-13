﻿using AutoMapper;
using Postech8SOAT.FastOrder.Domain.Entities;
using Postech8SOAT.FastOrder.Domain.ValueObjects;
using Postech8SOAT.FastOrder.WebAPI.DTOs;

namespace Postech8SOAT.FastOrder.WebAPI.Mapping;

public class DomainToDTOProfile : Profile
{
    public DomainToDTOProfile()
    {
        CreateMap<Produto, ProdutoDTO>()
            .ReverseMap();

        CreateMap<Cliente, ClienteDTO>()
            .ForMember(c => c.Email, opt => opt.MapFrom(c => c.Email.Address))
            .ForMember(c => c.Cpf, opt => opt.MapFrom(c => c.Cpf.Value))
            .AfterMap((c, dto) => dto.SetId(c.Id))
            .ReverseMap()
            .ForMember(c => c.Email, opt => opt.MapFrom(c => new EmailAddress(c.Email)))
            .ForMember(c => c.Cpf, opt => opt.MapFrom(c => new Cpf(c.Cpf)));

        CreateMap<Categoria, CategoriaDTO>()
            .ReverseMap();

        CreateMap<Pedido, PedidoDTO>()
            .ReverseMap();
    }
}
