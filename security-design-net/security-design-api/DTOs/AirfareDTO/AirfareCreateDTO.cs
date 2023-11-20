using FluentValidation.Results;
using MediatR;

namespace Security.Design.Api.DTOs.AirfareDTO;

public record AirfareCreateDTO(string Origem, string Destino, decimal Valor, DateTime Validade) : IRequest<AirFareCreateResponse>
{
    internal HeadersApp HeadersApp { get; set; }
};
