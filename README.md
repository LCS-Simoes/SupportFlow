# 💬 SupportFlow - Em Desenvolvimento

O **SupportFlow** é uma aplicação desenvolvida em **ASP.NET Core** com arquitetura limpa, voltada para o **gerenciamento de tickets de suporte**.  
Seu objetivo é otimizar a comunicação entre usuários e equipes de atendimento, permitindo o registro, acompanhamento e categorização de solicitações de forma simples e eficiente.

---

## 🚀 Funcionalidades

- 🧾 **Cadastro de tickets** com título, descrição, status e categoria  
- 👤 **Autenticação de usuários** com perfis diferentes (usuário comum e administrador)  
- 🗂️ **Listagem e filtragem de tickets** por status ou categoria  
- 🛠️ **Atualização e exclusão de tickets**  
- 💡 **Interface dinâmica** desenvolvida com **Razor Pages** (ASP) e consumo da **API REST**  
- ⚙️ **Camadas separadas** seguindo os princípios da **Clean Architecture**

---

## 🧱 Estrutura do Projeto
```
src/
├── SupportFlow.API              # Projeto ASP.NET Core Web API (Controllers, Endpoints, Configurações, Swagger)
├── SupportFlow.Application      # Camada de Aplicação (Use Cases, DTOs,)
├── SupportFlow.Domain           # Camada de Domínio (Entidades, Enums, Regras de Negócio, Contratos)
├── SupportFlow.Infrastructure   # Camada de Infraestrutura (EF Core, SQLite, Repositórios, Mapeamentos)
└── SupportFlow.Front            # Camada de Apresentação (Razor Pages, Views, wwwroot, Integração com a API)
```
## 👨‍💻 Autor
**Lucas Simões**  
📍 Desenvolvedor focado em soluções web e arquitetura limpa  
🔗 GitHub: [LCS-Simoes](https://github.com/LCS-Simoes)
