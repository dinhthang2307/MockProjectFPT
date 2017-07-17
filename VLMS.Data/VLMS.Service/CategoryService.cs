using System.Collections.Generic;
using System.Linq;
using VLMS.Database;
using VLMS.Database.Infracstructure;
using VLMS.Database.Repository;


namespace VLMS.Service
{
    public interface ICategoryService{

        Category Add(Category category);
        void Update(Category category);
        Category Delete(int id);
        IEnumerable<Category> GetAll();
        //IEnumerable<Item> GetAllByParentId(int parentId);
        IEnumerable<Category> GetAll(string keyWord);
        Category GetById(int id);
        void save();
    }
    class CategoryService : ICategoryService
    {
        ICategoryRepository _categoryRepository;
        IUnitOfWork _unitOfWork;

        public CategoryService(ICategoryRepository categoryService, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryService;
            _unitOfWork = unitOfWork;
        }
        public Category Add(Category category)
        {
            return _categoryRepository.Add(category);
        }

        public Category Delete(int id)
        {
            return _categoryRepository.Delete(id);
        }

        public IEnumerable<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public IEnumerable<Category> GetAll(string keyWord)
        {
            if (!string.IsNullOrEmpty(keyWord))

                return _categoryRepository.GetMulti(x => x.Name.Contains(keyWord) || x.Description.Contains(keyWord));
            else
            {
                return _categoryRepository.GetAll();
            }
        }

        public Category GetById(int id)
        {
            return _categoryRepository.GetSingleById(id);
        }

        public void save()
        {
            _unitOfWork.Commit();
            

        }

        public void Update(Category item)
        {
            _categoryRepository.Update(item);
        }
    }
}
