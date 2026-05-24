# Product-Inventory

## Sobre el proyecto
Es un proyecto para gestionar productos del inventario.

## Tecnologías
- **.NET 10**
- **EntityFramework Core** y **PostgreSQL**
- Tests con **Xunit**
- **Docker / Docker Compose**
- **Swagger / OpenAPI**
- CI/CD con **GitHub Actions**

## Modelos

**Product**
```
{
  int Id 
  string Name 
  string Category 
  string? Brand 
  string? Vendor 
  double Price 
  int Amount
}
```

## Endpoints

### Gestionar tipos de fichajes
| Metodo | Endpoint        |
|-------:|-----------------|
|    GET | `/Product/`     |
|    GET | `/Product/{id}` |
|   POST | `/Product/`     |
|    PUT | `/Product/{id}` |
| DELETE | `/Product/{id}` |

## Entorno desarrollo local

1. Iniciar postgres:
```bash
docker compose up
```
2. Aplicar migraciones: 
```
dotnet tool install --global dotnet-ef
dotnet ef database update
```
3. Ejecutar: `dotnet run`
4. Acceder a: http://localhost:5136/swagger

## Ejecutar entorno local

- Iniciar postgresql y product-inventory: 
```
docker compose -f local-deploy.yml up -d
```
- Acceder a: [`localhost:8080/swagger`](http://localhost:8080/swagger)

## Comandos utiles

- Añadir dependencias:
```
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
```

- Crear y aplicar migraciones:
```
dotnet tool install --global dotnet-ef
dotnet-ef migrations add InitialCreate
dotnet ef database update
```

- Crear tests
```
dotnet new xunit -n ProductInventoryTests
```
