using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Admin.Entities
{
    public interface IEntityBase { }

    public abstract class EntityBase : IEntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public DateTimeOffset CreatedAt { get; protected set; } = DateTimeOffset.Now;

        public DateTimeOffset? UpdatedAt { get; protected set; }

        public bool SoftDeleted { get; set; } = false;

        public long? UpdatedBy { get; set; }
    }

    public abstract class EntityBaseWithoutId : IEntityBase
    {
        public DateTimeOffset CreatedAt { get; protected set; } = DateTimeOffset.Now;

        public DateTimeOffset? UpdatedAt { get; protected set; }

        public bool SoftDeleted { get; set; } = false;

        public long? UpdatedBy { get; set; }
    }
}
