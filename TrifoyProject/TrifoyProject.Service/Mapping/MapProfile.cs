using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrifoyProject.Core.DTOs;
using TrifoyProject.Entity;

namespace TrifoyProject.Service.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<PlayerFeatures, PlayerFeaturesDTO>().ReverseMap();
        }
    }
}
