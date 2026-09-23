using FptRagLab.Domain.Common;

namespace FptRagLab.Domain.Entities
{
    /// <summary>
    /// Represents a student's quiz attempt (BR-52).
    /// </summary>
    public class QuizAttempt : BaseEntity
    {
        public Guid QuizId { get; set; }
        public Guid UserId { get; set; }
        public int Score { get; set; }
        public int TotalQuestions { get; set; }
        public DateTime SubmittedAt { get; set; }

        // Navigation properties
        public Quiz Quiz { get; set; } = null!;
        public User User { get; set; } = null!;
        public ICollection<AttemptAnswer> Answers { get; set; } = new List<AttemptAnswer>();
    }
}
