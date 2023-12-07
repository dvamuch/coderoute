﻿namespace CodeRoute.DTO
{
    public class Roadmap
    {
        public int RouteId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? StatusId { get; set; }
        public int? Percentage { get; set; }
    }
}
