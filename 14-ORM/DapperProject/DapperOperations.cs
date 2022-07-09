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

        public void InsertOrder(OrderModel order1)
        {
            throw new NotImplementedException();
        }
    }
}
