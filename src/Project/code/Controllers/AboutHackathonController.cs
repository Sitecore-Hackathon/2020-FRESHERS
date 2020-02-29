using Glass.Mapper.Sc;
using Sitecore.Data.Fields;
using Sitecore.Feature.Poc.Component.Banner;
using Sitecore.Feature.Poc.Interface;
using Sitecore.Hackathon.Website.ViewModel;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sitecore.Hackathon.Website.Controllers
{
    public class AboutHackathonController : Controller
    {
        //default ctor
        public AboutHackathonController()
        {
        }

        /// <summary>
        /// Render About Hackathon Section
        /// </summary>
        /// <returns></returns>
        public ActionResult RenderAboutHackathonSection()
        {
            var currentItem = RenderingContext.Current.Rendering.Item;
            var dataSourceId = RenderingContext.CurrentOrNull.Rendering.DataSource;
            var dataSource = Sitecore.Context.Database.GetItem(dataSourceId);
            if (dataSource != null)
            {
                var viewModel = new AboutHackathonViewModel()
                {
                    AboutHackathonTitle = dataSource.Fields["AboutHackathonTitle"].Value,
                    AboutHackathonCaption = dataSource.Fields["AboutHackathonCaption"].Value,
                    AboutHackathonImage = ((ImageField)dataSource.Fields["AboutHackathonImage"]),
                    AboutHackathonDescription = dataSource.Fields["AboutHackathonDescription"].Value
                    //aboutModel.ContentImageUrl = MediaManager.GetMediaUrl(imgField.MediaItem);
                    //aboutModel.ContentImageAltText = imgField.Alt;
                };
                return View("~/Views/AboutHackathon/AboutHackathon.cshtml", viewModel);
            }
            return View("~/Views/AboutHackathon/AboutHackathon.cshtml", null);
        }
    }
}