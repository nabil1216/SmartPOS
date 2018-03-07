using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartPOS.Entity.EntityModels;

using SmartPOS.Gateway;
namespace SmartPOS.Manager
{
    public class MaterialTypeManager
    {
        MaterialTypeGateway materialTypeGateway=new MaterialTypeGateway();

        public String Save(MaterialType materialType)
        {
            int rowAfftected = materialTypeGateway.Save(materialType);
            if (rowAfftected > 0)
            {
                return "Item Saved";
            }

            return "Save Failed";
        }

        public List<MaterialType> GetAllMaterialTypes()
        {
            return materialTypeGateway.GetAllMaterialTypes();
        }

        public string Update(MaterialType materialType)
        {
            int rowAfftected = materialTypeGateway.Update(materialType);
            if (rowAfftected > 0)
            {
                return "Item Updated";
            }

            return "Update Failed";
        }

        public MaterialType GetMaterialTypeById(int id)
        {
            return materialTypeGateway.GetMaterialTypeById(id);
        }
    }
}
