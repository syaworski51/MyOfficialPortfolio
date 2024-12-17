using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyOfficialPortfolio.Models
{
    [Table("Links")]
    public class Link
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
    }
}
