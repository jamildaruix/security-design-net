using MediatR;

namespace Security.Design.Api.DTOs.AirfareDTO;

public record AirTicketPriceUpdateDTO(decimal Valor, DateTime Validade) : IRequest<AirFareUpdateResponse>
{
    internal int Id { get; set; }
    internal HeadersApp HeadersApp { get; set; }

};
