using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoscowTask.Core.Entities;

namespace MoscowTask.DAL.MS.Configurations;

/// <summary>
/// Конфигурация для <see cref="Doctor"/>
/// </summary>
public class DoctorConfiguration : EntityTypeConfigurationBase<Doctor>
{
    /// <inheritdoc />
    public override void ConfigureChild(EntityTypeBuilder<Doctor> builder)
    {
        builder.Property(p => p.Surname)
            .HasComment("Фамилия")
            .IsRequired();

        builder.Property(p => p.Name)
            .HasComment("Имя")
            .IsRequired();

        builder.Property(p => p.Patronymic)
            .HasComment("Отчество");

        builder.Property(p => p.OfficeId)
            .HasComment("Идентификатор кабинета")
            .IsRequired();

        builder.Property(x => x.SpecializationId)
            .HasComment("Идентификатор специализации")
            .IsRequired();
        
        builder.Property(x => x.PlotId)
            .HasComment("Идентификатор участка")
            .IsRequired();

        builder.HasOne(x => x.Office)
            .WithMany(y => y.Doctors)
            .HasForeignKey(x => x.OfficeId)
            .HasPrincipalKey(y => y.Id);

        builder.HasOne(x => x.Specialization)
            .WithMany(y => y.Doctors)
            .HasForeignKey(x => x.SpecializationId)
            .HasPrincipalKey(y => y.Id);

        builder.HasOne(x => x.Plot)
            .WithMany(y => y.Doctors)
            .HasForeignKey(x => x.PlotId)
            .HasPrincipalKey(y => y.Id);
    }
}