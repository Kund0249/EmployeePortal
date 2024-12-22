using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeePortal.Examples
{
   public class Product
    {
        public string ProductImage { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
    }

    public class ProductRepository
    {
        string ImagePath;
        public ProductRepository()
        {
            ImagePath = @"../Content/App-Icons/istockphoto-1389128157-612x612.jpg";
        }


        public List<Product> GetProducts
        {
            get
            {
                return new List<Product>()
                {
                    new Product(){ProductImage = ImagePath,Name="Lemon",Desc = "This is a test text."},
                    new Product(){ProductImage = ImagePath,Name="Orange",Desc = "This is a test text."},
                    new Product(){ProductImage = ImagePath,Name="Yellow Lemon",Desc = "This is a test text."}
                }; 
            }
        }
    }
    public partial class RepeaterExample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               var data = new ProductRepository().GetProducts;

                productGallery.DataSource = data;
                productGallery.DataBind();
            }
        }
    }
}