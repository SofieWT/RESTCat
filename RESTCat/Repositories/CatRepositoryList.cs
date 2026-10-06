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

        public Cat? GetCats(string? name = null, string? breed = null, string? color = null)
        {
            throw new NotImplementedException();
        }

        public Cat? UpdateCat(int id, Cat newData)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Cat>? ICatRepository.GetCats(string? name, string? breed, string? color)
        {
            throw new NotImplementedException();
        }
    }
}
