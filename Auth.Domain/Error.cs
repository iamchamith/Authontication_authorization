using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Auth.Bo.Utility.Enums;

namespace Auth.Domain
{
    public class Error
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Exception { get; set; }
        [Required]
        public string ExceptionMessage { get; set; }
        public string ExceptionStackTrace { get; set; }
        [Required]
        public DateTime CreatedTime { get; set; }
        public string CreatedUser { get; set; }
        [Required]
        public ErroType ExceptionType { get; set; }
        [Required]
        public bool IsChecked { get; set; }
        public string Descripton { get; set; }
    }
}
