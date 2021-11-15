# GrupoAEducacaoChallenge
Desafio Para vaga de Desenvolvedor FullStack do Grupo A Educacao

## Inicialização do projeto
  Para que o projeto seja executado corretamente, é necessário alterar a string de conexão (Connection String) chamada "DefaultMysqlConnection" dentro do arquivo 
  appsettings.json  (GrupoAEducaoChallenge.WebAPI) e definir as configurações de conexão com o servidor mysql próprio.
  
  Devido ao entity framework ter sido configurado para a criação do banco de dados por meio do code-first, é necessário que seja dado comando "update-database" no console, 
  para que o banco seja criado corretamente.
  
---------------------------------------------------------------------------------------
## Arquitetura da solução - Back End
  No back end, foi utilizado conceitos da Clean Architecture e DDD (Domain Driven Desing) com o intuito de fazer o projeto escalonável, desacoplado e coeso.
  Foram criados criados 6 projetos no total (e mais uma subcamada representando testes unitários). Cada projeto representa uma camada específica e isolada da solução como um todo

- GrupoAEducaoChallenge.Domain: 
  Modelo de domínio. Responsável por conter entidades do negócio e interfaces responsáveis pelo repositório
  
- GrupoAEducaoChallenge.Application: 
  Camada de aplicação é responsável por conter regras de serviços, mapeamento (auto mapper) e interfaces responsáveis pelo serviço
  
- GrupoAEducaoChallenge.Domain.Tests: 
  sub camada do domain, responsável pelos testes unitários da camada específica. 

- GrupoAEducaoChallenge.Infra.Data:
  Camada de persistênica onde está toda a comunicação com banco de dados e configurações do EF Core.

- GrupoAEducaoChallenge.Infra.IoC:
  Camada de Inversão de controle, responsável por conter configurações de injeção de dependência

- GrupoAEducaoChallenge.WebAPI: 
  API responsável por se comunicar com camada de apresentação.

- GrupoAEducaoChallenge.WebUI: 
  Camada de Apresentação utilizando framework Vuejs
  
---------------------------------------------------------------------------------------
  
## Lista de bibliotecas de terceiros utilizadas
  No backend foram tambem utilizados:
  - AutoMapper  
  - xUnit
    
  No frontEnd foram tambem utilizados:
  - axios  
  - v-mask
  - vue-router
    
---------------------------------------------------------------------------------------
## O que você melhoraria se tivesse mais tempo
  - Adicionar mais classes de teste unitário
  - Implementar campo de busca de aluno
  - Utilizar no front end um gerenciador de estado (vuex)
