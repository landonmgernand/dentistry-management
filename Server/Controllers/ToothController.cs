using DentistryManagement.Server.Mappers;
using DentistryManagement.Server.Services.Interfaces;
using DentistryManagement.Shared.ViewModels.Comments;
using DentistryManagement.Shared.ViewModels.Diseases;
using DentistryManagement.Shared.ViewModels.Teeth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DentistryManagement.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ToothController : ControllerBase
    {
        private readonly IToothService _toothService;
        private readonly ICommentService _commentService;

        public ToothController(IToothService toothService, ICommentService commentService)
        {
            _toothService = toothService;
            _commentService = commentService;
        }

        [HttpGet("{toothId}/diseases")]
        public ActionResult<IEnumerable<DiseaseViewModel>> GetToothDiseases(int toothId)
        {
            return _toothService.GetDiseases(toothId).Select(d => DiseaseMapper.DTOtoDiseaseVM(d)).ToArray();
        }

        [HttpPost("{toothId}/diseases")]
        public IActionResult CreateToothDiseases(int toothId, [FromBody] CreateToothDiseasesViewModel createToothDiseaseViewModel)
        {
            if (toothId != createToothDiseaseViewModel.ToothId)
            {
                return BadRequest();
            }

            if (!_toothService.Exist(toothId))
            {
                return NotFound();
            }

            var toothDiseasesDTO = ToothMapper.CreateToothDiseasesVMToDTO(createToothDiseaseViewModel);
            _toothService.CreateToothDiseases(toothDiseasesDTO);

            return Ok(ModelState);
        }

        [HttpGet("{toothId}/comments")]
        public ActionResult<IEnumerable<CommentViewModel>> GetComments(int toothId)
        {
            if (!_toothService.Exist(toothId))
            {
                return NotFound();
            }

            return _toothService.GetComments(toothId).Select(c => CommentMapper.DTOtoCommentVM(c)).ToList();
        }

        [HttpGet("{toothId}/comments-count")]
        public ActionResult<int> GetCommentsCount(int toothId)
        {
            if (!_toothService.Exist(toothId))
            {
                return NotFound();
            }

            return _toothService.GetComments(toothId).Count();
        }

        [HttpPost("{toothId}/comments")]
        public IActionResult CreateComment(int toothId, [FromBody] CreateCommentViewModel createComment)
        {
            if (toothId != createComment.ToothId)
            {
                return BadRequest();
            }

            if (!_toothService.Exist(toothId))
            {
                return NotFound();
            }

            var commentDTO = CommentMapper.CreateCommentVMToDTO(createComment);
            _commentService.Create(commentDTO);

            return Ok(ModelState);
        }

        [HttpDelete("{toothId}/comments/{id}")]
        public IActionResult DeleteComment(int toothId, int id)
        {
            if (!_commentService.Exist(toothId, id))
            {
                return NotFound();
            }

            _commentService.Delete(id);

            return NoContent();
        }
    }
}
