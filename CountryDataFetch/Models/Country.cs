using System.ComponentModel.DataAnnotations;

namespace CountryDataFetch.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Region { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
