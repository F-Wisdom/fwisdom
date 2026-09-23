using FptRagLab.Domain.Common;

namespace FptRagLab.Domain.Entities
{
    /// <summary>
    /// Represents an answer option for a multiple-choice question.
    /// </summary>
    public class QuestionOption : BaseEntity
    {
        public Guid QuestionId { get; set; }
        public string Content { get; set; } = string.Empty;
        public bool IsCorrect { get; set; }
        public int OrderIndex { get; set; }

        // Navigation properties
        public Question Question { get; set; } = null!;
    }
}
