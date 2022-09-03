using eTickets.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models;

public class Cinema : IEntityBase
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Logo is required")]
    public string Logo { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Description is required")]
    public string Description { get; set; }

    // Relationships
    public List<Movie> Movies { get; set; }
}