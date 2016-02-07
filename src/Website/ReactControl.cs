using System.Collections.Generic;
using System.Dynamic;
using System.Web.UI;
using React;
using React.Exceptions;
using React.TinyIoC;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.StringExtensions;
using Sitecore.Web.UI.WebControls;

namespace Reactor
{
  public class ReactControl : Sitecore.Web.UI.WebControl
  {
    private static IReactEnvironment Environment
    {
      get
      {
        IReactEnvironment current;
        try
        {
          current = ReactEnvironment.Current;
        }
        catch (TinyIoCResolutionException tinyIoCResolutionException)
        {
          throw new ReactNotInitialisedException("ReactJS.NET has not been initialised correctly.", tinyIoCResolutionException);
        }
        return current;
      }
    }

    public string Name { get; set; }

    protected override void DoRender(HtmlTextWriter output)
    {
      IReactComponent reactComponent = Environment.CreateComponent(Name, GetProps());
      output.Write(reactComponent.RenderHtml());
      output.Write("<script>{0}</script>".FormatWith(reactComponent.RenderJavaScript()));
    }

    private dynamic GetProps()
    {
      dynamic props = new ExpandoObject();
      var dataSourceItem = GetDataSourceItem();

      foreach (Field field in dataSourceItem.Fields)
      {
        if (field.Name.StartsWith("__"))
        {
          continue;
        }

        ((IDictionary<string, object>) props).Add(field.Name.ToLowerInvariant(), FieldRenderer.Render(dataSourceItem, field.Name));
      }
      return props;
    }

    private Item GetDataSourceItem()
    {
      Item dataSourceItem;
      if (!string.IsNullOrEmpty(DataSource))
      {
        dataSourceItem = Sitecore.Context.Database.GetItem(DataSource) ?? Sitecore.Context.Item;
      }
      else
      {
        dataSourceItem = Sitecore.Context.Item;
      }
      return dataSourceItem;
    }
  }
}