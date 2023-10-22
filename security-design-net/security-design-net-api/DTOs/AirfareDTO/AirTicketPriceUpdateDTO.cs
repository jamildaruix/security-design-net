using MediatR;

namespace Security.Design.Net.Api.DTOs.AirfareDTO;

public record AirTicketPriceUpdateDTO(decimal valor, DateTime validade) : IRequest<bool>
{
    protected internal int Id { get; set; }
};
