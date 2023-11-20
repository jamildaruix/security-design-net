using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Security.Design.Api.DTOs.AirfareDTO;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        public async Task<IResult> Post([FromHeader] HeadersApp headersApp, [FromBody] AirfareCreateDTO dto, CancellationToken cancellationToken)
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

        [HttpPut]
        public async Task<IResult> Put([FromHeader] HeadersApp headersApp, [FromRoute] int id, [FromBody] AirTicketPriceUpdateDTO dto, CancellationToken cancellationToken)
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
    }
}
