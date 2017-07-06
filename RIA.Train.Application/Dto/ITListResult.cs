using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIA.Train.Dto
{
    public interface ITListResult<T>
    {
        IReadOnlyList<T> Records { get; set; }
    }
}
