using EventFlow.Core.Entities;
using EventFlow.DataAccess.Helpers;
using Microsoft.EntityFrameworkCore;

namespace EventFlow.DataAccess.ContextInitializer;

internal static class SeedDataHelper
{
    public static void AddSeedData(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Event>().HasQueryFilter(e => !e.IsDeleted);

        var category = new Category()
        {
            Id = Guid.Parse("502828b0-b9a6-4495-b82a-10c2a8089570"),
            Name = "Default Category"
        };
        modelBuilder.Entity<Category>().HasData(category);

        modelBuilder.Entity<Gender>().HasData(StaticData.MaleGender, StaticData.FemaleGender, StaticData.MechanicalGender);
    }       
}
