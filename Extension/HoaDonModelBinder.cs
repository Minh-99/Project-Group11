using Group11.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Group11.Extension
{
    public class HoaDonModelBinder : IModelBinder
    {
        private const string sessionKey = "HoaDon";
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            // get the Cart from the session
            HoaDon cart = null;
            if (controllerContext.HttpContext.Session != null)
            {
                cart = (HoaDon)controllerContext.HttpContext.Session[sessionKey];
            }
            // create the Cart if there wasn't one in the session data
            if (cart == null)
            {
                cart = new HoaDon();
                cart.NgayLap = DateTime.Now;
                cart.ChiTietHoaDons = new List<ChiTietHoaDon>();
                if (controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[sessionKey] = cart;
                }
            }
            // return the cart
            return cart;
        }
    }
}