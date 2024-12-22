using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyOfficialPortfolio.Models
{
    [Table("Projects")]
    public class Project
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime DateStarted { get; set; }
        public DateTime? DateCompleted { get; set; }
        public string Tagline { get; set; }
        public string Description { get; set; }
        public List<Media> Images { get; set; }
        public List<Link> Links { get; set; }
    }
}
