# Banco

### Tecnologias Utilizadas

- .NET 5
- SqlServer
- Docker

### Executar Projeto

Para executar todo projeto foi criado um docker-compose, digite o seguinte comando na raiz do repositório:

```console
$ docker-compose up
```

Este comando irá compilar e executar o Projeto via docker.

### Conceitos
* Notification Pattern
* Mediator Pattern
* Domain-Driven Design
* Repository Pattern
* Solid

### Uso
Utilizar a rota de criação de pessoa para criar uma nova pessoa, está rota é para autocriação de pessoas, a partir disso é retornado um token para adicionar nas requisições para rotas privadas.

Para Acessar a documentação swagger da API basta acessar o seguinte endereço `SEU_IP:5000/swagger`. Ou a documentação insomnia com o seguinte endereço `SEU_IP:3000`