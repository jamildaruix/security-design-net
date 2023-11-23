using MediatR;
using Microsoft.AspNetCore.Mvc;
using Security.Design.Api.DTOs.AirfareDTO;

namespace Security.Design.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirfareController : ControllerAbstract
    {
        public AirfareController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<Errors>))]
        public async Task<IResult> Post(HeadersApp headersApp, [FromBody] AirfareCreateDTO dto, CancellationToken cancellationToken)
        {
            try
            {
                dto.HeadersApp = headersApp;
                var returns = await mediator.Send(dto, cancellationToken);

                if (returns.Status == false)
                {
                    return TypedResults.BadRequest(returns.Errors);
                }


                return TypedResults.Ok(returns.Status);

            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(ex);
            }

        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<Errors>))]
        public async Task<IResult> Put(HeadersApp headersApp, [FromRoute] int id, [FromBody] AirTicketPriceUpdateDTO dto, CancellationToken cancellationToken)
        {
            try
            {
                dto.HeadersApp = headersApp;
                dto.Id = id;
                var returns = await mediator.Send(dto, cancellationToken);

                if (returns.Status == false)
                {
                    return TypedResults.BadRequest(returns.Errors);
                }

                return TypedResults.Ok(returns.Status);

            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(ex);
            }
        }
    }
}
