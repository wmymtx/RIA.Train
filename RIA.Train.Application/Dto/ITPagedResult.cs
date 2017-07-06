using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIA.Train.Dto
{
    public interface ITPagedResult<T> : ITListResult<T>, ITHasTotalCount
    {
    }
}
