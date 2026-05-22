# Tienda API

API REST para gestión de productos con autenticación JWT, construida con .NET 8 siguiendo los principios de Clean Architecture y CQRS.

---

## Requisitos previos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Entity Framework Core CLI](https://learn.microsoft.com/ef/core/cli/dotnet)

Instalar EF Core CLI (una sola vez):

```bash
dotnet tool install --global dotnet-ef
```

---

## Pasos para ejecutar el proyecto

### 1. Clonar el repositorio

```bash
git clone <URL_DEL_REPOSITORIO>
cd tienda
```

### 2. Restaurar dependencias

```bash
dotnet restore tienda.sln
```

### 3. Aplicar la migración (crea la base de datos SQLite)

```bash
dotnet ef database update \
  --project src/tienda.Infrastructure \
  --startup-project src/tienda.WebApi
```

Esto crea el archivo `tienda.db` con las tablas `Users` y `Products`.

### 4. Ejecutar el proyecto

```bash
dotnet run --project src/tienda.WebApi
```

La API quedará disponible en:
- HTTP: `http://localhost:5227`
- HTTPS: `https://localhost:7227`

### 5. Explorar con Swagger

Abre en el navegador:

```
http://localhost:5227/swagger
```

---

## Autenticación y roles

El sistema maneja **dos roles**:

| Rol        | Valor | Permisos                                      |
|------------|-------|-----------------------------------------------|
| `Admin`    | 1     | Puede crear productos + ver productos         |
| `Customer` | 2     | Solo puede ver productos                      |

### Flujo de autenticación

1. **Registrar un usuario** → `POST /api/auth/register`
2. **Iniciar sesión** → `POST /api/auth/login` → obtenés el token JWT
3. **Usar el token** → en Swagger hacé clic en **Authorize** e ingresá: `Bearer {tu_token}`

---

## Endpoints

### Autenticación (públicos)

#### Registrar usuario
```http
POST /api/auth/register
Content-Type: application/json

{
  "firstName": "Juan",
  "lastName": "Pérez",
  "email": "juan@example.com",
  "password": "password123"
}
```

**Respuesta:**
```json
{
  "token": "eyJhbGci...",
  "email": "juan@example.com",
  "fullName": "Juan Pérez",
  "role": "Customer",
  "expiresAt": "2024-01-01T01:00:00Z"
}
```

> Los usuarios registrados tienen rol **Customer** por defecto.

#### Iniciar sesión
```http
POST /api/auth/login
Content-Type: application/json

{
  "email": "juan@example.com",
  "password": "password123"
}
```

---

### Productos (rutas protegidas — requieren JWT)

#### Obtener todos los productos
```http
GET /api/productos
Authorization: Bearer {token}
```

Disponible para: `Admin` y `Customer`

#### Obtener producto por ID
```http
GET /api/productos/{id}
Authorization: Bearer {token}
```

Disponible para: `Admin` y `Customer`

#### Crear producto
```http
POST /api/productos
Authorization: Bearer {token}   ← debe ser token de Admin
Content-Type: application/json

{
  "nombre": "Laptop HP",
  "descripcion": "Laptop 15 pulgadas",
  "precio": 999.99,
  "stock": 10
}
```

Disponible para: solo **Admin**

---

## Casos de uso implementados

| # | Caso de uso              | Tipo    | Rol requerido     | Endpoint                    |
|---|--------------------------|---------|-------------------|-----------------------------|
| 1 | Registrar usuario        | Command | Público           | `POST /api/auth/register`   |
| 2 | Iniciar sesión           | Command | Público           | `POST /api/auth/login`      |
| 3 | Obtener todos los productos | Query | Auth (Admin/Customer) | `GET /api/productos`   |
| 4 | Obtener producto por ID  | Query   | Auth (Admin/Customer) | `GET /api/productos/{id}` |
| 5 | Crear producto           | Command | Solo Admin        | `POST /api/productos`       |

---

## Arquitectura del proyecto

```
tienda/
├── src/
│   ├── tienda.Domain/          # Entidades, Value Objects, Excepciones, Enums
│   ├── tienda.Application/     # CQRS (Commands/Queries), Validadores, Contratos
│   ├── tienda.Infrastructure/  # EF Core (SQLite), JWT, BCrypt, Repositorios
│   └── tienda.WebApi/          # Controllers, Middleware, Program.cs
└── tienda.sln
```

### Patrones utilizados
- **Clean Architecture** — separación en 4 capas
- **CQRS** con MediatR — Commands y Queries separados
- **Repository Pattern** — abstracción del acceso a datos
- **Value Objects** — `Email` y `Money` con validaciones encapsuladas
- **Pipeline Behavior** — validación automática con FluentValidation

---

## Configuración (appsettings.json)

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=tienda.db"
  },
  "JwtSettings": {
    "SecretKey": "MySuper5ecreTKeyFor1iendaProjec7",
    "Issuer": "tienda-api",
    "Audience": "tienda-clients",
    "ExpirationMinutes": 60
  }
}
```

---

## Recrear la migración (si es necesario)

```bash
# Eliminar migración existente
dotnet ef migrations remove \
  --project src/tienda.Infrastructure \
  --startup-project src/tienda.WebApi

# Crear nueva migración
dotnet ef migrations add InitialCreate \
  --project src/tienda.Infrastructure \
  --startup-project src/tienda.WebApi \
  --output-dir Persistence/Migrations

# Aplicar a la base de datos
dotnet ef database update \
  --project src/tienda.Infrastructure \
  --startup-project src/tienda.WebApi
```

---

## Tecnologías

| Tecnología | Versión | Uso |
|------------|---------|-----|
| .NET | 8.0 | Framework base |
| Entity Framework Core | 8.0.11 | ORM + migraciones |
| SQLite | — | Base de datos |
| MediatR | 14.1.0 | CQRS / mediador |
| FluentValidation | 12.1.1 | Validación de comandos |
| BCrypt.Net-Next | 4.2.0 | Hash de contraseñas |
| JWT Bearer | 8.0.0 | Autenticación |
| Swashbuckle | 6.6.2 | Documentación Swagger |
