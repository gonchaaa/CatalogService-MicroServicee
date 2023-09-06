using CatalogService.Core.Utilities.Results.Abstract;
using CatalogService.Entities.DTOs.ProductDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Business.Abstract
{
    public interface IProductService
    {
        IResult CreateProduct(ProductCreateDTO productCreateDTO);
    }
}
