"""
FPT RAG Lab - AI Service
FastAPI application entry point.
"""
from fastapi import FastAPI
from fastapi.middleware.cors import CORSMiddleware

from app.api.routes import document_router, rag_router, health_router
from app.core.config import settings

app = FastAPI(
    title="FPT RAG Lab - AI Service",
    description="Document processing, embedding generation, RAG pipeline, and quiz generation service.",
    version="1.0.0",
)

# CORS
app.add_middleware(
    CORSMiddleware,
    allow_origins=settings.ALLOWED_ORIGINS,
    allow_credentials=True,
    allow_methods=["*"],
    allow_headers=["*"],
)

# Register routers
app.include_router(health_router, prefix="/health", tags=["Health"])
app.include_router(document_router, prefix="/api/documents", tags=["Document Processing"])
app.include_router(rag_router, prefix="/api/rag", tags=["RAG & Quiz Generation"])


@app.on_event("startup")
async def startup_event():
    """Initialize services on startup."""
    # TODO: Initialize database connections, load models, etc.
    pass


@app.on_event("shutdown")
async def shutdown_event():
    """Cleanup on shutdown."""
    pass
