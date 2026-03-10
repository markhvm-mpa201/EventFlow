using EventFlow.Core.Entities;

namespace EventFlow.DataAccess.Helpers;

public static class StaticData
{
    public static Gender MaleGender = new() 
    {
        Id = Guid.Parse("7d2203cd-a094-4720-af06-81d861201c09"),
        Name = "Male"
    };

    public static Gender FemaleGender = new()
    {
        Id = Guid.Parse("7ae1b828-b59b-4cd0-ab3a-5cb0193c327b"),
        Name = "Female"
    };

    public static Gender MechanicalGender = new()
    {
        Id = Guid.Parse("dda951eb-8b6c-4e59-82b8-b0fac65cde76"),
        Name = "Mechanical"
    };
}
