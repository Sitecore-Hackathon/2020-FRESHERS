using Sitecore.Foundation.Poc.Sitesettings.Banner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sitecore.Feature.Poc.Interface
{
    public interface IContentLogic
    {
        IBanner GetBanner();
    }
}
