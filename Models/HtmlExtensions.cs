using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Group11.Models
{
    public static class HtmlExtensions
    {
        public static MvcHtmlString ShowImage(this HtmlHelper html, byte[] image)
        {
            String img = "";
            if (image != null)
            {
                img = String.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(image));
            }
            else
            {
                img = "http://placehold.it/750x600";
            }
            return new MvcHtmlString("<img src='" + img + "'/>");
        }
    }
}