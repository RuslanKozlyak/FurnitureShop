
using Domain.Data;
using Domain.RepositoryInterfaces;
using Domain.ServiceInterfaces;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class FurnitureService : IFurnitureService
    {
        private readonly IRepository<Furniture> _furnitureRepository;
        private readonly IRepository<Category> _categoryRepository;

        public FurnitureService(IRepository<Furniture> FurnitureRepository)
        {
            _furnitureRepository = FurnitureRepository;
        }

        public Furniture GetFurniture(int FurnitureId)
        {
            var Furniture = _furnitureRepository.Get(FurnitureId,include => include.Category);
            return Furniture;
        }

        public IEnumerable<Furniture> GetAllFurnitures()
        {
            var Furniture = _furnitureRepository.GetAll();
            return Furniture;
        }

        public IEnumerable<Furniture> GetFurnitureByQuery(string query)
        {
            query = query.ToUpper();
            var findedFurnitures = _furnitureRepository.GetAll()
              .Where(Furniture => Furniture.ProductName.ToUpper().Contains(query)).ToList();
            return findedFurnitures;
        }

        public IEnumerable<Furniture> GetFurnitureCategory(int query)
        {
            var findedFurnitures = _furnitureRepository.GetAll()
              .Where(Furniture => Furniture.CategoryId.Equals(query)).ToList();
            return findedFurnitures;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            var categories = _categoryRepository.GetAll().ToList();
            return categories;
        }
    }
}
