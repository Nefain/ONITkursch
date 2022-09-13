using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ONIT_Kursov_3.Models;

namespace ONIT_Kursov_3
{
    public class DBWorker
    {
        static string connectionString = @"Data Source=localhost;Initial Catalog=Northwind;Integrated Security=True";

        public List<Categories> categories;
        public List<CustomerDemographics> customerDemographics;
        public List<Customers> customers;
        public List<Employees> employees;
        public List<EmployeeTerritories> employeeTerritories;
        public List<OrderDetails> orderDetails;
        public List<Orders> orders;
        public List<Products> products;
        public List<Region> regions;
        public List<Shippers> shippers;
        public List<Suppliers> suppliers;
        public List<Territories> territories;

        public void UpdateCategories()
        {
            ClearAll();

            SqlConnection connection = new SqlConnection(connectionString);
            List<Categories> temp = new List<Categories>();

            try
            {
                connection.Open();

                string cmd = "SELECT * FROM [Categories]";
                SqlCommand Command = new SqlCommand(cmd, connection);

                SqlDataReader reader = Command.ExecuteReader();

                while (reader.Read())
                {
                    Categories record = new Categories();

                    record.CategoryID = reader.GetInt32(0);
                    record.CategoryName = reader.GetString(1);
                    record.Description = reader.GetString(2);

                    temp.Add(record);
                }

                reader.Close();

                categories.Clear();
                categories = temp;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            connection.Close();
        }

        public void UpdateCustomerDemographics()
        {
            ClearAll();

            SqlConnection connection = new SqlConnection(connectionString);
            List<CustomerDemographics> temp = new List<CustomerDemographics>();

            try
            {
                connection.Open();

                string cmd = "SELECT * FROM [CustomerDemographics]";
                SqlCommand Command = new SqlCommand(cmd, connection);

                SqlDataReader reader = Command.ExecuteReader();

                while (reader.Read())
                {
                    CustomerDemographics record = new CustomerDemographics();

                    record.CustomerID = reader.GetString(0);
                    record.CustomerTypeID = reader.GetString(1);

                    temp.Add(record);
                }

                reader.Close();

                customerDemographics.Clear();
                customerDemographics = temp;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            connection.Close();
        }

        public void UpdateCustomers()
        {
            ClearAll();

            SqlConnection connection = new SqlConnection(connectionString);
            List<Customers> temp = new List<Customers>();

            try
            {
                connection.Open();

                string cmd = "SELECT * FROM [Customers]";
                SqlCommand Command = new SqlCommand(cmd, connection);

                SqlDataReader reader = Command.ExecuteReader();

                while (reader.Read())
                {
                    Customers record = new Customers();

                    record.CustomerID = reader.GetString(0);
                    record.CompanyName = reader.GetString(1);
                    record.ContactName = reader.GetString(2);
                    record.ContactTitle = reader.GetString(3);
                    record.Address = reader.GetString(4);
                    record.City = reader.GetString(5);

                    try
                    {
                        record.Region = reader.GetString(6);
                    }
                    catch { record.Region = "-"; }

                    try
                    {
                        record.PostalCode = reader.GetString(7);
                    }
                    catch { record.PostalCode = "-"; }

                    record.Country = reader.GetString(8);
                    record.Phone = reader.GetString(9);

                    try
                    {
                        record.Fax = reader.GetString(10);
                    }
                    catch { record.Fax = "-"; }

                    temp.Add(record);
                }

                reader.Close();

                customers.Clear();
                customers = temp;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            connection.Close();
        }

        public void UpdateEmployees()
        {
            ClearAll();

            SqlConnection connection = new SqlConnection(connectionString);
            List<Employees> temp = new List<Employees>();

            try
            {
                connection.Open();

                string cmd = "SELECT * FROM [Employees]";
                SqlCommand Command = new SqlCommand(cmd, connection);

                SqlDataReader reader = Command.ExecuteReader();

                while (reader.Read())
                {
                    Employees record = new Employees();

                    record.EmployeeID = reader.GetInt32(0);
                    record.LastName = reader.GetString(1);
                    record.FirstName = reader.GetString(2);
                    record.Title = reader.GetString(3);
                    record.TitleOfCourtesy = reader.GetString(4);
                    record.BirthDate = reader.GetDateTime(5);
                    record.HireDate = reader.GetDateTime(6);
                    record.Address = reader.GetString(7);
                    record.City = reader.GetString(8);
                    try
                    {
                        record.Region = reader.GetString(9);
                    }
                    catch { record.Region = "-"; }
                    record.PostalCode = reader.GetString(10);
                    record.Country = reader.GetString(11);
                    record.HomePhone = reader.GetString(12);
                    record.Extension = reader.GetString(13);
                    record.Photo = reader.GetSqlBytes(14).Buffer;
                    record.Notes = reader.GetString(15);
                    //try
                    //{
                    //    record.ReportsTo = reader.GetInt32(16);
                    //}
                    //catch { record.ReportsTo = null; }
                    try
                    {
                        var i = reader.GetInt32(16);
                        record.ReportsTo = i.ToString();
                    }
                    catch { record.ReportsTo = "-"; }
                    record.PhotoPath = reader.GetString(17);

                    temp.Add(record);
                }

                reader.Close();

                employees.Clear();
                employees = temp;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            connection.Close();
        }

        public void UpdateEmployeeTerritories()
        {
            ClearAll();

            SqlConnection connection = new SqlConnection(connectionString);
            List<EmployeeTerritories> temp = new List<EmployeeTerritories>();

            try
            {
                connection.Open();

                string cmd = "SELECT * FROM [EmployeeTerritories]";
                SqlCommand Command = new SqlCommand(cmd, connection);

                SqlDataReader reader = Command.ExecuteReader();

                while (reader.Read())
                {
                    EmployeeTerritories record = new EmployeeTerritories();

                    record.EmployeeID = reader.GetInt32(0);
                    record.TerritoryID = reader.GetString(1);

                    temp.Add(record);
                }

                reader.Close();

                employeeTerritories.Clear();
                employeeTerritories = temp;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            connection.Close();
        }

        public void UpdateOrderDetails()
        {
            ClearAll();

            SqlConnection connection = new SqlConnection(connectionString);
            List<OrderDetails> temp = new List<OrderDetails>();

            try
            {
                connection.Open();

                string cmd = "SELECT * FROM [Order Details]";
                SqlCommand Command = new SqlCommand(cmd, connection);

                SqlDataReader reader = Command.ExecuteReader();

                while (reader.Read())
                {
                    OrderDetails record = new OrderDetails();

                    record.OrderID = reader.GetInt32(0);
                    record.ProductID = reader.GetInt32(1);
                    record.UnitPrice = reader.GetDecimal(2);
                    record.Quantity = reader.GetInt16(3).ToString();
                    record.Discount = Convert.ToString(reader.GetSqlSingle(4));

                    temp.Add(record);
                }

                reader.Close();

                orderDetails.Clear();
                orderDetails = temp;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            connection.Close();
        }

        public void UpdateOrders()
        {
            ClearAll();

            SqlConnection connection = new SqlConnection(connectionString);
            List<Orders> temp = new List<Orders>();

            try
            {
                connection.Open();

                string cmd = "SELECT * FROM [Orders]";
                SqlCommand Command = new SqlCommand(cmd, connection);

                SqlDataReader reader = Command.ExecuteReader();

                while (reader.Read())
                {
                    Orders record = new Orders();

                    record.OrderID = reader.GetInt32(0);
                    record.CustomerID = reader.GetString(1);
                    record.EmployeeID = reader.GetInt32(2);
                    record.OrderDate = reader.GetDateTime(3);
                    record.RequiredDate = reader.GetDateTime(4);
                    try
                    {
                        record.ShippedDate = reader.GetDateTime(5);
                    }
                    catch { record.ShippedDate = DateTime.MinValue; }
                    record.ShipVia = reader.GetInt32(6);
                    record.Freight = reader.GetDecimal(7);
                    record.ShipName = reader.GetString(8);
                    record.ShipAddress = reader.GetString(9);
                    record.ShipCity = reader.GetString(10);
                    try
                    {
                        record.ShipRegion = reader.GetString(11);
                    }
                    catch { record.ShipRegion = "-"; }
                    try
                    {
                        record.ShipPostalCode = reader.GetString(12);
                    }
                    catch { record.ShipPostalCode = "-"; }
                    record.ShipCountry = reader.GetString(13);

                    temp.Add(record);
                }

                reader.Close();

                orders.Clear();
                orders = temp;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            connection.Close();
        }

        public void UpdateProducts()
        {
            ClearAll();

            SqlConnection connection = new SqlConnection(connectionString);
            List<Products> temp = new List<Products>();

            try
            {
                connection.Open();

                string cmd = "SELECT * FROM [Products]";
                SqlCommand Command = new SqlCommand(cmd, connection);

                SqlDataReader reader = Command.ExecuteReader();

                while (reader.Read())
                {
                    Products record = new Products();

                    record.ProductID = reader.GetInt32(0);
                    record.ProductName = reader.GetString(1);
                    record.SupplierID = reader.GetInt32(2);
                    record.CategoryID = reader.GetInt32(3);
                    record.QuantityPerUnit = reader.GetString(4);
                    record.UnitPrice = reader.GetDecimal(5);
                    record.UnitsInStock = reader.GetInt16(6);
                    record.UnitsOnOrder = reader.GetInt16(7);
                    record.ReorderLevel = reader.GetInt16(8);
                    record.Discontinued = reader.GetBoolean(9);

                    temp.Add(record);
                }

                reader.Close();

                products.Clear();
                products = temp;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            connection.Close();
        }

        public void UpdateRegion()
        {
            ClearAll();

            SqlConnection connection = new SqlConnection(connectionString);
            List<Region> temp = new List<Region>();

            try
            {
                connection.Open();

                string cmd = "SELECT * FROM [Region]";
                SqlCommand Command = new SqlCommand(cmd, connection);

                SqlDataReader reader = Command.ExecuteReader();

                while (reader.Read())
                {
                    Region record = new Region();

                    record.RegionID = reader.GetInt32(0);
                    record.RegionDescription = reader.GetString(1);

                    temp.Add(record);
                }

                reader.Close();

                regions.Clear();
                regions = temp;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            connection.Close();
        }

        public void UpdateShippers()
        {
            ClearAll();

            SqlConnection connection = new SqlConnection(connectionString);
            List<Shippers> temp = new List<Shippers>();

            try
            {
                connection.Open();

                string cmd = "SELECT * FROM [Shippers]";
                SqlCommand Command = new SqlCommand(cmd, connection);

                SqlDataReader reader = Command.ExecuteReader();

                while (reader.Read())
                {
                    Shippers record = new Shippers();

                    record.ShipperID = reader.GetInt32(0);
                    record.CompanyName = reader.GetString(1);
                    record.Phone = reader.GetString(2);

                    temp.Add(record);
                }

                reader.Close();

                shippers.Clear();
                shippers = temp;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            connection.Close();
        }

        public void UpdateSuppliers()
        {
            ClearAll();

            SqlConnection connection = new SqlConnection(connectionString);
            List<Suppliers> temp = new List<Suppliers>();

            try
            {
                connection.Open();

                string cmd = "SELECT * FROM [Suppliers]";
                SqlCommand Command = new SqlCommand(cmd, connection);

                SqlDataReader reader = Command.ExecuteReader();

                while (reader.Read())
                {
                    Suppliers record = new Suppliers();

                    record.SupplierID = reader.GetInt32(0);
                    record.CompanyName = reader.GetString(1);
                    record.ContactName = reader.GetString(2);
                    record.ContactTitle = reader.GetString(3);
                    record.Address = reader.GetString(4);
                    record.City = reader.GetString(5);
                    try
                    {
                        record.Region = reader.GetString(6);
                    }
                    catch { record.Region = "-"; }
                    record.PostalCode = reader.GetString(7);
                    record.Country = reader.GetString(8);
                    record.Phone = reader.GetString(9);
                    try
                    {
                        record.Fax = reader.GetString(10);
                    }
                    catch { record.Fax = "-"; }
                    try
                    {
                        record.HomePage = reader.GetString(11);
                    }
                    catch { record.HomePage = "-"; }

                    temp.Add(record);
                }

                reader.Close();

                suppliers.Clear();
                suppliers = temp;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            connection.Close();
        }

        public void UpdateTerritories()
        {
            ClearAll();

            SqlConnection connection = new SqlConnection(connectionString);
            List<Territories> temp = new List<Territories>();

            try
            {
                connection.Open();

                string cmd = "SELECT * FROM [Territories]";
                SqlCommand Command = new SqlCommand(cmd, connection);

                SqlDataReader reader = Command.ExecuteReader();

                while (reader.Read())
                {
                    Territories record = new Territories();

                    record.TerritoryID = reader.GetString(0);
                    record.TerritoryDescription = reader.GetString(1);
                    record.RegionID = reader.GetInt32(2);

                    temp.Add(record);
                }

                reader.Close();

                territories.Clear();
                territories = temp;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            connection.Close();
        }

        public void UpdateAll()
        {
            UpdateCategories();
            UpdateCustomerDemographics();
            UpdateCustomers();
            UpdateEmployees();
            UpdateEmployeeTerritories();
            UpdateOrderDetails();
            UpdateOrders();
            UpdateProducts();
            UpdateRegion();
            UpdateShippers();
            UpdateSuppliers();
            UpdateTerritories();
        }

        public void ClearAll()
        {
            categories.Clear();
            customerDemographics.Clear();
            customers.Clear();
            employees.Clear();
            employeeTerritories.Clear();
            orderDetails.Clear();
            orders.Clear();
            products.Clear();
            regions.Clear();
            shippers.Clear();
            suppliers.Clear();
            territories.Clear();
        }

        public DBWorker()
        {
            categories = new List<Categories>();
            customerDemographics = new List<CustomerDemographics>();
            customers = new List<Customers>();
            employees = new List<Employees>();
            employeeTerritories = new List<EmployeeTerritories>();
            orderDetails = new List<OrderDetails>();
            orders = new List<Orders>();
            products = new List<Products>();
            regions = new List<Region>();
            shippers = new List<Shippers>();
            suppliers = new List<Suppliers>();
            territories = new List<Territories>();
        }
    }
}
