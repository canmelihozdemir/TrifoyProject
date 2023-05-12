using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrifoyProject.Core.DTOs;
using TrifoyProject.Core.Services;
using TrifoyProject.Entity;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TrifoyProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : CustomBaseController
    {
        private readonly UserManager<AppUser> _userManager;

        private readonly IPlayerFeaturesService _service;

        public PlayersController(IPlayerFeaturesService service, UserManager<AppUser> userManager)
        {
            _service = service;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return CreateActionResult(CustomResponseDTO<List<PlayerFeatures>>.Success(200, (await _service.GetAllAsync()).ToList()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return CreateActionResult(CustomResponseDTO<PlayerFeatures>.Success(200, await _service.GetByIdAsync(id)));
        }

        [HttpPost]
        public async Task<IActionResult> SaveAsync(SignUpDTO request)
        {
            var identityResult = await _userManager.CreateAsync(new() { UserName=request.UserName},request.Password);

            if (identityResult.Succeeded)
            {
                var playerFeature=await _service.AddAsync(new() { CreatedDate=new DateTime(),Role="player",Rank="Yeni"});
                var user = await _userManager.Users.Where(name => name.UserName == request.UserName).FirstOrDefaultAsync();
                user!.PlayerFeaturesId=playerFeature.Id;
                await _userManager.UpdateAsync(user);
                return Ok("Kayıt başarılı!");
            }

            return BadRequest(identityResult.Errors.Select(x => x.Description));
        }

        [HttpPost("RegisterAsync")]
        public async Task<IActionResult> RegisterAsync(PlayerRegisterDTO playerRegisterDTO)
        {
            return CreateActionResult(CustomResponseDTO<PlayerFeatures>.Success(201,await _service.RegisterAsync(playerRegisterDTO))) ;
        }
    }
}
