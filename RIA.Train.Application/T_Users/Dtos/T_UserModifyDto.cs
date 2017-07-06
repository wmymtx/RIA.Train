using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIA.Train.Application.Dtos
{
    public class T_UserModifyDto
    {
        public string LoginNo { get; set; }

        public string OldPassword { get; set; }

        public string NewPassword { get; set; }

        public string ReNewPassword { get; set; }
    }
}
