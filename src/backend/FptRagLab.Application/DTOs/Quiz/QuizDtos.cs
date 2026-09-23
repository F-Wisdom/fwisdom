using FptRagLab.Domain.Enums;

namespace FptRagLab.Application.DTOs.Quiz
{
    public class GenerateQuizRequestDto
    {
        public Guid CourseId { get; set; }
        public List<Guid> LearningOutcomeIds { get; set; } = new();
        public int QuestionCount { get; set; } = 10;
        public QuizDifficulty Difficulty { get; set; } = QuizDifficulty.Medium;
    }

    public class QuizDto
    {
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public string CourseTitle { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public QuizDifficulty Difficulty { get; set; }
        public int QuestionCount { get; set; }
        public List<QuestionDto> Questions { get; set; } = new();
        public DateTime CreatedAt { get; set; }
    }

    public class QuestionDto
    {
        public Guid Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public List<QuestionOptionDto> Options { get; set; } = new();
        // Note: Correct answer and explanation are hidden during the quiz
    }

    public class QuestionOptionDto
    {
        public Guid Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public int OrderIndex { get; set; }
    }

    public class SubmitQuizRequestDto
    {
        public Guid QuizId { get; set; }
        public List<AnswerSubmissionDto> Answers { get; set; } = new();
    }

    public class AnswerSubmissionDto
    {
        public Guid QuestionId { get; set; }
        public Guid? SelectedOptionId { get; set; }
    }

    public class QuizResultDto
    {
        public Guid AttemptId { get; set; }
        public Guid QuizId { get; set; }
        public int Score { get; set; }
        public int TotalQuestions { get; set; }
        public List<QuestionResultDto> Results { get; set; } = new();
        public DateTime SubmittedAt { get; set; }
    }

    public class QuestionResultDto
    {
        public Guid QuestionId { get; set; }
        public string Content { get; set; } = string.Empty;
        public Guid? SelectedOptionId { get; set; }
        public Guid CorrectOptionId { get; set; }
        public bool IsCorrect { get; set; }
        public string Explanation { get; set; } = string.Empty;
        public CitationDto? Citation { get; set; }
    }

    public class CitationDto
    {
        public string DocumentFileName { get; set; } = string.Empty;
        public int PageNumber { get; set; }
        public string? SectionTitle { get; set; }
        public string RelevantText { get; set; } = string.Empty;
    }

    public class QuizHistoryItemDto
    {
        public Guid AttemptId { get; set; }
        public Guid QuizId { get; set; }
        public string QuizTitle { get; set; } = string.Empty;
        public string CourseTitle { get; set; } = string.Empty;
        public int Score { get; set; }
        public int TotalQuestions { get; set; }
        public DateTime SubmittedAt { get; set; }
    }
}
