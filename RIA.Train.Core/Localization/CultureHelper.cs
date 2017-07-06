using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RIA.Train.Localization
{
    public static class CultureHelper
    {
        public static bool IsRtl
        {
            get { return Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft; }
        }
    }
}
