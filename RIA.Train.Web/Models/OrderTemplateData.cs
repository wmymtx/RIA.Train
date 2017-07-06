using Senparc.Weixin.MP.AdvancedAPIs.TemplateMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RIA.Train.Web.Models
{
    public class OrderTemplateData
    {
        public TemplateDataItem first { get; set; }

        public TemplateDataItem keyword1 { get; set; }

        public TemplateDataItem keyword2 { get; set; }

        public TemplateDataItem keyword3 { get; set; }

        public TemplateDataItem remark { get; set; }
    }
}