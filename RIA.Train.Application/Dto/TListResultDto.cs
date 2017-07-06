using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIA.Train.Dto
{
    [Serializable]
    public class TListResultDto<T> : ITListResult<T>
    {
        /// <summary>
        /// List of items.
        /// </summary>
        public IReadOnlyList<T> Records
        {
            get { return _records ?? (_records = new List<T>()); }
            set { _records = value; }
        }
        private IReadOnlyList<T> _records;

        /// <summary>
        /// Creates a new <see cref="ListResultDto{T}"/> object.
        /// </summary>
        public TListResultDto()
        {

        }

        /// <summary>
        /// Creates a new <see cref="ListResultDto{T}"/> object.
        /// </summary>
        /// <param name="items">List of items</param>
        public TListResultDto(IReadOnlyList<T> records)
        {
            Records = records;
        }
    }
}
