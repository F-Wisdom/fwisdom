using FptRagLab.Domain.Common;
using FptRagLab.Domain.Enums;

namespace FptRagLab.Domain.Entities
{
    /// <summary>
    /// Represents an uploaded document in a student's personal workspace.
    /// Documents are isolated per student (BR-17).
    /// </summary>
    public class Document : BaseEntity
    {
        public Guid UserId { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string StoragePath { get; set; } = string.Empty; // UUID-based path (BR-19)
        public string FileType { get; set; } = string.Empty; // PDF or DOCX (BR-84)
        public long FileSizeBytes { get; set; }
        public DocumentStatus Status { get; set; } = DocumentStatus.Processing;
        public string? ErrorMessage { get; set; }

        // Navigation properties
        public User User { get; set; } = null!;
        public ICollection<DocumentChunk> Chunks { get; set; } = new List<DocumentChunk>();
    }
}
