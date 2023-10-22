using MediatR;
using Microsoft.AspNetCore.Mvc;
using Security.Design.Net.Api.DTOs.AirfareDTO;

namespace Security.Design.Net.Api.Routes
{
    public static class AirfareRoute
    {
        public static void MapAirfareEndpoint(this WebApplication app)
        {
            var airfareApi = app.MapGroup("/airfare");

            airfareApi.MapPost("/", CreateAsync);
            airfareApi.MapPut("/{id}", AirTicketPriceUpdateAsync);
        }

        private static  async Task<IResult> CreateAsync([FromBody] AirfareCreateDTO dto, CancellationToken cancellationToken, IMediator mediator) //, IHttpContextAccessor httpContextAccessor)
        {
            try
            {
                //    var userId = HttpContextUtility.GetUserId(httpContextAccessor);
                //    var user = await mediator.Send(new GetUserProfileQuery(userId));

                var returns = await mediator.Send(dto, cancellationToken);

                return TypedResults.Ok(returns);

            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(ex); 
            }
        }

        private static async Task<IResult> AirTicketPriceUpdateAsync([FromRoute] int id, [FromBody] AirTicketPriceUpdateDTO dto, CancellationToken cancellationToken, IMediator mediator) //, IHttpContextAccessor httpContextAccessor)
        {
            try
            {
                dto.Id = id;
                //    var userId = HttpContextUtility.GetUserId(httpContextAccessor);
                //    var user = await mediator.Send(new GetUserProfileQuery(userId));

                //var returns = await mediator.Send(dto, cancellationToken);

                return TypedResults.Ok();

            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(ex);
            }
        }

    }
}
