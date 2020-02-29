using Sitecore.Feature.Poc.Interface;
using Sitecore.Foundation.Poc.Interface;
using Sitecore.Foundation.Poc.Sitesettings.Banner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Feature.Poc.Component
{
    public class ContentLogic : IContentLogic
    {
        private readonly IControllerSCContext _currentContext;

        public ContentLogic(IControllerSCContext currentContext)
        {
            _currentContext = currentContext;
        }

        public IBanner GetBanner()
        {
            return _currentContext.GetDataSource<IBanner>();
        }
    }
}