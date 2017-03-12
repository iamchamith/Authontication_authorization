using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Auth.Bo.Utility.Enums;

namespace Auth.Domain
{
    [Table("Authentications")]
    public class Authentication
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Key]
        public string UserId { get; set; }
        [Required]
        [StringLength(50)]
        [Index(IsUnique =true)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool IsValiedEmail { get; set; }
        [Required]
        [DefaultValue(Roles.User)]
        public Roles Roles { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool Active { get; set; }
        [Required]
        public DateTime RegDate { get; set; }
    }
}
