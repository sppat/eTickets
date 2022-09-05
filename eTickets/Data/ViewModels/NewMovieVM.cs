using eTickets.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class NewMovieVM
    {
        [Display(Name = "Movie Name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name = "Movie Description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Display(Name = "Movie Price")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        [Display(Name = "Movie Poster URL")]
        [Required(ErrorMessage = "Movie Poster URL is required")]
        public string ImageUrl { get; set; }

        [Display(Name = "Movie Start Date")]
        [Required(ErrorMessage = "Movie Start Date is required")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Movie End Date")]
        [Required(ErrorMessage = "Movie End Date is required")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Movie Category")]
        [Required(ErrorMessage = "Movie Category is required")]
        public MovieCategory MovieCategory { get; set; }

        [Display(Name = "Cinema")]
        [Required(ErrorMessage = "Cinema is required")]
        public int CinemaId { get; set; }

        [Display(Name = "Producer")]
        [Required(ErrorMessage = "Producer is required")]
        public int ProducerId { get; set; }

        [Display(Name = "Select Actors")]
        [Required(ErrorMessage = "Actor(s) is required")]
        public List<int> ActorIds { get; set; }
    }
}
