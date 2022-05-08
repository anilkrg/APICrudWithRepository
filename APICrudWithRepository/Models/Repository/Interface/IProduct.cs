using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICrudWithRepository.Models.Repository.Interface
{
   public interface IProduct
    {
        List<Product> GetProducts();
        Product GetProductById(int Id);
        Product PostProduct(Product product);
        Product UpdateProduct(Product product);
        Product DeleteProduct(int Id);
    }
}
