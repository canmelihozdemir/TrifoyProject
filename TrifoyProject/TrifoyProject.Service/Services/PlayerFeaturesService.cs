using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TrifoyProject.Core.DTOs;
using TrifoyProject.Core.Repositories;
using TrifoyProject.Core.Services;
using TrifoyProject.Core.UnitOfWorks;
using TrifoyProject.Entity;
using TrifoyProject.Service.Exceptions;

namespace TrifoyProject.Service.Services
{
    public class PlayerFeaturesService : Service<PlayerFeatures>, IPlayerFeaturesService
    {
        private readonly UserManager<AppUser> _userManager;
        public PlayerFeaturesService(IGenericRepository<PlayerFeatures> repository, IUnitOfWork unitOfWork, IMapper mapper, UserManager<AppUser> userManager) : base(repository, unitOfWork, mapper)
        {
            _userManager = userManager;
        }

        public async Task<AppUser> GetUserByNameAsync(string userName)
        {
            var hasUser = await _userManager.FindByNameAsync(userName);

            if (hasUser == null)
            {
                throw new NotFoundException("Böyle bir kullanıcı adı bulunamadı!");
            }

            return hasUser;
        }

        public async Task<AppUser> LoginAsync(PlayerLoginDTO playerLoginDTO)
        {
            var hasUser=await GetUserByNameAsync(playerLoginDTO.UserName);

            return hasUser;
        }


        public async Task<PlayerFeaturesDTO> RegisterAsync(PlayerRegisterDTO playerRegisterDTO)//REFACTOR TO REPO LAYER
        {
            var identityResult = await _userManager.CreateAsync(new() { UserName = playerRegisterDTO.UserName }, playerRegisterDTO.Password!);

            if (identityResult.Succeeded)
            {
                var playerFeature = await AddAsync(new() { CreatedDate = new DateTime(), Role = "player", Rank = "Yeni" });
                var user = await _userManager.Users.Where(name => name.UserName == playerRegisterDTO.UserName).FirstOrDefaultAsync();
                user!.PlayerFeaturesId = playerFeature.Id;
                await _userManager.UpdateAsync(user);
                
                return _mapper.Map<PlayerFeaturesDTO>(playerFeature);
            }

            var errorMessages = identityResult.Errors.Select(x => x.Description).ToString();
            throw new ClientSideException(errorMessages!);
        }
    }
}
