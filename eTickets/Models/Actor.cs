using System.ComponentModel.DataAnnotations;

namespace eTickets.Models;

public class Actor
{
    [Key]
    public int Id { get; set; }

    [Display(Name = "Profile Picture")]
    [Required(ErrorMessage = "Profile picture is required")]
    public string ProfilePictureUrl { get; set; }

    [Display(Name = "Full Name")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Full name must be between 3 and 50 characters")]
    [Required(ErrorMessage = "Full name is required")]
    public string FullName { get; set; }

    [Display(Name = "Bio")]
    [Required(ErrorMessage = "Bio is required")]
    public string Bio { get; set; }

    // Relationships
    public List<ActorMovie> ActorMovies { get; set; }
}