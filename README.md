# ✈️ SkyBooker – Microservices Flugbuchungsplattform

## 📄 Übersicht
SkyBooker ist eine Microservices-basierte Anwendung zur Verwaltung von Flügen, Buchungen und Benutzer-Authentifizierung.  
Das Projekt nutzt ASP.NET Core, Docker, Serilog, Swagger, JWT und moderne Datenbanktechnologien (MongoDB, MSSQL, SQLite).

---

## 🏛️ Projektstruktur

```
SkyBooker/
├── docker-compose.yml
├── README.md
├── API Gateway (kommt später mit Ocelot)
│
├── Services/
│ ├── AuthService/
│ │ ├── Controllers/
│ │ │ └── AuthController.cs
│ │ ├── Data/
│ │ │ └── ApplicationDbContext.cs
│ │ ├── DTOs/
│ │ │ ├── LoginRequest.cs
│ │ │ ├── RegisterRequest.cs
│ │ ├── Interfaces/
│ │ │ └── IAuthService.cs
│ │ ├── Middleware/
│ │ │ └── ExceptionHandlingMiddleware.cs
│ │ ├── Models/
│ │ │ └── User.cs
│ │ ├── Profiles/
│ │ │ └── UserMappingProfile.cs
│ │ ├── Services/
│ │ │ └── AuthService.cs
│ │ ├── Helpers/
│ │ │ └── JwtTokenGenerator.cs
│ │ ├── Configuration/
│ │ │ └── JwtSettings.cs
│ │ ├── appsettings.json
│ │ ├── AuthService.Dockerfile
│ │ └── Program.cs
│
│ ├── BookingService/
│ │ ├── Controllers/
│ │ │ └── BookingController.cs
│ │ ├── Data/
│ │ │ └── BookingDbContext.cs
│ │ ├── DTOs/
│ │ │ ├── ApiResponse.cs
│ │ │ ├── BookingResponse.cs
│ │ │ └── CreateBookingRequest.cs
│ │ ├── Middleware/
│ │ │ └── ExceptionHandlingMiddleware.cs
│ │ ├── Models/
│ │ │ └── Booking.cs
│ │ ├── Profiles/
│ │ │ └── BookingMappingProfile.cs
│ │ ├── Services/
│ │ │ └── BookingService.cs
│ │ ├── appsettings.json
│ │ ├── BookingService.Dockerfile
│ │ └── Program.cs
│
│ ├── FlightService/
│ │ ├── Controllers/
│ │ │ └── FlightController.cs
│ │ ├── Data/
│ │ │ └── FlightDbContext.cs (geplant)
│ │ ├── Models/
│ │ │ └── Flight.cs (geplant)
│ │ ├── Services/
│ │ │ └── FlightService.cs (geplant)
│ │ ├── appsettings.json
│ │ ├── FlightService.Dockerfile
│ │ └── Program.cs
```


---

## 🛠️ Technologien
```
| Bereich				 | Technologie											|
|------------------------|------------------------------------------------------|
| Framework              | ASP.NET Core 8.0										|
| Microservices          | Ja (3 Services aktuell)								|
| Gateway                | Ocelot (geplant)										|
| Authentifizierung      | JWT													|
| Datenbanken            | SQLite (User) / MSSQL (Booking) / MongoDB (Flight)	|
| Containerisierung      | Docker, Docker Compose								|
| Logging                | Serilog												|
| Dokumentation          | Swagger / OpenAPI									|
| API Testing            | Postman												|
```
---

## ✅ Erfüllte Anforderungen

- Flugplan-Service: **teilweise** (FlightService wird noch finalisiert)
- Buchungs-Service: **fertig**
- Authentifizierungs-Service: **fertig**
- JWT-Authentifizierung: **fertig**
- Serilog-Logging: **fertig**
- ExceptionHandlingMiddleware: **fertig**
- Swagger-API Dokumentation: **überall vorhanden**
- GitHub-Repository: **aktiv verwaltet**
- Docker Setup (Compose, Images, SQL Server, MongoDB): **fast abgeschlossen**

---

## ⚠️ Was fehlt noch?
```
| Aufgabe											| Status			|
|---------------------------------------------------|-------------------|
| FlightService vollständige CRUD-Implementierung	| ❌ Ausstehend		|
| RabbitMQ Setup (optionale Anforderung AO6)		| ❌ Ausstehend		|
| WhatsApp-Integration (AO3)						| ❌ Ausstehend		|
| API Gateway mit Ocelot							| ⚠️ Noch offen		|
| Unit Tests										| ❌ Ausstehend		|
| Docker Compose vollständig stabilisiert			| ⚠️ Teilweise		|
```
---

## 🧪 Lokales Setup und Testen

1. **Voraussetzungen installieren**
   - Docker Desktop
   - Visual Studio 2022
   - .NET SDK 8.0

2. **Projekt klonen**
   - ```bash
   - git clone https://github.com/Yannnnck/SkyBooker
   - cd SkyBooker

3. **Docker Container starten
   - docker-compose up --build


4. **WebAPI testen
   - Swagger öffnen: http://localhost:5001/swagger/index.html			
   - AuthService, BookingService, FlightService prüfen

5. **Standard-Ports
   - AuthService: 5001
   - BookingService: 5003
   - FlightService: 5002
   - Ozelot: 5000

Kontakt
Projektleiter: Yannick Frei, Tunahan Keser