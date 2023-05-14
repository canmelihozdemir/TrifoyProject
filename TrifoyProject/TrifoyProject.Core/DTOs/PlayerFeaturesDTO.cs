using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrifoyProject.Core.DTOs
{
    public class PlayerFeaturesDTO:BaseDTO
    {
        public string? Role { get; set; }
        public string? Rank { get; set; }
        public int PlayedGame { get; set; }
        public int Win { get; set; }
        public int Lose { get; set; }
        public int Goal { get; set; }
        public int Assist { get; set; }
        public int CS { get; set; }
        public int Coin { get; set; }
    }
}
