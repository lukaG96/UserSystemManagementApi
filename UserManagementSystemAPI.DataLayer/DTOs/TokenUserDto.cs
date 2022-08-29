using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagementSystemAPI.DataLayer.DTOs;
public record TokenUserDto
([Required]
 string UserUuid,
[Required]
 string UserNameOnline,
[Required]
 string LocationId,
 string? GroupId
) : LoginModelDto;
