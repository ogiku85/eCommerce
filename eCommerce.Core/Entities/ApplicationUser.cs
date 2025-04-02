namespace eCommerce.Core.Entities;

// this should have been done using .net identity frameworks
/// <summary>
/// Defines Application user as entity model for storing users in data store
/// </summary>
public class ApplicationUser
{
    public Guid UserID { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? PersonName { get; set; }
    public string? Gender { get; set; }
}