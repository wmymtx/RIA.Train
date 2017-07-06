using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIA.Train.Application.Dtos
{
    public class T_Staff_LoginDto
    {
        public int LoginNo { get; set; }


        public string Password { get; set; }


        public string OpenId { get; set; }

        public string RetUrl { get; set; }
    }
}
