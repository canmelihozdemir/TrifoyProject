using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrifoyProject.Core.DTOs;

namespace TrifoyProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomBaseController : ControllerBase
    {
        [NonAction]
        public IActionResult CreateActionResult<T>(CustomResponseDTO<T> customResponseDTO)
        {
            if (customResponseDTO.StatusCode==204)
            {
                return new ObjectResult(null)
                {
                    StatusCode=customResponseDTO.StatusCode
                };
            }

            return new ObjectResult(customResponseDTO) { StatusCode=customResponseDTO.StatusCode};

        }
    }
}
