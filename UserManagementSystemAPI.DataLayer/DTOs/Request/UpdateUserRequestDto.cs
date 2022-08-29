using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagementSystemAPI.DataLayer.DTOs.Request
{
    public class UpdateUserRequestDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Status { get; set; }
        public string? Email { get; set; }
    }
}
