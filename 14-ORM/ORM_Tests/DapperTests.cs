using DapperProject;
using DapperProject.Models;
using NUnit.Framework;
using System;
using System.Data.SqlClient;

namespace ORM_Tests
{
    public class DapperTests
    {
        private string _connectionString;
        private DapperOperations _dbOperations;

        [SetUp]
        public void Setup()
        {
            _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ORM_database;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            _dbOperations = new DapperOperations(_connectionString);
            TruncateDB();
        }

        private void TruncateDB()
        {
            using var connection = new SqlConnection(_connectionString);
            using var truncateProducts = new SqlCommand("DELETE FROM [Product]; DBCC CHECKIDENT([Product], RESEED, 0);", connection);
            var truncateOrders = new SqlCommand("DELETE FROM [Order]; DBCC CHECKIDENT([Order], RESEED, 0);", connection);
            connection.Open();
            truncateOrders.ExecuteNonQuery();
            truncateProducts.ExecuteNonQuery();
        }

        /// <summary>
        /// This is a single big test which runs all small tests in specified order.
        /// The order is crucial for database data checking.
        /// </summary>
        [Test]
        public void AllTests()
        {
            // CRUD operations:
            // insert tests
            TestScenario_InsertProduct_ProductModelProvided_ProductCreated();
            TestScenario_InsertOrder_OrderModelProvided_OrdersCreated();
            // read test
            TestScenario_ReadOrder_OrderNumberProvided_OrderIsObtained();
            // update test
            TestScenario_UpdateOrderStatus_OrderNumberAndNewStatusProvided_OrderIsUpdated();
            // delete test
            TestScenario_DeleteOrder_OrderNumberProvided_OrderIsDeleted();

        }

        private void TestScenario_InsertProduct_ProductModelProvided_ProductCreated()
        {
            // arrange
            var product1 = new ProductModel()
            {
                Name = "Product 1",
                Description = "Best product",
                Height = 5,
                Weight = 6,
                Length = 7,
                Width = 8
            };

            var product2 = new ProductModel()
            {
                Name = "Product 2",
                Description = "Middle product",
                Height = 9,
                Weight = 10,
                Length = 11,
                Width = 12
            };

            var product3 = new ProductModel()
            {
                Name = "Product 3",
                Description = "Worst product",
                Height = 13,
                Weight = 14,
                Length = 15,
                Width = 16
            };

            // act
            var actualAffectedRows = 0;
            actualAffectedRows += _dbOperations.InsertProduct(product1);
            actualAffectedRows += _dbOperations.InsertProduct(product2);
            actualAffectedRows += _dbOperations.InsertProduct(product3);
            var expectedAffectedRows = 3;

            // assert
            Assert.AreEqual(expectedAffectedRows, actualAffectedRows);
        }

        private void TestScenario_InsertOrder_OrderModelProvided_OrdersCreated()
        {
            // arrange
            var order1 = new OrderModel()
            {
                CreatedDate = DateTime.Parse("2012-04-06"),
                UpdatedDate = DateTime.Parse("2012-04-20"),
                Status = OrderStatus.NotStarted,
                ProductId = 1
            };
            var order2 = new OrderModel()
            {
                CreatedDate = DateTime.Parse("2015-04-06"),
                UpdatedDate = DateTime.Parse("2015-04-20"),
                Status = OrderStatus.InProgress,
                ProductId = 2
            };
            var order3 = new OrderModel()
            {
                CreatedDate = DateTime.Parse("2018-04-06"),
                UpdatedDate = DateTime.Parse("2018-04-20"),
                Status = OrderStatus.Arrived,
                ProductId = 3
            };

            // act
            var actualAffectedRows = 0;
            actualAffectedRows += _dbOperations.InsertOrder(order1);
            actualAffectedRows += _dbOperations.InsertOrder(order2);
            actualAffectedRows += _dbOperations.InsertOrder(order3);
            var expectedAffectedRows = 3;

            // assert
            Assert.AreEqual(expectedAffectedRows, actualAffectedRows);
        }

        /// <summary>
        /// This test expects data from Insert test to be present.
        /// </summary>
        private void TestScenario_ReadOrder_OrderNumberProvided_OrderIsObtained()
        {
            // arrange
            var orderNumber = 2;

            // act
            var actualOrder = _dbOperations.ReadOrder(orderNumber);
            var expectedOrder = new OrderModel()
            {
                CreatedDate = DateTime.Parse("2015-04-06"),
                UpdatedDate = DateTime.Parse("2015-04-20"),
                Status = OrderStatus.InProgress,
                ProductId = 2
            };

            // assert
            TestHelpers.AreEqualByJson(actualOrder, expectedOrder);
        }

        private void TestScenario_UpdateOrderStatus_OrderNumberAndNewStatusProvided_OrderIsUpdated()
        {
            // arrange
            var orderNumber = 2;
            var newStatus = OrderStatus.Done;
            var now = DateTime.Now;
            var expectedOrder = new OrderModel()
            {
                CreatedDate = DateTime.Parse("2015-04-06"),
                UpdatedDate = new DateTime(now.Year, now.Month, now.Day),
                Status = newStatus,
                ProductId = orderNumber
            };

            // act
            var actualOrder = _dbOperations.UpdateOrderStatus(orderNumber, newStatus);

            // assert
            TestHelpers.AreEqualByJson(expectedOrder, actualOrder);
        }

        private void TestScenario_DeleteOrder_OrderNumberProvided_OrderIsDeleted()
        {
            // arrange
            var orderNumber = 3;

            // act
            var deleteStatusOK = _dbOperations.DeleteOrder(orderNumber);
            var isOrderDeleted = (deleteStatusOK) && (_dbOperations.ReadOrder(orderNumber) == null);

            // assert
            Assert.IsTrue(isOrderDeleted);
        }
    }
}