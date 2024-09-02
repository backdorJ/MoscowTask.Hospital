using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoscowTask.Core.Entities;

namespace MoscowTask.DAL.MS.Configurations;

/// <summary>
/// Конфигурация для <see cref="Office"/>
/// </summary>
public class OfficeConfiguration : EntityTypeConfigurationBase<Office>
{
    /// <inheritdoc />
    public override void ConfigureChild(EntityTypeBuilder<Office> builder)
    {
        builder.Property(p => p.Number)
            .HasComment("Номер")
            .IsRequired();

        builder.HasMany(x => x.Doctors)
            .WithOne(y => y.Office)
            .HasForeignKey(y => y.OfficeId)
            .HasPrincipalKey(x => x.Id);
    }
}