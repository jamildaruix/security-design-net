namespace Security.Design.Api.DTOs.AirfareDTO;

public record AirFareCreateResponse(bool Status,  List<Errors> Errors);
public record AirFareUpdateResponse(bool Status, List<Errors> Errors);
