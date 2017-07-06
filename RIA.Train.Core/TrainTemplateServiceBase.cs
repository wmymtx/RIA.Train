using Abp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIA.Train
{
    public abstract class TrainTemplateServiceBase : AbpServiceBase
    {
        protected TrainTemplateServiceBase()
        {
            LocalizationSourceName = TrainConsts.LocalizationSourceName;
        }
    }
}
