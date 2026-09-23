using FptRagLab.Domain.Common;
using FptRagLab.Domain.Enums;

namespace FptRagLab.Domain.Entities
{
    /// <summary>
    /// Represents a generated quiz for a student based on a course and learning outcomes.
    /// </summary>
    public class Quiz : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid CourseId { get; set; }
        public string Title { get; set; } = string.Empty;
        public QuizDifficulty Difficulty { get; set; } = QuizDifficulty.Medium;
        public int QuestionCount { get; set; }

        // Navigation properties
        public User User { get; set; } = null!;
        public Course Course { get; set; } = null!;
        public ICollection<Question> Questions { get; set; } = new List<Question>();
        public ICollection<QuizLearningOutcome> QuizLearningOutcomes { get; set; } = new List<QuizLearningOutcome>();
        public ICollection<QuizAttempt> Attempts { get; set; } = new List<QuizAttempt>();
    }
}
