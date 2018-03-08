using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPOS.Entity.EntityModels;
using SmartPOS.Gateway;

namespace SmartPOS.Manager
{
  public  class ProductManager
    {
        ProductGateway productGateway=new ProductGateway();
        public List<Category> FillCategory(int id)
        {
            return productGateway.FillCategory(id);
        }

        public String Save(Product product)
        {
            int rowAfftected = productGateway.Save(product);
            if (rowAfftected > 0)
            {
                return "Item Saved";
            }

            return "Save Failed";
        }

        public string Update(Product product)
        {
            int rowAfftected = productGateway.Update(product);
            if (rowAfftected > 0)
            {
                return "Item Updated";
            }

            return "Update Failed";
        }

        public List<Product> GetAllProduct()
        {
            return productGateway.GetAllProduct();
        }

        public Product GetById(int id)
        {
            return productGateway.GetById(id);
        }
    }
}
