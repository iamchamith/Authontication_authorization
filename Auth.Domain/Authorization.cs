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
    [Table("Authorizations")]
    public class Authorization
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column(Order = 0), Key]
        public Roles Roles { get; set; }
        [Column(Order = 1), Key]
        public string Tag { get; set; }
    }
}
