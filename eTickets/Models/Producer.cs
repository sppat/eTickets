using eTickets.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models;

public class Producer : IEntityBase
{
    [Key]
    public int Id { get; set; }

    [Display(Name = "Profile Picture")]
    [Required(ErrorMessage = "The profile picture is required")]
    public string ProfilePictureUrl { get; set; }

    [Display(Name = "Full Name")]
    [Required(ErrorMessage = "The full name is required")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "The full name must be between 3 and 50 characters")]
    public string FullName { get; set; }

    [Display(Name = "Bio")]
    [Required(ErrorMessage = "The bio is required")]
    public string Bio { get; set; }

    // Relationships
    public List<Movie> Movies { get; set; }
}