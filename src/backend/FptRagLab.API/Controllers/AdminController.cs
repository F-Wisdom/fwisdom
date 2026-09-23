using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FptRagLab.API.Controllers
{
    /// <summary>
    /// Admin-only controller for managing users, courses, learning outcomes,
    /// token quotas, system policies, and viewing statistics.
    /// UC-15 to UC-20.
    /// </summary>
    [Authorize(Roles = "Administrator")]
    [ApiController]
    [Route("api/admin")]
    public class AdminController : ControllerBase
    {
        // TODO: Inject IAdminService, IUserManagementService

        /// <summary>UC-17: Get list of all users.</summary>
        [HttpGet("users")]
        public IActionResult GetUsers()
        {
            // TODO: Implement
            throw new NotImplementedException();
        }

        /// <summary>UC-17: Update user status (activate/deactivate).</summary>
        [HttpPut("users/{userId}/status")]
        public IActionResult UpdateUserStatus(Guid userId, [FromBody] bool isActive)
        {
            // TODO: Implement
            throw new NotImplementedException();
        }

        /// <summary>UC-15: Create a new course.</summary>
        [HttpPost("courses")]
        public IActionResult CreateCourse()
        {
            // TODO: Implement
            throw new NotImplementedException();
        }

        /// <summary>UC-16: Create or update learning outcomes for a course.</summary>
        [HttpPost("courses/{courseId}/learning-outcomes")]
        public IActionResult ManageLearningOutcomes(Guid courseId)
        {
            // TODO: Implement
            throw new NotImplementedException();
        }

        /// <summary>UC-18: Configure token quota for a user.</summary>
        [HttpPut("users/{userId}/token-quota")]
        public IActionResult SetTokenQuota(Guid userId, [FromBody] int quota)
        {
            // TODO: Implement
            throw new NotImplementedException();
        }

        /// <summary>UC-19: Get system statistics.</summary>
        [HttpGet("statistics")]
        public IActionResult GetStatistics()
        {
            // TODO: Implement - return user, document, quiz, token stats
            throw new NotImplementedException();
        }

        /// <summary>UC-20: Get/Update system policies.</summary>
        [HttpGet("policies")]
        public IActionResult GetPolicies()
        {
            // TODO: Implement
            throw new NotImplementedException();
        }
    }
}
