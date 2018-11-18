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
using TaxiDriverApp.IOTypes;
using TaxiDriverApp.DataTypes;

namespace TaxiDriverApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TaxiDriver currentDriver;
        private ClientsDB clientsInfo;
        private DriversDB driversInfo;
        private OrdersDB ordersInfo;
        private int counter;
        public MainWindow()
        {
            InitializeComponent();
            counter = 0;
            clientsInfo = new ClientsDB("../../InputData/ClientsData.txt");
            clientsInfo.ReadFromFile();

            driversInfo = new DriversDB("../../InputData/DriversData.txt");
            driversInfo.ReadFromFile();
        }
        private void startWork_Click(object sender, RoutedEventArgs e)
        {
            currentDriver = driversInfo.FindDriver(driverSurName.Text, driverUserName.Text);
            driverInfoSurnameNameDetails.Content = currentDriver.Surname + " " + currentDriver.Name;
            driverInfoAgeDetails.Content = currentDriver.Age;
            driverInfoCarDetails.Content = currentDriver.CarNumber;
            driverInfoExpDetails.Content = currentDriver.Experience;
            driverInfoCostDetails.Content = currentDriver.PayCheck + " грн";
            driverInfoCostPerMinDetails.Content = currentDriver.CostPerMinute;

            ordersInfo = new OrdersDB("../../InputData/OrdersData.txt", clientsInfo, driversInfo);
            ordersInfo.ReadFromFile();
            ShowOrdersInListView();
        }
        private void endOfWork_Click(object sender, RoutedEventArgs e)
        {
            driversInfo.UpdateDriver(currentDriver);
            driversInfo.WriteToFile();
            ordersInfo.WriteToFile();
            MessageBox.Show(String.Format("Дякуємо за роботу, {0}!", currentDriver.Name), "До побачення");
            Close();
        }
        private void orders_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as ListView).SelectedItem;
            if (item != null && counter == 0)
            {
                counter++;
                OrderWindow wind = new OrderWindow(item as TaxiOrder);
                wind.Show();
            }
        }
        public void updateCounter()
        {
            counter--;
        }
        public void updateOrders(TaxiOrder orderToUpdate)
        {
            ordersInfo.UpdateOrder(orderToUpdate);
            currentDriver.PayCheck += orderToUpdate.Cost;
            driverInfoCostDetails.Content = currentDriver.PayCheck + " грн";
            ShowOrdersInListView();
        }
        private void ShowOrdersInListView()
        {
            orders.Items.Clear();
            foreach (TaxiOrder order in ordersInfo.AllOrders)
            {
                if (order.Driver.Id == currentDriver.Id)
                {
                    orders.Items.Add(order);
                }
            }
        }
    }
}