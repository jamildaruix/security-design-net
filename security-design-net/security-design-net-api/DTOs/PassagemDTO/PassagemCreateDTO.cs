using MediatR;

namespace Security.Design.Net.Api.DTOs.PassagemDTO;

public record PassagemCreateDTO(string origem, string destino, decimal valor, DateTime validade) : IRequest<bool>;
