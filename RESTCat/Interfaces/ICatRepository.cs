using RESTCat.Models;

namespace RESTCat.Interfaces
{
    public interface ICatRepository
    {

        Cat AddCat(Cat cat);
        Cat? GetCatById(int id);
        Cat? UpdateCat(int id, Cat newData);
        Cat? DeleteCat(int id);
        IEnumerable<Cat>? GetCats(string? name = null, string? breed = null, string? color = null, string? sortOrder = null);
    }
}
