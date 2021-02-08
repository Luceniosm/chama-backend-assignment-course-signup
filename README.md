Arquitetura:
|---CourseSignUp.Api
	|---CourseSignUp.Application	
	|---CourseSignUp.Domain	
	|---CourseSignUp.DTO	
	|---CourseSignUp.Infra.Data	
	|---CourseSignUp.Infra.Ioc	
	|---CourseSignUp.Messege	
|---CourseSignUp.Received - Azure Service Bus
|---CourseSignUp.Functions - Azure Function Timer Triger

Explicação das soluções:
 CourseSignUp.Received envia a massa de dados para CourseSignUp.Api e processa as regras  CourseSignUp.Api recebe uma massa de inscrições, enfileira no azure service bus usando endpoint "sign-up" 
 CourseSignUp.Functions gera relatorio diario da estatistica diariamente as 7 AM envia email para o responsavel cadastrado.
 
Teste:
	Criar uma banco de dados "CourseSignUp20210206" adicionar no appsettings.
	Criar uma Services bus no azure com o nome "coursequeue" e adicionar no appsettings na tag "AzureServiceBus".	
	Start CourseSignUp.Api e CourseSignUp.Received e descomentar "BombProcess". Obs: envia a massa de dados para services bus e consume fila aplicando as regras. 
	Start CourseSignUp.Api e CourseSignUp.Functions vai consumir a api e enviar email.

Tecnologias:
	Entity Framework
	Migrations
	Sql Serve
	DDD
	Azure Service Bus
	Azure Function

Melhorias:
	Serviço de envio de email, não implementado.
	filas por topicos, no caso cada curso tem a sua fila para pocessar.
	Teste unitarios, não implementado.	
	publicar no azure com app service.
