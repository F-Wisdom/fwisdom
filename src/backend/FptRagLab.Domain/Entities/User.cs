using System;
using FptRagLab.Domain.Common;
using FptRagLab.Domain.Enums;

namespace FptRagLab.Domain.Entities
{
    /// <summary>
    /// Represents a user (Student or Administrator) in the system.
    /// </summary>
    public class User : BaseEntity
    {
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public UserRole Role { get; set; } = UserRole.Student;
        public bool IsActive { get; set; } = true;
        public DateTime? LastLoginAt { get; set; }

        // Token quota for AI generation
        public int TokenQuota { get; set; } = 0;
        public int TokenUsed { get; set; } = 0;

        // Navigation properties
        public ICollection<Document> Documents { get; set; } = new List<Document>();
        public ICollection<Quiz> Quizzes { get; set; } = new List<Quiz>();
        public ICollection<QuizAttempt> QuizAttempts { get; set; } = new List<QuizAttempt>();
    }
}
