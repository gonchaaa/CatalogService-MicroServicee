using CatalogService.Core.EventBus;
using CatalogService.DataAccess.Concrete;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Business.Consumer
{
    public class UpdateProductNameConsumer : IConsumer<ProductNameChangeEvent>
    {
        private readonly AppDbContext _context;

        public UpdateProductNameConsumer(AppDbContext context)
        {
            _context = context;
        }

        public async Task Consume(ConsumeContext<ProductNameChangeEvent> context)
        {
            var updatedData = _context.Products.Where(x => x.Id == context.Message.Id).ToList();
            var res = updatedData.Select(x => { x.ProductName = context.Message.ProductName; return x; }).ToList();
            _context.SaveChanges();

        }
    }
}
