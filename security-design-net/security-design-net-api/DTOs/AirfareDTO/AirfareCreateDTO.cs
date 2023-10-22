using MediatR;

namespace Security.Design.Net.Api.DTOs.AirfareDTO;

public record AirfareCreateDTO(string origem, string destino, decimal valor, DateTime validade) : IRequest<bool>;
