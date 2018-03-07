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
                Query = "Insert into tbl_Brand (MaterialTypeId,BrandId,CategoryId,ModelNo,Name,Description,Image,CreateDate) values ('" + product.MaterialTypeId + "','" + product.BrandId + "','" + product.CategoryId + "','" + product.Model + "','" + product.Name + "','" + product.Description + "',GETDATE()) ";
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
                Query = "UPDATE tbl_Product SET MaterialTypeId=@MaterialTypeId,BrandId=@BrandId,CategoryId=@CategoryId,ModelNo=@ModelNo, Name=@Name,Description=@Description,Image=@Image, UpdateDate=GetDate() WHERE ProductId=@Id";
                Command.CommandText = Query;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("Name", product.Name);
                Command.Parameters.AddWithValue("MaterialTypeId", product.MaterialTypeId);
                Command.Parameters.AddWithValue("BrandId", product.BrandId);
                Command.Parameters.AddWithValue("CategoryId", product.CategoryId);
                Command.Parameters.AddWithValue("ModelNo", product.Model);
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
                Query = "Select * from tbl_Product";
                Connection.Open();
                Command.CommandText = Query;
                Reader = Command.ExecuteReader();

                List<Product> products = new List<Product>();
                while (Reader.Read())
                {
                    Product Product = new Product()
                    {
                        Id = (int)Reader["ProductId"],
                        MaterialTypeId = (int)Reader["MaterialTypeId"],
                        BrandId = (int)Reader["BrandId"],
                        CategoryId = (int)Reader["CategoryId"],
                        Model = Reader["ModelNo"].ToString(),
                        Description = Reader["Description"].ToString(),
                       // Image = (Byte)Reader["Image"],
                        Name = Reader["Name"].ToString()

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
