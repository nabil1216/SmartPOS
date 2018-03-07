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
   public class MaterialTypeGateway: ConnectionGateway
    {
        public int Save(MaterialType materialType)
        {
            try
            {
                Query = "Insert into tbl_MaterialType (Name,CreateDate) values ('" + materialType.Name + "',GETDATE()) ";
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

        public List<MaterialType> GetAllMaterialTypes()
        {
            try
            {
                Query = "Select * from tbl_MaterialType";
                Connection.Open();
                Command.CommandText = Query;
                Reader = Command.ExecuteReader();

                List<MaterialType> materialTypes = new List<MaterialType>();
                while (Reader.Read())
                {
                    MaterialType materialType = new MaterialType()
                    {
                        Id = (int)Reader["MaterialTypeId"],
                        Name = Reader["Name"].ToString()
                       
                    };

                    materialTypes.Add(materialType);

                }

                Reader.Close();
                return materialTypes;

            }
            finally
            {
                if (Connection != null && Connection.State != ConnectionState.Closed)
                {
                    Connection.Close();
                }
            }
        }

        public int Update(MaterialType materialType)
        {
            try
            {
                Query = "UPDATE tbl_MaterialType SET Name=@Name,UpdateDate=GetDate() WHERE MaterialTypeId=@Id";
                Command.CommandText = Query;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("Name", materialType.Name);
               
                Command.Parameters.AddWithValue("Id", materialType.Id);
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

        public MaterialType GetMaterialTypeById(int id)
        {
            try
            {
                Query = "SELECT * FROM tbl_MaterialType WHERE MaterialTypeId = @Id";
                Command.CommandText = Query;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("Id", id);
                Connection.Open();
                Reader = Command.ExecuteReader();
                MaterialType materialType = null;
                if (Reader.HasRows)
                {
                    Reader.Read();
                    materialType = new MaterialType()
                    {
                        Id = (int)Reader["MaterialTypeId"],
                        Name = Reader["Name"].ToString()
                      
                    };
                }
                Reader.Close();
                return materialType;
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
