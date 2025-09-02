# Tasarım Seçenekleri
- **Architecture**: 4 katmanlı (Domain, Application, Infrastructure, Api). Controller → Application Service → UoW/Repositories → EF Core.
- **SOLID**: 
  - SRP: Validasyon, mapping, persistence ayrı.
  - DIP: Application, Infrastructure’a değil arayüzlere bağımlı.
- **Persistence**: EF Core + SqlServer
- **Error Handling**: GlobalExceptionMiddleware; consistent JSON hata çıktısı
- **Validation**: FluentValidation ile DTO seviyesinde.
- **Docs**: Swagger/OpenAPI.
- **Docker**: API + SQL Server için docker-compose. API connection string env var üzerinden.

## Docker Compose ile Tüm Sistemi Ayağa Kaldırma

### Docker Desktop ın kurulu olması gerekmektedir

### 1.Build

docker-compose build

### 2.Run

docker-compose up

### 3.Stop

docker-compose down

---

## Servis Portları

- **ECommerceService**	
	- http://localhost:8080
- **MSSQL**
	- localhost:1433 (docker)

---

## Swagger UI

- **ECommerceService Swagger**
	- http://localhost:8080/swagger