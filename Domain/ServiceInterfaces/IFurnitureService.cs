
using Domain.Data;
using System.Collections.Generic;

namespace Domain.ServiceInterfaces
{
    public interface IFurnitureService
    {
        public Furniture GetFurniture(int FurnitureId);

        public IEnumerable<Furniture> GetAllFurnitures();
        public IEnumerable<Furniture> GetFurnitureByQuery(string query);
        public IEnumerable<Furniture> GetFurnitureCategory(int query);
        public IEnumerable<Category> GetAllCategories();
    }
}
