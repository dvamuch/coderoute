using System.ComponentModel.DataAnnotations;

namespace CodeRoute.Models
{
    public class RouteStatus
    {
        [Key]
        public int RouteStatusId { get; set; }
        public string StatusName { get; set;}
    }
}
