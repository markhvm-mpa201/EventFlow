using EventFlow.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventFlow.DataAccess.Configuratons;

internal class EventConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.Property(x => x.Name).IsRequired().HasMaxLength(256);

        builder.HasOne(x=>x.Category)
            .WithMany(x=>x.Events).HasForeignKey(x=>x.CategoryId)
            .HasPrincipalKey(x=>x.Id).OnDelete(DeleteBehavior.Restrict);
    }
}
