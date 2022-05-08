using APICrudWithRepository.Models.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICrudWithRepository.Models.Repository.Services
{

    public class ProductServices : IProduct
    {
        private readonly ApplicationDbContext dbContext;

        public ProductServices(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;       
        }

        public Product DeleteProduct(int id)
        {
            try
            {
                var prod = dbContext.Products.SingleOrDefault(e => e.Id == id);
                if (prod != null)
                {
                    dbContext.Products.Remove(prod);
                    dbContext.SaveChanges();
                    return prod;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public Product GetProductById(int Id)
        {
            try
            {
                var prod = dbContext.Products.SingleOrDefault(e => e.Id == Id);
                return prod;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<Product> GetProducts()
        {
            try
            {
                var prod = dbContext.Products.ToList();
                return prod;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Product PostProduct(Product product)
        {
            try
            {
                dbContext.Products.Add(product);
                dbContext.SaveChanges();
                return product;
                 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Product UpdateProduct(Product product)
        {
            try
            {
                var prod = dbContext.Products.SingleOrDefault(e => e.Id == product.Id);
                if (prod != null)
                {
                    prod.Title = product.Title;
                    prod.Price = product.Price;
                    prod.Quantity = product.Quantity;
                    prod.Category = product.Category;
                    prod.Description = product.Description;
                    dbContext.Products.Update(prod);
                    dbContext.SaveChanges();
                    return prod;
                }
                else
                {
                    return null;
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
