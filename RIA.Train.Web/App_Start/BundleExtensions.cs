using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace RIA.Train.Web
{
    public static class BundleExtensions
    {
        public static Bundle ForceOrdered(this Bundle bundle)
        {
            bundle.Orderer = new AsIsBundleOrderer();
            return bundle;
        }
    }
}