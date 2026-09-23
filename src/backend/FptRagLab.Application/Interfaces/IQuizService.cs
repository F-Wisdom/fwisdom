using FptRagLab.Application.DTOs.Quiz;

namespace FptRagLab.Application.Interfaces
{
    /// <summary>
    /// Quiz generation and management service interface.
    /// Handles UC-09 Configure Quiz, UC-10 Generate Quiz, UC-11 Take Quiz,
    /// UC-12 View Result, UC-13 View Quiz History, UC-14 Review Previous Quiz.
    /// </summary>
    public interface IQuizService
    {
        Task<QuizDto> GenerateQuizAsync(Guid userId, GenerateQuizRequestDto request);
        Task<QuizDto> GetQuizAsync(Guid userId, Guid quizId);
        Task<QuizResultDto> SubmitQuizAsync(Guid userId, SubmitQuizRequestDto request);
        Task<QuizResultDto> GetAttemptResultAsync(Guid userId, Guid attemptId);
        Task<IEnumerable<QuizHistoryItemDto>> GetQuizHistoryAsync(Guid userId);
    }
}
