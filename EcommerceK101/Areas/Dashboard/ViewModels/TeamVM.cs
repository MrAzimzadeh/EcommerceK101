﻿using EcommerceK101.Models;

namespace EcommerceK101.Areas.Dashboard.ViewModels
{
    public class TeamVM
    {
        public  List<SocialNetwork> SocialNetworks { get; set; }
        public Team Team { get; set; }
        public List<Position> Positions { get; set; }
        public List<TeamsNetwork> TeamsNetworks { get; set; }
    }
}
