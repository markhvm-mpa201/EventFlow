using EventFlow.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventFlow.DataAccess.Configuratons;

internal class EventConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.Property(x => x.Name).IsRequired().HasMaxLength(256);
    }


}

internal class Cat