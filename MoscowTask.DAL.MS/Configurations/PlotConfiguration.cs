using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoscowTask.Core.Entities;

namespace MoscowTask.DAL.MS.Configurations;

/// <summary>
/// Конфигурация для <see cref="Plot"/>
/// </summary>
public class PlotConfiguration : EntityTypeConfigurationBase<Plot>
{
    /// <inheritdoc />
    public override void ConfigureChild(EntityTypeBuilder<Plot> builder)
    {
        builder.Property(p => p.Number)
            .HasComment("Номер")
            .IsRequired();

        builder.HasMany(x => x.Patients)
            .WithOne(y => y.Plot)
            .HasForeignKey(y => y.PlotId)
            .HasPrincipalKey(x => x.Id);

        builder.HasMany(x => x.Doctors)
            .WithOne(y => y.Plot)
            .HasForeignKey(y => y.PlotId)
            .HasPrincipalKey(x => x.Id);
    }
}