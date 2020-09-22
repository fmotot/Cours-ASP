using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace TP1_Module06.Helpers
{
    public static class MyHelpers
    {
        public static IHtmlString CustomSubmit(this HtmlHelper htmlHelper, String name)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<div class=\"form-group\">");
            sb.Append("<div class=\"col-md-offser-2 com-md-10\">");
            sb.Append($"<input type=\"submit\" value=\"{ name }\" class=\"btn btn-default\" />");
            sb.Append("</div></div>");


            return new MvcHtmlString(sb.ToString());
        }

    }
}