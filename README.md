Arquitetura:<br>
|---CourseSignUp.Api<br>
	|---CourseSignUp.Application<br>
	|---CourseSignUp.Domain<br>
	|---CourseSignUp.DTO<br>
	|---CourseSignUp.Infra.Data<br>	
	|---CourseSignUp.Infra.Ioc<br>
	|---CourseSignUp.Messege<br>
|---CourseSignUp.Received - Azure Service Bus<br>
|---CourseSignUp.Functions - Azure Function Timer Triger<br>

Explicação das soluções:<br>
 CourseSignUp.Received envia a massa de dados para CourseSignUp.Api e processa as regras  CourseSignUp.Api recebe uma massa de inscrições, enfileira no azure service bus usando endpoint "sign-up" 
 CourseSignUp.Functions gera relatorio diario da estatistica diariamente as 7 AM envia email para o responsavel cadastrado.
 
Teste:<br>
	Criar uma banco de dados "CourseSignUp20210206" adicionar no appsettings.<br>
	Criar uma Services bus no azure com o nome "coursequeue" e adicionar no appsettings na tag "AzureServiceBus".<br>
	Start CourseSignUp.Api e CourseSignUp.Received e descomentar "BombProcess". Obs: envia a massa de dados para services bus e consume fila aplicando as regras.<br>
	Start CourseSignUp.Api e CourseSignUp.Functions vai consumir a api e enviar email.<br>

Tecnologias:<br>
	Entity Framework<br>
	Migrations<br>
	Sql Serve<br>
	DDD<br>
	Azure Service Bus<br>
	Azure Function<br>

Melhorias:<br>
	Serviço de envio de email, não implementado.<br>
	filas por topicos, no caso cada curso tem a sua fila para pocessar.<br>
	Teste unitarios, não implementado.<br>
	publicar no azure com app service.<br>
