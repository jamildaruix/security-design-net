using MediatR;

namespace Security.Design.Net.Api.DTOs.AirfareDTO;

public record AirTicketPriceUpdateDTO(decimal Valor, DateTime Validade) : IRequest<bool>
{
    protected internal int Id { get; set; }
};
