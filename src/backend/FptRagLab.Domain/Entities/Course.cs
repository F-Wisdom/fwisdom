using FptRagLab.Domain.Common;
using FptRagLab.Domain.Enums;

namespace FptRagLab.Domain.Entities
{
    /// <summary>
    /// Represents a course available on the platform.
    /// </summary>
    public class Course : BaseEntity
    {
        public string Code { get; set; } = string.Empty; // Must be unique (BR-13)
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public CourseStatus Status { get; set; } = CourseStatus.Active;

        // Navigation properties
        public ICollection<LearningOutcome> LearningOutcomes { get; set; } = new List<LearningOutcome>();
        public ICollection<Quiz> Quizzes { get; set; } = new List<Quiz>();
    }
}
