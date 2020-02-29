using System;
using Glass.Mapper.Sc;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Glass.Mapper.Sc.Web;

namespace Sitecore.Foundation.Poc.Interface
{
    public interface IControllerSCContext : IRequestContext// ISitecoreContext
    {
        T GetDataSource<T>() where T : class;

        T GetRenderingParameters<T>() where T : class;
    }
}
