using Category_Service.Models;
using Category_Service.Repositories;

namespace Category_Service.Services
{
    public class CategoryService: ICategoryService
    {
        private readonly ICategoryRepository _repository;
        public CategoryService(ICategoryRepository repository) => _repository = repository;

        public Task<IEnumerable<Category>> GetAllCategories() => _repository.GetAllAsync();
        public Task<Category> GetCategoryById(int id) => _repository.GetByIdAsync(id);
        public Task CreateCategory(Category category) => _repository.AddAsync(category);
        public Task UpdateCategory(Category category) => _repository.UpdateAsync(category);
        public Task RemoveCategory(int id) => _repository.DeleteAsync(id);
    }
}
