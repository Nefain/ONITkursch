using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ONIT_Kursov_3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DBWorker dBWorker;
        //Номер открытой таблицы
        int numOfTable = 1;
        public MainWindow()
        {
            InitializeComponent();
            this.ContentRendered += MainWindow_ContentRendered;
            this.SizeChanged += MainWindow_SizeChanged;
            gridTable.SizeChanged += GridTable_SizeChanged;
        }

        private void GridTable_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.Width = GetGridWidth(gridTable) + 80;
        }

        private void MainWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            combox.Width = Math.Abs(Math.Abs(ExportBut.Width - e.NewSize.Width) - 50);
        }

        private void MainWindow_ContentRendered(object sender, EventArgs e)
        {
            dBWorker = new DBWorker();
            dBWorker.UpdateCategories();
            gridTable.ItemsSource = dBWorker.categories;      
        }

        private double GetGridWidth(DataGrid datagrid)
        {
            double w = 0;
            foreach(var col in datagrid.Columns)
            {
                w += col.ActualWidth;
            }
            return w;
        }

        private void ShowCategoriesTable(object sender, RoutedEventArgs e)
        {
            dBWorker.UpdateCategories();
            gridTable.ItemsSource = dBWorker.categories;
            labelTableName.Content = "Categories";
            numOfTable = 1;
        }
        private void ShowCustomerDemographicsTable(object sender, RoutedEventArgs e)
        {
            dBWorker.UpdateCustomerDemographics();
            gridTable.ItemsSource = dBWorker.customerDemographics;
            labelTableName.Content = "Customer Demographics";
            numOfTable = 2;
        }
        private void ShowCustomersTable(object sender, RoutedEventArgs e)
        {
            dBWorker.UpdateCustomers();
            gridTable.ItemsSource = dBWorker.customers;
            labelTableName.Content = "Customers";
            numOfTable = 3;
        }
        private void ShowEmployeesTable(object sender, RoutedEventArgs e)
        {
            dBWorker.UpdateEmployees();
            gridTable.ItemsSource = dBWorker.employees;
            labelTableName.Content = "Employees";
            numOfTable = 4;
        }
        private void ShowEmployeeTerritoriesTable(object sender, RoutedEventArgs e)
        {
            dBWorker.UpdateEmployeeTerritories();
            gridTable.ItemsSource = dBWorker.employeeTerritories;
            labelTableName.Content = "Employee Territories";
            numOfTable = 5;
        }
        private void ShowOrderDetailsTable(object sender, RoutedEventArgs e)
        {
            dBWorker.UpdateOrderDetails();
            gridTable.ItemsSource = dBWorker.orderDetails;
            labelTableName.Content = "Order Details";
            numOfTable = 6;
        }
        private void ShowOrdersTable(object sender, RoutedEventArgs e)
        {
            dBWorker.UpdateOrders();
            gridTable.ItemsSource = dBWorker.orders;
            labelTableName.Content = "Orders";
            numOfTable = 7;
        }
        private void ShowProductsTable(object sender, RoutedEventArgs e)
        {
            dBWorker.UpdateProducts();
            gridTable.ItemsSource = dBWorker.products;
            labelTableName.Content = "Products";
            numOfTable = 8;
        }
        private void ShowRegionTable(object sender, RoutedEventArgs e)
        {
            dBWorker.UpdateRegion();
            gridTable.ItemsSource = dBWorker.regions;
            labelTableName.Content = "Region";
            numOfTable = 9;
        }
        private void ShowShippersTable(object sender, RoutedEventArgs e)
        {
            dBWorker.UpdateShippers();
            gridTable.ItemsSource = dBWorker.shippers;
            labelTableName.Content = "Shippers";
            numOfTable = 10;
        }
        private void ShowSuppliersTable(object sender, RoutedEventArgs e)
        {
            dBWorker.UpdateSuppliers();
            gridTable.ItemsSource = dBWorker.suppliers;
            labelTableName.Content = "Suppliers";
            numOfTable = 11;
        }
        private void ShowTerritoriesTable(object sender, RoutedEventArgs e)
        {
            dBWorker.UpdateTerritories();
            gridTable.ItemsSource = dBWorker.territories;
            labelTableName.Content = "Territories";
            numOfTable = 12;
        }

        private void ExcelExport(object sender, RoutedEventArgs e)
        {
            SaveFileDialog fileManager = new SaveFileDialog();
            fileManager.Filter = "Файл excel (*.xlsx)|*.xlsx";
            fileManager.ShowDialog();
            try
            {
                var item = fileManager.FileName;
                if (item != "")
                {
                    ExcelWorker excelWorker = new ExcelWorker(item);
                    switch (numOfTable)
                    {
                        case 1:
                            {
                                excelWorker.ExportToExcel(dBWorker.categories);
                                break;
                            }
                        case 2:
                            {
                                excelWorker.ExportToExcel(dBWorker.customerDemographics);
                                break;
                            }
                        case 3:
                            {
                                excelWorker.ExportToExcel(dBWorker.customers);
                                break;
                            }
                        case 4:
                            {
                                excelWorker.ExportToExcel(dBWorker.employees);
                                break;
                            }
                        case 5:
                            {
                                excelWorker.ExportToExcel(dBWorker.employeeTerritories);
                                break;
                            }
                        case 6:
                            {
                                excelWorker.ExportToExcel(dBWorker.orderDetails);
                                break;
                            }
                        case 7:
                            {
                                excelWorker.ExportToExcel(dBWorker.orders);
                                break;
                            }
                        case 8:
                            {
                                excelWorker.ExportToExcel(dBWorker.products);
                                break;
                            }
                        case 9:
                            {
                                excelWorker.ExportToExcel(dBWorker.regions);
                                break;
                            }
                        case 10:
                            {
                                excelWorker.ExportToExcel(dBWorker.shippers);
                                break;
                            }
                        case 11:
                            {
                                excelWorker.ExportToExcel(dBWorker.suppliers);
                                break;
                            }
                        case 12:
                            {
                                excelWorker.ExportToExcel(dBWorker.territories);
                                break;
                            }

                    }
                }
            }
            catch (Exception ex) { System.Windows.MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); }
            MessageBox.Show("Сохранение успешно завершено", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {

        }
    }
}
