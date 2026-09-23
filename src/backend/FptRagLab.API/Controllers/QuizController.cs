using FptRagLab.Application.DTOs.Quiz;
using FptRagLab.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FptRagLab.API.Controllers
{
    /// <summary>
    /// Handles quiz generation, taking, submission, and history.
    /// UC-09, UC-10, UC-11, UC-12, UC-13, UC-14.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/quizzes")]
    public class QuizController : ControllerBase
    {
        private readonly IQuizService _quizService;

        public QuizController(IQuizService quizService)
        {
            _quizService = quizService;
        }

        /// <summary>UC-10: Generate a quiz via RAG pipeline.</summary>
        [HttpPost("generate")]
        public async Task<IActionResult> GenerateQuiz([FromBody] GenerateQuizRequestDto request)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var result = await _quizService.GenerateQuizAsync(userId, request);
            return Ok(result);
        }

        /// <summary>UC-11: Get a quiz to take.</summary>
        [HttpGet("{quizId}")]
        public async Task<IActionResult> GetQuiz(Guid quizId)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var result = await _quizService.GetQuizAsync(userId, quizId);
            return Ok(result);
        }

        /// <summary>UC-11+UC-12: Submit quiz answers and get results.</summary>
        [HttpPost("submit")]
        public async Task<IActionResult> SubmitQuiz([FromBody] SubmitQuizRequestDto request)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var result = await _quizService.SubmitQuizAsync(userId, request);
            return Ok(result);
        }

        /// <summary>UC-13: Get quiz attempt history.</summary>
        [HttpGet("history")]
        public async Task<IActionResult> GetQuizHistory()
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var result = await _quizService.GetQuizHistoryAsync(userId);
            return Ok(result);
        }

        /// <summary>UC-14: Review a specific quiz attempt result.</summary>
        [HttpGet("attempts/{attemptId}")]
        public async Task<IActionResult> GetAttemptResult(Guid attemptId)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var result = await _quizService.GetAttemptResultAsync(userId, attemptId);
            return Ok(result);
        }
    }
}
