namespace CodeRoute.Models
{
    public class DirectionRoute
    {
        public int DirectionId { get; set; }
        public Direction? Direction { get; set; }

        public int RouteId { get; set; }
        public Route Route { get; set; }
    }
}
