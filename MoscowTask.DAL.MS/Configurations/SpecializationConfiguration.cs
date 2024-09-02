using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoscowTask.Core.Entities;

namespace MoscowTask.DAL.MS.Configurations;

/// <summary>
/// Конфигурация для <see cref="Specialization"/>
/// </summary>
public class SpecializationConfiguration : EntityTypeConfigurationBase<Specialization>
{
    /// <inheritdoc />
    public override void ConfigureChild(EntityTypeBuilder<Specialization> builder)
    {
        builder.Property(p => p.Name)
            .HasComment("Название")
            .IsRequired();

        builder.HasMany(x => x.Doctors)
            .WithOne(y => y.Specialization)
            .HasForeignKey(y => y.SpecializationId)
            .HasPrincipalKey(x => x.Id);
    }
}