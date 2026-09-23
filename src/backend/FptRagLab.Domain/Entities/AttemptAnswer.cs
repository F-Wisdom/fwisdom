using FptRagLab.Domain.Common;

namespace FptRagLab.Domain.Entities
{
    /// <summary>
    /// Represents a student's answer for a specific question in a quiz attempt.
    /// </summary>
    public class AttemptAnswer : BaseEntity
    {
        public Guid QuizAttemptId { get; set; }
        public Guid QuestionId { get; set; }
        public Guid? SelectedOptionId { get; set; } // Null = unanswered
        public bool IsCorrect { get; set; }

        // Navigation properties
        public QuizAttempt QuizAttempt { get; set; } = null!;
        public Question Question { get; set; } = null!;
        public QuestionOption? SelectedOption { get; set; }
    }
}
