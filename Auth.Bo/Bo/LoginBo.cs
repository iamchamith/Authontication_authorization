using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Auth.Bo.Utility.Enums;

namespace Auth.Bo
{
    public class LoginBo
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
