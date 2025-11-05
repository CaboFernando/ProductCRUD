# 🛒 Sistema de Gerenciamento de Produtos

Sistema CRUD completo desenvolvido com **AngularJS 1.3** no frontend e **.NET Framework 4.8** no backend.

## 📋 Sobre o Projeto

Aplicação web para gerenciamento de produtos com operações de criação, leitura, atualização e exclusão (CRUD), desenvolvida como desafio técnico.

## 🛠️ Tecnologias Utilizadas

### Backend
- .NET Framework 4.8
- ASP.NET Web API 2
- Entity Framework 6.4.4
- SQL Server LocalDB
- C#

### Frontend
- AngularJS 1.3.20
- Bootstrap 3.3.7
- HTML5 / CSS3
- JavaScript

## 🏗️ Arquitetura

```
ProductCRUD/
├── ProductCRUD.API/          # Camada de Apresentação (Web API)
├── ProductCRUD.Data/         # Camada de Acesso a Dados
├── ProductCRUD.Domain/       # Camada de Domínio (Entidades)
└── Frontend/                 # Aplicação AngularJS
```

### Padrões Utilizados
- **Repository Pattern** para acesso a dados
- **Dependency Injection** via construtores
- **RESTful API** com verbos HTTP semânticos
- **MVC Pattern** no frontend (AngularJS)
- **Separation of Concerns** entre camadas

## 📦 Funcionalidades

- ✅ Listar todos os produtos
- ✅ Visualizar detalhes de um produto
- ✅ Criar novo produto
- ✅ Editar produto existente
- ✅ Excluir produto
- ✅ Validação de dados
- ✅ Mensagens de feedback ao usuário
- ✅ Interface responsiva

## 🚀 Como Executar

### Pré-requisitos
- Visual Studio 2019 ou superior
- .NET Framework 4.8
- SQL Server LocalDB
- Navegador web moderno

### Backend

1. Clone o repositório:
```bash
git clone https://github.com/CaboFernando/ProductCRUD.git
cd ProductCRUD
```

2. Abra a solution no Visual Studio:
```
ProductCRUD.slnx
```

3. Restaure os pacotes NuGet:
```
Tools → NuGet Package Manager → Restore NuGet Packages
```

4. Execute as migrations para criar o banco de dados:
```powershell
Update-Database -ProjectName ProductCRUD.Data
```

5. Execute o projeto (F5):
```
A API estará disponível em: https://localhost:44370/api/products
```

### Frontend

1. Navegue até a pasta Frontend:
```bash
cd Frontend
```

2. Inicie um servidor web local. Opções:

**Opção 1 - Live Server (VS Code):**
- Instale a extensão "Live Server"
- Clique direito em `index.html` → "Open with Live Server"

**Opção 2 - http-server (Node.js):**
```bash
npm install -g http-server
http-server -p 8080
```

**Opção 3 - Python:**
```bash
python -m http.server 8080
```

3. Acesse no navegador:
```
http://localhost:8080
```

## 🔧 Configuração

### Connection String

Edite o arquivo `ProductCRUD.API/Web.config` se necessário:

```xml
<connectionStrings>
  <add name="DefaultConnection" 
       connectionString="Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=ProductCRUD;Integrated Security=True" 
       providerName="System.Data.SqlClient" />
</connectionStrings>
```

### API URL no Frontend

Edite `Frontend/app/app.js` para ajustar a porta da API:

```javascript
.constant('API_URL', 'http://localhost:44370/api/products');
```

## 📊 Estrutura do Banco de Dados

### Tabela: Products

| Campo        | Tipo         | Descrição                  |
|--------------|--------------|----------------------------|
| Id           | int          | Chave primária (identity)  |
| Nome         | varchar(100) | Nome do produto            |
| Descricao    | text         | Descrição do produto       |
| Preco        | decimal(18,2)| Preço do produto           |
| DataCadastro | datetime     | Data de criação do registro|

## 🔍 Endpoints da API

| Método | Endpoint              | Descrição                |
|--------|-----------------------|--------------------------|
| GET    | /api/products         | Lista todos os produtos  |
| GET    | /api/products/{id}    | Busca produto por ID     |
| POST   | /api/products         | Cria novo produto        |
| PUT    | /api/products/{id}    | Atualiza produto         |
| DELETE | /api/products/{id}    | Exclui produto           |

### Exemplo de Request (POST/PUT)

```json
{
  "Nome": "Notebook Dell",
  "Descricao": "Notebook i7, 16GB RAM, SSD 512GB",
  "Preco": 4599.90
}
```

## 🧪 Testando a API

### Postman / Insomnia

**GET - Listar produtos:**
```
GET http://localhost:44370/api/products
```

**POST - Criar produto:**
```
POST http://localhost:44370/api/products
Content-Type: application/json

{
  "Nome": "Mouse Logitech",
  "Descricao": "Mouse sem fio",
  "Preco": 89.90
}
```

## 📝 Decisões Técnicas

### Por que 3 camadas (sem Business Layer)?
Para um CRUD simples, optei por não incluir uma camada de negócio separada, evitando over-engineering. Se o projeto crescesse com regras complexas, seria refatorado para incluir essa camada.

### Por que CORS via Web.config?
Configurei CORS manualmente via Web.config ao invés de usar pacotes NuGet para evitar conflitos de versão e demonstrar conhecimento de configuração do ASP.NET.

### Por que Repository Pattern?
O padrão Repository abstrai o acesso a dados, facilitando testes unitários e possíveis mudanças de estratégia de persistência no futuro.

## 🎯 Boas Práticas Implementadas

- ✅ Separação de responsabilidades (SRP)
- ✅ Nomenclatura consistente e semântica
- ✅ Tratamento de exceções
- ✅ Validação de dados no backend e frontend
- ✅ Feedback visual para o usuário
- ✅ Código limpo e legível
- ✅ Configurações centralizadas
- ✅ Versionamento com Git

## 📱 Screenshots

### Lista de Produtos
![Lista de Produtos](https://via.placeholder.com/800x400?text=Lista+de+Produtos)

### Formulário de Cadastro
![Formulário](https://via.placeholder.com/800x400?text=Formulário+de+Cadastro)

## 👤 Autor

**Fernando Cabo**
- GitHub: [@CaboFernando](https://github.com/CaboFernando)
- LinkedIn: [Seu LinkedIn](https://linkedin.com/in/seu-perfil)

## 📄 Licença

Este projeto foi desenvolvido como desafio técnico e está disponível sob a licença MIT.

---

⭐ Se este projeto foi útil, considere dar uma estrela!