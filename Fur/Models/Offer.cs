using Fur.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fur.Models
{
    public class Offer
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ArtNo { get; set; }
        public int ColorId { get; set; }


        public Color Color {
            get {


                if (ColorId != 0)
                {
                    return ColorService.GetColorById(ColorId);
                }
                return new Color();

            }
        }

        public int SizeId { get; set; }
        public Size size {
            get {


                if (SizeId != 0)
                {
                    return SizeService.GetSizeById(SizeId);
                }
                return new Size();


            } }


        public int Price { get; set; }

        //public Product Product{
        //    get
        //    {
        //        return ProductService.GetProductById(ProductId);

        //    }

        //}
    }


}