using FptRagLab.Domain.Enums;

namespace FptRagLab.Application.DTOs.Document
{
    public class DocumentUploadResponseDto
    {
        public Guid Id { get; set; }
        public string FileName { get; set; } = string.Empty;
        public DocumentStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class DocumentListItemDto
    {
        public Guid Id { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string FileType { get; set; } = string.Empty;
        public long FileSizeBytes { get; set; }
        public DocumentStatus Status { get; set; }
        public string? ErrorMessage { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
