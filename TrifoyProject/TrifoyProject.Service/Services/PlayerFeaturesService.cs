using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrifoyProject.Core.Repositories;
using TrifoyProject.Core.Services;
using TrifoyProject.Core.UnitOfWorks;
using TrifoyProject.Entity;

namespace TrifoyProject.Service.Services
{
    public class PlayerFeaturesService : Service<PlayerFeatures>, IPlayerFeaturesService
    {
        public PlayerFeaturesService(IGenericRepository<PlayerFeatures> repository, IUnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork, mapper)
        {
        }
    }
}
