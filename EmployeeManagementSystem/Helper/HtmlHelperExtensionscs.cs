using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeManagementSystem.Helper
{
    public static class HtmlHelperExtensionscs
    {

        public static IHtmlContent ActionButton<TModel>(
             this IHtmlHelper<TModel> htmlHelper,
             string link,
             string text,
             string cssClass)
        {
            var anchor = new TagBuilder("a");
            anchor.Attributes["href"] = link;
            anchor.AddCssClass($"btn {cssClass} btn-sm");
            anchor.InnerHtml.Append(text);
            return anchor;
        }
    }
}
