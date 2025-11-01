using System;
using System.Collections.Generic;
using Task.Models;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

namespace Task.DAOs
{
    public class ProductDAO : IProductDAO
    {
        private readonly MySqlConnection _mysqlConnection;

        private static readonly string GetAllProductsQuery = "SELECT * FROM monk.product";
        private static readonly string GetProductByIdQuery = "SELECT * FROM monk.product WHERE id = @productId";

        public ProductDAO(IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("OfficeDB")
                ?? throw new ArgumentNullException("Connection string `OfficeDB` cannot be null");

            _mysqlConnection = new MySqlConnection(connectionString);
            _mysqlConnection.Open();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();

            using (MySqlCommand command = new MySqlCommand(GetAllProductsQuery, _mysqlConnection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Product product = new Product
                        {
                            ProductId = reader.GetInt32("id"),
                            Name = reader.GetString("name"),
                            Price = reader.GetDecimal("price"),
                            Rating = reader.GetDecimal("rating"),
                            Category = reader.GetString("category"),
                            Description = reader.GetString("description"),
                            Image = reader.GetString("image_url"),
                            Stock = reader.GetInt32("stock"),
                            Discount = reader.GetString("tax_on_product")
                        };

                        products.Add(product);
                    }
                }
            }

            return products;
        }

        public Product? GetProductById(int productId)
        {
            using (MySqlCommand command = new MySqlCommand(GetProductByIdQuery, _mysqlConnection))
            {
                command.Parameters.AddWithValue("@productId", productId);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Product product = new Product
                        {
                            ProductId = reader.GetInt32("id"),
                            Name = reader.GetString("name"),
                            Price = reader.GetDecimal("price"),
                            Rating = reader.GetDecimal("rating"),
                            Category = reader.GetString("category"),
                            Description = reader.GetString("description"),
                            Image = reader.GetString("image_url"),
                            Stock = reader.GetInt32("stock"),
                            Discount = reader.GetString("tax_on_product")
                        };

                        return product;
                    }
                }
            }

            return null;
        }

        ~ProductDAO()
        {
            _mysqlConnection.Close();
        }
    }
}
