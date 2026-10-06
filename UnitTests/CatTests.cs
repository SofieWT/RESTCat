using Xunit;
using RESTCat.Models;
using RESTCat.Repositories;
namespace UnitTests
{
    public class CatTests
    {

        Cat cat1 = new Cat { Id = 1, Name = "Kiki", Age = 9, Breed = "Maine Coon", Color = "White" };
        Cat cat2 = new Cat { Id = 2, Name = "Nala", Age = 11, Breed = "Maine Coon", Color = "Red" };

        [Fact]
        public void AddCat_AddsCatToRepository()
        {
            //Arrange
            CatRepositoryList catRepository = new CatRepositoryList();
            //Act
            Cat AddedCat1 = catRepository.AddCat(cat1);
            Cat AddedCat2 = catRepository.AddCat(cat2);
            //Assert
            Assert.Equal(2, catRepository.GetCats().Count());
            Assert.NotNull(catRepository.GetCats());
            Assert.NotEmpty(catRepository.GetCats());
            Assert.Same(AddedCat1, catRepository.GetCats().First());
            Assert.Same(AddedCat2, catRepository.GetCats().Last());
            Assert.Same(AddedCat1, cat1);
            Assert.Same(AddedCat2, cat2);

        }
        [Fact]
        public void DeleteCat_DeletesCatFromRepository()
        {
            //Arrange
            CatRepositoryList catRepository = new CatRepositoryList();
            Cat addedCat1 = catRepository.AddCat(cat1);
            Cat addedcat2 = catRepository.AddCat(cat2);
            //Act
            var deletedCat = catRepository.DeleteCat(1);
            //Assert
            Assert.NotNull(deletedCat);
            Assert.NotEmpty(catRepository.GetCats());
            Assert.Equal(1, catRepository.GetCats().Count());
        }
    }
}
