using MediatR;

namespace Security.Design.Net.Api.DTOs.AirfareDTO;

public record MudarValorUpdateDTO(decimal valor, DateTime validade) : IRequest<bool>;
