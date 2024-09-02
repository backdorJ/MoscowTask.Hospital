using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoscowTask.Core.Entities;

namespace MoscowTask.DAL.MS.Configurations;

/// <summary>
/// Базовый класс конфигурации
/// </summary>
public abstract class EntityTypeConfigurationBase<TEntity> : IEntityTypeConfiguration<TEntity>
    where TEntity : EntityBase
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(x => x.Id);
    }

    /// <summary>
    /// Конфигурация остальных компонентов
    /// </summary>
    /// <param name="builder">Конфигурация</param>
    public abstract void ConfigureChild(EntityTypeBuilder<TEntity> builder);
}