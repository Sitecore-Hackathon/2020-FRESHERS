using Sitecore.Data.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Hackathon.Website.ViewModel
{
    public class BannerViewModel
    {
        public string BannerTitle { get; set; }
        public ImageField BannerImage { get; set; }
        public string BannerDescription { get; set; }
        public string YoutubeVedioUrl { get; set; }
    }
}