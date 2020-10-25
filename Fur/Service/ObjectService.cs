using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fur.Models;

namespace Fur.Service
{
    public class ObjectService
    {
        public static List<SelectListItem> UpdateDropDownList(List<SelectListItem> selectListItems,int Id)
        {
            foreach (var selectListItem in selectListItems)
            {
                selectListItem.Selected = false;
            }

            if (Id != 0)
            {
                var IsSelected = selectListItems.Where(x => x.Value == Id.ToString()).ToList().Count>0?true:false;

                if (IsSelected)
                {
                    selectListItems.Where(x => x.Value == Id.ToString()).First().Selected = true;

                    return selectListItems;
                }
            }

            selectListItems.First().Selected = true;


            return selectListItems;
        }

        public static string IsProductInBasketItem(Basket basket,string TypeItem )
        {

            var Product= ProductService.GetProductById(basket.Offer.ProductId);


            if (Product != null)
            {
                if (TypeItem == "Photo") { return Product.Photo; }
                if (TypeItem == "Name") { return Product.Name; }
            }
            if (TypeItem == "Name") { return basket.Offer.ArtNo; }
            return null;
        }

        public static Product GetProduct(Good good)
        {
            var Product = ProductService.GetProductById(good.Offer.ProductId);

            if (Product != null)
            {
                return Product;
            }
            else
            {

                Product = new Product() { Name = good.Offer.ArtNo,Photo=null };

                return Product;
            }
        }


    }
}