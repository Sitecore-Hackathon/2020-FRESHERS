using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;

namespace Sitecore.Foundation.Poc.Sitesettings.Banner
{
    [SitecoreType(TemplateId = "{0FC920BD-C715-4458-A788-55F9B4152BA0}", AutoMap = true)]
    public interface IBanner
    {
        string BannerTitle { get; set; }
        string BannerImage { get; set; }
        string BannerDescription { get; set; }
    }
}
