using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPOS.Entity.EntityModels;

namespace SmartPOS.Gateway
{
  public  class ProductGateway:ConnectionGateway
    {
        public List<Category> FillCategory(int id)
        {
           
                try
                {
                   // Query = "Select * From tbl_Category where BrandId=@Id";
                    Query = "SELECT c.CategoryId,CategoryName,b.Name FROM tbl_Category c left outer join tbl_Brand b on c.BrandId = b.BrandId where b.BrandId = @id";
                    Command.CommandText = Query;
                    Command.Parameters.Clear();
                    Command.Parameters.AddWithValue("@Id", id);
                    Connection.Open();
                    Reader = Command.ExecuteReader();
                //  Category category = null;
                List<Category> categories = new List<Category>();

               
                    while (Reader.Read())
                    {
                        Category category = new Category()
                        {
                            Id = (int)Reader["CategoryId"],
                            Name = Reader["CategoryName"].ToString(),
                            Brand = Reader["Name"].ToString()

                        };
                        categories.Add(category);
                    }
               
                Reader.Close();
                 return categories;
                }
                finally
                {
                    if (Connection != null && Connection.State != ConnectionState.Closed)
                    {
                        Connection.Close();
                    }
                }
            }

        public int Save(Product product)
        {
            try
            {
                Query = "Insert into tbl_Product (MaterialTypeId,BrandId,CategoryId,ModelNo,ProductName,Description,CreateDate) values ('" + product.MaterialTypeId + "','" + product.BrandId + "','" + product.CategoryId + "','" + product.Code + "','" + product.Name + "','" + product.Description + "',GETDATE()) ";
                Command.CommandText = Query;
                Connection.Open();
                int rowAfftected = Command.ExecuteNonQuery();
                return rowAfftected;
            }
            finally
            {
                if (Connection != null && Connection.State != ConnectionState.Closed)
                {
                    Connection.Close();
                }
            }
        }

        public int Update(Product product)
        {
            try
            {
                Query = "UPDATE tbl_Product SET MaterialTypeId=@MaterialTypeId,BrandId=@BrandId,CategoryId=@CategoryId,ModelNo=@ModelNo, ProductName=@ProductName,Description=@Description,Image=@Image, UpdateDate=GetDate() WHERE ProductId=@Id";
                Command.CommandText = Query;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("ProductName", product.Name);
                Command.Parameters.AddWithValue("MaterialTypeId", product.MaterialTypeId);
                Command.Parameters.AddWithValue("BrandId", product.BrandId);
                Command.Parameters.AddWithValue("CategoryId", product.CategoryId);
                Command.Parameters.AddWithValue("ModelNo", product.Code);
                Command.Parameters.AddWithValue("Description", product.Description);
             //   Command.Parameters.AddWithValue("Image", product.Image);

                Command.Parameters.AddWithValue("ProductId", product.Id);
                Connection.Open();
                int rowAffected = Command.ExecuteNonQuery();
                return rowAffected;
            }
            finally
            {
                if (Connection != null && Connection.State != ConnectionState.Closed)
                {
                    Connection.Close();
                }
            }
        }

        public List<Product> GetAllProduct()
        {
            try
            {
                Query = @"Select ProductId,m.Name,b.Name,c.CategoryName,p.ModelNo,p.ProductName from tbl_Product p
                left outer join tbl_MaterialType m on p.MaterialTypeId = m.MaterialTypeId
                left outer join tbl_Brand b on p.BrandId = b.BrandId
                left outer join tbl_Category c on p.CategoryId = c.CategoryId";
                Connection.Open();
                Command.CommandText = Query;
                Reader = Command.ExecuteReader();

                List<Product> products = new List<Product>();
                while (Reader.Read())
                {
                    Product Product = new Product()
                    {
                        Id = (int)Reader["ProductId"],
                        MaterialTypeId = Reader["Name"].ToString(),
                        BrandId = Reader["Name"].ToString(),
                        CategoryId = Reader["CategoryName"].ToString(),
                        Code = Reader["ModelNo"].ToString(),
                       // Description = Reader["Description"].ToString(),
                       // Image = (Byte)Reader["Image"],
                        Name = Reader["ProductName"].ToString()

                    };

                    products.Add(Product);

                }

                Reader.Close();
                return products;
            }
            finally
            {
                if (Connection != null && Connection.State != ConnectionState.Closed)
                {
                    Connection.Close();
                }
            }
        }
    }
    
}
