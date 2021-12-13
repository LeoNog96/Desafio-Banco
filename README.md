# Banco
WebApi do projeto banco.
### Tecnologias Utilizadas

- .NET 5
- EntityFrameworkCore
- SqlServer
- Docker
### Executar Projeto

Para executar todo projeto foi criado um docker-compose, digite o seguinte comando na raiz do repositório:

```console
$ docker-compose up
```

Este comando irá compilar e executar o Projeto via docker. Ao inicializar o serviço da api automaticamente será criado as tabelas a partir das migrations do ef core.

### Conceitos
* Notification Pattern
* Mediator Pattern
* Domain-Driven Design
* Repository Pattern
* Solid


### Uso api
Para Acessar a documentação swagger da API basta acessar o seguinte endereço `SEU_IP:5000/swagger`:
 ![Swagger](https://github.com/LeoNog96/Desafio-Banco/blob/master/img/Swagger.PNG)


Ou a documentação insomnia com o seguinte endereço `SEU_IP:3000`:
 ![Insomniadoc](https://github.com/LeoNog96/Desafio-Banco/blob/master/img/Insomniadoc.PNG)
