"""
PDF and DOCX parser service.
Extracts text and metadata from uploaded documents (UC-24).
"""
from dataclasses import dataclass
from typing import List, Optional


@dataclass
class ParsedPage:
    """Represents a parsed page from a document."""
    page_number: int
    content: str
    section_title: Optional[str] = None


class DocumentParser:
    """
    Parses PDF and DOCX files to extract text and metadata.
    Optionally integrates with OCR service for scanned documents (BR-87).
    """

    async def parse(self, file_path: str, file_type: str) -> List[ParsedPage]:
        """
        Parse a document and return a list of pages with content.

        Args:
            file_path: Path to the uploaded file.
            file_type: 'pdf' or 'docx'

        Returns:
            List of ParsedPage objects with text content.
        """
        if file_type.lower() == "pdf":
            return await self._parse_pdf(file_path)
        elif file_type.lower() in ("docx", "doc"):
            return await self._parse_docx(file_path)
        else:
            raise ValueError(f"Unsupported file type: {file_type}")

    async def _parse_pdf(self, file_path: str) -> List[ParsedPage]:
        """
        Parse a PDF file.
        TODO: Implement using PyMuPDF (fitz) or pdfplumber.
        If scanned, send to OCR service first.
        """
        # Example with PyMuPDF:
        # import fitz
        # doc = fitz.open(file_path)
        # pages = [ParsedPage(i+1, page.get_text()) for i, page in enumerate(doc)]
        raise NotImplementedError("PDF parsing not yet implemented")

    async def _parse_docx(self, file_path: str) -> List[ParsedPage]:
        """
        Parse a DOCX file.
        TODO: Implement using python-docx.
        """
        # Example with python-docx:
        # from docx import Document
        # doc = Document(file_path)
        # ...
        raise NotImplementedError("DOCX parsing not yet implemented")
