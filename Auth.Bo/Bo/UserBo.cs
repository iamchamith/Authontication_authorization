using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Auth.Bo.Utility.Enums;

namespace Auth.Bo
{
    public class UserBo
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public bool IsValiedEmail { get; set; }
        public Roles Roles { get; set; }
        public bool Active { get; set; }
        public DateTime RegDate { get; set; }
    }
}
