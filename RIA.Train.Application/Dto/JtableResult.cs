using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIA.Train.Dto
{
    public class JtableResult<T>
    {
        public string Result { get; set; }

        public T Records { get; set; }

        public int TotalRecordCount { get; set; }

        public JtableResult(int count,T t)
        {
            TotalRecordCount = count;
            Records = t;
            Result = "OK";
        }
    }
}
