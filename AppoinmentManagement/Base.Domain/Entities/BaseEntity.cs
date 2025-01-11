namespace Base.Domain.Entities;

/// <summary>
/// Represents a base entity class with common properties for tracking and managing entities.
/// </summary>
public class BaseEntity
{
    /// <summary>
    /// Gets or sets the unique identifier for the entity.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the entity was created.
    /// </summary>
    public DateTime? CreatedOn { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the entity was updated.
    /// </summary>
    public DateTime? ModifiedOn { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the entity is marked as deleted.
    /// </summary>
    public bool IsDeleted { get; set; }
}
