using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HoidayResorts.Data_Entities
{
    public class Resort
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Country is required")]
        public string Country { get; set; }
        public string Location { get; set; }
        [Required(ErrorMessage = "Lowest room price is required")]
        public int CheapestRoom { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}