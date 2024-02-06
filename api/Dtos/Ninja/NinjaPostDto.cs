using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Enumerates;

namespace api.Dtos.Ninja
{
    public class NinjaPostDto
    {
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public Rankings Ranking { get; set; }
        public Villages Village { get; set; }
        public Clans Clan { get; set; } = Clans.Random;
    }
}