using FptRagLab.Domain.Common;

namespace FptRagLab.Domain.Entities
{
    /// <summary>
    /// Citation linking a question to its source document chunk (BR-39, BR-43).
    /// </summary>
    public class Citation : BaseEntity
    {
        public Guid QuestionId { get; set; }
        public Guid DocumentChunkId { get; set; }
        public string DocumentFileName { get; set; } = string.Empty;
        public int PageNumber { get; set; }
        public string? SectionTitle { get; set; }
        public string RelevantText { get; set; } = string.Empty;

        // Navigation properties
        public Question Question { get; set; } = null!;
        public DocumentChunk DocumentChunk { get; set; } = null!;
    }
}
