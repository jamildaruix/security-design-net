using MediatR;

namespace Security.Design.Net.Api.DTOs.AirfareDTO;

public record AirfareCreateDTO(string Origem, string Destino, decimal Valor, DateTime Validade) : IRequest<bool>;
