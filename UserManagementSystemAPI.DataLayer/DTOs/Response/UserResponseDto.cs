namespace UserManagementSystemAPI.DataLayer.DTOs.Response;

public class UserResponseDto
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Status { get; set; }
    public string Email { get; set; }
}

