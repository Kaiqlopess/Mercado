# Mercado API

Um sistema de gerenciamento para mercados desenvolvido em C# e .NET, focado em alta manutenibilidade através da aplicação dos princípios **SOLID** e de uma estrutura baseada em **Clean Architecture**.

## 🏗 Arquitetura e Padrões (SOLID)

O projeto está dividido em camadas bem definidas, garantindo que as regras de negócio sejam isoladas de frameworks externos, facilitando testes e evoluções futuras:

*   **Mercado.Api**: Camada de Apresentação (Controllers). Lida exclusivamente com as requisições HTTP, respostas e roteamento.
*   **Mercado.Application**: Camada de Aplicação (Use Cases). Contém os fluxos e orquestração do sistema, utilizando DTOs (Data Transfer Objects). É evidente a aplicação do **Princípio da Responsabilidade Única (SRP)** (ex: `ICriarProdutoService`, `IDeletarProdutoService`), onde cada serviço possui apenas uma função e um único motivo para mudar. O **Princípio de Inversão de Dependência (DIP)** também é largamente aplicado com injeção de dependências.
*   **Mercado.Domain**: O coração da aplicação. Contém as Entidades de negócio (Produto, Categoria, Setor) e as interfaces que definem os contratos dos repositórios.
*   **Mercado.Infra**: Camada de Infraestrutura. Lida com o acesso a dados (Banco de Dados), a implementação real dos repositórios definidos no domínio, e a configuração do ORM.

### Entidades Principais
*   📦 **Produto**
*   🏷️ **Categoria**
*   🏬 **Setor**

## 💾 ORM e Banco de Dados

O mapeamento objeto-relacional é feito utilizando o **Entity Framework Core (EF Core)**. 
A modelagem do banco segue a abordagem Code-First e todas as mudanças de estrutura (tabelas, colunas, relacionamentos) são controladas via **Migrations**, permitindo a criação da base e evolução do esquema de banco de dados de maneira automatizada e previsível.

## 🚀 Rotas da API (Endpoints)

Abaixo estão os endpoints expostos pela API.

### 🛒 Produtos (`/Produto`)
*   `POST /Produto` - Cadastra um novo produto.
*   `GET /Produto` - Lista todos os produtos cadastrados.
*   `GET /Produto/categoria/{id}` - Lista produtos filtrando pela Categoria.
*   `DELETE /Produto/{id}` - Exclui um produto específico.
*   `PUT /Produto/{id}` - Atualiza as informações de um produto.
*   `POST /Produto/vender` - Registra a venda de um produto no caixa (baixa no estoque).
*   `GET /Produto/estoque/valor-total` - Retorna o valor financeiro total dos produtos armazenados em estoque.
*   `GET /Produto/estoque/faltantes` - Lista os produtos que estão com o estoque zerado ou abaixo do limite.

### 🏷️ Categorias (`/Categoria`)
*   `POST /Categoria` - Cadastra uma nova categoria.
*   `GET /Categoria` - Lista todas as categorias cadastradas.
*   `DELETE /Categoria/{id}` - Exclui uma categoria específica.
*   `PUT /Categoria/{id}` - Atualiza as informações de uma categoria.

### 🏬 Setores (`/Setor`)
*   `POST /Setor` - Cadastra um novo setor.
*   `GET /Setor` - Lista todos os setores cadastrados.
*   `DELETE /Setor/{id}` - Exclui um setor específico.
*   `PUT /Setor/{id}` - Atualiza as informações de um setor.

## ⚙️ Como Executar o Projeto

1. Faça o clone do repositório.
2. Certifique-se de ter o **.NET SDK** instalado na sua máquina.
3. Configure a `ConnectionString` com o seu banco de dados no arquivo `appsettings.json` ou `appsettings.Development.json` localizado em `src/Mercado.Api`.
4. Navegue até o diretório raiz e execute as migrations para criar o banco de dados e as tabelas:
   ```bash
   dotnet ef database update --project src/Mercado.Infra --startup-project src/Mercado.Api
   ```
5. Inicie o projeto:
   ```bash
   dotnet run --project src/Mercado.Api
   ```
6. Acesse via navegador no endereço gerado pelo Kestrel (por padrão: `http://localhost:5000` ou `https://localhost:5001`). Caso tenha o Swagger configurado, acesse `/swagger`.
