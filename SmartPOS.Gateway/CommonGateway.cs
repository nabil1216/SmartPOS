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
   public class CommonGateway:ConnectionGateway
    {
        public List<Common> GetAllCategories()
        {
            try
            {
                Query = "Select * from tbl_Category";
                Connection.Open();
                Command.CommandText = Query;
                Reader = Command.ExecuteReader();

                List<Common> commons = new List<Common>();
                while (Reader.Read())
                {
                    Common Common = new Common()
                    {
                        Id = (int)Reader["CategoryId"],
                        Name = Reader["CategoryName"].ToString()

                    };

                    commons.Add(Common);

                }

                Reader.Close();
                return commons;
            }
            finally
            {
                if (Connection != null && Connection.State != ConnectionState.Closed)
                {
                    Connection.Close();
                }
            }
        }


        //Get All Brand

        public List<Common> GetAllBrand()
        {
            try
            {
                Query = "Select * from tbl_Brand";
                Connection.Open();
                Command.CommandText = Query;
                Reader = Command.ExecuteReader();

                List<Common> commons = new List<Common>();
                while (Reader.Read())
                {
                    Common Common = new Common()
                    {
                        Id = (int)Reader["BrandId"],
                        Name = Reader["Name"].ToString()

                    };

                    commons.Add(Common);

                }

                Reader.Close();
                return commons;
            }
            finally
            {
                if (Connection != null && Connection.State != ConnectionState.Closed)
                {
                    Connection.Close();
                }
            }
        }

        public List<Common> GetAllUnit()
        {
            try
            {
                Query = "Select * from tbl_Unit";
                Connection.Open();
                Command.CommandText = Query;
                Reader = Command.ExecuteReader();

                List<Common> commons = new List<Common>();
                while (Reader.Read())
                {
                    Common Common = new Common()
                    {
                        Id = (int)Reader["UnitId"],
                        Name = Reader["UnitName"].ToString()

                    };

                    commons.Add(Common);

                }

                Reader.Close();
                return commons;
            }
            finally
            {
                if (Connection != null && Connection.State != ConnectionState.Closed)
                {
                    Connection.Close();
                }
            }
        }

        public List<Common> GetAllProduct(string prefix)
        {
            try
            {
                Query = "Select * from tbl_Product where ModelNo like '%'+@prefix+'%'";
                Command.CommandText = Query;
                Command.Parameters.Clear();
                Command.Parameters.AddWithValue("@prefix", prefix);
                Connection.Open();
                Command.CommandText = Query;
                Reader = Command.ExecuteReader();

                List<Common> commons = new List<Common>();
                while (Reader.Read())
                {
                    Common Common = new Common()
                    {
                        Id = (int)Reader["ProductId"],
                        Name = Reader["ModelNo"].ToString(),
                        ProductName = Reader["ProductName"].ToString()

                    };

                    commons.Add(Common);

                }

                Reader.Close();
                return commons;
            }
            finally
            {
                if (Connection != null && Connection.State != ConnectionState.Closed)
                {
                    Connection.Close();
                }
            }
        }

        //public List<Common> GetAllVat()
        //{
        //    try
        //    {
        //        Query = "Select * from tbl_Vat";
        //        Connection.Open();
        //        Command.CommandText = Query;
        //        Reader = Command.ExecuteReader();

        //        List<Common> commons = new List<Common>();
        //        while (Reader.Read())
        //        {
        //            Common Common = new Common()
        //            {
        //                Id = (int)Reader["VatId"],
        //                Name =(double) Reader["Value"]

        //            };

        //            commons.Add(Common);

        //        }

        //        Reader.Close();
        //        return commons;
        //    }
        //    finally
        //    {
        //        if (Connection != null && Connection.State != ConnectionState.Closed)
        //        {
        //            Connection.Close();
        //        }
        //    }
        //}

        public List<Common> GetAllMaterialTypes()
        {
            try
            {
                Query = "Select * from tbl_MaterialType";
                Connection.Open();
                Command.CommandText = Query;
                Reader = Command.ExecuteReader();

                List<Common> commons = new List<Common>();
                while (Reader.Read())
                {
                    Common Common = new Common()
                    {
                        Id = (int)Reader["MaterialTypeId"],
                        Name = Reader["Name"].ToString()

                    };

                    commons.Add(Common);

                }

                Reader.Close();
                return commons;

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

