# 📌 Principais Comandos do Entity Framework Core (EF Core)

## 🔹 Instalação da ferramenta
- `dotnet tool install --global dotnet-ef` → Instala o CLI do EF Core globalmente na máquina.  
- `dotnet tool update --global dotnet-ef` → Atualiza a ferramenta do EF Core.  

---

## 🔹 Pacotes essenciais (exemplo com SQL Server)
- `dotnet add package Microsoft.EntityFrameworkCore` → Adiciona o pacote base do EF Core.  
- `dotnet add package Microsoft.EntityFrameworkCore.SqlServer` → Adiciona o provedor para SQL Server.  
- `dotnet add package Microsoft.EntityFrameworkCore.Design` → Necessário para scaffolding e migrations.  

---

## 🔹 Migrations
- `dotnet ef migrations add NomeDaMigration` → Cria uma nova migration.  
- `dotnet ef migrations remove` → Remove a última migration (se ainda não aplicada ao banco).  
- `dotnet ef database update` → Aplica migrations pendentes ao banco de dados.  
- `dotnet ef database update NomeDaMigration` → Reverte o banco para o estado de uma migration específica.  
- `dotnet ef migrations list` → Lista todas as migrations existentes no projeto.  

---

## 🔹 Banco de Dados
- `dotnet ef database update` → Cria o banco de dados conforme o contexto configurado.  
- `dotnet ef database drop` → Exclui o banco de dados configurado no contexto.  

---

## 🔹 Scaffold (Database-First)
- `dotnet ef dbcontext scaffold "ConnectionStringAqui" Microsoft.EntityFrameworkCore.SqlServer -o Models` → Gera modelos e DbContext a partir de um banco existente.  
  - `-o` → Define a pasta de saída (exemplo: `-o Models`).  
  - `--context` → Define o nome do contexto.  
  - `--tables` → Seleciona tabelas específicas.  
  - `--force` → Sobrescreve arquivos existentes.  

---

## 🔹 DbContext
- `dotnet ef dbcontext info` → Exibe informações do DbContext configurado.  
- `dotnet ef dbcontext list` → Lista todos os DbContexts no projeto.  
- `dotnet ef migrations script` → Gera um script SQL baseado nas migrations.  

---

# ⚡ Fluxo mais usado no dia a dia
1. Criar uma migration → `dotnet ef migrations add NomeDaMigration`  
2. Atualizar o banco com a migration → `dotnet ef database update`  
3. Conferir migrations existentes → `dotnet ef migrations list`  
4. Se necessário remover última migration → `dotnet ef migrations remove`  
5. Se for gerar classes a partir de um banco existente →  
   `dotnet ef dbcontext scaffold "ConnectionStringAqui" Microsoft.EntityFrameworkCore.SqlServer -o Models`  

---
