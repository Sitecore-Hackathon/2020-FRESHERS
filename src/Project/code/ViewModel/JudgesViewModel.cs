using Sitecore.Data.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Hackathon.Website.ViewModel
{
    public class JudgesViewModel
    {
        public string JudgesInformation { get; set; }
        public IList<JudgesDetails> JudgesList { get; set; }
    }

    public class JudgesDetails
    {
        public string JudgesInfo { get; set; }
        public string JudgeName { get; set; }
        public string JudgesPic { get; set; }
        public string JudgesProfession { get; set; }
    }
}