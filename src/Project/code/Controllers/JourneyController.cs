using Glass.Mapper.Sc;
using Sitecore.Data.Fields;
using Sitecore.Feature.Poc.Component.Banner;
using Sitecore.Feature.Poc.Interface;
using Sitecore.Hackathon.Website.ViewModel;
using Sitecore.Mvc.Presentation;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sitecore.Hackathon.Website.Controllers
{
    public class JourneyController : Controller
    {
        /// <summary>
        /// ctor
        /// </summary>
        public JourneyController()
        {
        }

        /// <summary>
        /// Render Journey controller
        /// </summary>
        /// <returns></returns>
        public ActionResult RenderJourneySection()
        {
            //var dataSourceId = RenderingContext.CurrentOrNull.Rendering.DataSource;
            var dataSource = Sitecore.Context.Database.GetItem(RenderingContext.CurrentOrNull.Rendering.DataSource);
            if (dataSource != null)
            {
                Sitecore.Data.Fields.MultilistField multiselectField =
                       dataSource.Fields["HackathonJourney"];
                Sitecore.Data.Items.Item[] items = multiselectField.GetItems();

                if (items != null && items.Length > 0)
                {
                    var listofjourneydetails = new List<JourneyDetails>();

                    for (int i = 0; i < items.Length; i++)
                    {
                        Sitecore.Data.Items.Item journeyItem = items[i];
                        var journeydetail = new JourneyDetails()
                        {
                            JourneyHeader = FieldRenderer.Render(journeyItem, "JourneyHeader"),
                            JourneyCaption = FieldRenderer.Render(journeyItem, "JourneyCaption"),
                            JourneyStyle = FieldRenderer.Render(journeyItem, "JourneyStyle")
                        };
                        listofjourneydetails.Add(journeydetail);
                    }
                    var returnviewmodel = new JourneyViewModel()
                    {
                        JourneyListDetails = listofjourneydetails
                    };
                    return View("~/Views/Journey/Journey.cshtml", returnviewmodel);
                }
            }
            return View("~/Views/Journey/Journey.cshtml", null);

            // var currentItem = SitecoreContext.GetCurrentItem<IGlassBase>();
            //var contentdata = _contentLogic.GetBanner();
            // return View(_contentLogic.GetBanner());
        }
    }
}