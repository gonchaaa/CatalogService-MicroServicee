using AutoMapper;
using CatalogService.Business.Abstract;
using CatalogService.Core.Utilities.Results.Abstract;
using CatalogService.Core.Utilities.Results.Concrete.SuccessResults;
using CatalogService.DataAccess.Abtract;
using CatalogService.DataAccess.DTOs.CatageroyDTO;
using CatalogService.Entities.Concrete;
using CatalogService.Entities.DTOs.CatageroyDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        private readonly IMapper _mapper;
        public CategoryManager(ICategoryDal categoryDal, IMapper mapper)
        {
            _categoryDal = categoryDal;
            _mapper = mapper;
        }

        public IResult CreateCategory(CategoryCreateDTO categoryCreate)
        {
            var mapCategory = _mapper.Map<Category>(categoryCreate);
            _categoryDal.Add(mapCategory);
            return new SuccessResult();
        }

        public Task<IResult> CreateCategoryAsync(CategoryCreateDTO categoryCreate)
        {
            //var mapCategory = _mapper.Map<Category>(categoryCreate);
            //await _categoryDal.AddCategoryAsync(mapCategory);
            //return new SuccessResult();
            throw new NotImplementedException();
        }

        public IResult UpdateCategory(int id, CategoryUpdateDTO category)
        {
            var mapCategory = _mapper.Map<Category>(category);
            var findCategory = _categoryDal.Get(x => x.Id == id);
            findCategory.CategoryName = mapCategory.CategoryName;
            findCategory.CreatedDate = mapCategory.CreatedDate;
            findCategory.PhotoUrl = mapCategory.PhotoUrl;
            findCategory.IsNavbar = mapCategory.IsNavbar;
            findCategory.IsFeatured = mapCategory.IsFeatured;
            _categoryDal.Update(findCategory);
            return new SuccessResult();
        }
    }
}
