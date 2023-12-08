using System.ComponentModel.DataAnnotations;

namespace CodeRoute.Models
{
    public class Direction
    {
        [Key]
        public int DirectionId { get; set; }
        public string DirectionName { get; set; }
    }
}
