using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foodie.Models
{
    public class Restaurant
    {
        [Key] public int RestaurantId { get; set; }
        public string Restaurant_Name { get; set; }
        public string FoodType { get; set; }
        public int Overall_Rating { get; set; }
        public int LocationId { get; set; }

        [ForeignKey("LocationId")]
        public Address? Address { get; set; }
    }
}
