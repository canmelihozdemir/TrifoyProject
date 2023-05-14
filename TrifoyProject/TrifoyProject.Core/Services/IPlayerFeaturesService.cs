using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrifoyProject.Core.DTOs;
using TrifoyProject.Entity;

namespace TrifoyProject.Core.Services
{
    public interface IPlayerFeaturesService:IService<PlayerFeatures>
    {
        Task<PlayerFeaturesDTO> RegisterAsync(PlayerRegisterDTO playerRegisterDTO);
    }
}
