using CatalogService.Business.Abstract;
using CatalogService.Core.Utilities.Results.Abstract;
using CatalogService.Core.Utilities.Results.Concrete.ErrorResults;
using CatalogService.Core.Utilities.Results.Concrete.SuccessResults;
using CatalogService.DataAccess.Abtract;
using CatalogService.Entities.DTOs.ProductDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult CreateProduct(ProductCreateDTO productCreateDTO)
        {
            try
            {
                var result = _productDal.CreateProduct(productCreateDTO);
                return new SuccessResult();
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }
        }
    }
}
