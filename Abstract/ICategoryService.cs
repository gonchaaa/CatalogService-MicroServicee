using CatalogService.Core.Utilities.Results.Abstract;
using CatalogService.DataAccess.DTOs.CatageroyDTO;
using CatalogService.Entities.DTOs.CatageroyDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Business.Abstract
{
    public interface ICategoryService
    {
        IResult CreateCategory(CategoryCreateDTO categoryCreate);
        IResult UpdateCategory(int id, CategoryUpdateDTO category);
        // Async method
        Task<IResult> CreateCategoryAsync(CategoryCreateDTO categoryCreate);

    }
}
