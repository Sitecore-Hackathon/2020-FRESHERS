using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.ComponentModel.Composition;
using System.Reflection;
using SimpleInjector.Advanced;
using System.Composition;

namespace Sitecore.Hackathon.Website.DI
{
    public class ImportAttributePropertySelectionBehavior : IPropertySelectionBehavior
    {
        public bool SelectProperty(Type serviceType, PropertyInfo propertyInfo)
        {
            return propertyInfo.GetCustomAttributes(typeof(ImportAttribute), true).Any();
        }
    }
}