using MYARCH.CORE;
using MYARCH.CORE.Constants;
using MYARCH.DATA.GenericRepository;
using MYARCH.DATA.UnitofWork;
using MYARCH.DTO.EEntity;
using MYARCH.SERVICES.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYARCH.SERVICES.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IGenericRepository<Category> _categoryRepository;
        //private readonly IGenericRepository<Post> _postRepository;
        private readonly IUnitofWork _uow;

        public CategoryService(UnitofWork uow)
        {
            _uow = uow;
            _categoryRepository = uow.GetRepository<Category>();
            //_postRepository = uow.GetRepository<Post>();
        }

        public List<ECategoryDTO> GetCategories()
        {
            var result = (from c in _categoryRepository.GetAll()
                          select new ECategoryDTO
                          {
                              Color = c.Color,
                              Id = c.Id,
                              Name = c.Name,
                              Icon = c.Icon
                          }).ToList();
            return result;
        }

        public ECategoryDTO GetCategoryDetailByCategoryId(int categoryId)
        {
            var result = (from c in _categoryRepository.GetAll()
                          where c.Id == categoryId
                          select new ECategoryDTO
                          {
                              Color = c.Color,
                              Id = c.Id,
                              Name = c.Name,
                              Icon = c.Icon
                          }).SingleOrDefault();
            return result;
        }

        public void Insert(ECategoryDTO category)
        {
            var categoryEntity = AutoMapper.Mapper.DynamicMap<Category>(category);
            _categoryRepository.Insert(categoryEntity);
        }

        public void Update(ECategoryDTO category)
        {
            var categoryEntity = _categoryRepository.Find(category.Id);
            AutoMapper.Mapper.DynamicMap(category, categoryEntity);
            _categoryRepository.Update(categoryEntity);
        }
        public void Delete(int Id)
        {
            var categoryEntity = _categoryRepository.Find(Id);
            _categoryRepository.Delete(categoryEntity);
        }
    }
}
