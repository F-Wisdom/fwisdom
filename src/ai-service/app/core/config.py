"""
Application configuration using Pydantic Settings.
"""
from pydantic_settings import BaseSettings
from typing import List


class Settings(BaseSettings):
    # Application
    APP_NAME: str = "FPT RAG Lab AI Service"
    DEBUG: bool = False

    # Database (PostgreSQL + pgvector)
    DATABASE_URL: str = "postgresql+asyncpg://postgres:password@localhost:5432/fpt_rag_lab"

    # LLM API
    LLM_PROVIDER: str = "openai"  # "openai" or "gemini"
    OPENAI_API_KEY: str = ""
    OPENAI_MODEL: str = "gpt-4o-mini"
    GEMINI_API_KEY: str = ""
    GEMINI_MODEL: str = "gemini-1.5-flash"

    # Embedding API
    EMBEDDING_PROVIDER: str = "openai"  # "openai" or "local"
    OPENAI_EMBEDDING_MODEL: str = "text-embedding-3-small"
    EMBEDDING_DIMENSION: int = 1536

    # OCR Service (optional)
    OCR_SERVICE_URL: str = ""

    # RAG Configuration
    CHUNK_SIZE: int = 512        # characters per chunk
    CHUNK_OVERLAP: int = 64      # overlap between chunks
    TOP_K_CHUNKS: int = 5        # number of chunks to retrieve

    # CORS
    ALLOWED_ORIGINS: List[str] = ["http://localhost:3000", "http://localhost:5173", "http://localhost:5000"]

    # Backend API (for internal callbacks)
    BACKEND_API_URL: str = "http://localhost:5000"

    class Config:
        env_file = ".env"
        case_sensitive = True


settings = Settings()
