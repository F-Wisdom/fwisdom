using FptRagLab.Domain.Common;

namespace FptRagLab.Domain.Entities
{
    /// <summary>
    /// Represents an MCQ question in a quiz, with source citation (BR-43).
    /// </summary>
    public class Question : BaseEntity
    {
        public Guid QuizId { get; set; }
        public string Content { get; set; } = string.Empty;
        public string Explanation { get; set; } = string.Empty;
        public int OrderIndex { get; set; }

        // Navigation properties
        public Quiz Quiz { get; set; } = null!;
        public ICollection<QuestionOption> Options { get; set; } = new List<QuestionOption>();
        public Citation? Citation { get; set; }
    }
}
