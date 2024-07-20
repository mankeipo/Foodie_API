using System.ComponentModel.DataAnnotations;

namespace Foodie.Models
{
    public class Address
    {
        public string Location { get; set; }
        public string Borough { get; set; }
        [Key] public int LocationId { get; set; }

    }
}
