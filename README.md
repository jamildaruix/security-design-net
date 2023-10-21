# security-design-net

# Apresentação

https://docs.google.com/presentation/d/14R8AZeC97lXQ1BRHEei22UHfkSjTMa0k/edit#slide=id.p1

# Objetivo

Registro de Passagens de Veículo por câmeras de Trânsito
Desenvolvimento
Api PassagemController com dois métodos
•	POST body (validar conteúdo no Fluent Validation)
o	CameraId
o	Placa

Dentro do Método acrescentar:
•	DataPassagem
•	Usuário
•	RemoteIpAddress HttpContext.Current.Request.UserHostAddress 
•	CorrelationId = HttpContext.Current.Request.Headers["CorrelationId"];
No primeiro insert -> pegar uma chave privada, concatenar com o json do comando e gerar um hash.
Criar uma tabela chamada event_passagem (id, comando, model, hash)
A partir do segundo comando pegar o hash do comando anterior consultando a tabela, e efetuar o novo registro.
Fazer uma rotina de auditoria passando a chave privada -> Consultar tabela, pegar json da primeira model, gerar hash e seguir comparando todas as linhas.


GET/{placa}
Demonstrar enriquecimento de request criando uma model com
•	Usuário
•	RemoteIpAddress HttpContext.Current.Request.UserHostAddress 
•	CorrelationId = HttpContext.Current.Request.Headers["CorrelationId"];

Gravar model também na tabela de eventos, demonstrando quem andou consultando as passagens

Este CorrelationId/RequestId é fácil de ser gerado no Kong
Mas usar o Kong na Poc acho que não é o caso neh
Ai a gente pode só explicar que simplificamos a Poc
E colocamos o RequestId no Postman


#EventSource

https://learn.microsoft.com/en-us/dotnet/core/diagnostics/eventsource-getting-started

https://microservices.io/patterns/data/event-sourcing.html

https://www.eventstore.com/event-sourcing

https://learn.microsoft.com/en-us/aspnet/core/tutorials/web-api-help-pages-using-swagger?view=aspnetcore-8.0&preserve-view=true#securing-swagger-ui-endpoints
