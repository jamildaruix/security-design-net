using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Security.Design.Api.DTOs.AirfareDTO;

namespace Security.Design.Api.Controllers
{
    public abstract class ControllerAbstract : ControllerBase
    {
        private protected readonly IMediator mediator;

        protected ControllerAbstract(IMediator mediator)
        {
            this.mediator = mediator;
        }
    }
}
