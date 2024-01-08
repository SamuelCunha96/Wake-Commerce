# Projeto Wake Commerce

Este repositório contém uma solução para as operações de CRUD de produtos, construída como parte de um teste técnico. A solução está estruturada em sete projetos:

1. **Wake.Commerce.Api**: Este projeto contém a API REST que expõe os endpoints para o CRUD de produtos.
2. **Wake.Commerce.Application**: Este projeto contém a lógica de negócios da aplicação. Ele implementa o padrão CQRS e contém comandos, consultas e validadores. O arquivo ApplicationServiceRegistration.cs mostra como os serviços são registrados e configurados, incluindo o MediatR para o CQRS e o AutoMapper para mapeamento de objetos.
3. **Wake.Commerce.Domain**: Este projeto define as entidades do domínio.
4. **Wake.Commerce.Infrastructure**: Este projeto lida com a persistência de dados, incluindo repositórios e configurações do Entity Framework.
5. **Wake.Commerce.Shared**: Este projeto contém código compartilhado, como DTOs (Data Transfer Objects) e extensões.
6. **Wake.Commerce.IntegrationTests**: Este projeto contém testes de integração para a API. Ele verifica se os endpoints da API estão funcionando conforme esperado.
7. **Wake.Commerce.UnitTests**: Este projeto contém testes unitários para as lógicas de negócios e validadores de entrada de dados e regras de negócios. Ele testa componentes individuais da aplicação de forma isolada.

## Principais Recursos
- **Operações CRUD**: Funcionalidades para gerenciamento de produtos, incluindo criar, ler, atualizar e deletar.
- **Banco de Dados em Memória**: Utiliza um banco de dados em memória para manipulação eficiente de dados e propósitos de teste.
- **Entity Framework**: Utiliza o Entity Framework para ORM (Mapeamento Objeto-Relacional), simplificando a manipulação e consulta de dados.
- **Padrão CQRS**: Implementa o padrão Command Query Responsibility Segregation (CQRS) para separar operações de leitura e escrita, melhorando a escalabilidade e manutenibilidade.


## Requisitos

- SDK do .NET 6


## Executando a API
1. **Clone o repositório**:
   ```
   git clone https://github.com/SamuelCunha96/Wake-Commerce.git
   ```
2. **Navegue até o diretório do projeto da API**.
3. **Execute a API**:
   ```
   dotnet run
   ```


## Executando Testes Unitários
1. **Navegue até o diretório do projeto de testes unitários**.
2. **Execute os testes**:
   ```
   dotnet test
   ```


## Executando Testes de Integração
1. **Navegue até o diretório do projeto de testes de integração**.
2. **Execute os testes**:
   ```
   dotnet test
   ```
