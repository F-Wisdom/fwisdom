using FptRagLab.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FptRagLab.API.Controllers
{
    /// <summary>
    /// Handles personal document upload and management.
    /// UC-07: Upload Personal Document, UC-08: View Document List.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/documents")]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentService _documentService;

        public DocumentController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        /// <summary>UC-07: Upload a PDF or DOCX document to personal workspace.</summary>
        [HttpPost]
        public async Task<IActionResult> UploadDocument(IFormFile file)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            using var stream = file.OpenReadStream();
            var result = await _documentService.UploadDocumentAsync(userId, stream, file.FileName, file.ContentType);
            return Ok(result);
        }

        /// <summary>UC-08: Get the list of personal documents and their statuses.</summary>
        [HttpGet]
        public async Task<IActionResult> GetDocuments()
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var result = await _documentService.GetUserDocumentsAsync(userId);
            return Ok(result);
        }

        /// <summary>UC-08: Get the processing status of a specific document.</summary>
        [HttpGet("{documentId}")]
        public async Task<IActionResult> GetDocumentStatus(Guid documentId)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var result = await _documentService.GetDocumentStatusAsync(userId, documentId);
            return Ok(result);
        }

        /// <summary>Delete a document from personal workspace.</summary>
        [HttpDelete("{documentId}")]
        public async Task<IActionResult> DeleteDocument(Guid documentId)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            await _documentService.DeleteDocumentAsync(userId, documentId);
            return NoContent();
        }
    }
}
