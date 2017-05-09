using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ElectronicShop.Domain.Entities;

namespace ElectronicShop.WebUI.Models
{
    public class CartIndexViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}