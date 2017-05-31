using System.Collections.Generic;
using HoidayResorts.Data_Entities;

namespace HoidayResorts.Models
{
    public class ResortViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Location { get; set; }
        public int CheapestRoom { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public int CountOfReviews { get; set; }
        public double? OverallRating { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}