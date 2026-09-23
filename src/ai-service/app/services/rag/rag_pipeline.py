"""
RAG (Retrieval-Augmented Generation) pipeline service.
Handles quiz generation using document retrieval and LLM (UC-28 to UC-35).
"""
from app.schemas.schemas import (
    GenerateQuizRequest,
    GenerateQuizResponse,
    GeneratedQuestionSchema,
)
from typing import List


class RAGPipeline:
    """
    Orchestrates the full RAG-based quiz generation pipeline:
    1. Create retrieval query from course + LOs (UC-13)
    2. Generate query embedding
    3. Search pgvector for relevant chunks (UC-28)
    4. Filter by user workspace (BR-31, BR-32)
    5. Build RAG context (UC-29)
    6. Apply prompt constraints (UC-30)
    7. Generate questions with LLM (UC-31)
    8. Validate grounding (UC-32)
    9. Map citations (UC-33)
    10. Reject/regenerate unsupported questions (UC-34)
    """

    def __init__(self, embedder, vector_store, llm_client):
        self.embedder = embedder
        self.vector_store = vector_store
        self.llm_client = llm_client

    async def generate_quiz(self, request: GenerateQuizRequest) -> GenerateQuizResponse:
        """
        Full RAG quiz generation pipeline.
        Returns a list of grounded questions with citations.
        """
        # Step 1: Build retrieval query from course and LOs
        retrieval_query = self._build_retrieval_query(
            request.course_title,
            request.learning_outcomes
        )

        # Step 2: Generate query embedding
        query_embedding = await self.embedder.embed(retrieval_query)

        # Step 3 + 4: Retrieve relevant chunks (filtered by user_id for isolation)
        chunks = await self.vector_store.similarity_search(
            embedding=query_embedding,
            user_id=request.user_id,
            top_k=5
        )

        if not chunks:
            return GenerateQuizResponse(
                quiz_id=request.quiz_id,
                questions=[],
                total_input_tokens=0,
                total_output_tokens=0,
                model_name="",
                status="insufficient_context"
            )

        # Step 5: Build RAG context
        context = self._build_rag_context(chunks, request.course_title, request.learning_outcomes)

        # Step 6 + 7: Generate questions with LLM
        llm_response = await self.llm_client.generate_questions(
            context=context,
            question_count=request.question_count,
            difficulty=request.difficulty,
            learning_outcomes=request.learning_outcomes
        )

        # Step 8 + 9 + 10: Validate grounding, map citations, filter questions
        validated_questions = await self._validate_and_map_citations(
            llm_response.questions, chunks
        )

        return GenerateQuizResponse(
            quiz_id=request.quiz_id,
            questions=validated_questions,
            total_input_tokens=llm_response.input_tokens,
            total_output_tokens=llm_response.output_tokens,
            model_name=llm_response.model_name,
            status="success"
        )

    def _build_retrieval_query(self, course_title: str, learning_outcomes: List[str]) -> str:
        """Create a natural language retrieval query from course and LOs."""
        lo_text = " ".join(learning_outcomes)
        return f"Course: {course_title}. Learning Outcomes: {lo_text}"

    def _build_rag_context(self, chunks, course_title: str, learning_outcomes: List[str]) -> str:
        """Combine retrieved chunks into LLM context."""
        context_parts = [
            f"Course: {course_title}",
            f"Learning Outcomes: {', '.join(learning_outcomes)}",
            "\n--- Relevant Course Material ---\n"
        ]
        for i, chunk in enumerate(chunks, 1):
            context_parts.append(f"[Source {i}: {chunk.document_file_name}, Page {chunk.page_number}]\n{chunk.content}")
        return "\n\n".join(context_parts)

    async def _validate_and_map_citations(self, questions, chunks) -> List[GeneratedQuestionSchema]:
        """
        Validate questions against source chunks and map citations.
        Rejects questions that cannot be grounded in the retrieved content (UC-34).
        """
        # TODO: Implement grounding validation logic
        # This may involve a second LLM call to check grounding (UC-32)
        validated = []
        for q in questions:
            # TODO: Check if question can be supported by any retrieved chunk
            # If not, skip/reject it
            validated.append(q)
        return validated
