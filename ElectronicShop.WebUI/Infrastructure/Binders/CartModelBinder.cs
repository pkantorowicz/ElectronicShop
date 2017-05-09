using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ElectronicShop.Domain.Entities;

namespace ElectronicShop.WebUI.Infrastructure.Binders
{
    public class CartModelBinder : IModelBinder
    {
        private const string sessionKey = "Cart";
        public object BindModel(ControllerContext controllerContext,
        ModelBindingContext bindingContext)
        {
            // pobranie obiektu Cart z sesji
            Cart cart = null;
            if (controllerContext.HttpContext.Session != null)
            {
                cart = (Cart)controllerContext.HttpContext.Session[sessionKey];
            }
            // utworzenie obiektu Cart, jeżeli nie został znaleziony w danych sesji
            if (cart == null)
            {
                cart = new Cart();
                if (controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[sessionKey] = cart;
                }
            }
            // zwróć koszyk
            return cart;
        }
    }
}