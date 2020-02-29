using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Hackathon.Website.ViewModel
{
    public class JourneyViewModel
    {
        public IList<JourneyDetails> JourneyListDetails { get; set; }
    }

    public class JourneyDetails
    {
        public string JourneyHeader { get; set; }
        public string JourneyCaption { get; set; }
        public string JourneyStyle { get; set; }
    }
}