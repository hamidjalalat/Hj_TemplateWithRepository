using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Infrastructure
{
    public static class MyHtmlHelper
    {
        static MyHtmlHelper()
        {
        }
        public static IHtmlString HjEditor
        (this HtmlHelper htmlHelper, string name, object value = null)
        {
            TagBuilder oInput =
                new TagBuilder("input");

            oInput.Attributes.Add("id", name);
            oInput.Attributes.Add("name", name);
            oInput.Attributes.Add("type", "text");

            if (value != null)
            {
                oInput.Attributes.Add("value", value.ToString());
            }

            return (htmlHelper.Raw(oInput.ToString()));
        }

        public static IHtmlString HjEditor<TModel, TValue>
            (this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TValue>> expression)
        {
            ModelMetadata oModelMetadata =
            ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);

            string DisplayName = oModelMetadata.DisplayName;

            string Output = string.Format("<div class='form-group'>" +
                htmlHelper.LabelFor(expression, htmlAttributes: new { @class = "control-label col-md-2" }) +
                "<div class='col-md-10'>" +
                htmlHelper.EditorFor(expression, new { htmlAttributes = new { @class = "form-control" } }) +
                htmlHelper.ValidationMessageFor(expression, "", new { @class = "text-danger" }) +
                "</div></div>"
                , DisplayName);

            return htmlHelper.Raw(Output.ToString());
        }

     
        public static IHtmlString HjSubmit
            (this HtmlHelper htmlHelper, string name, string caption,string @class)
        {
            TagBuilder oButton =
                new TagBuilder("button");

            oButton.SetInnerText(caption);
         
            oButton.AddCssClass(@class);

            oButton.Attributes.Add("id", name);
            oButton.Attributes.Add("name", name);
            oButton.Attributes.Add("type", "submit");

            string Output = "<div class='form-group'>" +
                   " <div class='col-md-offset-2 col-md-10'>" +
               oButton.ToString() +
                    "</div>" +
                "</div>";

            return (htmlHelper.Raw(Output));
        }
    }
}