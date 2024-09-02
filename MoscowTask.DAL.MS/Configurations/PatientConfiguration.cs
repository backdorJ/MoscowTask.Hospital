using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoscowTask.Contracts.Enums;
using MoscowTask.Core.Entities;

namespace MoscowTask.DAL.MS.Configurations;

/// <summary>
/// Конфигурация для <see cref="Patient"/>
/// </summary>
public class PatientConfiguration : EntityTypeConfigurationBase<Patient>
{
    /// <inheritdoc />
    public override void ConfigureChild(EntityTypeBuilder<Patient> builder)
    {
        builder.Property(p => p.Surname)
            .HasComment("Фамилия")
            .IsRequired();

        builder.Property(p => p.Name)
            .HasComment("Имя")
            .IsRequired();

        builder.Property(p => p.Patronymic)
            .HasComment("Отчество");

        builder.Property(p => p.Address)
            .HasComment("Адрес")
            .IsRequired();

        builder.Property(p => p.Birthday)
            .HasComment("Дата рождения")
            .IsRequired();

        builder.Property(p => p.Gender)
            .HasComment("Пол")
            .IsRequired()
            .HasConversion(
                x => x.ToString(),
                y => Enum.Parse<Gender>(y.ToString()));

        builder.Property(p => p.PlotId)
            .HasComment("Идентификатор участка")
            .IsRequired();

        builder.HasOne(x => x.Plot)
            .WithMany(y => y.Patients)
            .HasForeignKey(x => x.PlotId)
            .HasPrincipalKey(y => y.Id);
    }
}