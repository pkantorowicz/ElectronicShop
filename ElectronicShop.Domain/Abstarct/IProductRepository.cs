using System.Collections.Generic;
using ElectronicShop.Domain.Entities;

namespace ElectronicShop.Domain.Abstarct
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }

        void SaveProduct(Product product);

        Product DeleteProduct(int productID);
    }
}
