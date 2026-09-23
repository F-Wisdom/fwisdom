using FptRagLab.Domain.Common;

namespace FptRagLab.Domain.Entities
{
    /// <summary>
    /// Tracks AI token usage for quota management (BR-60, BR-62).
    /// </summary>
    public class TokenUsageLog : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid? QuizId { get; set; }
        public string ModelName { get; set; } = string.Empty;
        public int InputTokens { get; set; }
        public int OutputTokens { get; set; }
        public int TotalTokens { get; set; }
        public decimal EstimatedCost { get; set; }

        // Navigation properties
        public User User { get; set; } = null!;
    }
}
