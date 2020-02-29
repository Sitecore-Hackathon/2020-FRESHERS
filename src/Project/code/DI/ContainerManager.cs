using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimpleInjector;

namespace Sitecore.Hackathon.Website.DI
{
    public class ContainerManager
    {
        private static readonly Container container = new Container();

        public Container Container
        {
            get
            {
                return container;
            }
        }
    }
}