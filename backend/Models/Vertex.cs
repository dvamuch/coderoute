using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeRoute.Models
{
    public class Vertex
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VertexId { get; set; }
        public int RouteId { get; set; }
        public string Name { get; set; }
        public string MarkdownPage { get; set; }
    }
}
