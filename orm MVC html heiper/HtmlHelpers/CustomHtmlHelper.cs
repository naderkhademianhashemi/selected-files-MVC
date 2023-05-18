using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.HtmlHelpers
{
    public static class CustomHtmlHelper
    {
        public static MvcHtmlString FADTextArea(this HtmlHelper htmlHelper, string name)
        {
            string tag = $"<textarea name='{name}' class='form-control' rows='4'></textarea>";
            return new MvcHtmlString(tag);
        }
    }
}