using System.ComponentModel.DataAnnotations;

namespace MatchDataManager.Api.Models;

public class Location : Entity
{
    
    [Required]
    [StringLength(255, ErrorMessage = "The Name cannot exceed 255 characters. ")]
    public string Name { get; set; }
    [Required]
    [StringLength(55, ErrorMessage = "The City's name cannot exceed 55 characters. ")]
    public string City { get; set; }
}