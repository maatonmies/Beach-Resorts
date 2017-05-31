using System.ComponentModel.DataAnnotations;

namespace HoidayResorts.Data_Entities
{
    public class Review
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ReviewerName { get; set; }
        public string ReviewText { get; set; }
        [Required(ErrorMessage = "Rating is required")]
        [Range(0,10)]
        public double Rating { get; set; }
        public int ResortId { get; set; }
    }
}