# 🛒 Sistema de Gerenciamento de Produtos

Sistema CRUD completo desenvolvido com **AngularJS 1.3** no frontend e **.NET Framework 4.8** no backend.

## 📋 Sobre o Projeto

Aplicação web para gerenciamento de produtos com operações de criação, leitura, atualização e exclusão (CRUD), desenvolvida como desafio técnico.

## 🛠️ Tecnologias Utilizadas

### Backend
- .NET Framework 4.8
- ASP.NET Web API 2
- Entity Framework 6
- SQL Server (LocalDB/Express/Full)
- C#

### Frontend
- AngularJS 1.3.20
- Bootstrap 3.3.7
- HTML5 / CSS3
- JavaScript

## 🏗️ Arquitetura

```
ProductCRUD/
├── ProductCRUD.API/          # Camada de API (Web API 2)
│   ├── Controllers/ProductsController.cs
│   ├── Services/ProductService.cs        # Camada de aplicação (orquestra DTOs ↔ domínio)
│   ├── Models/ProductDtos.cs             # DTOs: Create/Update/Read
│   └── App_Start/WebApiConfig.cs         # CORS + JSON camelCase
├── ProductCRUD.Data/         # Acesso a dados (EF6)
│   ├── Context/ProductContext.cs
│   ├── Repositories/ProductRepository.cs
│   └── Migrations/*
└── ProductCRUD.Domain/       # Domínio (Entidades e Contratos)
    ├── Entities/Product.cs
    └── Repositories/IProductRepository.cs
```

### Padrões Utilizados
- Repository Pattern para acesso a dados
- Service/Application Layer para regras simples e mapeamento
- RESTful API com verbos HTTP semânticos
- Separation of Concerns entre camadas

## 📦 Funcionalidades

- ✅ Listar todos os produtos
- ✅ Visualizar detalhes de um produto
- ✅ Criar novo produto
- ✅ Editar produto existente
- ✅ Excluir produto
- ✅ Validação de dados (DataAnnotations nos DTOs)

## 🚀 Como Executar

### Pré-requisitos
- Visual Studio 2019 ou superior
- .NET Framework 4.8
- SQL Server (LocalDB/Express/Full)

### Backend

1. Clone o repositório:
```bash
git clone https://github.com/CaboFernando/ProductCRUD.git
cd ProductCRUD
```

2. Abra a solution no Visual Studio.

3. Configure a connection string em `ProductCRUD.API/Web.config` (nome `DefaultConnection`).

4. Execute o projeto (F5). Na primeira execução o EF6 aplicará as migrações automaticamente via `MigrateDatabaseToLatestVersion`.
   - Opcionalmente, você pode aplicar as migrações manualmente:
   ```powershell
   Update-Database -ProjectName ProductCRUD.Data
   ```

### Frontend

Siga as instruções no diretório do frontend (se aplicável) para subir um servidor estático e consumir os endpoints abaixo.

## 🔧 Configuração

### Connection String

`ProductCRUD.API/Web.config`:
```xml
<connectionStrings>
  <add name="DefaultConnection"
       connectionString="Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ProductCRUD;Integrated Security=True;MultipleActiveResultSets=True"
       providerName="System.Data.SqlClient" />
</connectionStrings>
```

## 🔍 Endpoints da API

Base: `/api/products`

| Método | Endpoint           | Descrição                |
|--------|---------------------|--------------------------|
| GET    | /api/products       | Lista todos os produtos  |
| GET    | /api/products/{id}  | Busca produto por ID     |
| POST   | /api/products       | Cria novo produto        |
| PUT    | /api/products/{id}  | Atualiza produto         |
| DELETE | /api/products/{id}  | Exclui produto           |

### Exemplo de Request (POST/PUT)

```json
{
  "nome": "Notebook Dell",
  "descricao": "Notebook i7, 16GB RAM, SSD 512GB",
  "preco": 4599.90
}
```

### Exemplo de Response (Read DTO)

```json
{
  "id": 1,
  "nome": "Notebook Dell",
  "descricao": "Notebook i7, 16GB RAM, SSD 512GB",
  "preco": 4599.90,
  "dataCadastro": "2025-11-05T20:55:00"
}
```

## 📊 Estrutura do Banco de Dados

Tabela `Products` (Code First):

| Campo        | Tipo             | Regras                     |
|--------------|------------------|----------------------------|
| Id           | int              | Identity, PK               |
| Nome         | nvarchar(100)    | Not null                   |
| Descricao    | nvarchar(max)    | Nullable                   |
| Preco        | decimal(18,2)    | Not null                   |
| DataCadastro | datetime         | Not null (definido no repo)|

## 🌐 CORS e Formatação JSON
- CORS habilitado via `WebApiConfig`/`[EnableCors]` permitindo todas as origens (ajuste para produção).
- Formatação JSON em camelCase e XML desabilitado.
- `POST` retorna `201 Created` com `Location` usando `CreatedAtRoute`.

## 📝 Decisões Técnicas

- DTOs introduzidos para separar contrato de API da entidade de domínio e aplicar validações.
- Camada de serviço para orquestração e mapeamento (mantendo controllers finos).
- Repositório com `AsNoTracking()` em listagens para performance.
- Migrações automáticas na inicialização do contexto para simplificar setup.

## 🧪 Testando a API (exemplos)

Listar produtos:
```
GET http://localhost:{porta}/api/products
```

Criar produto:
```
POST http://localhost:{porta}/api/products
Content-Type: application/json

{
  "nome": "Mouse Logitech",
  "descricao": "Mouse sem fio",
  "preco": 89.90
}
```

## 👤 Autor

**Fernando Cabo**
- GitHub: [@CaboFernando](https://github.com/CaboFernando)

## 📄 Licença

Este projeto foi desenvolvido como desafio técnico e está disponível sob a licença MIT.

---

⭐ Se este projeto foi útil, considere dar uma estrela!