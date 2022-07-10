using DataBaseAccess;
using DataBaseAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic
{
    public class EFOperations
    {
        private DbContextOptions _options;
        public EFOperations()
        {
            _options = new DbContextOptionsBuilder<HomeworkDBContext>()
                .UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ORM_EF;Integrated Security=True")
                .Options;
            using (var dbContext = new HomeworkDBContext(_options))
            {
                dbContext.Database.Migrate();
            }
        }

        public void DeleteAllTables()
        {
            using var dbContext = new HomeworkDBContext(_options);
            dbContext.Database.ExecuteSqlRaw("DELETE FROM [Order]; DBCC CHECKIDENT([Order], RESEED, 0); ");
            dbContext.Database.ExecuteSqlRaw("DELETE FROM [Product]; DBCC CHECKIDENT([Product], RESEED, 0);");
            dbContext.SaveChanges();
        }

        public int InsertProduct(ProductModel product)
        {
            using var dbContext = new HomeworkDBContext(_options);
            dbContext.Add(product);
            var affectedRows = dbContext.SaveChanges();
            return affectedRows;
        }

        public int InsertOrder(OrderModel order)
        {
            using var dbContext = new HomeworkDBContext(_options);
            dbContext.Product.SingleOrDefault(p => p.Id == order.ProductId)?.Orders.Add(order);
            var affectedRows = dbContext.SaveChanges();
            return affectedRows;
        }


        public ProductModel ReadProduct(int productId)
        {
            using var dbContext = new HomeworkDBContext(_options);
            var result = dbContext.Product.SingleOrDefault(p => p.Id == productId);
            return result;
        }

        public ProductModel UpdateProductDecription(int productId, string newDescription)
        {
            using var dbContext = new HomeworkDBContext(_options);
            var productToChange = dbContext.Product.SingleOrDefault(p => p.Id == productId);
            if (productToChange != null)
            {
                productToChange.Description = newDescription;
            }

            var affectedRows = dbContext.SaveChanges();

            // Read and return the result.
            ProductModel udpatedProduct = null;
            if (affectedRows > 0)
            {
                udpatedProduct = ReadProduct(productId);
            }

            return udpatedProduct;
        }

        public bool DeleteProduct(int productId)
        {
            using var dbContext = new HomeworkDBContext(_options);
            var productToDelete = dbContext.Product.SingleOrDefault(p => p.Id == productId);
            if (productToDelete != null)
            {
                dbContext.Product.Remove(productToDelete);
            }

            var affectedRows = dbContext.SaveChanges();
            return affectedRows > 0;

        }
    }
}