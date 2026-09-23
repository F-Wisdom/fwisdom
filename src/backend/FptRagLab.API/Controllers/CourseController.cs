using Microsoft.AspNetCore.Mvc;

namespace FptRagLab.API.Controllers
{
    /// <summary>
    /// Handles course browsing for students.
    /// UC-05: View Courses, UC-06: View Course Details.
    /// </summary>
    [ApiController]
    [Route("api/courses")]
    public class CourseController : ControllerBase
    {
        // TODO: Inject ICourseService

        /// <summary>UC-05: Get list of available courses.</summary>
        [HttpGet]
        public IActionResult GetCourses()
        {
            // TODO: Implement - return list of active courses
            throw new NotImplementedException();
        }

        /// <summary>UC-06: Get course details including learning outcomes.</summary>
        [HttpGet("{courseId}")]
        public IActionResult GetCourse(Guid courseId)
        {
            // TODO: Implement - return course details with LOs
            throw new NotImplementedException();
        }
    }
}
