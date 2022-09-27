using System.ComponentModel.DataAnnotations;

namespace MatchDataManager.Api.Models;

public class Team : Entity
{
    [Required(ErrorMessage = "Name is required")]
    [StringLength(255, ErrorMessage = "The Name cannot exceed 255 characters. ")]
    public string Name { get; set; }
    
    [StringLength(55, ErrorMessage = "The coach's name cannot exceed 55 characters. ")]
    public string CoachName { get; set; }
}