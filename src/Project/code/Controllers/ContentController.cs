using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Hackathon.Website.ViewModel;
using Sitecore.Mvc.Presentation;
using Sitecore.Web.UI.WebControls;
using System.Web.Mvc;
using Sitecore.Data.Fields;
using Sitecore.Resources.Media;

namespace Sitecore.Hackathon.Website.Controllers
{
    public class ContentController : Controller
    {
        public ContentController()
        {
        }

        /// <summary>
        /// Entry Submission Controller
        /// </summary>
        /// <returns></returns>
        public ActionResult RenderEntrySubmissionSection()
        {
            var currentItem = RenderingContext.Current.Rendering.Item;
            var dataSourceId = RenderingContext.CurrentOrNull.Rendering.DataSource;
            var dataSource = Sitecore.Context.Database.GetItem(dataSourceId);
            if (dataSource != null)
            {
                var viewModel = new EntrySubmissionViewModel()
                {
                    EntrySubmissionTitle = dataSource.Fields["EntrySubmissionTItle"].Value,
                    EntrySubmissionCaption = dataSource.Fields["EntrySubmissionCaption"].Value,
                    EntrySubmissionDescription = dataSource.Fields["EntrySubmissionDescription"].Value,
                    EntrySubmissionImage = ((ImageField)dataSource.Fields["EntrySubmissionImage"])
                };
                return View("~/Views/Sitecontent/Entrysubmission.cshtml", viewModel);
            }
            return View("~/Views/Sitecontent/Entrysubmission.cshtml", null);
        }

        /// <summary>
        /// Judges Information Section
        /// </summary>
        /// <returns></returns>
        public ActionResult RenderJudgesInfoSection()
        {
            var currentItem = RenderingContext.Current.Rendering.Item;
            var dataSourceId = RenderingContext.CurrentOrNull.Rendering.DataSource;
            var dataSource = Sitecore.Context.Database.GetItem(dataSourceId);
            if (dataSource != null)
            {
                var judgeinformation = dataSource.Fields["JudgesInformation"]?.Value;
                Sitecore.Data.Fields.MultilistField multiselectField =
                      dataSource.Fields["JudgesList"];
                Sitecore.Data.Items.Item[] items = multiselectField.GetItems();

                if (items != null && items.Length > 0)
                {
                    var listofjudges = new List<JudgesDetails>();
                    for (int i = 0; i < items.Length; i++)
                    {
                        Sitecore.Data.Items.Item judgeItem = items[i];

                        Sitecore.Data.Fields.ImageField field = items[i].Fields["JudgesPic"];

                        var judgedetail = new JudgesDetails()
                        {
                            JudgesInfo = FieldRenderer.Render(judgeItem, "JudgesInfo"),
                            JudgeName = FieldRenderer.Render(judgeItem, "JudgeName"),
                            JudgesProfession = FieldRenderer.Render(judgeItem, "JudgesProfession"),
                            JudgesPic = MediaManager.GetMediaUrl(field.MediaItem)
                        };
                        listofjudges.Add(judgedetail);
                    }
                    var returnviewmodel = new JudgesViewModel()
                    {
                        JudgesList = listofjudges,
                        JudgesInformation = judgeinformation
                    };

                    return View("~/Views/JudgesInformation/JudgesInformation.cshtml", returnviewmodel);
                };

            }
            return View("~/Views/JudgesInformation/JudgesInformation.cshtml", null);
        }

        /// <summary>
        /// Previous Years Snapshot Section
        /// </summary>
        /// <returns></returns>
        public ActionResult RenderPastYearSnapshotSection()
        {
            var currentItem = RenderingContext.Current.Rendering.Item;
            var dataSourceId = RenderingContext.CurrentOrNull.Rendering.DataSource;
            var dataSource = Sitecore.Context.Database.GetItem(dataSourceId);
            if (dataSource != null)
            {
                var previousyearinformation = dataSource.Fields["PreviousYearSnapshotTitle"]?.Value;
                Sitecore.Data.Fields.MultilistField multiselectField =
                      dataSource.Fields["PreviousYearSnapshotList"];
                Sitecore.Data.Items.Item[] items = multiselectField.GetItems();

                if (items != null && items.Length > 0)
                {
                    var listofsnapshot = new List<PreviousYearSnapshotDetails>();
                    for (int i = 0; i < items.Length; i++)
                    {
                        Sitecore.Data.Items.Item snapshotItem = items[i];

                        Sitecore.Data.Fields.ImageField field = items[i].Fields["PreviousYearImage"];

                        var snapshotdetail = new PreviousYearSnapshotDetails()
                        {
                            PreviousYearTitle = FieldRenderer.Render(snapshotItem, "PreviousYearTitle"),
                            PreviousYear = FieldRenderer.Render(snapshotItem, "PreviousYear"),
                            PreviousYearDescription = FieldRenderer.Render(snapshotItem, "PreviousYearDescription"),
                            PreviousYearImage = MediaManager.GetMediaUrl(field.MediaItem)
                        };
                        listofsnapshot.Add(snapshotdetail);
                    }
                    var returnviewmodel = new PastYearSnapshotViewModel()
                    {
                        PreviousYearSnapshotTitle = previousyearinformation,
                        PreviousYearSnapshotList = listofsnapshot
                    };

                    return View("~/Views/PreviousYear/PreviousYear.cshtml", returnviewmodel);
                };

            }
            return View("~/Views/PreviousYear/PreviousYear.cshtml", null);
        }
    }
}