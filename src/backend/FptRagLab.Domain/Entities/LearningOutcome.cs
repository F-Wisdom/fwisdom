using FptRagLab.Domain.Common;

namespace FptRagLab.Domain.Entities
{
    /// <summary>
    /// Represents a learning outcome associated with a course.
    /// Each course must have at least one LO (BR-14).
    /// </summary>
    public class LearningOutcome : BaseEntity
    {
        public Guid CourseId { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        // Navigation properties
        public Course Course { get; set; } = null!;
    }
}
