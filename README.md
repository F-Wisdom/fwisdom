# FPT RAG Lab – Outcome-Aligned Quiz Generation Platform

AI-assisted web platform for FPT University students to generate Retrieval-Augmented Generation (RAG) based, outcome-aligned multiple-choice quizzes from their uploaded course documents.

---

## 📁 Project Structure

```
F_wisdom/
├── docker-compose.yml          # Run all services together
├── Documentation/              # Project documentation & SRS
└── src/
    ├── backend/                # ASP.NET Core C# Backend API
    │   ├── FptRagLab.API/      # Web API layer (Controllers, Middleware)
    │   ├── FptRagLab.Application/  # Application layer (Services, DTOs, Interfaces)
    │   ├── FptRagLab.Domain/   # Domain entities, enums, interfaces
    │   └── FptRagLab.Infrastructure/  # EF Core, Repositories, External services
    │
    ├── ai-service/             # Python FastAPI AI/RAG Service
    │   ├── app/
    │   │   ├── main.py         # FastAPI app entry point
    │   │   ├── core/           # Config, database
    │   │   ├── api/routes/     # API endpoints
    │   │   ├── services/
    │   │   │   ├── document/   # Parser, Chunker
    │   │   │   ├── rag/        # RAG pipeline, Vector store
    │   │   │   └── quiz/       # LLM client, Grounding validator
    │   │   ├── schemas/        # Pydantic request/response models
    │   │   └── utils/          # Helper utilities
    │   ├── tests/              # Unit & integration tests
    │   ├── requirements.txt    # Python dependencies
    │   ├── Dockerfile
    │   └── .env.example        # Environment variables template
    │
    └── frontend/               # React/Next.js Web Application
        └── src/
            ├── components/     # Reusable UI components
            ├── pages/          # Page components
            ├── services/       # API service clients
            ├── store/          # State management
            ├── types/          # TypeScript types
            └── utils/          # Helper functions
```

---

## 🏗️ Architecture

```
[Frontend (React)]
       ↕ HTTPS
[ASP.NET Core Backend API (C#)]
       ↕ REST/JSON
[Python AI Service (FastAPI)]
       ↕
[PostgreSQL + pgvector]
       ↕
[LLM API (OpenAI/Gemini)] | [Embedding API] | [Email Service] | [OCR Service]
```

---

## 🚀 Getting Started

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [Python 3.11+](https://python.org)
- [Node.js 20+](https://nodejs.org)
- [Docker & Docker Compose](https://docker.com)
- [PostgreSQL 16 with pgvector](https://github.com/pgvector/pgvector)

### 1. Start Database (with Docker)

```bash
docker-compose up postgres -d
```

### 2. Run Backend API (C#)

```bash
cd src/backend/FptRagLab.API
dotnet run
# API available at: http://localhost:5000
# Swagger UI: http://localhost:5000/swagger
```

### 3. Run AI Service (Python)

```bash
cd src/ai-service
cp .env.example .env
# Edit .env with your API keys

pip install -r requirements.txt
uvicorn app.main:app --reload --port 8000
# API available at: http://localhost:8000
# Docs at: http://localhost:8000/docs
```

### 4. Run Frontend

```bash
cd src/frontend
npm install
npm run dev
# Frontend at: http://localhost:3000
```

### Or run everything with Docker Compose:

```bash
cp .env.example .env   # Add OPENAI_API_KEY
docker-compose up
```

---

## 🔑 Key Features

| Feature | Component | Use Cases |
|---|---|---|
| Register / Login / JWT Auth | Backend | UC-01, UC-02, UC-03 |
| Upload PDF/DOCX documents | Backend + AI Service | UC-07, UC-23-27 |
| RAG-based Quiz Generation | AI Service | UC-10, UC-28-35 |
| Take Quiz & View Results | Backend | UC-11, UC-12 |
| Source Citations | Backend + AI Service | UC-33, UC-40 |
| Quiz History & Review | Backend | UC-13, UC-14 |
| Admin Dashboard | Backend | UC-15-20 |
| Token Quota Management | Backend | UC-41, UC-42 |

---

## 🛠️ Tech Stack

| Layer | Technology |
|---|---|
| **Frontend** | React / Next.js / TypeScript |
| **Backend API** | ASP.NET Core 8, C#, EF Core |
| **AI Service** | Python 3.11, FastAPI |
| **Database** | PostgreSQL 16 + pgvector |
| **Auth** | JWT (access + refresh tokens) |
| **LLM** | OpenAI GPT / Google Gemini |
| **Embeddings** | OpenAI text-embedding-3-small |
| **Container** | Docker + Docker Compose |

---

## 📋 Environment Variables

### Backend (`src/backend/FptRagLab.API/appsettings.json`)
- `ConnectionStrings:DefaultConnection` - PostgreSQL connection string
- `Jwt:Key` - JWT signing secret (min 256-bit)
- `AiService:BaseUrl` - Python AI Service URL

### AI Service (`src/ai-service/.env`)
- `OPENAI_API_KEY` - OpenAI API key
- `DATABASE_URL` - PostgreSQL connection URL
- `BACKEND_API_URL` - Backend API URL for callbacks

---

## 👥 Team Roles

| Role | Responsibilities |
|---|---|
| **Backend Dev** | C# API, Auth, Document/Quiz management, EF Core |
| **AI Dev** | Python RAG pipeline, LLM integration, pgvector |
| **Frontend Dev** | React UI, quiz interface, admin dashboard |
| **Full-stack** | Integration, Docker, CI/CD |

---

## 📚 Documentation

- [Business Requirements & SRS](./Documentation/FPT%20RAG%20LAB.md)
- [Context Diagram & ERD](./Documentation/Context,%20Swimlane%20,Usecase.%20ERD%20and%20DB.md)
- [Architecture (C4 DSL)](./Documentation/workspace.dsl)
- [ERD on Miro](https://miro.com/app/board/uXjVHk5IMGs=/?share_link_id=651883539467)
- [DB Schema on dbdiagram.io](https://dbdiagram.io/d/6a141414b62396d22c61573d)