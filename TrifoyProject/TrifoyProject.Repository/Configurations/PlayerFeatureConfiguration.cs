using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrifoyProject.Entity;

namespace TrifoyProject.Repository.Configurations
{
    public class PlayerFeatureConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public PlayerFeatureConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(x => x.PlayerFeaturesId).IsRequired(false);
        }
    }
}
