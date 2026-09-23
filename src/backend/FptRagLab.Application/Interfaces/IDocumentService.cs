using FptRagLab.Application.DTOs.Document;

namespace FptRagLab.Application.Interfaces
{
    /// <summary>
    /// Document management service interface.
    /// Handles UC-07 Upload Personal Document, UC-08 View Document List.
    /// Triggers RAG processing pipeline after upload (BR-22).
    /// </summary>
    public interface IDocumentService
    {
        Task<DocumentUploadResponseDto> UploadDocumentAsync(Guid userId, Stream fileStream, string fileName, string contentType);
        Task<IEnumerable<DocumentListItemDto>> GetUserDocumentsAsync(Guid userId);
        Task<DocumentListItemDto> GetDocumentStatusAsync(Guid userId, Guid documentId);
        Task DeleteDocumentAsync(Guid userId, Guid documentId);
    }
}
