"""
API routes for the AI Service.
"""
from fastapi import APIRouter
from app.schemas.schemas import ProcessDocumentRequest, ProcessDocumentResponse, GenerateQuizRequest, GenerateQuizResponse

# ── Routers ──────────────────────────────────────────────────────────────────

health_router = APIRouter()
document_router = APIRouter()
rag_router = APIRouter()


# ── Health Check ──────────────────────────────────────────────────────────────

@health_router.get("/")
async def health_check():
    """Health check endpoint."""
    return {"status": "ok", "service": "FPT RAG Lab AI Service"}


# ── Document Processing ───────────────────────────────────────────────────────

@document_router.post("/process", response_model=ProcessDocumentResponse)
async def process_document(request: ProcessDocumentRequest):
    """
    Process an uploaded document through the RAG pipeline:
    Parse → Chunk → Embed → Store in pgvector.

    Called by the Backend API after a student uploads a document (BR-22).
    """
    # TODO: Inject and use DocumentProcessor service
    raise NotImplementedError("Document processing not yet implemented")


# ── RAG & Quiz Generation ─────────────────────────────────────────────────────

@rag_router.post("/generate-quiz", response_model=GenerateQuizResponse)
async def generate_quiz(request: GenerateQuizRequest):
    """
    Generate a quiz via the RAG pipeline:
    Retrieve relevant chunks → Build context → LLM generation → Validate & cite.

    Called by the Backend API when a student requests quiz generation (UC-10).
    """
    # TODO: Inject and use RAGPipeline service
    raise NotImplementedError("Quiz generation not yet implemented")
