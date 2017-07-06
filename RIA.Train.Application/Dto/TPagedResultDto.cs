using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIA.Train.Dto
{
    [Serializable]
    public class TPagedResultDto<T> : TListResultDto<T>, ITPagedResult<T>
    {
        /// <summary>
        /// Total count of Items.
        /// </summary>
        public int TotalRecordCount { get; set; }

        public string Result { get; set; }

        /// <summary>
        /// Creates a new <see cref="PagedResultDto{T}"/> object.
        /// </summary>
        public TPagedResultDto()
        {

        }

        /// <summary>
        /// Creates a new <see cref="PagedResultDto{T}"/> object.
        /// </summary>
        /// <param name="totalCount">Total count of Items</param>
        /// <param name="items">List of items in current page</param>
        public TPagedResultDto(int totalCount, IReadOnlyList<T> records)
            : base(records)
        {
            TotalRecordCount = totalCount;
            Result = "OK";
        }
    }
}
