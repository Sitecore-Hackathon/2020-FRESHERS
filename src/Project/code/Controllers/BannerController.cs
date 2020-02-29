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
    public class BannerController : Controller
    {
        //default ctor
        public BannerController()
        {
        }

        /// <summary>
        /// Render Banner Section
        /// </summary>
        /// <returns></returns>
        public ActionResult RenderBannerSection()
        {
            var currentItem = RenderingContext.Current.Rendering.Item;
            var dataSourceId = RenderingContext.CurrentOrNull.Rendering.DataSource;
            var dataSource = Sitecore.Context.Database.GetItem(dataSourceId);
            if (dataSource != null)
            {
                var viewModel = new BannerViewModel()
                {
                    BannerTitle = dataSource.Fields["BannerTitle"].Value,
                    BannerDescription = dataSource.Fields["BannerDescription"].Value,
                    BannerImage = ((ImageField)dataSource.Fields["BannerImage"]),
                    YoutubeVedioUrl = dataSource.Fields["YoutubeVedioUrl"].Value
                    //aboutModel.ContentImageUrl = MediaManager.GetMediaUrl(imgField.MediaItem);
                    //aboutModel.ContentImageAltText = imgField.Alt;
                };
                return View("~/Views/Banner/Banner.cshtml", viewModel);
            }
            return View("~/Views/Banner/Banner.cshtml", null);
        }
    }
}