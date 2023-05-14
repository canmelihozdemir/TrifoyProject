using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public async Task<PlayerFeaturesDTO> RegisterAsync(PlayerRegisterDTO playerRegisterDTO)
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
