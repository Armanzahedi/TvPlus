using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using SimpleMvcSitemap;
using SimpleMvcSitemap.Routing;

namespace TvPlus.Web.Controllers
{
    public class BaseUrlProvider : IBaseUrlProvider
    {
        public Uri BaseUrl => new Uri("https://tvplus.ir");
    }

    public class SitemapController : Controller
    {

        [Route("sitemap.xml")]
        public ActionResult Index()
        {
            List<SitemapNode> nodes = new List<SitemapNode>();
            nodes.Add(new SitemapNode(Url.Action("Index", "Home")));


            return new SitemapProvider(new BaseUrlProvider()).CreateSitemap(new SitemapModel(nodes));
        }
    }
}
