using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrifoyProject.Entity
{
    public class AppUser:IdentityUser
    {
        public int PlayerFeaturesId { get; set; }
        public PlayerFeatures? PlayerFeatures{ get; set; }
    }
}
