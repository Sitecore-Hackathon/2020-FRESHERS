using Sitecore.Data.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Hackathon.Website.ViewModel
{
    public class EntrySubmissionViewModel
    {
        public string EntrySubmissionTitle { get; set; }
        public string EntrySubmissionCaption { get; set; }
        public ImageField EntrySubmissionImage { get; set; }
        public string EntrySubmissionDescription { get; set; }
    }
}