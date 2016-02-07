using System.Web.Optimization;
using System.Web.Optimization.React;
using React;
using Sitecore.Events.Hooks;

namespace Reactor.System
{
  public class Loader : IHook
  {
    public void Initialize()
    {
      BundleTable.Bundles.Add(new BabelBundle("~/bundle/react").IncludeDirectory("~/jsx", "*.jsx"));

      ReactSiteConfiguration.Configuration
        .SetReuseJavaScriptEngines(true)
        .AddScript("~/jsx/HelloWorld.jsx")
        .AddScript("~/jsx/HeaderImage.jsx")
        .AddScript("~/jsx/Counter.jsx")
        .AddScript("~/jsx/TitleText.jsx");
    }
  }
}