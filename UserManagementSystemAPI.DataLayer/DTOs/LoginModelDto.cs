using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagementSystemAPI.DataLayer.DTOs;

public record LoginModelDto
{
    [Required]
    [StringLength(20, ErrorMessage = "Username must be between {2} and {1} characters long.", MinimumLength = 4)]
    public string Username { get; init; }
    [Required]
    [StringLength(20, ErrorMessage = "Password must be between {2} and {1} characters long.", MinimumLength = 4)]
    public string Password { get; init; }
}

