using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyOfficialPortfolio.Models
{
    [Table("Images")]
    public class Image
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
        public DateTime DateUploaded { get; set; }
        public string Path { get; set; }
        public string? Caption { get; set; }
    }
}
