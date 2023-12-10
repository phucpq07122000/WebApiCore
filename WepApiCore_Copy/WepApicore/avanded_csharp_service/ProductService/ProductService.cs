using advanded_csharp_database;
using advanded_csharp_database.Models;
using advanded_csharp_dto.DTOEnitity;
using advanded_csharp_dto.Request;
using advanded_csharp_dto.Response;
using Microsoft.EntityFrameworkCore;

namespace advanded_csharp_service.ProductService
{
    public class ProductService : IProductService
    {
        /// <summary>
        /// Add new Product
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<bool> AddNewProduct(ProductDto request)
        {

            if (request != null)
            {
                using DataDbContext context = new();
                if (context.Products != null)
                {
                    Product product = new()
                    {
                        Name = request.Name,
                        Price = request.Price,
                        Category = request.Category,
                        Images = request.Images,
                        Quantity = request.Quantity,
                        Unit = request.Unit,
                    };

                    _ = await context.Products.AddAsync(product);

                    int i = await context.SaveChangesAsync(); //save change trả về int
                    return i > 0;
                }
            }
            return false;
        }


        /// <summary>
        /// Get detail Product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<ProductDto> GetDetailProduct(Guid id)
        {
            ProductDto productResponse = new();
            using (DataDbContext context = new())
            {
                if (context.Products != null)
                {
                    IQueryable<Product> query = context.Products
                        .Where(p => p.Id == id);
                    Product? product = query.FirstOrDefault();
                    if (product != null)
                    {
                        productResponse = new()
                        {
                            Id = product.Id,
                            Name = product.Name,
                            Category = product.Category,
                            Images = product.Images,
                            Price = product.Price,
                            Quantity = product.Quantity,
                            Unit = product.Unit,
                        };
                    }
                }

            }
            return Task.FromResult(productResponse);
        }

        /// <summary>
        /// Get product list follow name or all
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<GetDataProductResponse> GetProductList(GetListProductRequest request)
        {
            GetDataProductResponse getDataProductResponse = new()
            {
                PageSize = request.PageSize,
                PageIndex = request.PageIndex
            };
            using (DataDbContext context = new())
            {
                if (context.Products != null)
                {
                    IQueryable<Product> query = context.Products
                    .Where(a => a.Name.Contains(request.ProductName))
                    .OrderBy(a => a.Quantity)
                    .AsQueryable(); // not excute

                    getDataProductResponse.Data = await query
                        .Skip(request.PageSize * (request.PageIndex - 1))
                        .Take(request.PageSize)
                        .Select(a => new ProductDto
                        {
                            Id = a.Id,
                            Category = a.Category,
                            Name = a.Name,
                            Price = a.Price,
                            Quantity = a.Quantity,
                            CreatedAt = a.CreatedAt,
                        }).ToListAsync();

                    getDataProductResponse.Total = await query.CountAsync();
                }
            }
            return getDataProductResponse;
        }

        /// <summary>
        /// Update Data
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        /// <example> best description </example>
        /// <link> https://stackoverflow.com/questions/46657813/how-to-update-record-using-entity-framework-core</link>
        /// <link> https://learn.microsoft.com/en-us/ef/core/saving/disconnected-entities#saving-single-entities</link>
        public async Task<ProductDto> UpdateProduct(ProductDto request)
        {
            using DataDbContext context = new();
            if (context.Products != null)
            {
                Product? existingProduct = context.Products.Find(request.Id);
                if (existingProduct != null)
                {
                    _ = context.Products.Update(FindValueChangeAndReplace(request, existingProduct));
                    _ = await context.SaveChangesAsync();
                    return await GetDetailProduct(request.Id);
                }
            }
            return await GetDetailProduct(request.Id);
        }



        /// <summary>
        /// Method Check Vallue update which is not have value
        /// </summary>
        /// <param name="requestUpdate"></param>
        /// <param name="existingProduct"></param>
        /// <returns></returns>
        public Product FindValueChangeAndReplace(ProductDto requestUpdate, Product existingProduct)
        {
            existingProduct.Name = (requestUpdate.Name != "") ? requestUpdate.Name : existingProduct.Name;
            existingProduct.Price = (requestUpdate.Price != "") ? requestUpdate.Price : existingProduct.Price;
            existingProduct.Unit = (requestUpdate.Unit != "") ? requestUpdate.Unit : existingProduct.Unit;
            existingProduct.Quantity = (requestUpdate.Quantity == 0) ? requestUpdate.Quantity : existingProduct.Quantity;
            existingProduct.Category = (requestUpdate.Category != "") ? requestUpdate.Category : existingProduct.Category;
            existingProduct.Images = (requestUpdate.Images != "") ? requestUpdate.Images : existingProduct.Images;
            return existingProduct;

        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteProduct(Guid requestID)
        {
            using DataDbContext context = new();
            if (context.Products != null)
            {
                Product? products = context.Products.Find(requestID);
                if (products != null)
                {
                    _ = context.Products.Attach(products); // check existing?
                    _ = context.Products.Remove(products);
                    int i = await context.SaveChangesAsync(); //save change trả về int
                    return i > 0;
                }
            }
            return false;
        }
    }
}
