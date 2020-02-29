using Sitecore.Data.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Hackathon.Website.ViewModel
{
    public class PastYearSnapshotViewModel
    {
        public string PreviousYearSnapshotTitle { get; set; }
        public IList<PreviousYearSnapshotDetails> PreviousYearSnapshotList { get; set; }
    }

    public class PreviousYearSnapshotDetails
    {
        public string PreviousYear { get; set; }
        public string PreviousYearTitle { get; set; }
        public string PreviousYearDescription { get; set; }
        public string PreviousYearImage { get; set; }
    }
}