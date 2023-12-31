using Domain.Packages;
using Domain.Places;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class LineItemConfiguration : IEntityTypeConfiguration<LineItem>
{
    public void Configure(EntityTypeBuilder<LineItem> builder)
    {
        builder.HasKey(li => li.Id);

        builder.Property(li => li.Id).HasConversion(
            LineItemId => LineItemId.Value,
            value => new LineItemId(value)
        );

        builder.HasOne<Place>()
            .WithMany()
            .HasForeignKey(li => li.PlaceId);

    }
}