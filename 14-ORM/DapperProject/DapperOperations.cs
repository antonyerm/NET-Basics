using Dapper;
using DapperProject.Models;
using System;
using System.Data.SqlClient;

namespace DapperProject
{
    public class DapperOperations
    {
        string _connectionString;

        public DapperOperations(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int InsertProduct(ProductModel product)
        {
            var sql = "INSERT INTO [Product] " +
                "VALUES (@Name, @Description, @Weight, @Height, @Width, @Length);";
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            var affectedRows = connection.Execute(sql,
                new
                {
                    Name = product.Name,
                    Description = product.Description,
                    Weight = product.Weight,
                    Height = product.Height,
                    Width = product.Width,
                    Length = product.Length
                });
            return affectedRows;
        }

        public int InsertOrder(OrderModel order)
        {
            var sql = "INSERT INTO [Order] VALUES (@Status, @CreatedDate, @UpdatedDate, @ProductId);";
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            var affectedRows = connection.Execute(sql,
                new
                {
                    Status = order.Status.ToString(),
                    CreatedDate = order.CreatedDate,
                    UpdatedDate = order.UpdatedDate,
                    ProductId = order.ProductId
                });
            return affectedRows;
        }

        public OrderModel ReadOrder(int orderNumber)
        {
            var sql = "SELECT * FROM [Order] WHERE [Order].Id = @orderNumber";
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            var obtainedOrder = connection.QuerySingleOrDefault<OrderModel>(sql,
                new
                {
                    orderNumber = orderNumber
                });
            return obtainedOrder;
        }

        public OrderModel UpdateOrderStatus(int orderNumber, OrderStatus newOrderStatus)
        {
            var sql = "UPDATE [Order] SET [Order].Status = @Status, [Order].UpdatedDate = @UpdatedDate" +
                " WHERE [Order].Id = @OrderNumber;";
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            var affectedRows = connection.Execute(sql,
                new
                {
                    Status = newOrderStatus.ToString(),
                    UpdatedDate = DateTime.Now.Date,
                    OrderNumber = orderNumber
                });

            // Read and return the result.
            OrderModel udpatedOrder = null;
            if (affectedRows > 0)
            {
                udpatedOrder = ReadOrder(orderNumber);
            }

            return udpatedOrder;
        }

        public bool DeleteOrder(int orderNumber)
        {
            var sql = "DELETE FROM [Order] WHERE [Order].Id = @OrderNumber";
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            var affectedRows = connection.Execute(sql,
                new
                {
                    OrderNumber = orderNumber
                });

            return affectedRows > 0;
        }
    }
}
