using System.ComponentModel.DataAnnotations;

namespace Domain.Common
{
    public class AuditableEntity : IEntity
    {
        //=========Audit Members============ 
        public DateTime CreatedAt { set; get; }

        [MaxLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }
        [MaxLength(50)]
        public string UpdatedBy { get; set; }

        public AuditableEntity()
        {
            CreatedAt = DateTime.UtcNow;
        }
    }

    public class AuditableEntity<T> : AuditableEntity, IEntity<T>
    {
        // Identity 
        [Key]
        public T Id { get; set; }
    }

    public class AuditlessEntity<T> : IEntity<T>
    {
        // Identity 
        [Key]
        public T Id { get; set; }
    }

    public class AuditlessDisplayEntity<T> : AuditlessEntity<T>
    {
    }
}