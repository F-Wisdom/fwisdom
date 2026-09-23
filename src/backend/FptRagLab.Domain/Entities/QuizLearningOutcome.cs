namespace FptRagLab.Domain.Entities
{
    /// <summary>
    /// Join table linking quizzes to learning outcomes.
    /// </summary>
    public class QuizLearningOutcome
    {
        public Guid QuizId { get; set; }
        public Guid LearningOutcomeId { get; set; }

        // Navigation properties
        public Quiz Quiz { get; set; } = null!;
        public LearningOutcome LearningOutcome { get; set; } = null!;
    }
}
