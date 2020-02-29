using Sitecore.Data.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Hackathon.Website.ViewModel
{
    public class AboutHackathonViewModel
    {
        public string AboutHackathonTitle { get; set; }
        public string AboutHackathonCaption { get; set; }
        public string AboutHackathonDescription { get; set; }
        public ImageField AboutHackathonImage { get; set; }
    }
}