﻿using System.ComponentModel.DataAnnotations;

namespace MatchDataManager.Api.Models;

public class Team : Entity
{
    [Required]
    [StringLength(255, ErrorMessage = "The Name cannot exceed 255 characters. ")]
    public string Name { get; set; }
    

    public string CoachName { get; set; }
}