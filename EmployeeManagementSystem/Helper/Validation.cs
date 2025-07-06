using Microsoft.AspNetCore.Html;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeManagementSystem.Helper
{
    public static class Validation
    {

        public static IHtmlContent ValidationMessageCustomFor<TModel, TProperty>(
            this IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            string cssClass = "text-danger")
        {
            return htmlHelper.ValidationMessageFor(expression, null, new { @class = cssClass });
        }
        }
    }
}
