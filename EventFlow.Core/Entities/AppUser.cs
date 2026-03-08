using Microsoft.AspNetCore.Identity;

namespace EventFlow.Core.Entities;

public class AppUser : IdentityUser
{
    public string Fullname { get; set; } = null!;
}