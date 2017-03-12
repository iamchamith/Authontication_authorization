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
    public class ErrorBo
    {
        public int Id { get; set; }
        public string Exception { get; set; }
        public string ExceptionMessage { get; set; }
        public string ExceptionStackTrace { get; set; }
        public DateTime CreatedTime { get; set; }
        public string CreatedUser { get; set; }
        public ErroType ExceptionType { get; set; }
        public bool IsChecked { get; set; }
        public string Descripton { get; set; }
    }
}
