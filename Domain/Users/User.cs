using Domain.Common;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Users
{
    [Table(nameof(User))]
    public class User : AuditableEntity<Guid> //information (created at , )
    {
        public User()
        {
            CreatedAt = DateTime.UtcNow;
        }

        [Required]
        [MaxLength(128)]
        public string FullName { get; set; }
        [Required]
        [MaxLength(450)]
        public string HashPassword { set; get; }

        [Required]
        [MaxLength(128)]
        public string Salt { set; get; }
        [Required]
        [MaxLength(128)]
        public string Email { set; get; }
        [Required]
        [MaxLength(128)]
        public string Phone { get; set; }
        public UserRole UserRole { get; set; }
        public bool IsActive { set; get; }

    }
}
