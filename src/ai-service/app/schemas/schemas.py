"""
Pydantic schemas for request/response models in the AI Service.
"""
from pydantic import BaseModel, Field
from typing import List, Optional
from enum import Enum
import uuid


class QuizDifficulty(str, Enum):
    easy = "easy"
    medium = "medium"
    hard = "hard"


# ── Document Processing Schemas ──────────────────────────────────────────────

class ProcessDocumentRequest(BaseModel):
    """Request to process an uploaded document for RAG."""
    document_id: uuid.UUID
    user_id: uuid.UUID
    file_path: str
    file_name: str
    file_type: str  # "pdf" or "docx"


class ProcessDocumentResponse(BaseModel):
    """Response after document processing."""
    document_id: uuid.UUID
    status: str  # "completed" or "failed"
    chunk_count: int = 0
    error_message: Optional[str] = None


# ── RAG & Quiz Generation Schemas ────────────────────────────────────────────

class GenerateQuizRequest(BaseModel):
    """Request to generate a quiz via RAG pipeline."""
    quiz_id: uuid.UUID
    user_id: uuid.UUID
    course_id: uuid.UUID
    course_title: str
    learning_outcomes: List[str] = Field(..., description="List of LO descriptions")
    question_count: int = Field(10, ge=1, le=50)
    difficulty: QuizDifficulty = QuizDifficulty.medium


class QuestionOptionSchema(BaseModel):
    content: str
    is_correct: bool
    order_index: int


class CitationSchema(BaseModel):
    document_id: uuid.UUID
    document_chunk_id: uuid.UUID
    document_file_name: str
    page_number: int
    section_title: Optional[str] = None
    relevant_text: str


class GeneratedQuestionSchema(BaseModel):
    content: str
    explanation: str
    order_index: int
    options: List[QuestionOptionSchema]
    citation: Optional[CitationSchema] = None


class GenerateQuizResponse(BaseModel):
    """Response with generated questions."""
    quiz_id: uuid.UUID
    questions: List[GeneratedQuestionSchema]
    total_input_tokens: int
    total_output_tokens: int
    model_name: str
    status: str  # "success" or "failed" or "insufficient_context"


# ── Vector Search Schemas ─────────────────────────────────────────────────────

class RetrievalRequest(BaseModel):
    """Request for vector similarity search."""
    query: str
    user_id: uuid.UUID
    top_k: int = 5


class ChunkResult(BaseModel):
    """A retrieved document chunk."""
    chunk_id: uuid.UUID
    document_id: uuid.UUID
    content: str
    page_number: int
    section_title: Optional[str] = None
    similarity_score: float
