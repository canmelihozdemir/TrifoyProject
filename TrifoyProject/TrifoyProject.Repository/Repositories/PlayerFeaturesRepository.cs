using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrifoyProject.Core.Repositories;
using TrifoyProject.Entity;

namespace TrifoyProject.Repository.Repositories
{
    public class PlayerFeaturesRepository : GenericRepository<PlayerFeatures>, IPlayerFeaturesRepository
    {
        public PlayerFeaturesRepository(AppIdentityDbContext appIdentityDbContext) : base(appIdentityDbContext)
        {
        }
    }
}
