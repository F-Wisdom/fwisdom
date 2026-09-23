"""
Document processing service.
Handles: Parse → Chunk → Embed → Store (BR-24).
"""
from app.schemas.schemas import ProcessDocumentRequest, ProcessDocumentResponse
import uuid


class DocumentProcessor:
    """
    Orchestrates the full document ingestion pipeline:
    1. Parse PDF/DOCX (UC-24)
    2. Chunk document (UC-25)
    3. Generate embeddings (UC-26)
    4. Store in pgvector (UC-27)
    """

    def __init__(self, parser, chunker, embedder, vector_store):
        self.parser = parser
        self.chunker = chunker
        self.embedder = embedder
        self.vector_store = vector_store

    async def process(self, request: ProcessDocumentRequest) -> ProcessDocumentResponse:
        """Process a document through the full RAG ingestion pipeline."""
        try:
            # Step 1: Parse document
            pages = await self.parser.parse(request.file_path, request.file_type)

            # Step 2: Chunk document
            chunks = await self.chunker.chunk(pages)

            # Step 3: Generate embeddings
            embeddings = await self.embedder.embed_batch([c.content for c in chunks])

            # Step 4: Store chunks and embeddings in pgvector
            await self.vector_store.store_chunks(
                document_id=request.document_id,
                user_id=request.user_id,
                chunks=chunks,
                embeddings=embeddings
            )

            return ProcessDocumentResponse(
                document_id=request.document_id,
                status="completed",
                chunk_count=len(chunks)
            )

        except Exception as e:
            return ProcessDocumentResponse(
                document_id=request.document_id,
                status="failed",
                error_message=str(e)
            )
