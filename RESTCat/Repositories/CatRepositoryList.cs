using RESTCat.Interfaces;
using RESTCat.Models;

namespace RESTCat.Repositories
{
    public class CatRepositoryList : ICatRepository
    {
        private List<Cat> _cats = new List<Cat>();

        private int _nextId=1;

        public Cat AddCat(Cat cat)
        {
            cat.Id = _nextId++;
            _cats.Add(cat);
            return cat;
        }

        public Cat? DeleteCat(int id)
        {
            var catToBeDeleted = GetCatById(id);
            if (catToBeDeleted == null)
            {
                return null;
            }
            _cats.Remove(catToBeDeleted);
            return catToBeDeleted;
        }

        public Cat? GetCatById(int id)
        {
            return _cats.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Cat>? GetCats(string? name = null, string? breed = null, string? color = null, string? sortOrder = null)
        {
            IEnumerable<Cat> result = _cats.AsReadOnly();
            if (name != null)
            {
                result = result.Where(c => c.Name != null && c.Name.Contains(name));
            }
            if (breed != null)
            {
                result = result.Where(c => c.Breed != null && c.Breed.Contains(breed));
            }
            if (color != null)
            {
                result = result.Where(c => c.Color != null && c.Color.Contains(color));
            }
            if (sortOrder != null)
            {
                switch (sortOrder.ToLower())
                {
                    case "name":
                        result = result.OrderBy(c => c.Name);
                        break;
                    case "age":
                        result = result.OrderBy(c => c.Age);
                        break;
                    case "breed":
                        result = result.OrderBy(c => c.Breed);
                        break;
                    case "color":
                        result = result.OrderBy(c => c.Color);
                        break;
                    default:
                        break;
                }
            }
            return result;

        }



        public Cat? UpdateCat(int id, Cat newData)
        {
            Cat catToBeUpdated = GetCatById(id);
            if (catToBeUpdated != null)
            {
                catToBeUpdated.Name = newData.Name ?? catToBeUpdated.Name;
                catToBeUpdated.Age = newData.Age != 0 ? newData.Age : catToBeUpdated.Age;
                catToBeUpdated.Breed = newData.Breed ?? catToBeUpdated.Breed;
                catToBeUpdated.Color = newData.Color ?? catToBeUpdated.Color;
            }
            return catToBeUpdated;
        }
    }
}
