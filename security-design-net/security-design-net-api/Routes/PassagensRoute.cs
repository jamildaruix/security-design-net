using MediatR;
using Security.Design.Net.Api.DTOs.PassagemDTO;

namespace Security.Design.Net.Api.Routes
{
    public static class PassagensRoute
    {
        public static void MapPassagensEndpoint(this WebApplication app)
        {
            var passagensApi = app.MapGroup("/passagens");

            passagensApi.MapPost("/", InserirAsync);
        }

        private static  async Task<IResult> InserirAsync(PassagemCreateDTO dto, CancellationToken cancellationToken, IMediator mediator) //, IHttpContextAccessor httpContextAccessor)
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
    }
}
