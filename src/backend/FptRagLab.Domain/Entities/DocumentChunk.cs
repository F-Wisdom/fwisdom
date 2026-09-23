using FptRagLab.Domain.Common;

namespace FptRagLab.Domain.Entities
{
    /// <summary>
    /// Represents a chunk of text extracted from a document.
    /// Each chunk retains source metadata and its vector embedding (BR-29).
    /// </summary>
    public class DocumentChunk : BaseEntity
    {
        public Guid DocumentId { get; set; }
        public Guid UserId { get; set; } // Workspace isolation (BR-31, BR-32)
        public int PageNumber { get; set; }
        public string? SectionTitle { get; set; }
        public string Content { get; set; } = string.Empty;
        public int ChunkIndex { get; set; }

        // pgvector embedding - stored as float array
        // In EF Core with pgvector, this maps to a vector column
        public float[] Embedding { get; set; } = Array.Empty<float>();

        // Navigation properties
        public Document Document { get; set; } = null!;
    }
}
