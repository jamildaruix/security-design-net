using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Security.Design.Api.DTOs.AirfareDTO;

public record HeadersApp
{
    [FromHeader, Required]
    public Guid? CorrelationID { get; init; }
}
