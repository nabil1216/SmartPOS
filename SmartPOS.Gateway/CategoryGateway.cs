using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPOS.Entity.EntityModels;
using System.Configuration;
using System.Data;
namespace SmartPOS.Gateway
{
    public class CategoryGateway: CommonGateway
    {
        public List<Category> GetAllCategories()
        {
            try
            {
                Query = "SELECT category.CategoryId,category.CategoryName,brand.Name FROM tbl_Category category inner join tbl_Brand brand on category.BrandId = brand.BrandId";
                Connection.Open();
                Command.CommandText = Query;
                Reader = Command.ExecuteReader();

                List<Category> categories = new List<Category>();
                while (Reader.Read())
                {
                    Category Category = new Category()
                    {
                        Id = (int) Reader["CategoryId"],
                        
                        Brand = Reader["Name"].ToString(),
                        Name = Reader["CategoryName"].ToString()
                    };

                    categories.Add(Category);

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

        public int Save(Category category)
        {
            try
            {
                Query = "Insert into tbl_Category (CategoryName,BrandId,CreateDate) values ('" + category.Name + "','"+category.Brand+"',GETDATE()) ";
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

        public Category GetById(int id)
        {
            try
            {
                Query = "SELECT *,brand.Name FROM tbl_Category category inner join tbl_Brand brand on category.BrandId = brand.BrandId WHERE CategoryId = @Id";
                Command.CommandText = Query;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("Id", id);
                Connection.Open();
                Reader = Command.ExecuteReader();
                Category category = null;
                if (Reader.HasRows)
                {
                    Reader.Read();
                    category = new Category()
                    {
                        Id = (int)Reader["CategoryId"],
                        Brand= Reader["BrandId"].ToString(),
                        Name = Reader["CategoryName"].ToString()
                    };
                }
                Reader.Close();
                return category;
            }
            finally
            {
                if (Connection != null && Connection.State != ConnectionState.Closed)
                {
                    Connection.Close();
                }
            }
        }

        public int Update(Category category)
        {
            try
            {
                Query = "UPDATE tbl_Category SET CategoryName=@CategoryName,BrandId=@BrandId, UpdateDate=GetDate() WHERE CategoryId=@Id";
                Command.CommandText = Query;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("CategoryName", category.Name);
                Command.Parameters.AddWithValue("Id", category.Id);
                Command.Parameters.AddWithValue("BrandId", category.Brand);
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
    }
}
